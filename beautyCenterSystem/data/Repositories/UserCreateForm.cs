using beautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beautyCenterSystem.data.Repositories
{
    public partial class UserCreateForm : Form
    {
        // 1. تعريف الـ Repository
        private readonly UserRepository _userRepo;

        public UserCreateForm()
        {
            InitializeComponent();

            // 2. إنشاء الـ Repository داخل الكونستركتر كما تفعلون
            _userRepo = new UserRepository(new DbConnectionFactory());

            // 3. تطبيق الثيم (AppTheme)
            AppTheme.Apply(this);
            PnlHeader.BackColor = AppTheme.Primary;
            BtnCancel.BackColor = Color.DarkGray;

            // 4. إعدادات حقل كلمة المرور (إخفاء النص المكتوب)
            txtPassword.PasswordChar = '●';
            txtPassword.UseSystemPasswordChar = true;

            // 5. ربط الأحداث
            this.Load += UserCreateForm_Load;
            btnSave.Click += btnSave_Click;
            BtnCancel.Click += BtnCancel_Click;
        }

        private async void UserCreateForm_Load(object sender, EventArgs e)
        {
            await LoadRolesAsync();
        }

        // جلب الأدوار لملء الكومبو بوكس
        private async Task LoadRolesAsync()
        {
            try
            {
                var roles = await _userRepo.GetAllRolesAsync();

                if (roles != null && roles.Any())
                {
                    cmbRole.DataSource = roles.ToList();
                    cmbRole.DisplayMember = "RoleName";
                    cmbRole.ValueMember = "RoleID";

                    // اختيار أول عنصر كافتراضي
                    cmbRole.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل الأدوار: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // 1. التحقق من المدخلات (Validation)
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("يرجى إدخال اسم المستخدم.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("يرجى إدخال كلمة المرور.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (cmbRole.SelectedValue == null)
            {
                MessageBox.Show("يرجى اختيار الدور الوظيفي.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRole.Focus();
                return;
            }

            // 2. محاولة الحفظ
            try
            {
                btnSave.Enabled = false; // تعطيل الزر لمنع الضغط المزدوج

                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text; // الـ Repo سيقوم بالتشفير
                int roleId = Convert.ToInt32(cmbRole.SelectedValue);

                bool isSaved = await _userRepo.CreateUserAsync(username, password, roleId);

                if (isSaved)
                {
                    MessageBox.Show("تم إضافة المستخدم بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // إرجاع النتيجة للفورم الأب لتحديث الجريد
                    this.Close();
                }
                else
                {
                    MessageBox.Show("لم يتم الحفظ. قد يكون اسم المستخدم موجوداً مسبقاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء حفظ المستخدم: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true; // إعادة تفعيل الزر في حالة حدوث خطأ
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}