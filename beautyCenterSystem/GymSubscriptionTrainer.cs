using System;

namespace beautyCenterSystem
{
    public class GymSubscriptionTrainer
    {
        public int SubscriptionTrainerID { get; set; }
        public int SubscriptionID { get; set; }
        public int TrainerID { get; set; }
        public string TrainerName { get; set; } = string.Empty; // للعرض فقط
        public decimal BaseAmount { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal CommissionAmount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
