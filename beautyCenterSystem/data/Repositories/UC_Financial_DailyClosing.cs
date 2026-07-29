using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using BeautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using beautyCenterSystem.helpers;
using BeautyCenterSystem.Data.Repositories;

namespace beautyCenterSystem.data.Repositories {
    public partial class UC_Financial_DailyClosing : UserControl {
        private DataGridView dgv;
        private Label lblTotalDifference;

        public UC_Financial_DailyClosing() {
            InitializeComponent();
            
            var pnlTop = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.WhiteSmoke };
            lblTotalDifference = new Label { Text = "القيمة النهائية: 0", ForeColor = Color.Black, Font = new Font("Segoe UI", 12, FontStyle.Bold), AutoSize = true, Location = new Point(20, 20) };
            pnlTop.Controls.Add(lblTotalDifference);
            
            dgv = new DataGridView {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White
            };
            this.Controls.Add(dgv);
            this.Controls.Add(pnlTop);
            this.RightToLeft = RightToLeft.Yes;
            beautyCenterSystem.AppTheme.Apply(this);
        }
        
        public async Task LoadData(DateTime fromDate, DateTime toDate) {
            try
            {
                var repo = new FinancialReportsRepository(new DbConnectionFactory());
                var data = await repo.GetDailyClosuresReportsAsync(fromDate, toDate);

                decimal totalDifference = 0;

                foreach (dynamic row in data)
                {
                    try
                    {
                        decimal diff = (decimal)row.Difference;
                        totalDifference += diff;
                    }
                    catch { }
                }

                if (totalDifference < 0)
                {
                    lblTotalDifference.Text = $"صافي الحسابات: {Math.Abs(totalDifference):N0} (عجز)";
                    lblTotalDifference.ForeColor = Color.Red;
                }
                else if (totalDifference > 0)
                {
                    lblTotalDifference.Text = $"صافي الحسابات: {totalDifference:N0} (فائض)";
                    lblTotalDifference.ForeColor = Color.Green;
                }
                else
                {
                    lblTotalDifference.Text = $"صافي الحسابات: 0 (متطابق)";
                    lblTotalDifference.ForeColor = Color.Black;
                }

                dgv.DataSource = null;
                dgv.Columns.Clear();
                dgv.AutoGenerateColumns = false;

                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ClosureDate", HeaderText = "التاريخ" });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ActualCashHand", HeaderText = "العد الفعلي", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Difference", HeaderText = "الفرق" });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ClosedByName", HeaderText = "المستخدم" });

                dgv.DataSource = data.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب بيانات التقفيل: {ex.Message}");
            }
        }
    }
}





