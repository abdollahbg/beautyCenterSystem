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
                var sql = @"
                    SELECT 
                        T.*,
                        ISNULL(Earned.TotalEarned, 0) - ISNULL(Paid.TotalPaid, 0) AS CurrentDues
                    FROM Trainers T
                    LEFT JOIN (
                        SELECT 
                            GT.TrainerID, 
                            SUM((CASE WHEN GT.BaseAmount > 0 THEN GT.BaseAmount ELSE GS.PaidAmount END) * (GT.CommissionRate / 100.0)) AS TotalEarned
                        FROM GymSubscriptionTrainers GT
                        JOIN CustomerGymSubscriptions GS ON GT.SubscriptionID = GS.SubscriptionID AND GS.IsActive = 1
                        GROUP BY GT.TrainerID
                    ) Earned ON T.TrainerID = Earned.TrainerID
                    LEFT JOIN (
                        SELECT TrainerID, SUM(AmountPaid) AS TotalPaid
                        FROM TrainerPayments
                        GROUP BY TrainerID
                    ) Paid ON T.TrainerID = Paid.TrainerID
                    WHERE T.IsActive = 1 
                    ORDER BY T.TrainerName";
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
                JOIN CustomerGymSubscriptions GS ON GT.SubscriptionID = GS.SubscriptionID AND GS.IsActive = 1
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

                // (تمت الإزالة لتجنب الازدواجية في الحسابات: لا نسجل مدفوعات المدربات كمصروفات)

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
