using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;

namespace beautyCenterSystem.data.Repositories
{
    public class TrainerRepository
    {
        private readonly BeautyCenterSystem.Data.DbConnectionFactory _connectionFactory;

        public TrainerRepository(BeautyCenterSystem.Data.DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Trainer>> GetAllAsync()
        {
            using (var db = _connectionFactory.CreateConnection())
            {
                var sql = "SELECT * FROM Trainers WHERE IsActive = 1 ORDER BY TrainerName";
                return await db.QueryAsync<Trainer>(sql);
            }
        }

        public async Task<Trainer> GetByIdAsync(int id)
        {
            using (var db = _connectionFactory.CreateConnection())
            {
                var sql = "SELECT * FROM Trainers WHERE TrainerID = @TrainerID";
                return await db.QueryFirstOrDefaultAsync<Trainer>(sql, new { TrainerID = id });
            }
        }

        public async Task AddAsync(Trainer trainer)
        {
            using (var db = _connectionFactory.CreateConnection())
            {
                var sql = @"
                    INSERT INTO Trainers (TrainerName, Phone) 
                    VALUES (@TrainerName, @Phone);
                    SELECT CAST(SCOPE_IDENTITY() as int);";
                trainer.TrainerID = await db.QuerySingleAsync<int>(sql, trainer);
            }
        }

        public async Task UpdateAsync(Trainer trainer)
        {
            using (var db = _connectionFactory.CreateConnection())
            {
                var sql = @"
                    UPDATE Trainers 
                    SET TrainerName = @TrainerName, 
                        Phone = @Phone
                    WHERE TrainerID = @TrainerID";
                await db.ExecuteAsync(sql, trainer);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var db = _connectionFactory.CreateConnection())
            {
                // Soft delete
                var sql = "UPDATE Trainers SET IsActive = 0 WHERE TrainerID = @TrainerID";
                await db.ExecuteAsync(sql, new { TrainerID = id });
            }
        }

        public async Task AddTrainerPaymentAsync(TrainerPayment payment)
        {
            using (var db = _connectionFactory.CreateConnection())
            {
                // First deduct from safe
                var safeSql = "UPDATE Safes SET Balance = Balance - @AmountPaid WHERE SafeID = @SafeID";
                await db.ExecuteAsync(safeSql, new { AmountPaid = payment.AmountPaid, SafeID = payment.SafeID });

                // Record payment
                var sql = @"
                    INSERT INTO TrainerPayments (TrainerID, SafeID, AmountPaid, PaymentDate, IssuedBy, Notes)
                    VALUES (@TrainerID, @SafeID, @AmountPaid, @PaymentDate, @IssuedBy, @Notes);";
                await db.ExecuteAsync(sql, payment);

                // Add to expenses
                var expenseSql = @"
                    INSERT INTO Expenses (ExpenseName, Category, Amount, ExpenseDate, PaidFromSafeID, IssuedBy, Notes)
                    VALUES (@ExpenseName, @Category, @Amount, @PaymentDate, @SafeID, @IssuedBy, @Notes)";
                
                await db.ExecuteAsync(expenseSql, new {
                    ExpenseName = "صرف مستحقات مدربة",
                    Category = "رواتب وعمولات",
                    Amount = payment.AmountPaid,
                    PaymentDate = payment.PaymentDate,
                    SafeID = payment.SafeID,
                    IssuedBy = payment.IssuedBy,
                    Notes = payment.Notes
                });
            }
        }

        // جلب إجمالي ما استحقته المدربة من اشتراكات الجيم
        public async Task<decimal> GetTrainerTotalEarnedAsync(int trainerId)
        {
            using var db = _connectionFactory.CreateConnection();
            string sql = @"
                SELECT ISNULL(SUM( 
                    (CASE WHEN GT.BaseAmount > 0 THEN GT.BaseAmount ELSE GS.PaidAmount END) * (GT.CommissionRate / 100.0)
                ), 0)
                FROM GymSubscriptionTrainers GT
                JOIN CustomerGymSubscriptions GS ON GT.SubscriptionID = GS.SubscriptionID
                WHERE GT.TrainerID = @ID";
            return await db.ExecuteScalarAsync<decimal>(sql, new { ID = trainerId });
        }

        // جلب إجمالي ما تم صرفه للمدربة سابقاً
        public async Task<decimal> GetTrainerTotalPaidAsync(int trainerId)
        {
            using var db = _connectionFactory.CreateConnection();
            string sql = "SELECT ISNULL(SUM(AmountPaid), 0) FROM TrainerPayments WHERE TrainerID = @ID";
            return await db.ExecuteScalarAsync<decimal>(sql, new { ID = trainerId });
        }

        // تسجيل عملية صرف جديدة للمدربة (مع تحديث رصيد الخزنة في معاملة واحدة Transaction)
        public async Task<bool> SaveTrainerPaymentAsync(int trainerId, int safeId, decimal amount, string notes, int userId)
        {
            using var db = _connectionFactory.CreateConnection();
            db.Open();
            using var trans = db.BeginTransaction();
            try
            {
                // 1. إضافة سجل الصرف
                string sqlPayment = @"INSERT INTO TrainerPayments (TrainerID, SafeID, AmountPaid, PaymentDate, Notes, IssuedBy) 
                              VALUES (@TrainerID, @SafeID, @Amount, GETDATE(), @Notes, @UserID)";
                await db.ExecuteAsync(sqlPayment,
                    new { TrainerID = trainerId, SafeID = safeId, Amount = amount, Notes = notes, UserID = userId },
                    trans);

                // 2. خصم المبلغ من رصيد الخزنة
                string sqlUpdateSafe = "UPDATE Safes SET Balance = Balance - @Amount WHERE SafeID = @SafeID";
                await db.ExecuteAsync(sqlUpdateSafe,
                    new { Amount = amount, SafeID = safeId },
                    trans);

                // 3. تسجيل كمصروف
                string expenseSql = @"
                    INSERT INTO Expenses (ExpenseName, Category, Amount, ExpenseDate, PaidFromSafeID, IssuedBy, Notes)
                    VALUES (N'صرف مستحقات مدربة', N'رواتب وعمولات', @Amount, GETDATE(), @SafeID, @UserID, @Notes)";
                await db.ExecuteAsync(expenseSql,
                    new { Amount = amount, SafeID = safeId, UserID = userId, Notes = notes },
                    trans);

                trans.Commit();
                return true;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }
    }
}
