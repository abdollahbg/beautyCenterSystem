using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyCenterSystem.Data;
using BeautyCenterSystem.Models;
using beautyCenterSystem.viewsmodels; // تأكد من وجود المودلز (DTOs) في هذا المجلد

namespace BeautyCenterSystem.Data.Repositories
{
    public class FinancialReportsRepository : BaseRepository
    {
        public FinancialReportsRepository(DbConnectionFactory dbFactory) : base(dbFactory) { }

        // 1. جلب بيانات لوحة المؤشرات (الأرقام الكبيرة)
        public async Task<FinancialDashboardDTO> GetFinancialDashboardAsync(DateTime from, DateTime to)
        {
            using var db = _dbFactory.CreateConnection();

            // استعلام مجمع لجلب كل القيم في طلب واحد لزيادة السرعة
            string sql = @"
                SELECT 
                    ISNULL(SUM(AmountPaid), 0) AS TotalRevenue,
                    ISNULL(SUM(CASE WHEN PaymentMethod = 'Cash' THEN AmountPaid ELSE 0 END), 0) AS CashRevenue,
                    ISNULL(SUM(CASE WHEN PaymentMethod = 'Card' THEN AmountPaid ELSE 0 END), 0) AS CardRevenue
                FROM vw_Financial_Revenues 
                WHERE PaymentDate BETWEEN @From AND @To;

                SELECT ISNULL(SUM(Amount), 0) FROM vw_Financial_Expenses WHERE ExpenseDate BETWEEN @From AND @To;
                
                SELECT ISNULL(SUM(TotalAmount), 0) FROM vw_Financial_Purchases WHERE PurchaseDate BETWEEN @From AND @To;";

            using var multi = await db.QueryMultipleAsync(sql, new { From = from, To = to });

            var revenueInfo = await multi.ReadFirstAsync();
            decimal totalExpenses = await multi.ReadFirstAsync<decimal>();
            decimal totalPurchases = await multi.ReadFirstAsync<decimal>();

            return new FinancialDashboardDTO
            {
                TotalRevenue = revenueInfo.TotalRevenue,
                CashRevenue = revenueInfo.CashRevenue,
                CardRevenue = revenueInfo.CardRevenue,
                TotalExpenses = totalExpenses,
                TotalPurchases = totalPurchases
            };
        }

        // 2. تقرير الإيرادات التفصيلي
        public async Task<IEnumerable<RevenueReportDTO>> GetRevenueReportsAsync(DateTime from, DateTime to)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "SELECT * FROM vw_Financial_Revenues WHERE PaymentDate BETWEEN @From AND @To ORDER BY PaymentDate DESC";
            return await db.QueryAsync<RevenueReportDTO>(sql, new { From = from, To = to });
        }

