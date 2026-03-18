using beautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beautyCenterSystem.data.Repositories
{
    public partial class DeleteUserModal : Form
    {
        private readonly UserRepository _userRepo;
        private readonly int _targetUserId; // المستخدم المراد حذفه
        private readonly int _currentAdminId; // الأدمن الحالي لتأكيد كلمة مروره

        public DeleteUserModal(int targetUserId, int currentAdminId)
        {
            InitializeComponent();
            _userRepo = new UserRepository(new DbConnectionFactory());

            _targetUserId = targetUserId;
            _currentAdminId = currentAdminId;

            // إعدادات الواجهة
            AppTheme.Apply(this);
            BtnCancel.BackColor = Color.DarkGray;
            btnSave.Text = "تأكيد الحذف";
            btnSave.BackColor = Color.Crimson; // لون أحمر للتنبيه
            btnSave.ForeColor = Color.White;

            txtPassword.PasswordChar = '●';
            txtPassword.UseSystemPasswordChar = true;

            // الأحداث
            btnSave.Click += btnSave_Click;
            BtnCancel.Click += (s, e) => this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("يرجى إدخال كلمة المرور للتأكيد.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnSave.Enabled = false;

                // 1. التحقق من صحة كلمة مرور الشخص الذي يحذف
                bool isValid = await _userRepo.VerifyPasswordAsync(_currentAdminId, password);

                if (!isValid)
                {
                    MessageBox.Show("كلمة المرور غير صحيحة، لا يمكن إتمام الحذف.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. تنفيذ عملية الحذف
                bool isDeleted = await _userRepo.DeleteUserAsync(_targetUserId);

                if (isDeleted)
                {
                    MessageBox.Show("تم حذف المستخدم بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}");
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }
    }
}