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
            string sql = @"SELECT A.*, C.CustomerName 
                           FROM Appointments A 
                           JOIN Customers C ON A.CustomerID = C.CustomerID 
                           WHERE CAST(A.AppointmentDate AS DATE) = CAST(@TargetDate AS DATE)
                           ORDER BY A.AppointmentDate ASC";

            return await db.QueryAsync<Appointment>(sql, new { TargetDate = date });
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

    }
}