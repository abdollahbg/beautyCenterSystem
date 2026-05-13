using System;

namespace beautyCenterSystem.viewsmodels
{
    public class AppointmentDetailDto
    {
        // 1. المعرفات (IDs)
        public int DetailID { get; set; }      // مهم جداً للتحكم في حالة الخدمة (Start/Complete)
        public int? ServiceID { get; set; }
        public int? MaterialID { get; set; }
        public int? EmployeeID { get; set; }

        // 2. بيانات العرض
        public string Name { get; set; }
        public string EmployeeName { get; set; }
        public string RoomName { get; set; }

        // 3. البيانات المالية والكميات
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal CommissionAmount { get; set; }

        // --- التعديلات الجديدة للحالة والتوقيت ---
        public string Status { get; set; } = "Pending"; // (Pending, InProgress, Completed, Canceled)
        public DateTime? ActualStartTime { get; set; }  // وقت بدء الخدمة فعلياً
        public DateTime? ActualEndTime { get; set; }    // وقت انتهاء الخدمة فعلياً
        // ------------------------------------------
    }
}