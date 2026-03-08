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

namespace beautyCenterSystem.data.Repositories
{
    public partial class frmSafes : Form
    {
        private readonly FinancialRepository _financialRepository;
        public frmSafes()
        {
            InitializeComponent();
            _financialRepository = new FinancialRepository(new DbConnectionFactory());
        }
        private async Task LoadSafesData()
        {
            try
            {
                var safes = await _financialRepository.GetAllSafesAsync();

                // الحل النهائي: تفعيل التوليد ثم المسح لضمان تنظيف الذاكرة المؤقتة للأعمدة
                dgvSafes.AutoGenerateColumns = true;
                dgvSafes.Columns.Clear();

                dgvSafes.DataSource = safes.ToList();

                FormatSafesGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل الخزنات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatSafesGrid()
        {
            if (dgvSafes.Columns.Count > 0)
            {
                // 1. إخفاء الأعمدة التي لا تهم المستخدم (IDs والحالة)
                if (dgvSafes.Columns.Contains("SafeID")) dgvSafes.Columns["SafeID"].Visible = false;
                if (dgvSafes.Columns.Contains("IsActive")) dgvSafes.Columns["IsActive"].Visible = false;

                // 2. تعريب أسماء الأعمدة (Header Text)
                if (dgvSafes.Columns.Contains("SafeName"))
                    dgvSafes.Columns["SafeName"].HeaderText = "اسم الخزنة / الحساب";

                if (dgvSafes.Columns.Contains("Balance"))
                    dgvSafes.Columns["Balance"].HeaderText = "الرصيد المتوفر";

                // 3. تنسيق القيم المالية (الرصيد)
                if (dgvSafes.Columns.Contains("Balance"))
                {
                    // تنسيق الرقم (رقمين عشريين)
                    dgvSafes.Columns["Balance"].DefaultCellStyle.Format = "N2";




                    // جعل الخط عريضاً (Bold) للرصيد
                    dgvSafes.Columns["Balance"].DefaultCellStyle.Font = new Font(dgvSafes.Font, FontStyle.Bold);

                    // محاذاة النص للوسط
                    dgvSafes.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // 4. إعدادات الحماية والمظهر العامة
                dgvSafes.ReadOnly = true; // منع التعديل المباشر نهائياً
                dgvSafes.AllowUserToAddRows = false; // منع إضافة صفوف فارغة
                dgvSafes.AllowUserToDeleteRows = false; // منع الحذف
                dgvSafes.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // اختيار الصف بالكامل
                dgvSafes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // ملء المساحة بالكامل
                dgvSafes.RowHeadersVisible = false; // إخفاء العمود الجانبي الصغير لزيادة المساحة
            }
        }
        private async void frmSafes_Load(object sender, EventArgs e)
        {
            AppTheme.Apply(this);
            this.BeginInvoke((MethodInvoker)delegate
            {
                btnAddSafe.FlatStyle = FlatStyle.Flat;
                btnAddSafe.FlatAppearance.BorderSize = 1;
                btnAddSafe.FlatAppearance.BorderColor = AppTheme.Charcoal;
                btnAddSafe.BackColor = Color.White;
                btnAddSafe.ForeColor = Color.Black;
            });
            this.BeginInvoke((MethodInvoker)delegate
            {
                btnTransfer.ForeColor = AppTheme.Charcoal;
                btnTransfer.FlatStyle = FlatStyle.Flat;
                btnTransfer.FlatAppearance.BorderSize = 1;
                btnTransfer.FlatAppearance.BorderColor = AppTheme.Charcoal;
                btnTransfer.BackColor = Color.White;
                btnTransfer.TextAlign = ContentAlignment.MiddleCenter;
            });
            await LoadAllFinancialData();

        }

        private async void btnAddSafe_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAddSafe())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // هنا نقوم بالحفظ الفعلي باستخدام ريبوزيتوري الفورم الأب
                    bool result = await _financialRepository.AddNewSafeAsync(frm.SafeName, frm.InitialBalance);
                    if (result)
                    {
                        await LoadSafesData(); // تحديث الجدول بعد الحفظ
                    }
                }
            }
        }

