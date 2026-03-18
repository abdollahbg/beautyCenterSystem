using beautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beautyCenterSystem.data.Repositories
{
    public partial class UserEditForm : Form
    {
        private readonly UserRepository _userRepo;
        private readonly int _userId;
        private readonly string _currentUsername;
        private readonly int _currentRoleId;

        public UserEditForm(int userId, string username, int roleId)
        {
            InitializeComponent();

            // تهيئة المستودع
            _userRepo = new UserRepository(new DbConnectionFactory());

            _userId = userId;
            _currentUsername = username;
            _currentRoleId = roleId;

            AppTheme.Apply(this);
            PnlHeader.BackColor = AppTheme.Primary;
            BtnCancel.BackColor = Color.DarkGray;

            this.Load += UserEditForm_Load;
            btnSave.Click += btnSave_Click;
            BtnCancel.Click += (s, e) => this.Close();
        }

        private async void UserEditForm_Load(object sender, EventArgs e)
        {
            await LoadRolesAsync();

            // تعبئة البيانات المستلمة في الحقول
            txtUsername.Text = _currentUsername;
            cmbRole.SelectedValue = _currentRoleId;
        }

        private async Task LoadRolesAsync()
        {
            try
            {
                var roles = await _userRepo.GetAllRolesAsync();
                if (roles != null)
                {
                    cmbRole.DataSource = roles.ToList();
                    cmbRole.DisplayMember = "RoleName";
                    cmbRole.ValueMember = "RoleID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل الأدوار: {ex.Message}");
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text)) return;

            try
            {
                btnSave.Enabled = false;

                // استدعاء المنطق من الـ Repository
                bool success = await _userRepo.UpdateUserBasicInfoAsync(
                    _userId,
                    txtUsername.Text.Trim(),
                    Convert.ToInt32(cmbRole.SelectedValue)
                );

                if (success)
                {
                    MessageBox.Show("تم التحديث بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}");
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }
    }
}