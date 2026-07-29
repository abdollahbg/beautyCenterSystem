using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using beautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using beautyCenterSystem.data.Repositories;
using BeautyCenterSystem.Data;
using beautyCenterSystem.viewsmodels;
using BeautyCenterSystem.Models;
using BeautyCenterSystem.Data.Repositories;

namespace beautyCenterSystem
{
    public partial class UC_Cafeteria : UserControl
    {
        private FlowLayoutPanel _flpMaterials;
        private UC_CartSummary _cartSummary;
        private readonly MaterialRepository _materialRepo;
        private readonly AppointmentRepository _appRepo;
        private readonly CustomerRepository _customerRepo;
        private readonly int _currentUserId;
        private List<AppointmentDetailDto> _selectedServices = new List<AppointmentDetailDto>();

        public UC_Cafeteria(int currentUserId)
        {
            InitializeComponent();
            _currentUserId = currentUserId;
            
            var dbFactory = new DbConnectionFactory();
            _materialRepo = new MaterialRepository(dbFactory);
            _appRepo = new AppointmentRepository(dbFactory);
            _customerRepo = new CustomerRepository(dbFactory);

            InitializeUI();
            LoadCustomersToCartCombo().ConfigureAwait(false);
        }

        private async Task LoadCustomersToCartCombo()
        {
            var customers = await _customerRepo.GetAllAsync();
            _cartSummary.FillCustomers(customers.ToList());
        }

        private void InitializeUI()
        {
            this.Dock = DockStyle.Fill;
            this.RightToLeft = RightToLeft.Yes;

            var splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterDistance = this.Width > 0 ? (int)(this.Width * 0.75) : 750
            };

            // عند تغيير حجم الشاشة، حافظ على نسبة 75%
            splitContainer.Resize += (s, e) =>
            {
                if (splitContainer.Width > 0)
                {
                    splitContainer.SplitterDistance = (int)(splitContainer.Width * 0.75);
                }
            };

            // إنشاء لوحة الكافيتيريا بدلاً من UC_ServiceSelector
            var pnlMenu = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            
            var lblTitle = new Label
            {
                Text = "قائمة الكافيتيريا",
                Dock = DockStyle.Top,
                Height = 60,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = AppTheme.Charcoal
            };
            
            var separator = new Panel { Dock = DockStyle.Top, Height = 2, BackColor = Color.Crimson };

            _flpMaterials = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(15),
                BackColor = Color.FromArgb(250, 250, 250)
            };

            pnlMenu.Controls.Add(_flpMaterials);
            pnlMenu.Controls.Add(separator);
            pnlMenu.Controls.Add(lblTitle);

            _cartSummary = new UC_CartSummary();
            _cartSummary.Dock = DockStyle.Fill;
            _cartSummary.SaveButtonText = "تأكيد ودفع الفاتورة";
            _cartSummary.ItemColumnHeaderText = "الصنف";
            _cartSummary.OnSaveAppointmentClicked += async (s, e) => await SaveCafeteriaOrder();
            _cartSummary.OnRemoveServiceRequested += (s, itemId) => RemoveItemFromCart(itemId);
            _cartSummary.OnQuantityChanged += (itemId, qty) => UpdateItemQuantity(itemId, qty);
            _cartSummary.OnAddCustomerClicked += async (s, e) => 
            {
                using (var f = new AddCustomerForm())
                {
                    if (f.ShowDialog() == DialogResult.OK) await LoadCustomersToCartCombo();
                }
            };

            splitContainer.Panel1.Controls.Add(pnlMenu);
            splitContainer.Panel2.Controls.Add(_cartSummary);
            
