using beautyCenterSystem.Data.Repositories;
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

namespace beautyCenterSystem
{
    public partial class AddAppointmentForm : Form
    {
        private readonly ServiceRepository _serviceRepo;
        private readonly AppointmentRepository _appointmentRepo;
        private readonly CustomerRepository _customerRepo;
        private int _editAppId = 0;

        // متغير لاسم الموظفة الحالية (يمكنك جلبها من شاشة تسجيل الدخول لاحقاً)
        private string _currentUserName = "الموظفة الحالية";

        public AddAppointmentForm()
        {
            InitializeComponent();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            _serviceRepo = new ServiceRepository(new DbConnectionFactory());
            _appointmentRepo = new AppointmentRepository(new DbConnectionFactory());
            _customerRepo = new CustomerRepository(new DbConnectionFactory());
        }

        public AddAppointmentForm(int appId) : this()
        {
            _editAppId = appId;
            this.Text = "تعديل بيانات الحجز";
            btnSave.Text = "تحديث البيانات";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        }

        private async Task LoadAppointmentDataForEdit()
        {
            if (_editAppId <= 0) return;

            try
            {
                var currentApp = await _appointmentRepo.GetByIdAsync(_editAppId);

                if (currentApp != null)
                {
                    cmbCustomerSearch.SelectedValue = currentApp.CustomerID;
                    dtpAppointmentDate.Value = currentApp.AppointmentDate.Date;
                    dtpAppointmentTime.Value = currentApp.AppointmentDate;
                }

                var selectedServices = await _appointmentRepo.GetAppointmentServicesAsync(_editAppId);
                var selectedServiceIds = selectedServices.Select(s => s.ServiceID).ToList();

                foreach (ListViewItem item in lvServices.Items)
                {
                    if (item.Tag is Service service)
                    {
                        if (selectedServiceIds.Contains(service.ServiceID))
                        {
                            item.Checked = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل بيانات التعديل: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadServicesToListView()
        {
            try
            {
                var services = await _serviceRepo.GetAllWithRoomNamesAsync();
                lvServices.Items.Clear();

                foreach (var service in services)
                {
                    ListViewItem item = new ListViewItem(service.ServiceName);
                    item.SubItems.Add(service.Price.ToString("N2"));
                    item.SubItems.Add($"{service.DurationMinutes} دقيقة");
                    item.Tag = service;
                    lvServices.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل الخدمات: {ex.Message}");
            }
        }

        private async Task LoadCustomersToCombo()
        {
            try
            {
                var customers = await _customerRepo.GetAllAsync();
                cmbCustomerSearch.DataSource = customers.ToList();
                cmbCustomerSearch.DisplayMember = "CustomerName";
                cmbCustomerSearch.ValueMember = "CustomerID";
                cmbCustomerSearch.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل قائمة العميلات: {ex.Message}");
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. التحقق من البيانات الأساسية
                if (cmbCustomerSearch.SelectedValue == null)
                {
                    MessageBox.Show("من فضلك، اختر عميلة أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (lvServices.CheckedItems.Count == 0)
                {
                    MessageBox.Show("يجب اختيار خدمة واحدة على الأقل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. تجميع التاريخ والوقت في متغير واحد
                DateTime appointmentFullDate = dtpAppointmentDate.Value.Date + dtpAppointmentTime.Value.TimeOfDay;

                // 3. تجهيز الخدمات المختارة وحساب الإجمالي
                var selectedServices = new List<Service>();
                int totalMinutes = 0;
                decimal totalPrice = 0;

                foreach (ListViewItem item in lvServices.CheckedItems)
                {
                    var service = (Service)item.Tag;
                    selectedServices.Add(service);
                    totalMinutes += service.DurationMinutes;
                    totalPrice += service.Price;
                }

                // 4. فحص تعارض المواعيد
                var serviceIds = selectedServices.Select(s => s.ServiceID).ToList();
                string conflictResult = await _appointmentRepo.CheckConflictAsync(appointmentFullDate, totalMinutes, serviceIds);

                if (!string.IsNullOrEmpty(conflictResult))
                {
                    var confirm = MessageBox.Show(
                        $"تنبيه تعارض: {conflictResult} مشغولة في هذا الوقت.\nهل تريد إتمام العملية على أي حال؟",
                        "تأكيد التعارض", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.No) return;
                }

                // 5. إنشاء كائن الحجز (Appointment Object)
                var appointmentData = new Appointment
                {
                    AppointmentID = _editAppId,
                    CustomerID = (int)cmbCustomerSearch.SelectedValue,
                    AppointmentDate = appointmentFullDate,
                    TotalPrice = totalPrice,
                    Status = "Pending",
                    CreatedBy = 1, // معرف الموظف الحالي
                    SelectedServices = selectedServices
                };

                // 6. تنفيذ العملية (إضافة أو تحديث)
                bool isSuccess = false;

                if (_editAppId > 0)
                {
                    // حالة التعديل
                    isSuccess = await _appointmentRepo.UpdateAsync(appointmentData);
                }
                else
                {
                    // حالة إضافة جديدة (إرجاع الـ ID للتأكد من النجاح فقط)
                    int finalAppId = await _appointmentRepo.CreateAndGetIdAsync(appointmentData);
                    isSuccess = finalAppId > 0;
                }

                // 7. النتيجة النهائية وإغلاق الفورم
                if (isSuccess)
                {
                    string msg = _editAppId > 0 ? "تم تحديث بيانات الحجز بنجاح!" : "تم تسجيل الحجز بنجاح!";
                    MessageBox.Show(msg, "تم العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvServices_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            decimal total = 0;
            int totalMinutes = 0;

            foreach (ListViewItem item in lvServices.CheckedItems)
            {
                var service = (Service)item.Tag;
                total += service.Price;
                totalMinutes += service.DurationMinutes;
            }

            lblTotalPrice.Text = $"إجمالي السعر: {total:N2} د.ل";
            lblTotalDuration.Text = $"المدة الإجمالية: {totalMinutes} دقيقة";
        }

        private async void btnAddCustomer_Click(object sender, EventArgs e)
        {
            using (var customerForm = new AddCustomerForm())
            {
                if (customerForm.ShowDialog() == DialogResult.OK)
                {
                    await LoadCustomersToCombo();
                    MessageBox.Show("تم إضافة العميلة وتحديث القائمة بنجاح.");
                    if (cmbCustomerSearch.Items.Count > 0)
                    {
                        cmbCustomerSearch.SelectedIndex = 0;
                    }
                }
            }
        }

        private async void AddAppointmentForm_Load(object sender, EventArgs e)
        {
            try
            {
                AppTheme.Apply(this);
                BtnCancel.BackColor = Color.DarkGray;
                SetupServicesListView();

                await Task.WhenAll(LoadServicesToListView(), LoadCustomersToCombo());

                dtpAppointmentTime.Format = DateTimePickerFormat.Custom;
               dtpAppointmentTime.CustomFormat = "mm : hh tt";
                dtpAppointmentTime.ShowUpDown = true;

                dtpAppointmentDate.Value = DateTime.Now;
                dtpAppointmentTime.Value = DateTime.Now;

                if (_editAppId > 0)
                {
                    await LoadAppointmentDataForEdit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تهيئة الشاشة: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnSave.PerformClick();
                return true;
            }
            if (keyData == Keys.Escape)
            {
                BtnCancel.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SetupServicesListView()
        {
            lvServices.View = View.Details;
            lvServices.FullRowSelect = true;
            lvServices.CheckBoxes = true;
            lvServices.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvServices.RightToLeft = RightToLeft.Yes;
            lvServices.RightToLeftLayout = true;

            lvServices.Columns.Clear();
            lvServices.Columns.Add("الخدمة", 220, HorizontalAlignment.Right);
            lvServices.Columns.Add("السعر", 100, HorizontalAlignment.Center);
            lvServices.Columns.Add("المدة", 100, HorizontalAlignment.Center);

            lvServices.ItemChecked -= lvServices_ItemChecked;
            lvServices.ItemChecked += lvServices_ItemChecked;
        }
    }
}