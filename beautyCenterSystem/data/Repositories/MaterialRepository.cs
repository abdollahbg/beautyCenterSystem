using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using BeautyCenterSystem.Data;

namespace beautyCenterSystem.Data.Repositories
{
    public class MaterialRepository
    {
        private readonly DbConnectionFactory _dbFactory;

        public MaterialRepository(DbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        // 1. جلب كل المواد النشطة (سواء كانت متوفرة أو غير متوفرة)
        // لا تجلب المواد التي تم عمل حذف ناعم لها (IsActive = 0)
        public async Task<IEnumerable<Material>> GetAllAsync()
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = "SELECT * FROM Materials WHERE IsActive = 1 ORDER BY MaterialName";
                return await conn.QueryAsync<Material>(sql);
            }
        }

        // 2. جلب المواد المتاحة والنشطة فقط (لاستخدامها في شاشات البيع أو الصرف)
        public async Task<IEnumerable<Material>> GetAvailableAsync()
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = "SELECT * FROM Materials WHERE IsAvailable = 1 AND IsActive = 1 ORDER BY MaterialName";
                return await conn.QueryAsync<Material>(sql);
            }
        }

        // 3. إضافة مادة جديدة
        public async Task<bool> CreateAsync(Material material)
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                // نضمن إضافة IsActive كـ 1 افتراضياً
                string sql = @"INSERT INTO Materials (MaterialName, IsAvailable, IsActive) 
                             VALUES (@MaterialName, @IsAvailable, 1)";
                int rows = await conn.ExecuteAsync(sql, material);
                return rows > 0;
            }
        }

        // 4. تحديث مادة (تعديل الاسم أو حالة التوفر)
        public async Task<bool> UpdateAsync(Material material)
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = @"UPDATE Materials 
                             SET MaterialName = @MaterialName, 
                                 IsAvailable = @IsAvailable 
                             WHERE MaterialID = @MaterialID";
                int rows = await conn.ExecuteAsync(sql, material);
                return rows > 0;
            }
        }

        // 5. الحذف الناعم (Soft Delete)
        // يحل مشكلة الـ Conflict مع جداول المشتريات
        public async Task<bool> DeleteAsync(int id)
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                // نقوم فقط بتعطيل العنصر لكي لا يظهر في النظام مجدداً
                string sql = "UPDATE Materials SET IsActive = 0 WHERE MaterialID = @id";
                int rows = await conn.ExecuteAsync(sql, new { id });
                return rows > 0;
            }
        }

        // 6. جلب المواد التي نفدت من المخزن ولكنها لا تزال "نشطة" في النظام
        public async Task<IEnumerable<Material>> GetOutOfStockMaterialsAsync()
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = "SELECT * FROM Materials WHERE IsAvailable = 0 AND IsActive = 1";
                return await conn.QueryAsync<Material>(sql);
            }
        }
    }
}