using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautyCenterSystem
{
    public class SafeTransfer
    {
        public int TransferID { get; set; }
        public int? FromSafeID { get; set; }
        public int? ToSafeID { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransferDate { get; set; }
        public int? CreatedBy { get; set; }
        public string Notes { get; set; }

        // للعرض في الجداول
        public string FromSafeName { get; set; }
        public string ToSafeName { get; set; }
        public string CreatedByName { get; set; }
    }
}
