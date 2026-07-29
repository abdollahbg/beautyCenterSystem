using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautyCenterSystem.viewsmodels
{
    public class DailySummaryDTO
    {
        public decimal TotalCashIn { get; set; }
        public decimal TotalCardIn { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal TotalPurchases { get; set; }
        public decimal TotalCafeteriaIn { get; set; }
        // الرصيد الدفتري المتوقع = الكاش والشبكة الداخلة - المصروفات والمشتريات
        public decimal ExpectedCash => (TotalCashIn + TotalCardIn) - (TotalExpenses + TotalPurchases);
    }
}
