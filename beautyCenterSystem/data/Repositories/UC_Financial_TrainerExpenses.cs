using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using BeautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data.Repositories;
using beautyCenterSystem.helpers;

namespace beautyCenterSystem.data.Repositories {
    public partial class UC_Financial_TrainerExpenses : UserControl {
        private DataGridView dgv;
        public UC_Financial_TrainerExpenses() {
            InitializeComponent();
            dgv = new DataGridView {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White
            };
            this.Controls.Add(dgv);
            this.RightToLeft = RightToLeft.Yes;
            beautyCenterSystem.AppTheme.Apply(this);
        }
        
        public async Task LoadData(DateTime fromDate, DateTime toDate) {
            try
            {
                var repo = new FinancialReportsRepository(new DbConnectionFactory());
                var data = await repo.GetTrainerExpensesAsync(fromDate, toDate);

                dgv.DataSource = null;
                dgv.Columns.Clear();
                dgv.AutoGenerateColumns = false;

                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrainerName", HeaderText = "المدربة", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ExpenseAmount", HeaderText = "المبلغ", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ExpenseDate", HeaderText = "التاريخ" });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Notes", HeaderText = "ملاحظات" });

                dgv.DataSource = data.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب بيانات مصروفات المدربات: {ex.Message}");
            }
        }
    }
}
