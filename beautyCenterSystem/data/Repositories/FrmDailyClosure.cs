using System;
using System.Drawing;
using System.Windows.Forms;
using beautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using beautyCenterSystem.viewsmodels; // تأكد من استدعاء مسار الـ DTO الصحيح
using BeautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;

namespace beautyCenterSystem.data.Repositories
{
    public partial class FrmDailyClosure : Form
    {
        private readonly FinancialRepository _financialRepo;

        // متغيرات لتخزين القيم المسترجعة من النظام
        private decimal _cashSystem = 0;
        private decimal _cardSystem = 0;
        private decimal _totalExpenses = 0;
        private decimal _totalPurchases = 0;
        private decimal _expectedCash = 0;

        public FrmDailyClosure()
        {
            InitializeComponent();

            // إعداد التبعيات
            var factory = new DbConnectionFactory();
            _financialRepo = new FinancialRepository(factory);

            // ربط الأحداث البرمجية
            this.Load += FrmDailyClosure_Load;
            txtActualCash.TextChanged += TxtActualCash_TextChanged;
            txtActualCash.KeyPress += TxtActualCash_KeyPress;
            btnSaveClosure.Click += BtnSaveClosure_Click;
            btnCancel.Click += (s, e) => this.Close();
        }

        private async void FrmDailyClosure_Load(object sender, EventArgs e)
        {
            // 1. تطبيق التصميم العام
            AppTheme.Apply(this);
            CustomizeNumericLabels();

            try
            {
                // 2. جلب البيانات المالية لليوم الحالي
                var summary = await _financialRepo.GetDailyFinancialSummaryAsync();

                if (summary != null)
                {
                    // تخزين القيم في المتغيرات المحلية
                    _cashSystem = summary.TotalCashIn;
                    _cardSystem = summary.TotalCardIn;
                    _totalExpenses = summary.TotalExpenses;
                    _totalPurchases = summary.TotalPurchases;

                    // الاعتماد على المعادلة الموجودة داخل الـ DTO
                    _expectedCash = summary.ExpectedCash;

                    // عرض البيانات في الواجهة
                    lblCashSystem.Text = _cashSystem.ToString("N2");
                    lblCardSystem.Text = _cardSystem.ToString("N2");

                    // عرض إجمالي الخارج (مصروفات + مشتريات)
                    lblOutgoings.Text = (_totalExpenses + _totalPurchases).ToString("N2");

                    lblExpectedCash.Text = _expectedCash.ToString("N2");

                    // تحديث الفارق المبدئي (باعتبار النقد الفعلي 0 في البداية)
                    CalculateDifference();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب البيانات المالية: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeNumericLabels()
        {
            // تنسيق الألوان لتمييز القيم المالية
            lblCashSystem.ForeColor = Color.FromArgb(0, 120, 215); // أزرق للإيراد
            lblCashSystem.Font = new Font(lblCashSystem.Font, FontStyle.Bold);

            lblCardSystem.ForeColor = Color.FromArgb(0, 120, 215);
            lblCardSystem.Font = new Font(lblCardSystem.Font, FontStyle.Bold);

            lblOutgoings.ForeColor = Color.FromArgb(211, 47, 47); // أحمر للمصروفات
            lblOutgoings.Font = new Font(lblOutgoings.Font, FontStyle.Bold);

            lblExpectedCash.ForeColor = Color.FromArgb(46, 125, 50); // أخضر للصافي المتوقع
            lblExpectedCash.Font = new Font(lblExpectedCash.Font, FontStyle.Bold);

            // تنسيق أزرار التحكم
            btnSaveClosure.BackColor = Color.MediumSeaGreen;
            btnSaveClosure.ForeColor = Color.White;
            btnCancel.BackColor = Color.LightCoral;
            btnCancel.ForeColor = Color.White;
        }

        private void TxtActualCash_TextChanged(object sender, EventArgs e)
        {
            CalculateDifference();
        }

        private void CalculateDifference()
        {
            // قراءة النقد الفعلي المدخل من قبل المستخدم
            if (!decimal.TryParse(txtActualCash.Text, out decimal actualCash))
            {
                actualCash = 0;
            }

            // حساب الفرق: (ما هو موجود فعلياً) - (ما يجب أن يكون موجوداً حسب النظام)
            decimal difference = actualCash - _expectedCash;

            // تلوين الفارق ديناميكياً
            if (difference < 0)
            {
                lblDifference.Text = $"عجز بقيمة: {Math.Abs(difference):N2}";
                lblDifference.ForeColor = Color.Red;
            }
            else if (difference > 0)
            {
                lblDifference.Text = $"زيادة بقيمة: {difference:N2}";
                lblDifference.ForeColor = Color.ForestGreen;
            }
            else
            {
                lblDifference.Text = "الصندوق مطابق تماماً (0.00)";
                lblDifference.ForeColor = Color.DimGray;
            }
        }

        private void TxtActualCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            // منع إدخال أي شيء غير الأرقام والفاصلة العشرية
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // منع تكرار الفاصلة العشرية
            if ((e.KeyChar == '.') && (txtActualCash.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private async void BtnSaveClosure_Click(object sender, EventArgs e)
        {
            // 1. التحقق من صحة المدخلات
            if (string.IsNullOrWhiteSpace(txtActualCash.Text) || !decimal.TryParse(txtActualCash.Text, out decimal actualCash))
            {
                MessageBox.Show("يرجى إدخال المبلغ النقدي الموجود في الدرج بشكل صحيح.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtActualCash.Focus();
                return;
            }

            // 2. طلب تأكيد من المستخدم (أمان إضافي)
            var confirm = MessageBox.Show("هل أنت متأكد من حفظ إغلاق اليوم؟ لا يمكن التعديل بعد الحفظ.",
                                         "تأكيد العملية", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                btnSaveClosure.Enabled = false;

                // 3. إرسال البيانات للحفظ في قاعدة البيانات
                // تم تمرير القيم الأربع (كاش، شبكة، مصروفات، مشتريات) ليقوم الـ Repository بحساب الـ Difference بدقة
                bool success = await _financialRepo.SaveDailyClosureAsync(
                    _cashSystem,
                    _cardSystem,
                    _totalExpenses,
                    _totalPurchases,
                    actualCash,
                    CurrentSession.UserID,
                    txtNotes.Text.Trim()
                );

                if (success)
                {
                    MessageBox.Show("تم توثيق إغلاق الحساب بنجاح وتصفير العجز/الزيادة دفترياً.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("فشل في حفظ بيانات الإغلاق، يرجى مراجعة الاتصال بقاعدة البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSaveClosure.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}", "خطأ نظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSaveClosure.Enabled = true;
            }
        }
    }
}