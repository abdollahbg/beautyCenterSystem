using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using BeautyCenterSystem.Data;
using BeautyCenterSystem.Data.Repositories;
using CartesianChart = LiveCharts.WinForms.CartesianChart;
using beautyCenterSystem.helpers;

namespace beautyCenterSystem.data.Repositories
{
    public partial class FrmFinancialReports : Form
    {
        private readonly FinancialReportsRepository _reportsRepo;
        private CartesianChart chartRooms = new CartesianChart();
        private CartesianChart chartServices = new CartesianChart();

        public FrmFinancialReports()
        {
            InitializeComponent();

            // إعداد المستودع
            var dbFactory = new DbConnectionFactory();
            _reportsRepo = new FinancialReportsRepository(dbFactory);

            // تطبيق الثيم العام
            AppTheme.Apply(this);

            // تخصيص ألوان الكروت العلوية
            lblTotalRevenue.ForeColor = Color.FromArgb(39, 174, 96);   // أخضر
            lblTotalExpenses.ForeColor = Color.FromArgb(192, 57, 43);  // أحمر
            lblTotalPurchases.ForeColor = Color.FromArgb(211, 84, 0); // برتقالي
            lblNetProfit.ForeColor = Color.FromArgb(44, 62, 80);      // رمادي

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

            chartRooms.AxisY.Add(new Axis { Title = "المبلغ", LabelFormatter = val => val.ToString("N0") });
            chartRooms.AxisX.Add(new Axis { Title = "الغرف", Labels = new List<string>() });

            chartServices.AxisX.Add(new Axis { Title = "المبلغ", LabelFormatter = val => val.ToString("N0") });
            chartServices.AxisY.Add(new Axis { Title = "الخدمات", Labels = new List<string>() });
        }

        public async Task RefreshDashboardData()
        {
            try
            {
                DateTime from = dtpFrom.Value.Date;
                DateTime to = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

                // 1. تحديث الكروت المالية
                var dashboard = await _reportsRepo.GetFinancialDashboardAsync(from, to);
                lblTotalRevenue.Text = dashboard.TotalRevenue.ToString("N0");
                lblTotalExpenses.Text = dashboard.TotalExpenses.ToString("N0");
                lblTotalPurchases.Text = dashboard.TotalPurchases.ToString("N0");

                decimal netProfit = dashboard.TotalRevenue - dashboard.TotalExpenses - dashboard.TotalPurchases;
                lblNetProfit.Text = netProfit.ToString("N0");
                lblNetProfit.ForeColor = netProfit >= 0 ? Color.Green : Color.Red;

                // 2. تحديث الرسوم البيانية وجداول الملخص
                var roomData = (await _reportsRepo.GetRevenueByRoomAsync(from, to)).ToList();
                UpdateRoomsChart(roomData);
                BindRoomsGrid(roomData);

                var serviceData = (await _reportsRepo.GetTopServicesAsync(from, to)).ToList();
                UpdateServicesChart(serviceData);
                BindServicesGrid(serviceData);

                // 3. ربط التبويبات (تعريف يدوي لمنع التكرار)
                BindSalesGrid(await _reportsRepo.GetRevenueReportsAsync(from, to));
                BindExpensesGrid(await _reportsRepo.GetExpenseReportsAsync(from, to));
                BindPurchasesGrid(await _reportsRepo.GetPurchaseReportsAsync(from, to));
                BindSafesGrid(await _reportsRepo.GetCurrentSafesStatusAsync());
                BindDailyClosingGrid(await _reportsRepo.GetDailyClosuresReportsAsync(from, to));

                // 4. ربط التبويبات الجديدة
                BindEmployeeExpensesGrid(await _reportsRepo.GetEmployeeExpensesAsync(from, to));
                BindCafeteriaGrid(await _reportsRepo.GetCafeteriaReportsAsync(from, to));
                BindEmployeeDetailsGrid(await _reportsRepo.GetEmployeePerformanceAsync(from, to));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء جلب البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- دوال الربط (Data Binding) المصححة ---

        private void ClearAndSetupGrid(DataGridView dgv)
        {
            dgv.DataSource = null;
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = false;
        }

        private void BindSalesGrid(IEnumerable<dynamic> data)
        {
            ClearAndSetupGrid(dgvSalesDetails);
            dgvSalesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CustomerName", HeaderText = "اسم العميلة", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvSalesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AmountPaid", HeaderText = "المبلغ المدفوع", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvSalesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaymentMethod", HeaderText = "طريقة الدفع" });
            dgvSalesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaymentDate", HeaderText = "التاريخ" });
            dgvSalesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SafeName", HeaderText = "الخزنة" });
            dgvSalesDetails.DataSource = data.ToList();
        }

        private void BindExpensesGrid(IEnumerable<dynamic> data)
        {
            ClearAndSetupGrid(dgvExpensesDetails);
            dgvExpensesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ExpenseName", HeaderText = "بيان المصروف", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvExpensesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = "التصنيف" });
            dgvExpensesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Amount", HeaderText = "المبلغ", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvExpensesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ExpenseDate", HeaderText = "التاريخ" });
            dgvExpensesDetails.DataSource = data.ToList();
        }

        private void BindPurchasesGrid(IEnumerable<dynamic> data)
        {
            ClearAndSetupGrid(dgvPurchasesDetails);
            dgvPurchasesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SupplierName", HeaderText = "المورد", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvPurchasesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalAmount", HeaderText = "الإجمالي", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvPurchasesDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PurchaseDate", HeaderText = "التاريخ" });
            dgvPurchasesDetails.DataSource = data.ToList();
        }

