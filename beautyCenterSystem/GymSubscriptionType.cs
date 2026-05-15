using System;

namespace beautyCenterSystem
{
    public class GymSubscriptionType
    {
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public int DurationDays { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public bool IsSessionBased { get; set; }
        public int TotalSessions { get; set; }
    }
}
