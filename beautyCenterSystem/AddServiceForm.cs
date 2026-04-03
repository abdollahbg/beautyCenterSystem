using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beautyCenterSystem
{
    public partial class AddServiceForm : Form
    {
        private readonly RoomRepository _roomRepo;
        private readonly ServiceRepository _serviceRepo;

        public AddServiceForm()
        {
            InitializeComponent();
            _roomRepo = new RoomRepository(new DbConnectionFactory());
            _serviceRepo = new ServiceRepository(new DbConnectionFactory());
            AppTheme.Apply(this);
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await FillRoomsCombo();
            PnlHeader.BackColor = AppTheme.Primary;
            BtnCancel.BackColor = Color.Gray;
        }

        private async Task FillRoomsCombo()
        {
            var rooms = await _roomRepo.GetAllAsync();
            cmbRooms.DataSource = rooms.ToList();
            cmbRooms.DisplayMember = "RoomName";
            cmbRooms.ValueMember = "RoomID";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // 1. التحقق من اسم الخدمة
            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                MessageBox.Show("يرجى إدخال اسم الخدمة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServiceName.Focus();
                return;
            }

            // 2. التحقق من السعر النهائي
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("يرجى إدخال سعر الخدمة بشكل صحيح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            // 3. التحقق من سعر الموظفة (الحقل الجديد)
            if (!decimal.TryParse(txtEmployeeBasePrice.Text, out decimal empPrice))
            {
                // إذا كان الحقل فارغاً نعتبره 0، وإذا كان فيه نص خاطئ ننبه المستخدم
                if (!string.IsNullOrWhiteSpace(txtEmployeeBasePrice.Text))
                {
                    MessageBox.Show("يرجى إدخال سعر الموظفة بشكل صحيح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmployeeBasePrice.Focus();
                    return;
                }
                empPrice = 0;
            }

            // 4. التحقق من المدة
            if (!int.TryParse(txtDuration.Text, out int duration) || duration <= 0)
            {
                MessageBox.Show("يرجى إدخال مدة الخدمة بالدقائق", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDuration.Focus();
                return;
            }

            // 5. التحقق من اختيار الغرفة
            if (cmbRooms.SelectedValue == null)
            {
                MessageBox.Show("يرجى اختيار غرفة لهذه الخدمة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // بناء الكائن مع إضافة الحقل الجديد
            var service = new Service
            {
                ServiceName = txtServiceName.Text.Trim(),
                Price = price,
                EmployeeBasePrice = empPrice, // ربط القيمة هنا
                DurationMinutes = duration,
                RoomID = (int)cmbRooms.SelectedValue,
                IsActive = true
            };

            try
            {
                await _serviceRepo.AddAsync(service);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء الحفظ: {ex.Message}");
            }
        }

        // توحيد حدث منع الحروف للأسعار (يمكنك ربط الحقلين بهذا الحدث من الديزاينر)
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // منع تكرار النقطة العشرية
            var textBox = sender as MaterialTextBox2;
            if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnSave.PerformClick();
                return true;
            }
            if (keyData == Keys.Escape)
            {
                BtnCancel.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}