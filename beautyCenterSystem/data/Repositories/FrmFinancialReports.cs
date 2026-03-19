using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing; // ضروري جداً للألوان
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using BeautyCenterSystem.Data;
using BeautyCenterSystem.Data.Repositories;
using CartesianChart = LiveCharts.WinForms.CartesianChart;
using System.Configuration;
using beautyCenterSystem.helpers;

namespace beautyCenterSystem.data.Repositories
{
    public partial class FrmFinancialReports : Form
    {
        // 1. تعريف مراجع البيانات والرسوم
        private readonly FinancialReportsRepository _reportsRepo;
        private CartesianChart chartRooms = new CartesianChart();
        private CartesianChart chartServices = new CartesianChart();

        public FrmFinancialReports()
        {
            InitializeComponent();

            // إعداد الـ Repository 
            var dbFactory = new DbConnectionFactory();
            _reportsRepo = new FinancialReportsRepository(dbFactory);

            // تطبيق الثيم العام
            AppTheme.Apply(this);

            // -----------

            // --- تخصيص ألوان المؤشرات المالية ---
            lblTotalRevenue.ForeColor = Color.FromArgb(39, 174, 96);
            lblTotalExpenses.ForeColor = Color.FromArgb(192, 57, 43);
            lblTotalPurchases.ForeColor = Color.FromArgb(211, 84, 0);
            lblNetProfit.ForeColor = Color.FromArgb(44, 62, 80);

            InitializeCustomCharts();
        }

        private void InitializeCustomCharts()
        {
            chartRooms.Dock = DockStyle.Fill;
            tableLayoutPanel2.Controls.Add(chartRooms, 1, 0);

            chartServices.Dock = DockStyle.Fill;
            tableLayoutPanel2.Controls.Add(chartServices, 1, 1);

            ApplyChartStyling();
        }

        private void ApplyChartStyling()
        {
            chartRooms.Background = System.Windows.Media.Brushes.White;
            chartServices.Background = System.Windows.Media.Brushes.White;

            chartRooms.LegendLocation = LegendLocation.Bottom;
            chartServices.LegendLocation = LegendLocation.Bottom;

            chartRooms.AxisY.Add(new Axis
            {
                Title = "المبلغ",
                LabelFormatter = val => val.ToString("N0"),
                Separator = new Separator { Step = 1000 }
            });
            chartRooms.AxisX.Add(new Axis { Title = "الغرف", Labels = new List<string>() });

            chartServices.AxisX.Add(new Axis
            {
                Title = "المبلغ",
                LabelFormatter = val => val.ToString("N0")
            });
            chartServices.AxisY.Add(new Axis { Title = "الخدمات", Labels = new List<string>() });
        }

