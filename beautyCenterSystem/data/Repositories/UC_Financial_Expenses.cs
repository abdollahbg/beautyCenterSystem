using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using BeautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using beautyCenterSystem.helpers;
using BeautyCenterSystem.Data.Repositories;

namespace beautyCenterSystem.data.Repositories {
    public partial class UC_Financial_Expenses : UserControl {
        private DataGridView dgv;
        public UC_Financial_Expenses() {
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
                var data = await repo.GetExpenseReportsAsync(fromDate, toDate);

                dgv.DataSource = null;
                dgv.Columns.Clear();
                dgv.AutoGenerateColumns = false;

                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ExpenseName", HeaderText = "بيان المصروف", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = "التصنيف" });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Amount", HeaderText = "المبلغ", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ExpenseDate", HeaderText = "التاريخ" });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RoomName", HeaderText = "الغرفة" });

                var formattedData = data.Select(x => new beautyCenterSystem.viewsmodels.ExpenseReportDTO
                {
                    ExpenseID = x.ExpenseID,
                    ExpenseName = x.ExpenseName,
                    Category = x.Category,
                    Amount = x.Amount,
                    ExpenseDate = x.ExpenseDate,
                    PaidFromSafe = x.PaidFromSafe,
                    IssuedBy = x.IssuedBy,
                    RoomName = string.IsNullOrEmpty(x.RoomName) ? "مصروف عام" : x.RoomName
                }).ToList();

                dgv.DataSource = formattedData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب بيانات المصروفات: {ex.Message}");
            }
        }
    }
}






