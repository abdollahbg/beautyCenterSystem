using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautyCenterSystem
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int? MaterialID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; } // سيتم جلبه من قاعدة البيانات كقيمة محسوبة
        public DateTime PurchaseDate { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public int? PaidFromSafeID { get; set; }
        public int? IssuedBy { get; set; }

        // خصائص إضافية للعرض
        public string MaterialName { get; set; } = string.Empty;
        public string SafeName { get; set; } = string.Empty;
        public string IssuedByName { get; set; } = string.Empty;
    }
}