        // 2. دالة تحديث البيانات الأساسية
        public async Task RefreshDashboardData()
        {
            try
            {
                DateTime from = dtpFrom.Value.Date;
                DateTime to = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

                // أ. جلب بيانات الكروت (Dashboard)
                var dashboard = await _reportsRepo.GetFinancialDashboardAsync(from, to);

                lblTotalRevenue.Text = dashboard.TotalRevenue.ToString("N0");
                lblTotalExpenses.Text = dashboard.TotalExpenses.ToString("N0");
                lblTotalPurchases.Text = dashboard.TotalPurchases.ToString("N0");

                decimal netProfit = dashboard.TotalRevenue - dashboard.TotalExpenses - dashboard.TotalPurchases;
                lblNetProfit.Text = netProfit.ToString("N0");
                lblNetProfit.ForeColor = netProfit >= 0 ? Color.Green : Color.Red;

                // ب. تحديث رسم وجدول الغرف
                var roomData = (await _reportsRepo.GetRevenueByRoomAsync(from, to)).ToList();
                UpdateRoomsChart(roomData);
                BindRoomsGrid(roomData);

                // ج. تحديث رسم وجدول الخدمات
                var serviceData = (await _reportsRepo.GetTopServicesAsync(from, to)).ToList();
                UpdateServicesChart(serviceData);
                BindServicesGrid(serviceData);

                // د. تفاصيل المصروفات
                var expensesData = await _reportsRepo.GetExpenseReportsAsync(from, to);
                BindExpensesGrid(expensesData.ToList());

                // هـ. تفاصيل المشتريات
                var purchasesData = await _reportsRepo.GetPurchaseReportsAsync(from, to);
                BindPurchasesGrid(purchasesData.ToList());

                // و. أرصدة الخزائن
                var safesData = await _reportsRepo.GetCurrentSafesStatusAsync();
                BindSafesGrid(safesData.ToList());

                // ز. تفاصيل مبيعات الخدمات (الإضافة الجديدة)
                var salesData = await _reportsRepo.GetRevenueReportsAsync(from, to);
                BindSalesGrid(salesData.ToList());

                // ح. تقارير الإغلاق اليومي (الإضافة الجديدة)
                var closingData = await _reportsRepo.GetDailyClosuresReportsAsync(from, to);
                BindDailyClosingGrid(closingData.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحديث البيانات: {ex.Message}");
            }
        }

        private void UpdateRoomsChart(IEnumerable<dynamic> data)
        {
            chartRooms.Series.Clear();
            chartRooms.AxisX[0].Labels = data.Select(x => (string)x.RoomName).ToList();

            chartRooms.Series.Add(new ColumnSeries
            {
                Title = "إيراد الغرفة",
                Values = new ChartValues<decimal>(data.Select(x => (decimal)x.TotalRevenue)),
                DataLabels = true,
                Fill = System.Windows.Media.Brushes.MediumSlateBlue
            });
        }

        private void UpdateServicesChart(IEnumerable<dynamic> data)
        {
            chartServices.Series.Clear();
            chartServices.AxisY[0].Labels = data.Select(x => (string)x.ServiceName).ToList();

            chartServices.Series.Add(new RowSeries
            {
                Title = "إيراد الخدمة",
                Values = new ChartValues<decimal>(data.Select(x => (decimal)x.TotalRevenue)),
                DataLabels = true,
                Fill = System.Windows.Media.Brushes.PaleVioletRed
            });
        }

        // --- دوال ربط الجداول (Grids) ---

        private void BindRoomsGrid(object data)
        {
            dgvRoomsSummary.DataSource = null;
            dgvRoomsSummary.Columns.Clear();
            dgvRoomsSummary.AutoGenerateColumns = false;
            dgvRoomsSummary.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RoomName", HeaderText = "اسم الغرفة", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvRoomsSummary.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalRevenue", HeaderText = "إجمالي الإيرادات", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvRoomsSummary.DataSource = data;
        }

        private void BindServicesGrid(object data)
        {
            dgvServicesSummary.DataSource = null;
            dgvServicesSummary.Columns.Clear();
            dgvServicesSummary.AutoGenerateColumns = false;
            dgvServicesSummary.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ServiceName", HeaderText = "اسم الخدمة", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvServicesSummary.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalRevenue", HeaderText = "إجمالي الإيرادات", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvServicesSummary.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TimesRequested", HeaderText = "عدد الطلبات" });
            dgvServicesSummary.DataSource = data;
        }

        private void BindExpensesGrid(object data)
        {
            dgvExpensesDetails.DataSource = null;
            dgvExpensesDetails.Columns.Clear();
            dgvExpensesDetails.AutoGenerateColumns = false;
            dgvExpensesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ExpenseName", HeaderText = "بيان المصروف", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvExpensesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = "التصنيف" });
            dgvExpensesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Amount", HeaderText = "المبلغ", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvExpensesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ExpenseDate", HeaderText = "التاريخ" });
            dgvExpensesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaidFromSafe", HeaderText = "دُفع من" });
            dgvExpensesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IssuedBy", HeaderText = "بواسطة" });
            dgvExpensesDetails.DataSource = data;
        }

        private void BindPurchasesGrid(object data)
        {
            dgvPurchasesDetails.DataSource = null;
            dgvPurchasesDetails.Columns.Clear();
            dgvPurchasesDetails.AutoGenerateColumns = false;
            dgvPurchasesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SupplierName", HeaderText = "المورد", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvPurchasesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalAmount", HeaderText = "الإجمالي", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvPurchasesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PurchaseDate", HeaderText = "التاريخ" });
            dgvPurchasesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaidFromSafe", HeaderText = "دُفع من" });
            dgvPurchasesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IssuedBy", HeaderText = "بواسطة" });
            dgvPurchasesDetails.DataSource = data;
        }

