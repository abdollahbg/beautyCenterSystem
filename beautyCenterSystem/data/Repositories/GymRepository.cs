using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System;
using BeautyCenterSystem.Data;

namespace beautyCenterSystem.Data.Repositories
{
    public class GymRepository
    {
        private readonly DbConnectionFactory _dbFactory;

        public GymRepository(DbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        // --- Subscription Types ---
        public async Task<IEnumerable<GymSubscriptionType>> GetAllSubscriptionTypesAsync()
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "SELECT * FROM GymSubscriptionTypes WHERE IsActive = 1";
            return await db.QueryAsync<GymSubscriptionType>(sql);
        }

        public async Task<IEnumerable<GymPackageTrainer>> GetPackageTrainersAsync(int packageId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"SELECT PT.*, T.TrainerName 
                           FROM GymPackageTrainers PT
                           JOIN Trainers T ON PT.TrainerID = T.TrainerID
                           WHERE PT.PackageID = @PackageID AND T.IsActive = 1";
            return await db.QueryAsync<GymPackageTrainer>(sql, new { PackageID = packageId });
        }

        public async Task<bool> AddSubscriptionTypeAsync(GymSubscriptionType type, List<GymPackageTrainer> trainers = null)
        {
            using var db = _dbFactory.CreateConnection();
            db.Open();
            using var transaction = db.BeginTransaction();
            try
            {
                string sql = @"INSERT INTO GymSubscriptionTypes (TypeName, DurationDays, Price, IsActive, IsSessionBased, TotalSessions) 
                               VALUES (@TypeName, @DurationDays, @Price, 1, @IsSessionBased, @TotalSessions);
                               SELECT CAST(SCOPE_IDENTITY() as int);";
                               
                int newTypeId = await db.QuerySingleAsync<int>(sql, type, transaction);

                if (trainers != null && trainers.Any())
                {
                    string trainerSql = @"INSERT INTO GymPackageTrainers (PackageID, TrainerID, BaseAmount, CommissionRate)
                                          VALUES (@PackageID, @TrainerID, @BaseAmount, @CommissionRate)";
                    foreach (var t in trainers)
                    {
                        t.PackageID = newTypeId;
                        await db.ExecuteAsync(trainerSql, t, transaction);
                    }
                }
                
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task<bool> UpdateSubscriptionTypeAsync(GymSubscriptionType type, List<GymPackageTrainer> trainers = null)
        {
            using var db = _dbFactory.CreateConnection();
            db.Open();
            using var transaction = db.BeginTransaction();
            try
            {
                string sql = @"UPDATE GymSubscriptionTypes 
                               SET TypeName = @TypeName, 
                                   DurationDays = @DurationDays,
                                   Price = @Price,
                                   IsSessionBased = @IsSessionBased,
                                   TotalSessions = @TotalSessions
                               WHERE TypeID = @TypeID";
                await db.ExecuteAsync(sql, type, transaction);

                if (trainers != null)
                {
                    // حذف المدربات القديمات وإضافة الجديدات
                    await db.ExecuteAsync("DELETE FROM GymPackageTrainers WHERE PackageID = @PackageID", new { PackageID = type.TypeID }, transaction);
                    
                    if (trainers.Any())
                    {
                        string trainerSql = @"INSERT INTO GymPackageTrainers (PackageID, TrainerID, BaseAmount, CommissionRate)
                                              VALUES (@PackageID, @TrainerID, @BaseAmount, @CommissionRate)";
                        foreach (var t in trainers)
                        {
                            t.PackageID = type.TypeID;
                            await db.ExecuteAsync(trainerSql, t, transaction);
                        }
                    }
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task<bool> DeleteSubscriptionTypeAsync(int typeId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "UPDATE GymSubscriptionTypes SET IsActive = 0 WHERE TypeID = @Id";
            int rows = await db.ExecuteAsync(sql, new { Id = typeId });
            return rows > 0;
        }

        // --- Customer Subscriptions ---
        // --- Customer Subscriptions ---

        // 1. تعديل الدالة لتقبل التواريخ كبارامترات اختيارية
        public async Task<IEnumerable<GymSubscriptionStatus>> GetAllCustomerSubscriptionsAsync(DateTime? fromDate = null, DateTime? toDate = null)
        {
            using var db = _dbFactory.CreateConnection();

            // بناء الاستعلام الأساسي من الـ View
            string sql = "SELECT * FROM vw_GymSubscriptionsStatus WHERE 1=1";

            // إضافة شرط التاريخ فقط في حال تمريره (الفلترة بناءً على تاريخ بداية الاشتراك StartDate)
            if (fromDate.HasValue)
            {
                sql += " AND StartDate >= @FromDate";
            }
            if (toDate.HasValue)
            {
                sql += " AND StartDate <= @ToDate";
            }

            // ترتيب النتائج من الأحدث إلى الأقدم
            sql += " ORDER BY StartDate DESC";

            return await db.QueryAsync<GymSubscriptionStatus>(sql, new { FromDate = fromDate, ToDate = toDate });
        }

        public async Task<bool> RegisterCustomerSubscriptionAsync(CustomerGymSubscription subscription, string paymentMethod)
        {
            using var db = _dbFactory.CreateConnection();
            db.Open();
            using var transaction = db.BeginTransaction();

            try
            {
                // 1. Get SafeID from PaymentMapping
                string safeSql = "SELECT SafeID FROM PaymentMapping WHERE MethodName = @MethodName";
                int? safeId = await db.QueryFirstOrDefaultAsync<int?>(safeSql, new { MethodName = paymentMethod }, transaction);

                if (!safeId.HasValue)
                {
                    throw new Exception("لم يتم العثور على الخزنة المرتبطة بطريقة الدفع");
                }
                
                subscription.SafeID = safeId.Value;

                // 2. Insert Customer Subscription
                string insertSql = @"
                    INSERT INTO CustomerGymSubscriptions 
                    (CustomerID, TypeID, StartDate, EndDate, PaidAmount, SafeID, IssuedBy, Notes, CreatedAt, SessionsRemaining, IsActive)
                    VALUES 
                    (@CustomerID, @TypeID, @StartDate, @EndDate, @PaidAmount, @SafeID, @IssuedBy, @Notes, GETDATE(), @SessionsRemaining, 1);
                    SELECT CAST(SCOPE_IDENTITY() as int);";
                
                int newSubId = await db.ExecuteScalarAsync<int>(insertSql, subscription, transaction);
                subscription.SubscriptionID = newSubId;

                // Insert Trainers
                if (subscription.Trainers != null && subscription.Trainers.Count > 0)
                {
                    string trainerSql = @"
                        INSERT INTO GymSubscriptionTrainers 
                        (SubscriptionID, TrainerID, BaseAmount, CommissionRate)
                        VALUES 
                        (@SubscriptionID, @TrainerID, @BaseAmount, @CommissionRate)";

                    foreach (var trainer in subscription.Trainers)
                    {
                        trainer.SubscriptionID = newSubId;
                        await db.ExecuteAsync(trainerSql, trainer, transaction);
                    }
                }

                // 3. Update Safe Balance
                string updateSafeSql = "UPDATE Safes SET Balance = Balance + @Amount WHERE SafeID = @SafeID";
                await db.ExecuteAsync(updateSafeSql, new { Amount = subscription.PaidAmount, SafeID = safeId.Value }, transaction);

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        // --- Gym Income Report ---
        public async Task<decimal> GetTotalGymIncomeAsync(DateTime fromDate, DateTime toDate)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"SELECT ISNULL(SUM(PaidAmount), 0) 
                           FROM CustomerGymSubscriptions 
                           WHERE IsActive = 1 
                             AND CreatedAt >= @FromDate 
                             AND CreatedAt <= @ToDate";
            return await db.ExecuteScalarAsync<decimal>(sql, new { FromDate = fromDate, ToDate = toDate });
        }

        public async Task<IEnumerable<dynamic>> GetGymIncomeDetailsAsync(DateTime fromDate, DateTime toDate)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"SELECT 
                               GS.SubscriptionID,
                               C.CustomerName,
                               C.Phone,
                               ST.TypeName AS SubscriptionType,
                               GS.StartDate,
                               GS.EndDate,
                               GS.PaidAmount,
                               S.SafeName,
                               GS.CreatedAt
                           FROM CustomerGymSubscriptions GS
                           JOIN Customers C ON GS.CustomerID = C.CustomerID
                           JOIN GymSubscriptionTypes ST ON GS.TypeID = ST.TypeID
                           LEFT JOIN Safes S ON GS.SafeID = S.SafeID
                           WHERE GS.IsActive = 1
                             AND GS.CreatedAt >= @FromDate
                             AND GS.CreatedAt <= @ToDate
                           ORDER BY GS.CreatedAt DESC";
            return await db.QueryAsync(sql, new { FromDate = fromDate, ToDate = toDate });
        }

        // --- Attendance ---
        public async Task<bool> CheckInSessionAsync(int subscriptionId, string note = "")
        {
            using var db = _dbFactory.CreateConnection();
            db.Open();
            using var transaction = db.BeginTransaction();

            try
            {
                // Check remaining sessions
                string checkSql = "SELECT SessionsRemaining, IsActive FROM CustomerGymSubscriptions WHERE SubscriptionID = @Id";
                var sub = await db.QueryFirstOrDefaultAsync<CustomerGymSubscription>(checkSql, new { Id = subscriptionId }, transaction);

                if (sub == null || !sub.IsActive || sub.SessionsRemaining <= 0)
                {
                    throw new Exception("لا يمكن تسجيل الحضور: الاشتراك منتهي أو لا يوجد حصص متبقية.");
                }

                // Decrement sessions
                string updateSubSql = "UPDATE CustomerGymSubscriptions SET SessionsRemaining = SessionsRemaining - 1 WHERE SubscriptionID = @Id";
                await db.ExecuteAsync(updateSubSql, new { Id = subscriptionId }, transaction);

                // Log attendance
                string insertAttSql = "INSERT INTO GymAttendance (SubscriptionID, CheckInTime, Note) VALUES (@Id, GETDATE(), @Note)";
                await db.ExecuteAsync(insertAttSql, new { Id = subscriptionId, Note = note }, transaction);

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        // --- Trainer Dues ---
        public async Task<IEnumerable<beautyCenterSystem.viewsmodels.TrainerDuesDTO>> GetUnpaidTrainerDuesAsync()
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"
                SELECT 
                    T.TrainerID,
                    T.TrainerName,
                    ISNULL(SUM(GT.BaseAmount), 0) AS TotalBaseAmount,
                    ISNULL(SUM( (CASE WHEN GT.BaseAmount > 0 THEN GT.BaseAmount ELSE GS.PaidAmount END) * (GT.CommissionRate / 100.0) ), 0) AS TotalCommissionAmount,
                    ISNULL(SUM( (CASE WHEN GT.BaseAmount > 0 THEN GT.BaseAmount ELSE GS.PaidAmount END) * (GT.CommissionRate / 100.0) ), 0) AS TotalDues,
                    COUNT(GT.SubscriptionTrainerID) AS UnpaidSubscriptionsCount
                FROM GymSubscriptionTrainers GT
                JOIN Trainers T ON GT.TrainerID = T.TrainerID
                JOIN CustomerGymSubscriptions GS ON GT.SubscriptionID = GS.SubscriptionID
                WHERE GT.IsPaid = 0 AND GS.IsActive = 1
                GROUP BY T.TrainerID, T.TrainerName
                HAVING COUNT(GT.SubscriptionTrainerID) > 0";
            return await db.QueryAsync<beautyCenterSystem.viewsmodels.TrainerDuesDTO>(sql);
        }

        public async Task<bool> PayTrainerDuesAsync(int trainerId, decimal totalAmount, int safeId, int userId, string userName)
        {
            using var db = _dbFactory.CreateConnection();
            db.Open();
            using var transaction = db.BeginTransaction();
            try
            {
                // 1. Create Expense Transaction
                string safeTransSql = @"
                    INSERT INTO Expenses 
                    (ExpenseName, Category, Amount, ExpenseDate, PaidFromSafeID, IssuedBy, Notes)
                    VALUES 
                    ('صرف مستحقات مدربة', 'رواتب ومستحقات', @Amount, GETDATE(), @SafeID, @UserID, @Notes)";
                
                await db.ExecuteAsync(safeTransSql, new 
                { 
                    SafeID = safeId, 
                    Amount = totalAmount, 
                    UserID = userId, 
                    Notes = $"صرف مستحقات للمدربة {userName} (رقم {trainerId})"
                }, transaction);

                // 2. Deduct from Safe Balance
                string updateSafeSql = "UPDATE Safes SET Balance = Balance - @Amount WHERE SafeID = @SafeID";
                await db.ExecuteAsync(updateSafeSql, new { Amount = totalAmount, SafeID = safeId }, transaction);

                // 3. Mark trainer dues as paid
                string updateDuesSql = @"
                    UPDATE GymSubscriptionTrainers 
                    SET IsPaid = 1, PaymentDate = GETDATE()
                    WHERE TrainerID = @TrainerID AND IsPaid = 0";
                await db.ExecuteAsync(updateDuesSql, new { TrainerID = trainerId }, transaction);

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
