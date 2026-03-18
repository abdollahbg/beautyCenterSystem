using BeautyCenterSystem.Models;
using FontAwesome.Sharp; // ضروري للتعامل مع الأيقونات
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace beautyCenterSystem
{
    // كلاس بسيط لتمثيل الخدمة في الفاتورة
    public class InvoiceItem
    {
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
    }

    public class ReceiptPrinter
    {
        // ================= 1. البيانات الثابتة للمركز =================
        public string CenterName { get; set; } = "صالون التجميل الراقي";
        public string Phone { get; set; } = "رقم الهاتف: 0912345678";
        public Image Logo { get; set; } = null;
        public string Policy { get; set; } = "الرجاء مراجعة الفاتورة قبل المغادرة.\nالمبالغ المدفوعة غير قابلة للاسترداد.";

        public string FacebookHandle { get; set; }
        public string InstagramHandle { get; set; }
        public string WhatsAppHandle { get; set; }

        private CenterSettings _settings;
        public void SetSettings(CenterSettings settings)
        {
            _settings = settings;
        }

        // ================= 2. البيانات المتغيرة =================
        public int InvoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal NetAmount { get; set; }
        public string CashierName { get; set; }

        // ================= 3. دالة بدء الطباعة =================
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

        // ================= 4. دالة الرسم الأساسية =================
        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int y = 10;
            int width = 270;

            // إعدادات الخطوط
            Font fontTitle = new Font("Tahoma", 12, FontStyle.Bold);
            Font fontHeader = new Font("Tahoma", 10, FontStyle.Bold);
            Font fontBody = new Font("Tahoma", 9);
            Font fontSmall = new Font("Tahoma", 8);

            StringFormat formatCenter = new StringFormat { Alignment = StringAlignment.Center, FormatFlags = StringFormatFlags.DirectionRightToLeft };
            StringFormat formatRight = new StringFormat { Alignment = StringAlignment.Near, FormatFlags = StringFormatFlags.DirectionRightToLeft };
            StringFormat formatLeft = new StringFormat { Alignment = StringAlignment.Far, FormatFlags = StringFormatFlags.DirectionRightToLeft };

            // --- الترويسة (Header) ---
            if (Logo != null)
            {
                int logoWidth = 80;
                int logoHeight = 80;
                int logoX = (width - logoWidth) / 2;
                g.DrawImage(Logo, logoX, y, logoWidth, logoHeight);
                y += logoHeight + 5;
            }

            g.DrawString(CenterName, fontTitle, Brushes.Black, new RectangleF(0, y, width, 25), formatCenter);
            y += 25;

            g.DrawString($"هاتف: {Phone}", fontBody, Brushes.Black, new RectangleF(0, y, width, 20), formatCenter);
            y += 20;

            DrawDashedLine(g, y, width);
            y += 10;

            g.DrawString($"رقم الفاتورة: {InvoiceNumber}", fontSmall, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
            y += 15;

            string displayName = !string.IsNullOrEmpty(CashierName) ? CashierName : "Admin";
            g.DrawString($"الموظف/ة: {displayName}", fontSmall, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
            y += 15;

            g.DrawString($"التاريخ: {DateTime.Now:yyyy/MM/dd HH:mm}", fontSmall, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
            y += 20;

            // --- بيانات العميلة ---
            DrawSolidLine(g, y, width);
            y += 5;
            g.DrawString($"العميل/ة: {CustomerName}", fontHeader, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
            y += 25;

            // --- جدول الخدمات ---
            g.DrawString("الخدمة", fontHeader, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
            g.DrawString("السعر", fontHeader, Brushes.Black, new RectangleF(0, y, width, 20), formatLeft);
            y += 20;
            DrawDashedLine(g, y, width);
            y += 10;

            foreach (var item in Items)
            {
                g.DrawString(item.ServiceName, fontBody, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
                g.DrawString(item.Price.ToString("N2"), fontBody, Brushes.Black, new RectangleF(0, y, width, 20), formatLeft);
                y += 20;
            }

            DrawSolidLine(g, y, width);
            y += 10;

            // --- الخلاصة المالية ---
            g.DrawString("إجمالي الخدمات:", fontBody, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
            g.DrawString(TotalAmount.ToString("N2"), fontBody, Brushes.Black, new RectangleF(0, y, width, 20), formatLeft);
            y += 20;

            if (Discount > 0)
            {
                g.DrawString("الخصم:", fontBody, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
                g.DrawString(Discount.ToString("N2"), fontBody, Brushes.Black, new RectangleF(0, y, width, 20), formatLeft);
                y += 20;
            }

            g.DrawString("الصافي المطلوب:", fontHeader, Brushes.Black, new RectangleF(0, y, width, 25), formatRight);
            g.DrawString(NetAmount.ToString("N2"), fontHeader, Brushes.Black, new RectangleF(0, y, width, 25), formatLeft);
            y += 35;

            // --- التذييل (Footer) ---
            DrawDashedLine(g, y, width);
            y += 10;

            g.DrawString(Policy, fontSmall, Brushes.Black, new RectangleF(5, y, width - 10, 40), formatCenter);
            y += 45;

            // رسم السوشيال ميديا (محاذاة لليسار مع توضيح اسم الموقع)
            // نستخدم إزاحة 20 بكسل من اليسار لتبدو مرتبة
            DrawSocialMediaLine(g, IconChar.Facebook, "Facebook", FacebookHandle, fontSmall, ref y, 20);
            DrawSocialMediaLine(g, IconChar.Instagram, "Instagram", InstagramHandle, fontSmall, ref y, 20);
            DrawSocialMediaLine(g, IconChar.Whatsapp, "WhatsApp", WhatsAppHandle, fontSmall, ref y, 20);

            y += 10;
            g.DrawString("*** شكراً لزيارتكم ***", fontHeader, Brushes.Black, new RectangleF(0, y, width, 20), formatCenter);
        }

        // ================= 5. دوال مساعدة للرسم =================
        private void DrawDashedLine(Graphics g, int y, int width)
        {
            Pen dashedPen = new Pen(Color.Black, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
            g.DrawLine(dashedPen, 10, y, width - 10, y);
        }

        private void DrawSolidLine(Graphics g, int y, int width)
        {
            g.DrawLine(Pens.Black, 10, y, width - 10, y);
        }

        // الدالة المعدلة: رسم الأيقونة (أكبر قليلاً) + اسم المنصة + المعرف، بمحاذاة اليسار
        private void DrawSocialMediaLine(Graphics g, IconChar iconChar, string platformName, string handle, Font font, ref int currentY, int leftOffset)
        {
            if (string.IsNullOrWhiteSpace(handle)) return;

            int iconSize = 18; // تكبير الشعار قليلاً (كان 14)

            using (Bitmap iconImage = iconChar.ToBitmap(Color.Black, iconSize))
            {
                // رسم الأيقونة في جهة اليسار
                g.DrawImage(iconImage, leftOffset, currentY);

                // النص المراد كتابته (اسم المنصة + المعرف)
                string fullText = $"{platformName}: {handle}";

                // رسم النص بجانب الأيقونة مباشرة (إزاحة iconSize + 5 بكسل)
                g.DrawString(fullText, font, Brushes.Black, leftOffset + iconSize + 5, currentY + 2);
            }

            currentY += 25; // مسافة عمودية أكبر قليلاً بين الأسطر لتفادي الالتصاق
        }
    }
}