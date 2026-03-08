using MaterialSkin.Controls;
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
    public partial class frmAddSafe : Form
    {
        // خصائص عامة لنقل البيانات للفورم الرئيسي
        public string SafeName { get; private set; }
        public decimal InitialBalance { get; private set; }

        public frmAddSafe()
        {
            InitializeComponent();
        }

        private void txtInitialBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            // السماح بالأرقام، المفتاح الخلفي (Backspace)، والفاصلة العشرية فقط
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // السماح بفاصلة عشرية واحدة فقط
            if ((e.KeyChar == '.') && ((sender as MaterialTextBox2).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnSaveSafe_Click(object sender, EventArgs e)
        {
            // 1. التأكد من اسم الخزنة
            if (string.IsNullOrWhiteSpace(txtSafeName.Text))
            {
                MessageBox.Show("يرجى إدخال اسم الخزنة أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSafeName.Focus();
                return;
            }

            // 2. التحقق من الرصيد الافتتاحي (إذا تركه فارغاً نعتبره 0)
            string balanceText = string.IsNullOrWhiteSpace(txtInitialBalance.Text) ? "0" : txtInitialBalance.Text;

            if (!decimal.TryParse(balanceText, out decimal initialBalance))
            {
                MessageBox.Show("يرجى إدخال مبلغ صحيح في خانة الرصيد.", "خطأ في البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInitialBalance.Focus();
                return;
            }

            // 3. منع الرصيد السالب عند التأسيس
            if (initialBalance < 0)
            {
                MessageBox.Show("لا يمكن بدء الخزنة برصيد سالب.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // تعبئة الخصائص بالقيم النهائية
            SafeName = txtSafeName.Text.Trim();
            InitialBalance = initialBalance;

            // إعطاء إشارة نجاح وإغلاق الفورم
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // إغلاق الفورم دون حفظ
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmAddSafe_Load(object sender, EventArgs e)
        {
            AppTheme.Apply(this);
            
            PnlHeader.BackColor = AppTheme.Primary;
            BtnCancel.BackColor = Color.Gray;
        }
    }
}