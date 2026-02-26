using Dapper;
using beautyCenterSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BeautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;

namespace beautyCenterSystem.Data.Repositories
{
    public class AppointmentRepository : BaseRepository
    {
        public AppointmentRepository(DbConnectionFactory dbFactory) : base(dbFactory) { }

        // 1. إضافة حجز جديد مع خدماته (Master-Detail Transaction)
        public async Task<bool> CreateAsync(Appointment appointment)
        {
            using var db = _dbFactory.CreateConnection();
            db.Open();
            using var transaction = db.BeginTransaction();

            try
            {
                // أ- إدخال الحجز الأساسي وجلب الـ ID المتولد
                string sqlApp = @"INSERT INTO Appointments (CustomerID, AppointmentDate, TotalPrice, Status, CreatedBy) 
                                  VALUES (@CustomerID, @AppointmentDate, @TotalPrice, @Status, @CreatedBy);
                                  SELECT CAST(SCOPE_IDENTITY() as int);";

                int appId = await db.QuerySingleAsync<int>(sqlApp, appointment, transaction);

                // ب- إدخال تفاصيل الخدمات المرتبطة بهذا الحجز
                string sqlDetails = "INSERT INTO AppointmentDetails (AppointmentID, ServiceID) VALUES (@AppId, @SId)";

                foreach (var service in appointment.SelectedServices)
                {
                    await db.ExecuteAsync(sqlDetails, new { AppId = appId, SId = service.ServiceID }, transaction);
                }

                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw; // إعادة رمي الخطأ للتعامل معه في الواجهة
            }
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
        public async Task<bool> UpdateStatusAsync(int appId, string status)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "UPDATE Appointments SET Status = @Status WHERE AppointmentID = @Id";
            int rows = await db.ExecuteAsync(sql, new { Status = status, Id = appId });
            return rows > 0;
        }

        // 4. جلب تفاصيل حجز معين (الخدمات التي تم اختيارها فيه)
        public async Task<IEnumerable<Service>> GetAppointmentServicesAsync(int appId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"SELECT S.* FROM Services S 
                           JOIN AppointmentDetails AD ON S.ServiceID = AD.ServiceID 
                           WHERE AD.AppointmentID = @AppId";

            return await db.QueryAsync<Service>(sql, new { AppId = appId });
        }
    }
}