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
    public partial class RoleCreateForm : Form
    {
        // 1. تعريف المستودع
        private readonly UserRepository _userRepo;

        public RoleCreateForm()
        {
            InitializeComponent();

            // 2. تهيئة المستودع محلياً داخل الكونستركتر
            _userRepo = new UserRepository(new DbConnectionFactory());

            // 3. تطبيق التنسيقات
            AppTheme.Apply(this);
            PnlHeader.BackColor = AppTheme.Primary;
            BtnCancel.BackColor = Color.DarkGray;

            // 4. ربط الأحداث
            btnSave.Click += btnSave_Click;
            BtnCancel.Click += (s, e) => this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // التحقق من إدخال اسم الدور (بدون تشكيل في اسم المتغير)
            if (string.IsNullOrWhiteSpace(txtRoleName.Text))
            {
                MessageBox.Show("يرجى إدخال اسم الدور أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoleName.Focus();
                return;
            }

            try
            {
                btnSave.Enabled = false; // تعطيل الزر مؤقتاً

                string roleName = txtRoleName.Text.Trim();

                // استدعاء المنطق من الـ Repository
                bool isCreated = await _userRepo.CreateRoleAsync(roleName);

                if (isCreated)
                {
                    MessageBox.Show("تم إضافة الدور الجديد بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // لإغلاق الفورم وتحديث القائمة في الشاشة الرئيسية
                    this.Close();
                }
                else
                {
                    MessageBox.Show("فشلت عملية الإضافة، ربما اسم الدور مكرر", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء الحفظ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true; // إعادة تفعيل الزر
            }
        }
    }
}