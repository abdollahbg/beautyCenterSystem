namespace beautyCenterSystem.data.Repositories
{
    partial class FrmFinancialReports
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label4 = new Label();
            btnRefresh = new MaterialSkin.Controls.MaterialButton();
            btnPrint = new MaterialSkin.Controls.MaterialButton();
            label2 = new Label();
            label1 = new Label();
            dtpTo = new DateTimePicker();
            dtpFrom = new DateTimePicker();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlNetProfit = new MaterialSkin.Controls.MaterialCard();
            lblNetProfit = new Label();
            label6 = new Label();
            pnlTotalPurchases = new MaterialSkin.Controls.MaterialCard();
            lblTotalPurchases = new Label();
            label3 = new Label();
            pnlTotalExpenses = new MaterialSkin.Controls.MaterialCard();
            lblTotalExpenses = new Label();
            label8 = new Label();
            pnlTotalRevenue = new MaterialSkin.Controls.MaterialCard();
            lblTotalRevenue = new Label();
            label10 = new Label();
            splitMain = new SplitContainer();
            tableLayoutPanel2 = new TableLayoutPanel();
            dgvRoomsSummary = new DataGridView();
            dgvServicesSummary = new DataGridView();
            tabcontrol = new MaterialSkin.Controls.MaterialTabControl();
            tpSales = new TabPage();
            dgvSalesDetails = new DataGridView();
            tpExpenses = new TabPage();
            dgvExpensesDetails = new DataGridView();
            tpPurchases = new TabPage();
            dgvPurchasesDetails = new DataGridView();
            tpSafes = new TabPage();
            dgvSafesBalances = new DataGridView();
            tpDailyClosing = new TabPage();
            dgvDailyClosing = new DataGridView();
            tpEmployeeExpenses = new TabPage();
            dgvEmployeeExpenses = new DataGridView();
            tpCafeteriaRevenues = new TabPage();
            dgvCafeteriaRevenues = new DataGridView();
            tpEmployeeDetails = new TabPage();
            dgvEmployeeDetails = new DataGridView();
            materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlNetProfit.SuspendLayout();
            pnlTotalPurchases.SuspendLayout();
            pnlTotalExpenses.SuspendLayout();
            pnlTotalRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoomsSummary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvServicesSummary).BeginInit();
            tabcontrol.SuspendLayout();
            tpSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalesDetails).BeginInit();
            tpExpenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpensesDetails).BeginInit();
            tpPurchases.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPurchasesDetails).BeginInit();
            tpSafes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSafesBalances).BeginInit();
            tpDailyClosing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDailyClosing).BeginInit();
            tpEmployeeExpenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployeeExpenses).BeginInit();
            tpCafeteriaRevenues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCafeteriaRevenues).BeginInit();
            tpEmployeeDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployeeDetails).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(btnPrint);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dtpTo);
            panel1.Controls.Add(dtpFrom);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(1184, 80);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(994, 25);
            label4.Name = "label4";
            label4.Size = new Size(140, 30);
            label4.TabIndex = 7;
            label4.Text = "التقارير المالية";
            // 
            // btnRefresh
            // 
            btnRefresh.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRefresh.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRefresh.Depth = 0;
            btnRefresh.HighEmphasis = true;
            btnRefresh.Icon = null;
            btnRefresh.Location = new Point(25, 22);
            btnRefresh.Margin = new Padding(4, 6, 4, 6);
            btnRefresh.MouseState = MaterialSkin.MouseState.HOVER;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.NoAccentTextColor = Color.Empty;
            btnRefresh.Size = new Size(97, 36);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "تحديث البيانات";
            btnRefresh.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRefresh.UseAccentColor = false;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnPrint
            // 
            btnPrint.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnPrint.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnPrint.Depth = 0;
            btnPrint.HighEmphasis = true;
            btnPrint.Icon = null;
            btnPrint.Location = new Point(155, 22);
            btnPrint.Margin = new Padding(4, 6, 4, 6);
            btnPrint.MouseState = MaterialSkin.MouseState.HOVER;
            btnPrint.Name = "btnPrint";
            btnPrint.NoAccentTextColor = Color.Empty;
            btnPrint.Size = new Size(96, 36);
            btnPrint.TabIndex = 5;
            btnPrint.Text = "طباعة التقارير";
            btnPrint.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnPrint.UseAccentColor = false;
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(665, 30);
            label2.Name = "label2";
            label2.Size = new Size(34, 19);
            label2.TabIndex = 3;
            label2.Text = "إلى:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(927, 30);
            label1.Name = "label1";
            label1.Size = new Size(30, 19);
            label1.TabIndex = 2;
            label1.Text = "من:";
            // 
            // dtpTo
            // 
            dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpTo.Font = new Font("Segoe UI", 11F);
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(485, 26);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(170, 27);
            dtpTo.TabIndex = 1;
            // 
            // dtpFrom
            // 
            dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFrom.Font = new Font("Segoe UI", 11F);
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(747, 26);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(170, 27);
            dtpFrom.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(pnlNetProfit, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlTotalPurchases, 1, 0);
            tableLayoutPanel1.Controls.Add(pnlTotalExpenses, 2, 0);
            tableLayoutPanel1.Controls.Add(pnlTotalRevenue, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 80);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(15, 10, 15, 10);
            tableLayoutPanel1.RightToLeft = RightToLeft.Yes;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1184, 120);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // pnlNetProfit
            // 
            pnlNetProfit.BackColor = Color.FromArgb(255, 255, 255);
            pnlNetProfit.Controls.Add(lblNetProfit);
            pnlNetProfit.Controls.Add(label6);
            pnlNetProfit.Depth = 0;
            pnlNetProfit.Dock = DockStyle.Fill;
            pnlNetProfit.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlNetProfit.Location = new Point(886, 15);
            pnlNetProfit.Margin = new Padding(15, 5, 5, 5);
            pnlNetProfit.MouseState = MaterialSkin.MouseState.HOVER;
            pnlNetProfit.Name = "pnlNetProfit";
            pnlNetProfit.Padding = new Padding(14);
            pnlNetProfit.Size = new Size(268, 90);
            pnlNetProfit.TabIndex = 5;
            // 
            // lblNetProfit
            // 
            lblNetProfit.Dock = DockStyle.Bottom;
            lblNetProfit.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblNetProfit.ForeColor = Color.Green;
            lblNetProfit.Location = new Point(14, 46);
            lblNetProfit.Name = "lblNetProfit";
            lblNetProfit.Size = new Size(240, 30);
            lblNetProfit.TabIndex = 3;
            lblNetProfit.Text = "0.00";
            lblNetProfit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Segoe UI", 12F);
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(14, 14);
            label6.Name = "label6";
            label6.Size = new Size(240, 28);
            label6.TabIndex = 2;
            label6.Text = "صافي الربح";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTotalPurchases
            // 
            pnlTotalPurchases.BackColor = Color.FromArgb(255, 255, 255);
            pnlTotalPurchases.Controls.Add(lblTotalPurchases);
            pnlTotalPurchases.Controls.Add(label3);
            pnlTotalPurchases.Depth = 0;
            pnlTotalPurchases.Dock = DockStyle.Fill;
            pnlTotalPurchases.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlTotalPurchases.Location = new Point(603, 15);
            pnlTotalPurchases.Margin = new Padding(10, 5, 10, 5);
            pnlTotalPurchases.MouseState = MaterialSkin.MouseState.HOVER;
            pnlTotalPurchases.Name = "pnlTotalPurchases";
            pnlTotalPurchases.Padding = new Padding(14);
            pnlTotalPurchases.Size = new Size(268, 90);
            pnlTotalPurchases.TabIndex = 4;
            // 
            // lblTotalPurchases
            // 
            lblTotalPurchases.Dock = DockStyle.Bottom;
            lblTotalPurchases.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalPurchases.ForeColor = Color.FromArgb(255, 128, 128);
            lblTotalPurchases.Location = new Point(14, 46);
            lblTotalPurchases.Name = "lblTotalPurchases";
            lblTotalPurchases.Size = new Size(240, 30);
            lblTotalPurchases.TabIndex = 4;
            lblTotalPurchases.Text = "0.00";
            lblTotalPurchases.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 12F);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(14, 14);
            label3.Name = "label3";
            label3.Size = new Size(240, 28);
            label3.TabIndex = 0;
            label3.Text = "إجمالي المشتريات";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTotalExpenses
            // 
            pnlTotalExpenses.BackColor = Color.FromArgb(255, 255, 255);
            pnlTotalExpenses.Controls.Add(lblTotalExpenses);
            pnlTotalExpenses.Controls.Add(label8);
            pnlTotalExpenses.Depth = 0;
            pnlTotalExpenses.Dock = DockStyle.Fill;
            pnlTotalExpenses.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlTotalExpenses.Location = new Point(315, 15);
            pnlTotalExpenses.Margin = new Padding(10, 5, 10, 5);
            pnlTotalExpenses.MouseState = MaterialSkin.MouseState.HOVER;
            pnlTotalExpenses.Name = "pnlTotalExpenses";
            pnlTotalExpenses.Padding = new Padding(14);
            pnlTotalExpenses.Size = new Size(268, 90);
            pnlTotalExpenses.TabIndex = 0;
            // 
            // lblTotalExpenses
            // 
            lblTotalExpenses.Dock = DockStyle.Bottom;
            lblTotalExpenses.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalExpenses.ForeColor = Color.FromArgb(255, 128, 0);
            lblTotalExpenses.Location = new Point(14, 46);
            lblTotalExpenses.Name = "lblTotalExpenses";
            lblTotalExpenses.Size = new Size(240, 30);
            lblTotalExpenses.TabIndex = 4;
            lblTotalExpenses.Text = "0.00";
            lblTotalExpenses.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Segoe UI", 12F);
            label8.ForeColor = Color.Gray;
            label8.Location = new Point(14, 14);
            label8.Name = "label8";
            label8.Size = new Size(240, 28);
            label8.TabIndex = 2;
            label8.Text = "إجمالي المصروفات";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTotalRevenue
            // 
            pnlTotalRevenue.BackColor = Color.FromArgb(255, 255, 255);
            pnlTotalRevenue.Controls.Add(lblTotalRevenue);
            pnlTotalRevenue.Controls.Add(label10);
            pnlTotalRevenue.Depth = 0;
            pnlTotalRevenue.Dock = DockStyle.Fill;
            pnlTotalRevenue.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlTotalRevenue.Location = new Point(30, 15);
            pnlTotalRevenue.Margin = new Padding(5, 5, 15, 5);
            pnlTotalRevenue.MouseState = MaterialSkin.MouseState.HOVER;
            pnlTotalRevenue.Name = "pnlTotalRevenue";
            pnlTotalRevenue.Padding = new Padding(14);
            pnlTotalRevenue.Size = new Size(270, 90);
            pnlTotalRevenue.TabIndex = 3;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.Dock = DockStyle.Bottom;
            lblTotalRevenue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalRevenue.ForeColor = Color.Blue;
            lblTotalRevenue.Location = new Point(14, 46);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(242, 30);
            lblTotalRevenue.TabIndex = 3;
            lblTotalRevenue.Text = "0.00";
            lblTotalRevenue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.Dock = DockStyle.Top;
            label10.Font = new Font("Segoe UI", 12F);
            label10.ForeColor = Color.Gray;
            label10.Location = new Point(14, 14);
            label10.Name = "label10";
            label10.Size = new Size(242, 28);
            label10.TabIndex = 2;
            label10.Text = "إجمالي الإيرادات";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(0, 200);
            splitMain.Name = "splitMain";
            splitMain.Orientation = Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(tableLayoutPanel2);
            splitMain.Panel1.RightToLeft = RightToLeft.Yes;
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(tabcontrol);
            splitMain.Panel2.Controls.Add(materialTabSelector1);
            splitMain.Panel2.RightToLeft = RightToLeft.Yes;
            splitMain.Size = new Size(1184, 549);
            splitMain.SplitterDistance = 249;
            splitMain.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel2.Controls.Add(dgvRoomsSummary, 0, 0);
            tableLayoutPanel2.Controls.Add(dgvServicesSummary, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(15);
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1184, 249);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // dgvRoomsSummary
            // 
            dgvRoomsSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoomsSummary.BackgroundColor = Color.White;
            dgvRoomsSummary.BorderStyle = BorderStyle.None;
            dgvRoomsSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoomsSummary.Dock = DockStyle.Fill;
            dgvRoomsSummary.Location = new Point(711, 18);
            dgvRoomsSummary.Name = "dgvRoomsSummary";
            dgvRoomsSummary.Size = new Size(455, 103);
            dgvRoomsSummary.TabIndex = 2;
            // 
            // dgvServicesSummary
            // 
            dgvServicesSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServicesSummary.BackgroundColor = Color.White;
            dgvServicesSummary.BorderStyle = BorderStyle.None;
            dgvServicesSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServicesSummary.Dock = DockStyle.Fill;
            dgvServicesSummary.Location = new Point(711, 127);
            dgvServicesSummary.Name = "dgvServicesSummary";
            dgvServicesSummary.Size = new Size(455, 104);
            dgvServicesSummary.TabIndex = 3;
            // 
            // tabcontrol
            // 
            tabcontrol.Controls.Add(tpSales);
            tabcontrol.Controls.Add(tpExpenses);
            tabcontrol.Controls.Add(tpPurchases);
            tabcontrol.Controls.Add(tpSafes);
            tabcontrol.Controls.Add(tpDailyClosing);
            tabcontrol.Controls.Add(tpEmployeeExpenses);
            tabcontrol.Controls.Add(tpCafeteriaRevenues);
            tabcontrol.Controls.Add(tpEmployeeDetails);
            tabcontrol.Depth = 0;
            tabcontrol.Dock = DockStyle.Fill;
            tabcontrol.Location = new Point(0, 48);
            tabcontrol.MouseState = MaterialSkin.MouseState.HOVER;
            tabcontrol.Multiline = true;
            tabcontrol.Name = "tabcontrol";
            tabcontrol.RightToLeftLayout = true;
            tabcontrol.SelectedIndex = 0;
            tabcontrol.Size = new Size(1184, 248);
            tabcontrol.TabIndex = 0;
            // 
            // tpSales
            // 
            tpSales.BackColor = Color.White;
            tpSales.Controls.Add(dgvSalesDetails);
            tpSales.Location = new Point(4, 24);
            tpSales.Name = "tpSales";
            tpSales.Padding = new Padding(10);
            tpSales.Size = new Size(1176, 220);
            tpSales.TabIndex = 3;
            tpSales.Text = "تفاصيل المبيعات";
            // 
            // dgvSalesDetails
            // 
            dgvSalesDetails.BackgroundColor = Color.White;
            dgvSalesDetails.BorderStyle = BorderStyle.None;
            dgvSalesDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalesDetails.Dock = DockStyle.Fill;
            dgvSalesDetails.Location = new Point(10, 10);
            dgvSalesDetails.Name = "dgvSalesDetails";
            dgvSalesDetails.Size = new Size(1156, 200);
            dgvSalesDetails.TabIndex = 0;
            // 
            // tpExpenses
            // 
            tpExpenses.BackColor = Color.White;
            tpExpenses.Controls.Add(dgvExpensesDetails);
            tpExpenses.Location = new Point(4, 24);
            tpExpenses.Name = "tpExpenses";
            tpExpenses.Padding = new Padding(10);
            tpExpenses.Size = new Size(1176, 220);
            tpExpenses.TabIndex = 0;
            tpExpenses.Text = "تفاصيل المصروفات";
            // 
            // dgvExpensesDetails
            // 
            dgvExpensesDetails.BackgroundColor = Color.White;
            dgvExpensesDetails.BorderStyle = BorderStyle.None;
            dgvExpensesDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpensesDetails.Dock = DockStyle.Fill;
            dgvExpensesDetails.Location = new Point(10, 10);
            dgvExpensesDetails.Name = "dgvExpensesDetails";
            dgvExpensesDetails.Size = new Size(1156, 200);
            dgvExpensesDetails.TabIndex = 0;
            // 
            // tpPurchases
            // 
            tpPurchases.BackColor = Color.White;
            tpPurchases.Controls.Add(dgvPurchasesDetails);
            tpPurchases.Location = new Point(4, 24);
            tpPurchases.Name = "tpPurchases";
            tpPurchases.Padding = new Padding(10);
            tpPurchases.Size = new Size(1176, 220);
            tpPurchases.TabIndex = 1;
            tpPurchases.Text = "تفاصيل المشتريات";
            // 
            // dgvPurchasesDetails
            // 
            dgvPurchasesDetails.BackgroundColor = Color.White;
            dgvPurchasesDetails.BorderStyle = BorderStyle.None;
            dgvPurchasesDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPurchasesDetails.Dock = DockStyle.Fill;
            dgvPurchasesDetails.Location = new Point(10, 10);
            dgvPurchasesDetails.Name = "dgvPurchasesDetails";
            dgvPurchasesDetails.Size = new Size(1156, 200);
            dgvPurchasesDetails.TabIndex = 1;
            // 
            // tpSafes
            // 
            tpSafes.BackColor = Color.White;
            tpSafes.Controls.Add(dgvSafesBalances);
            tpSafes.Location = new Point(4, 24);
            tpSafes.Name = "tpSafes";
            tpSafes.Padding = new Padding(10);
            tpSafes.Size = new Size(1176, 220);
            tpSafes.TabIndex = 2;
            tpSafes.Text = "أرصدة الخزائن الحالية";
            // 
            // dgvSafesBalances
            // 
            dgvSafesBalances.BackgroundColor = Color.White;
            dgvSafesBalances.BorderStyle = BorderStyle.None;
            dgvSafesBalances.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSafesBalances.Dock = DockStyle.Fill;
            dgvSafesBalances.Location = new Point(10, 10);
            dgvSafesBalances.Name = "dgvSafesBalances";
            dgvSafesBalances.Size = new Size(1156, 200);
            dgvSafesBalances.TabIndex = 2;
            // 
            // tpDailyClosing
            // 
            tpDailyClosing.BackColor = Color.White;
            tpDailyClosing.Controls.Add(dgvDailyClosing);
            tpDailyClosing.Location = new Point(4, 24);
            tpDailyClosing.Name = "tpDailyClosing";
            tpDailyClosing.Padding = new Padding(10);
            tpDailyClosing.Size = new Size(1176, 220);
            tpDailyClosing.TabIndex = 4;
            tpDailyClosing.Text = "إغلاق الحسابات اليومية";
            // 
            // dgvDailyClosing
            // 
            dgvDailyClosing.BackgroundColor = Color.White;
            dgvDailyClosing.BorderStyle = BorderStyle.None;
            dgvDailyClosing.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDailyClosing.Dock = DockStyle.Fill;
            dgvDailyClosing.Location = new Point(10, 10);
            dgvDailyClosing.Name = "dgvDailyClosing";
            dgvDailyClosing.Size = new Size(1156, 200);
            dgvDailyClosing.TabIndex = 0;
            // 
            // tpEmployeeExpenses
            // 
            tpEmployeeExpenses.BackColor = Color.White;
            tpEmployeeExpenses.Controls.Add(dgvEmployeeExpenses);
            tpEmployeeExpenses.Location = new Point(4, 24);
            tpEmployeeExpenses.Name = "tpEmployeeExpenses";
            tpEmployeeExpenses.Padding = new Padding(10);
            tpEmployeeExpenses.Size = new Size(1176, 220);
            tpEmployeeExpenses.TabIndex = 5;
            tpEmployeeExpenses.Text = "مصروفات الموظفات";
            // 
            // dgvEmployeeExpenses
            // 
            dgvEmployeeExpenses.BackgroundColor = Color.White;
            dgvEmployeeExpenses.BorderStyle = BorderStyle.None;
            dgvEmployeeExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployeeExpenses.Dock = DockStyle.Fill;
            dgvEmployeeExpenses.Location = new Point(10, 10);
            dgvEmployeeExpenses.Name = "dgvEmployeeExpenses";
            dgvEmployeeExpenses.Size = new Size(1156, 200);
            dgvEmployeeExpenses.TabIndex = 0;
            // 
            // tpCafeteriaRevenues
            // 
            tpCafeteriaRevenues.BackColor = Color.White;
            tpCafeteriaRevenues.Controls.Add(dgvCafeteriaRevenues);
            tpCafeteriaRevenues.Location = new Point(4, 24);
            tpCafeteriaRevenues.Name = "tpCafeteriaRevenues";
            tpCafeteriaRevenues.Padding = new Padding(10);
            tpCafeteriaRevenues.Size = new Size(1176, 220);
            tpCafeteriaRevenues.TabIndex = 6;
            tpCafeteriaRevenues.Text = "إيرادات الكافيتيريا";
            // 
            // dgvCafeteriaRevenues
            // 
            dgvCafeteriaRevenues.BackgroundColor = Color.White;
            dgvCafeteriaRevenues.BorderStyle = BorderStyle.None;
            dgvCafeteriaRevenues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCafeteriaRevenues.Dock = DockStyle.Fill;
            dgvCafeteriaRevenues.Location = new Point(10, 10);
            dgvCafeteriaRevenues.Name = "dgvCafeteriaRevenues";
            dgvCafeteriaRevenues.Size = new Size(1156, 200);
            dgvCafeteriaRevenues.TabIndex = 0;
            // 
            // tpEmployeeDetails
            // 
            tpEmployeeDetails.BackColor = Color.White;
            tpEmployeeDetails.Controls.Add(dgvEmployeeDetails);
            tpEmployeeDetails.Location = new Point(4, 24);
            tpEmployeeDetails.Name = "tpEmployeeDetails";
            tpEmployeeDetails.Padding = new Padding(10);
            tpEmployeeDetails.Size = new Size(1176, 220);
            tpEmployeeDetails.TabIndex = 7;
            tpEmployeeDetails.Text = "أداء الموظفات";
            // 
            // dgvEmployeeDetails
            // 
            dgvEmployeeDetails.BackgroundColor = Color.White;
            dgvEmployeeDetails.BorderStyle = BorderStyle.None;
            dgvEmployeeDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployeeDetails.Dock = DockStyle.Fill;
            dgvEmployeeDetails.Location = new Point(10, 10);
            dgvEmployeeDetails.Name = "dgvEmployeeDetails";
            dgvEmployeeDetails.Size = new Size(1156, 200);
            dgvEmployeeDetails.TabIndex = 0;
            // 
            // materialTabSelector1
            // 
            materialTabSelector1.BaseTabControl = tabcontrol;
            materialTabSelector1.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            materialTabSelector1.Depth = 0;
            materialTabSelector1.Dock = DockStyle.Top;
            materialTabSelector1.Font = new Font("IRANYekanMobileFN", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTabSelector1.Location = new Point(0, 0);
            materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabSelector1.Name = "materialTabSelector1";
            materialTabSelector1.Size = new Size(1184, 48);
            materialTabSelector1.TabIndex = 1;
            materialTabSelector1.Text = "materialTabSelector1";
            // 
            // FrmFinancialReports
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(242, 242, 242);
            ClientSize = new Size(1184, 749);
            Controls.Add(splitMain);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Name = "FrmFinancialReports";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "التقارير المالية المجمعة";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            pnlNetProfit.ResumeLayout(false);
            pnlTotalPurchases.ResumeLayout(false);
            pnlTotalExpenses.ResumeLayout(false);
            pnlTotalRevenue.ResumeLayout(false);
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRoomsSummary).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvServicesSummary).EndInit();
            tabcontrol.ResumeLayout(false);
            tpSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSalesDetails).EndInit();
            tpExpenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExpensesDetails).EndInit();
            tpPurchases.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPurchasesDetails).EndInit();
            tpSafes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSafesBalances).EndInit();
            tpDailyClosing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDailyClosing).EndInit();
            tpEmployeeExpenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployeeExpenses).EndInit();
            tpCafeteriaRevenues.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCafeteriaRevenues).EndInit();
            tpEmployeeDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployeeDetails).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialCard pnlTotalExpenses;
        private MaterialSkin.Controls.MaterialCard pnlNetProfit;
        private MaterialSkin.Controls.MaterialCard pnlTotalPurchases;
        private MaterialSkin.Controls.MaterialCard pnlTotalRevenue;
        private System.Windows.Forms.Label lblNetProfit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalPurchases;
        private System.Windows.Forms.Label lblTotalExpenses;
        private System.Windows.Forms.SplitContainer splitMain;

        // التغييرات البرمجية المطلوبة للـ MaterialSkin والتبويبات القديمة والجديدة
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvRoomsSummary;
        private System.Windows.Forms.DataGridView dgvServicesSummary;

        // تحويل الأزرار إلى MaterialButton مع الإبقاء على نفس الأسماء
        private MaterialSkin.Controls.MaterialButton btnPrint;
        private MaterialSkin.Controls.MaterialButton btnRefresh;

        private System.Windows.Forms.Label label4;
        private MaterialSkin.Controls.MaterialTabControl tabcontrol;
        private TabPage tpSales;
        private DataGridView dgvSalesDetails;
        private TabPage tpExpenses;
        private DataGridView dgvExpensesDetails;
        private TabPage tpPurchases;
        private DataGridView dgvPurchasesDetails;
        private TabPage tpSafes;
        private DataGridView dgvSafesBalances;
        private TabPage tpDailyClosing;
        private DataGridView dgvDailyClosing;
        private TabPage tpEmployeeExpenses;
        private DataGridView dgvEmployeeExpenses;
        private TabPage tpCafeteriaRevenues;
        private DataGridView dgvCafeteriaRevenues;
        private TabPage tpEmployeeDetails;
        private DataGridView dgvEmployeeDetails;
    }
}