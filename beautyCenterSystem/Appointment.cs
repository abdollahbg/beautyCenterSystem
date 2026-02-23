using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautyCenterSystem
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } // للعرض
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } // يمكن تحويله لـ Enum عند القراءة
        public int CreatedBy { get; set; }
        public decimal TotalPrice { get; set; }

        // قائمة الخدمات المرتبطة بهذا الحجز
        public List<Service> SelectedServices { get; set; } = new List<Service>();
    }
}