        private void BindSafesGrid(IEnumerable<dynamic> data)
        {
            ClearAndSetupGrid(dgvSafesBalances);
            dgvSafesBalances.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SafeName", HeaderText = "اسم الخزنة", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvSafesBalances.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Balance", HeaderText = "الرصيد الحالي", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvSafesBalances.DataSource = data.ToList();
        }

        private void BindDailyClosingGrid(IEnumerable<dynamic> data)
        {
            ClearAndSetupGrid(dgvDailyClosing);
            dgvDailyClosing.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ClosureDate", HeaderText = "التاريخ" });
            dgvDailyClosing.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ActualCashHand", HeaderText = "العد الفعلي", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvDailyClosing.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Difference", HeaderText = "الفرق" });
            dgvDailyClosing.DataSource = data.ToList();
        }

        private void BindEmployeeExpensesGrid(IEnumerable<dynamic> data)
        {
            ClearAndSetupGrid(dgvEmployeeExpenses);
            dgvEmployeeExpenses.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EmployeeName", HeaderText = "الموظفة", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvEmployeeExpenses.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ExpenseAmount", HeaderText = "المبلغ", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvEmployeeExpenses.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ExpenseDate", HeaderText = "التاريخ" });
            dgvEmployeeExpenses.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Notes", HeaderText = "ملاحظات" });
            dgvEmployeeExpenses.DataSource = data.ToList();
        }

        private void BindCafeteriaGrid(IEnumerable<dynamic> data)
        {
            ClearAndSetupGrid(dgvCafeteriaRevenues);
            dgvCafeteriaRevenues.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ItemName", HeaderText = "الصنف", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCafeteriaRevenues.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalRevenue", HeaderText = "الإيراد", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvCafeteriaRevenues.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "QuantitySold", HeaderText = "الكمية" });
            dgvCafeteriaRevenues.DataSource = data.ToList();
        }

        private void BindEmployeeDetailsGrid(IEnumerable<dynamic> data)
        {
            ClearAndSetupGrid(dgvEmployeeDetails);

            // اسم الموظفة
            dgvEmployeeDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EmployeeName",
                HeaderText = "الموظفة",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // إجمالي العمل (الدخل الذي أدخلته للمركز)
            dgvEmployeeDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalServicesRevenue",
                HeaderText = "إجمالي العمل",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            // إجمالي العمولات المستحقة (التي حققتها بناءً على نسبتها)
            dgvEmployeeDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalEarnedCommissions",
                HeaderText = "العمولة المستحقة",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            // إجمالي ما استلمته فعلياً (النسب التي صرفت لها من الخزنة)
            dgvEmployeeDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalActuallyPaid",
                HeaderText = "المبالغ المستلمة",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvEmployeeDetails.DataSource = data.ToList();
        }

        private void BindRoomsGrid(object data) { ClearAndSetupGrid(dgvRoomsSummary); dgvRoomsSummary.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RoomName", HeaderText = "الغرفة", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill }); dgvRoomsSummary.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalRevenue", HeaderText = "الإيراد", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } }); dgvRoomsSummary.DataSource = data; }
        private void BindServicesGrid(object data) { ClearAndSetupGrid(dgvServicesSummary); dgvServicesSummary.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ServiceName", HeaderText = "الخدمة", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill }); dgvServicesSummary.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalRevenue", HeaderText = "الإيراد", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } }); dgvServicesSummary.DataSource = data; }

        // --- تحديث الرسوم البيانية ---
        private void UpdateRoomsChart(IEnumerable<dynamic> data)
        {
            chartRooms.Series.Clear();
            var list = data.ToList();
            chartRooms.AxisX[0].Labels = list.Select(x => (string)x.RoomName).ToList();
            chartRooms.Series.Add(new ColumnSeries { Title = "إيراد الغرفة", Values = new ChartValues<decimal>(list.Select(x => (decimal)x.TotalRevenue)), Fill = System.Windows.Media.Brushes.MediumSlateBlue, DataLabels = true });
        }

        private void UpdateServicesChart(IEnumerable<dynamic> data)
        {
            chartServices.Series.Clear();
            var list = data.ToList();
            chartServices.AxisY[0].Labels = list.Select(x => (string)x.ServiceName).ToList();
            chartServices.Series.Add(new RowSeries { Title = "إيراد الخدمة", Values = new ChartValues<decimal>(list.Select(x => (decimal)x.TotalRevenue)), Fill = System.Windows.Media.Brushes.PaleVioletRed, DataLabels = true });
        }

        // --- الأحداث (Events) ---

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            await RefreshDashboardData();
            btnRefresh.Enabled = true;
        }

        private void btnGymIncome_Click(object sender, EventArgs e)
        {
            using (var gymReport = new frmGymIncomeReport())
            {
                gymReport.ShowDialog();
            }
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnRefresh.Enabled = false;

                var settingsRepo = new SettingsRepository(new DbConnectionFactory());
                var centerSettings = await settingsRepo.GetSettingsAsync();

                DateTime fromDate = dtpFrom.Value.Date;
                DateTime toDate = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

                var dashboardData = await _reportsRepo.GetFinancialDashboardAsync(fromDate, toDate);
                var roomsData = (await _reportsRepo.GetRevenueByRoomAsync(fromDate, toDate)).ToList();
                var servicesData = (await _reportsRepo.GetTopServicesAsync(fromDate, toDate)).ToList();

                string fileName = $"Financial_Report_{DateTime.Now:yyyy_MM_dd_HHmm}.pdf";
                string filePath = Path.Combine(Path.GetTempPath(), fileName);

                var reportGenerator = new FinancialReportGenerator();
                reportGenerator.Generate(filePath, centerSettings, dashboardData, roomsData, servicesData, fromDate, toDate);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في الطباعة: {ex.Message}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnRefresh.Enabled = true;
            }
        }
    }
}