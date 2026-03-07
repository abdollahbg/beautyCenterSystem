using BeautyCenterSystem.Data;
using BeautyCenterSystem.Data.Repositories;
using MaterialSkin;
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
    public partial class frmExpenses : Form
    {
        private readonly FinancialRepository _financialRepo;
        public frmExpenses()
        {
            InitializeComponent();
            _financialRepo = new FinancialRepository(new DbConnectionFactory());

        }

        private async void frmExpenses_Load(object sender, EventArgs e)
        {

            await LoadSafes();

            await LoadExpenses();
            AppTheme.Apply(this);



        }
        private async Task LoadSafes()
        {
            try
            {
                // جلب البيانات من الريبوزيتوري
                var safes = await _financialRepo.GetAllSafesAsync();
                var safeList = safes.ToList();

                // ربط البيانات بالـ ComboBox
                cmbSafes.DataSource = safeList;
                cmbSafes.DisplayMember = "SafeName"; // ما يراه الموظف (مثلاً: درج الكاشير)
                cmbSafes.ValueMember = "SafeID";     // ما يتم تخزينه برمجياً (مثلاً: 1)

                // جعل الاختيار الافتراضي هو أول خزنة (غالباً درج الكاشير)
                if (safeList.Count > 0)
                {
                    cmbSafes.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل الخزنات: {ex.Message}");
            }
        }
        private async Task RefreshData()
        {
            var data = await _financialRepo.GetExpensesAsync(dtp_From.Value, dtp_To.Value, txtboxSearch.Text);
            dgvExpenses.DataSource = data.ToList();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // السماح بالأرقام، النقطة العشرية، علامة السالب، والـ Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // منع وجود أكثر من نقطة عشرية
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // السماح بعلامة السالب فقط في بداية النص
            if ((e.KeyChar == '-') && ((sender as TextBox).SelectionStart != 0 || (sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private async void btnSaveExpense_Click(object sender, EventArgs e)
        {
            // 1. التحقق من البيانات (Validation)
            if (string.IsNullOrWhiteSpace(txtAmount.Text) || cmbSafes.SelectedValue == null)
            {
                MessageBox.Show("من فضلك أدخل المبلغ واختر الخزنة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. تجهيز كائن المصروف
                var expense = new Expense
                {
                    ExpenseName = txtDescription.Text, // الوصف (Multi-line)
                    Category = txtCategory.Text,       // التصنيف (حر الكتابة)
                    Amount = decimal.Parse(txtAmount.Text),
                    ExpenseDate = dtpExpenseDate.Value,
                    PaidFromSafeID = (int)cmbSafes.SelectedValue,

                    // استخدام الكلاس الخاص بك هنا
                    IssuedBy = CurrentSession.UserID
                };

                // 3. استدعاء الريبوزيتوري للحفظ
                bool success = await _financialRepo.AddExpenseAsync(expense);

                if (success)
                {
                    MessageBox.Show("تم تسجيل المصروف وخصم المبلغ من الخزنة بنجاح.", "تمت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. تنظيف الحقول بعد الحفظ
                    ClearInputs();

                    // 5. تحديث الجدول في الجهة اليسرى (Panel1)
                    await LoadExpenses();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ أثناء الحفظ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // دالة جلب البيانات وعرضها في الجدول
        private async Task LoadExpenses()
        {
            var search = txtboxSearch.Text;
            var fromDate = dtp_From.Value;
            var toDate = dtp_To.Value;

            var result = await _financialRepo.GetExpensesAsync(fromDate, toDate, search);
            dgvExpenses.DataSource = result.ToList();

            FormatGrid();
        }

        // عند الكتابة في مربع البحث
        private async void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            await LoadExpenses();
        }

        // هذه الدالة سيتم استدعاؤها عند تغيير أي من التاريخين
        private async void OnDateFilterChanged(object sender, EventArgs e)
        {
            // LoadExpenses ستقرأ تلقائياً من dtp_From و dtp_To
            await LoadExpenses();
        }
        // دالة لتنظيف الحقول
        private void ClearInputs()
        {
            txtAmount.Clear();
            txtDescription.Clear();
            dtpExpenseDate.Value = DateTime.Now;
        }
        private void FormatGrid()
        {
            if (dgvExpenses.Columns.Count > 0)
            {
                // 1. إخفاء أعمدة المعرفات (IDs) التي لا تهم المستخدم
                if (dgvExpenses.Columns.Contains("ExpenseID")) dgvExpenses.Columns["ExpenseID"].Visible = false;
                if (dgvExpenses.Columns.Contains("PaidFromSafeID")) dgvExpenses.Columns["PaidFromSafeID"].Visible = false;
                if (dgvExpenses.Columns.Contains("IssuedBy")) dgvExpenses.Columns["IssuedBy"].Visible = false;
                if (dgvExpenses.Columns.Contains("Notes")) dgvExpenses.Columns["Notes"].Visible = false;

                // 2. تحسين أسماء الأعمدة الظاهرة (Header Text)
                if (dgvExpenses.Columns.Contains("Category")) dgvExpenses.Columns["Category"].HeaderText = "التصنيف";
                if (dgvExpenses.Columns.Contains("ExpenseName")) dgvExpenses.Columns["ExpenseName"].HeaderText = "بيان المصروف";
                if (dgvExpenses.Columns.Contains("Amount")) dgvExpenses.Columns["Amount"].HeaderText = "المبلغ";
                if (dgvExpenses.Columns.Contains("ExpenseDate")) dgvExpenses.Columns["ExpenseDate"].HeaderText = "التاريخ";
                if (dgvExpenses.Columns.Contains("SafeName")) dgvExpenses.Columns["SafeName"].HeaderText = "الخزنة";
                if (dgvExpenses.Columns.Contains("IssuedByName")) dgvExpenses.Columns["IssuedByName"].HeaderText = "الموظف";

                // 3. تنسيق القيم (مثل العملة والتاريخ)
                if (dgvExpenses.Columns.Contains("Amount"))
                {
                    dgvExpenses.Columns["Amount"].DefaultCellStyle.Format = "N2"; // إظهار رقمين بعد العلامة العشرية
                    dgvExpenses.Columns["Amount"].DefaultCellStyle.ForeColor = Color.DarkRed; // تمييز المبلغ باللون الأحمر
                }

                if (dgvExpenses.Columns.Contains("ExpenseDate"))
                {
                    dgvExpenses.Columns["ExpenseDate"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm"; // تنسيق التاريخ والوقت
                }

                // --- التعديلات الجديدة للتحكم في الصلاحيات ---

                // أولاً: السماح بالتعديل في الجدول بشكل عام
                dgvExpenses.ReadOnly = false;

                // ثانياً: قفل جميع الأعمدة برمجياً
                foreach (DataGridViewColumn col in dgvExpenses.Columns)
                {
                    col.ReadOnly = true;
                }

                // ثالثاً: فتح الأعمدة المحددة فقط للتعديل
                if (dgvExpenses.Columns.Contains("Category"))
                {
                    dgvExpenses.Columns["Category"].ReadOnly = false;
                    dgvExpenses.Columns["Category"].DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 210); // لون خلفية خفيف لتمييز القابلية للتعديل
                }

                if (dgvExpenses.Columns.Contains("ExpenseName"))
                {
                    dgvExpenses.Columns["ExpenseName"].ReadOnly = false;
                    dgvExpenses.Columns["ExpenseName"].DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 210);
                }

                // 4. ضبط العرض التلقائي للأعمدة
                dgvExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            dgvExpenses.AllowUserToAddRows = false; // منع المستخدم من إضافة صف فارغ يدوياً
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
        {
            // splitContainer1.Panel2.BackColor = Color.Transparent;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void dgvExpenses_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // التأكد من أن التعديل ليس في السطر الرأسي (Header)
            if (e.RowIndex >= 0)
            {
                var row = dgvExpenses.Rows[e.RowIndex];

                // جلب البيانات المحدثة والمعرف
                int id = (int)row.Cells["ExpenseID"].Value;
                string category = row.Cells["Category"].Value?.ToString() ?? "";
                string name = row.Cells["ExpenseName"].Value?.ToString() ?? "";
                string notes = row.Cells["Notes"].Value?.ToString() ?? ""; // إذا كنت تسمح بتعديل الملاحظات أيضاً

                try
                {
                    // استدعاء الميثود التي كتبناها في الـ Repository سابقاً
                    bool success = await _financialRepo.UpdateExpenseDetailsAsync(id, category, name, notes);

                    if (!success)
                    {
                        MessageBox.Show("فشل تحديث البيانات في قاعدة البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        await LoadExpenses(); // إعادة تحميل البيانات لإلغاء التغيير بصرياً
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطأ أثناء التحديث: {ex.Message}");
                }
            }
        }
    }
}
