using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BeautyCenterSystem.Models;

namespace beautyCenterSystem
{
    public class SubscriptionReceiptPrinter
    {
        // ================= 1. الإعدادات والبيانات =================
        public string CenterName { get; set; } = "مركز التجميل";
        public string Phone { get; set; } = "";
        public Image? Logo { get; set; } = null;
        public string Policy { get; set; } = "الرجاء الاحتفاظ بواصل الاشتراك.\nالمبالغ المدفوعة غير قابلة للاسترداد.";

        public string FacebookHandle { get; set; } = string.Empty;
        public string InstagramHandle { get; set; } = string.Empty;
        public string WhatsAppHandle { get; set; } = string.Empty;

        public void SetSettings(CenterSettings settings)
        {
            if (settings != null)
            {
                CenterName = settings.CenterName;
                Phone = settings.Phone;
                FacebookHandle = settings.Facebook;
                InstagramHandle = settings.Instagram;
                WhatsAppHandle = settings.WhatsApp;
            }
        }

        public int ReceiptNumber { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string SubscriptionDate { get; set; } = string.Empty;
        public string PackageName { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public decimal AmountPaid { get; set; }
        public string CashierName { get; set; } = string.Empty;
        public int SessionsRemaining { get; set; } = 0;
        public bool IsSessionBased { get; set; } = false;

        // ================= 2. وظيفة الطباعة =================
        public void PrintReceipt(bool showPreview = false)
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("Thermal80mm", 285, 0);
            pd.PrintPage += Pd_PrintPage;

            if (showPreview)
            {
                PrintPreviewDialog preview = new PrintPreviewDialog { Document = pd };
                preview.ShowDialog();
            }
            else
            {
                pd.PrintController = new StandardPrintController();
                pd.Print();
            }
        }

        // ================= 3. محرك الرسم =================
        private void Pd_PrintPage(object? sender, PrintPageEventArgs e)
        {
            Graphics? g = e.Graphics;
            if (g == null) return;

            int y = 10;
            int width = 270;

            // إعدادات الخطوط
            Font fontTitle = new Font("Tahoma", 11, FontStyle.Bold);
            Font fontHeader = new Font("Tahoma", 9, FontStyle.Bold);
            Font fontBody = new Font("Tahoma", 8);
            Font fontSmall = new Font("Tahoma", 7);

            StringFormat formatCenter = new StringFormat { Alignment = StringAlignment.Center, FormatFlags = StringFormatFlags.DirectionRightToLeft };
            StringFormat formatRight = new StringFormat { Alignment = StringAlignment.Near, FormatFlags = StringFormatFlags.DirectionRightToLeft };
            StringFormat formatLeft = new StringFormat { Alignment = StringAlignment.Far, FormatFlags = StringFormatFlags.DirectionRightToLeft };

            // --- الترويسة ---
            if (Logo != null)
            {
                int logoSize = 65;
                g.DrawImage(Logo, (width - logoSize) / 2, y, logoSize, logoSize);
                y += logoSize + 5;
            }

            g.DrawString(CenterName, fontTitle, Brushes.Black, new RectangleF(0, y, width, 25), formatCenter);
            y += 25;

            g.DrawString("واصل اشتراك جيم", fontHeader, Brushes.Black, new RectangleF(0, y, width, 20), formatCenter);
            y += 25;

            // --- معلومات الإيصال ---
            g.DrawString($"رقم الإيصال: {ReceiptNumber}", fontBody, Brushes.Black, new RectangleF(0, y, width / 2, 20), formatRight);
            g.DrawString($"التاريخ: {SubscriptionDate}", fontBody, Brushes.Black, new RectangleF(width / 2, y, width / 2, 20), formatLeft);
            y += 20;

            g.DrawString($"العميلة: {CustomerName}", fontHeader, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
            y += 25;

            g.DrawString(new string('-', 45), fontBody, Brushes.Black, new RectangleF(0, y, width, 20), formatCenter);
            y += 15;

            // --- تفاصيل الاشتراك ---
            g.DrawString($"نوع الباقة: {PackageName}", fontHeader, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
            y += 25;

            g.DrawString(new string('-', 45), fontBody, Brushes.Black, new RectangleF(0, y, width, 20), formatCenter);
            y += 15;

            // --- الإجمالي ---
            g.DrawString($"المبلغ المدفوع: {AmountPaid} د.ل", fontHeader, Brushes.Black, new RectangleF(0, y, width, 25), formatRight);
            y += 25;

            g.DrawString(new string('-', 45), fontBody, Brushes.Black, new RectangleF(0, y, width, 20), formatCenter);
            y += 15;

            // --- معلومات إضافية ---
            g.DrawString($"الموظفة: {CashierName}", fontBody, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
            y += 20;
            g.DrawString($"الهاتف: {Phone}", fontBody, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
            y += 20;

            // --- حسابات التواصل الاجتماعي ---
            if (!string.IsNullOrEmpty(FacebookHandle))
            {
                g.DrawString($"FB: {FacebookHandle}", fontSmall, Brushes.Black, new RectangleF(0, y, width, 15), formatCenter);
                y += 15;
            }
            if (!string.IsNullOrEmpty(InstagramHandle))
            {
                g.DrawString($"IG: {InstagramHandle}", fontSmall, Brushes.Black, new RectangleF(0, y, width, 15), formatCenter);
                y += 15;
            }
            if (!string.IsNullOrEmpty(WhatsAppHandle))
            {
                g.DrawString($"WA: {WhatsAppHandle}", fontSmall, Brushes.Black, new RectangleF(0, y, width, 15), formatCenter);
                y += 15;
            }

            y += 10;
            // --- سياسة الاسترجاع / الملاحظات ---
            g.DrawString(Policy, fontSmall, Brushes.Black, new RectangleF(0, y, width, 40), formatCenter);
            y += 40;

            g.DrawString("شكراً لاشتراكك معنا!", fontHeader, Brushes.Black, new RectangleF(0, y, width, 25), formatCenter);
            y += 30;

            // تمديد الصفحة إذا تجاوزنا 11 بوصة
            // e.HasMorePages false by default
        }
    }
}
