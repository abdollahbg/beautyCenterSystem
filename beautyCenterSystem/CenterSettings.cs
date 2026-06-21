using System;
using System.Drawing;
using System.IO;

namespace BeautyCenterSystem.Models
{
    public class CenterSettings
    {
        public int Id { get; set; } = 1; // سنستخدم دائماً الصف رقم 1
        public string CenterName { get; set; } = "صالون التجميل";
        public string Phone { get; set; } = "0900000000";
        public string Facebook { get; set; } = string.Empty;
        public string Instagram { get; set; } = string.Empty;
        public string WhatsApp { get; set; } = string.Empty;
        public string Note { get; set; } = "الرجاء مراجعة الفاتورة قبل المغادرة.";
        public byte[] LogoBytes { get; set; } = Array.Empty<byte>(); // تخزين الصورة كبايتات في قاعدة البيانات

        // دالة مساعدة لتحويل مصفوفة البايتات إلى Image لاستخدامها في الطباعة
        public Image GetLogoImage()
        {
            if (LogoBytes == null || LogoBytes.Length == 0) return null;
            using (var ms = new MemoryStream(LogoBytes))
            {
                return Image.FromStream(ms);
            }
        }
    }
}