using Dapper;
using beautyCenterSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BeautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using Microsoft.Data.SqlClient;
using beautyCenterSystem.viewsmodels;

namespace beautyCenterSystem.Data.Repositories
{
    public class AppointmentRepository : BaseRepository
    {
        public AppointmentRepository(DbConnectionFactory dbFactory) : base(dbFactory) { }

        // --------------------------------------------------------
        // دوال التحكم في حالة الخدمات (الجديدة)
        // --------------------------------------------------------

        public async Task<bool> StartServiceAsync(int detailId, int appointmentId)
        {
            using var db = _dbFactory.CreateConnection();
            var parameters = new { DetailID = detailId, AppointmentID = appointmentId };

            // استدعاء الـ Stored Procedure
            await db.ExecuteAsync("sp_StartService", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public async Task<bool> CompleteServiceAsync(int detailId, int appointmentId)
        {
            using var db = _dbFactory.CreateConnection();
            var parameters = new { DetailID = detailId, AppointmentID = appointmentId };

            // استدعاء الـ Stored Procedure
            await db.ExecuteAsync("sp_CompleteService", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        // --------------------------------------------------------
        // العمليات الأساسية للحجز
        // --------------------------------------------------------

        // 1. إضافة حجز جديد
        public async Task<bool> CreateAsync(Appointment appointment)
        {
            using var db = _dbFactory.CreateConnection();
            await ((SqlConnection)db).OpenAsync();
            using var transaction = db.BeginTransaction();

            try
            {
                // الإجمالي يتم حسابه تلقائياً عبر الـ Trigger لاحقاً، لذلك نمرر 0 مبدئياً
                string sqlApp = @"INSERT INTO Appointments (CustomerID, AppointmentDate, TotalPrice, Status, CreatedBy) 
                                  VALUES (@CustomerID, @AppointmentDate, 0, @Status, @CreatedBy);
                                  SELECT CAST(SCOPE_IDENTITY() as int);";

                int appId = await db.QuerySingleAsync<int>(sqlApp, appointment, transaction);

                string sqlDetails = @"INSERT INTO AppointmentDetails (AppointmentID, ServiceID, MaterialID, Quantity, PriceAtSale, EmployeeID, Status) 
                                      VALUES (@AppId, @SId, @MId, @Qty, @Price, @EId, 'Pending')";

                if (appointment.SelectedServices != null)
                {
                    foreach (var item in appointment.SelectedServices)
                    {
                        await db.ExecuteAsync(sqlDetails, new
                        {
                            AppId = appId,
                            SId = item.ServiceID,
                            MId = item.MaterialID,
                            Qty = item.Quantity,
                            Price = item.Price,
                            EId = item.EmployeeID
                        }, transaction);
                    }
                }

                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task<Appointment> GetByIdAsync(int appId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"SELECT A.*, C.CustomerName 
                           FROM Appointments A 
                           JOIN Customers C ON A.CustomerID = C.CustomerID 
                           WHERE A.AppointmentID = @Id";
            return await db.QueryFirstOrDefaultAsync<Appointment>(sql, new { Id = appId });
        }

        // 2. جلب مواعيد يوم معين
        public async Task<IEnumerable<Appointment>> GetByDateAsync(DateTime? date = null, int? roomId = null)
        {
            using var db = _dbFactory.CreateConnection();

            // استعلام موحد بدون تجميع نصوص SQL
            // عند اختيار غرفة: يعيد فقط الحجوزات التي تحتوي على خدمة في تلك الغرفة
            // عند اختيار "الكل" (roomId = null أو 0): يعيد جميع حجوزات اليوم
            const string sql = @"
                SELECT DISTINCT
                    A.AppointmentID,
                    A.CustomerID,
                    A.AppointmentDate,
                    A.TotalPrice,
                    A.Status,
                    A.CreatedBy,
                    A.ArrivalTime,
                    A.FinishTime,
                    C.CustomerName,
                    P.PaymentMethod
                FROM Appointments A
                LEFT JOIN Customers C ON A.CustomerID = C.CustomerID
                LEFT JOIN AppointmentDetails AD ON A.AppointmentID = AD.AppointmentID
                LEFT JOIN Services S ON AD.ServiceID = S.ServiceID
                LEFT JOIN Payments P ON A.AppointmentID = P.AppointmentID
                WHERE
                    A.Status != 'Cancelled'
                    AND (@TargetDate IS NULL OR CAST(A.AppointmentDate AS DATE) = CAST(@TargetDate AS DATE))
                    AND (@RoomId IS NULL OR S.RoomID = @RoomId)
                ORDER BY A.AppointmentDate ASC, A.ArrivalTime ASC";

            var result = await db.QueryAsync<Appointment>(sql, new { TargetDate = date, RoomId = roomId });
            return result ?? Enumerable.Empty<Appointment>();
        }

        // 3. تغيير حالة الحجز العامة
        public async Task<bool> UpdateStatusAsync(int appointmentId, string newStatus)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "UPDATE Appointments SET Status = @Status WHERE AppointmentID = @Id";
            int rows = await db.ExecuteAsync(sql, new { Status = newStatus, Id = appointmentId });
            return rows > 0;
        }

        // إلغاء أو تعديل حجز مكتمل مدفوع واسترداد قيمته ومواده من الخزينة والمخزون
        public async Task<bool> ReverseCompletedAppointmentAsync(int appointmentId, string targetStatus = "Cancelled")
        {
            using var db = _dbFactory.CreateConnection();
            await ((SqlConnection)db).OpenAsync();
            using var transaction = db.BeginTransaction();

            try
            {
                // جلب مبلغ الدفع والخزينة
                string sqlPayment = "SELECT TOP 1 AmountPaid, SafeID FROM Payments WHERE AppointmentID = @AppId ORDER BY PaymentID DESC";
                var paymentInfo = await db.QueryFirstOrDefaultAsync<dynamic>(sqlPayment, new { AppId = appointmentId }, transaction);

                if (paymentInfo != null && paymentInfo.SafeID != null)
                {
                    decimal amountPaid = paymentInfo.AmountPaid;
                    int safeId = paymentInfo.SafeID;

                    // إرجاع المبلغ للخزينة (استرداد/خصم)
                    string updateSafeSql = "UPDATE Safes SET Balance = Balance - @Amount WHERE SafeID = @SafeId";
                    await db.ExecuteAsync(updateSafeSql, new { Amount = amountPaid, SafeId = safeId }, transaction);
                    
                    // حذف الدفعة حتى لا تحسب في الإيرادات
                    string deletePaymentSql = "DELETE FROM Payments WHERE AppointmentID = @AppId";
                    await db.ExecuteAsync(deletePaymentSql, new { AppId = appointmentId }, transaction);
                }

                // إرجاع المواد المستهلكة للمخزون
                string stockUpdateSql = @"
                    UPDATE Materials 
                    SET StockQuantity = StockQuantity + AD.Quantity 
                    FROM Materials M 
                    INNER JOIN AppointmentDetails AD ON M.MaterialID = AD.MaterialID 
                    WHERE AD.AppointmentID = @AppId AND AD.MaterialID IS NOT NULL";
                await db.ExecuteAsync(stockUpdateSql, new { AppId = appointmentId }, transaction);

                // تغيير الحالة
                string updateAppSql = "UPDATE Appointments SET Status = @TargetStatus WHERE AppointmentID = @AppId";
                await db.ExecuteAsync(updateAppSql, new { AppId = appointmentId, TargetStatus = targetStatus }, transaction);

                // تصفير عمولات الموظفات لهذا الموعد 
                string zeroCommissionsSql = "UPDATE AppointmentDetails SET CommissionAmount = 0 WHERE AppointmentID = @AppId";
                await db.ExecuteAsync(zeroCommissionsSql, new { AppId = appointmentId }, transaction);

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"فشل عملية استرداد الحجز المكتمل: {ex.Message}");
            }
        }

        // 4. جلب تفاصيل حجز معين - تم إضافة DetailID والحالات والأوقات
        public async Task<IEnumerable<AppointmentDetailDto>> GetAppointmentServicesAsync(int appId)
        {
            using var db = _dbFactory.CreateConnection();

            string sql = @"SELECT 
                             AD.DetailID,              -- مهم لأزرار البدء والإنهاء
                             AD.ServiceID, 
                             AD.MaterialID, 
                             AD.EmployeeID, 
                             AD.Quantity,            
                             AD.PriceAtSale AS Price,
                             AD.CommissionAmount,
                             AD.Status,                -- حالة الخدمة الفردية
                             AD.ActualStartTime,       -- وقت البدء الفعلي
                             AD.ActualEndTime,         -- وقت الانتهاء الفعلي
                             COALESCE(S.ServiceName, M.MaterialName) AS Name,
                             CASE 
                                 WHEN AD.ServiceID IS NOT NULL THEN R.RoomName 
                                 WHEN AD.MaterialID IS NOT NULL THEN N'كافيتيريا'
                                 ELSE N'-' 
                             END AS RoomName,
                             E.EmployeeName
                         FROM AppointmentDetails AD 
                         LEFT JOIN Services S ON AD.ServiceID = S.ServiceID 
                         LEFT JOIN Materials M ON AD.MaterialID = M.MaterialID
                         LEFT JOIN Rooms R ON S.RoomID = R.RoomID 
                         LEFT JOIN Employees E ON AD.EmployeeID = E.EmployeeID
                         WHERE AD.AppointmentID = @AppId";

            return await db.QueryAsync<AppointmentDetailDto>(sql, new { AppId = appId });
        }

        // 5. فحص تعارض المواعيد
        public async Task<string> CheckConflictAsync(DateTime startTime, int durationMinutes, List<int> serviceIds, int currentAppId = 0)
        {
            if (serviceIds == null || !serviceIds.Any())
                return null;

            using var db = _dbFactory.CreateConnection();
            DateTime endTime = startTime.AddMinutes(durationMinutes);

            string sql = @"
                SELECT TOP 1 S.ServiceName + N' في غرفة: ' + ISNULL(R.RoomName, CAST(S.RoomID AS NVARCHAR(10)))
                FROM AppointmentDetails AD
                JOIN Appointments A ON AD.AppointmentID = A.AppointmentID
                JOIN Services S ON AD.ServiceID = S.ServiceID
                LEFT JOIN Rooms R ON S.RoomID = R.RoomID
                WHERE 
                    A.Status IN ('Pending', 'InProgress') 
                    AND A.AppointmentID != @CurrentId 
                    AND AD.ServiceID IS NOT NULL
                    AND S.RoomID IN (
                        SELECT RoomID FROM Services WHERE ServiceID IN @SIds
                    )
                    AND (
                        (@Start < DATEADD(minute, (
                            SELECT SUM(s2.DurationMinutes) 
                            FROM Services s2 
                            JOIN AppointmentDetails ad2 ON s2.ServiceID = ad2.ServiceID 
                            WHERE ad2.AppointmentID = A.AppointmentID AND ad2.ServiceID IS NOT NULL
                        ), A.AppointmentDate))
                        AND (@End > A.AppointmentDate)
                    )";

            var conflictingService = await db.QueryFirstOrDefaultAsync<string>(sql, new
            {
                Start = startTime,
                End = endTime,
                SIds = serviceIds,
                CurrentId = currentAppId
            });

            return conflictingService;
        }

        // 6. تحديث الحجز 
        public async Task<bool> UpdateAsync(Appointment appointment)
        {
            using var db = _dbFactory.CreateConnection();
            await ((SqlConnection)db).OpenAsync(); // تم التعديل إلى اتصال غير متزامن
            using var transaction = db.BeginTransaction();

            try
            {
                // لا نحدث TotalPrice يدوياً هنا، الـ Trigger سيتولى الأمر بمجرد الإدراج
                string sqlUpdateApp = @"UPDATE Appointments SET 
                                        AppointmentDate = @AppointmentDate, 
                                        CustomerID = @CustomerID
                                        WHERE AppointmentID = @AppointmentID";

                await db.ExecuteAsync(sqlUpdateApp, appointment, transaction);

                // ملاحظة هامة: الحذف والإضافة يفضل ألا يمس الخدمات التي بدأت بالفعل.
                // تم تعديل الاستعلام لحذف الخدمات المعلقة (Pending) فقط لتجنب ضياع أوقات الخدمات المكتملة.
                string sqlDeleteDetails = "DELETE FROM AppointmentDetails WHERE AppointmentID = @AppointmentID AND Status = 'Pending'";
                await db.ExecuteAsync(sqlDeleteDetails, new { AppointmentID = appointment.AppointmentID }, transaction);

                string sqlInsertDetails = @"INSERT INTO AppointmentDetails (AppointmentID, ServiceID, MaterialID, Quantity, PriceAtSale, EmployeeID, Status) 
                                            VALUES (@AppId, @SId, @MId, @Qty, @Price, @EId, 'Pending')";

                if (appointment.SelectedServices != null)
                {
                    foreach (var item in appointment.SelectedServices)
                    {
                        // لتجنب تكرار إدخال خدمات تم إنهاؤها أو بدأت، نقوم بإدخال الخدمات المعلقة فقط أو المضافة حديثاً
                        if (item.Status == "Pending" || string.IsNullOrEmpty(item.Status))
                        {
                            await db.ExecuteAsync(sqlInsertDetails, new
                            {
                                AppId = appointment.AppointmentID,
                                SId = item.ServiceID,
                                MId = item.MaterialID,
                                Qty = item.Quantity,
                                Price = item.Price,
                                EId = item.EmployeeID
                            }, transaction);
                        }
                    }
                }

                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        // 7. إتمام العملية مالياً
        public async Task<bool> CompleteAndPayAsync(int appId, decimal amountSystem, decimal amountPaid, decimal discount, string method, int userId)
        {
            using var db = _dbFactory.CreateConnection();
            if (db.State != ConnectionState.Open)
                await ((SqlConnection)db).OpenAsync(); // تم التعديل إلى اتصال غير متزامن

            using var transaction = db.BeginTransaction();

            try
            {
                string getSafeSql = "SELECT SafeID FROM PaymentMapping WHERE MethodName = @Method";
                int safeId = await db.QueryFirstOrDefaultAsync<int>(getSafeSql, new { Method = method }, transaction);

                if (safeId == 0)
                    throw new Exception($"لم يتم تحديد خزنة افتراضية لطريقة الدفع: {method}.");

                string updateAppSql = "UPDATE Appointments SET Status = 'Completed' WHERE AppointmentID = @Id";
                await db.ExecuteAsync(updateAppSql, new { Id = appId }, transaction);

                string stockUpdateSql = @"
                    UPDATE Materials 
                    SET StockQuantity = StockQuantity - AD.Quantity 
                    FROM Materials M 
                    INNER JOIN AppointmentDetails AD ON M.MaterialID = AD.MaterialID 
                    WHERE AD.AppointmentID = @AppId AND AD.MaterialID IS NOT NULL";

                await db.ExecuteAsync(stockUpdateSql, new { AppId = appId }, transaction);

                string updateCommissionsSql = @"
                    UPDATE AD
                    SET AD.CommissionAmount = (CAST(E.CommissionRate AS DECIMAL(18,2)) / 100.0) * CAST(S.EmployeeBasePrice AS DECIMAL(18,2))
                    FROM AppointmentDetails AD
                    INNER JOIN Employees E ON AD.EmployeeID = E.EmployeeID
                    INNER JOIN Services S ON AD.ServiceID = S.ServiceID
                    WHERE AD.AppointmentID = @AppId 
                      AND AD.ServiceID IS NOT NULL 
                      AND AD.EmployeeID IS NOT NULL";

                await db.ExecuteAsync(updateCommissionsSql, new { AppId = appId }, transaction);

                string insertPaymentSql = @"INSERT INTO Payments (AppointmentID, AmountSystem, AmountPaid, Discount, PaymentMethod, IssuedBy, SafeID, PaymentDate) 
                                           VALUES (@AppId, @SysAmt, @PaidAmt, @Disc, @Method, @UserId, @SafeId, GETDATE())";

                await db.ExecuteAsync(insertPaymentSql, new
                {
                    AppId = appId,
                    SysAmt = amountSystem,
                    PaidAmt = amountPaid,
                    Disc = discount,
                    Method = method,
                    UserId = userId,
                    SafeId = safeId
                }, transaction);

                string updateSafeSql = "UPDATE Safes SET Balance = Balance + @Amount WHERE SafeID = @SafeId";
                await db.ExecuteAsync(updateSafeSql, new { Amount = amountPaid, SafeId = safeId }, transaction);

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"فشل إتمام العملية مالياً: {ex.Message}");
            }
        }

        // 8. إنشاء حجز وجلب المعرف
        public async Task<int> CreateAndGetIdAsync(Appointment appointment)
        {
            using var db = _dbFactory.CreateConnection();
            await ((SqlConnection)db).OpenAsync();
            using var transaction = db.BeginTransaction();

            try
            {
                string sqlApp = @"INSERT INTO Appointments (CustomerID, AppointmentDate, TotalPrice, Status, CreatedBy) 
                                  VALUES (@CustomerID, @AppointmentDate, 0, @Status, @CreatedBy);
                                  SELECT CAST(SCOPE_IDENTITY() as int);";

                int appId = await db.QuerySingleAsync<int>(sqlApp, appointment, transaction);

                string sqlDetails = @"INSERT INTO AppointmentDetails (AppointmentID, ServiceID, MaterialID, Quantity, PriceAtSale, EmployeeID, Status) 
                                      VALUES (@AppId, @SId, @MId, @Qty, @Price, @EId, 'Pending')";

                if (appointment.SelectedServices != null)
                {
                    foreach (var item in appointment.SelectedServices)
                    {
                        await db.ExecuteAsync(sqlDetails, new
                        {
                            AppId = appId,
                            SId = item.ServiceID,
                            MId = item.MaterialID,
                            Qty = item.Quantity,
                            Price = item.Price,
                            EId = item.EmployeeID
                        }, transaction);
                    }
                }

                transaction.Commit();
                return appId;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        // 9. الإحصائيات (KPIs)
        public async Task<(int completed, string topService, int avgTime)> GetTodayDashboardKPIsAsync()
        {
            using var db = _dbFactory.CreateConnection();

            string sql = @"
            SELECT COUNT(*) FROM Appointments WHERE Status = 'Completed' AND CAST(AppointmentDate AS DATE) = CAST(GETDATE() AS DATE);

            SELECT TOP 1 S.ServiceName
            FROM AppointmentDetails AD
            JOIN Services S ON AD.ServiceID = S.ServiceID
            JOIN Appointments A ON AD.AppointmentID = A.AppointmentID
            WHERE CAST(A.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE) AND AD.ServiceID IS NOT NULL
            GROUP BY S.ServiceName ORDER BY COUNT(*) DESC;

            SELECT ISNULL(AVG(S.DurationMinutes), 0)
            FROM AppointmentDetails AD
            JOIN Services S ON AD.ServiceID = S.ServiceID
            JOIN Appointments A ON AD.AppointmentID = A.AppointmentID
            WHERE A.Status = 'Completed' AND CAST(A.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE) AND AD.ServiceID IS NOT NULL;";

            using var multi = await db.QueryMultipleAsync(sql);

            var completed = await multi.ReadFirstAsync<int>();
            var topService = await multi.ReadFirstOrDefaultAsync<string>() ?? "لا يوجد";
            var avgTime = await multi.ReadFirstAsync<int>();

            return (completed, topService, avgTime);
        }

        // 10. حالة الغرف - تم تحديثها لجلب الخدمة "قيد التنفيذ" فعلياً للحصول على دقة أعلى
        public async Task<IEnumerable<dynamic>> GetRoomsStatusAsync()
        {
            using var db = _dbFactory.CreateConnection();

            string sql = @"
            SELECT 
                R.RoomID, 
                R.RoomName,
                ActiveApp.AppointmentStatus,
                ActiveApp.DetailStatus,
                ActiveApp.CustomerName,
                ActiveApp.ServiceName,
                ActiveApp.ActualStartTime AS StartTime,
                ActiveApp.DurationMinutes
            FROM Rooms R
            OUTER APPLY (
                SELECT TOP 1 
                    A.Status as AppointmentStatus,
                    AD.Status as DetailStatus,
                    C.CustomerName, 
                    S.ServiceName, 
                    AD.ActualStartTime, 
                    S.DurationMinutes
                FROM AppointmentDetails AD
                JOIN Appointments A ON AD.AppointmentID = A.AppointmentID
                JOIN Services S ON AD.ServiceID = S.ServiceID
                JOIN Customers C ON A.CustomerID = C.CustomerID
                WHERE S.RoomID = R.RoomID 
                AND AD.ServiceID IS NOT NULL
                AND AD.Status = 'InProgress' -- دقة أعلى: الغرفة مشغولة فقط إذا كانت الخدمة قيد التنفيذ
                AND CAST(A.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)
                ORDER BY AD.ActualStartTime DESC 
            ) AS ActiveApp
            WHERE R.IsActive = 1 AND R.IsCaffeteria = 0";

            return await db.QueryAsync(sql);
        }
    }
}