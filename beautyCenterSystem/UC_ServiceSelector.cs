using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BeautyCenterSystem.Models; // تأكد من إضافة هذا الـ namespace
using Timer = System.Windows.Forms.Timer;

namespace beautyCenterSystem
{
    public partial class UC_ServiceSelector : UserControl
    {
        public event EventHandler<int> OnServiceAdded;
        public event EventHandler OnBackClicked;

        private Panel _pnlHeader;
        private Label _lblRoomName;
        private Button _btnBack;
        private FlowLayoutPanel _flpServices;

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
                Height = 60,
                Dock = DockStyle.Top,
                BackColor = AppTheme.BackgroundLight,
                Padding = new Padding(10)
            };

            _btnBack = new Button
            {
                Text = "رجوع للغرف ➔",
                Font = AppTheme.GetFont(12, FontStyle.Bold),
                Size = new Size(130, 40),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                BackColor = AppTheme.Charcoal,
                ForeColor = AppTheme.White
            };
            _btnBack.FlatAppearance.BorderSize = 0;
            _btnBack.Click += (s, e) => OnBackClicked?.Invoke(this, EventArgs.Empty);

            _lblRoomName = new Label
            {
                Text = "خدمات الغرفة",
                Font = AppTheme.GetFont(18, FontStyle.Bold),
                ForeColor = AppTheme.Primary,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft
            };

            _btnBack.Location = new Point(20, 10);
            _lblRoomName.Location = new Point(this.Width - 300, 15);
            _lblRoomName.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            _pnlHeader.Controls.Add(_btnBack);
            _pnlHeader.Controls.Add(_lblRoomName);

            _flpServices = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(20),
                FlowDirection = FlowDirection.LeftToRight
            };

            this.Controls.Add(_flpServices);
            this.Controls.Add(_pnlHeader);
        }

        private void UC_ServiceSelector_Load(object sender, EventArgs e)
        {
            AppTheme.Apply(this);
        }

        /// <summary>
        /// تعديل: استقبال قائمة List بدلاً من DataTable
        /// </summary>
        public void LoadServices(string roomName, List<Service> services)
        {
            _lblRoomName.Text = $"خدمات غرفة: {roomName}";
            _flpServices.Controls.Clear();

            if (services == null) return;

            foreach (var service in services)
            {
                int serviceId = service.ServiceID;
                string serviceName = service.ServiceName;
                decimal price = service.Price; // تأكد من مطابقة اسم الخاصية في موديل Service
                int duration = service.DurationMinutes;

                Panel serviceCard = CreateServiceCard(serviceId, serviceName, price, duration);
                _flpServices.Controls.Add(serviceCard);
            }
        }

        private Panel CreateServiceCard(int serviceId, string serviceName, decimal price, int duration)
        {
            Panel card = new Panel
            {
                Size = new Size(280, 110),
                Margin = new Padding(10),
                BackColor = AppTheme.White,
                Cursor = Cursors.Hand,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblName = new Label
            {
                Text = serviceName,
                Font = AppTheme.GetFont(14, FontStyle.Bold),
                ForeColor = AppTheme.Charcoal,
                Location = new Point(10, 15),
                AutoSize = false,
                Size = new Size(260, 30),
                RightToLeft = RightToLeft.Yes,
                Enabled = false
            };

            Label lblPrice = new Label
            {
                Text = $"{price:N2} د.ل",
                Font = AppTheme.GetFont(12, FontStyle.Bold),
                ForeColor = AppTheme.Primary,
                Location = new Point(10, 55),
                AutoSize = true,
                Enabled = false
            };

            Label lblDuration = new Label
            {
                Text = $"⏱ {duration} دقيقة",
                Font = AppTheme.GetFont(10, FontStyle.Regular),
                ForeColor = AppTheme.DarkGray,
                Location = new Point(160, 55),
                AutoSize = true,
                Enabled = false
            };

            card.MouseEnter += (s, e) => card.BackColor = AppTheme.RoseGold;
            card.MouseLeave += (s, e) => card.BackColor = AppTheme.White;

            card.Click += (s, e) =>
            {
                card.BackColor = Color.LightGreen;
                Timer t = new Timer { Interval = 150 };
                t.Tick += (ts, te) => { card.BackColor = AppTheme.White; t.Stop(); };
                t.Start();

                OnServiceAdded?.Invoke(this, serviceId);
            };

            card.Controls.Add(lblName);
            card.Controls.Add(lblPrice);
            card.Controls.Add(lblDuration);

            return card;
        }
    }
}