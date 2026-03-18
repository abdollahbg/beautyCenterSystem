using beautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beautyCenterSystem.data.Repositories
{
    public partial class PasswordResetForm : Form
    {
        private readonly UserRepository _userRepo;
        private readonly int _userId;
        private readonly string _username;

        public PasswordResetForm(int userId, string username)
        {
            InitializeComponent();
            _userRepo = new UserRepository(new DbConnectionFactory());

            _userId = userId;
            _username = username;

            // إعدادات الواجهة والتنسيق
            AppTheme.Apply(this);
            PnlHeader.BackColor = AppTheme.Primary;
            BtnCancel.BackColor = Color.DarkGray;

            // ضبط الحقول
            txtUsername.Text = _username;
            txtUsername.ReadOnly = true; // لا يسمح بتغيير الاسم هنا

            txtNewPassword.PasswordChar = '●';
            txtConfirmNewPassword.PasswordChar = '●';

            // ربط الأحداث
            btnSave.Click += btnSave_Click;
            BtnCancel.Click += (s, e) => this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // 1. التحقق من المدخلات
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmNewPassword.Text))
            {
                MessageBox.Show("يرجى إدخال كلمة المرور وتأكيدها.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. التحقق من تطابق كلمتي المرور
            if (txtNewPassword.Text != txtConfirmNewPassword.Text)
            {
                MessageBox.Show("كلمات المرور غير متطابقة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                btnSave.Enabled = false;

                // 3. استدعاء الريبو لتنفيذ التغيير
                bool success = await _userRepo.ResetPasswordAsync(_userId, txtNewPassword.Text.Trim());

                if (success)
                {
                    MessageBox.Show($"تم تغيير كلمة المرور للمستخدم {_username} بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء التحديث: {ex.Message}");
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }
    }
}