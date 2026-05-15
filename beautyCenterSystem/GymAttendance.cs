using System;

namespace beautyCenterSystem
{
    public class GymAttendance
    {
        public int AttendanceID { get; set; }
        public int SubscriptionID { get; set; }
        public DateTime CheckInTime { get; set; }
        public string Note { get; set; }
    }
}
