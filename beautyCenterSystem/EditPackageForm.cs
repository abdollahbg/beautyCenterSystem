using System;
using System.Windows.Forms;
using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using MaterialSkin.Controls;

namespace beautyCenterSystem
{
    public partial class EditPackageForm : MaterialForm
    {
        private readonly GymRepository _gymRepo;
        private GymSubscriptionType _packageToEdit;

        public EditPackageForm(GymSubscriptionType package)
        {
            InitializeComponent();
            _gymRepo = new GymRepository(new DbConnectionFactory());
            _packageToEdit = package;

            // Events
            chkIsSessionBased.CheckedChanged += ChkIsSessionBased_CheckedChanged;
            btnUpdate.Click += BtnUpdate_Click;
            btnCancel.Click += BtnCancel_Click;

            // Populate fields
            PopulateData();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AppTheme.Apply(this);
        }

        private void PopulateData()
        {
            if (_packageToEdit != null)
            {
                txtPackageName.Text = _packageToEdit.TypeName;
                txtDurationDays.Text = _packageToEdit.DurationDays.ToString();
                txtPrice.Text = _packageToEdit.Price.ToString();
                chkIsSessionBased.Checked = _packageToEdit.IsSessionBased;
                txtTotalSessions.Text = _packageToEdit.TotalSessions.ToString();
                
                txtTotalSessions.Enabled = _packageToEdit.IsSessionBased;
            }
        }

        private void ChkIsSessionBased_CheckedChanged(object sender, EventArgs e)
        {
            txtTotalSessions.Enabled = chkIsSessionBased.Checked;
            if (!chkIsSessionBased.Checked)
                txtTotalSessions.Text = "0";
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
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
                _packageToEdit.TypeName = txtPackageName.Text.Trim();
                _packageToEdit.DurationDays = int.Parse(txtDurationDays.Text);
                _packageToEdit.Price = decimal.Parse(txtPrice.Text);
                _packageToEdit.IsSessionBased = chkIsSessionBased.Checked;
                _packageToEdit.TotalSessions = chkIsSessionBased.Checked ? int.Parse(txtTotalSessions.Text) : 0;
                
                bool updated = await _gymRepo.UpdateSubscriptionTypeAsync(_packageToEdit);

                if (updated)
                {
                    MessageBox.Show("تم تعديل الباقة بنجاح.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تعديل الباقة: {ex.Message}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
