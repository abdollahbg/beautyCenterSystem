using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeautyCenterSystem.Data;
using BeautyCenterSystem.Data.Repositories;
using beautyCenterSystem.data.Repositories;

namespace beautyCenterSystem.data.Repositories
{
    public partial class EmployeePaymentForm : Form
    {
        private readonly EmployeeRepository _employeeRepo;
        private readonly FinancialRepository _financialRepo;
        private readonly int _currentUserId;

        // الخاصية المطلوبة لاستقبال معرف الموظفة من الشاشة الخارجية
        public int? SelectedEmployeeId { get; set; }

        public EmployeePaymentForm(int userId)
        {
            InitializeComponent();

            // إعداد مصنع الاتصال والريبوزات
            var dbFactory = new DbConnectionFactory();
            _employeeRepo = new EmployeeRepository(dbFactory);
            _financialRepo = new FinancialRepository(dbFactory);

            _currentUserId = userId;

            // ربط الأحداث
            this.Load += EmployeePaymentForm_Load;
            cmbEmployee.SelectedIndexChanged += cmbEmployee_SelectedIndexChanged;
            btnSave.Click += btnSave_Click; // تأكد من ربط حدث الزر هنا إذا لم يكن مربوطاً في المصمم
            AppTheme.Apply(this);
        }

        private async void EmployeePaymentForm_Load(object sender, EventArgs e)
        {
            // 1. تحميل البيانات الأساسية أولاً (الموظفات والخزنات)
            await LoadInitialData();

            // 2. إذا تم تمرير معرف موظفة، قم باختيارها في الكومبو بوكس
            if (SelectedEmployeeId.HasValue)
            {
                cmbEmployee.SelectedValue = SelectedEmployeeId.Value;

                // 3. استدعاء جلب الأرصدة يدوياً لضمان تحديث الواجهة فور الفتح
                await RefreshEmployeeBalances(SelectedEmployeeId.Value);
            }
        }

        private async Task LoadInitialData()
        {
            try
            {
                // تحميل قائمة الموظفات النشطات
                var employees = await _employeeRepo.GetAllEmployeesAsync();
                cmbEmployee.DataSource = employees.Where(x => x.IsActive).ToList();
                cmbEmployee.DisplayMember = "EmployeeName";
                cmbEmployee.ValueMember = "EmployeeID";
                cmbEmployee.SelectedIndex = -1;
                
                // Store all employees to access their type easily
                cmbEmployee.Tag = employees.ToList();

                // تحميل قائمة الخزنات
                var safes = await _financialRepo.GetAllSafesAsync();
                cmbSafe.DataSource = safes.ToList();
                cmbSafe.DisplayMember = "SafeName";
                cmbSafe.ValueMember = "SafeID";
                cmbSafe.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل البيانات الأولية: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            // جلب الأرصدة فقط عند اختيار قيمة صحيحة (ليست -1 أو null)
            if (cmbEmployee.SelectedValue is int empId)
            {
                await RefreshEmployeeBalances(empId);
            }
        }

        private async Task RefreshEmployeeBalances(int empId)
        {
            try
            {
                var allEmps = cmbEmployee.Tag as List<beautyCenterSystem.Employee>;
                var selectedEmp = allEmps?.FirstOrDefault(e => e.EmployeeID == empId);

                if (selectedEmp != null && selectedEmp.EmployeeType == "Salary")
                {
                    // Salary logic
                    decimal baseSalary = selectedEmp.BaseSalary;
                    decimal totalPaid = await _employeeRepo.GetTotalPaidAsync(empId); // this gets total paid forever, maybe we just show it
                    
                    txtTotalEarned.Text = baseSalary.ToString("N2");
                    txtTotalPaid.Text = totalPaid.ToString("N2");
                    txtRemainingBalance.Text = "N/A (راتب)";
                }
                else
                {
                    // Commission logic
                    decimal totalEarned = await _employeeRepo.GetTotalEarnedAsync(empId);
                    decimal totalPaid = await _employeeRepo.GetTotalPaidAsync(empId);
                    decimal remaining = totalEarned - totalPaid;

                    // تحديث حقول العرض في الواجهة
                    txtTotalEarned.Text = totalEarned.ToString("N2");
                    txtTotalPaid.Text = totalPaid.ToString("N2");
                    txtRemainingBalance.Text = remaining.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحديث أرصدة الموظفة: {ex.Message}");
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // التحقق من صحة الاختيارات
            if (cmbEmployee.SelectedValue == null || cmbSafe.SelectedValue == null)
            {
                MessageBox.Show("يرجى اختيار الموظفة والخزنة أولاً.", "تنبيه");
                return;
            }

            // التحقق من صحة المبلغ المدخل
            if (!decimal.TryParse(txtAmountToPay.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("يرجى إدخال مبلغ صرف صحيح.", "تنبيه");
                return;
            }

            // التحقق من أن المبلغ لا يتجاوز المستحق لموظفات النسبة فقط
            var allEmps = cmbEmployee.Tag as List<beautyCenterSystem.Employee>;
            int eId = (int)cmbEmployee.SelectedValue;
            var selectedEmp = allEmps?.FirstOrDefault(e => e.EmployeeID == eId);

            if (selectedEmp == null || selectedEmp.EmployeeType == "Commission")
            {
                if (decimal.TryParse(txtRemainingBalance.Text, out decimal remaining))
                {
                    if (amount > remaining)
                    {
                        MessageBox.Show("المبلغ المدخل يتجاوز رصيد الموظفة المتبقي!", "خطأ في المبلغ");
                        return;
                    }
                }
            }

            try
            {
                btnSave.Enabled = false;
                int empId = (int)cmbEmployee.SelectedValue;
                int safeId = (int)cmbSafe.SelectedValue;
                string notes = txtNotes.Text.Trim();

                // تنفيذ عملية الحفظ (صرف المبلغ وخصمه من الخزنة في ترانزاكشن واحد)
                bool success = await _employeeRepo.SaveEmployeePaymentAsync(empId, safeId, amount, notes, _currentUserId);

                if (success)
                {
                    MessageBox.Show("تم تسجيل عملية الصرف بنجاح وتحديث رصيد الخزنة.", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // تحديث الأرصدة بعد الصرف مباشرة
                    await RefreshEmployeeBalances(empId);

                    // تنظيف الحقول للعملية التالية
                    txtAmountToPay.Clear();
                    txtNotes.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء الحفظ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
