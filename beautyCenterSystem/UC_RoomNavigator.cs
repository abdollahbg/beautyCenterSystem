using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BeautyCenterSystem.Models;

namespace beautyCenterSystem
{
    public partial class UC_RoomNavigator : UserControl
    {
        public event EventHandler<int> OnRoomSelected;

        private FlowLayoutPanel _flpRooms;
        private Label _lblTitle;

        public UC_RoomNavigator()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.BackColor = AppTheme.BackgroundLight;
            this.Dock = DockStyle.Fill;

            _lblTitle = new Label
            {
                Text = "اختر الغرفة",
                Font = AppTheme.GetFont(20, FontStyle.Bold),
                ForeColor = AppTheme.Charcoal,
                AutoSize = true,
                Location = new Point(20, 20),
                RightToLeft = RightToLeft.Yes
            };

            _flpRooms = new FlowLayoutPanel
            {
                Location = new Point(20, 80),
                Size = new Size(this.Width - 40, this.Height - 100),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AutoScroll = true,
                RightToLeft = RightToLeft.Yes, // هذا يعكس الترتيب تلقائياً ليكون من اليمين لليسار
                // التعديل الأول: نجعله LeftToRight لأن RightToLeft.Yes ستقوم بعكسه. وضع الاثنان معاً يسبب مشاكل الاستطالة
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true
            };

            this.Controls.Add(_lblTitle);
            this.Controls.Add(_flpRooms);
        }

        private void UC_RoomNavigator_Load(object sender, EventArgs e)
        {
            AppTheme.Apply(this);
        }

        public void LoadRooms(List<Room> rooms)
        {
            _flpRooms.SuspendLayout();
            _flpRooms.Controls.Clear();

            if (rooms != null)
            {
                foreach (var room in rooms)
                {
                    Panel roomCard = CreateRoomCard(room.RoomID, room.RoomName, room.IconPath);
                    _flpRooms.Controls.Add(roomCard);
                }
            }
            _flpRooms.ResumeLayout();
        }

        private Panel CreateRoomCard(int roomId, string roomName, string iconPath)
        {
            Size cardSize = new Size(180, 180);

            Panel card = new Panel
            {
                Size = cardSize,
                MinimumSize = cardSize,
                MaximumSize = cardSize,
                Margin = new Padding(15),
                BackColor = AppTheme.White,
                Cursor = Cursors.Hand,
                Tag = roomId,
                // التعديل الثاني الحاسم: منع الكارد من التمدد العشوائي نهائياً
                Anchor = AnchorStyles.None,
                Dock = DockStyle.None
            };

            PictureBox picIcon = new PictureBox
            {
                Size = new Size(80, 80),
                Location = new Point(50, 25),
                SizeMode = PictureBoxSizeMode.Zoom,
                Enabled = false
            };

            try
            {
                if (!string.IsNullOrEmpty(iconPath) && File.Exists(iconPath))
                    picIcon.Image = Image.FromFile(iconPath);
                else
                    picIcon.BackColor = Color.Transparent;
            }
            catch { }

            Label lblName = new Label
            {
                Text = roomName,
                Font = AppTheme.GetFont(14, FontStyle.Bold),
                ForeColor = AppTheme.Charcoal,
                AutoSize = false,
                Size = new Size(180, 40),
                Location = new Point(0, 120),
                TextAlign = ContentAlignment.MiddleCenter,
                Enabled = false
            };

            card.MouseEnter += (s, e) => {
                card.BackColor = AppTheme.RoseGold;
                lblName.ForeColor = AppTheme.Primary;
            };

            card.MouseLeave += (s, e) => {
                card.BackColor = AppTheme.White;
                lblName.ForeColor = AppTheme.Charcoal;
            };

            card.Click += (s, e) => OnRoomSelected?.Invoke(this, roomId);

            card.Controls.Add(picIcon);
            card.Controls.Add(lblName);

            return card;
        }
    }
}