        // 3. تقرير المصروفات التفصيلي
        public async Task<IEnumerable<ExpenseReportDTO>> GetExpenseReportsAsync(DateTime from, DateTime to)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "SELECT * FROM vw_Financial_Expenses WHERE ExpenseDate BETWEEN @From AND @To ORDER BY ExpenseDate DESC";
            return await db.QueryAsync<ExpenseReportDTO>(sql, new { From = from, To = to });
        }

        // 4. تقرير المشتريات التفصيلي
        public async Task<IEnumerable<PurchaseReportDTO>> GetPurchaseReportsAsync(DateTime from, DateTime to)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "SELECT * FROM vw_Financial_Purchases WHERE PurchaseDate BETWEEN @From AND @To ORDER BY PurchaseDate DESC";
            return await db.QueryAsync<PurchaseReportDTO>(sql, new { From = from, To = to });
        }

        // 5. تقرير أرباح كل غرفة (هام جداً للرسومات البيانية)
        public async Task<IEnumerable<dynamic>> GetRevenueByRoomAsync(DateTime from, DateTime to)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"
                SELECT RoomName, SUM(ServicePrice) AS TotalRevenue 
                FROM vw_Financial_RoomServicePerformance 
                WHERE PaymentDate BETWEEN @From AND @To 
                GROUP BY RoomName 
                ORDER BY TotalRevenue DESC";
            return await db.QueryAsync(sql, new { From = from, To = to });
        }

        // 6. تقرير أكثر الخدمات طلباً
        public async Task<IEnumerable<dynamic>> GetTopServicesAsync(DateTime from, DateTime to)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"
                SELECT TOP 10 ServiceName, COUNT(*) AS TimesRequested, SUM(ServicePrice) AS TotalRevenue
                FROM vw_Financial_RoomServicePerformance
                WHERE PaymentDate BETWEEN @From AND @To
                GROUP BY ServiceName
                ORDER BY TimesRequested DESC";
            return await db.QueryAsync(sql, new { From = from, To = to });
        }

        // 7. جلب حالة الخزائن الحالية (بدون فلترة تاريخ لأنها لحظية)
        public async Task<IEnumerable<dynamic>> GetCurrentSafesStatusAsync()
        {
            using var db = _dbFactory.CreateConnection();
            return await db.QueryAsync("SELECT SafeName, Balance FROM vw_Financial_SafesSummary");
        }
        // 8. جلب تقارير الإغلاق اليومي
        public async Task<IEnumerable<dynamic>> GetDailyClosuresReportsAsync(DateTime from, DateTime to)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"
                SELECT D.*, U.Username AS ClosedByName 
                FROM DailyClosures D
                LEFT JOIN Users U ON D.ClosedBy = U.UserID
                WHERE D.ClosureDate BETWEEN @From AND @To
                ORDER BY D.ClosureDate DESC";
            return await db.QueryAsync(sql, new { From = from, To = to });
        }
        // 1. جلب مدفوعات الموظفين الفعلية (التي تم صرفها من الخزنة)
        public async Task<IEnumerable<dynamic>> GetEmployeeExpensesAsync(DateTime from, DateTime to)
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = @"
            SELECT 
                e.EmployeeName AS EmployeeName,
                ep.AmountPaid AS ExpenseAmount,
                ep.PaymentDate AS ExpenseDate,
                s.SafeName AS SafeName,
                ep.Notes AS Notes
            FROM EmployeePayments ep
            INNER JOIN Employees e ON ep.EmployeeID = e.EmployeeID
            INNER JOIN Safes s ON ep.SafeID = s.SafeID
            WHERE ep.PaymentDate BETWEEN @from AND @to
            ORDER BY ep.PaymentDate DESC";

                return await conn.QueryAsync<dynamic>(sql, new { from, to });
            }
        }

        // 2. جلب إيرادات الكافتيريا (المواد التي تم تعليمها كعنصر كافتيريا)
        public async Task<IEnumerable<dynamic>> GetCafeteriaReportsAsync(DateTime from, DateTime to)
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                string sql = @"
            SELECT 
                m.MaterialName AS ItemName,
                SUM(ad.Quantity) AS QuantitySold,
                SUM(ad.Quantity * ISNULL(ad.PriceAtSale, m.SalePrice)) AS TotalRevenue
            FROM AppointmentDetails ad
            INNER JOIN Materials m ON ad.MaterialID = m.MaterialID
            INNER JOIN Appointments a ON ad.AppointmentID = a.AppointmentID
            WHERE a.AppointmentDate BETWEEN @from AND @to
            AND m.IsCaffeteriaItem = 1
            GROUP BY m.MaterialName
            ORDER BY TotalRevenue DESC";

                return await conn.QueryAsync<dynamic>(sql, new { from, to });
            }
        }

        // 3. جلب ملخص أداء الموظفات (العمولات المستحقة والعمليات المنفذة)
        public async Task<IEnumerable<dynamic>> GetEmployeePerformanceAsync(DateTime from, DateTime to)
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                // الاستعلام يدمج بين استحقاقات العمليات (Ad) وبين المدفوعات الفعلية (Ep) لكل موظفة
                string sql = @"
            SELECT 
                e.EmployeeName AS EmployeeName,
                COUNT(ad.DetailID) AS ServicesCount,
                ISNULL(SUM(ad.PriceAtSale * ad.Quantity), 0) AS TotalServicesRevenue,
                ISNULL(SUM(ad.CommissionAmount), 0) AS TotalEarnedCommissions,
                (SELECT ISNULL(SUM(AmountPaid), 0) 
                 FROM EmployeePayments 
                 WHERE EmployeeID = e.EmployeeID 
                 AND PaymentDate BETWEEN @from AND @to) AS TotalActuallyPaid
            FROM Employees e
            LEFT JOIN AppointmentDetails ad ON e.EmployeeID = ad.EmployeeID
            LEFT JOIN Appointments a ON ad.AppointmentID = a.AppointmentID AND a.Status = 'Completed'
            WHERE (a.AppointmentDate BETWEEN @from AND @to OR a.AppointmentDate IS NULL)
            GROUP BY e.EmployeeID, e.EmployeeName
            ORDER BY TotalServicesRevenue DESC";

                return await conn.QueryAsync<dynamic>(sql, new { from, to });
            }
        }
    }
}