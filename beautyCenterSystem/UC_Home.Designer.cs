namespace beautyCenterSystem
{
    partial class UC_Home
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlTopHeader = new Panel();
            btnDailyClose = new MaterialSkin.Controls.MaterialButton();
            lblDashboardTitle = new Label();
            tlpKPIs = new TableLayoutPanel();
            cardCompleted = new MaterialSkin.Controls.MaterialCard();
            lblCompletedVal = new Label();
            lblCompletedTitle = new Label();
            cardTopService = new MaterialSkin.Controls.MaterialCard();
            lblTopServiceVal = new Label();
            lblTopServiceTitle = new Label();
            cardAvgTime = new MaterialSkin.Controls.MaterialCard();
            lblAvgTimeVal = new Label();
            lblAvgTimeTitle = new Label();
            splitMain = new SplitContainer();
            flpRooms = new FlowLayoutPanel();
            cardRoomReady = new MaterialSkin.Controls.MaterialCard();
            lblRoom1Status = new Label();
            lblRoom1Name = new Label();
            pnlReadyIndicator = new Panel();
            cardRoomBusy = new MaterialSkin.Controls.MaterialCard();
            lblRoom2Time = new Label();
            lblRoom2Service = new Label();
            lblRoom2Customer = new Label();
            lblRoom2Name = new Label();
            pnlBusyIndicator = new Panel();
            lblRoomsHeader = new Label();
            dgvOutofStock = new DataGridView();
            lblStockHeader = new Label();
            pnlTopHeader.SuspendLayout();
            tlpKPIs.SuspendLayout();
            cardCompleted.SuspendLayout();
            cardTopService.SuspendLayout();
            cardAvgTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            flpRooms.SuspendLayout();
            cardRoomReady.SuspendLayout();
            cardRoomBusy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOutofStock).BeginInit();
            SuspendLayout();
            // 
            // pnlTopHeader
            // 
            pnlTopHeader.Controls.Add(btnDailyClose);
            pnlTopHeader.Controls.Add(lblDashboardTitle);
            pnlTopHeader.Dock = DockStyle.Top;
            pnlTopHeader.Location = new Point(0, 0);
            pnlTopHeader.Name = "pnlTopHeader";
            pnlTopHeader.Size = new Size(1184, 60);
            pnlTopHeader.TabIndex = 0;
            // 
            // btnDailyClose
            // 
            btnDailyClose.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDailyClose.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDailyClose.Depth = 0;
            btnDailyClose.HighEmphasis = true;
            btnDailyClose.Icon = null;
            btnDailyClose.Location = new Point(15, 12);
            btnDailyClose.Margin = new Padding(4, 6, 4, 6);
            btnDailyClose.MouseState = MaterialSkin.MouseState.HOVER;
            btnDailyClose.Name = "btnDailyClose";
            btnDailyClose.NoAccentTextColor = Color.Empty;
            btnDailyClose.Size = new Size(134, 36);
            btnDailyClose.TabIndex = 1;
            btnDailyClose.Text = "إغلاق الحساب اليومي";
            btnDailyClose.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDailyClose.UseAccentColor = true;
            btnDailyClose.UseVisualStyleBackColor = true;
            btnDailyClose.Click += btnDailyClose_Click;
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblDashboardTitle.Location = new Point(950, 15);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(155, 30);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "الشاشة الرئيسية";
            // 
            // tlpKPIs
            // 
            tlpKPIs.ColumnCount = 3;
            tlpKPIs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpKPIs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpKPIs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpKPIs.Controls.Add(cardCompleted, 2, 0);
            tlpKPIs.Controls.Add(cardTopService, 1, 0);
            tlpKPIs.Controls.Add(cardAvgTime, 0, 0);
            tlpKPIs.Dock = DockStyle.Top;
            tlpKPIs.Location = new Point(0, 60);
            tlpKPIs.Name = "tlpKPIs";
            tlpKPIs.RowCount = 1;
            tlpKPIs.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpKPIs.Size = new Size(1184, 110);
            tlpKPIs.TabIndex = 1;
            // 
            // cardCompleted
            // 
            cardCompleted.BackColor = Color.FromArgb(255, 255, 255);
            cardCompleted.Controls.Add(lblCompletedVal);
            cardCompleted.Controls.Add(lblCompletedTitle);
            cardCompleted.Depth = 0;
            cardCompleted.Dock = DockStyle.Fill;
            cardCompleted.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cardCompleted.Location = new Point(15, 10);
            cardCompleted.Margin = new Padding(5, 10, 15, 10);
            cardCompleted.MouseState = MaterialSkin.MouseState.HOVER;
            cardCompleted.Name = "cardCompleted";
            cardCompleted.Padding = new Padding(14);
            cardCompleted.Size = new Size(376, 90);
            cardCompleted.TabIndex = 0;
            // 
            // lblCompletedVal
            // 
            lblCompletedVal.AutoSize = true;
            lblCompletedVal.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblCompletedVal.ForeColor = Color.DarkBlue;
            lblCompletedVal.Location = new Point(17, 35);
            lblCompletedVal.Name = "lblCompletedVal";
            lblCompletedVal.Size = new Size(33, 37);
            lblCompletedVal.TabIndex = 1;
            lblCompletedVal.Text = "0";
            // 
            // lblCompletedTitle
            // 
            lblCompletedTitle.AutoSize = true;
            lblCompletedTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCompletedTitle.Location = new Point(210, 14);
            lblCompletedTitle.Name = "lblCompletedTitle";
            lblCompletedTitle.Size = new Size(156, 21);
            lblCompletedTitle.TabIndex = 0;
            lblCompletedTitle.Text = "الخدمات المكتملة اليوم";
            // 
            // cardTopService
            // 
            cardTopService.BackColor = Color.FromArgb(255, 255, 255);
            cardTopService.Controls.Add(lblTopServiceVal);
            cardTopService.Controls.Add(lblTopServiceTitle);
            cardTopService.Depth = 0;
            cardTopService.Dock = DockStyle.Fill;
            cardTopService.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cardTopService.Location = new Point(401, 10);
            cardTopService.Margin = new Padding(5, 10, 5, 10);
            cardTopService.MouseState = MaterialSkin.MouseState.HOVER;
            cardTopService.Name = "cardTopService";
            cardTopService.Padding = new Padding(14);
            cardTopService.Size = new Size(384, 90);
            cardTopService.TabIndex = 1;
            // 
            // lblTopServiceVal
            // 
            lblTopServiceVal.AutoSize = true;
            lblTopServiceVal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTopServiceVal.ForeColor = Color.DarkOrange;
            lblTopServiceVal.Location = new Point(17, 39);
            lblTopServiceVal.Name = "lblTopServiceVal";
            lblTopServiceVal.Size = new Size(49, 30);
            lblTopServiceVal.TabIndex = 1;
            lblTopServiceVal.Text = "----";
            // 
            // lblTopServiceTitle
            // 
            lblTopServiceTitle.AutoSize = true;
            lblTopServiceTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTopServiceTitle.Location = new Point(225, 14);
            lblTopServiceTitle.Name = "lblTopServiceTitle";
            lblTopServiceTitle.Size = new Size(122, 21);
            lblTopServiceTitle.TabIndex = 0;
            lblTopServiceTitle.Text = "الخدمة الأكثر طلباً";
            // 
            // cardAvgTime
            // 
            cardAvgTime.BackColor = Color.FromArgb(255, 255, 255);
            cardAvgTime.Controls.Add(lblAvgTimeVal);
            cardAvgTime.Controls.Add(lblAvgTimeTitle);
            cardAvgTime.Depth = 0;
            cardAvgTime.Dock = DockStyle.Fill;
            cardAvgTime.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cardAvgTime.Location = new Point(795, 10);
            cardAvgTime.Margin = new Padding(15, 10, 5, 10);
            cardAvgTime.MouseState = MaterialSkin.MouseState.HOVER;
            cardAvgTime.Name = "cardAvgTime";
            cardAvgTime.Padding = new Padding(14);
            cardAvgTime.Size = new Size(374, 90);
            cardAvgTime.TabIndex = 2;
            // 
            // lblAvgTimeVal
            // 
            lblAvgTimeVal.AutoSize = true;
            lblAvgTimeVal.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblAvgTimeVal.ForeColor = Color.Teal;
            lblAvgTimeVal.Location = new Point(17, 35);
            lblAvgTimeVal.Name = "lblAvgTimeVal";
            lblAvgTimeVal.Size = new Size(105, 37);
            lblAvgTimeVal.TabIndex = 1;
            lblAvgTimeVal.Text = "0 دقيقة";
            // 
            // lblAvgTimeTitle
            // 
            lblAvgTimeTitle.AutoSize = true;
            lblAvgTimeTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAvgTimeTitle.Location = new Point(215, 14);
            lblAvgTimeTitle.Name = "lblAvgTimeTitle";
            lblAvgTimeTitle.Size = new Size(140, 21);
            lblAvgTimeTitle.TabIndex = 0;
            lblAvgTimeTitle.Text = "متوسط وقت الخدمة";
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(0, 170);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(flpRooms);
            splitMain.Panel1.Controls.Add(lblRoomsHeader);
            splitMain.Panel1.Padding = new Padding(15);
            splitMain.Panel1.RightToLeft = RightToLeft.Yes;
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(dgvOutofStock);
            splitMain.Panel2.Controls.Add(lblStockHeader);
            splitMain.Panel2.Padding = new Padding(15);
            splitMain.Panel2.RightToLeft = RightToLeft.Yes;
            splitMain.Size = new Size(1184, 579);
            splitMain.SplitterDistance = 780;
            splitMain.TabIndex = 2;
            // 
            // flpRooms
            // 
            flpRooms.AutoScroll = true;
            flpRooms.Controls.Add(cardRoomReady);
            flpRooms.Controls.Add(cardRoomBusy);
            flpRooms.Dock = DockStyle.Fill;
            flpRooms.Location = new Point(15, 50);
            flpRooms.Name = "flpRooms";
            flpRooms.Size = new Size(750, 514);
            flpRooms.TabIndex = 1;
            // 
            // cardRoomReady
            // 
            cardRoomReady.BackColor = Color.FromArgb(255, 255, 255);
            cardRoomReady.Controls.Add(lblRoom1Status);
            cardRoomReady.Controls.Add(lblRoom1Name);
            cardRoomReady.Controls.Add(pnlReadyIndicator);
            cardRoomReady.Depth = 0;
            cardRoomReady.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cardRoomReady.Location = new Point(525, 5);
            cardRoomReady.Margin = new Padding(5);
            cardRoomReady.MouseState = MaterialSkin.MouseState.HOVER;
            cardRoomReady.Name = "cardRoomReady";
            cardRoomReady.Padding = new Padding(14);
            cardRoomReady.Size = new Size(220, 150);
            cardRoomReady.TabIndex = 0;
            // 
            // lblRoom1Status
            // 
            lblRoom1Status.AutoSize = true;
            lblRoom1Status.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRoom1Status.ForeColor = Color.MediumSeaGreen;
            lblRoom1Status.Location = new Point(17, 105);
            lblRoom1Status.Name = "lblRoom1Status";
            lblRoom1Status.Size = new Size(48, 21);
            lblRoom1Status.TabIndex = 1;
            lblRoom1Status.Text = "جاهزة";
            // 
            // lblRoom1Name
            // 
            lblRoom1Name.AutoSize = true;
            lblRoom1Name.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRoom1Name.Location = new Point(112, 30);
            lblRoom1Name.Name = "lblRoom1Name";
            lblRoom1Name.Size = new Size(65, 25);
            lblRoom1Name.TabIndex = 0;
            lblRoom1Name.Text = "غرفة 1";
            // 
            // pnlReadyIndicator
            // 
            pnlReadyIndicator.BackColor = Color.MediumSeaGreen;
            pnlReadyIndicator.Dock = DockStyle.Top;
            pnlReadyIndicator.Location = new Point(14, 14);
            pnlReadyIndicator.Name = "pnlReadyIndicator";
            pnlReadyIndicator.Size = new Size(192, 8);
            pnlReadyIndicator.TabIndex = 2;
            // 
            // cardRoomBusy
            // 
            cardRoomBusy.BackColor = Color.FromArgb(255, 255, 255);
            cardRoomBusy.Controls.Add(lblRoom2Time);
            cardRoomBusy.Controls.Add(lblRoom2Service);
            cardRoomBusy.Controls.Add(lblRoom2Customer);
            cardRoomBusy.Controls.Add(lblRoom2Name);
            cardRoomBusy.Controls.Add(pnlBusyIndicator);
            cardRoomBusy.Depth = 0;
            cardRoomBusy.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cardRoomBusy.Location = new Point(295, 5);
            cardRoomBusy.Margin = new Padding(5);
            cardRoomBusy.MouseState = MaterialSkin.MouseState.HOVER;
            cardRoomBusy.Name = "cardRoomBusy";
            cardRoomBusy.Padding = new Padding(14);
            cardRoomBusy.Size = new Size(220, 150);
            cardRoomBusy.TabIndex = 1;
            // 
            // lblRoom2Time
            // 
            lblRoom2Time.AutoSize = true;
            lblRoom2Time.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRoom2Time.ForeColor = Color.IndianRed;
            lblRoom2Time.Location = new Point(17, 110);
            lblRoom2Time.Name = "lblRoom2Time";
            lblRoom2Time.Size = new Size(86, 19);
            lblRoom2Time.TabIndex = 5;
            lblRoom2Time.Text = "منذ 15 دقيقة";
            // 
            // lblRoom2Service
            // 
            lblRoom2Service.AutoSize = true;
            lblRoom2Service.Font = new Font("Segoe UI", 10F);
            lblRoom2Service.Location = new Point(17, 85);
            lblRoom2Service.Name = "lblRoom2Service";
            lblRoom2Service.Size = new Size(128, 19);
            lblRoom2Service.TabIndex = 4;
            lblRoom2Service.Text = "الخدمة: تنظيف بشرة";
            // 
            // lblRoom2Customer
            // 
            lblRoom2Customer.AutoSize = true;
            lblRoom2Customer.Font = new Font("Segoe UI", 10F);
            lblRoom2Customer.Location = new Point(17, 60);
            lblRoom2Customer.Name = "lblRoom2Customer";
            lblRoom2Customer.Size = new Size(117, 19);
            lblRoom2Customer.TabIndex = 3;
            lblRoom2Customer.Text = "العميلة: سارة أحمد";
            // 
            // lblRoom2Name
            // 
            lblRoom2Name.AutoSize = true;
            lblRoom2Name.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRoom2Name.Location = new Point(135, 30);
            lblRoom2Name.Name = "lblRoom2Name";
            lblRoom2Name.Size = new Size(65, 25);
            lblRoom2Name.TabIndex = 0;
            lblRoom2Name.Text = "غرفة 2";
            // 
            // pnlBusyIndicator
            // 
            pnlBusyIndicator.BackColor = Color.IndianRed;
            pnlBusyIndicator.Dock = DockStyle.Top;
            pnlBusyIndicator.Location = new Point(14, 14);
            pnlBusyIndicator.Name = "pnlBusyIndicator";
            pnlBusyIndicator.Size = new Size(192, 8);
            pnlBusyIndicator.TabIndex = 2;
            // 
            // lblRoomsHeader
            // 
            lblRoomsHeader.AutoSize = true;
            lblRoomsHeader.Dock = DockStyle.Top;
            lblRoomsHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRoomsHeader.Location = new Point(15, 15);
            lblRoomsHeader.Name = "lblRoomsHeader";
            lblRoomsHeader.Padding = new Padding(0, 0, 0, 10);
            lblRoomsHeader.Size = new Size(150, 35);
            lblRoomsHeader.TabIndex = 0;
            lblRoomsHeader.Text = "حالة الغرف الحالية";
            // 
            // dgvOutofStock
            // 
            dgvOutofStock.AllowUserToAddRows = false;
            dgvOutofStock.AllowUserToDeleteRows = false;
            dgvOutofStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOutofStock.BackgroundColor = Color.White;
            dgvOutofStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOutofStock.Dock = DockStyle.Fill;
            dgvOutofStock.Location = new Point(15, 50);
            dgvOutofStock.Name = "dgvOutofStock";
            dgvOutofStock.ReadOnly = true;
            dgvOutofStock.RowTemplate.Height = 30;
            dgvOutofStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOutofStock.Size = new Size(370, 514);
            dgvOutofStock.TabIndex = 1;
            // 
            // lblStockHeader
            // 
            lblStockHeader.AutoSize = true;
            lblStockHeader.Dock = DockStyle.Top;
            lblStockHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblStockHeader.ForeColor = Color.Crimson;
            lblStockHeader.Location = new Point(15, 15);
            lblStockHeader.Name = "lblStockHeader";
            lblStockHeader.Padding = new Padding(0, 0, 0, 10);
            lblStockHeader.Size = new Size(120, 35);
            lblStockHeader.TabIndex = 0;
            lblStockHeader.Text = "نواقص المواد";
            // 
            // UC_Home
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(splitMain);
            Controls.Add(tlpKPIs);
            Controls.Add(pnlTopHeader);
            Name = "UC_Home";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1184, 749);
            Load += UC_Home_Load;
            pnlTopHeader.ResumeLayout(false);
            pnlTopHeader.PerformLayout();
            tlpKPIs.ResumeLayout(false);
            cardCompleted.ResumeLayout(false);
            cardCompleted.PerformLayout();
            cardTopService.ResumeLayout(false);
            cardTopService.PerformLayout();
            cardAvgTime.ResumeLayout(false);
            cardAvgTime.PerformLayout();
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel1.PerformLayout();
            splitMain.Panel2.ResumeLayout(false);
            splitMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            flpRooms.ResumeLayout(false);
            cardRoomReady.ResumeLayout(false);
            cardRoomReady.PerformLayout();
            cardRoomBusy.ResumeLayout(false);
            cardRoomBusy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOutofStock).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTopHeader;
        private System.Windows.Forms.Label lblDashboardTitle;
        private MaterialSkin.Controls.MaterialButton btnDailyClose;

        private System.Windows.Forms.TableLayoutPanel tlpKPIs;
        private MaterialSkin.Controls.MaterialCard cardCompleted;
        private System.Windows.Forms.Label lblCompletedTitle;
        private System.Windows.Forms.Label lblCompletedVal;
        private MaterialSkin.Controls.MaterialCard cardTopService;
        private System.Windows.Forms.Label lblTopServiceTitle;
        private System.Windows.Forms.Label lblTopServiceVal;
        private MaterialSkin.Controls.MaterialCard cardAvgTime;
        private System.Windows.Forms.Label lblAvgTimeTitle;
        private System.Windows.Forms.Label lblAvgTimeVal;

        private System.Windows.Forms.SplitContainer splitMain;

        // غرف العمليات
        private System.Windows.Forms.Label lblRoomsHeader;
        private System.Windows.Forms.FlowLayoutPanel flpRooms;

        // بطاقات تجريبية للغرف (ستقوم بحذفها وتوليدها برمجياً لاحقاً)
        private MaterialSkin.Controls.MaterialCard cardRoomReady;
        private System.Windows.Forms.Panel pnlReadyIndicator;
        private System.Windows.Forms.Label lblRoom1Name;
        private System.Windows.Forms.Label lblRoom1Status;

        private MaterialSkin.Controls.MaterialCard cardRoomBusy;
        private System.Windows.Forms.Panel pnlBusyIndicator;
        private System.Windows.Forms.Label lblRoom2Name;
        private System.Windows.Forms.Label lblRoom2Customer;
        private System.Windows.Forms.Label lblRoom2Service;
        private System.Windows.Forms.Label lblRoom2Time;

        // نواقص المواد
        private System.Windows.Forms.Label lblStockHeader;
        private System.Windows.Forms.DataGridView dgvOutofStock;
    }
}