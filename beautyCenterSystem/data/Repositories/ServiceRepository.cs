using Dapper;
using beautyCenterSystem;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using BeautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;

namespace beautyCenterSystem.Data.Repositories
{
    public class ServiceRepository : BaseRepository
    {
        public ServiceRepository(DbConnectionFactory dbFactory) : base(dbFactory) { }

        // 1. جلب الخدمات مع اسم الغرفة (تم تضمين السعر الخاص بالموظفة تلقائياً عبر S.*)
        public async Task<IEnumerable<Service>> GetAllWithRoomNamesAsync()
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"SELECT S.*, R.RoomName FROM Services S 
                           LEFT JOIN Rooms R ON S.RoomID = R.RoomID 
                           WHERE S.IsActive = 1
                           ORDER BY S.ServiceName";
            return await db.QueryAsync<Service>(sql);
        }

        // 2. إضافة خدمة جديدة مع السعرين (المعروض وللموظفة)
        public async Task<bool> AddAsync(Service service)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"INSERT INTO Services (ServiceName, Price, EmployeeBasePrice, DurationMinutes, RoomID, IsActive) 
                           VALUES (@ServiceName, @Price, @EmployeeBasePrice, @DurationMinutes, @RoomID, 1)";

            int rows = await db.ExecuteAsync(sql, service);
            return rows > 0;
        }

        // 3. تحديث بيانات الخدمة بالكامل
        public async Task<bool> UpdateAsync(Service service)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"UPDATE Services 
                           SET ServiceName = @ServiceName, 
                               Price = @Price, 
                               EmployeeBasePrice = @EmployeeBasePrice, 
                               DurationMinutes = @DurationMinutes, 
                               RoomID = @RoomID 
                           WHERE ServiceID = @ServiceID";

            int rows = await db.ExecuteAsync(sql, service);
            return rows > 0;
        }

        // 4. الحذف المنطقي للخدمة
        public async Task<bool> DeleteAsync(int serviceId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "UPDATE Services SET IsActive = 0 WHERE ServiceID = @Id";
            int rows = await db.ExecuteAsync(sql, new { Id = serviceId });
            return rows > 0;
        }

        // 5. جلب خدمات غرفة معينة (للتعامل مع واجهات الغرف)
        public async Task<IEnumerable<Service>> GetByRoomIdAsync(int roomId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "SELECT * FROM Services WHERE RoomID = @RoomId AND IsActive = 1";
            return await db.QueryAsync<Service>(sql, new { RoomId = roomId });
        }
    }
}