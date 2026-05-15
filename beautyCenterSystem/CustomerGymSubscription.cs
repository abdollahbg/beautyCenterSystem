using System;

namespace beautyCenterSystem
{
    public class CustomerGymSubscription
    {
        public int SubscriptionID { get; set; }
        public int CustomerID { get; set; }
        public int TypeID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PaidAmount { get; set; }
        public int? SafeID { get; set; }
        public int? IssuedBy { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public int SessionsRemaining { get; set; }
        public bool IsActive { get; set; }
    }
}
