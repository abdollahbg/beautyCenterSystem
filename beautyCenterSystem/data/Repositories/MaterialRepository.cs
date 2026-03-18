using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using BeautyCenterSystem.Data; // تأكد من مطابقة الـ Namespace لمشروعك

namespace beautyCenterSystem.Data.Repositories
{
    public class MaterialRepository
    {
        private readonly DbConnectionFactory _dbFactory;

        public MaterialRepository(DbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        // 1. جلب كل المواد
        public async Task<IEnumerable<Material>> GetAllAsync()
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = "SELECT * FROM Materials ORDER BY MaterialName";
                return await conn.QueryAsync<Material>(sql);
            }
        }

        // 2. جلب المواد المتاحة فقط (لاستخدامها في شاشات أخرى)
        public async Task<IEnumerable<Material>> GetAvailableAsync()
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = "SELECT * FROM Materials WHERE IsAvailable = 1 ORDER BY MaterialName";
                return await conn.QueryAsync<Material>(sql);
            }
        }

        // 3. إضافة مادة جديدة
        public async Task<bool> CreateAsync(Material material)
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = "INSERT INTO Materials (MaterialName, IsAvailable) VALUES (@MaterialName, @IsAvailable)";
                int rows = await conn.ExecuteAsync(sql, material);
                return rows > 0;
            }
        }

        // 4. تحديث مادة
        public async Task<bool> UpdateAsync(Material material)
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = "UPDATE Materials SET MaterialName = @MaterialName, IsAvailable = @IsAvailable WHERE MaterialID = @MaterialID";
                int rows = await conn.ExecuteAsync(sql, material);
                return rows > 0;
            }
        }

        // 5. حذف مادة
        public async Task<bool> DeleteAsync(int id)
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = "DELETE FROM Materials WHERE MaterialID = @id";
                int rows = await conn.ExecuteAsync(sql, new { id });
                return rows > 0;
            }
        }
        public async Task<IEnumerable<Material>> GetOutOfStockMaterialsAsync()
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                return await conn.QueryAsync<Material>("SELECT * FROM Materials WHERE IsAvailable = 0");
            }
        }
    }
}