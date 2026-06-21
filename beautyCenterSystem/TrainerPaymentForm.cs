using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeautyCenterSystem.Data;
using BeautyCenterSystem.Data.Repositories;
using beautyCenterSystem.data.Repositories;

namespace beautyCenterSystem
{
    public partial class TrainerPaymentForm : Form
    {
        private readonly TrainerRepository _trainerRepo;
        private readonly FinancialRepository _financialRepo;
        private readonly int _currentUserId;

        // الخاصية المطلوبة لاستقبال معرف المدربة من الشاشة الخارجية
        public int? SelectedTrainerId { get; set; }

        public TrainerPaymentForm(int userId)
        {
            InitializeComponent();

            var dbFactory = new DbConnectionFactory();
            _trainerRepo = new TrainerRepository(dbFactory);
            _financialRepo = new FinancialRepository(dbFactory);

            _currentUserId = userId;

            // ربط الأحداث
            this.Load += TrainerPaymentForm_Load;
            cmbTrainer.SelectedIndexChanged += cmbTrainer_SelectedIndexChanged;
            btnSave.Click += btnSave_Click;
            BtnCancel.Click += BtnCancel_Click;
        }

        private async void TrainerPaymentForm_Load(object? sender, EventArgs e)
        {
            AppTheme.Apply(this);

            // 1. تحميل البيانات الأساسية (المدربات والخزنات)
            await LoadInitialData();

            // 2. إذا تم تمرير معرف مدربة، قم باختيارها
            if (SelectedTrainerId.HasValue)
            {
                cmbTrainer.SelectedValue = SelectedTrainerId.Value;
                await RefreshTrainerBalances(SelectedTrainerId.Value);
            }
        }

        private async Task LoadInitialData()
        {
            try
            {
                // تحميل قائمة المدربات النشطات
                var trainers = await _trainerRepo.GetAllAsync();
                cmbTrainer.DataSource = trainers.ToList();
                cmbTrainer.DisplayMember = "TrainerName";
                cmbTrainer.ValueMember = "TrainerID";
                cmbTrainer.SelectedIndex = -1;

                // تحميل قائمة الخزنات
                var safes = await _financialRepo.GetAllSafesAsync();
                cmbSafe.DataSource = safes.ToList();
                cmbSafe.DisplayMember = "SafeName";
                cmbSafe.ValueMember = "SafeID";
                cmbSafe.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل البيانات الأولية: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cmbTrainer_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbTrainer.SelectedValue is int trainerId)
            {
                await RefreshTrainerBalances(trainerId);
            }
        }

        private async Task RefreshTrainerBalances(int trainerId)
        {
            try
            {
                decimal totalEarned = await _trainerRepo.GetTrainerTotalEarnedAsync(trainerId);
                decimal totalPaid = await _trainerRepo.GetTrainerTotalPaidAsync(trainerId);
                decimal remaining = totalEarned - totalPaid;

                txtTotalEarned.Text = totalEarned.ToString("N2");
                txtTotalPaid.Text = totalPaid.ToString("N2");
                txtRemainingBalance.Text = remaining.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحديث أرصدة المدربة: {ex.Message}");
            }
        }

        private async void btnSave_Click(object? sender, EventArgs e)
        {
            // التحقق من صحة الاختيارات
            if (cmbTrainer.SelectedValue == null || cmbSafe.SelectedValue == null)
            {
                MessageBox.Show("يرجى اختيار المدربة والخزنة أولاً.", "تنبيه");
                return;
            }

            // التحقق من صحة المبلغ المدخل
            if (!decimal.TryParse(txtAmountToPay.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("يرجى إدخال مبلغ صرف صحيح.", "تنبيه");
                return;
            }

            // التحقق من أن المبلغ لا يتجاوز المستحق
            if (decimal.TryParse(txtRemainingBalance.Text, out decimal remaining))
            {
                if (amount > remaining)
                {
                    MessageBox.Show("المبلغ المدخل يتجاوز رصيد المدربة المتبقي!", "خطأ في المبلغ");
                    return;
                }
            }

            try
            {
                btnSave.Enabled = false;
                int trainerId = (int)cmbTrainer.SelectedValue;
                int safeId = (int)cmbSafe.SelectedValue;
                string notes = txtNotes.Text.Trim();

                bool success = await _trainerRepo.SaveTrainerPaymentAsync(trainerId, safeId, amount, notes, _currentUserId);

                if (success)
                {
                    MessageBox.Show("تم تسجيل عملية الصرف بنجاح وتحديث رصيد الخزنة.", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // تحديث الأرصدة بعد الصرف
                    await RefreshTrainerBalances(trainerId);

                    // تنظيف الحقول
                    txtAmountToPay.Clear();
                    txtNotes.Text = "صرف مستحقات مدربة";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء الحفظ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
