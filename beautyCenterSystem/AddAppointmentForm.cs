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
        public AddAppointmentForm()
        {
            InitializeComponent();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            _serviceRepo = new ServiceRepository(new DbConnectionFactory());
            _appointmentRepo = new AppointmentRepository(new DbConnectionFactory());
            _customerRepo = new CustomerRepository(new DbConnectionFactory());

           


        }
        public AddAppointmentForm(int appId) : this() // يستدعي الكونستركتر الأول لتهيئة الـ Repos والأدوات
        {
            _editAppId = appId;
            this.Text = "تعديل بيانات الحجز";
            btnSave.Text = "تحديث البيانات"; // تغيير نص الزر ليناسب العملية
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;

        }
        private async Task LoadAppointmentDataForEdit()
        {
            if (_editAppId <= 0) return;

            try
            {
                // 1. جلب بيانات الحجز الأساسية بالـ ID مباشرة
                // (تأكد من إضافة دالة GetByIdAsync في AppointmentRepository كما فعلنا في الخطوة السابقة)
                var currentApp = await _appointmentRepo.GetByIdAsync(_editAppId);

                if (currentApp != null)
                {
                    // 2. تحديد العميلة في الكومبوبوكس
                    // تأكد أنك قمت بضبط ValueMember = "CustomerID" عند تحميل الكومبوبوكس
                    cmbCustomerSearch.SelectedValue = currentApp.CustomerID;

                    // 3. ضبط التاريخ والوقت من قاعدة البيانات
                    // أداة التاريخ تأخذ الجزء الخاص بالتاريخ فقط
                    dtpAppointmentDate.Value = currentApp.AppointmentDate.Date;

                    // أداة الوقت تأخذ التاريخ الكامل وهي ستعرض الوقت بناءً على التنسيق (tt mm : hh)
                    dtpAppointmentTime.Value = currentApp.AppointmentDate;
                }

                // 4. جلب الخدمات التي اختارتها العميلة سابقاً لهذا الحجز
                var selectedServices = await _appointmentRepo.GetAppointmentServicesAsync(_editAppId);
                var selectedServiceIds = selectedServices.Select(s => s.ServiceID).ToList();

                // 5. المرور على ListView وعمل علامة صح (Checked) على الخدمات المختارة
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
                // استخدام الدالة الموجودة في الريبو الخاص بك
                var services = await _serviceRepo.GetAllWithRoomNamesAsync();

                lvServices.Items.Clear();

                foreach (var service in services)
                {
                    // إنشاء سطر جديد في القائمة
                    ListViewItem item = new ListViewItem(service.ServiceName);
                    item.SubItems.Add(service.Price.ToString("N2"));
                    item.SubItems.Add($"{service.DurationMinutes} دقيقة");

                    // تخزين كائن الخدمة بالكامل في الـ Tag للوصول إليه عند الحساب
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
                // جلب العميلات من ريبوستري العملاء
                // تأكد أن اسم الدالة في ريبو العملاء هو GetAllCustomersAsync أو ما يشبهه
                var customers = await _customerRepo.GetAllAsync();

                // ربط البيانات بالكومبو بوكس
                cmbCustomerSearch.DataSource = customers.ToList();
                cmbCustomerSearch.DisplayMember = "CustomerName";
                cmbCustomerSearch.ValueMember = "CustomerID";

                // جعل الكومبو يبدأ بدون اختيار (فارغ)
                cmbCustomerSearch.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل قائمة العميلات: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. التحقق من البيانات الأساسية (Validation)
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
                DateTime appointmentFullDate = dtpAppointmentDate.Value.Date
                                             + dtpAppointmentTime.Value.TimeOfDay;

                // 3. تجهيز قائمة الخدمات المختارة والمدة الإجمالية لفحص التعارض
                var selectedServices = new List<Service>();
                int totalMinutes = 0;
                decimal totalPrice = 0;

                foreach (ListViewItem item in lvServices.CheckedItems)
                {
                    var service = (Service)item.Tag; // التأكد من وجود الكائن في الـ Tag
                    selectedServices.Add(service);
                    totalMinutes += service.DurationMinutes;
                    totalPrice += service.Price;
                }

                // 4. استدعاء "محرّك فحص التعارض" (Conflict Check)
                var serviceIds = selectedServices.Select(s => s.ServiceID).ToList();
                string conflictResult = await _appointmentRepo.CheckConflictAsync(appointmentFullDate, totalMinutes, serviceIds);

                // ملاحظة: في حالة التعديل، قد يظهر تعارض مع "نفس الحجز" القديم. 
                // إذا كان النظام دقيقاً جداً يفضل تعديل دالة الاستعلام لتتجاهل _editAppId
                if (!string.IsNullOrEmpty(conflictResult))
                {
                    var confirm = MessageBox.Show(
                        $"تنبيه تعارض: {conflictResult} مشغولة في هذا الوقت.\nهل تريد إتمام العملية على أي حال؟",
                        "تأكيد التعارض",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirm == DialogResult.No) return;
                }

                // 5. إنشاء كائن الحجز (Appointment Object)
                // نمرر الـ _editAppId سواء كانت 0 (إضافة) أو رقم الحجز (تعديل)
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

                // 6. تنفيذ العملية (حفظ جديد أو تحديث)
                bool isSuccess;
                string successMessage;

                if (_editAppId > 0)
                {
                    // حالة التعديل
                    isSuccess = await _appointmentRepo.UpdateAsync(appointmentData);
                    successMessage = "تم تحديث بيانات الحجز بنجاح!";
                }
                else
                {
                    // حالة إضافة جديدة
                    isSuccess = await _appointmentRepo.CreateAsync(appointmentData);
                    successMessage = "تم تسجيل الحجز بنجاح!";
                }

                // 7. النتيجة النهائية
                if (isSuccess)
                {
                    MessageBox.Show(successMessage, "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // إغلاق الفورم وإعلام الشاشة الرئيسية بالتحديث
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

            // المرور على جميع العناصر التي بجانبها علامة صح
            foreach (ListViewItem item in lvServices.CheckedItems)
            {
                // استعادة بيانات الخدمة من الـ Tag
                var service = (Service)item.Tag;

                total += service.Price;
                totalMinutes += service.DurationMinutes;
            }

            // تحديث الليبلات في الواجهة
            lblTotalPrice.Text = $"إجمالي السعر: {total:N2} د.ل";
            lblTotalDuration.Text = $"المدة الإجمالية: {totalMinutes} دقيقة";
        }

        private async void btnAddCustomer_Click(object sender, EventArgs e)
        {
            // 1. فتح فورم إضافة عميلة كـ Dialog (نافذة منبثقة)
            // نمرر الريبوستري الخاص بالعميلات للفورم الجديد
            using (var customerForm = new AddCustomerForm())
            {
                if (customerForm.ShowDialog() == DialogResult.OK)
                {
                    // 2. إذا تم الحفظ بنجاح، نقوم بتحديث القائمة في الكومبو بوكس
                    await LoadCustomersToCombo();

                    // 3. (حركة ذكية) اختيار آخر عميلة تمت إضافتها تلقائياً
                    // نفترض أن الفورم يعيد لنا معرف العميلة الجديدة أو نبحث عن أكبر ID
                    // لكن للسهولة سنعيد تحميل القائمة فقط
                    MessageBox.Show("تم إضافة العميلة وتحديث القائمة بنجاح.");
                    cmbCustomerSearch.SelectedIndex = cmbCustomerSearch.Items.Count - 1;

                }
            }
        }

        private async void AddAppointmentForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. تطبيق التنسيق والسمة العامة
                AppTheme.Apply(this);
                BtnCancel.BackColor = Color.DarkGray;
                SetupServicesListView(); // إعداد الأعمدة والخصائص للـ ListView

                // 2. تحميل البيانات الأساسية (الخدمات والعميلات) بالتوازي لتسريع العملية
                await Task.WhenAll(LoadServicesToListView(), LoadCustomersToCombo());

                // 3. ضبط تنسيق أدوات التاريخ والوقت
                dtpAppointmentTime.Format = DateTimePickerFormat.Custom;
                dtpAppointmentTime.CustomFormat = "tt mm : hh"; // التنسيق القياسي (ساعة:دقيقة صباحاً/مساءً)
                dtpAppointmentTime.ShowUpDown = true;

                // 4. ضبط القيم الافتراضية للتاريخ
                dtpAppointmentDate.Value = DateTime.Now;
                dtpAppointmentTime.Value = DateTime.Now;

                // 💡 5. منطق التعديل: إذا كان هناك ID، قم بتحميل بيانات الحجز فوق البيانات الأساسية
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
            // إذا ضغط المستخدم Enter وكان التركيز (Focus) "ليس" في حقل الملاحظات
            if (keyData == Keys.Enter)
            {
                btnSave.PerformClick(); // نفذ كود زر الحفظ
                return true; // أخبر النظام أننا تعاملنا مع الضغطة ولا داعي لعمل "Beep"
            }

            // إذا ضغط Esc، أغلق الفورم (مثل زر الكانسل)
            if (keyData == Keys.Escape)
            {
                BtnCancel.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void SetupServicesListView()
        {
            // 1. الإعدادات الأساسية
            lvServices.View = View.Details;
            lvServices.FullRowSelect = true;
            lvServices.CheckBoxes = true;
            lvServices.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            // 💡 السر هنا: يجب تفعيل هاتين الخاصيتين معاً
            lvServices.RightToLeft = RightToLeft.Yes;
            lvServices.RightToLeftLayout = true; // هذا السطر هو الذي يقلب ترتيب الأعمدة فعلياً

            // 2. إضافة الأعمدة (في وضع الـ RightToLeftLayout، العمود الأول المضاف سيظهر في أقصى اليمين)
            lvServices.Columns.Clear();

            // العمود الأول (سيكون في أقصى اليمين)
            lvServices.Columns.Add("الخدمة", 220, HorizontalAlignment.Right);
            // العمود الثاني
            lvServices.Columns.Add("السعر", 100, HorizontalAlignment.Center);
            // العمود الثالث
            lvServices.Columns.Add("المدة", 100, HorizontalAlignment.Center);

            // ربط الحدث
            lvServices.ItemChecked -= lvServices_ItemChecked;
            lvServices.ItemChecked += lvServices_ItemChecked;
        }

    }
}
