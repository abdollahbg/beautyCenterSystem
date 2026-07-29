using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using BeautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using beautyCenterSystem.helpers;
using BeautyCenterSystem.Data.Repositories;

namespace beautyCenterSystem.data.Repositories {
    public partial class UC_Financial_EmployeePerformance : UserControl {
        private DataGridView dgv;
        public UC_Financial_EmployeePerformance() {
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
                var data = await repo.GetEmployeePerformanceAsync(fromDate, toDate);

                dgv.DataSource = null;
                dgv.Columns.Clear();
                dgv.AutoGenerateColumns = false;

                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EmployeeName", HeaderText = "الموظفة", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ServicesCount", HeaderText = "عدد الخدمات" });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalServicesRevenue", HeaderText = "إجمالي العمل", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalEarnedCommissions", HeaderText = "العمولة المستحقة", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalActuallyPaid", HeaderText = "المبالغ المستلمة", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });

                dgv.DataSource = data.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب بيانات أداء الموظفات: {ex.Message}");
            }
        }
    }
}






