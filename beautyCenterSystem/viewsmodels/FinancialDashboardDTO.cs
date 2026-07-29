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
        public decimal TotalCafeteriaRevenue { get; set; } // دخل الكافيتيريا
        public decimal TotalExpenses { get; set; }    // إجمالي المصروفات
        public decimal TotalPurchases { get; set; }   // إجمالي المشتريات
        
        public decimal TotalEmployeeDues { get; set; } // إجمالي مستحقات الموظفات المكتسبة
        public decimal TotalTrainerDues { get; set; }  // إجمالي مستحقات المدربات المكتسبة
        
        public decimal NetProfit => TotalRevenue - (TotalExpenses + TotalPurchases + TotalEmployeeDues + TotalTrainerDues); // صافي الربح الحقيقي

        public decimal CashRevenue { get; set; }      // دخل الكاش
        public decimal CardRevenue { get; set; }      // دخل البطاقة
    }
}
