using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using BeautyCenterSystem.Models; // تأكد من وجود الموديلات هنا
using System;
using System.Drawing;
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

        // دالة تصفح واختيار الأيقونة
        private void btnBrowseIcon_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "اختر أيقونة للغرفة";
                ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtIconPath.Text = ofd.FileName;
                }
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomName2.Text))
            {
                MessageBox.Show("يرجى إدخال اسم الغرفة أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoomName2.Focus();
                return;
            }

            try
            {
                // تم إضافة IconPath هنا
                var newRoom = new Room
                {
                    RoomName = txtRoomName2.Text.Trim(),
                    IconPath = txtIconPath.Text.Trim()
                };

                bool success = await _roomRepo.AddAsync(newRoom);

                if (success)
                {
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

            // تنسيق بسيط لزر التصفح ليناسب المظهر
            btnBrowseIcon.BackColor = Color.White;
            btnBrowseIcon.FlatStyle = FlatStyle.Flat;
            btnBrowseIcon.FlatAppearance.BorderColor = Color.LightGray;
        }
    }
}