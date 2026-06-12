using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeautyCenterSystem.Models;
using beautyCenterSystem.data.Repositories;

namespace beautyCenterSystem
{
    public partial class UC_Appointments : UserControl
    {
        private readonly AppointmentRepository _appointmentRepo;
        private readonly RoomRepository _roomRepo;
        private List<Appointment> _allDayAppointments = new List<Appointment>();
        private bool _isLoadingAppointments = false;

        public UC_Appointments()
        {
            InitializeComponent();
            var dbFactory = new DbConnectionFactory();
            _appointmentRepo = new AppointmentRepository(dbFactory);
            _roomRepo = new RoomRepository(dbFactory);

            // ربط أحداث جدول التفاصيل برمجياً
            dgvDetails.CellFormatting += dgvDetails_CellFormatting;
            dgvDetails.CellContentClick += dgvDetails_CellContentClick;
            dgvAppointments.DataBindingComplete += dgvAppointments_DataBindingComplete;
        }

        private async Task LoadAppointments()
        {
            _isLoadingAppointments = true;
            try
            {
                int? selectedAppId = null;
                // حفظ الـ ID المحدد حالياً قبل تحديث البيانات
                if (dgvAppointments.Columns.Contains("AppointmentID") && dgvAppointments.CurrentRow != null)
                {
                    var cellValue = dgvAppointments.CurrentRow.Cells["AppointmentID"].Value;
                    if (cellValue != null) selectedAppId = Convert.ToInt32(cellValue);
                }

                DateTime selectedDate = dtpFilterDate.Value.Date;
                int selectedRoomId = 0;
                if (cmbFilterRoom.SelectedValue != null && int.TryParse(cmbFilterRoom.SelectedValue.ToString(), out int rid))
                {
                    selectedRoomId = rid;
                }

                var appointments = await _appointmentRepo.GetByDateAsync(selectedDate, selectedRoomId > 0 ? selectedRoomId : (int?)null);
                _allDayAppointments = appointments.ToList();

                // مسح الأعمدة أولاً قبل إعادة تعيين DataSource
                // هذا يمنع تراكم الأعمدة المضافة يدوياً (RowIndex) مع الأعمدة المولَّدة تلقائياً
                dgvAppointments.DataSource = null;
                dgvAppointments.Columns.Clear();
                dgvAppointments.DataSource = _allDayAppointments;
                FormatGrid();

                if (_allDayAppointments.Count > 0)
                {
                    // البحث عن الصف السابق بأمان
                    DataGridViewRow rowToSelect = null;
                    if (selectedAppId.HasValue)
                    {
                        rowToSelect = dgvAppointments.Rows
                            .Cast<DataGridViewRow>()
                            .FirstOrDefault(r => r.Cells["AppointmentID"].Value != null &&
                                                 Convert.ToInt32(r.Cells["AppointmentID"].Value) == selectedAppId);
                    }

                    if (rowToSelect == null) rowToSelect = dgvAppointments.Rows[0];

                    dgvAppointments.ClearSelection();
                    rowToSelect.Selected = true;

                    // تأكد من وجود خلية ظاهرة قبل التحديد
                    if (dgvAppointments.FirstDisplayedCell != null)
                    {
                        dgvAppointments.CurrentCell = rowToSelect.Cells[dgvAppointments.FirstDisplayedCell.ColumnIndex];
                    }

                    // تحميل التفاصيل باستخدام الدالة المساعدة
                    int currentAppId = Convert.ToInt32(rowToSelect.Cells["AppointmentID"].Value);
                    await RefreshDetails(currentAppId);
                }
                else
                {
                    // مسح شامل لشبكة التفاصيل عند عدم وجود نتائج
                    dgvDetails.DataSource = null;
                    dgvDetails.Columns.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل المواعيد: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isLoadingAppointments = false;
            }
        }

        // دالة مساعدة لتحديث التفاصيل لتجنب التكرار
        private async Task RefreshDetails(int appId)
        {
            var services = await _appointmentRepo.GetAppointmentServicesAsync(appId);
            dgvDetails.DataSource = services.ToList();
            FormatDetailsGrid();
        }

        private void FormatGrid()
        {
            if (dgvAppointments.Columns.Count == 0) return;

            try
            {
                // --- عمود الترقيم التسلسلي (#) ---
                // يُضاف هنا مباشرةً وتُملأ قيمه فوراً قبل أي حدث آخر
                if (!dgvAppointments.Columns.Contains("RowIndex"))
                {
                    var idxCol = new DataGridViewTextBoxColumn
                    {
                        Name = "RowIndex",
                        HeaderText = "#",
                        Width = 36,
                        ReadOnly = true,
                        SortMode = DataGridViewColumnSortMode.NotSortable
                    };
                    dgvAppointments.Columns.Insert(0, idxCol);
                }

                // ملء أرقام الترقيم فوراً بعد إضافة العمود
                for (int i = 0; i < dgvAppointments.Rows.Count; i++)
                    dgvAppointments.Rows[i].Cells["RowIndex"].Value = (i + 1).ToString();

                // --- عمود وقت الموعد المخصص ---
                // يعرض وقت الموعد (الساعة:الدقيقة ص/م) مستخلصاً من AppointmentDate
                if (!dgvAppointments.Columns.Contains("AppointmentTime"))
                {
                    var timeCol = new DataGridViewTextBoxColumn
                    {
                        Name = "AppointmentTime",
                        HeaderText = "الوقت",
                        Width = 80,
                        ReadOnly = true,
                        SortMode = DataGridViewColumnSortMode.NotSortable
                    };
                    // أدرج بعد عمود التاريخ مباشرةً
                    int dateIdx = dgvAppointments.Columns.Contains("AppointmentDate")
                        ? dgvAppointments.Columns["AppointmentDate"].DisplayIndex + 1
                        : 1;
                    dgvAppointments.Columns.Insert(dateIdx, timeCol);
                }

                // ملء قيم وقت الموعد من حقل AppointmentDate
                if (dgvAppointments.Columns.Contains("AppointmentTime") &&
                    dgvAppointments.Columns.Contains("AppointmentDate"))
                {
                    foreach (DataGridViewRow row in dgvAppointments.Rows)
                    {
                        if (row.Cells["AppointmentDate"].Value is DateTime dt)
                            row.Cells["AppointmentTime"].Value = dt.ToString("hh:mm tt");
                    }
                }

                // 1. إخفاء الأعمدة التقنية وأعمدة النطاق الزمني غير المطلوبة
                string[] hiddenCols = {
                    "AppointmentID", "CustomerID", "CreatedBy", "SelectedServices", "Notes",
                    "ArrivalTime",  // مخفي — يُغني عنه عمود "الوقت" المشتق من AppointmentDate
                    "FinishTime"    // مخفي — غير مطلوب في عرض الجدول
                };
                foreach (var col in hiddenCols)
                    if (dgvAppointments.Columns.Contains(col))
                        dgvAppointments.Columns[col].Visible = false;

                // 2. تعريب وتنسيق الأعمدة المرئية
                if (dgvAppointments.Columns.Contains("AppointmentDate"))
                {
                    dgvAppointments.Columns["AppointmentDate"].HeaderText = "التاريخ";
                    dgvAppointments.Columns["AppointmentDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
                    dgvAppointments.Columns["AppointmentDate"].Width = 95;
                }

                if (dgvAppointments.Columns.Contains("CustomerName"))
                {
                    dgvAppointments.Columns["CustomerName"].HeaderText = "اسم العميلة";
                    dgvAppointments.Columns["CustomerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvAppointments.Columns["CustomerName"].MinimumWidth = 120;
                }

                if (dgvAppointments.Columns.Contains("TotalPrice"))
                {
                    dgvAppointments.Columns["TotalPrice"].HeaderText = "الإجمالي";
                    dgvAppointments.Columns["TotalPrice"].Width = 80;
                    dgvAppointments.Columns["TotalPrice"].DefaultCellStyle.Format = "N2";
                }

                if (dgvAppointments.Columns.Contains("Status"))
                {
                    dgvAppointments.Columns["Status"].HeaderText = "الحالة";
                    dgvAppointments.Columns["Status"].Width = 90;
                }

                dgvAppointments.ReadOnly = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FormatGrid error: {ex.Message}");
            }
        }

        private void FormatDetailsGrid()
        {
            if (dgvDetails.Columns.Count == 0) return;

            // 1. إدارة عمود الأزرار (إضافته في النهاية)
            if (!dgvDetails.Columns.Contains("ActionBtn"))
            {
                DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
                btnCol.Name = "ActionBtn";
                btnCol.HeaderText = "إجراء";
                btnCol.FlatStyle = FlatStyle.Flat;
                btnCol.Width = 80;
                dgvDetails.Columns.Add(btnCol); // إضافة في النهاية
            }
            else
            {
                // التأكد من بقائه في الأخير حتى بعد تحديث الـ DataSource
                dgvDetails.Columns["ActionBtn"].DisplayIndex = dgvDetails.Columns.Count - 1;
            }

            // 2. إخفاء الأعمدة التي تسبب زحاماً
            string[] hiddenCols = { "ServiceID", "MaterialID", "AppointmentID", "DetailID", "EmployeeID", "CommissionAmount", "IsMaterial" };
            foreach (var col in hiddenCols)
            {
                if (dgvDetails.Columns.Contains(col))
                    dgvDetails.Columns[col].Visible = false;
            }
            if (dgvDetails.Columns.Contains("RoomName"))
            {
                dgvDetails.Columns["RoomName"].HeaderText = "الغرفة";
            }

            if (dgvDetails.Columns.Contains("Quantity"))
            {
                dgvDetails.Columns["Quantity"].HeaderText = "الكمية";
                dgvDetails.Columns["Quantity"].Width = 50;
            }

            if (dgvDetails.Columns.Contains("Price"))
            {
                dgvDetails.Columns["Price"].HeaderText = "السعر";
                dgvDetails.Columns["Price"].DefaultCellStyle.Format = "N2";
                dgvDetails.Columns["Price"].Width = 70;
            }

            // 3. تعريب وتعديل عرض الأعمدة
            if (dgvDetails.Columns.Contains("Name"))
            {
                dgvDetails.Columns["Name"].HeaderText = "الخدمة/المنتج";
                dgvDetails.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (dgvDetails.Columns.Contains("EmployeeName"))
            {
                dgvDetails.Columns["EmployeeName"].HeaderText = "الموظفة";
                dgvDetails.Columns["EmployeeName"].Width = 100;
            }

            if (dgvDetails.Columns.Contains("ActualStartTime"))
            {
                dgvDetails.Columns["ActualStartTime"].HeaderText = "بدء";
                dgvDetails.Columns["ActualStartTime"].DefaultCellStyle.Format = "hh:mm tt";
                dgvDetails.Columns["ActualStartTime"].Width = 70;
            }

            if (dgvDetails.Columns.Contains("ActualEndTime"))
            {
                dgvDetails.Columns["ActualEndTime"].HeaderText = "نهاية";
                dgvDetails.Columns["ActualEndTime"].DefaultCellStyle.Format = "hh:mm tt";
                dgvDetails.Columns["ActualEndTime"].Width = 70;
            }

            if (dgvDetails.Columns.Contains("Status"))
            {
                dgvDetails.Columns["Status"].HeaderText = "الحالة";
                dgvDetails.Columns["Status"].Width = 85;
            }

            dgvDetails.ReadOnly = true;
            if (dgvDetails.Columns.Contains("ActionBtn"))
                dgvDetails.Columns["ActionBtn"].ReadOnly = false;
        }

        private void dgvDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDetails.Columns[e.ColumnIndex].Name == "ActionBtn" && e.RowIndex >= 0)
            {
                var row = dgvDetails.Rows[e.RowIndex];
                string status = row.Cells["Status"].Value?.ToString() ?? "Pending";

                bool isMaterial = dgvDetails.Columns.Contains("MaterialID") &&
                                  row.Cells["MaterialID"].Value != null &&
                                  row.Cells["MaterialID"].Value != DBNull.Value &&
                                  row.Cells["MaterialID"].Value.ToString() != "0";

                DataGridViewButtonCell cell = (DataGridViewButtonCell)row.Cells["ActionBtn"];

                if (status == "Pending")
                {
                    e.Value = isMaterial ? "تم التسليم" : "ابدأ";
                    cell.Style.BackColor = isMaterial ? Color.DodgerBlue : Color.MediumSeaGreen;
                    cell.Style.ForeColor = Color.White;
                }
                else if (status == "InProgress")
                {
                    e.Value = "إنهاء";
                    cell.Style.BackColor = Color.Orange;
                    cell.Style.ForeColor = Color.White;
                }
                else if (status == "Completed" || status == "Canceled")
                {
                    e.Value = status == "Completed" ? "مكتمل" : "ملغي";
                    cell.Style.BackColor = Color.LightGray;
                    cell.Style.ForeColor = Color.DarkGray;
                }
            }
        }

        private async void dgvDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAppointments.CurrentRow == null) return;

            if (e.RowIndex >= 0 && dgvDetails.Columns[e.ColumnIndex].Name == "ActionBtn")
            {
                var row = dgvDetails.Rows[e.RowIndex];
                string status = row.Cells["Status"].Value?.ToString() ?? "Pending";

                if (status == "Completed" || status == "Canceled") return;

                try
                {
                    int detailId = Convert.ToInt32(row.Cells["DetailID"].Value);
                    int appointmentId = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["AppointmentID"].Value);

                    bool isMaterial = dgvDetails.Columns.Contains("MaterialID") &&
                                      row.Cells["MaterialID"].Value != null &&
                                      row.Cells["MaterialID"].Value != DBNull.Value &&
                                      row.Cells["MaterialID"].Value.ToString() != "0";

                    if (status == "Pending")
                    {
                        if (isMaterial)
                            await _appointmentRepo.CompleteServiceAsync(detailId, appointmentId);
                        else
                            await _appointmentRepo.StartServiceAsync(detailId, appointmentId);
                    }
                    else if (status == "InProgress")
                    {
                        await _appointmentRepo.CompleteServiceAsync(detailId, appointmentId);
                    }

                    await LoadAppointments();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ أثناء تنفيذ العملية: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void dgvAppointments_SelectionChanged(object sender, EventArgs e)
        {
            // لا تُفعّل هذا الحدث أثناء عملية تحميل البيانات لتجنب التعارض
            if (_isLoadingAppointments) return;

            if (dgvAppointments.CurrentRow != null && dgvAppointments.CurrentRow.Index >= 0 && dgvAppointments.Focused)
            {
                try
                {
                    int appId = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["AppointmentID"].Value);
                    await RefreshDetails(appId);
                }
                catch
                {
                    dgvDetails.DataSource = null;
                    dgvDetails.Columns.Clear();
                }
            }
        }

        private async void UC_Appointments_Load(object sender, EventArgs e)
        {
            ApplyButtonStyles();
            await LoadRooms();
            await LoadAppointments();
        }

        private async Task LoadRooms()
        {
            try
            {
                var rooms = (await _roomRepo.GetAllAsync()).ToList();
                rooms.Insert(0, new beautyCenterSystem.Room { RoomID = 0, RoomName = "الكل" });
                cmbFilterRoom.DataSource = rooms;
                cmbFilterRoom.DisplayMember = "RoomName";
                cmbFilterRoom.ValueMember = "RoomID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل الغرف: {ex.Message}");
            }
        }

