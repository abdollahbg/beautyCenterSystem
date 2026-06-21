using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq; // أضفنا هذا لاستخدام Linq
using System.Windows.Forms;
using BeautyCenterSystem.Models;

namespace beautyCenterSystem
{
    public partial class UC_RoomNavigator : UserControl
    {
        // التعديل الجوهري: الحدث الآن يمرر كائن الغرفة بالكامل لسهولة فحص البيانات (مثل الاسم)
        public event EventHandler<Room> OnRoomSelected;

        private FlowLayoutPanel _flpRooms;
        private Label _lblTitle;
        private List<Room> _loadedRooms; // حفظ النسخة المحلية للغرف

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
                Text = "اختر القسم أو الغرفة",
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
                RightToLeft = RightToLeft.Yes,
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
            _loadedRooms = rooms; // تخزين الغرف
            _flpRooms.SuspendLayout();
            while (_flpRooms.Controls.Count > 0) { var c = _flpRooms.Controls[0]; _flpRooms.Controls.Remove(c); c.Dispose(); }

            if (rooms != null)
            {
                foreach (var room in rooms)
                {
                    // نمرر الكائن كاملاً للدالة المنشئة للكارت
                    Panel roomCard = CreateRoomCard(room);
                    _flpRooms.Controls.Add(roomCard);
                }
            }
            _flpRooms.ResumeLayout();
        }

        private Panel CreateRoomCard(Room room)
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
                Tag = room.RoomID, // لا نزال نحتفظ بالـ ID في الـ Tag للضرورة
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
                if (!string.IsNullOrEmpty(room.IconPath) && File.Exists(room.IconPath))
                    picIcon.Image = Image.FromFile(room.IconPath);
                else
                    picIcon.BackColor = Color.Transparent;
            }
            catch { /* معالجة الخطأ في حال كانت الصورة تالفة */ }

            Label lblName = new Label
            {
                Text = room.RoomName,
                Font = AppTheme.GetFont(14, FontStyle.Bold),
                ForeColor = AppTheme.Charcoal,
                AutoSize = false,
                Size = new Size(180, 40),
                Location = new Point(0, 120),
                TextAlign = ContentAlignment.MiddleCenter,
                Enabled = false
            };

            // تأثيرات التمرير
            card.MouseEnter += (s, e) => {
                card.BackColor = AppTheme.RoseGold;
                lblName.ForeColor = AppTheme.Primary;
            };

            card.MouseLeave += (s, e) => {
                card.BackColor = AppTheme.White;
                lblName.ForeColor = AppTheme.Charcoal;
            };

            // عند الضغط، نرسل كائن الغرفة بالكامل
            card.Click += (s, e) => OnRoomSelected?.Invoke(this, room);

            card.Controls.Add(picIcon);
            card.Controls.Add(lblName);

            return card;
        }
    }
}