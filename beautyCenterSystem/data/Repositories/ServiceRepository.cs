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

        
        public async Task<IEnumerable<dynamic>> GetAllWithRoomNamesAsync()
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"SELECT S.*, R.RoomName 
                           FROM Services S 
                           LEFT JOIN Rooms R ON S.RoomID = R.RoomID 
                           ORDER BY S.ServiceName";
            return await db.QueryAsync(sql);
        }

        public async Task<bool> AddAsync(Service service)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"INSERT INTO Services (ServiceName, Price, DurationMinutes, RoomID) 
                           VALUES (@ServiceName, @Price, @DurationMinutes, @RoomID)";

            int rows = await db.ExecuteAsync(sql, service);
            return rows > 0;
        }

        public async Task<bool> UpdateAsync(Service service)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"UPDATE Services 
                           SET ServiceName = @ServiceName, 
                               Price = @Price, 
                               DurationMinutes = @DurationMinutes, 
                               RoomID = @RoomID 
                           WHERE ServiceID = @ServiceID";

            int rows = await db.ExecuteAsync(sql, service);
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int serviceId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "DELETE FROM Services WHERE ServiceID = @Id";
            int rows = await db.ExecuteAsync(sql, new { Id = serviceId });
            return rows > 0;
        }

        public async Task<IEnumerable<Service>> GetByRoomIdAsync(int roomId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "SELECT * FROM Services WHERE RoomID = @RoomId";
            return await db.QueryAsync<Service>(sql, new { RoomId = roomId });
        }
    }
}