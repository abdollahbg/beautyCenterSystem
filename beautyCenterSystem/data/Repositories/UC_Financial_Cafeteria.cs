using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using BeautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using beautyCenterSystem.helpers;
using BeautyCenterSystem.Data.Repositories;

namespace beautyCenterSystem.data.Repositories {
    public partial class UC_Financial_Cafeteria : UserControl {
        private DataGridView dgv;
        private Label lblIncome;
        private Label lblExpenses;
        private Label lblNetProfit;

        public UC_Financial_Cafeteria() {
            InitializeComponent();
            
            var pnlTop = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.WhiteSmoke };
            lblIncome = new Label { Text = "إجمالي الإيرادات: 0", ForeColor = Color.Green, Font = new Font("Segoe UI", 12, FontStyle.Bold), AutoSize = true, Location = new Point(500, 20) };
            lblExpenses = new Label { Text = "مصروفات الكافتيريا: 0", ForeColor = Color.Red, Font = new Font("Segoe UI", 12, FontStyle.Bold), AutoSize = true, Location = new Point(250, 20) };
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
                var repo = new FinancialReportsRepository(new DbConnectionFactory());
                var data = await repo.GetCafeteriaReportsAsync(fromDate, toDate);
                decimal expenses = await repo.GetCafeteriaExpensesAsync(fromDate, toDate);

                decimal totalIncome = 0;
                foreach (dynamic row in data)
                {
                    totalIncome += (decimal)row.TotalRevenue;
                }

                decimal netProfit = totalIncome - expenses;

                lblIncome.Text = $"إجمالي الإيرادات: {totalIncome:N0}";
                lblExpenses.Text = $"مصروفات الكافتيريا: {expenses:N0}";
                lblNetProfit.Text = $"صافي الربح: {netProfit:N0}";

                dgv.DataSource = null;
                dgv.Columns.Clear();
                dgv.AutoGenerateColumns = false;

                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ItemName", HeaderText = "الصنف", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "QuantitySold", HeaderText = "الكمية" });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalRevenue", HeaderText = "الإجمالي", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });

                dgv.DataSource = data.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب بيانات الكافيتريا: {ex.Message}");
            }
        }
    }
}






