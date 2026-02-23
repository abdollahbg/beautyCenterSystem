using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautyCenterSystem
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public int AppointmentID { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int IssuedBy { get; set; }
    }
}
