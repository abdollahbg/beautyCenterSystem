using BeautyCenterSystem.Data;
using BeautyCenterSystem.Data.Repositories;
using beautyCenterSystem.Data.Repositories;
using beautyCenterSystem.viewsmodels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace beautyCenterSystem
{
    public partial class TrainerDuesForm : Form
    {
        private readonly GymRepository _gymRepo;
        private readonly FinancialRepository _safeRepo;
        private int _userId;
        private string _userName;

        public TrainerDuesForm(int userId, string userName)
        {
            InitializeComponent();
            _gymRepo = new GymRepository(new DbConnectionFactory());
            _safeRepo = new FinancialRepository(new DbConnectionFactory());
            _userId = userId;
            _userName = userName;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AppTheme.Apply(this);

            try
            {
                await LoadSafesAsync();
                await LoadTrainerDuesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل البيانات: {ex.Message}");
            }
        }

        private async System.Threading.Tasks.Task LoadSafesAsync()
        {
            var safes = await _safeRepo.GetAllSafesAsync();
            cmbSafes.DataSource = safes.ToList();
            cmbSafes.DisplayMember = "SafeName";
            cmbSafes.ValueMember = "SafeID";
        }

        private async System.Threading.Tasks.Task LoadTrainerDuesAsync()
        {
            var dues = await _gymRepo.GetUnpaidTrainerDuesAsync();
            dgvTrainerDues.DataSource = dues.ToList();

            if (dgvTrainerDues.Columns.Contains("TrainerID"))
                dgvTrainerDues.Columns["TrainerID"].Visible = false;

            if (dgvTrainerDues.Columns.Contains("TrainerName"))
                dgvTrainerDues.Columns["TrainerName"].HeaderText = "اسم المدربة";

            if (dgvTrainerDues.Columns.Contains("TotalBaseAmount"))
                dgvTrainerDues.Columns["TotalBaseAmount"].HeaderText = "إجمالي المبلغ الثابت";

            if (dgvTrainerDues.Columns.Contains("TotalCommissionAmount"))
                dgvTrainerDues.Columns["TotalCommissionAmount"].HeaderText = "إجمالي العمولات";

            if (dgvTrainerDues.Columns.Contains("TotalDues"))
                dgvTrainerDues.Columns["TotalDues"].HeaderText = "إجمالي المستحقات";

            if (dgvTrainerDues.Columns.Contains("UnpaidSubscriptionsCount"))
                dgvTrainerDues.Columns["UnpaidSubscriptionsCount"].HeaderText = "عدد الاشتراكات الغير مدفوعة";

            if (!dgvTrainerDues.Columns.Contains("btnPay"))
            {
                DataGridViewButtonColumn btnPay = new DataGridViewButtonColumn();
                btnPay.Name = "btnPay";
                btnPay.HeaderText = "صرف المستحقات";
                btnPay.Text = "صرف";
                btnPay.UseColumnTextForButtonValue = true;
                btnPay.FlatStyle = FlatStyle.Flat;
                dgvTrainerDues.Columns.Add(btnPay);
            }
        }

        private async void dgvTrainerDues_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTrainerDues.Columns[e.ColumnIndex].Name == "btnPay")
            {
                if (cmbSafes.SelectedValue == null)
                {
                    MessageBox.Show("الرجاء اختيار الخزنة التي سيتم السحب منها أولاً.");
                    return;
                }

                var row = dgvTrainerDues.Rows[e.RowIndex];
                int trainerId = (int)row.Cells["TrainerID"].Value;
                string trainerName = row.Cells["TrainerName"].Value.ToString();
                decimal totalDues = (decimal)row.Cells["TotalDues"].Value;
                int safeId = (int)cmbSafes.SelectedValue;
                string safeName = cmbSafes.Text;

                var confirmResult = MessageBox.Show(
                    $"هل أنت متأكد من صرف مستحقات بقيمة {totalDues:C} للمدربة {trainerName} من خزنة {safeName}؟\n" +
                    "سيتم خصم هذا المبلغ من الخزنة بشكل فوري وتصفير حساب المدربة.",
                    "تأكيد الدفع", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        bool success = await _gymRepo.PayTrainerDuesAsync(trainerId, totalDues, safeId, _userId, _userName);
                        if (success)
                        {
                            MessageBox.Show("تم صرف المستحقات بنجاح وتحديث حساب الخزنة!");
                            await LoadTrainerDuesAsync(); // Reload
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"خطأ أثناء الصرف: {ex.Message}");
                    }
                }
            }
        }
    }
}
