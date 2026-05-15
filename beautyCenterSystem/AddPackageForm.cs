using System;
using System.Windows.Forms;
using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using MaterialSkin.Controls;

namespace beautyCenterSystem
{
    public partial class AddPackageForm : MaterialForm
    {
        private readonly GymRepository _gymRepo;

        public AddPackageForm()
        {
            InitializeComponent();
            _gymRepo = new GymRepository(new DbConnectionFactory());
            
            // Events
            chkIsSessionBased.CheckedChanged += ChkIsSessionBased_CheckedChanged;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AppTheme.Apply(this);
        }

        private void ChkIsSessionBased_CheckedChanged(object sender, EventArgs e)
        {
            txtTotalSessions.Enabled = chkIsSessionBased.Checked;
            if (!chkIsSessionBased.Checked)
                txtTotalSessions.Text = "0";
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPackageName.Text) || 
                string.IsNullOrWhiteSpace(txtPrice.Text) || 
                string.IsNullOrWhiteSpace(txtDurationDays.Text))
            {
                MessageBox.Show("الرجاء إدخال بيانات الباقة الأساسية (الاسم، المدة، السعر).");
                return;
            }

            try
            {
                var package = new GymSubscriptionType
                {
                    TypeName = txtPackageName.Text.Trim(),
                    DurationDays = int.Parse(txtDurationDays.Text),
                    Price = decimal.Parse(txtPrice.Text),
                    IsSessionBased = chkIsSessionBased.Checked,
                    TotalSessions = chkIsSessionBased.Checked ? int.Parse(txtTotalSessions.Text) : 0,
                    IsActive = true
                };

                bool saved = await _gymRepo.AddSubscriptionTypeAsync(package);

                if (saved)
                {
                    MessageBox.Show("تم حفظ الباقة بنجاح.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في حفظ الباقة: {ex.Message}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
