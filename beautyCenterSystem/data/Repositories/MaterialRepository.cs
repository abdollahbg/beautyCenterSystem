using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using beautyCenterSystem.Data;
using BeautyCenterSystem.Data;
using BeautyCenterSystem.Models; // تأكد من وجود الموديل

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
                string sql = "SELECT * FROM Materials WHERE IsActive = 1 ORDER BY MaterialName";
                return await conn.QueryAsync<Material>(sql);
            }
        }

        // 2. جلب مواد الكافيتيريا فقط
        public async Task<IEnumerable<Material>> GetCaffeteriaMenuAsync()
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = @"SELECT * FROM Materials 
                               WHERE IsCaffeteriaItem = 1 
                               AND IsAvailable = 1 
                               AND IsActive = 1 
                               AND StockQuantity > 0 
                               ORDER BY MaterialName";
                return await conn.QueryAsync<Material>(sql);
            }
        }

        // 3. إضافة مادة جديدة
        public async Task<bool> CreateAsync(Material material)
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = @"INSERT INTO Materials (MaterialName, IsAvailable, IsActive, SalePrice, StockQuantity, IsCaffeteriaItem) 
                             VALUES (@MaterialName, @IsAvailable, 1, @SalePrice, @StockQuantity, @IsCaffeteriaItem)";
                int rows = await conn.ExecuteAsync(sql, material);
                return rows > 0;
            }
        }

        // 4. تحديث مادة بالكامل
        public async Task<bool> UpdateAsync(Material material)
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = @"UPDATE Materials 
                             SET MaterialName = @MaterialName, 
                                 IsAvailable = @IsAvailable,
                                 SalePrice = @SalePrice,
                                 StockQuantity = @StockQuantity,
                                 IsCaffeteriaItem = @IsCaffeteriaItem
                             WHERE MaterialID = @MaterialID";
                int rows = await conn.ExecuteAsync(sql, material);
                return rows > 0;
            }
        }

        // 5. تحديث المخزون عند البيع
        public async Task<bool> DecreaseStockAsync(int materialId, int quantity)
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = @"UPDATE Materials 
                               SET StockQuantity = StockQuantity - @quantity 
                               WHERE MaterialID = @materialId AND StockQuantity >= @quantity";
                int rows = await conn.ExecuteAsync(sql, new { materialId, quantity });
                return rows > 0;
            }
        }

        // 6. الحذف الناعم
        public async Task<bool> DeleteAsync(int id)
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = "UPDATE Materials SET IsActive = 0 WHERE MaterialID = @id";
                int rows = await conn.ExecuteAsync(sql, new { id });
                return rows > 0;
            }
        }

        // 7. جلب مادة واحدة بواسطة المعرف (هذه هي الدالة التي كانت ناقصة وتسببت في الخطأ)
        public async Task<Material> GetByIdAsync(int id)
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = "SELECT * FROM Materials WHERE MaterialID = @id AND IsActive = 1";
                return await conn.QueryFirstOrDefaultAsync<Material>(sql, new { id });
            }
        }

        public async Task<IEnumerable<Material>> GetOutOfStockMaterialsAsync()
        {
            using (var connection = _dbFactory.CreateConnection())
            {
                // قمنا بإزالة شرط IsCaffeteriaItem لجلب جميع المواد 
                // التي تتبع نظام المخزن (صالون + كافيتيريا)
                string query = @"SELECT * FROM Materials 
                         WHERE IsActive = 1 
                         AND (
                             (StockQuantity IS NOT NULL AND StockQuantity < 5) 
                             OR IsAvailable = 0
                         )";

                return await connection.QueryAsync<Material>(query);
            }
        }
    }
}