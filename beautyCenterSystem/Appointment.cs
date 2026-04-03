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

    // التعديل هنا: غير List<Service> إلى القائمة الجديدة
    public List<AppointmentDetailDto> SelectedServices { get; set; } = new List<AppointmentDetailDto>();
}