using System;

namespace beautyCenterSystem.viewsmodels
{
    public class AppointmentDetailDto
    {
        // 1. المعرفات (IDs)
        public int? ServiceID { get; set; }   // يقبل Null إذا كان العنصر "مادة"
        public int? MaterialID { get; set; }  // يقبل Null إذا كان العنصر "خدمة"
        public int? EmployeeID { get; set; }  // رقم الموظفة للعمولة

        // 2. بيانات العرض (للجداول والطباعة)
        public string Name { get; set; }          // اسم الخدمة أو المادة
        public string EmployeeName { get; set; }  // اسم الموظفة (للعرض)

        // --- الإضافة الجديدة هنا ---
        public string RoomName { get; set; }      // اسم الغرفة الذي سيظهر كـ "نوع الخدمة" في الفاتورة
        // ---------------------------

        // 3. البيانات المالية والكميات
        public int Quantity { get; set; }         // الكمية (مهمة للكافيتيريا)
        public decimal Price { get; set; }        // السعر وقت البيع

        // 4. الحقول المالية الإضافية
        public decimal CommissionAmount { get; set; }
    }
}