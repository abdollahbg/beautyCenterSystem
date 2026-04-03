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

        // متغير لحفظ قيمة الخصم الفعلية (بالمال وليس كنسبة) لإرسالها لاحقاً
        private decimal _calculatedDiscountAmount = 0;

        public CheckoutForm(string customerName, decimal totalAmount)
        {
            InitializeComponent();

            // 1. إعدادات الخطوط (خط عريض وواضح للأرقام)
            Font numericFont = new Font("Segoe UI", 14, FontStyle.Bold);

            // 2. ضبط خصائص الحقول
            txtTotalSystem.ReadOnly = true; // غير قابل للتعديل
            txtTotalSystem.BackColor = Color.WhiteSmoke;
            txtTotalSystem.TextAlign = HorizontalAlignment.Center;
            txtTotalSystem.Font = numericFont;

            txtAmountPaid.TextAlign = HorizontalAlignment.Center;
            txtAmountPaid.Font = numericFont;

            // جعل حقل الصافي للقراءة فقط لأنه يُحسب آلياً الآن
            txtNet.ReadOnly = true;
            txtNet.BackColor = Color.WhiteSmoke;
            txtNet.TextAlign = HorizontalAlignment.Center;
            txtNet.Font = numericFont;

            cmbDiscountPercent.Font = numericFont;

            // 3. ضبط القيم الابتدائية
            lblCustomerName.Text = customerName;
            txtTotalSystem.Text = totalAmount.ToString("N2");
            txtAmountPaid.Text = totalAmount.ToString("N2");

            // تحديد القيمة الافتراضية للخصم بـ 0%
            if (cmbDiscountPercent.Items.Count > 0)
                cmbDiscountPercent.SelectedIndex = 0;

            // 4. إضافة خيارات الدفع
            cmbPaymentMethod.Items.Clear();
            cmbPaymentMethod.Items.Add("نقدي (Cash)");
            cmbPaymentMethod.Items.Add("بطاقة (Card)");
            cmbPaymentMethod.SelectedIndex = 0;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            decimal.TryParse(txtNet.Text, out decimal netValue);

            // الإجمالي المدفوع هو الصافي
            this.AmountPaid = netValue;

            // تمرير قيمة الخصم الفعلية المحسوبة في الدالة (بالدينار)
            this.Discount = _calculatedDiscountAmount;

            // تحديد طريقة الدفع بناءً على الاختيار
            if (cmbPaymentMethod.SelectedIndex == 0)
                this.PaymentMethod = "Cash";
            else
                this.PaymentMethod = "Card";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CheckoutForm_Load(object sender, EventArgs e)
        {
            // لا تنسَ التحقق من وجود كلاس AppTheme لديك، وإلا يمكنك مسح هذا السطر
            // AppTheme.Apply(this); 

            CalculateNet();
            btnCancel.BackColor = Color.DarkGray;

            // جعل التركيز يبدأ من "المبلغ المدفوع" لتسهيل العمل
            txtAmountPaid.Focus();
            txtAmountPaid.SelectAll();
        }

        // ملاحظة: تأكد من ربط هذا الحدث بزر الإلغاء في شاشة التصميم
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // الحدث الجديد الخاص بالكومبو بوكس
        private void cmbDiscountPercent_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateNet();
        }

        private void CalculateNet()
        {
            // 1. جلب الإجمالي بأمان
            decimal.TryParse(txtTotalSystem.Text, out decimal total);

            // 2. استخراج النسبة المئوية من الكومبو بوكس
            string selectedDiscount = cmbDiscountPercent.SelectedItem?.ToString() ?? "0%";
            string cleanDiscount = selectedDiscount.Replace("%", "").Trim();
            decimal.TryParse(cleanDiscount, out decimal discountPercent);

            // 3. حساب قيمة الخصم الفعلية
            _calculatedDiscountAmount = total * (discountPercent / 100);

            // 4. الحساب: الصافي = الإجمالي - الخصم الفعلي
            decimal net = total - _calculatedDiscountAmount;

            if (net < 0) net = 0;

            // 5. تحديث خانة الصافي
            txtNet.Text = net.ToString("N2");

            // تحديث حقل "المدفوع" ليكون مطابقاً للصافي لتسهيل العمل على الموظف
            txtAmountPaid.Text = net.ToString("N2");
        }
    }
}