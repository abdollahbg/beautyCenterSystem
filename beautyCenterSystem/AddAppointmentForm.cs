using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using BeautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beautyCenterSystem
{
    public partial class AddAppointmentForm : Form
    {
        private readonly ServiceRepository _serviceRepo;
        private readonly AppointmentRepository _appointmentRepo;
        private readonly CustomerRepository _customerRepo;
        private readonly RoomRepository _roomRepo;
        private int _editAppId = 0;

        private UC_CartSummary _cartSummary;
        private UC_RoomNavigator _roomNav;
        private UC_ServiceSelector _serviceSelector;

        private List<Service> _selectedServices = new List<Service>();

        public AddAppointmentForm()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;

            var factory = new DbConnectionFactory();
            _serviceRepo = new ServiceRepository(factory);
            _appointmentRepo = new AppointmentRepository(factory);
            _customerRepo = new CustomerRepository(factory);
            _roomRepo = new RoomRepository(factory);
        }

        public AddAppointmentForm(int appId) : this()
        {
            _editAppId = appId;
            this.Text = "تعديل بيانات الحجز";
        }

        private async void AddAppointmentForm_Load(object sender, EventArgs e)
        {
            try
            {
                SetupNewUI();
                await InitializeData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل البيانات: {ex.Message}");
            }
        }

        private void SetupNewUI()
        {
            _cartSummary = new UC_CartSummary { Dock = DockStyle.Fill };
            pnlSidebar.Controls.Clear();
            pnlSidebar.Controls.Add(_cartSummary);

            _cartSummary.OnAddCustomerClicked += btnAddCustomer_Click;
            _cartSummary.OnSaveAppointmentClicked += btnSave_Click;
            _cartSummary.OnRemoveServiceRequested += (s, id) => {
                var item = _selectedServices.FirstOrDefault(x => x.ServiceID == id);
                if (item != null)
                {
                    _selectedServices.Remove(item);
                    _cartSummary.RefreshCart(_selectedServices);
                }
            };

            _roomNav = new UC_RoomNavigator();
            // لضمان عدم تغير شكل الكارد، تأكد أن UC_RoomNavigator يحتوي على FlowLayoutPanel 
            // بخاصية WrapContents = true و Anchor محدد بشكل صحيح.
            _roomNav.OnRoomSelected += async (s, id) => await OpenRoomServices(id);

            _serviceSelector = new UC_ServiceSelector();
            _serviceSelector.OnBackClicked += (s, ev) => ShowUC(_roomNav);
            _serviceSelector.OnServiceAdded += async (s, id) => await AddServiceToCart(id);

            dtpAppointmentDate.Value = DateTime.Now;
            dtpAppointmentTime.Value = DateTime.Now;

            AppTheme.Apply(this);
        }

        private async Task InitializeData()
        {
            await LoadCustomersToCartCombo();

            // جلب الغرف (ويمكن فلترتها هنا إذا كان هناك عمود IsActive للغرف)
            var rooms = await _roomRepo.GetAllAsync();
            _roomNav.LoadRooms(rooms.ToList());

            ShowUC(_roomNav);

            if (_editAppId > 0) await LoadAppointmentDataForEdit();
        }

        private void ShowUC(UserControl uc)
        {
            // 1. إذا لم تكن الواجهة مضافة مسبقاً للوحة العرض، قم بإضافتها
            if (!pnlMainContent.Controls.Contains(uc))
            {
                uc.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(uc);
            }

            // 2. اجلب الواجهة إلى المقدمة لتغطية الواجهات الأخرى (بدون مسحها)
            uc.BringToFront();

            // 3. إنعاش الواجهة لضمان جودة الرسم
            uc.Refresh();
        }

        private async Task OpenRoomServices(int roomId)
        {
            var allServices = await _serviceRepo.GetByRoomIdAsync(roomId);

            // التعديل: فلترة الخدمات النشطة فقط برمجياً لضمان عدم ظهور المحذوف
            var activeServices = allServices.Where(s => s.IsActive).ToList();

            var room = await _roomRepo.GetByIdAsync(roomId);
            _serviceSelector.LoadServices(room?.RoomName ?? "", activeServices);
            ShowUC(_serviceSelector);
        }

        private async Task AddServiceToCart(int serviceId)
        {
            var services = await _serviceRepo.GetAllWithRoomNamesAsync();

            // التعديل: التأكد من أن الخدمة المختارة نشطة وليست محذوفة
            var service = services.FirstOrDefault(s => s.ServiceID == serviceId && s.IsActive);

            if (service != null && !_selectedServices.Any(x => x.ServiceID == serviceId))
            {
                _selectedServices.Add(service);
                _cartSummary.RefreshCart(_selectedServices);
            }
        }

        private async Task LoadCustomersToCartCombo()
        {
            var customers = await _customerRepo.GetAllAsync();
            _cartSummary.FillCustomers(customers.ToList());
        }

        private async void btnAddCustomer_Click(object sender, EventArgs e)
        {
            using (var f = new AddCustomerForm())
                if (f.ShowDialog() == DialogResult.OK) await LoadCustomersToCartCombo();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int? customerId = _cartSummary.SelectedCustomerId;
                if (!customerId.HasValue || customerId <= 0 || _selectedServices.Count == 0)
                {
                    MessageBox.Show("يرجى اختيار عميلة وخدمة واحدة على الأقل.");
                    return;
                }

                DateTime fullDate = dtpAppointmentDate.Value.Date + dtpAppointmentTime.Value.TimeOfDay;
                var serviceIds = _selectedServices.Select(s => s.ServiceID).ToList();

                string conflict = await _appointmentRepo.CheckConflictAsync(fullDate, _selectedServices.Sum(s => s.DurationMinutes), serviceIds, _editAppId);
                if (!string.IsNullOrEmpty(conflict))
                {
                    if (MessageBox.Show($"{conflict} مشغولة. هل تريد المتابعة على أي حال؟", "تنبيه تعارض", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;
                }

                var app = new Appointment
                {
                    AppointmentID = _editAppId,
                    CustomerID = customerId.Value,
                    AppointmentDate = fullDate,
                    TotalPrice = _selectedServices.Sum(s => s.Price),
                    Status = "Pending",
                    CreatedBy = CurrentSession.UserID,
                    SelectedServices = _selectedServices
                };

                bool success = _editAppId > 0
                    ? await _appointmentRepo.UpdateAsync(app)
                    : (await _appointmentRepo.CreateAndGetIdAsync(app)) > 0;

                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ أثناء الحفظ: {ex.Message}");
            }
        }

        private async Task LoadAppointmentDataForEdit()
        {
            var app = await _appointmentRepo.GetByIdAsync(_editAppId);
            if (app != null)
            {
                dtpAppointmentDate.Value = app.AppointmentDate.Date;
                dtpAppointmentTime.Value = app.AppointmentDate;
                _cartSummary.SelectedCustomerId = app.CustomerID;
            }

            var services = await _appointmentRepo.GetAppointmentServicesAsync(_editAppId);
            // عند التعديل، نعرض الخدمات المحجوزة مسبقاً حتى لو أصبحت غير نشطة الآن لضمان دقة البيانات التاريخية
            _selectedServices = services.ToList();
            _cartSummary.RefreshCart(_selectedServices);
        }
    }
}