        private async void cmbFilterRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbFilterRoom.SelectedIndex >= 0)
                {
                    await LoadAppointments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تصفية الغرف: {ex.Message}");
            }
        }

        private void dgvAppointments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // الترقيم التسلسلي يُعالج الآن مباشرةً داخل FormatGrid()
            // بعد إنشاء عمود RowIndex، مما يضمن وجود العمود قبل ملء القيم.
        }

        private void ApplyButtonStyles()
        {
            btnRefresh.Size = new Size(76, 67);
            btnRefresh.ForeColor = AppTheme.Charcoal;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 1;
            btnRefresh.FlatAppearance.BorderColor = AppTheme.Charcoal;
            btnRefresh.BackColor = Color.White;
            btnRefresh.TextAlign = ContentAlignment.MiddleCenter;
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
                    .Where(a => a.CustomerName != null && a.CustomerName.ToLower().Contains(filter)).ToList();
            }
            FormatGrid();
        }

        private async void btnAddAppointment_Click(object sender, EventArgs e)
        {
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

                if (currentStatus == "Cancelled")
                {
                    MessageBox.Show("عذراً، لا يمكن إتمام أو دفع حجز ملغي.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (currentStatus == "Completed")
                {
                    MessageBox.Show("هذا الحجز مكتمل ومدفوع بالفعل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (currentStatus != "Finished")
                {
                    var confirm = MessageBox.Show("انتباه: لا تزال هناك خدمات قيد التنفيذ أو قيد الانتظار في هذا الحجز! هل تريد إجبار إنهاء الحجز والانتقال للدفع؟", "تأكيد الدفع المبكر", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.No) return;
                }

                using (var payForm = new CheckoutForm(customerName, totalAmount))
                {
                    if (payForm.ShowDialog() == DialogResult.OK)
                    {
                        bool isSuccess = await _appointmentRepo.CompleteAndPayAsync(
                            appId, totalAmount, payForm.AmountPaid, payForm.Discount,
                            payForm.PaymentMethod, CurrentSession.UserID);

                        if (isSuccess)
                        {
                            await LoadAppointments();

                            try
                            {
                                var settingsRepo = new SettingsRepository(new DbConnectionFactory());
                                var settings = await settingsRepo.GetSettingsAsync();
                                var services = await _appointmentRepo.GetAppointmentServicesAsync(appId);

                                ReceiptPrinter printer = new ReceiptPrinter
                                {
                                    CenterName = settings.CenterName ?? "صالون التجميل",
                                    Phone = settings.Phone ?? "",
                                    Policy = settings.Note ?? "شكراً لزيارتكم.",
                                    Logo = settings.GetLogoImage(),
                                    FacebookHandle = settings.Facebook,
                                    InstagramHandle = settings.Instagram,
                                    WhatsAppHandle = settings.WhatsApp,
                                    InvoiceNumber = appId,
                                    CustomerName = customerName,
                                    AppointmentDateTime = dtpFilterDate.Value.ToString("yyyy-MM-dd hh:mm tt"),
                                    TotalAmount = totalAmount,
                                    Discount = payForm.Discount,
                                    NetAmount = payForm.AmountPaid,
                                    CashierName = CurrentSession.Username,
                                    Items = services.Select(s => new InvoiceItem
                                    {
                                        ServiceName = s.Name,
                                        RoomName = s.RoomName,
                                        Quantity = s.Quantity > 0 ? s.Quantity : 1,
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
                var settingsRepo = new SettingsRepository(new DbConnectionFactory());
                var settings = await settingsRepo.GetSettingsAsync();
                var services = await _appointmentRepo.GetAppointmentServicesAsync(appId);
                var row = dgvAppointments.CurrentRow;

                ReceiptPrinter printer = new ReceiptPrinter
                {
                    CenterName = settings.CenterName,
                    Phone = settings.Phone,
                    Logo = settings.GetLogoImage(),
                    Policy = settings.Note + "\n(نسخة طباعة فقط)",
                    FacebookHandle = settings.Facebook,
                    InstagramHandle = settings.Instagram,
                    WhatsAppHandle = settings.WhatsApp,
                    InvoiceNumber = appId,
                    CustomerName = row.Cells["CustomerName"].Value.ToString(),
                    AppointmentDateTime = dtpFilterDate.Value.ToString("yyyy-MM-dd hh:mm tt"),
                    TotalAmount = Convert.ToDecimal(row.Cells["TotalPrice"].Value),
                    NetAmount = Convert.ToDecimal(row.Cells["TotalPrice"].Value),
                    CashierName = CurrentSession.Username,
                    Items = services.Select(s => new InvoiceItem
                    {
                        ServiceName = s.Name,
                        RoomName = s.RoomName,
                        Quantity = s.Quantity > 0 ? s.Quantity : 1,
                        Price = s.Price
                    }).ToList()
                };

                printer.PrintReceipt(showPreview: false);
            }
            catch (Exception ex) { MessageBox.Show("خطأ في الطباعة: " + ex.Message); }
        }
    }
}