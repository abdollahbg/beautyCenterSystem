using System;
using System.Collections.Generic;
using System.Data;
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
            // --- تخصيص ألوان المؤشرات المالية فقط ---

            // 1. إجمالي الإيرادات (أخضر احترافي)
            lblTotalRevenue.ForeColor = Color.FromArgb(39, 174, 96);

            // 2. إجمالي المصروفات (أحمر هادئ)
            lblTotalExpenses.ForeColor = Color.FromArgb(192, 57, 43);

            // 3. إجمالي المشتريات (لون ذهبي/برتقالي لتمييزها عن المصاريف العامة)
            lblTotalPurchases.ForeColor = Color.FromArgb(211, 84, 0);

            // 4. صافي الربح (لون افتراضي رمادي غامق - سيتغير لاحقاً عند جلب البيانات)
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

                lblNetProfit.ForeColor = netProfit >= 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;

                // ب. تحديث رسم وجدول الغرف
                var roomData = (await _reportsRepo.GetRevenueByRoomAsync(from, to)).ToList();
                UpdateRoomsChart(roomData);
                BindRoomsGrid(roomData); // استدعاء دالة الربط اليدوي

                // ج. تحديث رسم وجدول الخدمات
                var serviceData = (await _reportsRepo.GetTopServicesAsync(from, to)).ToList();
                UpdateServicesChart(serviceData);
                BindServicesGrid(serviceData); // استدعاء دالة الربط اليدوي

                // أ. تفاصيل المصروفات
                var expensesData = await _reportsRepo.GetExpenseReportsAsync(from, to);
                BindExpensesGrid(expensesData.ToList());

                // ب. تفاصيل المشتريات
                var purchasesData = await _reportsRepo.GetPurchaseReportsAsync(from, to);
                BindPurchasesGrid(purchasesData.ToList());

                // ج. أرصدة الخزائن
                var safesData = await _reportsRepo.GetCurrentSafesStatusAsync();
                BindSafesGrid(safesData.ToList());
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

        // --- دالة ربط جدول الغرف لمنع التكرار والتعريب ---
        private void BindRoomsGrid(object data)
        {
            dgvRoomsSummary.DataSource = null;
            dgvRoomsSummary.Columns.Clear();
            dgvRoomsSummary.AutoGenerateColumns = false; // منع التكرار الإنجليزي

            dgvRoomsSummary.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoomName", // يجب أن يطابق اسم الخاصية في الـ Repository
                HeaderText = "اسم الغرفة",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvRoomsSummary.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalRevenue",
                HeaderText = "إجمالي الإيرادات",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvRoomsSummary.DataSource = data;
        }

        // --- دالة ربط جدول الخدمات لمنع التكرار والتعريب ---
        private void BindServicesGrid(object data)
        {
            dgvServicesSummary.DataSource = null;
            dgvServicesSummary.Columns.Clear();
            dgvServicesSummary.AutoGenerateColumns = false; // منع التكرار الإنجليزي

            dgvServicesSummary.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ServiceName",
                HeaderText = "اسم الخدمة",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvServicesSummary.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalRevenue",
                HeaderText = "إجمالي الإيرادات",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvServicesSummary.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TimesRequested", // تأكد من مطابقة الاسم البرمجي (TimesRequested)
                HeaderText = "عدد الطلبات"
            });

            dgvServicesSummary.DataSource = data;
        }

        // حدث زر التحديث
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            await RefreshDashboardData();
            btnRefresh.Enabled = true;
        }
        // --- تاب تفاصيل المصروفات ---
        private void BindExpensesGrid(object data)
        {
            dgvExpensesDetails.DataSource = null;
            dgvExpensesDetails.Columns.Clear();
            dgvExpensesDetails.AutoGenerateColumns = false;

            dgvExpensesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ExpenseName", HeaderText = "بيان المصروف", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvExpensesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = "التصنيف" });
            dgvExpensesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Amount", HeaderText = "المبلغ" });
            dgvExpensesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ExpenseDate", HeaderText = "التاريخ" });
            dgvExpensesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaidFromSafe", HeaderText = "دُفع من" });
            dgvExpensesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IssuedBy", HeaderText = "بواسطة" });

            dgvExpensesDetails.DataSource = data;
        }

        // --- تاب تفاصيل المشتريات ---
        private void BindPurchasesGrid(object data)
        {
            dgvPurchasesDetails.DataSource = null;
            dgvPurchasesDetails.Columns.Clear();
            dgvPurchasesDetails.AutoGenerateColumns = false;

            dgvPurchasesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SupplierName", HeaderText = "المورد", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvPurchasesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalAmount", HeaderText = "الإجمالي" });
            dgvPurchasesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PurchaseDate", HeaderText = "التاريخ" });
            dgvPurchasesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaidFromSafe", HeaderText = "دُفع من" });
            dgvPurchasesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IssuedBy", HeaderText = "بواسطة" });

            dgvPurchasesDetails.DataSource = data;
        }

        // --- تاب أرصدة الخزائن ---
        private void BindSafesGrid(object data)
        {
            dgvSafesBalances.DataSource = null;
            dgvSafesBalances.Columns.Clear();
            dgvSafesBalances.AutoGenerateColumns = false;

            dgvSafesBalances.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SafeName", HeaderText = "اسم الخزنة", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvSafesBalances.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Balance", HeaderText = "الرصيد الحالي" });

            dgvSafesBalances.DataSource = data;
        }

    }
}