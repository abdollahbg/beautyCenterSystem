using System;

namespace beautyCenterSystem
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public string IconPath { get; set; }
        public bool IsActive { get; set; }
        // الحقل الجديد للتمييز بين غرف الخدمات والكافيتيريا
        public bool IsCaffeteria { get; set; }
        public override string ToString()
        {
            return RoomName;
        }
    }
}