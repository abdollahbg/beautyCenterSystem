using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautyCenterSystem
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Phone { get; set; }
        public decimal CommissionRate { get; set; }
        public int? RoomID { get; set; }
        public string RoomName { get; set; } // للحاجات العرض فقط
        public bool IsActive { get; set; }
    }
}