        private void BindSafesGrid(object data)
        {
            dgvSafesBalances.DataSource = null;
            dgvSafesBalances.Columns.Clear();
            dgvSafesBalances.AutoGenerateColumns = false;
            dgvSafesBalances.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SafeName", HeaderText = "اسم الخزنة", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvSafesBalances.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Balance", HeaderText = "الرصيد الحالي", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvSafesBalances.DataSource = data;
        }

        private void BindSalesGrid(object data)
        {
            dgvSalesDetails.DataSource = null;
            dgvSalesDetails.Columns.Clear();
            dgvSalesDetails.AutoGenerateColumns = false;
            dgvSalesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CustomerName", HeaderText = "اسم العميلة", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvSalesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AmountPaid", HeaderText = "المبلغ المدفوع", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvSalesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Discount", HeaderText = "الخصم" });
            dgvSalesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaymentMethod", HeaderText = "طريقة الدفع" });
            dgvSalesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaymentDate", HeaderText = "التاريخ" });
            dgvSalesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SafeName", HeaderText = "الخزنة" });
            dgvSalesDetails.DataSource = data;
        }

        private void BindDailyClosingGrid(object data)
        {
            dgvDailyClosing.DataSource = null;
            dgvDailyClosing.Columns.Clear();
            dgvDailyClosing.AutoGenerateColumns = false;
            dgvDailyClosing.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ClosureDate", HeaderText = "تاريخ الإغلاق", DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd HH:mm" } });
            dgvDailyClosing.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalCashSystem", HeaderText = "كاش (نظام)", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvDailyClosing.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalCardSystem", HeaderText = "بطاقة (نظام)", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvDailyClosing.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ActualCashHand", HeaderText = "العد الفعلي", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvDailyClosing.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Difference", HeaderText = "الفرق", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvDailyClosing.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Notes", HeaderText = "ملاحظات", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvDailyClosing.DataSource = data;
        }

        // حدث زر التحديث
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            await RefreshDashboardData();
            btnRefresh.Enabled = true;
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. إظهار مؤشر الانتظار (اختياري لراحة المستخدم)
                this.Cursor = Cursors.WaitCursor;
                btnRefresh.Enabled = false; // تعطيل أزرار التحكم مؤقتاً

                // 2. جلب إعدادات المركز (الاسم، الهاتف، اللوغو)
                var settingsRepo = new SettingsRepository(new DbConnectionFactory());
                var centerSettings = await settingsRepo.GetSettingsAsync();

                // 3. تحديد الفترة الزمنية المختارة في الواجهة
                DateTime fromDate = dtpFrom.Value.Date;
                DateTime toDate = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

                // 4. جلب البيانات المالية من الـ Repository (نفس البيانات المعروضة في الجداول)
                var dashboardData = await _reportsRepo.GetFinancialDashboardAsync(fromDate, toDate);
                var roomsData = (await _reportsRepo.GetRevenueByRoomAsync(fromDate, toDate)).ToList();
                var servicesData = (await _reportsRepo.GetTopServicesAsync(fromDate, toDate)).ToList();

                // 5. تجهيز مسار حفظ ملف الـ PDF (في المجلد المؤقت للنظام)
                string fileName = $"Financial_Report_{DateTime.Now:yyyy_MM_dd___HHmm}.pdf";
                string filePath = Path.Combine(Path.GetTempPath(), fileName);

                // 6. استدعاء المولد لتوليد الملف
                var reportGenerator = new FinancialReportGenerator();
                reportGenerator.Generate(
                    filePath,
                    centerSettings,
                    dashboardData,
                    roomsData,
                    servicesData,
                    fromDate,
                    toDate
                );

                // 7. فتح الملف للمعاينة (سيفتح في المتصفح أو قارئ PDF الافتراضي)
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath)
                {
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء إعداد التقرير: {ex.Message}", "خطأ في الطباعة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 8. إعادة المؤشر لحالته الطبيعية
                this.Cursor = Cursors.Default;
                btnRefresh.Enabled = true;
            }
        }
    }
}