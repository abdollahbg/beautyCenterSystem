using Dapper;
using beautyCenterSystem;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using BeautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;

namespace beautyCenterSystem.Data.Repositories
{
    public class RoomRepository : BaseRepository
    {
        public RoomRepository(DbConnectionFactory dbFactory) : base(dbFactory) { }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "SELECT RoomID, RoomName FROM Rooms ORDER BY RoomName";
            return await db.QueryAsync<Room>(sql);
        }

        public async Task<bool> AddAsync(Room room)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "INSERT INTO Rooms (RoomName) VALUES (@RoomName)";
            int rows = await db.ExecuteAsync(sql, room);
            return rows > 0;
        }

        public async Task<bool> UpdateAsync(Room room)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "UPDATE Rooms SET RoomName = @RoomName WHERE RoomID = @RoomID";
            int rows = await db.ExecuteAsync(sql, room);
            return rows > 0;
        }

        
        public async Task<bool> DeleteAsync(int roomId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "DELETE FROM Rooms WHERE RoomID = @Id";
            int rows = await db.ExecuteAsync(sql, new { Id = roomId });
            return rows > 0;
        }


        public async Task<Room> GetByIdAsync(int roomId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "SELECT * FROM Rooms WHERE RoomID = @Id";
            return await db.QueryFirstOrDefaultAsync<Room>(sql, new { Id = roomId });
        }
    }
}