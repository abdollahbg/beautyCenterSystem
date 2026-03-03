using beautyCenterSystem.data.Repositories;
using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beautyCenterSystem
{
    public partial class UC_Appointments : UserControl
    {
        private readonly AppointmentRepository _appointmentRepo;
        // هذه القائمة ستحتفظ بنسخة من حجوزات اليوم المختار كاملة
        private List<Appointment> _allDayAppointments = new List<Appointment>();
        public UC_Appointments()
        {
            InitializeComponent();
            _appointmentRepo = new AppointmentRepository(new DbConnectionFactory());
        }
        private async Task LoadAppointments()
        {
            try
            {
                // 1. تنظيف جدول التفاصيل فوراً عند بدء تغيير التاريخ
                dgvDetails.DataSource = null;

                DateTime selectedDate = dtpFilterDate.Value.Date;

                // 2. جلب البيانات من قاعدة البيانات
                var appointments = await _appointmentRepo.GetByDateAsync(selectedDate);
                _allDayAppointments = appointments.ToList();

                // 3. ربط البيانات بالجدول الرئيسي
                dgvAppointments.DataSource = null; // خطوة إضافية لضمان تصفير "الحالة السابقة" تماماً
                dgvAppointments.DataSource = _allDayAppointments;

                // 4. تنسيق الأعمدة
                FormatGrid();

                // 💡 الحل الجذري لمشكلة التغييرة الأولى:
                // إجبار الجدول على إلغاء أي اختيار تلقائي، ثم اختيار السطر الأول يدوياً
                if (_allDayAppointments.Count > 0)
                {
                    dgvAppointments.ClearSelection();

                    // اختيار السطر الأول برمجياً سيجبر حدث SelectionChanged على العمل
                    dgvAppointments.Rows[0].Selected = true;

                    // استدعاء يدوي لدالة جلب التفاصيل للسطر الأول لضمان التحديث من المرة الأولى
                    int firstAppId = Convert.ToInt32(dgvAppointments.Rows[0].Cells["AppointmentID"].Value);
                    var services = await _appointmentRepo.GetAppointmentServicesAsync(firstAppId);
                    dgvDetails.DataSource = services.ToList();
                    FormatDetailsGrid();
                }
                else
                {
                    // إذا كان اليوم فارغاً، نتأكد أن جدول التفاصيل فارغ أيضاً
                    dgvDetails.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل المواعيد: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatGrid()
        {
            if (dgvAppointments.Columns.Count > 0)
            {
                // إخفاء المعرفات والقوائم المعقدة التي لا تُعرض في الجريد تلقائياً
                string[] hiddenCols = { "AppointmentID", "CustomerID", "CreatedBy", "SelectedServices" };
                foreach (var col in hiddenCols)
                {
                    if (dgvAppointments.Columns.Contains(col))
                        dgvAppointments.Columns[col].Visible = false;
                }

                // تسمية الأعمدة الأساسية
                if (dgvAppointments.Columns.Contains("AppointmentDate"))
                {
                    dgvAppointments.Columns["AppointmentDate"].HeaderText = "الوقت";
                    dgvAppointments.Columns["AppointmentDate"].DefaultCellStyle.Format = "hh:mm tt";
                    dgvAppointments.Columns["AppointmentDate"].Width = 100;
                }

                if (dgvAppointments.Columns.Contains("CustomerName"))
                {
                    dgvAppointments.Columns["CustomerName"].HeaderText = "اسم العميلة";
                    dgvAppointments.Columns["CustomerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (dgvAppointments.Columns.Contains("TotalPrice"))
                {
                    dgvAppointments.Columns["TotalPrice"].HeaderText = "الإجمالي";
                    dgvAppointments.Columns["TotalPrice"].Width = 90;
                }

                if (dgvAppointments.Columns.Contains("Status"))
                {
                    dgvAppointments.Columns["Status"].HeaderText = "الحالة";
                    dgvAppointments.Columns["Status"].Width = 100;
                }
            }

            dgvAppointments.ReadOnly = true;

            foreach (DataGridViewRow row in dgvAppointments.Rows)
            {
                string status = row.Cells["Status"].Value.ToString();
                if (status == "InProgress")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow; // لون يميز العمل القائم
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (status == "Completed")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen; // لون المواعيد المنتهية
                }
            }
            // داخل حلقة التكرار على صفوف الجدول
            foreach (DataGridViewRow row in dgvAppointments.Rows)
            {
                if (row.Cells["Status"].Value.ToString() == "Cancelled")
                {
                    row.DefaultCellStyle.ForeColor = Color.Gray; // جعل الخط باهت
                    row.DefaultCellStyle.SelectionBackColor = Color.Gray; // تمييزه حتى عند الاختيار
                                                                          // يمكنك أيضاً جعل الخط عليه شطب (Strikethrough)
                    row.DefaultCellStyle.Font = new Font(dgvAppointments.Font, FontStyle.Strikeout);
                }
            }
        }
        private void FormatDetailsGrid()
        {
            if (dgvDetails.Columns.Count > 0)
            {
                // إخفاء ما لا نحتاجه في عرض التفاصيل السريع
                string[] hiddenCols = { "ServiceID", "RoomID", "IsActive", "DurationMinutes" };
                foreach (var col in hiddenCols)
                {
                    if (dgvDetails.Columns.Contains(col))
                        dgvDetails.Columns[col].Visible = false;
                }

                // تسمية الأعمدة
                if (dgvDetails.Columns.Contains("ServiceName"))
                {
                    dgvDetails.Columns["ServiceName"].HeaderText = "الخدمة";
                    dgvDetails.Columns["ServiceName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (dgvDetails.Columns.Contains("Price"))
                {
                    dgvDetails.Columns["Price"].HeaderText = "السعر";
                    dgvDetails.Columns["Price"].Width = 70;
                }

                // ملاحظة: إذا كان المودل يحتوي على اسم الغرفة سنظهره هنا
                if (dgvDetails.Columns.Contains("RoomName"))
                    dgvDetails.Columns["RoomName"].HeaderText = "الغرفة";
            }
            dgvDetails.ReadOnly = true;
        }



        private async void dgvAppointments_SelectionChanged(object sender, EventArgs e)
        {
            // 1. التأكد من وجود سطر مختار ومن أن الجدول ليس فارغاً
            if (dgvAppointments.CurrentRow != null && dgvAppointments.CurrentRow.Index >= 0)
            {
                try
                {
                    // 2. استخراج رقم الحجز من السطر الحالي
                    // ملاحظة: تأكد أن اسم العمود في الـ FormatGrid هو "AppointmentID"
                    int appId = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["AppointmentID"].Value);

                    // 3. جلب الخدمات المرتبطة بهذا الحجز من قاعدة البيانات
                    var services = await _appointmentRepo.GetAppointmentServicesAsync(appId);

                    // 4. عرضها في الجدول الجانبي
                    dgvDetails.DataSource = services.ToList();

                    // 5. تنسيق جدول التفاصيل
                    FormatDetailsGrid();
                }
                catch (Exception ex)
                {
                    // نكتفي بتفريغ الجدول في حال حدوث خطأ بسيط أو أثناء التحميل الأولي
                    dgvDetails.DataSource = null;
                }
            }
            else
            {
                // إذا لم يتم اختيار شيء، فرغ الجدول الثاني
                dgvDetails.DataSource = null;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void UC_Appointments_Load(object sender, EventArgs e)
        {
            FormatGrid(); // تهيئة الأعمدة أولاً
            await LoadAppointments(); // جلب بيانات اليوم الافتراضي
                                      // تحديد حجم ثابت للزر يضمن ظهور النص كاملاً
            btnRefresh.Size = new Size(76, 67);
            this.BeginInvoke((MethodInvoker)delegate
            {
                btnRefresh.ForeColor = AppTheme.Charcoal;
                btnRefresh.FlatStyle = FlatStyle.Flat;
                btnRefresh.FlatAppearance.BorderSize = 1;
                btnRefresh.FlatAppearance.BorderColor = AppTheme.Charcoal;
                btnRefresh.BackColor = Color.White;
                btnRefresh.TextAlign = ContentAlignment.MiddleCenter;
            });
            // التأكد من أن النص في المنتصف تماماً
            btnRefresh.TextAlign = ContentAlignment.MiddleCenter;
        }

        private async void dtpFilterDate_ValueChanged(object sender, EventArgs e)
        {
            dgvDetails.DataSource = null;
            await LoadAppointments();
        }

        private void txtSearchCustomer_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearchCustomer.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(filter))
            {
                // إذا مسح المستخدم النص، نعيد عرض كل حجوزات اليوم
                dgvAppointments.DataSource = _allDayAppointments;
            }
            else
            {
                var filteredList = _allDayAppointments.Where(a =>
                    a.CustomerName.ToLower().Contains(filter)

                ).ToList();

                dgvAppointments.DataSource = filteredList;
            }

            // إعادة تنسيق الجدول ليظل الشكل مرتباً
            FormatGrid();
        }

        private async void btnAddAppointment_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddAppointmentForm())
            {
                AppTheme.Apply(addForm);

                var result = addForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    await LoadAppointments();

                }

            }
        }



        private async void btnRefresh_Click_1(object sender, EventArgs e)
        {
            await LoadAppointments();
        }

        private async void btnStartService_Click(object sender, EventArgs e)
        {
            // 1. التأكد من اختيار حجز من الجدول
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار حجز من الجدول أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. الحصول على بيانات الحجز المختار
            var selectedRow = dgvAppointments.SelectedRows[0];
            int appointmentId = Convert.ToInt32(selectedRow.Cells["AppointmentID"].Value);
            string currentStatus = selectedRow.Cells["Status"].Value.ToString();

            // 3. منع بدء خدمة منتهية أو ملغاة
            if (currentStatus != "Pending")
            {
                MessageBox.Show("يمكنك بدء الحجوزات التي في حالة 'قيد الانتظار' فقط.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // 4. تحديث الحالة في قاعدة البيانات
                bool success = await _appointmentRepo.UpdateStatusAsync(appointmentId, "InProgress");

                if (success)
                {
                    MessageBox.Show("تم تغيير حالة الحجز إلى 'قيد التنفيذ'.", "تم بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. تحديث الجدول ليعكس الحالة الجديدة فوراً
                    await LoadAppointments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحديث الحالة: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCancelAppointment_Click(object sender, EventArgs e)
        {
            // 1. التحقق من اختيار حجز
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار الحجز المراد إلغاؤه من الجدول.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // 2. جلب بيانات السطر المختار
                var selectedRow = dgvAppointments.SelectedRows[0];
                int appId = Convert.ToInt32(selectedRow.Cells["AppointmentID"].Value);
                string customerName = selectedRow.Cells["CustomerName"].Value.ToString();
                string currentStatus = selectedRow.Cells["Status"].Value.ToString();

                // 3. منع إلغاء حجز ملغي بالفعل أو مكتمل
                if (currentStatus == "Cancelled")
                {
                    MessageBox.Show("هذا الحجز ملغي بالفعل!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (currentStatus == "Completed")
                {
                    MessageBox.Show("لا يمكن إلغاء حجز مكتمل ومسدد.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. رسالة تأكيد للمستخدم
                var confirmResult = MessageBox.Show(
                    $"هل أنتِ متأكدة من إلغاء حجز العميلة ({customerName})؟\nلا يمكن التراجع عن هذا الإجراء.",
                    "تأكيد الإلغاء",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    // 5. تنفيذ الإلغاء في قاعدة البيانات
                    bool success = await _appointmentRepo.UpdateStatusAsync(appId, "Cancelled");

                    if (success)
                    {
                        MessageBox.Show("تم إلغاء الحجز بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 6. تحديث الجدول فوراً
                        await LoadAppointments();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء محاولة الإلغاء: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEditAppointment_Click(object sender, EventArgs e)
        {
            // 1. التحقق من أن المستخدم اختار سطراً بالفعل
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار حجز من الجدول أولاً للقيام بتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // 2. جلب البيانات من السطر المختار
                var selectedRow = dgvAppointments.SelectedRows[0];
                int appId = Convert.ToInt32(selectedRow.Cells["AppointmentID"].Value);
                string status = selectedRow.Cells["Status"].Value?.ToString();

                // 3. منع تعديل الحجوزات الملغاة
                if (status == "Cancelled")
                {
                    MessageBox.Show("عذراً، لا يمكن تعديل حجز تم إلغاؤه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. فتح شاشة التعديل (نمرر الـ appId للمشيد الذي برمجناه)
                using (var editForm = new AddAppointmentForm(appId))
                {
                    // إذا أغلق المستخدم الشاشة بعد الضغط على "تحديث" (DialogResult.OK)
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        await LoadAppointments(); // تحديث الجدول الرئيسي ليعكس التعديلات فوراً
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء محاولة فتح شاشة التعديل: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCompleteAndPay_Click(object sender, EventArgs e)
        {
            // 1. التأكد من اختيار حجز من الجدول
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار الحجز المراد إتمامه من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. جلب بيانات السطر المختار
                var selectedRow = dgvAppointments.SelectedRows[0];
                int appId = Convert.ToInt32(selectedRow.Cells["AppointmentID"].Value);
                string customerName = selectedRow.Cells["CustomerName"].Value.ToString();
                decimal totalAmount = Convert.ToDecimal(selectedRow.Cells["TotalPrice"].Value);
                string currentStatus = selectedRow.Cells["Status"].Value.ToString();

                // 3. التحقق من حالة الحجز
                if (currentStatus == "Completed")
                {
                    MessageBox.Show("هذا الحجز مكتمل ومدفوع بالفعل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 4. فتح فورم الدفع
                using (var payForm = new CheckoutForm(customerName, totalAmount))
                {
                    if (payForm.ShowDialog() == DialogResult.OK)
                    {
                        // 5. تحديث الحالة في قاعدة البيانات (نستخدم معرف المستخدم من الجلسة)
                        bool isSuccess = await _appointmentRepo.CompleteAndPayAsync(
                            appId,
                            totalAmount,
                            payForm.AmountPaid,
                            payForm.Discount,
                            payForm.PaymentMethod,
                            CurrentSession.UserID // تم الربط بالجلسة
                        );

                        if (isSuccess)
                        {
                            // 6. تحديث الجدول الرئيسي
                            await LoadAppointments();

                            try
                            {
                                // 7. جلب الإعدادات والخدمات من قاعدة البيانات
                                var settingsRepo = new SettingsRepository(new DbConnectionFactory());
                                var settings = await settingsRepo.GetSettingsAsync();
                                var services = await _appointmentRepo.GetAppointmentServicesAsync(appId);

                                // 8. تجهيز كائن الطباعة بالبيانات الفعلية من الإعدادات والجلسة
                                ReceiptPrinter printer = new ReceiptPrinter();

                                // بيانات المركز من الإعدادات (مع وضع قيم افتراضية في حال كانت فارغة)
                                printer.CenterName = settings.CenterName ?? "صالون التجميل";
                                printer.Phone = settings.Phone ?? "";
                                printer.Policy = settings.Note ?? "الرجاء مراجعة الفاتورة قبل المغادرة.";
                                printer.Logo = settings.GetLogoImage(); // تحويل البايتات لصورة

                                // تجميع روابط السوشيال ميديا
                                List<string> socialList = new List<string>();
                                if (!string.IsNullOrEmpty(settings.Facebook)) socialList.Add("FB: " + settings.Facebook);
                                if (!string.IsNullOrEmpty(settings.Instagram)) socialList.Add("Insta: " + settings.Instagram);
                                if (!string.IsNullOrEmpty(settings.WhatsApp)) socialList.Add("WhatsApp: " + settings.WhatsApp);
                                printer.SocialMedia = string.Join(" | ", socialList);

                                // بيانات الفاتورة
                                printer.InvoiceNumber = appId;
                                printer.CustomerName = customerName;
                                printer.TotalAmount = totalAmount;
                                printer.Discount = payForm.Discount;
                                printer.NetAmount = payForm.AmountPaid;

                                // بيانات الموظف من الجلسة
                                printer.CashierName = CurrentSession.Username;

                                printer.Items = services.Select(s => new InvoiceItem
                                {
                                    ServiceName = s.ServiceName,
                                    Price = s.Price
                                }).ToList();

                                // 9. الطباعة المباشرة
                                printer.PrintReceipt(false);
                            }
                            catch (Exception printEx)
                            {
                                MessageBox.Show($"تم الحفظ، لكن فشلت الطباعة: {printEx.Message}", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            MessageBox.Show($"تم إتمام العملية بنجاح للعميلة {customerName}.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PrintDirectly(ReceiptPrinter printer)
        {
            PrintDocument pd = new PrintDocument();
            // ضبط مقاس الورق لـ 80mm
            pd.DefaultPageSettings.PaperSize = new PaperSize("Thermal80mm", 285, 0);

            // ربط الرسم بكلاس الطابعة
            pd.PrintPage += (s, ev) => {
                // هنا نستدعي دالة الرسم الأصلية الموجودة في كلاس ReceiptPrinter
                // (ملاحظة: إذا جعلت دالة Pd_PrintPage في كلاس الطابعة public يمكنك استدعاؤها مباشرة)
                // حالياً سنقوم باستدعاء أمر الطباعة المباشر
            };

            // هذا السطر هو السر في الطباعة المباشرة دون ظهور نوافذ
            pd.PrintController = new StandardPrintController();

            // تنفيذ الطباعة
            // ملاحظة: تأكد أن كلاس ReceiptPrinter يحتوي على منطق الرسم داخل PrintDocument
            // سأقوم بتعديل دالة PrintReceipt داخل كلاس ReceiptPrinter لتصبح هكذا:
        }
    }

}
