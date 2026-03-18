using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using System.Collections.Generic;
using beautyCenterSystem.data.Repositories;

namespace beautyCenterSystem
{
    public partial class UC_Home : UserControl
    {
        private readonly RoomRepository _roomRepo;
        private readonly MaterialRepository _materialRepo;
        private readonly AppointmentRepository _appointmentRepo;

        public UC_Home()
        {
            var factory = new DbConnectionFactory();
            _roomRepo = new RoomRepository(factory);
            _materialRepo = new MaterialRepository(factory);
            _appointmentRepo = new AppointmentRepository(factory);

            InitializeComponent();


            this.VisibleChanged += UC_Home_VisibleChanged;

            // تايمر لتحديث الواجهة (الوقت المتبقي والألوان) كل دقيقة دون إعادة الاستعلام من القاعدة
            System.Windows.Forms.Timer timerUI = new System.Windows.Forms.Timer { Interval = 60000 };
            timerUI.Tick += (s, e) => UpdateUIStatusOnly();
            timerUI.Start();
        }

        private async void UC_Home_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && !this.IsDisposed)
            {
                await RefreshDashboard();
            }
        }

        private async void UC_Home_Load(object sender, EventArgs e)
        {
            AppTheme.Apply(this);
            await RefreshDashboard();

        }

        public async Task RefreshDashboard()
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;

            try
            {
                var kpisTask = _appointmentRepo.GetTodayDashboardKPIsAsync();
                var roomsTask = _appointmentRepo.GetRoomsStatusAsync();
                var materialsTask = _materialRepo.GetOutOfStockMaterialsAsync();

                await Task.WhenAll(kpisTask, roomsTask, materialsTask);

                var kpis = await kpisTask;
                var roomsData = await roomsTask;
                var outOfStock = await materialsTask;

                this.Invoke((Action)(() =>
                {
                    // 1. تحديث الإحصائيات
                    lblCompletedVal.Text = kpis.completed.ToString();
                    lblTopServiceVal.Text = kpis.topService;
                    lblAvgTimeVal.Text = $"{kpis.avgTime} دقيقة";

                    // 2. تحديث جدول النواقص
                    dgvOutofStock.DataSource = null;
                    dgvOutofStock.DataSource = outOfStock.ToList();
                    FormatMaterialsGrid();

                    // 3. تحديث كروت الغرف
                    UpdateRoomCards(roomsData);
                }));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Dashboard Error: {ex.Message}");
            }
        }

        #region إدارة الغرف (Logic & UI)

        private void UpdateRoomCards(IEnumerable<dynamic> roomsData)
        {
            flpRooms.Controls.Clear();
            foreach (var item in roomsData)
            {
                var card = CreateEnhancedRoomCard(item);
                flpRooms.Controls.Add(card);
            }
        }

        private MaterialCard CreateEnhancedRoomCard(dynamic data)
        {
            var card = new MaterialCard
            {
                Size = new Size(240, 160),
                Margin = new Padding(10),
                Tag = data // تخزين البيانات الأصلية للتايمر
            };

            // لوحة المؤشر اللوني
            var indicator = new Panel { Name = "pnlIndicator", Dock = DockStyle.Top, Height = 8 };

            var lblRoomName = new Label
            {
                Text = data.RoomName,
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Location = new Point(140, 25),
                AutoSize = true
            };

            card.Controls.Add(indicator);
            card.Controls.Add(lblRoomName);

            ApplyStatusLogic(card, data);

            return card;
        }

        private void ApplyStatusLogic(MaterialCard card, dynamic data)
        {
            string status = data.AppointmentStatus?.ToString() ?? "";
            DateTime startTime = data.StartTime != null ? (DateTime)data.StartTime : DateTime.MinValue;
            int duration = data.DurationMinutes != null ? (int)data.DurationMinutes : 0;

            var indicator = card.Controls.Find("pnlIndicator", true).FirstOrDefault() as Panel;

            // إزالة أي ليبيلات قديمة عند إعادة التحديث
            var oldLabels = card.Controls.OfType<Label>().Where(l => l.Name != "" && l.Location.Y > 50).ToList();
            foreach (var ol in oldLabels) card.Controls.Remove(ol);

            bool isBusy = status == "InProgress";
            DateTime endTime = startTime.AddMinutes(duration);
            bool isTimeUp = DateTime.Now > endTime;

            // الحالة 1: الغرفة جاهزة (الحجز مكتمل أو لا يوجد حجز)
            if (status == "Completed" || string.IsNullOrEmpty(status))
            {
                if (indicator != null) indicator.BackColor = Color.MediumSeaGreen;
                card.Controls.Add(new Label { Text = "الغرفة جاهزة الآن", ForeColor = Color.MediumSeaGreen, Font = new Font("Segoe UI", 10, FontStyle.Italic), Location = new Point(60, 85), AutoSize = true });
            }
            // الحالة 2: مشغولة وتأخرت (InProgress + انتهى الوقت)
            else if (isBusy && isTimeUp)
            {
                if (indicator != null) indicator.BackColor = Color.Orange;
                AddClientLabels(card, data);
                card.Controls.Add(new Label { Name = "lblTimeStatus", Text = "انتهى الوقت (تأخير)", ForeColor = Color.Red, Font = new Font("Segoe UI", 9, FontStyle.Bold), Location = new Point(15, 115), AutoSize = true });
            }
            // الحالة 3: مشغولة والوقت مستمر
            else if (isBusy)
            {
                if (indicator != null) indicator.BackColor = Color.IndianRed;
                AddClientLabels(card, data);
                card.Controls.Add(new Label { Name = "lblTimeStatus", Text = CalculateRemainingTime(startTime, duration), ForeColor = Color.Black, Font = new Font("Segoe UI", 9, FontStyle.Bold), Location = new Point(15, 115), AutoSize = true });
            }
        }

        private void AddClientLabels(MaterialCard card, dynamic data)
        {
            card.Controls.Add(new Label { Text = $"العميلة: {data.CustomerName}", Font = new Font("Segoe UI", 9), Location = new Point(15, 60), AutoSize = true });
            card.Controls.Add(new Label { Text = $"الخدمة: {data.ServiceName}", Font = new Font("Segoe UI", 9), Location = new Point(15, 85), AutoSize = true, ForeColor = Color.DimGray });
        }

        private void UpdateUIStatusOnly()
        {
            foreach (Control control in flpRooms.Controls)
            {
                if (control is MaterialCard card && card.Tag != null)
                {
                    // إعادة تطبيق منطق الألوان والنصوص بناءً على الوقت الحالي
                    ApplyStatusLogic(card, card.Tag);
                }
            }
        }

        private string CalculateRemainingTime(DateTime startTime, int durationMinutes)
        {
            var endTime = startTime.AddMinutes(durationMinutes);
            var remaining = endTime - DateTime.Now;
            if (remaining.TotalSeconds <= 0) return "انتهى الوقت";
            return $"متبقي: {remaining.Minutes} دقيقة";
        }

        #endregion

        private void FormatMaterialsGrid()
        {
            if (dgvOutofStock.Columns.Count > 0)
            {
                if (dgvOutofStock.Columns["MaterialID"] != null) dgvOutofStock.Columns["MaterialID"].Visible = false;
                if (dgvOutofStock.Columns["IsAvailable"] != null) dgvOutofStock.Columns["IsAvailable"].Visible = false;
                if (dgvOutofStock.Columns["MaterialName"] != null)
                {
                    dgvOutofStock.Columns["MaterialName"].HeaderText = "المادة الناقصة";
                    dgvOutofStock.Columns["MaterialName"].FillWeight = 100;
                }
            }
        }

        private async void btnDailyClose_Click(object sender, EventArgs e)
        {
            // 1. إنشاء نسخة من فورم الإغلاق
            // تأكد من عمل using beautyCenterSystem.data.Repositories; في أعلى الملف
            using (FrmDailyClosure frm = new FrmDailyClosure())
            {
                // 2. إظهار الفورم كنافذة منبثقة (Modal)
                var result = frm.ShowDialog();

                // 3. (اختياري) إذا أردت تحديث أرقام الشاشة الرئيسية بعد الإغلاق
                // نفترض أن لديك دالة RefreshDashboard() التي برمجناها سابقاً
                await RefreshDashboard();
            }
        }
    }
}