        private void dgvSafes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tpFinancialMapping_Click(object sender, EventArgs e)
        {

        }
        // داخل كلاس frmSafes
        private async Task LoadMappingSettings()
        {
            try
            {
                // 1. جلب قائمة الخزنات لملء الكومبو بوكس
                var safes = await _financialRepository.GetAllSafesAsync();
                var safesList = safes.ToList();

                // إعداد كومبو بوكس الكاش
                cmbCashSafe.DataSource = new BindingSource(safesList, null);
                cmbCashSafe.DisplayMember = "SafeName";
                cmbCashSafe.ValueMember = "SafeID";

                // إعداد كومبو بوكس البطاقة (نسخة منفصلة)
                cmbCardSafe.DataSource = new BindingSource(safesList, null);
                cmbCardSafe.DisplayMember = "SafeName";
                cmbCardSafe.ValueMember = "SafeID";

                // 2. جلب الإعدادات الحالية من جدول PaymentMapping لضبط الاختيارات
                var mappings = await _financialRepository.GetAllPaymentMappingsAsync();
                foreach (var map in mappings)
                {
                    if (map.MethodName == "Cash")
                        cmbCashSafe.SelectedValue = map.SafeID;
                    else if (map.MethodName == "Card")
                        cmbCardSafe.SelectedValue = map.SafeID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ أثناء تحميل الإعدادات: {ex.Message}", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // كود زر الحفظ في التبويب الثالث
        private async void btnSaveMapping_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCashSafe.SelectedValue == null || cmbCardSafe.SelectedValue == null)
                {
                    MessageBox.Show("يرجى اختيار الخزنات لجميع طرق الدفع أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // حفظ ربط الكاش
                await _financialRepository.UpdatePaymentMappingAsync("Cash", (int)cmbCashSafe.SelectedValue);

                // حفظ ربط البطاقة
                await _financialRepository.UpdatePaymentMappingAsync("Card", (int)cmbCardSafe.SelectedValue);

                MessageBox.Show("تم حفظ إعدادات توجيه الأموال بنجاح. سيقوم النظام الآن بتوزيع المقبوضات آلياً.",
                                "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"فشل الحفظ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSafes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && double.TryParse(e.Value.ToString(), out double cellValue))
            {
                if (cellValue < 0)
                {
                    // تغيير لون النص (الكتابة) إلى الأحمر
                    e.CellStyle.ForeColor = Color.Red;
                }
                else
                {
                    // تغيير لون النص (الكتابة) إلى الأخضر
                    e.CellStyle.ForeColor = Color.Green;
                }
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void cmbFromSafe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFromSafe.SelectedItem is Safe selectedSafe)
            {
                // عرض الرصيد بتنسيق مالي (مثلاً: 1,500.00 د.ل)
                lblFromBalance.Text = selectedSafe.Balance.ToString("N2") + " د.ل";

                // تغيير لون الليبل إذا كان الرصيد صفراً للتنبيه
                lblFromBalance.ForeColor = selectedSafe.Balance <= 0 ? Color.Red : Color.Green;
            }
        }

        private async void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. التحقق من صحة المبلغ المدخل
                if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
                {
                    MessageBox.Show("يرجى إدخال مبلغ صحيح أكبر من الصفر.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. التحقق من اختيار الخزنات وعدم تكرارها
                int fromId = (int)cmbFromSafe.SelectedValue;
                int toId = (int)cmbToSafe.SelectedValue;

                if (fromId == toId)
                {
                    MessageBox.Show("لا يمكن التحويل لنفس الخزنة، يرجى اختيار خزنة وجهة مختلفة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. التحقق من كفاية الرصيد في الخزنة المصدر
                var fromSafe = (Safe)cmbFromSafe.SelectedItem;
                if (amount > fromSafe.Balance)
                {
                    MessageBox.Show($"عذراً، الرصيد غير كافٍ. المتوفر حالياً هو: {fromSafe.Balance:N2}", "رصيد غير كافٍ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 4. تنفيذ عملية التحويل عبر الـ Repository
                // نستخدم معرف المستخدم الحالي من الجلسة (CurrentSession.UserID)
                bool success = await _financialRepository.TransferMoneyAsync(fromId, toId, amount, CurrentSession.UserID);

                if (success)
                {
                    MessageBox.Show($"تم تحويل مبلغ {amount:N2} بنجاح.", "عملية ناجحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. تحديث الواجهة (تصفير الحقل وتحديث القوائم والجدول)
                    txtAmount.Clear();
                    await LoadAllFinancialData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء التحويل: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAmount.Text, out decimal val) && cmbFromSafe.SelectedItem is Safe s)
            {
                txtAmount.ForeColor = val > s.Balance ? Color.Red : Color.Black;
            }
        }

        private async Task LoadTransferCombos()
        {
            try
            {
                var safes = await _financialRepository.GetAllSafesAsync();
                var list = safes.ToList();

                // تعبئة "من خزنة"
                cmbFromSafe.DataSource = new BindingSource(list, null);
                cmbFromSafe.DisplayMember = "SafeName";
                cmbFromSafe.ValueMember = "SafeID";

                // تعبئة "إلى خزنة"
                cmbToSafe.DataSource = new BindingSource(list, null);
                cmbToSafe.DisplayMember = "SafeName";
                cmbToSafe.ValueMember = "SafeID";

                // ضبط افتراضي: المصدر أول عنصر، والوجهة ثاني عنصر (إذا وجد)
                if (cmbFromSafe.Items.Count > 0) cmbFromSafe.SelectedIndex = 0;
                if (cmbToSafe.Items.Count > 1) cmbToSafe.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("خطأ في تحميل قوائم التحويل: " + ex.Message);
            }
        }
        // 1. تحميل سجل التحويلات
        private async Task LoadTransferHistory()
        {
            try
            {
                var history = await _financialRepository.GetTransferHistoryAsync();

                // 1. أهم سطر: منع الجدول من إنشاء أعمدة تلقائية بالإنجليزية
                dgvTransfers.AutoGenerateColumns = false;

                // 2. مسح أي أعمدة قديمة تماماً
                dgvTransfers.Columns.Clear();

                // 3. إضافة الأعمدة يدوياً (هنا نتحكم بالظهور والترتيب)
                // لاحظ أننا نربط DataPropertyName باسم الخاصية في قاعدة البيانات
                dgvTransfers.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FromSafe",
                    HeaderText = "من خزنة",
                    Name = "FromSafe"
                });

                dgvTransfers.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ToSafe",
                    HeaderText = "إلى خزنة",
                    Name = "ToSafe"
                });

                dgvTransfers.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Amount",
                    HeaderText = "المبلغ",
                    Name = "Amount"
                });

                dgvTransfers.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TransferDate",
                    HeaderText = "التاريخ",
                    Name = "TransferDate"
                });

                dgvTransfers.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TransferredBy",
                    HeaderText = "الموظف",
                    Name = "TransferredBy"
                });

