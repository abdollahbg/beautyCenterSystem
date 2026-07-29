using System;

namespace beautyCenterSystem
{
    public class Trainer
    {
        public int TrainerID { get; set; }
        public string TrainerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public decimal CurrentDues { get; set; } // المستحقات الحالية
    }
}
