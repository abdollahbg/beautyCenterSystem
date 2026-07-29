using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautyCenterSystem.viewsmodels
{
    public class ExpenseReportDTO
    {
        public int ExpenseID { get; set; }
        public string ExpenseName { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string PaidFromSafe { get; set; }
        public string IssuedBy { get; set; }
        public string RoomName { get; set; }
    }
}
