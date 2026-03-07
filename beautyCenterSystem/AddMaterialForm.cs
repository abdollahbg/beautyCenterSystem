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

namespace beautyCenterSystem
{
    public partial class AddMaterialForm : Form
    {
        private readonly MaterialRepository _materialRepo;

        public AddMaterialForm()
        {
            InitializeComponent();
            _materialRepo = new MaterialRepository(new DbConnectionFactory());
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // 1. التحقق من صحة المدخلات (Validation)
            if (string.IsNullOrWhiteSpace(txtMaterialName.Text))
            {
                MessageBox.Show("يرجى إدخال اسم الخامة أو المادة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaterialName.Focus();
                return;
            }

            try
            {
                // 2. إنشاء كائن المادة الجديد بالبيانات من الواجهة
                var newMaterial = new Material
                {
                    MaterialName = txtMaterialName.Text.Trim(),
                    IsAvailable = chkIsAvailable.Checked // تأكد أن هذا هو اسم الـ CheckBox لديك
                };

                // 3. استدعاء الريبو للحفظ في قاعدة البيانات
                // ملاحظة: تأكد أنك قمت بتعريف _materialRepo في الـ Constructor الخاص بالفورم
                bool isSuccess = await _materialRepo.CreateAsync(newMaterial);

                if (isSuccess)
                {
                    // 4. في حال النجاح، نضبط نتيجة الفورم ونغلقه
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("لم يتم حفظ البيانات، يرجى المحاولة مرة أخرى.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // معالجة أي أخطاء غير متوقعة (مثل مشاكل الاتصال بقاعدة البيانات)
                MessageBox.Show($"حدث خطأ أثناء عملية الحفظ: {ex.Message}", "خطأ نظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void AddMaterialForm_Load(object sender, EventArgs e)
        {
            AppTheme.Apply(this);
            PnlHeader.BackColor = AppTheme.Primary;
            BtnCancel.BackColor = Color.Gray;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }
    }
}
