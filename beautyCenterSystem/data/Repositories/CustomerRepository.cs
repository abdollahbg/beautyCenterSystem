using Dapper;
using BeautyCenterSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using beautyCenterSystem;

namespace BeautyCenterSystem.Data.Repositories
{
    public class CustomerRepository : BaseRepository
    {
        public CustomerRepository(DbConnectionFactory dbFactory) : base(dbFactory) { }

        // 1. جلب جميع العملاء النشطين فقط
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using var db = _dbFactory.CreateConnection();
            // أضفنا شرط IsActive = 1 لضمان عدم ظهور العملاء المحذوفين ناعماً
            string sql = "SELECT * FROM Customers WHERE IsActive = 1 ORDER BY CreatedAt DESC";
            return await db.QueryAsync<Customer>(sql);
        }

        // 2. البحث عن عميل ضمن القائمة النشطة فقط
        public async Task<IEnumerable<Customer>> SearchAsync(string searchTerm)
        {
            using var db = _dbFactory.CreateConnection();
            // البحث يتم فقط في السجلات التي قيمتها IsActive = 1
            string sql = @"SELECT * FROM Customers 
                           WHERE IsActive = 1 
                           AND (CustomerName LIKE @Term OR Phone LIKE @Term)";
            return await db.QueryAsync<Customer>(sql, new { Term = $"%{searchTerm}%" });
        }

        // 3. إضافة عميل جديد (سيأخذ القيمة 1 افتراضياً من قاعدة البيانات)
        public async Task<bool> AddAsync(Customer customer)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"INSERT INTO Customers (CustomerName, Phone, Notes) 
                           VALUES (@CustomerName, @Phone, @Notes)";

            int rows = await db.ExecuteAsync(sql, customer);
            return rows > 0;
        }

        // 4. تحديث بيانات عميل نشط
        public async Task<bool> UpdateAsync(Customer customer)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"UPDATE Customers 
                           SET CustomerName = @CustomerName, 
                               Phone = @Phone, 
                               Notes = @Notes 
                           WHERE CustomerID = @CustomerID AND IsActive = 1";

            int rows = await db.ExecuteAsync(sql, customer);
            return rows > 0;
        }

        // 5. الحذف الناعم (Soft Delete)
        // بدلاً من مسجل DELETE، نستخدم UPDATE لتغيير حالة النشاط
        public async Task<bool> DeleteAsync(int customerId)
        {
            using var db = _dbFactory.CreateConnection();
            // هذا التعديل يمنع ظهور خطأ الـ Reference Constraint ويحافظ على البيانات التاريخية
            string sql = "UPDATE Customers SET IsActive = 0 WHERE CustomerID = @Id";

            int rows = await db.ExecuteAsync(sql, new { Id = customerId });
            return rows > 0;
        }

        // 6. التحقق من وجود رقم الهاتف مسبقاً (ضمن العملاء النشطين)
        public async Task<bool> IsPhoneExistsAsync(string phone)
        {
            using var db = _dbFactory.CreateConnection();
            // نتحقق من الرقم فقط بين العملاء الذين لم يتم حذفهم
            string sql = "SELECT COUNT(1) FROM Customers WHERE Phone = @Phone AND IsActive = 1";
            int count = await db.ExecuteScalarAsync<int>(sql, new { Phone = phone });
            return count > 0;
        }
    }
}