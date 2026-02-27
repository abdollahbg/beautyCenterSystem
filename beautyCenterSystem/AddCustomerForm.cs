using BeautyCenterSystem.Data;
using BeautyCenterSystem.Data.Repositories;
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
    public partial class AddCustomerForm : Form
    {
        private readonly CustomerRepository _repo;
        public AddCustomerForm()
        {
            InitializeComponent();
            _repo = new CustomerRepository(new DbConnectionFactory());
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // إذا ضغط المستخدم Enter وكان التركيز (Focus) "ليس" في حقل الملاحظات
            if (keyData == Keys.Enter && !txtNotes.Focused)
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
        private void AddCustomerForm_Load(object sender, EventArgs e)
        {

            AppTheme.Apply(this);
            PnlHeader.BackColor = AppTheme.Primary;
            BtnCancel.BackColor = Color.Gray;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // الاسم يبقى إجبارياً لتمييز العميلة
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("يرجى إدخال اسم العميل على الأقل.");
                return;
            }

            try
            {
                // 1. معالجة البيانات الاختيارية (إذا كانت فارغة نضع *)
                string customerPhone = string.IsNullOrWhiteSpace(txtPhone.Text) ? "*" : txtPhone.Text.Trim();
                string customerNotes = string.IsNullOrWhiteSpace(txtNotes.Text) ? "*" : txtNotes.Text.Trim();

                // 2. التحقق من تكرار الهاتف (فقط إذا لم يكن النتيجة هي *)
                if (customerPhone != "*")
                {
                    if (await _repo.IsPhoneExistsAsync(customerPhone))
                    {
                        MessageBox.Show("هذا الرقم مسجل مسبقاً لعميل أخرى!");
                        return;
                    }
                }

                // 3. إنشاء الكائن بالبيانات الجديدة
                var newCustomer = new Customer
                {
                    CustomerName = txtName.Text.Trim(),
                    Phone = customerPhone,
                    Notes = customerNotes,
                    CreatedAt = DateTime.Now
                };

                // 4. الحفظ
                if (await _repo.AddAsync(newCustomer))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ: {ex.Message}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

       
    }
}
