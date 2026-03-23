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
                dgvAppointments.DataSource = null;
                dgvAppointments.DataSource = _allDayAppointments;

                // 4. تنسيق الأعمدة
                FormatGrid();

                // الحل لمشكلة التغييرة الأولى:
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
                string[] hiddenCols = { "AppointmentID", "CustomerID", "CreatedBy", "SelectedServices" };
                foreach (var col in hiddenCols)
                {
                    if (dgvAppointments.Columns.Contains(col))
                        dgvAppointments.Columns[col].Visible = false;
                }

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
                if (row.Cells["Status"].Value == null) continue;
                string status = row.Cells["Status"].Value.ToString();

                if (status == "InProgress")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (status == "Completed")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (status == "Cancelled")
                {
                    row.DefaultCellStyle.ForeColor = Color.Gray;
                    row.DefaultCellStyle.SelectionBackColor = Color.Gray;
                    row.DefaultCellStyle.Font = new Font(dgvAppointments.Font, FontStyle.Strikeout);
                }
            }
        }

        private void FormatDetailsGrid()
        {
            if (dgvDetails.Columns.Count > 0)
            {
                string[] hiddenCols = { "ServiceID", "RoomID", "IsActive", "DurationMinutes" };
                foreach (var col in hiddenCols)
                {
                    if (dgvDetails.Columns.Contains(col))
                        dgvDetails.Columns[col].Visible = false;
                }

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
            }
            dgvDetails.ReadOnly = true;
        }

        private async void dgvAppointments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow != null && dgvAppointments.CurrentRow.Index >= 0)
            {
                try
                {
                    int appId = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["AppointmentID"].Value);
                    var services = await _appointmentRepo.GetAppointmentServicesAsync(appId);
                    dgvDetails.DataSource = services.ToList();
                    FormatDetailsGrid();
                }
                catch
                {
                    dgvDetails.DataSource = null;
                }
            }
            else
            {
                dgvDetails.DataSource = null;
            }
        }

        private async void UC_Appointments_Load(object sender, EventArgs e)
        {
            FormatGrid();
            await LoadAppointments();

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
        }

        private async void dtpFilterDate_ValueChanged(object sender, EventArgs e)
        {
            await LoadAppointments();
        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearchCustomer.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filter))
            {
                dgvAppointments.DataSource = _allDayAppointments;
            }
            else
            {
                dgvAppointments.DataSource = _allDayAppointments
                    .Where(a => a.CustomerName.ToLower().Contains(filter)).ToList();
            }
            FormatGrid();
        }

        private async void btnAddAppointment_Click(object sender, EventArgs e)
        {
            // عند الإضافة نستخدم المشيد الافتراضي (appId = 0)
            using (var addForm = new AddAppointmentForm())
            {
                AppTheme.Apply(addForm);
                if (addForm.ShowDialog() == DialogResult.OK)
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
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار حجز من الجدول أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvAppointments.SelectedRows[0];
            int appointmentId = Convert.ToInt32(selectedRow.Cells["AppointmentID"].Value);
            string currentStatus = selectedRow.Cells["Status"].Value.ToString();

            if (currentStatus != "Pending")
            {
                MessageBox.Show("يمكنك بدء الحجوزات التي في حالة 'قيد الانتظار' فقط.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                bool success = await _appointmentRepo.UpdateStatusAsync(appointmentId, "InProgress");
                if (success)
                {
                    MessageBox.Show("تم تغيير حالة الحجز إلى 'قيد التنفيذ'.", "تم بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dgvAppointments.SelectedRows.Count == 0) return;

            try
            {
                var selectedRow = dgvAppointments.SelectedRows[0];
                int appId = Convert.ToInt32(selectedRow.Cells["AppointmentID"].Value);
                string customerName = selectedRow.Cells["CustomerName"].Value.ToString();
                string currentStatus = selectedRow.Cells["Status"].Value.ToString();

                if (currentStatus == "Cancelled" || currentStatus == "Completed") return;

                var confirmResult = MessageBox.Show($"هل أنت متأكد من إلغاء حجز العميلة ({customerName})؟", "تأكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    bool success = await _appointmentRepo.UpdateStatusAsync(appId, "Cancelled");
                    if (success) await LoadAppointments();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void btnEditAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار حجز من الجدول أولاً للقيام بتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var selectedRow = dgvAppointments.SelectedRows[0];
                int appId = Convert.ToInt32(selectedRow.Cells["AppointmentID"].Value);
                string status = selectedRow.Cells["Status"].Value?.ToString();

                if (status == "Cancelled")
                {
                    MessageBox.Show("عذراً، لا يمكن تعديل حجز تم إلغاؤه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // التعديل الجوهري: نمرر appId للفورم لاستثنائه من فحص التعارض
                using (var editForm = new AddAppointmentForm(appId))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        await LoadAppointments();
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
            // 1. التأكد من اختيار حجز
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار الحجز المراد إتمامه من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedRow = dgvAppointments.SelectedRows[0];
                int appId = Convert.ToInt32(selectedRow.Cells["AppointmentID"].Value);
                string customerName = selectedRow.Cells["CustomerName"].Value.ToString();
                decimal totalAmount = Convert.ToDecimal(selectedRow.Cells["TotalPrice"].Value);
                string currentStatus = selectedRow.Cells["Status"].Value.ToString();

                // --- التعديل المطلوب هنا ---
                if (currentStatus == "Cancelled")
                {
                    MessageBox.Show("عذراً، لا يمكن إتمام أو دفع حجز ملغي.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // ---------------------------

                if (currentStatus == "Completed")
                {
                    MessageBox.Show("هذا الحجز مكتمل ومدفوع بالفعل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 2. فتح فورم الدفع
                using (var payForm = new CheckoutForm(customerName, totalAmount))
                {
                    if (payForm.ShowDialog() == DialogResult.OK)
                    {
                        // 3. تحديث البيانات في قاعدة البيانات
                        bool isSuccess = await _appointmentRepo.CompleteAndPayAsync(
                            appId, totalAmount, payForm.AmountPaid, payForm.Discount,
                            payForm.PaymentMethod, CurrentSession.UserID);

                        if (isSuccess)
                        {
                            await LoadAppointments(); // تحديث الجدول

                            // 4. عملية الطباعة
                            try
                            {
                                var settingsRepo = new SettingsRepository(new DbConnectionFactory());
                                var settings = await settingsRepo.GetSettingsAsync();
                                var services = await _appointmentRepo.GetAppointmentServicesAsync(appId);

                                ReceiptPrinter printer = new ReceiptPrinter
                                {
                                    CenterName = settings.CenterName ?? "صالون التجميل الراقي",
                                    Phone = settings.Phone ?? "",
                                    Policy = settings.Note ?? "الرجاء مراجعة الفاتورة قبل المغادرة.",
                                    Logo = settings.GetLogoImage(),
                                    FacebookHandle = settings.Facebook,
                                    InstagramHandle = settings.Instagram,
                                    WhatsAppHandle = settings.WhatsApp,

                                    InvoiceNumber = appId,
                                    CustomerName = customerName,
                                    TotalAmount = totalAmount,
                                    Discount = payForm.Discount,
                                    NetAmount = payForm.AmountPaid,
                                    CashierName = CurrentSession.Username,

                                    Items = services.Select(s => new InvoiceItem
                                    {
                                        ServiceName = s.ServiceName,
                                        Price = s.Price
                                    }).ToList()
                                };

                                printer.PrintReceipt(showPreview: false);
                            }
                            catch (Exception printEx)
                            {
                                MessageBox.Show($"فشلت الطباعة: {printEx.Message}", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            MessageBox.Show($"تم إتمام العملية بنجاح للعميلة {customerName}.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ: {ex.Message}");
            }
        }

        private async void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null) return;

            try
            {
                int appId = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["AppointmentID"].Value);

                // جلب البيانات اللازمة
                var settingsRepo = new SettingsRepository(new DbConnectionFactory());
                var settings = await settingsRepo.GetSettingsAsync();
                var services = await _appointmentRepo.GetAppointmentServicesAsync(appId);

                var row = dgvAppointments.CurrentRow;

                ReceiptPrinter printer = new ReceiptPrinter
                {
                    CenterName = settings.CenterName,
                    Phone = settings.Phone,
                    Logo = settings.GetLogoImage(),
                    Policy = settings.Note + "\n \n طباعه فقط",

                    FacebookHandle = settings.Facebook,
                    InstagramHandle = settings.Instagram,
                    WhatsAppHandle = settings.WhatsApp,

                    InvoiceNumber = appId,
                    CustomerName = row.Cells["CustomerName"].Value.ToString(),
                    TotalAmount = Convert.ToDecimal(row.Cells["TotalPrice"].Value),
                    NetAmount = Convert.ToDecimal(row.Cells["TotalPrice"].Value), // افترضنا هنا الصافي هو الإجمالي لإعادة الطباعة
                    CashierName = CurrentSession.Username,
                    Items = services.Select(s => new InvoiceItem { ServiceName = s.ServiceName, Price = s.Price }).ToList()
                };

                // هنا نستخدم المعاينة قبل الطباعة
                printer.PrintReceipt(showPreview: false);
            }
            catch (Exception ex) { MessageBox.Show("خطأ في الطباعة: " + ex.Message); }
        }
    }
}