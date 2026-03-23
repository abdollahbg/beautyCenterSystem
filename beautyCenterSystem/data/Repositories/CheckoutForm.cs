using System;
using System.Drawing;
using System.Windows.Forms;

namespace beautyCenterSystem.data.Repositories
{
    public partial class CheckoutForm : Form
    {
        public decimal AmountPaid { get; private set; }
        public decimal Discount { get; private set; }
        public string PaymentMethod { get; private set; }

        public CheckoutForm(string customerName, decimal totalAmount)
        {
            InitializeComponent();
            // 1. إعدادات الخطوط (خط عريض وواضح للأرقام)
            Font numericFont = new Font("Segoe UI", 14, FontStyle.Bold);

            // 2. ضبط خصائص الحقول
            txtTotalSystem.ReadOnly = true; // غير قابل للتعديل
            txtTotalSystem.BackColor = Color.WhiteSmoke; // تمييزه لونياً كحقل للقراءة فقط
            txtTotalSystem.TextAlign = HorizontalAlignment.Center;
            txtTotalSystem.Font = numericFont;

            txtAmountPaid.TextAlign = HorizontalAlignment.Center;
            txtAmountPaid.Font = numericFont;

            txtDiscount.TextAlign = HorizontalAlignment.Center;
            txtDiscount.Font = numericFont;

            // 3. ضبط القيم الابتدائية
            lblCustomerName.Text = customerName;
            txtTotalSystem.Text = totalAmount.ToString("N2");
            txtAmountPaid.Text = totalAmount.ToString("N2");
            txtDiscount.Text = "0.00"; // قيمة افتراضية للخصم لمنع خطأ التحويل

            // 1. إضافة الخيارات أولاً
            cmbPaymentMethod.Items.Add("نقدي (Cash)");
            cmbPaymentMethod.Items.Add("بطاقة (Card)");


            cmbPaymentMethod.SelectedIndex = 0;
        }

        // تعديل طريقة جلب قيمة الدفع في زر التأكيد
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            decimal.TryParse(txtNet.Text, out decimal netValue);
            decimal.TryParse(txtDiscount.Text, out decimal discountValue);

            this.AmountPaid = netValue;
            this.Discount = discountValue;

            // --- التعديل هنا ---
            // بدلاً من أخذ النص الكامل، نتحقق من الخيار المختار
            if (cmbPaymentMethod.SelectedIndex == 0)
                this.PaymentMethod = "Cash";
            else
                this.PaymentMethod = "Card";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        private void CheckoutForm_Load(object sender, EventArgs e)
        {
            AppTheme.Apply(this);
            CalculateNet();
            btnCancel.BackColor = Color.DarkGray;

            // جعل التركيز يبدأ من "المبلغ المدفوع" لتسهيل العمل
            txtAmountPaid.Focus();
            txtAmountPaid.SelectAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // داخل CheckoutForm.cs

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateNet();
        }

        private void CalculateNet()
        {
            // تحويل القيم بأمان
            decimal total = 0;
            decimal discount = 0;

            decimal.TryParse(txtTotalSystem.Text, out total);
            decimal.TryParse(txtDiscount.Text, out discount);

            // الحساب: الصافي = الإجمالي - الخصم
            decimal net = total - discount;

            if (net < 0) net = 0;

            // تحديث خانة الصافي
            txtNet.Text = net.ToString("N2");
        }
    }
}