                // 4. ربط البيانات (الآن سيعرض فقط الـ 5 أعمدة التي أضفناها فوق)
                dgvTransfers.DataSource = history.ToList();

                // 5. تطبيق التنسيقات الجمالية (الألوان والخطوط)
                FormatTransfersGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل سجل التحويلات: {ex.Message}");
            }
        }

        // 2. تنسيق جدول التحويلات
        private void FormatTransfersGrid()
        {
            // نتأكد أن الجدول يحتوي على أعمدة لتجنب الأخطاء
            if (dgvTransfers.Columns.Count > 0)
            {
                // 1. تنسيق عمود المبلغ (لأنه موجود بالتأكيد في الأعمدة اليدوية)
                if (dgvTransfers.Columns.Contains("Amount"))
                {
                    dgvTransfers.Columns["Amount"].DefaultCellStyle.Format = "N2"; // رقمين عشريين
                    dgvTransfers.Columns["Amount"].DefaultCellStyle.Font = new Font(dgvTransfers.Font, FontStyle.Bold);
                    dgvTransfers.Columns["Amount"].DefaultCellStyle.ForeColor = Color.DarkBlue;
                    dgvTransfers.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // 2. تنسيق عمود التاريخ
                if (dgvTransfers.Columns.Contains("TransferDate"))
                {
                    dgvTransfers.Columns["TransferDate"].DefaultCellStyle.Format = "yyyy/MM/dd hh:mm tt";
                    dgvTransfers.Columns["TransferDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // 3. إعدادات المظهر العام والحماية
                dgvTransfers.ReadOnly = true;           // منع التعديل
                dgvTransfers.AllowUserToAddRows = false; // منع السطر الفارغ
                dgvTransfers.RowHeadersVisible = false;  // إخفاء السهم الجانبي
                dgvTransfers.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // تحديد الصف كاملاً
                dgvTransfers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // ملء المساحة

                // تحسين مظهر النصوص في بقية الأعمدة
                dgvTransfers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        private async Task LoadAllFinancialData()
        {
            var task1 = LoadSafesData();        // تحديث جدول الخزنات (التبويب 1)
            var task2 = LoadTransferCombos();   // تحديث قوائم التحويل (التبويب 2)
            var task3 = LoadMappingSettings();  // تحديث قوائم الربط (التبويب 3)
            var task4 = LoadTransferHistory();


            await Task.WhenAll(task1, task2, task3,task4);
        }
    }
}
