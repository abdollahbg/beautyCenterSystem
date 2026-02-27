using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beautyCenterSystem
{
    public partial class AddRoomForm : Form
    {
        private readonly RoomRepository _roomRepo;
        public AddRoomForm()
        {
            InitializeComponent();
            _roomRepo = new RoomRepository(new DbConnectionFactory());

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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // 1. التحقق من المدخلات (Validation)
            if (string.IsNullOrWhiteSpace(txtRoomName2.Text))
            {
                MessageBox.Show("يرجى إدخال اسم الغرفة أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoomName2.Focus();
                return;
            }

            try
            {
                // 2. تجهيز كائن الغرفة
                var newRoom = new Room
                {
                    RoomName = txtRoomName2.Text.Trim()
                };

                // 3. استدعاء الريبوستري للحفظ
                bool success = await _roomRepo.AddAsync(newRoom);

                if (success)
                {
                    // إبلاغ الفورم الأب (UC_Rooms) أن العملية تمت بنجاح لتحديث الجدول
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("فشل حفظ الغرفة، حاول مرة أخرى.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}", "خطأ برمجي", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddRoomForm_Load(object sender, EventArgs e)
        {
            panel1.BackColor = AppTheme.Primary;
            BtnCancel.BackColor = Color.Gray;
        }
    }
}
