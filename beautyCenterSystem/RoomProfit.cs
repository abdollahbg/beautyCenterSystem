using System;

namespace beautyCenterSystem
{
    public class RoomProfit
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public decimal TotalRevenue { get; set; }
        public decimal TotalExpenses { get; set; }
        
        public decimal NetProfit => TotalRevenue - TotalExpenses;
    }
}
