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
        // الرصيد الدفتري المتوقع (كاش فقط) = الكاش الداخل - المصروفات - المشتريات
        public decimal ExpectedCash => TotalCashIn - (TotalExpenses + TotalPurchases);
    }
}
