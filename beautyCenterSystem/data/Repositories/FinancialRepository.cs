using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeautyCenterSystem.Data;
using beautyCenterSystem;
using beautyCenterSystem.data.Repositories;
using beautyCenterSystem.viewsmodels;

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
        // --- إضافة خزنة جديدة ---
        public async Task<bool> AddNewSafeAsync(string safeName, decimal initialBalance)
        {
            using var db = _dbFactory.CreateConnection();
            // نستخدم IsActive = 1 كقيمة افتراضية حسب تصميمك
            string sql = @"INSERT INTO Safes (SafeName, Balance, IsActive) 
                   VALUES (@Name, @Balance, 1)";

            int rows = await db.ExecuteAsync(sql, new { Name = safeName, Balance = initialBalance });
            return rows > 0;
        }

        // جلب الخزنة المربوطة بطريقة دفع معينة (مثلاً Cash أو Card)
        public async Task<int> GetSafeIdByPaymentMethodAsync(string method)
        {
            using var db = _dbFactory.CreateConnection();
            // إذا لم يجد ربطاً، سيرجع 0 (لذا يجب معالجة هذه الحالة)
            string sql = "SELECT SafeID FROM PaymentMapping WHERE MethodName = @Method";
            return await db.QueryFirstOrDefaultAsync<int>(sql, new { Method = method });
        }

        // تحديث أو إضافة ربط جديد (يُستخدم من واجهة الإعدادات - Tab 3)
        public async Task<bool> UpdatePaymentMappingAsync(string method, int safeId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"IF EXISTS (SELECT 1 FROM PaymentMapping WHERE MethodName = @Method)
                   UPDATE PaymentMapping SET SafeID = @SId WHERE MethodName = @Method
                   ELSE
                   INSERT INTO PaymentMapping (MethodName, SafeID) VALUES (@Method, @SId)";

            int rows = await db.ExecuteAsync(sql, new { Method = method, SId = safeId });
            return rows > 0;
        }

        // جلب كل الإعدادات الحالية لعرضها في الواجهة
        public async Task<IEnumerable<dynamic>> GetAllPaymentMappingsAsync()
        {
            using var db = _dbFactory.CreateConnection();
            return await db.QueryAsync("SELECT * FROM PaymentMapping");
        }
        // --- جلب سجل التحويلات ---
        public async Task<IEnumerable<dynamic>> GetTransferHistoryAsync()
        {
            using var db = _dbFactory.CreateConnection();
            // نستخدم JOIN لنجلب أسماء الخزنات واسم الموظف بدلاً من الأرقام (IDs)
            string sql = @"
        SELECT 
            t.TransferID, 
            f.SafeName AS FromSafe, 
            s.SafeName AS ToSafe, 
            t.Amount, 
            t.TransferDate, 
            u.Username AS TransferredBy, 
            t.Notes
        FROM SafeTransfers t
        JOIN Safes f ON t.FromSafeID = f.SafeID
        JOIN Safes s ON t.ToSafeID = s.SafeID
        JOIN Users u ON t.CreatedBy = u.UserID
        ORDER BY t.TransferDate DESC";

            return await db.QueryAsync(sql);
        }
        // 1. جلب قائمة المواد لملء الكومبو بوكس عند الشراء
        public async Task<IEnumerable<dynamic>> GetAllMaterialsAsync()
        {
            using var db = _dbFactory.CreateConnection();
            return await db.QueryAsync("SELECT MaterialID, MaterialName FROM Materials WHERE IsAvailable = 1");
        }

        // 2. جلب سجل المشتريات مع أسماء المواد والخزنات (لعرضها في الجدول)
        public async Task<IEnumerable<dynamic>> GetPurchasesHistoryAsync()
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"
        SELECT 
            P.PurchaseID, 
            M.MaterialName, 
            P.Quantity, 
            P.UnitPrice, 
            P.TotalAmount, 
            P.PurchaseDate, 
            P.SupplierName, 
            S.SafeName AS PaidFromSafe,
            U.Username AS IssuedBy
        FROM Purchases P
        JOIN Materials M ON P.MaterialID = M.MaterialID
        JOIN Safes S ON P.PaidFromSafeID = S.SafeID
        JOIN Users U ON P.IssuedBy = U.UserID
        ORDER BY P.PurchaseDate DESC";

            return await db.QueryAsync(sql);
        }
        // 1. حذف عملية شراء ورد المبلغ للخزنة
        public async Task<bool> DeletePurchaseAsync(int purchaseId, decimal totalAmount, int safeId)
        {
            using var db = _dbFactory.CreateConnection();
            db.Open();
            using var transaction = db.BeginTransaction();
            try
            {
                // حذف السجل
                await db.ExecuteAsync("DELETE FROM Purchases WHERE PurchaseID = @Id", new { Id = purchaseId }, transaction);

                // رد المبلغ للخزنة
                await db.ExecuteAsync("UPDATE Safes SET Balance = Balance + @Amt WHERE SafeID = @SId",
                    new { Amt = totalAmount, SId = safeId }, transaction);

                transaction.Commit();
                return true;
            }
            catch { transaction.Rollback(); throw; }
        }

        // 2. تعديل عملية شراء (مع معالجة فرق السعر في الخزنة)
        public async Task<bool> UpdatePurchaseAsync(Purchase p, decimal oldTotal)
        {
            using var db = _dbFactory.CreateConnection();
            db.Open();
            using var transaction = db.BeginTransaction();
            try
            {
                // 1. تحديث بيانات المشتريات
                string sql = @"UPDATE Purchases SET MaterialID=@MaterialID, Quantity=@Quantity, 
                       UnitPrice=@UnitPrice, SupplierName=@SupplierName WHERE PurchaseID=@PurchaseID";

                await db.ExecuteAsync(sql, p, transaction);

                // 2. معالجة فرق السعر في الخزنة
                decimal newTotal = p.Quantity * p.UnitPrice;
                decimal diff = newTotal - oldTotal;

                // إذا كان الفرق موجباً سيخصم من الخزنة، وإذا سالباً (تخفيض سعر) سيعود للخزنة
                await db.ExecuteAsync("UPDATE Safes SET Balance = Balance - @Diff WHERE SafeID = @SId",
                    new { Diff = diff, SId = p.PaidFromSafeID }, transaction);

                transaction.Commit();
                return true; // الإرجاع في حال النجاح
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                // إما أن تعيد false أو تقوم بعمل throw ليتم معالجته في الواجهة
                throw new Exception($"فشل تحديث المشتريات: {ex.Message}");
            }
        }
        // 1. إضافة فاتورة مشتريات كاملة مع تفاصيلها
        public async Task<bool> AddPurchaseInvoiceAsync(PurchaseInvoice invoice)
        {
            using var db = _dbFactory.CreateConnection();
            db.Open();
            using var transaction = db.BeginTransaction();
            try
            {
                // أولاً: إدخال رأس الفاتورة والحصول على الـ ID الجديد
                string sqlInvoice = @"INSERT INTO PurchaseInvoices (SupplierName, TotalAmount, PurchaseDate, PaidFromSafeID, IssuedBy, Notes) 
                              VALUES (@SupplierName, @TotalAmount, @PurchaseDate, @PaidFromSafeID, @IssuedBy, @Notes);
                              SELECT CAST(SCOPE_IDENTITY() as int);";

                int invoiceId = await db.QuerySingleAsync<int>(sqlInvoice, invoice, transaction);

                // ثانياً: إدخال تفاصيل الفاتورة (المواد)
                string sqlDetails = @"INSERT INTO PurchaseDetails (InvoiceID, MaterialID, Quantity, UnitPrice) 
                              VALUES (@InvoiceID, @MaterialID, @Quantity, @UnitPrice)";

                foreach (var detail in invoice.Details)
                {
                    detail.InvoiceID = invoiceId;
                    await db.ExecuteAsync(sqlDetails, detail, transaction);
                }

                // ثالثاً: خصم المبلغ الإجمالي من الخزنة المحددة
                await db.ExecuteAsync("UPDATE Safes SET Balance = Balance - @Amt WHERE SafeID = @SId",
                    new { Amt = invoice.TotalAmount, SId = invoice.PaidFromSafeID }, transaction);

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"خطأ في حفظ فاتورة المشتريات: {ex.Message}");
            }
        }

        // 2. جلب قائمة الفواتير (لجدول الفواتير العلوي)
        public async Task<IEnumerable<dynamic>> GetPurchaseInvoicesAsync(DateTime from, DateTime to)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"SELECT I.*, S.SafeName, U.Username as IssuedByName 
                   FROM PurchaseInvoices I
                   JOIN Safes S ON I.PaidFromSafeID = S.SafeID
                   JOIN Users U ON I.IssuedBy = U.UserID
                   WHERE I.PurchaseDate BETWEEN @From AND @To
                   ORDER BY I.PurchaseDate DESC";

            return await db.QueryAsync(sql, new { From = from.Date, To = to.Date.AddDays(1).AddSeconds(-1) });
        }

        // 3. جلب تفاصيل فاتورة محددة (للجدول السفلي عند الضغط على فاتورة)
        public async Task<IEnumerable<dynamic>> GetInvoiceDetailsAsync(int invoiceId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"SELECT D.*, M.MaterialName 
                   FROM PurchaseDetails D
                   JOIN Materials M ON D.MaterialID = M.MaterialID
                   WHERE D.InvoiceID = @Id";

            return await db.QueryAsync(sql, new { Id = invoiceId });
        }
        public async Task<bool> DeletePurchaseInvoiceAsync(int invoiceId, decimal amount, int safeId)
        {
            using var db = _dbFactory.CreateConnection();
            db.Open();
            using var transaction = db.BeginTransaction();
            try
            {
                // 1. حذف الفاتورة (سيحذف التفاصيل تلقائياً بفضل Cascade)
                await db.ExecuteAsync("DELETE FROM PurchaseInvoices WHERE InvoiceID = @Id", new { Id = invoiceId }, transaction);

                // 2. رد المبلغ المخصوم للخزنة
                await db.ExecuteAsync("UPDATE Safes SET Balance = Balance + @Amt WHERE SafeID = @SId",
                    new { Amt = amount, SId = safeId }, transaction);

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"فشل حذف الفاتورة: {ex.Message}");
            }
        }

        // --- الدوال الإضافية الجديدة لإدارة التفاصيل الفردية ---

        public async Task<bool> AddPurchaseDetailAsync(PurchaseDetail detail, int safeId)
        {
            using var db = _dbFactory.CreateConnection();
            db.Open();
            using var transaction = db.BeginTransaction();
            try
            {
                // 1. إدخال السطر الجديد
                string sqlDetail = @"INSERT INTO PurchaseDetails (InvoiceID, MaterialID, Quantity, UnitPrice) 
                                     VALUES (@InvoiceID, @MaterialID, @Quantity, @UnitPrice)";
                await db.ExecuteAsync(sqlDetail, detail, transaction);

                decimal rowTotal = detail.Quantity * detail.UnitPrice;

                // 2. تحديث إجمالي الفاتورة الرئيسية
                await db.ExecuteAsync("UPDATE PurchaseInvoices SET TotalAmount = TotalAmount + @Amt WHERE InvoiceID = @Id",
                    new { Amt = rowTotal, Id = detail.InvoiceID }, transaction);

                // 3. خصم المبلغ من الخزنة
                await db.ExecuteAsync("UPDATE Safes SET Balance = Balance - @Amt WHERE SafeID = @SId",
                    new { Amt = rowTotal, SId = safeId }, transaction);

                transaction.Commit();
                return true;
            }
            catch { transaction.Rollback(); throw; }
        }

        public async Task<bool> DeletePurchaseDetailAsync(int detailId)
        {
            using var db = _dbFactory.CreateConnection();
            db.Open();
            using var transaction = db.BeginTransaction();
            try
            {
                // جلب بيانات السطر والخزنة قبل الحذف لرد المال
                string sqlGet = @"SELECT d.Quantity, d.UnitPrice, d.InvoiceID, i.PaidFromSafeID 
                                  FROM PurchaseDetails d 
                                  JOIN PurchaseInvoices i ON d.InvoiceID = i.InvoiceID 
                                  WHERE d.DetailID = @Id";
                var info = await db.QueryFirstOrDefaultAsync(sqlGet, new { Id = detailId }, transaction);

                if (info != null)
                {
                    decimal amountToRefund = (decimal)info.Quantity * (decimal)info.UnitPrice;

                    // رد المال للخزنة
                    await db.ExecuteAsync("UPDATE Safes SET Balance = Balance + @Amt WHERE SafeID = @SId",
                        new { Amt = amountToRefund, SId = info.PaidFromSafeID }, transaction);

                    // خصم القيمة من إجمالي الفاتورة
                    await db.ExecuteAsync("UPDATE PurchaseInvoices SET TotalAmount = TotalAmount - @Amt WHERE InvoiceID = @InvId",
                        new { Amt = amountToRefund, InvId = info.InvoiceID }, transaction);

                    // حذف السجل
                    await db.ExecuteAsync("DELETE FROM PurchaseDetails WHERE DetailID = @Id", new { Id = detailId }, transaction);
                }

                transaction.Commit();
                return true;
            }
            catch { transaction.Rollback(); throw; }
        }
        // 1. جلب الفواتير بناءً على تاريخ محدد فقط
        public async Task<IEnumerable<PurchaseInvoice>> GetPurchaseInvoicesByDateAsync(DateTime date)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"SELECT I.*, S.SafeName, U.Username as IssuedByName 
                   FROM PurchaseInvoices I
                   JOIN Safes S ON I.PaidFromSafeID = S.SafeID
                   JOIN Users U ON I.IssuedBy = U.UserID
                   WHERE CAST(I.PurchaseDate AS DATE) = @SelectedDate
                   ORDER BY I.PurchaseDate DESC";

            return await db.QueryAsync<PurchaseInvoice>(sql, new { SelectedDate = date.Date });
        }

        // 2. إنشاء رأس الفاتورة فقط (بدون تفاصيل) وإرجاع الرقم التعريفي ID
        public async Task<int> CreatePurchaseHeaderAsync(PurchaseInvoice invoice)
        {
            using var db = _dbFactory.CreateConnection();
            // ننشئ الفاتورة بإجمالي 0 في البداية، وسيزداد مع إضافة التفاصيل
            string sql = @"INSERT INTO PurchaseInvoices (SupplierName, TotalAmount, PurchaseDate, PaidFromSafeID, IssuedBy, Notes) 
                   VALUES (@SupplierName, 0, @PurchaseDate, @PaidFromSafeID, @IssuedBy, @Notes);
                   SELECT CAST(SCOPE_IDENTITY() as int);";

            return await db.QuerySingleAsync<int>(sql, invoice);
        }

        // 3. جلب تفاصيل فاتورة محددة (كـ List من موديل PurchaseDetail)
        public async Task<IEnumerable<PurchaseDetail>> GetPurchaseDetailsAsync(int invoiceId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"SELECT D.*, M.MaterialName 
                   FROM PurchaseDetails D
                   JOIN Materials M ON D.MaterialID = M.MaterialID
                   WHERE D.InvoiceID = @Id";

            return await db.QueryAsync<PurchaseDetail>(sql, new { Id = invoiceId });
        }
        public async Task<DailySummaryDTO> GetDailyFinancialSummaryAsync()
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = @"
        -- 0. تحديد خزنة الكاش ديناميكياً من جدول الربط
        DECLARE @CashSafeId INT = (SELECT TOP 1 SafeID FROM PaymentMapping WHERE MethodName = 'Cash');

        -- 1. المبيعات (نأخذ الكاش الذي دخل الخزنة المحددة، والشبكة بشكل عام)
        SELECT 
            ISNULL(SUM(CASE WHEN SafeID = @CashSafeId THEN AmountPaid ELSE 0 END), 0) as TotalCashIn,
            ISNULL(SUM(CASE WHEN PaymentMethod = 'Card' THEN AmountPaid ELSE 0 END), 0) as TotalCardIn
        FROM Payments 
        WHERE CAST(PaymentDate AS DATE) = CAST(GETDATE() AS DATE);

        -- 2. المصروفات (التي خرجت من خزنة الكاش حصراً)
        SELECT ISNULL(SUM(Amount), 0) FROM Expenses 
        WHERE CAST(ExpenseDate AS DATE) = CAST(GETDATE() AS DATE)
          AND PaidFromSafeID = @CashSafeId;

        -- 3. المشتريات (التي خُصمت من خزنة الكاش حصراً)
        SELECT ISNULL(SUM(TotalAmount), 0) FROM PurchaseInvoices 
        WHERE CAST(PurchaseDate AS DATE) = CAST(GETDATE() AS DATE)
          AND PaidFromSafeID = @CashSafeId;";

                using (var multi = await conn.QueryMultipleAsync(sql))
                {
                    var sales = await multi.ReadFirstAsync<dynamic>();
                    var expenses = await multi.ReadFirstAsync<decimal>();
                    var purchases = await multi.ReadFirstAsync<decimal>();

                    return new DailySummaryDTO
                    {
                        TotalCashIn = (decimal)sales.TotalCashIn,
                        TotalCardIn = (decimal)sales.TotalCardIn,
                        TotalExpenses = expenses,
                        TotalPurchases = purchases
                        // ملاحظة: ExpectedCash سيتم حسابها تلقائياً داخل الـ DTO
                    };
                }
            }
        }
        public async Task<bool> SaveDailyClosureAsync(decimal cashSystem, decimal cardSystem, decimal expenses, decimal purchases, decimal actualCash, int userId, string notes)
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                // المعادلة: (النقد الفعلي) - (النقد المتوقع دفترياً)
                // النقد المتوقع دفترياً = (إجمالي الكاش الداخل - المصروفات - المشتريات)
                string sql = @"INSERT INTO DailyClosures 
                     (TotalCashSystem, TotalCardSystem, TotalExpenses, TotalPurchases, ActualCashHand, Difference, ClosedBy, Notes, ClosureDate)
                     VALUES 
                     (@cashSystem, @cardSystem, @expenses, @purchases, @actualCash, 
                      (@actualCash - (@cashSystem - (@expenses + @purchases))), 
                      @userId, @notes, GETDATE())";

                var result = await conn.ExecuteAsync(sql, new
                {
                    cashSystem,
                    cardSystem,
                    expenses,
                    purchases,
                    actualCash,
                    userId,
                    notes
                });

                return result > 0;
            }
        }
    }

}