            this.Controls.Add(splitContainer);
        }

        public async Task LoadCafeteria()
        {
            _flpMaterials.Controls.Clear();
            var materials = await _materialRepo.GetCaffeteriaMenuAsync();
            var materialsList = materials.ToList();
            
            if (materialsList.Count == 0)
            {
                var lblEmpty = new Label
                {
                    Text = "لا توجد أصناف في الكافيتيريا.",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.Gray,
                    Margin = new Padding(20)
                };
                _flpMaterials.Controls.Add(lblEmpty);
                return;
            }

            foreach (var material in materialsList)
            {
                var card = CreateMaterialCard(material);
                _flpMaterials.Controls.Add(card);
            }
        }
        
        private Panel CreateMaterialCard(Material mat)
        {
            var pnl = new Panel
            {
                Width = 200,
                Height = 120,
                Margin = new Padding(10),
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblName = new Label
            {
                Text = mat.MaterialName,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = AppTheme.Charcoal,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 50
            };

            var lblPrice = new Label
            {
                Text = $"{mat.SalePrice:N2} د.ل",
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.Crimson,
                Dock = DockStyle.Bottom,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 40
            };
            
            var lblStock = new Label
            {
                Text = $"متوفر: {mat.StockQuantity}",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            pnl.Controls.Add(lblStock);
            pnl.Controls.Add(lblName);
            pnl.Controls.Add(lblPrice);

            // Click Events
            pnl.Click += async (s, e) => await AddMaterialToCart(mat.MaterialID);
            lblName.Click += async (s, e) => await AddMaterialToCart(mat.MaterialID);
            lblPrice.Click += async (s, e) => await AddMaterialToCart(mat.MaterialID);
            lblStock.Click += async (s, e) => await AddMaterialToCart(mat.MaterialID);

            // Hover effects
            pnl.MouseEnter += (s, e) => pnl.BackColor = Color.FromArgb(240, 240, 240);
            pnl.MouseLeave += (s, e) => pnl.BackColor = Color.White;

            return pnl;
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

        private void RemoveItemFromCart(int itemId)
        {
            var item = _selectedServices.FirstOrDefault(s => s.MaterialID == itemId);
            if (item != null)
            {
                _selectedServices.Remove(item);
                _cartSummary.RefreshCart(_selectedServices);
            }
        }

        private void UpdateItemQuantity(int itemId, int qty)
        {
            var item = _selectedServices.FirstOrDefault(s => s.MaterialID == itemId);
            if (item != null)
            {
                item.Quantity = qty;
                _cartSummary.RefreshCart(_selectedServices);
            }
        }

        private async Task SaveCafeteriaOrder()
        {
            if (_selectedServices.Count == 0)
            {
                MessageBox.Show("الطلب فارغ.");
                return;
            }

            decimal totalAmount = _selectedServices.Sum(s => s.Price * s.Quantity);

            var app = new Appointment
            {
                CustomerID = _cartSummary.SelectedCustomerId ?? 1, 
                AppointmentDate = DateTime.Now,
                Status = "Pending",
                CreatedBy = _currentUserId,
                SelectedServices = _selectedServices,
                TotalPrice = totalAmount
            };

            int appId = await _appRepo.CreateAndGetIdAsync(app);
            if (appId > 0)
            {
                using (var paymentForm = new CheckoutForm("مبيعات كافيتيريا نقدي", totalAmount))
                {
                    if (paymentForm.ShowDialog() == DialogResult.OK)
                    {
                        bool isSuccess = await _appRepo.CompleteAndPayAsync(
                            appId, totalAmount, paymentForm.AmountPaid, paymentForm.Discount,
                            paymentForm.PaymentMethod, _currentUserId);

                        if (isSuccess)
                        {
                            try
                            {
                                var dbFactory = new DbConnectionFactory();
                                var settingsRepo = new SettingsRepository(dbFactory);
                                var settings = await settingsRepo.GetSettingsAsync();

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
                                    CustomerName = "زبون كافيتيريا",
                                    AppointmentDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt"),
                                    TotalAmount = totalAmount,
                                    Discount = paymentForm.Discount,
                                    NetAmount = paymentForm.AmountPaid,
                                    CashierName = CurrentSession.Username,
                                    Items = _selectedServices.Select(s => new InvoiceItem
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
                                MessageBox.Show($"تم الدفع والحفظ بنجاح، لكن فشلت الطباعة: {printEx.Message}", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            MessageBox.Show("تم دفع طلب الكافيتيريا بنجاح.");
                            _selectedServices.Clear();
                            _cartSummary.RefreshCart(_selectedServices);
                            await LoadCafeteria(); // Refresh stock
                        }
                    }
                }
            }
        }
    }
}
