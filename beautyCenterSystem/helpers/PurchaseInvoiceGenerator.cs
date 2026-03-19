using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using BeautyCenterSystem.Models;

namespace beautyCenterSystem.helpers
{
    public class PurchaseInvoiceGenerator
    {
        private readonly string PrimaryColor = "#2c3e50"; // أزرق داكن رسمي
        private readonly string AccentColor = "#f8f9fa";  // خلفية رمادية فاتحة جداً
        private readonly string TextColor = "#34495e";

        public void Generate(string filePath, CenterSettings center, dynamic invoice, IEnumerable<dynamic> details)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            // تحويل القيم الأساسية لتجنب خطأ Dynamic Dispatch
            string supplierName = Convert.ToString(invoice.SupplierName) ?? "غير محدد";
            string invoiceId = Convert.ToString(invoice.InvoiceID);
            DateTime purchaseDate = Convert.ToDateTime(invoice.PurchaseDate);
            string notes = Convert.ToString(invoice.Notes);
            decimal totalAmount = Convert.ToDecimal(invoice.TotalAmount);

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    // الإعدادات الجديدة لنظام A4
                    page.Size(PageSizes.A4);
                    page.Margin(1.5f, Unit.Centimetre);
                    page.PageColor(Colors.White);

                    page.DefaultTextStyle(x => x.FontSize(11).FontFamily("Cairo").FontColor(TextColor));
                    page.ContentFromRightToLeft();

                    // 1. الرأس (Header)
                    page.Header().Element(c => ComposeHeader(c, center, invoiceId, purchaseDate));

                    // 2. المحتوى (Content)
                    page.Content().PaddingVertical(20).Column(col =>
                    {
                        ComposeInvoiceInfo(col, supplierName, notes);

                        col.Item().PaddingVertical(10).LineHorizontal(1.5f).LineColor(PrimaryColor);

                        // الجدول يأخذ المساحة المتاحة
                        col.Item().Element(c => ComposeTable(c, details.ToList()));

                        // الإجمالي في الأسفل
                        ComposeTotal(col, totalAmount);

                        // كلمة ختامية
                        col.Item().PaddingTop(50).AlignCenter().Text("قسم المشتريات - إدارة المركز").FontSize(10).Italic().FontColor(Colors.Grey.Medium);
                    });

                    // 3. التذييل (Footer) - الآن يحتوي على بيانات التواصل
                    page.Footer().Element(c => ComposeFooter(c, center));
                });
            }).GeneratePdf(filePath);
        }

        private void ComposeHeader(IContainer container, CenterSettings center, string invoiceId, DateTime date)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(center.CenterName ?? "مركز التجميل").FontSize(24).Bold().FontColor(PrimaryColor);
                    col.Item().PaddingTop(5).Text($"فاتورة مشتريات رقم: {invoiceId}").FontSize(14).SemiBold();
                    col.Item().Text($"تاريخ الإصدار: {date:yyyy/MM/dd HH:mm}").FontSize(10).FontColor(Colors.Grey.Darken2);
                });

                if (center.LogoBytes != null && center.LogoBytes.Length > 0)
                {
                    row.ConstantItem(80).Image(center.LogoBytes);
                }
            });
        }

        private void ComposeInvoiceInfo(ColumnDescriptor col, string supplierName, string notes)
        {
            col.Item().Row(row =>
            {
                row.RelativeItem().Column(c =>
                {
                    c.Item().Text("جهة التوريد (المورد):").FontSize(10).SemiBold().FontColor(PrimaryColor);
                    c.Item().PaddingTop(2).Text(supplierName).FontSize(13).Bold();
                });

                if (!string.IsNullOrWhiteSpace(notes))
                {
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text("ملاحظات إضافية:").FontSize(10).SemiBold().FontColor(PrimaryColor);
                        c.Item().PaddingTop(2).Text(notes).FontSize(10);
                    });
                }
            });
        }

        private void ComposeTable(IContainer container, List<dynamic> details)
        {
            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(35);  // م
                    columns.RelativeColumn(5);   // اسم المادة
                    columns.RelativeColumn(2);   // الكمية
                    columns.RelativeColumn(2);   // سعر الوحدة
                    columns.RelativeColumn(2);   // الإجمالي الفرعي
                });

                table.Header(header =>
                {
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("#");
                    header.Cell().Element(HeaderStyle).Text("الوصف / الصنف");
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("الكمية");
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("سعر الوحدة");
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("الإجمالي");
                });

                int index = 1;
                foreach (var item in details)
                {
                    string name = Convert.ToString(item.MaterialName);
                    string qty = Convert.ToString(item.Quantity);
                    string price = Convert.ToDecimal(item.UnitPrice).ToString("N2");
                    string total = Convert.ToDecimal(item.TotalAmount).ToString("N2");

                    table.Cell().Element(RowStyle).AlignCenter().Text(index.ToString());
                    table.Cell().Element(RowStyle).Text(name);
                    table.Cell().Element(RowStyle).AlignCenter().Text(qty);
                    table.Cell().Element(RowStyle).AlignCenter().Text(price);
                    table.Cell().Element(RowStyle).AlignCenter().Text(total).Bold();

                    index++;
                }
            });
        }

        private void ComposeTotal(ColumnDescriptor col, decimal totalAmount)
        {
            col.Item().AlignLeft().PaddingTop(10).MinWidth(200).Container()
                .Background(AccentColor).Border(1).BorderColor(Colors.Grey.Lighten2).Padding(10)
                .Row(row =>
                {
                    row.RelativeItem().Text("المبلغ الإجمالي الكلي:").FontSize(12).SemiBold();
                    row.AutoItem().Text(totalAmount.ToString("N2") + " د.ل").FontSize(12).Bold().FontColor(PrimaryColor);
                });
        }

        private void ComposeFooter(IContainer container, CenterSettings center)
        {
            container.Column(col =>
            {
                col.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
                col.Item().PaddingTop(5).Row(row =>
                {
                    // بيانات التواصل من الإعدادات
                    row.RelativeItem().Text(x =>
                    {
                        x.Span("هاتف: ").SemiBold();
                        x.Span(center.Phone ?? "-");
                        x.Span("  |  واتساب: ").SemiBold();
                        x.Span(center.WhatsApp ?? "-");
                    });

                    row.RelativeItem().AlignLeft().Text(x =>
                    {
                        x.Span("صفحة ");
                        x.CurrentPageNumber();
                        x.Span(" من ");
                        x.TotalPages();
                    });
                });

             
            });
        }

        private IContainer HeaderStyle(IContainer container) =>
            container.Background(PrimaryColor).PaddingVertical(6).PaddingHorizontal(5)
                     .DefaultTextStyle(x => x.SemiBold().FontColor(Colors.White).FontSize(10));

        private IContainer RowStyle(IContainer container) =>
            container.BorderBottom(1).BorderColor(Colors.Grey.Lighten4).PaddingVertical(6).PaddingHorizontal(5)
                     .DefaultTextStyle(x => x.FontSize(10));
    }
}