using System;
using System.Windows.Forms;
using BeautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using beautyCenterSystem.data.Repositories;

namespace beautyCenterSystem
{
    public partial class AddTrainerForm : Form
    {
        private readonly TrainerRepository _trainerRepo;

        public AddTrainerForm()
        {
            InitializeComponent();
            _trainerRepo = new TrainerRepository(new DbConnectionFactory());
        }

        private void AddTrainerForm_Load(object sender, EventArgs e)
        {
            AppTheme.Apply(this);
            PnlHeader.BackColor = AppTheme.Primary;
            
            // Hide unused fields that were copied from AddEmployeeForm
            // Since we didn't recreate the designer file, we just hide them
            if (this.Controls.ContainsKey("cmbEmployeeType")) this.Controls["cmbEmployeeType"].Visible = false;
            if (this.Controls.ContainsKey("labelType")) this.Controls["labelType"].Visible = false;
            if (this.Controls.ContainsKey("txtBaseSalary")) this.Controls["txtBaseSalary"].Visible = false;
            if (this.Controls.ContainsKey("labelSalary")) this.Controls["labelSalary"].Visible = false;
            if (this.Controls.ContainsKey("txtCommissionRate")) this.Controls["txtCommissionRate"].Visible = false;
            if (this.Controls.ContainsKey("label5")) this.Controls["label5"].Visible = false;
            if (this.Controls.ContainsKey("cmbRooms")) this.Controls["cmbRooms"].Visible = false;
            if (this.Controls.ContainsKey("label3")) this.Controls["label3"].Visible = false;
            
            // We adjust positions of Save and Cancel
            btnSave.Location = new System.Drawing.Point(250, 250);
            BtnCancel.Location = new System.Drawing.Point(60, 250);
            this.Height = 350;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTrainerName.Text))
            {
                MessageBox.Show("يرجى إدخال اسم المدربة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newTrainer = new Trainer
            {
                TrainerName = txtTrainerName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                IsActive = true
            };

            try
            {
                btnSave.Enabled = false;
                await _trainerRepo.AddAsync(newTrainer);
                
                MessageBox.Show("تم إضافة المدربة بنجاح.", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                btnSave.Enabled = true;
                MessageBox.Show($"فشل عملية الحفظ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
