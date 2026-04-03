using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using beautyCenterSystem.Data;
using BeautyCenterSystem.Data;

namespace beautyCenterSystem.Data.Repositories
{
    public class RoomRepository
    {
        private readonly DbConnectionFactory _dbFactory;

        public RoomRepository(DbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            using var db = _dbFactory.CreateConnection();
            // الـ * ستجلب IsCaffeteria تلقائياً الآن من الجدول
            string sql = "SELECT * FROM Rooms WHERE IsActive = 1 ORDER BY RoomName";
            return await db.QueryAsync<Room>(sql);
        }

        public async Task<bool> AddAsync(Room room)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"INSERT INTO Rooms (RoomName, IconPath, IsActive, IsCaffeteria) 
                           VALUES (@RoomName, @IconPath, 1, @IsCaffeteria)";
            int rows = await db.ExecuteAsync(sql, room);
            return rows > 0;
        }

        public async Task<bool> UpdateAsync(Room room)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"UPDATE Rooms 
                           SET RoomName = @RoomName, 
                               IconPath = @IconPath,
                               IsCaffeteria = @IsCaffeteria
                           WHERE RoomID = @RoomID";
            int rows = await db.ExecuteAsync(sql, room);
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int roomId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "UPDATE Rooms SET IsActive = 0 WHERE RoomID = @Id";
            int rows = await db.ExecuteAsync(sql, new { Id = roomId });
            return rows > 0;
        }

        public async Task<Room> GetByIdAsync(int roomId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "SELECT * FROM Rooms WHERE RoomID = @Id";
            return await db.QueryFirstOrDefaultAsync<Room>(sql, new { Id = roomId });
        }

        public async Task<bool> HasActiveServicesAsync(int roomId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "SELECT COUNT(1) FROM Services WHERE RoomID = @Id AND IsActive = 1";
            int count = await db.ExecuteScalarAsync<int>(sql, new { Id = roomId });
            return count > 0;
        }
    }
}