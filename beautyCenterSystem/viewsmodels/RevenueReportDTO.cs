using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautyCenterSystem.viewsmodels
{
    public class RevenueReportDTO
    {
        public int PaymentID { get; set; }
        public int AppointmentID { get; set; }
        public string CustomerName { get; set; }
        public decimal AmountSystem { get; set; }
        public decimal Discount { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public string SafeName { get; set; }
        public string ReceiverName { get; set; }
    }
}
