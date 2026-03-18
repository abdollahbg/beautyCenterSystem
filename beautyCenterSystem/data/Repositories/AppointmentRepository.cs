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

namespace beautyCenterSystem.Data.Repositories
{
    public class AppointmentRepository : BaseRepository
    {
        public AppointmentRepository(DbConnectionFactory dbFactory) : base(dbFactory) { }

        // 1. إضافة حجز جديد مع خدماته (Master-Detail Transaction)
        public async Task<bool> CreateAsync(Appointment appointment)
        {
            using var db = _dbFactory.CreateConnection();
            await ((SqlConnection)db).OpenAsync(); // فتح الاتصال بشكل Async أفضل
            using var transaction = db.BeginTransaction();

            try
            {
                string sqlApp = @"INSERT INTO Appointments (CustomerID, AppointmentDate, TotalPrice, Status, CreatedBy) 
                          VALUES (@CustomerID, @AppointmentDate, @TotalPrice, @Status, @CreatedBy);
                          SELECT CAST(SCOPE_IDENTITY() as int);";

                int appId = await db.QuerySingleAsync<int>(sqlApp, appointment, transaction);

                string sqlDetails = "INSERT INTO AppointmentDetails (AppointmentID, ServiceID) VALUES (@AppId, @SId)";

                // تحسين: تنفيذ الإدخال المتكرر بشكل أسرع
                foreach (var service in appointment.SelectedServices)
                {
                    await db.ExecuteAsync(sqlDetails, new { AppId = appId, SId = service.ServiceID }, transaction);
                }

                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                // الـ Transaction سيقوم بعمل Rollback تلقائياً عند حدوث Dispose إذا لم يتم عمل Commit
                // ولكن كتابته صراحة جيدة
                transaction.Rollback();
                throw;
            }
            // الـ using سيغلق الاتصال هنا فوراً
        }
        public async Task<Appointment> GetByIdAsync(int appId)
        {
            using var db = _dbFactory.CreateConnection();
            // جلب الحجز مع اسم العميلة
            string sql = @"SELECT A.*, C.CustomerName 
                   FROM Appointments A 
                   JOIN Customers C ON A.CustomerID = C.CustomerID 
                   WHERE A.AppointmentID = @Id";
            return await db.QueryFirstOrDefaultAsync<Appointment>(sql, new { Id = appId });
        }

        // 2. جلب مواعيد يوم معين (للعرض في الجدول الرئيسي)
        public async Task<IEnumerable<Appointment>> GetByDateAsync(DateTime date)
        {
            using var db = _dbFactory.CreateConnection();
            // استخدم LEFT JOIN لضمان جلب الحجز حتى لو حدث خطأ في ربط العميلة
            string sql = @"SELECT A.*, C.CustomerName 
                   FROM Appointments A 
                   LEFT JOIN Customers C ON A.CustomerID = C.CustomerID 
                   WHERE CAST(A.AppointmentDate AS DATE) = CAST(@TargetDate AS DATE)
                   ORDER BY A.AppointmentDate ASC";

            var result = await db.QueryAsync<Appointment>(sql, new { TargetDate = date });
            return result ?? Enumerable.Empty<Appointment>(); // ضمان عدم إرجاع Null أبداً
        }

