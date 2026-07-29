using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using BeautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using beautyCenterSystem.helpers;
using BeautyCenterSystem.Data.Repositories;

namespace beautyCenterSystem.data.Repositories {
    public partial class UC_Financial_Rooms : UserControl {
        private DataGridView dgv;
        public UC_Financial_Rooms() {
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
                var data = await repo.GetRevenueByRoomAsync(fromDate, toDate);

                dgv.DataSource = null;
                dgv.Columns.Clear();
                dgv.AutoGenerateColumns = false;

                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RoomName", HeaderText = "الغرفة", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalRevenue", HeaderText = "الإيراد", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalExpenses", HeaderText = "المصروفات", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NetProfit", HeaderText = "صافي الدخل", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });

                var formattedData = data.Select(x => new
                {
                    RoomName = (string)x.RoomName,
                    TotalRevenue = (decimal)x.TotalRevenue,
                    TotalExpenses = (decimal)x.TotalExpenses,
                    NetProfit = (decimal)x.NetProfit
                }).ToList();

                dgv.DataSource = formattedData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب بيانات أرباح الغرف: {ex.Message}");
            }
        }
    }
}






