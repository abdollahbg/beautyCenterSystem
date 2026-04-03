using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BeautyCenterSystem.Models;
using BeautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using Timer = System.Windows.Forms.Timer;
using BeautyCenterSystem.Data.Repositories;

namespace beautyCenterSystem
{
    public partial class UC_ServiceSelector : UserControl
    {
        // الأحداث للتعامل مع الإضافات
        public event EventHandler<int> OnServiceAdded;
        public event EventHandler<int> OnMaterialAdded;
        public event EventHandler OnBackClicked;

        private Panel _pnlHeader;
        private Label _lblRoomName;
        private Button _btnBack;
        private FlowLayoutPanel _flpServices;

        // عنصر اختيار الموظفة
        private ComboBox _cmbEmployees;
        private Label _lblEmployeeHint;

        private string _currentMode = "Service";
        private int _currentRoomId;

        // الخاصية التي تستخدم عند الحفظ لجلب الموظفة المختارة
        public int? SelectedEmployeeId
        {
            get
            {
                if (_cmbEmployees != null && _cmbEmployees.Visible && _cmbEmployees.SelectedValue != null)
                    return Convert.ToInt32(_cmbEmployees.SelectedValue);
                return null;
            }
        }

        public UC_ServiceSelector()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.BackColor = AppTheme.BackgroundLight;
            this.Dock = DockStyle.Fill;
            this.RightToLeft = RightToLeft.Yes;

