using BeautyCenterSystem.Data;
using BeautyCenterSystem.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using BeautyCenterSystem.Models;

namespace beautyCenterSystem.data.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(DbConnectionFactory dbFactory) : base(dbFactory) { }

        public async Task<User> LoginAsync(string username, string password)
        {
            using var db = _dbFactory.CreateConnection();

            string sql = @"SELECT U.*, R.RoleName 
                   FROM Users U 
                   INNER JOIN Roles R ON U.RoleID = R.RoleID 
                   WHERE U.Username = @Username AND U.IsActive = 1";

            var user = await db.QueryFirstOrDefaultAsync<User>(sql, new { Username = username });

            if (user != null)
            {
                // 💡 تحسين: تشغيل التحقق في Task منفصل لعدم حجز الـ Thread الرئيسي
                bool isValid = await Task.Run(() => BCrypt.Net.BCrypt.Verify(password, user.PasswordHash));

                if (isValid)
                {
                    return user;
                }
            }

            return null;
        }
        public async Task<bool> CreateUserAsync(string username, string password, int roleId)
        {
            using var db = _dbFactory.CreateConnection();

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            string sql = @"INSERT INTO Users (Username, PasswordHash, RoleID, IsActive) 
                           VALUES (@Username, @PasswordHash, @RoleID, 1)";

            int rows = await db.ExecuteAsync(sql, new
            {
                Username = username,
                PasswordHash = hashedPassword,
                RoleID = roleId
            });

            return rows > 0;
        }
    }
}
