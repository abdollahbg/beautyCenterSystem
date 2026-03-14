using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautyCenterSystem.viewsmodels
{
    public class FinancialDashboardDTO
    {
        public decimal TotalRevenue { get; set; }     // إجمالي الدخل
        public decimal TotalExpenses { get; set; }    // إجمالي المصروفات
        public decimal TotalPurchases { get; set; }   // إجمالي المشتريات
        public decimal NetProfit => TotalRevenue - (TotalExpenses + TotalPurchases); // صافي الربح (محسوب)

        public decimal CashRevenue { get; set; }      // دخل الكاش
        public decimal CardRevenue { get; set; }      // دخل البطاقة
    }
}
