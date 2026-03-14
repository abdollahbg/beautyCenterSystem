using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautyCenterSystem.viewsmodels
{
    public class PurchaseReportDTO
    {
        public int InvoiceID { get; set; }
        public string SupplierName { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PaidFromSafe { get; set; }
        public string IssuedBy { get; set; }
    }
}