            _pnlHeader = new Panel
            {
                Height = 85,
                Dock = DockStyle.Top,
                BackColor = AppTheme.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // 1. زر الرجوع (أقصى اليسار - بعيد عن العناصر الأخرى)
            _btnBack = new Button
            {
                Text = "➔ رجوع",
                Font = AppTheme.GetFont(11, FontStyle.Bold),
                Size = new Size(100, 40),
                Location = new Point(15, 22),
                BackColor = AppTheme.Charcoal,
                ForeColor = AppTheme.White,
                FlatStyle = FlatStyle.Flat
            };
            _btnBack.FlatAppearance.BorderSize = 0;
            _btnBack.Click += (s, e) => OnBackClicked?.Invoke(this, EventArgs.Empty);

            // 2. اسم الغرفة (تم تصغير الخط ليكون متناسقاً)
            _lblRoomName = new Label
            {
                Text = "غرفة العناية",
                Font = AppTheme.GetFont(14, FontStyle.Bold), // تصغير الخط من 16 إلى 14
                ForeColor = AppTheme.Primary,
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            // 3. الليبل (الموظفة المسؤولة)
            _lblEmployeeHint = new Label
            {
                Text = "الموظفة المسؤولة:",
                Font = AppTheme.GetFont(10, FontStyle.Bold),
                ForeColor = Color.DimGray,
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            // 4. كومبو بوكس الموظفات
            _cmbEmployees = new ComboBox
            {
                Width = 180, // عرض متناسق
                Height = 35,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = AppTheme.GetFont(11, FontStyle.Regular),
                BackColor = Color.White,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            _pnlHeader.Controls.Add(_btnBack);
            _pnlHeader.Controls.Add(_lblRoomName);
            _pnlHeader.Controls.Add(_lblEmployeeHint);
            _pnlHeader.Controls.Add(_cmbEmployees);

            _flpServices = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(20),
                FlowDirection = FlowDirection.RightToLeft
            };

            this.Controls.Add(_flpServices);
            this.Controls.Add(_pnlHeader);

            // المنطق الجديد: ترتيب العناصر من اليمين إلى اليسار بالتسلسل
            this.Resize += (s, e) => {
                // أ. اسم الغرفة في أقصى اليمين مع هامش 20 بكسل
                _lblRoomName.Left = _pnlHeader.Width - _lblRoomName.Width - 20;
                _lblRoomName.Top = 28;

                // ب. الليبل بجانب اسم الغرفة مباشرة (هامش 30 بكسل بينهما)
                _lblEmployeeHint.Left = _lblRoomName.Left - _lblEmployeeHint.Width - 30;
                _lblEmployeeHint.Top = 32;

                // ج. الكومبو بوكس بجانب الليبل مباشرة (هامش 10 بكسل)
                _cmbEmployees.Left = _lblEmployeeHint.Left - _cmbEmployees.Width - 10;
                _cmbEmployees.Top = 28;
            };

            // تنفيذ الترتيب فوراً
            this.OnResize(EventArgs.Empty);
        }

        /// <summary>
        /// جلب الموظفات المربوطات بالغرفة المختارة فقط
        /// </summary>
        private async void FilterEmployeesByRoom(int roomId)
        {
            try
            {
                var factory = new DbConnectionFactory();
                var repo = new EmployeeRepository(factory);

                // نفترض وجود دالة في الـ Repository تجلب الموظفات بناءً على رقم الغرفة
                // إذا لم تكن موجودة، يمكنك جلب الكل ثم عمل .Where(e => e.RoomID == roomId)
                var allEmployees = await repo.GetAllEmployeesAsync();
                var filteredEmployees = allEmployees.Where(e => e.RoomID == roomId && e.IsActive).ToList();

                _cmbEmployees.DataSource = filteredEmployees;
                _cmbEmployees.DisplayMember = "EmployeeName";
                _cmbEmployees.ValueMember = "EmployeeID";

                // تحسين: إذا كانت هناك موظفة واحدة فقط، يتم اختيارها تلقائياً وتعطيل التغيير لضمان الدقة
                if (filteredEmployees.Count == 1)
                {
                    _cmbEmployees.SelectedIndex = 0;
                    // _cmbEmployees.Enabled = false; // اختياري: إذا أردت منع الكاشير من تغيير الموظفة المربوطة أصلاً بالغرفة
                }
                else if (filteredEmployees.Count == 0)
                {
                    _cmbEmployees.DataSource = null;
                    _cmbEmployees.Text = "لا توجد موظفة لهذه الغرفة";
                }
                else
                {
                    _cmbEmployees.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الموظفات: " + ex.Message);
            }
        }

        /// <summary>
        /// تحميل الخدمات (تم إضافة حقل الـ RoomID للفلترة)
        /// </summary>
        public void LoadServices(Room room, List<Service> services)
        {
            _currentMode = "Service";
            _currentRoomId = room.RoomID;
            _lblRoomName.Text = room.RoomName;
            _flpServices.Controls.Clear();

            // 1. إظهار اختيار الموظفة وفلترتها فوراً بناءً على الغرفة المختارة
            _lblEmployeeHint.Visible = _cmbEmployees.Visible = true;
            FilterEmployeesByRoom(_currentRoomId);

            if (services == null) return;

            foreach (var service in services)
            {
                Panel card = CreateItemCard(service.ServiceID, service.ServiceName, service.Price, $"⏱ {service.DurationMinutes} دقيقة", true);
                _flpServices.Controls.Add(card);
            }
        }

        /// <summary>
        /// تحميل المواد (مثل الكافيتيريا)
        /// </summary>
        public void LoadMaterials(string roomName, List<Material> materials)
        {
            _currentMode = "Material";
            _lblRoomName.Text = roomName;
            _flpServices.Controls.Clear();

            // في وضع المواد (الكافيتيريا)، لا نحتاج لنسبة موظفة غرفة
            _lblEmployeeHint.Visible = _cmbEmployees.Visible = false;

            if (materials == null) return;

            foreach (var material in materials)
            {
                bool isAvailable = material.StockQuantity > 0;
                string stockInfo = isAvailable ? $"📦 متوفر: {material.StockQuantity}" : "⚠️ نفذت الكمية";
                Panel card = CreateItemCard(material.MaterialID, material.MaterialName, material.SalePrice, stockInfo, isAvailable);
                _flpServices.Controls.Add(card);
            }
        }

        private Panel CreateItemCard(int itemId, string itemName, decimal price, string subInfoText, bool isEnabled)
        {
            Panel card = new Panel
            {
                Size = new Size(260, 120),
                Margin = new Padding(12),
                BackColor = isEnabled ? AppTheme.White : Color.FromArgb(240, 240, 240),
                Cursor = isEnabled ? Cursors.Hand : Cursors.No,
                BorderStyle = BorderStyle.FixedSingle,
                Enabled = isEnabled
            };

            Label lblName = new Label
            {
                Text = itemName,
                Font = AppTheme.GetFont(13, FontStyle.Bold),
                ForeColor = isEnabled ? AppTheme.Charcoal : Color.Gray,
                Location = new Point(10, 15),
                Size = new Size(240, 30),
                TextAlign = ContentAlignment.TopRight,
                Enabled = false
            };

            Label lblPrice = new Label
            {
                Text = $"{price:N2} د.ل",
                Font = AppTheme.GetFont(12, FontStyle.Bold),
                ForeColor = isEnabled ? AppTheme.Primary : Color.Gray,
                Location = new Point(10, 60),
                AutoSize = true,
                Enabled = false
            };

            Label lblSubInfo = new Label
            {
                Text = subInfoText,
                Font = AppTheme.GetFont(9, FontStyle.Regular),
                ForeColor = isEnabled ? Color.DimGray : Color.Red,
                Location = new Point(10, 85),
                Size = new Size(240, 20),
                TextAlign = ContentAlignment.BottomLeft,
                Enabled = false
            };

            if (isEnabled)
            {
                card.MouseEnter += (s, e) => card.BackColor = AppTheme.RoseGold;
                card.MouseLeave += (s, e) => card.BackColor = AppTheme.White;

                card.Click += (s, e) =>
                {
                    // التحقق: في حال كان وضع خدمة، يجب اختيار موظفة أولاً
                    if (_currentMode == "Service" && SelectedEmployeeId == null)
                    {
                        MessageBox.Show("يرجى التأكد من وجود موظفة مسؤولة عن هذه الغرفة أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    card.BackColor = Color.LightGreen;
                    Timer t = new Timer { Interval = 100 };
                    t.Tick += (ts, te) => { card.BackColor = AppTheme.White; t.Stop(); };
                    t.Start();

                    if (_currentMode == "Service")
                        OnServiceAdded?.Invoke(this, itemId);
                    else
                        OnMaterialAdded?.Invoke(this, itemId);
                };
            }

            card.Controls.Add(lblName);
            card.Controls.Add(lblPrice);
            card.Controls.Add(lblSubInfo);

            return card;
        }
    }
}