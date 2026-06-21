using System;

namespace beautyCenterSystem
{
    public class GymPackageTrainer
    {
        public int PackageID { get; set; }
        public int TrainerID { get; set; }
        public string TrainerName { get; set; } 
        public decimal BaseAmount { get; set; }
        public decimal CommissionRate { get; set; }
    }
}
