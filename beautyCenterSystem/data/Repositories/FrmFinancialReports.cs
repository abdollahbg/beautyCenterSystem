using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BeautyCenterSystem.Data;
using BeautyCenterSystem.Data.Repositories;
using beautyCenterSystem.Data.Repositories;
using beautyCenterSystem.helpers;

namespace beautyCenterSystem.data.Repositories
{
    public partial class FrmFinancialReports : Form
    {
        private readonly FinancialReportsRepository _reportsRepo;
        private readonly GymRepository _gymRepo;

        public FrmFinancialReports()
        {
            InitializeComponent();

            // إعداد المستودع
            var dbFactory = new DbConnectionFactory();
            _reportsRepo = new FinancialReportsRepository(dbFactory);
            _gymRepo = new GymRepository(dbFactory);

            // تطبيق الثيم العام
            AppTheme.Apply(this);

            // إعداد السايد بار والتنقل
            SetupNavigation();

            // تخصيص ألوان الكروت العلوية
            lblTotalRevenue.ForeColor = Color.FromArgb(39, 174, 96);   // أخضر
            lblTotalExpenses.ForeColor = Color.FromArgb(192, 57, 43);  // أحمر
            lblTotalPurchases.ForeColor = Color.FromArgb(211, 84, 0); // برتقالي
        }

        public async Task RefreshDashboardData()
        {
            try
            {
                var fromDate = dtpFrom.Value.Date;
                var toDate = dtpTo.Value.Date;
                var useDate = chkEnableDateFilter.Checked;

                if (!useDate)
                {
                    fromDate = new DateTime(2000, 1, 1);
                    toDate = new DateTime(2100, 1, 1);
                }

                // 1. تحديث الكروت المالية العلوية
                var dashboard = await _reportsRepo.GetFinancialDashboardAsync(fromDate, toDate);
                decimal gymTotal = await _gymRepo.GetTotalGymIncomeAsync(fromDate, toDate);

                lblTotalRevenue.Text = dashboard.TotalRevenue.ToString("N0");
                lblTotalExpenses.Text = dashboard.TotalExpenses.ToString("N0");
                lblTotalPurchases.Text = dashboard.TotalPurchases.ToString("N0");
                lblTotalEmployeeDues.Text = dashboard.TotalEmployeeDues.ToString("N0");
                lblTotalTrainerDues.Text = dashboard.TotalTrainerDues.ToString("N0");
                lblTotalGym.Text = gymTotal.ToString("N0");
                lblTotalCafeteria.Text = dashboard.TotalCafeteriaRevenue.ToString("N0");

                decimal netProfit = dashboard.NetProfit;
                lblNetProfit.Text = netProfit.ToString("N0");
                lblNetProfit.ForeColor = netProfit >= 0 ? Color.Green : Color.Red;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء جلب البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ShowScreenAsync(UserControl screen)
        {
            if (pnlContent.Controls.Count > 0)
            {
                pnlContent.Controls[0].Dispose();
                pnlContent.Controls.Clear();
            }
            screen.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(screen);

            // جلب التواريخ الحالية من الفلاتر
            DateTime fromDate = chkEnableDateFilter.Checked ? dtpFrom.Value.Date : new DateTime(2000, 1, 1);
            DateTime toDate = chkEnableDateFilter.Checked ? dtpTo.Value.Date.AddDays(1).AddSeconds(-1) : new DateTime(2100, 1, 1);

            // استدعاء LoadData إذا كانت موجودة
            var loadMethod = screen.GetType().GetMethod("LoadData");
            if (loadMethod != null)
            {
                var task = loadMethod.Invoke(screen, new object[] { fromDate, toDate }) as Task;
                if (task != null) await task;
            }
        }

        private void SetupNavigation()
        {
            var navButtons = new Dictionary<FontAwesome.Sharp.IconButton, Func<UserControl>>
            {
                { btnNavServices, () => new UC_Financial_Services() },
                { btnNavRooms, () => new UC_Financial_Rooms() },
                { btnNavSales, () => new UC_Financial_Sales() },
                { btnNavExpenses, () => new UC_Financial_Expenses() },
                { btnNavPurchases, () => new UC_Financial_Purchases() },
                { btnNavSafes, () => new UC_Financial_Safes() },
                { btnNavDailyClosing, () => new UC_Financial_DailyClosing() },
                { btnNavEmployeeExpenses, () => new UC_Financial_EmployeeExpenses() },
                { btnNavTrainerExpenses, () => new UC_Financial_TrainerExpenses() },
                { btnNavGym, () => new UC_Financial_Gym() },
                { btnNavCafeteria, () => new UC_Financial_Cafeteria() },
                { btnNavEmployeePerf, () => new UC_Financial_EmployeePerformance() }
            };

            foreach (var kvp in navButtons)
            {
                var btn = kvp.Key;
                var getUc = kvp.Value;

                btn.Click += async (s, e) =>
                {
                    // إعادة الألوان لجميع الأزرار
                    foreach (var b in navButtons.Keys)
                    {
                        b.BackColor = Color.FromArgb(240, 240, 240);
                        b.ForeColor = Color.Black;
                        b.IconColor = Color.Black;
                    }

                    // تلوين الزر النشط
                    btn.BackColor = Color.FromArgb(220, 20, 60);
                    btn.ForeColor = Color.White;
                    btn.IconColor = Color.White;

                    await ShowScreenAsync(getUc());
                };
            }

            // تحديد أول شاشة كافتراضية
            btnNavServices.PerformClick();
        }



        // --- الأحداث (Events) ---

        private async void FrmFinancialReports_Load(object sender, EventArgs e)
        {
            await RefreshDashboardData();
        }

        private async void chkEnableDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = chkEnableDateFilter.Checked;
            dtpTo.Enabled = chkEnableDateFilter.Checked;
            await RefreshDashboardData();
        }

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

        private void labelEmployeeDuesTitle_Click(object sender, EventArgs e)
        {

        }
    }
}