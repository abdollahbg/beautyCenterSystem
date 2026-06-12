using BeautyCenterSystem.Models;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace beautyCenterSystem
{
    public class InvoiceItem
    {
        public string ServiceName { get; set; }
        public string RoomName { get; set; }  // "نوع الخدمة"
        public int Quantity { get; set; } = 1; // "العدد" - افتراضياً 1
        public decimal Price { get; set; }     // سعر الوحدة
        public decimal Total => Quantity * Price; // الإجمالي للعنصر الواحد
    }

    public class ReceiptPrinter
    {
        // ================= 1. الإعدادات والبيانات =================
        public string CenterName { get; set; } = "مركز التجميل";
        public string Phone { get; set; } = "";
        public Image Logo { get; set; } = null;
        public string Policy { get; set; } = "الرجاء مراجعة الفاتورة قبل المغادرة.\nالمبالغ المدفوعة غير قابلة للاسترداد.";

        public string FacebookHandle { get; set; }
        public string InstagramHandle { get; set; }
        public string WhatsAppHandle { get; set; }

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

        public int InvoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public string AppointmentDateTime { get; set; }
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
        public decimal TotalAmount { get; set; } // إجمالي الفاتورة قبل الخصم
        public decimal Discount { get; set; }
        public decimal NetAmount { get; set; }
        public string CashierName { get; set; }

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

        // ================= 3. محرك الرسم المحدث (4 أعمدة) =================
        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int y = 10;
            int width = 270;

            // إعدادات الخطوط
            Font fontTitle = new Font("Tahoma", 11, FontStyle.Bold);
            Font fontHeader = new Font("Tahoma", 8, FontStyle.Bold); // صغرنا الخط قليلاً للجدول
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
            y += 22;
            g.DrawString($"هاتف: {Phone}", fontBody, Brushes.Black, new RectangleF(0, y, width, 20), formatCenter);
            y += 18;

            DrawDashedLine(g, y, width);
            y += 8;

            // --- معلومات الفاتورة ---
            g.DrawString($"رقم الفاتورة: {InvoiceNumber}", fontSmall, Brushes.Black, new RectangleF(0, y, width, 15), formatRight);
            y += 15;
            g.DrawString($"الموظف/ة: {(string.IsNullOrEmpty(CashierName) ? "Admin" : CashierName)}", fontSmall, Brushes.Black, new RectangleF(0, y, width, 15), formatRight);
            y += 15;
            g.DrawString($"التاريخ: {DateTime.Now:yyyy/MM/dd HH:mm}", fontSmall, Brushes.Black, new RectangleF(0, y, width, 15), formatRight);
            y += 18;

            DrawSolidLine(g, y, width);
            y += 5;
            g.DrawString($"العميل/ة: {CustomerName}", fontHeader, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
            y += 25;

            if (!string.IsNullOrEmpty(AppointmentDateTime))
            {
                g.DrawString($"موعد الحجز: {AppointmentDateTime}", fontSmall, Brushes.Black, new RectangleF(0, y, width, 15), formatRight);
                y += 18;
            }

            // --- جدول الخدمات (4 أعمدة) ---
            // تقسيم العرض (270): الخدمة (95) | النوع (75) | العدد (35) | السعر (65)
            float colServiceX = 175; float colServiceW = 95;
            float colTypeX = 100; float colTypeW = 75;
            float colQtyX = 65; float colQtyW = 35;
            float colPriceX = 0; float colPriceW = 65;

            g.DrawString("الخدمة", fontHeader, Brushes.Black, new RectangleF(colServiceX, y, colServiceW, 20), formatRight);
            g.DrawString("نوع الخدمة", fontHeader, Brushes.Black, new RectangleF(colTypeX, y, colTypeW, 20), formatCenter);
            g.DrawString("عدد", fontHeader, Brushes.Black, new RectangleF(colQtyX, y, colQtyW, 20), formatCenter);
            g.DrawString("السعر", fontHeader, Brushes.Black, new RectangleF(colPriceX, y, colPriceW, 20), formatLeft);

            y += 18;
            DrawDashedLine(g, y, width);
            y += 8;

            foreach (var item in Items)
            {
                // 1. اسم الخدمة
                g.DrawString(item.ServiceName, fontBody, Brushes.Black, new RectangleF(colServiceX, y, colServiceW, 20), formatRight);

                // 2. نوع الخدمة (الغرفة)
                g.DrawString(string.IsNullOrEmpty(item.RoomName) ? "-" : item.RoomName, fontBody, Brushes.Black, new RectangleF(colTypeX, y, colTypeW, 20), formatCenter);

                // 3. العدد
                g.DrawString(item.Quantity.ToString(), fontBody, Brushes.Black, new RectangleF(colQtyX, y, colQtyW, 20), formatCenter);

                // 4. السعر الإجمالي للعنصر (العدد * السعر)
                g.DrawString(item.Total.ToString("N2"), fontBody, Brushes.Black, new RectangleF(colPriceX, y, colPriceW, 20), formatLeft);

                y += 18;
            }

            y += 5;
            DrawSolidLine(g, y, width);
            y += 8;

            // --- الخلاصة المالية ---
            g.DrawString("إجمالي الخدمات:", fontBody, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
            g.DrawString(TotalAmount.ToString("N2"), fontBody, Brushes.Black, new RectangleF(0, y, width, 20), formatLeft);
            y += 18;

            if (Discount > 0)
            {
                g.DrawString("الخصم:", fontBody, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
                g.DrawString(Discount.ToString("N2"), fontBody, Brushes.Black, new RectangleF(0, y, width, 20), formatLeft);
                y += 18;
            }

            g.DrawString("الصافي المطلوب:", fontHeader, Brushes.Black, new RectangleF(0, y, width, 25), formatRight);
            g.DrawString(NetAmount.ToString("N2"), fontHeader, Brushes.Black, new RectangleF(0, y, width, 25), formatLeft);
            y += 30;

            // --- التذييل ---
            DrawDashedLine(g, y, width);
            y += 8;
            g.DrawString(Policy, fontSmall, Brushes.Black, new RectangleF(5, y, width - 10, 35), formatCenter);
            y += 40;

            DrawSocialMediaLine(g, IconChar.Facebook, "Facebook", FacebookHandle, fontSmall, ref y, 20);
            DrawSocialMediaLine(g, IconChar.Instagram, "Instagram", InstagramHandle, fontSmall, ref y, 20);
            DrawSocialMediaLine(g, IconChar.Whatsapp, "WhatsApp", WhatsAppHandle, fontSmall, ref y, 20);

            y += 5;
            g.DrawString("*** شكراً لزيارتكم ***", fontHeader, Brushes.Black, new RectangleF(0, y, width, 20), formatCenter);
        }

        private void DrawDashedLine(Graphics g, int y, int width)
        {
            using (Pen dashedPen = new Pen(Color.Black, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
                g.DrawLine(dashedPen, 10, y, width - 10, y);
        }

        private void DrawSolidLine(Graphics g, int y, int width) => g.DrawLine(Pens.Black, 10, y, width - 10, y);

        private void DrawSocialMediaLine(Graphics g, IconChar iconChar, string platformName, string handle, Font font, ref int currentY, int leftOffset)
        {
            if (string.IsNullOrWhiteSpace(handle)) return;
            int iconSize = 15;
            using (Bitmap iconImage = iconChar.ToBitmap(Color.Black, iconSize))
            {
                g.DrawImage(iconImage, leftOffset, currentY);
                g.DrawString($"{platformName}: {handle}", font, Brushes.Black, leftOffset + iconSize + 5, currentY + 2);
            }
            currentY += 20;
        }
    }
}
