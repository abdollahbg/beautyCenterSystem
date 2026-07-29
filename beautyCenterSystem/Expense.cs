using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautyCenterSystem
{
    public class Expense
    {
        public int ExpenseID { get; set; }
        public string ExpenseName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int? PaidFromSafeID { get; set; }
        public int? IssuedBy { get; set; }
        public string Notes { get; set; } = string.Empty;

        // خصائص إضافية للعرض في الجداول (اختياري ولكن مفيد جداً)
        public string SafeName { get; set; } = string.Empty;
        public string IssuedByName { get; set; } = string.Empty;
        
        public int? RoomID { get; set; }
        public string RoomName { get; set; } = string.Empty;
    }
}
