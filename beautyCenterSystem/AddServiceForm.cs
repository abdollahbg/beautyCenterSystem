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
            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                MessageBox.Show("يرجى إدخال اسم الخدمة");
                return;
            }

            // 2. التحقق من السعر وتحويله بأمان
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("يرجى إدخال سعر صحيح (أكبر من صفر)");
                return;
            }

            // 3. التحقق من المدة
            if (!int.TryParse(txtDuration.Text, out int duration) || duration <= 0)
            {
                MessageBox.Show("يرجى إدخال مدة الخدمة بالدقائق");
                return;
            }

            // 4. التحقق من اختيار الغرفة
            if (cmbRooms.SelectedValue == null)
            {
                MessageBox.Show("يرجى اختيار غرفة لهذه الخدمة");
                return;
            }

            if (cmbRooms.SelectedValue == null) return;

            var service = new Service
            {
                ServiceName = txtServiceName.Text.Trim(),
                Price = decimal.Parse(txtPrice.Text),
                DurationMinutes = int.Parse(txtDuration.Text),
                RoomID = (int)cmbRooms.SelectedValue
            };

            await _serviceRepo.AddAsync(service);
            this.DialogResult = DialogResult.OK;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 1. السماح بالأرقام، مفاتيح التحكم (مثل Backspace)، والنقطة العشرية
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                return;
            }

            // 2. التحقق من النقطة العشرية باستخدام اسم الأداة مباشرة لتجنب الـ Null
            if (e.KeyChar == '.')
            {
                // استخدم اسم التكست بوكس الخاص بك مباشرة هنا
                if (txtPrice.Text.Contains("."))
                {
                    e.Handled = true;
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // إذا ضغط المستخدم Enter وكان التركيز (Focus) "ليس" في حقل الملاحظات
            if (keyData == Keys.Enter)
            {
                btnSave.PerformClick(); // نفذ كود زر الحفظ
                return true; // أخبر النظام أننا تعاملنا مع الضغطة ولا داعي لعمل "Beep"
            }

            // إذا ضغط Esc، أغلق الفورم (مثل زر الكانسل)
            if (keyData == Keys.Escape)
            {
                BtnCancel.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void txtDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            // السماح بالأرقام ومفتاح Backspace فقط
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
