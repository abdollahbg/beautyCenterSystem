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
            // تهيئة الريبوزيتوري
            _materialRepo = new MaterialRepository(new DbConnectionFactory());
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // 1. التحقق من صحة المدخلات (Validation)
            if (string.IsNullOrWhiteSpace(txtMaterialName.Text))
            {
                MessageBox.Show("يرجى إدخال اسم المادة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaterialName.Focus();
                return;
            }

            // التحقق من صحة السعر والكمية (تحويل آمن)
            decimal.TryParse(txtSalePrice.Text, out decimal salePrice);
            int.TryParse(txtStockQuantity.Text, out int stockQty);

            try
            {
                // 2. إنشاء كائن المادة الجديد بالبيانات المحدثة
                var newMaterial = new Material
                {
                    MaterialName = txtMaterialName.Text.Trim(),
                    SalePrice = salePrice,
                    StockQuantity = stockQty,
                    IsAvailable = chkIsAvailable.Checked,
                    IsCaffeteriaItem = chkIsCaffeteria.Checked,
                    IsActive = true // افتراضياً المادة مضافة كنشطة
                };

                // 3. استدعاء الريبو للحفظ في قاعدة البيانات
                // ملاحظة: تأكد أن اسم الدالة في الريبو هو CreateAsync أو AddAsync
                bool isSuccess = await _materialRepo.CreateAsync(newMaterial);

                if (isSuccess)
                {
                    MessageBox.Show("تمت إضافة المادة بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show($"حدث خطأ أثناء عملية الحفظ: {ex.Message}", "خطأ نظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Enter للحفظ
            if (keyData == Keys.Enter)
            {
                btnSave.PerformClick();
                return true;
            }

            // Esc للإلغاء
            if (keyData == Keys.Escape)
            {
                BtnCancel.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void AddMaterialForm_Load(object sender, EventArgs e)
        {
            // تطبيق الثيم العام
            AppTheme.Apply(this);

            // تخصيص الألوان بناءً على AppTheme
            PnlHeader.BackColor = AppTheme.Charcoal;
            label1.ForeColor = Color.White;

            // تنسيق الأزرار
            btnSave.BackColor = AppTheme.Primary;
            btnSave.ForeColor = Color.White;

            BtnCancel.BackColor = Color.Gray;
            BtnCancel.ForeColor = Color.White;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}