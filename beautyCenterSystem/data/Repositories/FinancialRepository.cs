using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeautyCenterSystem.Data;
using beautyCenterSystem;

namespace BeautyCenterSystem.Data.Repositories
{
    public class FinancialRepository : BaseRepository
    {
        public FinancialRepository(DbConnectionFactory dbFactory) : base(dbFactory) { }

        // --- عمليات الخزنات ---
        public async Task<IEnumerable<Safe>> GetAllSafesAsync()
        {
            using var db = _dbFactory.CreateConnection();
            return await db.QueryAsync<Safe>("SELECT * FROM Safes WHERE IsActive = 1");
        }

        // --- عمليات المصروفات ---
        public async Task<bool> AddExpenseAsync(Expense expense)
        {
            using var db = _dbFactory.CreateConnection();
            db.Open();
            using var transaction = db.BeginTransaction();
            try
            {
                // 1. إضافة سجل المصروف (تم إضافة ExpenseDate)
                string sql = @"INSERT INTO Expenses (ExpenseName, Category, Amount, ExpenseDate, PaidFromSafeID, IssuedBy, Notes) 
                       VALUES (@ExpenseName, @Category, @Amount, @ExpenseDate, @PaidFromSafeID, @IssuedBy, @Notes)";

                await db.ExecuteAsync(sql, expense, transaction);

                // 2. خصم المبلغ من الخزنة (يعمل بشكل صحيح مع القيم السالبة)
                await db.ExecuteAsync("UPDATE Safes SET Balance = Balance - @Amt WHERE SafeID = @SId",
                    new { Amt = expense.Amount, SId = expense.PaidFromSafeID }, transaction);

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        // --- عمليات المشتريات ---
        public async Task<bool> AddPurchaseAsync(Purchase purchase)
        {
            using var db = _dbFactory.CreateConnection();
            db.Open();
            using var transaction = db.BeginTransaction();
            try
            {
                // 1. إضافة المشتريات
                string sql = @"INSERT INTO Purchases (MaterialID, Quantity, UnitPrice, SupplierName, PaidFromSafeID, IssuedBy) 
                               VALUES (@MaterialID, @Quantity, @UnitPrice, @SupplierName, @PaidFromSafeID, @IssuedBy)";
                await db.ExecuteAsync(sql, purchase, transaction);

                // 2. خصم المبلغ الإجمالي من الخزنة
                decimal total = purchase.Quantity * purchase.UnitPrice;
                await db.ExecuteAsync("UPDATE Safes SET Balance = Balance - @Amt WHERE SafeID = @SId",
                    new { Amt = total, SId = purchase.PaidFromSafeID }, transaction);

                transaction.Commit();
                return true;
            }
            catch { transaction.Rollback(); throw; }
        }

        // --- عملية تحويل بين الخزنات (الترحيل) ---
        public async Task<bool> TransferMoneyAsync(int fromId, int toId, decimal amount, int userId)
        {
            using var db = _dbFactory.CreateConnection();
            db.Open();
            using var transaction = db.BeginTransaction();
            try
            {
                // 1. خصم من المصدر
                await db.ExecuteAsync("UPDATE Safes SET Balance = Balance - @Amt WHERE SafeID = @SId", new { Amt = amount, SId = fromId }, transaction);
                // 2. إضافة للمستلم
                await db.ExecuteAsync("UPDATE Safes SET Balance = Balance + @Amt WHERE SafeID = @SId", new { Amt = amount, SId = toId }, transaction);
                // 3. تسجيل عملية التحويل
                await db.ExecuteAsync(@"INSERT INTO SafeTransfers (FromSafeID, ToSafeID, Amount, CreatedBy) 
                                        VALUES (@F, @T, @A, @U)", new { F = fromId, T = toId, A = amount, U = userId }, transaction);

                transaction.Commit();
                return true;
            }
            catch { transaction.Rollback(); throw; }
        }
        public async Task<IEnumerable<Expense>> GetExpensesAsync(DateTime from, DateTime to, string search = "")
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"SELECT E.*, S.SafeName, U.Username as IssuedByName 
                   FROM Expenses E
                   JOIN Safes S ON E.PaidFromSafeID = S.SafeID
                   JOIN Users U ON E.IssuedBy = U.UserID
                   WHERE E.ExpenseDate BETWEEN @From AND @To
                   AND (E.ExpenseName LIKE @Search OR E.Category LIKE @Search)
                   ORDER BY E.ExpenseDate DESC";

            return await db.QueryAsync<Expense>(sql, new
            {
                From = from.Date,
                To = to.Date.AddDays(1).AddSeconds(-1),
                Search = $"%{search}%"
            });
        }
        public async Task<bool> UpdateExpenseDetailsAsync(int expenseId, string category, string expenseName, string notes)
        {
            try
            {
                using var db = _dbFactory.CreateConnection();

                // ملاحظة: Dapper يتعامل مع النصوص كـ Unicode تلقائياً عند استخدام البارامترات
                // وهذا يحل مشكلة علامات الاستفهام إذا كان نوع العمود NVARCHAR
                string sql = @"UPDATE Expenses 
                       SET Category = @Category, 
                           ExpenseName = @ExpenseName, 
                           Notes = @Notes 
                       WHERE ExpenseID = @Id";

                int rowsAffected = await db.ExecuteAsync(sql, new
                {
                    Category = category,
                    ExpenseName = expenseName,
                    Notes = notes,
                    Id = expenseId
                });

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // يمكنك تسجيل الخطأ هنا (Logging)
                throw new Exception($"حدث خطأ أثناء تحديث بيانات المصروف: {ex.Message}");
            }
        }
    }
}