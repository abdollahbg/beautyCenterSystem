using System;
using System.Drawing;
using System.Windows.Forms;
using beautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;

namespace beautyCenterSystem.data.Repositories
{
    public partial class FrmDailyClosure : Form
    {
        private readonly FinancialRepository _financialRepo;

        private decimal _cashSystem = 0;
        private decimal _cardSystem = 0;
        private decimal _totalExpenses = 0;
        private decimal _totalPurchases = 0;
        private decimal _expectedCash = 0;

        public FrmDailyClosure()
        {
            InitializeComponent();

            var factory = new DbConnectionFactory();
            _financialRepo = new FinancialRepository(factory);

            // ربط الأحداث
            this.Load += FrmDailyClosure_Load;
            txtActualCash.TextChanged += TxtActualCash_TextChanged;
            txtActualCash.KeyPress += TxtActualCash_KeyPress;
            btnSaveClosure.Click += BtnSaveClosure_Click;
            btnCancel.Click += (s, e) => this.Close();
        }

        private async void FrmDailyClosure_Load(object sender, EventArgs e)
        {
            // 1. تطبيق الثيم العام أولاً
            AppTheme.Apply(this);

            // 2. تخصيص ألوان ليبلز الأرقام (للوضوح العالي)
            CustomizeNumericLabels();

            try
            {
                var summary = await _financialRepo.GetDailyFinancialSummaryAsync();

                if (summary != null)
                {
                    _cashSystem = summary.TotalCashIn;
                    _cardSystem = summary.TotalCardIn;
                    _totalExpenses = summary.TotalExpenses;
                    _totalPurchases = summary.TotalPurchases;
                    _expectedCash = summary.ExpectedCash;

                    lblCashSystem.Text = _cashSystem.ToString("N2");
                    lblCardSystem.Text = _cardSystem.ToString("N2");
                    lblOutgoings.Text = (_totalExpenses + _totalPurchases).ToString("N2");
                    lblExpectedCash.Text = _expectedCash.ToString("N2");

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
            // تمييز أرقام الإيرادات باللون الأزرق الغامق
            lblCashSystem.ForeColor = Color.FromArgb(0, 120, 215);
            lblCashSystem.Font = new Font(lblCashSystem.Font, FontStyle.Bold);

            lblCardSystem.ForeColor = Color.FromArgb(0, 120, 215);
            lblCardSystem.Font = new Font(lblCardSystem.Font, FontStyle.Bold);

            // تمييز المصروفات باللون البرتقالي المحروق أو الأحمر الهادئ
            lblOutgoings.ForeColor = Color.FromArgb(211, 47, 47);
            lblOutgoings.Font = new Font(lblOutgoings.Font, FontStyle.Bold);

            // تمييز الرصيد المتوقع باللون الأخضر الغامق (لأنه الهدف)
            lblExpectedCash.ForeColor = Color.FromArgb(46, 125, 50);
            lblExpectedCash.Font = new Font(lblExpectedCash.Font, FontStyle.Bold);
            // تصحيح السينتكس وتبديل الألوان ليكون الحفظ أخضر والإلغاء أحمر
            btnSaveClosure.BackColor = Color.MediumSeaGreen; // اللون الأخضر للحفظ
            btnCancel.BackColor = Color.LightCoral;        // اللون الأحمر/المرجاني للإلغاء
        }

        private void TxtActualCash_TextChanged(object sender, EventArgs e)
        {
            CalculateDifference();
        }

        private void CalculateDifference()
        {
            decimal actualCash = 0;
            if (!string.IsNullOrWhiteSpace(txtActualCash.Text))
            {
                decimal.TryParse(txtActualCash.Text, out actualCash);
            }

            decimal difference = actualCash - _expectedCash;

            // تلوين ديناميكي للفارق (عجز/زيادة)
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
            // السماح بالأرقام والفاصلة العشرية فقط
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && (txtActualCash.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private async void BtnSaveClosure_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtActualCash.Text))
            {
                MessageBox.Show("يرجى إدخال المبلغ الموجود في الدرج.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtActualCash.Focus();
                return;
            }

            try
            {
                btnSaveClosure.Enabled = false;
                decimal actualCash = decimal.Parse(txtActualCash.Text);

                bool success = await _financialRepo.SaveDailyClosureAsync(
                    _cashSystem,
                    _cardSystem,
                    _totalExpenses,
                    _totalPurchases,
                    actualCash,
                    1, // يمكنك استبداله لاحقاً بـ GlobalUser.ID
                    txtNotes.Text
                );

                if (success)
                {
                    MessageBox.Show("تم توثيق إغلاق الحساب بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("فشل في حفظ البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSaveClosure.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ نظام: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSaveClosure.Enabled = true;
            }
        }
    }
}