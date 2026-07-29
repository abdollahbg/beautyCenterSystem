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
        public string EmployeeType { get; set; } = "Commission"; // 'Commission' or 'Salary'
        public decimal BaseSalary { get; set; }
        public bool IsActive { get; set; }
        public decimal CurrentDues { get; set; } // المستحقات الحالية
    }
}
