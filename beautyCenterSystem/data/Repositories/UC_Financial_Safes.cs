using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using BeautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using beautyCenterSystem.helpers;
using BeautyCenterSystem.Data.Repositories;

namespace beautyCenterSystem.data.Repositories {
    public partial class UC_Financial_Safes : UserControl {
        private DataGridView dgv;
        public UC_Financial_Safes() {
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
                // الخزائن لا تعتمد على التاريخ بل تظهر الرصيد الحالي
                var data = await repo.GetCurrentSafesStatusAsync();

                dgv.DataSource = null;
                dgv.Columns.Clear();
                dgv.AutoGenerateColumns = false;

                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SafeName", HeaderText = "اسم الخزنة", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Balance", HeaderText = "الرصيد الحالي", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });

                dgv.DataSource = data.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب أرصدة الخزائن: {ex.Message}");
            }
        }
    }
}






