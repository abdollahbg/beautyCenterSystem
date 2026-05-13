using System;
using System.Collections.Generic;
using beautyCenterSystem.viewsmodels;

public class Appointment
{
    public int AppointmentID { get; set; }
    public int CustomerID { get; set; }
    public string CustomerName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; } = "Pending";
    public int CreatedBy { get; set; }

    // --- التعديلات الجديدة لتوقيت العميل داخل المركز ---
    public DateTime? ArrivalTime { get; set; }  // وقت وصول العميلة للمركز
    public DateTime? FinishTime { get; set; }   // وقت انتهاء كل الخدمات (قبل الدفع)
    // --------------------------------------------------

    public List<AppointmentDetailDto> SelectedServices { get; set; } = new List<AppointmentDetailDto>();
}