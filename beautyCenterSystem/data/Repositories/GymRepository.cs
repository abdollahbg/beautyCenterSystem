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

        public async Task<bool> AddSubscriptionTypeAsync(GymSubscriptionType type)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"INSERT INTO GymSubscriptionTypes (TypeName, DurationDays, Price, IsActive, IsSessionBased, TotalSessions) 
                           VALUES (@TypeName, @DurationDays, @Price, 1, @IsSessionBased, @TotalSessions)";
            int rows = await db.ExecuteAsync(sql, type);
            return rows > 0;
        }

        public async Task<bool> UpdateSubscriptionTypeAsync(GymSubscriptionType type)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"UPDATE GymSubscriptionTypes 
                           SET TypeName = @TypeName, 
                               DurationDays = @DurationDays,
                               Price = @Price,
                               IsSessionBased = @IsSessionBased,
                               TotalSessions = @TotalSessions
                           WHERE TypeID = @TypeID";
            int rows = await db.ExecuteAsync(sql, type);
            return rows > 0;
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
                    (@CustomerID, @TypeID, @StartDate, @EndDate, @PaidAmount, @SafeID, @IssuedBy, @Notes, GETDATE(), @SessionsRemaining, 1)";
                
                await db.ExecuteAsync(insertSql, subscription, transaction);

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
    }
}
