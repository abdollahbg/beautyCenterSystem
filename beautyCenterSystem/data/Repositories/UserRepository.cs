using BeautyCenterSystem.Data;
using BeautyCenterSystem.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace beautyCenterSystem.data.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(DbConnectionFactory dbFactory) : base(dbFactory) { }

        // --- 1. عمليات تسجيل الدخول (موجودة سابقاً) ---
        public async Task<User> LoginAsync(string username, string password)
        {
            using var db = _dbFactory.CreateConnection();
            string userSql = @"SELECT U.*, R.RoleName 
                               FROM Users U 
                               INNER JOIN Roles R ON U.RoleID = R.RoleID 
                               WHERE U.Username = @Username AND U.IsActive = 1";

            var user = await db.QueryFirstOrDefaultAsync<User>(userSql, new { Username = username });

            if (user != null)
            {
                bool isValid = await Task.Run(() => BCrypt.Net.BCrypt.Verify(password, user.PasswordHash));
                if (isValid)
                {
                    string permissionSql = @"SELECT P.PermissionKey 
                                           FROM Permissions P
                                           INNER JOIN RolePermissions RP ON P.PermissionID = RP.PermissionID
                                           WHERE RP.RoleID = @RID";

                    var permissions = await db.QueryAsync<string>(permissionSql, new { RID = user.RoleID });
                    user.Permissions = permissions.ToList();
                    return user;
                }
            }
            return null;
        }

        // --- 2. إدارة المستخدمين ---
        public async Task<IEnumerable<dynamic>> GetAllUsersWithRolesAsync()
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"SELECT U.UserID, U.Username, U.IsActive, R.RoleName, R.RoleID
               FROM Users U
               JOIN Roles R ON U.RoleID = R.RoleID
               WHERE U.IsActive = 1";
            return await db.QueryAsync(sql);
        }

        public async Task<bool> CreateUserAsync(string username, string password, int roleId)
        {
            using var db = _dbFactory.CreateConnection();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            string sql = @"INSERT INTO Users (Username, PasswordHash, RoleID, IsActive) 
                           VALUES (@Username, @PasswordHash, @RoleID, 1)";

            int rows = await db.ExecuteAsync(sql, new { Username = username, PasswordHash = hashedPassword, RoleID = roleId });
            return rows > 0;
        }

        public async Task<bool> UpdateUserStatusAsync(int userId, bool isActive)
        {
            using var db = _dbFactory.CreateConnection();
            return await db.ExecuteAsync("UPDATE Users SET IsActive = @IsActive WHERE UserID = @ID", new { IsActive = isActive, ID = userId }) > 0;
        }

        // --- 3. إدارة الأدوار والصلاحيات (الجديد) ---

        // جلب كافة الصلاحيات المتاحة في النظام لملء قائمة الاختيارات (CheckedListBox)
        public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
        {
            using var db = _dbFactory.CreateConnection();
            return await db.QueryAsync<Permission>("SELECT * FROM Permissions");
        }

        // جلب معرفات (IDs) الصلاحيات التي يمتلكها دور معين حالياً
        public async Task<IEnumerable<int>> GetRolePermissionIdsAsync(int roleId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "SELECT PermissionID FROM RolePermissions WHERE RoleID = @RID";
            return await db.QueryAsync<int>(sql, new { RID = roleId });
        }

        // تحديث صلاحيات الدور (حذف القديم وإضافة الجديد في Transaction)
        public async Task<bool> UpdateRolePermissionsAsync(int roleId, List<int> selectedPermissionIds)
        {
            using var db = _dbFactory.CreateConnection();
            db.Open();
            using var trans = db.BeginTransaction();
            try
            {
                // 1. حذف الصلاحيات القديمة لهذا الدور
                await db.ExecuteAsync("DELETE FROM RolePermissions WHERE RoleID = @RID", new { RID = roleId }, trans);

                // 2. إضافة الصلاحيات الجديدة المختارة
                if (selectedPermissionIds != null && selectedPermissionIds.Any())
                {
                    string sql = "INSERT INTO RolePermissions (RoleID, PermissionID) VALUES (@RID, @PID)";
                    foreach (var pId in selectedPermissionIds)
                    {
                        await db.ExecuteAsync(sql, new { RID = roleId, PID = pId }, trans);
                    }
                }

                trans.Commit();
                return true;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            using var db = _dbFactory.CreateConnection();
            return await db.QueryAsync<Role>("SELECT * FROM Roles");
        }
        // داخل UserRepository.cs

        // 1. إعادة تعيين كلمة المرور
        // --- إعادة تعيين كلمة المرور لمستخدم معين ---
        public async Task<bool> ResetPasswordAsync(int userId, string plainPassword)
        {
            using var db = _dbFactory.CreateConnection();

            // تشفير كلمة المرور الجديدة
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(plainPassword);

            string sql = @"UPDATE Users 
                   SET PasswordHash = @Hash 
                   WHERE UserID = @ID";

            int rows = await db.ExecuteAsync(sql, new { Hash = passwordHash, ID = userId });
            return rows > 0;
        }
        // 2. الحذف الناعم (تغيير حالة النشاط)
        public async Task<bool> ToggleUserStatusAsync(int userId, bool status)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "UPDATE Users SET IsActive = @Status WHERE UserID = @ID";
            return await db.ExecuteAsync(sql, new { Status = status, ID = userId }) > 0;
        }

        // 3. إضافة دور جديد
        public async Task<bool> CreateRoleAsync(string roleName)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "INSERT INTO Roles (RoleName) VALUES (@Name)";
            return await db.ExecuteAsync(sql, new { Name = roleName }) > 0;
        }

        // التحقق من صحة كلمة مرور المستخدم الحالي (لعمليات الحذف أو العمليات الحساسة)
        public async Task<bool> VerifyCurrentUserPasswordAsync(int currentUserId, string password)
        {
            using var db = _dbFactory.CreateConnection();
            var passwordHash = await db.ExecuteScalarAsync<string>(
                "SELECT PasswordHash FROM Users WHERE UserID = @ID", new { ID = currentUserId });

            if (string.IsNullOrEmpty(passwordHash)) return false;

            return await Task.Run(() => BCrypt.Net.BCrypt.Verify(password, passwordHash));
        }
        // --- تحديث بيانات المستخدم (الاسم والدور) ---
        public async Task<bool> UpdateUserBasicInfoAsync(int userId, string username, int roleId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"UPDATE Users 
                   SET Username = @Username, 
                       RoleID = @RoleID 
                   WHERE UserID = @UserID";

            int rows = await db.ExecuteAsync(sql, new
            {
                UserID = userId,
                Username = username,
                RoleID = roleId
            });
            return rows > 0;
        }
        // --- التحقق من كلمة مرور المستخدم (لأغراض التأكيد) ---
        public async Task<bool> VerifyPasswordAsync(int userId, string password)
        {
            using var db = _dbFactory.CreateConnection();
            // جلب كلمة المرور المشفرة للمستخدم
            string sql = "SELECT PasswordHash FROM Users WHERE UserID = @ID AND IsActive = 1";
            var hash = await db.QueryFirstOrDefaultAsync<string>(sql, new { ID = userId });

            if (string.IsNullOrEmpty(hash)) return false;

            // التحقق من المطابقة (بافتراض أنك تستخدم BCrypt أو ما شابه داخل Repo)
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        // --- حذف مستخدم (Soft Delete) ---
        public async Task<bool> DeleteUserAsync(int userId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "UPDATE Users SET IsActive = 0 WHERE UserID = @ID";
            int rows = await db.ExecuteAsync(sql, new { ID = userId });
            return rows > 0;
        }


    }
}