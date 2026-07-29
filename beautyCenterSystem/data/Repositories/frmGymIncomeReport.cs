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
        private CheckBox chkEnableDateFilter;

        public frmGymIncomeReport()
        {
            InitializeComponent();

            var dbFactory = new DbConnectionFactory();
            _gymRepo = new GymRepository(dbFactory);

            // Add checkbox dynamically
            chkEnableDateFilter = new CheckBox
            {
                Text = "تفعيل الفلتر",
                Checked = true,
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(dtpTo.Location.X - 100, dtpTo.Location.Y + 2)
            };
            chkEnableDateFilter.CheckedChanged += (s, e) =>
            {
                dtpFrom.Enabled = chkEnableDateFilter.Checked;
                dtpTo.Enabled = chkEnableDateFilter.Checked;
                LoadReportAsync();
            };
            pnlDateFilter.Controls.Add(chkEnableDateFilter);

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

                DateTime from;
                DateTime to;

                if (chkEnableDateFilter.Checked)
                {
                    from = dtpFrom.Value.Date;
                    to = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);
                }
                else
                {
                    from = new DateTime(2000, 1, 1);
                    to = new DateTime(2100, 1, 1);
                }

                // 1. Get total income and update the label
                decimal totalIncome = await _gymRepo.GetTotalGymIncomeAsync(from, to);
                lblTotalIncomeValue.Text = totalIncome.ToString("N0");

                // 2. Get detailed records in background if needed (without grid binding)
                var details = (await _gymRepo.GetGymIncomeDetailsAsync(from, to)).ToList();
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