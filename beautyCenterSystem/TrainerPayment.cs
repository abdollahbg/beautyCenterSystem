using System;

namespace beautyCenterSystem
{
    public class TrainerPayment
    {
        public int PaymentID { get; set; }
        public int TrainerID { get; set; }
        public string TrainerName { get; set; } = string.Empty;
        public int SafeID { get; set; }
        public string SafeName { get; set; } = string.Empty;
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public int? IssuedBy { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
