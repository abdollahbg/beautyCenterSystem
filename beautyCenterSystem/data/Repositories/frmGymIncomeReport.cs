using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;

namespace beautyCenterSystem.data.Repositories
{
    public partial class frmGymIncomeReport : Form
    {
        private readonly GymRepository _gymRepo;

        public frmGymIncomeReport()
        {
            InitializeComponent();

            var dbFactory = new DbConnectionFactory();
            _gymRepo = new GymRepository(dbFactory);

            // Apply theme
            AppTheme.Apply(this);
            pnlHeader.BackColor = AppTheme.Primary;

            // Set default date range: first of current month to today
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;

            // Wire events
            btnFilter.Click += BtnFilter_Click;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadReportAsync();
        }

        private async void BtnFilter_Click(object sender, EventArgs e)
        {
            await LoadReportAsync();
        }

        private async Task LoadReportAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnFilter.Enabled = false;

                DateTime fromDate = dtpFrom.Value.Date;
                DateTime toDate = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

                // 1. Get total income and update the label
                decimal totalIncome = await _gymRepo.GetTotalGymIncomeAsync(fromDate, toDate);
                lblTotalIncomeValue.Text = totalIncome.ToString("N0");

                // 2. Get detailed records in background if needed (without grid binding)
                var details = (await _gymRepo.GetGymIncomeDetailsAsync(fromDate, toDate)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب تقرير الجيم: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnFilter.Enabled = true;
            }
        }
    }
}