using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BeautyCenterSystem.Models; // تأكد من وجود الـ Model الخاص بك

namespace beautyCenterSystem
{
    public partial class UC_CartSummary : UserControl
    {
        // الأحداث للتواصل مع الفورم الرئيسي
        public event EventHandler OnAddCustomerClicked;
        public event EventHandler OnSaveAppointmentClicked;
        public event EventHandler<int> OnRemoveServiceRequested;

        private decimal _lastTotal = 0; // لحفظ الإجمالي قبل الخصم

        public UC_CartSummary()
        {
            InitializeComponent();
            SetupCustomEvents();

            // تعيين القيمة الافتراضية للخصم لمنع قيم الـ null
            cmbDiscountPercent.SelectedIndex = 0; // 0%
        }

        private void SetupCustomEvents()
        {
            // ربط أحداث الأزرار
            btnAddCustomer.Click += (s, e) => OnAddCustomerClicked?.Invoke(this, e);
            btnSave.Click += (s, e) => OnSaveAppointmentClicked?.Invoke(this, e);

            // حدث حذف خدمة من السلة
            dgvCart.CellContentClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvCart.Columns[e.ColumnIndex].Name == "DeleteCol")
                {
                    int id = (int)dgvCart.Rows[e.RowIndex].Cells["IDCol"].Value;
                    OnRemoveServiceRequested?.Invoke(this, id);
                }
            };

            // حدث تغيير نسبة الخصم
            cmbDiscountPercent.SelectedIndexChanged += (s, e) => CalculateSummary();
        }

        // دالة لتحديث قائمة الخدمات وحساب الإجمالي
        public void RefreshCart(List<Service> services)
        {
            dgvCart.Rows.Clear();
            _lastTotal = 0;

            if (services != null)
            {
                foreach (var service in services)
                {
                    dgvCart.Rows.Add(service.ServiceID, service.ServiceName, service.Price.ToString("N2"), "❌");
                    _lastTotal += service.Price;
                }
            }

            CalculateSummary();
        }

        // دالة الحسابات المركزية (الإجمالي، الخصم، الصافي)
        private void CalculateSummary()
        {
            // 1. استخراج النسبة المئوية من الكومبو بوكس (مثلاً "10%" تصبح 10)
            string discountStr = cmbDiscountPercent.SelectedItem?.ToString().Replace("%", "") ?? "0";
            decimal discountPercent = decimal.Parse(discountStr);

            // 2. حساب قيمة الخصم بالدينار
            decimal discountAmount = _lastTotal * (discountPercent / 100);

            // 3. حساب الصافي
            decimal finalNet = _lastTotal - discountAmount;

            // 4. تحديث الواجهة
            lblSubTotalValue.Text = $"{_lastTotal:N2} د.ل";

            // عرض قيمة الخصم بجانب النص التوضيحي أو في مكان الصافي (حسب حاجتك)
            // هنا سنعرض الصافي في الليبل الكبير الرئيسي
            lblTotalPrice.Text = $"{finalNet:N2} د.ل";

            // إذا أردت تحديث نص الخصم ليظهر المبلغ المخصوم:
            lblDiscountText.Text = $"نسبة الخصم ({discountAmount:N2} د.ل):";
        }

        // دالة لتعبئة كومبو بوكس العميلات
        public void FillCustomers(object dataSource)
        {
            cmbCustomers.DataSource = dataSource;
            cmbCustomers.DisplayMember = "CustomerName";
            cmbCustomers.ValueMember = "CustomerID";
            cmbCustomers.SelectedIndex = -1;
        }

        public int? SelectedCustomerId
        {
            get => (int?)cmbCustomers.SelectedValue;
            set => cmbCustomers.SelectedValue = value;
        }

        // خصائص إضافية قد تحتاجها عند حفظ الفاتورة في قاعدة البيانات
        public decimal TotalBeforeDiscount => _lastTotal;
        public decimal DiscountPercentage
        {
            get
            {
                string val = cmbDiscountPercent.SelectedItem?.ToString().Replace("%", "") ?? "0";
                return decimal.Parse(val);
            }
        }
        public decimal FinalAmount => decimal.Parse(lblTotalPrice.Text.Replace(" د.ل", ""));
    }
}