using System;

namespace beautyCenterSystem
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public decimal Price { get; set; } // السعر المعروض للزبونة

        // الحقل الجديد: السعر الذي تُحسب منه نسبة الموظفة
        public decimal EmployeeBasePrice { get; set; }

        public int DurationMinutes { get; set; }
        public int RoomID { get; set; }
        public string RoomName { get; set; } = string.Empty; // للعرض فقط (Join)
        public bool IsActive { get; set; }
    }
}