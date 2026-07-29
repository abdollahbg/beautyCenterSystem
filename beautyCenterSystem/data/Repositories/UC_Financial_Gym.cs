using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using BeautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using beautyCenterSystem.helpers;
using BeautyCenterSystem.Data.Repositories;

namespace beautyCenterSystem.data.Repositories {
    public partial class UC_Financial_Gym : UserControl {
        private DataGridView dgv;
        private Label lblIncome;
        private Label lblExpenses;
        private Label lblNetProfit;

        public UC_Financial_Gym() {
            InitializeComponent();
            
            var pnlTop = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.WhiteSmoke };
            lblIncome = new Label { Text = "إجمالي الإيرادات: 0", ForeColor = Color.Green, Font = new Font("Segoe UI", 12, FontStyle.Bold), AutoSize = true, Location = new Point(500, 20) };
            lblExpenses = new Label { Text = "مصروفات الجيم: 0", ForeColor = Color.Red, Font = new Font("Segoe UI", 12, FontStyle.Bold), AutoSize = true, Location = new Point(250, 20) };
            lblNetProfit = new Label { Text = "صافي الربح: 0", ForeColor = Color.Blue, Font = new Font("Segoe UI", 12, FontStyle.Bold), AutoSize = true, Location = new Point(20, 20) };
            
            pnlTop.Controls.Add(lblIncome);
            pnlTop.Controls.Add(lblExpenses);
            pnlTop.Controls.Add(lblNetProfit);
            
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
                var repo = new GymRepository(new DbConnectionFactory());
                var data = await repo.GetGymIncomeDetailsAsync(fromDate, toDate);

                var financialRepo = new FinancialReportsRepository(new DbConnectionFactory());
                decimal expenses = await financialRepo.GetGymExpensesAsync(fromDate, toDate);

                decimal totalIncome = 0;
                foreach (dynamic row in data)
                {
                    totalIncome += (decimal)row.PaidAmount;
                }

                decimal netProfit = totalIncome - expenses;

                lblIncome.Text = $"إجمالي الإيرادات: {totalIncome:N0}";
                lblExpenses.Text = $"مصروفات الجيم: {expenses:N0}";
                lblNetProfit.Text = $"صافي الربح: {netProfit:N0}";

                dgv.DataSource = null;
                dgv.Columns.Clear();
                dgv.AutoGenerateColumns = false;

                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CustomerName", HeaderText = "اسم العميلة", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SubscriptionType", HeaderText = "الباقة", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SafeName", HeaderText = "الخزنة" });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaidAmount", HeaderText = "المبلغ", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CreatedAt", HeaderText = "التاريخ" });

                dgv.DataSource = data.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب بيانات إيرادات الجيم: {ex.Message}");
            }
        }
    }
}






