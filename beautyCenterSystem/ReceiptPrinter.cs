using BeautyCenterSystem.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace beautyCenterSystem // تأكد من أن الـ namespace يطابق مشروعك
{
    // كلاس بسيط لتمثيل الخدمة في الفاتورة
    public class InvoiceItem
    {
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
    }

    public class ReceiptPrinter
    {
        // 1. البيانات الثابتة للمركز (يمكنك تغييرها لاحقاً لتأتي من الإعدادات)
        public string CenterName { get; set; } = "صالون التجميل الراقي";
        public string Phone { get; set; } = "رقم الهاتف: 0912345678";
        public Image Logo { get; set; } = null; // سنمرر الصورة إن وجدت
        public string Policy { get; set; } = "الرجاء مراجعة الفاتورة قبل المغادرة.\nالمبالغ المدفوعة غير قابلة للاسترداد.";
        public string SocialMedia { get; set; } = "Insta: @BeautyCenter | Snap: BeautyC";


        private CenterSettings _settings;
        public void SetSettings(CenterSettings settings)
        {
            _settings = settings;
        }

        // 2. البيانات المتغيرة (لكل فاتورة)
        public int InvoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal NetAmount { get; set; }
        public string CashierName { get; set; } // اسم الموظف الذي أصدر الفاتورة


        // دالة بدء الطباعة
        public void PrintReceipt(bool showPreview = false)
        {
            PrintDocument pd = new PrintDocument();

            // إعدادات مقاس الورق الحراري 80mm
            pd.DefaultPageSettings.PaperSize = new PaperSize("Thermal80mm", 285, 0);

            // ربط حدث الرسم (تأكد أن دالة Pd_PrintPage موجودة في الكلاس)
            pd.PrintPage += Pd_PrintPage;

            if (showPreview)
            {
                // عرض نافذة المعاينة قبل الطباعة
                PrintPreviewDialog preview = new PrintPreviewDialog { Document = pd };
                preview.ShowDialog();
            }
            else
            {
                // الطباعة المباشرة فوراً
                // نستخدم StandardPrintController لمنع ظهور نافذة "جاري الطباعة..." الصغيرة
                pd.PrintController = new StandardPrintController();
                pd.Print();
            }
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int y = 10; // نقطة البداية الرأسية
            int width = 270; // العرض الآمن للطباعة (مراعاة للهوامش)

            // إعدادات الخطوط
            Font fontTitle = new Font("Tahoma", 12, FontStyle.Bold);
            Font fontHeader = new Font("Tahoma", 10, FontStyle.Bold);
            Font fontBody = new Font("Tahoma", 9);
            Font fontSmall = new Font("Tahoma", 8);

            // إعدادات المحاذاة للغة العربية (من اليمين لليسار)
            StringFormat formatCenter = new StringFormat { Alignment = StringAlignment.Center, FormatFlags = StringFormatFlags.DirectionRightToLeft };
            StringFormat formatRight = new StringFormat { Alignment = StringAlignment.Near, FormatFlags = StringFormatFlags.DirectionRightToLeft };
            StringFormat formatLeft = new StringFormat { Alignment = StringAlignment.Far, FormatFlags = StringFormatFlags.DirectionRightToLeft };

            // ================= 1. الترويسة (Header) =================

            // رسم الشعار الخاص بالمركز إن وجد
            if (Logo != null)
            {
                int logoWidth = 80; // حجم أصغر قليلاً ليتناسب مع الورق الحراري
                int logoHeight = 80;
                int logoX = (width - logoWidth) / 2;
                g.DrawImage(Logo, logoX, y, logoWidth, logoHeight);
                y += logoHeight + 5;
            }

            // اسم المركز (يتم تعديله من الإعدادات)
            g.DrawString(CenterName, fontTitle, Brushes.Black, new RectangleF(0, y, width, 25), formatCenter);
            y += 25;

            // رقم الهاتف (يتم تعديله من الإعدادات)
            g.DrawString($"هاتف: {Phone}", fontBody, Brushes.Black, new RectangleF(0, y, width, 20), formatCenter);
            y += 20;

            DrawDashedLine(g, y, width);
            y += 10;

            // معلومات الفاتورة والموظف
            g.DrawString($"رقم الفاتورة: {InvoiceNumber}", fontSmall, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
            y += 15;

            // استخدام اسم المستخدم من الجلسة CurrentSession إذا لم يمرر اسم كاشير
            string displayName = !string.IsNullOrEmpty(CashierName) ? CashierName : CurrentSession.Username;
            g.DrawString($"الموظف/ة: {displayName}", fontSmall, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
            y += 15;

            g.DrawString($"التاريخ: {DateTime.Now:yyyy/MM/dd HH:mm}", fontSmall, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
            y += 20;

            // ================= 2. بيانات العميلة =================
            DrawSolidLine(g, y, width);
            y += 5;
            g.DrawString($"العميلة: {CustomerName}", fontHeader, Brushes.Black, new RectangleF(0, y, width, 20), formatRight);
            y += 25;

            // ================= 3. جدول الخدمات =================
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

            // ================= 4. الخلاصة المالية =================
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

            // ================= 5. التذييل (Footer) =================
            DrawDashedLine(g, y, width);
            y += 10;

            // سياسة المركز (تعدل من الإعدادات - الجملة الافتراضية موجودة في الكلاس)
            g.DrawString(Policy, fontSmall, Brushes.Black, new RectangleF(5, y, width - 10, 40), formatCenter);
            y += 40;

            // مواقع التواصل الاجتماعي (تظهر فقط ما تم تعبئته)
            // نستخدم متغير SocialMedia الذي تم تجميعه في الإعدادات
            if (!string.IsNullOrEmpty(SocialMedia))
            {
                g.DrawString(SocialMedia, fontSmall, Brushes.DarkSlateGray, new RectangleF(0, y, width, 30), formatCenter);
                y += 25;
            }

            g.DrawString("*** شكراً لزيارتكم ***", fontHeader, Brushes.Black, new RectangleF(0, y, width, 20), formatCenter);
        }

        // دوال مساعدة لرسم الخطوط الفاصلة بشكل مرتب
        private void DrawDashedLine(Graphics g, int y, int width)
        {
            Pen dashedPen = new Pen(Color.Black, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
            g.DrawLine(dashedPen, 10, y, width - 10, y);
        }

        private void DrawSolidLine(Graphics g, int y, int width)
        {
            g.DrawLine(Pens.Black, 10, y, width - 10, y);
        }
    }
}