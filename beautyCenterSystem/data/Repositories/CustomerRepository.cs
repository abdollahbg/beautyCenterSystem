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

       
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "SELECT * FROM Customers ORDER BY CreatedAt DESC";
            return await db.QueryAsync<Customer>(sql);
        }


        public async Task<IEnumerable<Customer>> SearchAsync(string searchTerm)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"SELECT * FROM Customers 
                           WHERE CustomerName LIKE @Term OR Phone LIKE @Term";
            return await db.QueryAsync<Customer>(sql, new { Term = $"%{searchTerm}%" });
        }

        public async Task<bool> AddAsync(Customer customer)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"INSERT INTO Customers (CustomerName, Phone, Notes) 
                           VALUES (@CustomerName, @Phone, @Notes)";

            int rows = await db.ExecuteAsync(sql, customer);
            return rows > 0;
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"UPDATE Customers 
                           SET CustomerName = @CustomerName, 
                               Phone = @Phone, 
                               Notes = @Notes 
                           WHERE CustomerID = @CustomerID";

            int rows = await db.ExecuteAsync(sql, customer);
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int customerId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "DELETE FROM Customers WHERE CustomerID = @Id";

            int rows = await db.ExecuteAsync(sql, new { Id = customerId });
            return rows > 0;
        }

        // 6. التحقق من وجود رقم الهاتف مسبقاً (لمنع التكرار)
        public async Task<bool> IsPhoneExistsAsync(string phone)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "SELECT COUNT(1) FROM Customers WHERE Phone = @Phone";
            int count = await db.ExecuteScalarAsync<int>(sql, new { Phone = phone });
            return count > 0;
        }
    }
}