using System;

namespace beautyCenterSystem
{
    public class GymSubscriptionStatus
    {
        public int SubscriptionID { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string SubscriptionType { get; set; }
        public bool IsSessionBased { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SessionsRemaining { get; set; }
        public string SubscriptionStatus { get; set; }
        public decimal PaidAmount { get; set; }
    }
}