        // 3. تغيير حالة الحجز (مثلاً من Pending إلى Completed أو Cancelled)
        public async Task<bool> UpdateStatusAsync(int appointmentId, string newStatus)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "UPDATE Appointments SET Status = @Status WHERE AppointmentID = @Id";
            int rows = await db.ExecuteAsync(sql, new { Status = newStatus, Id = appointmentId });
            return rows > 0;
        }
        // 4. جلب تفاصيل حجز معين (الخدمات التي تم اختيارها فيه)
        public async Task<IEnumerable<Service>> GetAppointmentServicesAsync(int appId)
        {
            using var db = _dbFactory.CreateConnection();

            // 💡 التعديل هنا: قمنا بإضافة JOIN مع جدول Rooms وجلبنا RoomName
            string sql = @"SELECT S.*, R.RoomName 
                   FROM Services S 
                   JOIN AppointmentDetails AD ON S.ServiceID = AD.ServiceID 
                   LEFT JOIN Rooms R ON S.RoomID = R.RoomID 
                   WHERE AD.AppointmentID = @AppId";

            // الدابر (Dapper) سيقوم تلقائياً بربط RoomName بالخاصية الموجودة في كلاس Service
            return await db.QueryAsync<Service>(sql, new { AppId = appId });
        }
        // 5. فحص تعارض المواعيد بناءً على الغرف والوقت
        public async Task<string> CheckConflictAsync(DateTime startTime, int durationMinutes, List<int> serviceIds)
        {
            using var db = _dbFactory.CreateConnection();

            DateTime endTime = startTime.AddMinutes(durationMinutes);

            // تم تعديل SUM(Duration) إلى SUM(DurationMinutes)
            string sql = @"
        SELECT S.ServiceName + ' في غرفة: ' + CAST(S.RoomID AS VARCHAR)
        FROM AppointmentDetails AD
        JOIN Appointments A ON AD.AppointmentID = A.AppointmentID
        JOIN Services S ON AD.ServiceID = S.ServiceID
        WHERE A.Status != 'Cancelled'
        AND S.ServiceID IN (
            SELECT ServiceID FROM Services WHERE RoomID IN (
                SELECT RoomID FROM Services WHERE ServiceID IN @SIds
            )
        )
        AND (
            (@Start < DATEADD(minute, (SELECT SUM(DurationMinutes) FROM Services s2 
                                        JOIN AppointmentDetails ad2 ON s2.ServiceID = ad2.ServiceID 
                                        WHERE ad2.AppointmentID = A.AppointmentID), A.AppointmentDate))
            AND (@End > A.AppointmentDate)
        )
    ";

            var conflictingService = await db.QueryFirstOrDefaultAsync<string>(sql, new
            {
                Start = startTime,
                End = endTime,
                SIds = serviceIds
            });

            return conflictingService;
        }
        public async Task<bool> UpdateAsync(Appointment appointment)
        {
            using var db = _dbFactory.CreateConnection();
            db.Open();
            using var transaction = db.BeginTransaction();

            try
            {
                // 1. تحديث بيانات الحجز الأساسية (التاريخ، الإجمالي، الحالة)
                string sqlUpdateApp = @"UPDATE Appointments SET 
                                AppointmentDate = @AppointmentDate, 
                                TotalPrice = @TotalPrice,
                                CustomerID = @CustomerID
                                WHERE AppointmentID = @AppointmentID";

                await db.ExecuteAsync(sqlUpdateApp, appointment, transaction);

                // 2. حذف الخدمات القديمة المرتبطة بهذا الحجز
                string sqlDeleteDetails = "DELETE FROM AppointmentDetails WHERE AppointmentID = @AppointmentID";
                await db.ExecuteAsync(sqlDeleteDetails, new { AppointmentID = appointment.AppointmentID }, transaction);

                // 3. إضافة الخدمات الجديدة المختارة
                string sqlInsertDetails = "INSERT INTO AppointmentDetails (AppointmentID, ServiceID) VALUES (@AppId, @SId)";
                foreach (var service in appointment.SelectedServices)
                {
                    await db.ExecuteAsync(sqlInsertDetails, new { AppId = appointment.AppointmentID, SId = service.ServiceID }, transaction);
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

        public async Task<bool> CompleteAndPayAsync(int appId, decimal amountSystem, decimal amountPaid, decimal discount, string method, int userId)
        {
            using var db = _dbFactory.CreateConnection();
            // فتح الاتصال صراحةً قبل بدء الترانزاكشن
            if (db.State != ConnectionState.Open) db.Open();

            using var transaction = db.BeginTransaction();

            try
            {
                // 1. جلب الخزنة المربوطة آلياً بناءً على طريقة الدفع (Cash/Card)
                // ملاحظة: نمرر الترانزاكشن لضمان القراءة المتوافقة
                string getSafeSql = "SELECT SafeID FROM PaymentMapping WHERE MethodName = @Method";
                int safeId = await db.QueryFirstOrDefaultAsync<int>(getSafeSql, new { Method = method }, transaction);

                // حماية النظام: إذا لم يجد ربطاً في جدول PaymentMapping
                if (safeId == 0)
                {
                    throw new Exception($"لم يتم تحديد خزنة افتراضية لطريقة الدفع: {method}. يرجى ضبط الإعدادات أولاً.");
                }

                // 2. تحديث حالة الحجز إلى 'Completed'
                string updateAppSql = "UPDATE Appointments SET Status = 'Completed' WHERE AppointmentID = @Id";
                await db.ExecuteAsync(updateAppSql, new { Id = appId }, transaction);

                // 3. تسجيل الدفعة في جدول Payments
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

                // 4. تحديث رصيد الخزنة الصحيحة (زيادة المبلغ)
                string updateSafeSql = "UPDATE Safes SET Balance = Balance + @Amount WHERE SafeID = @SafeId";
                await db.ExecuteAsync(updateSafeSql, new { Amount = amountPaid, SafeId = safeId }, transaction);

                // اعتماد كافة العمليات
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                // تراجع عن كل العمليات في حال حدوث أي خطأ (SQL أو Logic)
                transaction.Rollback();
                // إعادة رمي الخطأ ليتم التقاطه في الواجهة وعرضه للمستخدم
                throw new Exception($"فشل إتمام العملية مالياً: {ex.Message}");
            }
        }
        // 1. إضافة حجز جديد وإرجاع الرقم التعريفي (ID) بدلاً من true/false
        public async Task<int> CreateAndGetIdAsync(Appointment appointment)
{
    using var db = _dbFactory.CreateConnection();
    await ((SqlConnection)db).OpenAsync(); 
    using var transaction = db.BeginTransaction();

    try
    {
        // الاستعلام يضيف الحجز ثم يطلب آخر ID تم توليده
        string sqlApp = @"INSERT INTO Appointments (CustomerID, AppointmentDate, TotalPrice, Status, CreatedBy) 
                          VALUES (@CustomerID, @AppointmentDate, @TotalPrice, @Status, @CreatedBy);
                          SELECT CAST(SCOPE_IDENTITY() as int);";

        // QuerySingleAsync ستجلب الـ ID مباشرة
        int appId = await db.QuerySingleAsync<int>(sqlApp, appointment, transaction);

        string sqlDetails = "INSERT INTO AppointmentDetails (AppointmentID, ServiceID) VALUES (@AppId, @SId)";

        if (appointment.SelectedServices != null)
        {
            foreach (var service in appointment.SelectedServices)
            {
                await db.ExecuteAsync(sqlDetails, new { AppId = appId, SId = service.ServiceID }, transaction);
            }
        }

        transaction.Commit();
        
        // نرجع الرقم الجديد لاستخدامه في الطباعة
        return appId; 
    }
    catch (Exception)
    {
        transaction.Rollback();
        throw;
    }
}
        public async Task<(int completed, string topService, int avgTime)> GetTodayDashboardKPIsAsync()
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = @"
            -- 1. المكتملة اليوم
            SELECT COUNT(*) FROM Appointments WHERE Status = 'Completed' AND CAST(AppointmentDate AS DATE) = CAST(GETDATE() AS DATE);

            -- 2. الخدمة الأكثر طلباً اليوم
            SELECT TOP 1 S.ServiceName
            FROM AppointmentDetails AD
            JOIN Services S ON AD.ServiceID = S.ServiceID
            JOIN Appointments A ON AD.AppointmentID = A.AppointmentID
            WHERE CAST(A.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)
            GROUP BY S.ServiceName ORDER BY COUNT(*) DESC;

            -- 3. متوسط وقت الخدمات المكتملة اليوم
            SELECT ISNULL(AVG(S.DurationMinutes), 0)
            FROM AppointmentDetails AD
            JOIN Services S ON AD.ServiceID = S.ServiceID
            JOIN Appointments A ON AD.AppointmentID = A.AppointmentID
            WHERE A.Status = 'Completed' AND CAST(A.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE);";

                using (var multi = await conn.QueryMultipleAsync(sql))
                {
                    var completed = await multi.ReadFirstAsync<int>();
                    var topService = await multi.ReadFirstOrDefaultAsync<string>() ?? "لا يوجد";
                    var avgTime = await multi.ReadFirstAsync<int>();
                    return (completed, topService, avgTime);
                }
            }
        }
        public async Task<IEnumerable<dynamic>> GetRoomsStatusAsync()
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = @"
            SELECT 
                R.RoomID, 
                R.RoomName,
                ActiveApp.AppointmentStatus,
                ActiveApp.CustomerName,
                ActiveApp.ServiceName,
                ActiveApp.StartTime,
                ActiveApp.DurationMinutes
            FROM Rooms R
            OUTER APPLY (
                SELECT TOP 1 
                    A.Status as AppointmentStatus, 
                    C.CustomerName, 
                    S.ServiceName, 
                    A.AppointmentDate as StartTime, 
                    S.DurationMinutes
                FROM AppointmentDetails AD
                JOIN Appointments A ON AD.AppointmentID = A.AppointmentID
                JOIN Services S ON AD.ServiceID = S.ServiceID
                JOIN Customers C ON A.CustomerID = C.CustomerID
                WHERE S.RoomID = R.RoomID 
                AND A.Status NOT IN ('Pending', 'Cancelled') -- نتجاهل المعلق والملغي فقط
                AND CAST(A.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)
                ORDER BY A.AppointmentDate DESC 
            ) AS ActiveApp
            WHERE R.IsActive = 1";

                return await conn.QueryAsync(sql);
            }
        }




    }
}