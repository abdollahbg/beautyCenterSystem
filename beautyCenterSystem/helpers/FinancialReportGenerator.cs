using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BeautyCenterSystem.Models;

namespace beautyCenterSystem.helpers
{
    public class FinancialReportGenerator
    {
        // الثيم اللوني الاحترافي
        private readonly string PrimaryColor = "#2c3e50"; // أزرق داكن
        private readonly string SuccessColor = "#27ae60"; // أخضر للإيرادات
        private readonly string ExpenseColor = "#e67e22"; // برتقالي للمصروفات
        private readonly string PurchaseColor = "#c0392b"; // أحمر للمشتريات

        public void Generate(string filePath, CenterSettings center, dynamic dashboard,
                             IEnumerable<dynamic> roomData, IEnumerable<dynamic> serviceData,
                             DateTime from, DateTime to)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            // تحويل القيم من ديناميك إلى صريحة فوراً
            decimal totalRev = Convert.ToDecimal(dashboard.TotalRevenue);
            decimal totalExp = Convert.ToDecimal(dashboard.TotalExpenses);
            decimal totalPur = Convert.ToDecimal(dashboard.TotalPurchases);

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);

                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Cairo"));
                    page.ContentFromRightToLeft();

                    page.Header().Element(c => ComposeHeader(c, center, from, to));

                    page.Content().PaddingVertical(10).Column(col =>
                    {
                        // 1. الكروت المالية الأربعة (بعد الفصل)
                        ComposeSummaryCards(col, totalRev, totalExp, totalPur);

                        col.Item().PaddingVertical(10).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                        // 2. الجداول
                        ComposeRoomsSection(col, roomData.ToList());
                        col.Item().PaddingVertical(10).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
                        ComposeServicesSection(col, serviceData.ToList());
                    });

                    page.Footer().Element(ComposeFooter);
                });
            }).GeneratePdf(filePath);
        }

        private void ComposeHeader(IContainer container, CenterSettings center, DateTime from, DateTime to)
        {
            container.PaddingBottom(10).Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(center.CenterName ?? "مركز التجميل").FontSize(20).Bold().FontColor(PrimaryColor);
                    col.Item().Text($"الفترة المالية: {from:yyyy/MM/dd} إلى {to:yyyy/MM/dd}").FontSize(10).SemiBold();
                });

                if (center.LogoBytes != null && center.LogoBytes.Length > 0)
                {
                    row.ConstantItem(60).Image(center.LogoBytes);
                }
            });
        }

        private void ComposeSummaryCards(ColumnDescriptor col, decimal rev, decimal exp, decimal pur)
        {
            decimal net = rev - exp - pur;

            col.Item().Row(row =>
            {
                // كرت الإيرادات
                row.RelativeItem().Component(new FinancialCard("إجمالي الإيرادات", rev, SuccessColor));
                row.ConstantItem(8);

                // كرت المصروفات (فصلناها هنا)
                row.RelativeItem().Component(new FinancialCard("إجمالي المصروفات", exp, ExpenseColor));
                row.ConstantItem(8);

                // كرت المشتريات (فصلناها هنا)
                row.RelativeItem().Component(new FinancialCard("إجمالي المشتريات", pur, PurchaseColor));
                row.ConstantItem(8);

                // كرت صافي الربح
                row.RelativeItem().Component(new FinancialCard("صافي الربح", net, net >= 0 ? PrimaryColor : PurchaseColor));
            });
        }

        private void ComposeRoomsSection(ColumnDescriptor col, List<dynamic> data)
        {
            col.Item().PaddingBottom(5).Text("إيرادات الغرف").FontSize(12).Bold().FontColor(PrimaryColor);

            col.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(3);
                    columns.RelativeColumn(2);
                });

                table.Header(header =>
                {
                    header.Cell().Element(h => HeaderStyle(h, PrimaryColor)).Text("اسم الغرفة");
                    header.Cell().Element(h => HeaderStyle(h, PrimaryColor)).AlignCenter().Text("الإيراد");
                });

                foreach (var item in data)
                {
                    string name = Convert.ToString(item.RoomName);
                    string price = Convert.ToDecimal(item.TotalRevenue).ToString("N0");

                    table.Cell().Element(RowStyle).Text(name);
                    table.Cell().Element(RowStyle).AlignCenter().Text(price).SemiBold();
                }
            });
        }

        private void ComposeServicesSection(ColumnDescriptor col, List<dynamic> data)
        {
            col.Item().PaddingBottom(5).Text("إيرادات الخدمات").FontSize(12).Bold().FontColor(PrimaryColor);

            col.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(4);
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(2);
                });

                table.Header(header =>
                {
                    header.Cell().Element(h => HeaderStyle(h, "#34495e")).Text("اسم الخدمة");
                    header.Cell().Element(h => HeaderStyle(h, "#34495e")).AlignCenter().Text("الطلبات");
                    header.Cell().Element(h => HeaderStyle(h, "#34495e")).AlignCenter().Text("الإيراد");
                });

                foreach (var item in data)
                {
                    string name = Convert.ToString(item.ServiceName);
                    string count = Convert.ToString(item.TimesRequested);
                    string price = Convert.ToDecimal(item.TotalRevenue).ToString("N0");

                    table.Cell().Element(RowStyle).Text(name);
                    table.Cell().Element(RowStyle).AlignCenter().Text(count);
                    table.Cell().Element(RowStyle).AlignCenter().Text(price).SemiBold();
                }
            });
        }

        private void ComposeFooter(IContainer container)
        {
            container.AlignCenter().PaddingTop(15).Text(x =>
            {
                x.Span("تاريخ الاستخراج: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + " | صفحة ");
                x.CurrentPageNumber();
            });
        }

        static IContainer HeaderStyle(IContainer container, string color) =>
            container.Background(color).PaddingVertical(3).PaddingHorizontal(5)
                     .DefaultTextStyle(x => x.SemiBold().FontColor(Colors.White));

        static IContainer RowStyle(IContainer container) =>
            container.BorderBottom(1).BorderColor(Colors.Grey.Lighten3).PaddingVertical(3).PaddingHorizontal(5);
    }

    public class FinancialCard : IComponent
    {
        private string Title { get; }
        private decimal Value { get; }
        private string Color { get; }

        public FinancialCard(string title, decimal value, string color)
        {
            Title = title;
            Value = value;
            Color = color;
        }

        public void Compose(IContainer container)
        {
            container.Background(Colors.White).Border(1).BorderColor(Colors.Grey.Lighten2).Padding(8)
                     .Column(col =>
                     {
                         col.Item().AlignCenter().Text(Title).FontSize(9).FontColor(Colors.Grey.Darken2);
                         col.Item().AlignCenter().Text(Value.ToString("N0")).FontSize(13).Bold().FontColor(Color);
                     });
        }
    }
}