using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeautyCenterSystem.Data;
using BeautyCenterSystem.Models;
using beautyCenterSystem.Data.Repositories;
using beautyCenterSystem.viewsmodels;
using BeautyCenterSystem.Data.Repositories;

namespace beautyCenterSystem
{
    public partial class AddAppointmentForm : Form
    {
        private readonly ServiceRepository _serviceRepo;
        private readonly AppointmentRepository _appointmentRepo;
        private readonly CustomerRepository _customerRepo;
        private readonly RoomRepository _roomRepo;
        private readonly MaterialRepository _materialRepo;
        private readonly EmployeeRepository _employeeRepo;

        private int _editAppId = 0;
        private UC_CartSummary _cartSummary;
        private UC_RoomNavigator _roomNav;
        private UC_ServiceSelector _serviceSelector;

        private List<AppointmentDetailDto> _selectedServices = new List<AppointmentDetailDto>();

        public AddAppointmentForm()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;

            var factory = new DbConnectionFactory();
            _serviceRepo = new ServiceRepository(factory);
            _appointmentRepo = new AppointmentRepository(factory);
            _customerRepo = new CustomerRepository(factory);
            _roomRepo = new RoomRepository(factory);
            _materialRepo = new MaterialRepository(factory);
            _employeeRepo = new EmployeeRepository(factory);
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
                MessageBox.Show($"حدث خطأ أثناء تحميل البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupNewUI()
        {
            _cartSummary = new UC_CartSummary { Dock = DockStyle.Fill };
            _cartSummary.ItemColumnHeaderText = "الخدمة";
            while (pnlSidebar.Controls.Count > 0) { var c = pnlSidebar.Controls[0]; pnlSidebar.Controls.Remove(c); c.Dispose(); }
            pnlSidebar.Controls.Add(_cartSummary);

            _cartSummary.OnAddCustomerClicked += btnAddCustomer_Click;
            _cartSummary.OnSaveAppointmentClicked += btnSave_Click;

            // [تعديل]: تحديث القائمة البرمجية فقط وترك الـ UC يحدث الليبل الخاص به داخلياً
            _cartSummary.OnQuantityChanged += (id, newQty) =>
            {
                var item = _selectedServices.FirstOrDefault(x =>
                    (x.ServiceID.HasValue && x.ServiceID == id) ||
                    (x.MaterialID.HasValue && x.MaterialID == id));

                if (item != null)
                {
                    item.Quantity = newQty;
                    // لا نستدعي RefreshCart هنا لضمان ثبات الجدول
                    // ولا نستدعي lblTotalPrice لأن الـ UC يحدثه تلقائياً الآن
                }
            };

            _cartSummary.OnRemoveServiceRequested += (s, id) =>
            {
                var item = _selectedServices.FirstOrDefault(x =>
                    (x.ServiceID.HasValue && x.ServiceID == id) ||
                    (x.MaterialID.HasValue && x.MaterialID == id));

                if (item != null)
                {
                    _selectedServices.Remove(item);
                    _cartSummary.RefreshCart(_selectedServices);
                }
            };

            _roomNav = new UC_RoomNavigator();
            _roomNav.OnRoomSelected += async (s, room) => await OpenRoomServices(room);

            _serviceSelector = new UC_ServiceSelector();
            _serviceSelector.OnBackClicked += (s, ev) => ShowUC(_roomNav);
            _serviceSelector.OnServiceAdded += async (s, id) => await AddServiceToCart(id);
            _serviceSelector.OnMaterialAdded += async (s, id) => await AddMaterialToCart(id);

            dtpAppointmentDate.Value = DateTime.Now;
            dtpAppointmentTime.Value = DateTime.Now;

            AppTheme.Apply(this);
        }

        private async Task InitializeData()
        {
            await LoadCustomersToCartCombo();
            var rooms = await _roomRepo.GetAllAsync(includeCafeteria: false);
            _roomNav.LoadRooms(rooms.ToList());
            ShowUC(_roomNav);

            if (_editAppId > 0) await LoadAppointmentDataForEdit();
        }

        private void ShowUC(UserControl uc)
        {
            if (!pnlMainContent.Controls.Contains(uc))
            {
                uc.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(uc);
            }
            uc.BringToFront();
            uc.Refresh();
        }

        private async Task OpenRoomServices(Room room)
        {
            if (room == null) return;
            if (room.IsCaffeteria)
            {
                var materials = await _materialRepo.GetCaffeteriaMenuAsync();
                _serviceSelector.LoadMaterials(room.RoomName, materials.ToList());
            }
            else
            {
                var allServices = await _serviceRepo.GetByRoomIdAsync(room.RoomID);
                var activeServices = allServices.Where(s => s.IsActive).ToList();
                _serviceSelector.LoadServices(room, activeServices);
            }
            ShowUC(_serviceSelector);
        }

        private async Task AddServiceToCart(int serviceId)
        {
            var services = await _serviceRepo.GetAllWithRoomNamesAsync();
            var service = services.FirstOrDefault(s => s.ServiceID == serviceId && s.IsActive);

            if (service != null && !_selectedServices.Any(x => x.ServiceID == serviceId))
            {
                int? selectedEmployeeId = _serviceSelector.SelectedEmployeeId;
                if (selectedEmployeeId == null || selectedEmployeeId <= 0)
                {
                    MessageBox.Show("يرجى اختيار الموظفة أولاً لتتمكن من إضافة الخدمة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _selectedServices.Add(new AppointmentDetailDto
                {
                    ServiceID = service.ServiceID,
                    Name = service.ServiceName,
                    RoomName = service.RoomName,
                    Price = service.Price,
                    Quantity = 1,
                    EmployeeID = selectedEmployeeId.Value
                });
                _cartSummary.RefreshCart(_selectedServices);
            }
        }

        private async Task AddMaterialToCart(int materialId)
        {
            var material = await _materialRepo.GetByIdAsync(materialId);
            if (material != null)
            {
                var existing = _selectedServices.FirstOrDefault(x => x.MaterialID == materialId);
                if (existing != null)
                {
                    existing.Quantity++;
                }
                else
                {
                    _selectedServices.Add(new AppointmentDetailDto
                    {
                        MaterialID = material.MaterialID,
                        Name = material.MaterialName,
                        RoomName = "كافيتيريا",
                        Price = material.SalePrice,
                        Quantity = 1,
                        EmployeeID = null
                    });
                }
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
            {
                if (f.ShowDialog() == DialogResult.OK) await LoadCustomersToCartCombo();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int? customerId = _cartSummary.SelectedCustomerId;
                if (!customerId.HasValue || customerId <= 0 || _selectedServices.Count == 0)
                {
                    MessageBox.Show("يرجى اختيار عميلة وصنف واحد على الأقل.");
                    return;
                }

                DateTime fullDate = dtpAppointmentDate.Value.Date + dtpAppointmentTime.Value.TimeOfDay;
                var serviceIds = _selectedServices.Where(x => x.ServiceID.HasValue).Select(s => s.ServiceID.Value).ToList();

                if (serviceIds.Any())
                {
                    string conflict = await _appointmentRepo.CheckConflictAsync(fullDate, 60, serviceIds, _editAppId);
                    if (!string.IsNullOrEmpty(conflict))
                    {
                        if (MessageBox.Show($"{conflict} مشغولة. هل تريد المتابعة؟", "تنبيه تعارض", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            return;
                    }
                }

                var app = new Appointment
                {
                    AppointmentID = _editAppId,
                    CustomerID = customerId.Value,
                    AppointmentDate = fullDate,
                    TotalPrice = _selectedServices.Sum(s => s.Price * s.Quantity),
                    Status = "Pending",
                    CreatedBy = CurrentSession.UserID,
                    SelectedServices = _selectedServices
                };

                bool success = (_editAppId > 0) ? await _appointmentRepo.UpdateAsync(app) : (await _appointmentRepo.CreateAndGetIdAsync(app)) > 0;

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

                var servicesDto = await _appointmentRepo.GetAppointmentServicesAsync(_editAppId);
                _selectedServices = servicesDto.ToList();
                _cartSummary.RefreshCart(_selectedServices);
            }
        }
    }
}