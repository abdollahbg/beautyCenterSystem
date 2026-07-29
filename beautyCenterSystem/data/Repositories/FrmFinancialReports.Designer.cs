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
            chkEnableDateFilter = new CheckBox();
            dtpTo = new DateTimePicker();
            dtpFrom = new DateTimePicker();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlTotalRevenue = new MaterialSkin.Controls.MaterialCard();
            lblTotalRevenue = new Label();
            label10 = new Label();
            pnlTotalPurchases = new MaterialSkin.Controls.MaterialCard();
            lblTotalPurchases = new Label();
            label3 = new Label();
            pnlTotalExpenses = new MaterialSkin.Controls.MaterialCard();
            lblTotalExpenses = new Label();
            label8 = new Label();
            pnlNetProfit = new MaterialSkin.Controls.MaterialCard();
            lblNetProfit = new Label();
            label6 = new Label();
            pnlTotalEmployeeDues = new MaterialSkin.Controls.MaterialCard();
            lblTotalEmployeeDues = new Label();
            labelEmployeeDuesTitle = new Label();
            pnlTotalTrainerDues = new MaterialSkin.Controls.MaterialCard();
            lblTotalTrainerDues = new Label();
            labelTrainerDuesTitle = new Label();
            pnlTotalGym = new MaterialSkin.Controls.MaterialCard();
            lblTotalGym = new Label();
            labelTotalGymTitle = new Label();
            pnlTotalCafeteria = new MaterialSkin.Controls.MaterialCard();
            lblTotalCafeteria = new Label();
            labelTotalCafeteriaTitle = new Label();
            mainLayout = new TableLayoutPanel();
            pnlSidebar = new Panel();
            btnNavEmployeePerf = new FontAwesome.Sharp.IconButton();
            btnNavCafeteria = new FontAwesome.Sharp.IconButton();
            btnNavGym = new FontAwesome.Sharp.IconButton();
            btnNavEmployeeExpenses = new FontAwesome.Sharp.IconButton();
            btnNavTrainerExpenses = new FontAwesome.Sharp.IconButton();
            btnNavDailyClosing = new FontAwesome.Sharp.IconButton();
            btnNavSafes = new FontAwesome.Sharp.IconButton();
            btnNavPurchases = new FontAwesome.Sharp.IconButton();
            btnNavExpenses = new FontAwesome.Sharp.IconButton();
            btnNavSales = new FontAwesome.Sharp.IconButton();
            btnNavRooms = new FontAwesome.Sharp.IconButton();
            btnNavServices = new FontAwesome.Sharp.IconButton();
            pnlMainContainer = new Panel();
            pnlContent = new Panel();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlTotalRevenue.SuspendLayout();
            pnlTotalPurchases.SuspendLayout();
            pnlTotalExpenses.SuspendLayout();
            pnlNetProfit.SuspendLayout();
            pnlTotalEmployeeDues.SuspendLayout();
            pnlTotalTrainerDues.SuspendLayout();
            pnlTotalGym.SuspendLayout();
            pnlTotalCafeteria.SuspendLayout();
            mainLayout.SuspendLayout();
            pnlSidebar.SuspendLayout();
            pnlMainContainer.SuspendLayout();
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
            panel1.Controls.Add(chkEnableDateFilter);
            panel1.Controls.Add(dtpTo);
            panel1.Controls.Add(dtpFrom);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(928, 80);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(738, 25);
            label4.Name = "label4";
            label4.Size = new Size(122, 25);
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
            label2.Location = new Point(409, 30);
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
            label1.Location = new Point(671, 30);
            label1.Name = "label1";
            label1.Size = new Size(30, 19);
            label1.TabIndex = 2;
            label1.Text = "من:";
            // 
            // chkEnableDateFilter
            // 
            chkEnableDateFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkEnableDateFilter.AutoSize = true;
            chkEnableDateFilter.Checked = true;
            chkEnableDateFilter.CheckState = CheckState.Checked;
            chkEnableDateFilter.Location = new Point(141, 30);
            chkEnableDateFilter.Name = "chkEnableDateFilter";
            chkEnableDateFilter.Size = new Size(84, 19);
            chkEnableDateFilter.TabIndex = 99;
            chkEnableDateFilter.Text = "تفعيل الفلتر";
            chkEnableDateFilter.UseVisualStyleBackColor = true;
            chkEnableDateFilter.CheckedChanged += chkEnableDateFilter_CheckedChanged;
            // 
            // dtpTo
            // 
            dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpTo.Font = new Font("Segoe UI", 11F);
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(229, 26);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(170, 27);
            dtpTo.TabIndex = 1;
            // 
            // dtpFrom
            // 
            dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFrom.Font = new Font("Segoe UI", 11F);
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(491, 26);
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
            tableLayoutPanel1.Controls.Add(pnlTotalRevenue, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlTotalPurchases, 1, 0);
            tableLayoutPanel1.Controls.Add(pnlTotalExpenses, 2, 0);
            tableLayoutPanel1.Controls.Add(pnlNetProfit, 3, 0);
            tableLayoutPanel1.Controls.Add(pnlTotalEmployeeDues, 0, 1);
            tableLayoutPanel1.Controls.Add(pnlTotalTrainerDues, 1, 1);
            tableLayoutPanel1.Controls.Add(pnlTotalGym, 2, 1);
            tableLayoutPanel1.Controls.Add(pnlTotalCafeteria, 3, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 80);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(15, 10, 15, 10);
            tableLayoutPanel1.RightToLeft = RightToLeft.Yes;
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(928, 200);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // pnlTotalRevenue
            // 
            pnlTotalRevenue.BackColor = Color.FromArgb(255, 255, 255);
            pnlTotalRevenue.Controls.Add(lblTotalRevenue);
            pnlTotalRevenue.Controls.Add(label10);
            pnlTotalRevenue.Depth = 0;
            pnlTotalRevenue.Dock = DockStyle.Fill;
            pnlTotalRevenue.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlTotalRevenue.Location = new Point(704, 15);
            pnlTotalRevenue.Margin = new Padding(5, 5, 15, 5);
            pnlTotalRevenue.MouseState = MaterialSkin.MouseState.HOVER;
            pnlTotalRevenue.Name = "pnlTotalRevenue";
            pnlTotalRevenue.Padding = new Padding(5);
            pnlTotalRevenue.Size = new Size(204, 80);
            pnlTotalRevenue.TabIndex = 2;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.Dock = DockStyle.Bottom;
            lblTotalRevenue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalRevenue.ForeColor = Color.FromArgb(41, 128, 185);
            lblTotalRevenue.Location = new Point(5, 50);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(194, 25);
            lblTotalRevenue.TabIndex = 3;
            lblTotalRevenue.Text = "0.00";
            lblTotalRevenue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.Dock = DockStyle.Top;
            label10.Font = new Font("Segoe UI", 10F);
            label10.ForeColor = Color.Gray;
            label10.Location = new Point(5, 5);
            label10.Name = "label10";
            label10.Size = new Size(194, 20);
            label10.TabIndex = 2;
            label10.Text = "إجمالي المدخول";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTotalPurchases
            // 
            pnlTotalPurchases.BackColor = Color.FromArgb(255, 255, 255);
            pnlTotalPurchases.Controls.Add(lblTotalPurchases);
            pnlTotalPurchases.Controls.Add(label3);
            pnlTotalPurchases.Depth = 0;
            pnlTotalPurchases.Dock = DockStyle.Fill;
            pnlTotalPurchases.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlTotalPurchases.Location = new Point(475, 15);
            pnlTotalPurchases.Margin = new Padding(10, 5, 10, 5);
            pnlTotalPurchases.MouseState = MaterialSkin.MouseState.HOVER;
            pnlTotalPurchases.Name = "pnlTotalPurchases";
            pnlTotalPurchases.Padding = new Padding(5);
            pnlTotalPurchases.Size = new Size(204, 80);
            pnlTotalPurchases.TabIndex = 4;
            // 
            // lblTotalPurchases
            // 
            lblTotalPurchases.Dock = DockStyle.Bottom;
            lblTotalPurchases.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalPurchases.ForeColor = Color.FromArgb(255, 128, 128);
            lblTotalPurchases.Location = new Point(5, 50);
            lblTotalPurchases.Name = "lblTotalPurchases";
            lblTotalPurchases.Size = new Size(194, 25);
            lblTotalPurchases.TabIndex = 4;
            lblTotalPurchases.Text = "0.00";
            lblTotalPurchases.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(5, 5);
            label3.Name = "label3";
            label3.Size = new Size(194, 20);
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
            pnlTotalExpenses.Location = new Point(251, 15);
            pnlTotalExpenses.Margin = new Padding(10, 5, 10, 5);
            pnlTotalExpenses.MouseState = MaterialSkin.MouseState.HOVER;
            pnlTotalExpenses.Name = "pnlTotalExpenses";
            pnlTotalExpenses.Padding = new Padding(5);
            pnlTotalExpenses.Size = new Size(204, 80);
            pnlTotalExpenses.TabIndex = 0;
            // 
            // lblTotalExpenses
            // 
            lblTotalExpenses.Dock = DockStyle.Bottom;
            lblTotalExpenses.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalExpenses.ForeColor = Color.FromArgb(255, 128, 0);
            lblTotalExpenses.Location = new Point(5, 50);
            lblTotalExpenses.Name = "lblTotalExpenses";
            lblTotalExpenses.Size = new Size(194, 25);
            lblTotalExpenses.TabIndex = 4;
            lblTotalExpenses.Text = "0.00";
            lblTotalExpenses.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Segoe UI", 10F);
            label8.ForeColor = Color.Gray;
            label8.Location = new Point(5, 5);
            label8.Name = "label8";
            label8.Size = new Size(194, 20);
            label8.TabIndex = 2;
            label8.Text = "إجمالي المصروفات";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlNetProfit
            // 
            pnlNetProfit.BackColor = Color.FromArgb(255, 255, 255);
            pnlNetProfit.Controls.Add(lblNetProfit);
            pnlNetProfit.Controls.Add(label6);
            pnlNetProfit.Depth = 0;
            pnlNetProfit.Dock = DockStyle.Fill;
            pnlNetProfit.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlNetProfit.Location = new Point(20, 15);
            pnlNetProfit.Margin = new Padding(15, 5, 5, 5);
            pnlNetProfit.MouseState = MaterialSkin.MouseState.HOVER;
            pnlNetProfit.Name = "pnlNetProfit";
            pnlNetProfit.Padding = new Padding(5);
            pnlNetProfit.Size = new Size(206, 80);
            pnlNetProfit.TabIndex = 5;
            // 
            // lblNetProfit
            // 
            lblNetProfit.Dock = DockStyle.Bottom;
            lblNetProfit.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblNetProfit.ForeColor = Color.Green;
            lblNetProfit.Location = new Point(5, 50);
            lblNetProfit.Name = "lblNetProfit";
            lblNetProfit.Size = new Size(196, 25);
            lblNetProfit.TabIndex = 3;
            lblNetProfit.Text = "0.00";
            lblNetProfit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Segoe UI", 10F);
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(5, 5);
            label6.Name = "label6";
            label6.Size = new Size(196, 20);
            label6.TabIndex = 2;
            label6.Text = "صافي الربح";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTotalEmployeeDues
            // 
            pnlTotalEmployeeDues.BackColor = Color.FromArgb(255, 255, 255);
            pnlTotalEmployeeDues.Controls.Add(lblTotalEmployeeDues);
            pnlTotalEmployeeDues.Controls.Add(labelEmployeeDuesTitle);
            pnlTotalEmployeeDues.Depth = 0;
            pnlTotalEmployeeDues.Dock = DockStyle.Fill;
            pnlTotalEmployeeDues.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlTotalEmployeeDues.Location = new Point(704, 105);
            pnlTotalEmployeeDues.Margin = new Padding(5, 5, 15, 5);
            pnlTotalEmployeeDues.MouseState = MaterialSkin.MouseState.HOVER;
            pnlTotalEmployeeDues.Name = "pnlTotalEmployeeDues";
            pnlTotalEmployeeDues.Padding = new Padding(5);
            pnlTotalEmployeeDues.Size = new Size(204, 80);
            pnlTotalEmployeeDues.TabIndex = 6;
            // 
            // lblTotalEmployeeDues
            // 
            lblTotalEmployeeDues.Dock = DockStyle.Bottom;
            lblTotalEmployeeDues.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalEmployeeDues.ForeColor = Color.DarkOrange;
            lblTotalEmployeeDues.Location = new Point(5, 50);
            lblTotalEmployeeDues.Name = "lblTotalEmployeeDues";
            lblTotalEmployeeDues.Size = new Size(194, 25);
            lblTotalEmployeeDues.TabIndex = 3;
            lblTotalEmployeeDues.Text = "0.00";
            lblTotalEmployeeDues.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelEmployeeDuesTitle
            // 
            labelEmployeeDuesTitle.Dock = DockStyle.Top;
            labelEmployeeDuesTitle.Font = new Font("Segoe UI", 10F);
            labelEmployeeDuesTitle.ForeColor = Color.Gray;
            labelEmployeeDuesTitle.Location = new Point(5, 5);
            labelEmployeeDuesTitle.Name = "labelEmployeeDuesTitle";
            labelEmployeeDuesTitle.Size = new Size(194, 20);
            labelEmployeeDuesTitle.TabIndex = 2;
            labelEmployeeDuesTitle.Text = "مستحقات الموظفات";
            labelEmployeeDuesTitle.TextAlign = ContentAlignment.MiddleCenter;
            labelEmployeeDuesTitle.Click += labelEmployeeDuesTitle_Click;
            // 
            // pnlTotalTrainerDues
            // 
            pnlTotalTrainerDues.BackColor = Color.FromArgb(255, 255, 255);
            pnlTotalTrainerDues.Controls.Add(lblTotalTrainerDues);
            pnlTotalTrainerDues.Controls.Add(labelTrainerDuesTitle);
            pnlTotalTrainerDues.Depth = 0;
            pnlTotalTrainerDues.Dock = DockStyle.Fill;
            pnlTotalTrainerDues.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlTotalTrainerDues.Location = new Point(480, 105);
            pnlTotalTrainerDues.Margin = new Padding(5, 5, 15, 5);
            pnlTotalTrainerDues.MouseState = MaterialSkin.MouseState.HOVER;
            pnlTotalTrainerDues.Name = "pnlTotalTrainerDues";
            pnlTotalTrainerDues.Padding = new Padding(5);
            pnlTotalTrainerDues.Size = new Size(204, 80);
            pnlTotalTrainerDues.TabIndex = 7;
            // 
            // lblTotalTrainerDues
            // 
            lblTotalTrainerDues.Dock = DockStyle.Bottom;
            lblTotalTrainerDues.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalTrainerDues.ForeColor = Color.DarkOrange;
            lblTotalTrainerDues.Location = new Point(5, 50);
            lblTotalTrainerDues.Name = "lblTotalTrainerDues";
            lblTotalTrainerDues.Size = new Size(194, 25);
            lblTotalTrainerDues.TabIndex = 3;
            lblTotalTrainerDues.Text = "0.00";
            lblTotalTrainerDues.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTrainerDuesTitle
            // 
            labelTrainerDuesTitle.Dock = DockStyle.Top;
            labelTrainerDuesTitle.Font = new Font("Segoe UI", 10F);
            labelTrainerDuesTitle.ForeColor = Color.Gray;
            labelTrainerDuesTitle.Location = new Point(5, 5);
            labelTrainerDuesTitle.Name = "labelTrainerDuesTitle";
            labelTrainerDuesTitle.Size = new Size(194, 20);
            labelTrainerDuesTitle.TabIndex = 2;
            labelTrainerDuesTitle.Text = "مستحقات المدربات";
            labelTrainerDuesTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTotalGym
            // 
            pnlTotalGym.BackColor = Color.FromArgb(255, 255, 255);
            pnlTotalGym.Controls.Add(lblTotalGym);
            pnlTotalGym.Controls.Add(labelTotalGymTitle);
            pnlTotalGym.Depth = 0;
            pnlTotalGym.Dock = DockStyle.Fill;
            pnlTotalGym.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlTotalGym.Location = new Point(251, 115);
            pnlTotalGym.Margin = new Padding(10, 15, 10, 5);
            pnlTotalGym.MouseState = MaterialSkin.MouseState.HOVER;
            pnlTotalGym.Name = "pnlTotalGym";
            pnlTotalGym.Padding = new Padding(5);
            pnlTotalGym.Size = new Size(204, 70);
            pnlTotalGym.TabIndex = 8;
            // 
            // lblTotalGym
            // 
            lblTotalGym.Dock = DockStyle.Bottom;
            lblTotalGym.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalGym.ForeColor = Color.Purple;
            lblTotalGym.Location = new Point(5, 40);
            lblTotalGym.Name = "lblTotalGym";
            lblTotalGym.Size = new Size(194, 25);
            lblTotalGym.TabIndex = 3;
            lblTotalGym.Text = "0.00";
            lblTotalGym.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTotalGymTitle
            // 
            labelTotalGymTitle.Dock = DockStyle.Top;
            labelTotalGymTitle.Font = new Font("Segoe UI", 10F);
            labelTotalGymTitle.ForeColor = Color.Gray;
            labelTotalGymTitle.Location = new Point(5, 5);
            labelTotalGymTitle.Name = "labelTotalGymTitle";
            labelTotalGymTitle.Size = new Size(194, 20);
            labelTotalGymTitle.TabIndex = 2;
            labelTotalGymTitle.Text = "دخل الجيم";
            labelTotalGymTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTotalCafeteria
            // 
            pnlTotalCafeteria.BackColor = Color.FromArgb(255, 255, 255);
            pnlTotalCafeteria.Controls.Add(lblTotalCafeteria);
            pnlTotalCafeteria.Controls.Add(labelTotalCafeteriaTitle);
            pnlTotalCafeteria.Depth = 0;
            pnlTotalCafeteria.Dock = DockStyle.Fill;
            pnlTotalCafeteria.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlTotalCafeteria.Location = new Point(20, 115);
            pnlTotalCafeteria.Margin = new Padding(15, 15, 5, 5);
            pnlTotalCafeteria.MouseState = MaterialSkin.MouseState.HOVER;
            pnlTotalCafeteria.Name = "pnlTotalCafeteria";
            pnlTotalCafeteria.Padding = new Padding(5);
            pnlTotalCafeteria.Size = new Size(206, 70);
            pnlTotalCafeteria.TabIndex = 9;
            // 
            // lblTotalCafeteria
            // 
            lblTotalCafeteria.Dock = DockStyle.Bottom;
            lblTotalCafeteria.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalCafeteria.ForeColor = Color.Orange;
            lblTotalCafeteria.Location = new Point(5, 40);
            lblTotalCafeteria.Name = "lblTotalCafeteria";
            lblTotalCafeteria.Size = new Size(196, 25);
            lblTotalCafeteria.TabIndex = 3;
            lblTotalCafeteria.Text = "0.00";
            lblTotalCafeteria.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTotalCafeteriaTitle
            // 
            labelTotalCafeteriaTitle.Dock = DockStyle.Top;
            labelTotalCafeteriaTitle.Font = new Font("Segoe UI", 10F);
            labelTotalCafeteriaTitle.ForeColor = Color.Gray;
            labelTotalCafeteriaTitle.Location = new Point(5, 5);
            labelTotalCafeteriaTitle.Name = "labelTotalCafeteriaTitle";
            labelTotalCafeteriaTitle.Size = new Size(196, 20);
            labelTotalCafeteriaTitle.TabIndex = 2;
            labelTotalCafeteriaTitle.Text = "دخل الكافيتيريا";
            labelTotalCafeteriaTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(pnlSidebar, 0, 0);
            mainLayout.Controls.Add(pnlMainContainer, 1, 0);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 1;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Size = new Size(1184, 749);
            mainLayout.TabIndex = 0;
            // 
            // pnlSidebar
            // 
            pnlSidebar.AutoScroll = true;
            pnlSidebar.BackColor = Color.FromArgb(240, 240, 240);
            pnlSidebar.Controls.Add(btnNavEmployeePerf);
            pnlSidebar.Controls.Add(btnNavCafeteria);
            pnlSidebar.Controls.Add(btnNavGym);
            pnlSidebar.Controls.Add(btnNavEmployeeExpenses);
            pnlSidebar.Controls.Add(btnNavTrainerExpenses);
            pnlSidebar.Controls.Add(btnNavDailyClosing);
            pnlSidebar.Controls.Add(btnNavSafes);
            pnlSidebar.Controls.Add(btnNavPurchases);
            pnlSidebar.Controls.Add(btnNavExpenses);
            pnlSidebar.Controls.Add(btnNavSales);
            pnlSidebar.Controls.Add(btnNavRooms);
            pnlSidebar.Controls.Add(btnNavServices);
            pnlSidebar.Dock = DockStyle.Fill;
            pnlSidebar.Location = new Point(937, 3);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(244, 743);
            pnlSidebar.TabIndex = 0;
            // 
            // btnNavEmployeePerf
            // 
            btnNavEmployeePerf.Dock = DockStyle.Top;
            btnNavEmployeePerf.FlatAppearance.BorderSize = 0;
            btnNavEmployeePerf.FlatStyle = FlatStyle.Flat;
            btnNavEmployeePerf.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnNavEmployeePerf.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            btnNavEmployeePerf.IconColor = Color.Black;
            btnNavEmployeePerf.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNavEmployeePerf.IconSize = 35;
            btnNavEmployeePerf.ImageAlign = ContentAlignment.MiddleRight;
            btnNavEmployeePerf.Location = new Point(0, 550);
            btnNavEmployeePerf.Name = "btnNavEmployeePerf";
            btnNavEmployeePerf.Padding = new Padding(0, 0, 15, 0);
            btnNavEmployeePerf.Size = new Size(244, 55);
            btnNavEmployeePerf.TabIndex = 0;
            btnNavEmployeePerf.Text = "أداء الموظفات";
            btnNavEmployeePerf.TextAlign = ContentAlignment.MiddleRight;
            btnNavEmployeePerf.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // btnNavCafeteria
            // 
            btnNavCafeteria.Dock = DockStyle.Top;
            btnNavCafeteria.FlatAppearance.BorderSize = 0;
            btnNavCafeteria.FlatStyle = FlatStyle.Flat;
            btnNavCafeteria.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnNavCafeteria.IconChar = FontAwesome.Sharp.IconChar.MugSaucer;
            btnNavCafeteria.IconColor = Color.Black;
            btnNavCafeteria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNavCafeteria.IconSize = 35;
            btnNavCafeteria.ImageAlign = ContentAlignment.MiddleRight;
            btnNavCafeteria.Location = new Point(0, 495);
            btnNavCafeteria.Name = "btnNavCafeteria";
            btnNavCafeteria.Padding = new Padding(0, 0, 15, 0);
            btnNavCafeteria.Size = new Size(244, 55);
            btnNavCafeteria.TabIndex = 1;
            btnNavCafeteria.Text = "إيرادات الكافيتريا";
            btnNavCafeteria.TextAlign = ContentAlignment.MiddleRight;
            btnNavCafeteria.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // btnNavGym
            // 
            btnNavGym.Dock = DockStyle.Top;
            btnNavGym.FlatAppearance.BorderSize = 0;
            btnNavGym.FlatStyle = FlatStyle.Flat;
            btnNavGym.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnNavGym.IconChar = FontAwesome.Sharp.IconChar.Dumbbell;
            btnNavGym.IconColor = Color.Black;
            btnNavGym.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNavGym.IconSize = 35;
            btnNavGym.ImageAlign = ContentAlignment.MiddleRight;
            btnNavGym.Location = new Point(0, 440);
            btnNavGym.Name = "btnNavGym";
            btnNavGym.Padding = new Padding(0, 0, 15, 0);
            btnNavGym.Size = new Size(244, 55);
            btnNavGym.TabIndex = 2;
            btnNavGym.Text = "إيرادات الجيم";
            btnNavGym.TextAlign = ContentAlignment.MiddleRight;
            btnNavGym.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // btnNavEmployeeExpenses
            // 
            btnNavEmployeeExpenses.Dock = DockStyle.Top;
            btnNavEmployeeExpenses.FlatAppearance.BorderSize = 0;
            btnNavEmployeeExpenses.FlatStyle = FlatStyle.Flat;
            btnNavEmployeeExpenses.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnNavEmployeeExpenses.IconChar = FontAwesome.Sharp.IconChar.UsersCog;
            btnNavEmployeeExpenses.IconColor = Color.Black;
            btnNavEmployeeExpenses.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNavEmployeeExpenses.IconSize = 35;
            btnNavEmployeeExpenses.ImageAlign = ContentAlignment.MiddleRight;
            btnNavEmployeeExpenses.Location = new Point(0, 385);
            btnNavEmployeeExpenses.Name = "btnNavEmployeeExpenses";
            btnNavEmployeeExpenses.Padding = new Padding(0, 0, 15, 0);
            btnNavEmployeeExpenses.Size = new Size(244, 55);
            btnNavEmployeeExpenses.TabIndex = 3;
            btnNavEmployeeExpenses.Text = "مصروفات الموظفين";
            btnNavEmployeeExpenses.TextAlign = ContentAlignment.MiddleRight;
            btnNavEmployeeExpenses.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // btnNavTrainerExpenses
            // 
            btnNavTrainerExpenses.Dock = DockStyle.Top;
            btnNavTrainerExpenses.FlatAppearance.BorderSize = 0;
            btnNavTrainerExpenses.FlatStyle = FlatStyle.Flat;
            btnNavTrainerExpenses.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnNavTrainerExpenses.IconChar = FontAwesome.Sharp.IconChar.UsersCog;
            btnNavTrainerExpenses.IconColor = Color.Black;
            btnNavTrainerExpenses.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNavTrainerExpenses.IconSize = 35;
            btnNavTrainerExpenses.ImageAlign = ContentAlignment.MiddleRight;
            btnNavTrainerExpenses.Location = new Point(0, 440);
            btnNavTrainerExpenses.Name = "btnNavTrainerExpenses";
            btnNavTrainerExpenses.Padding = new Padding(0, 0, 15, 0);
            btnNavTrainerExpenses.Size = new Size(244, 55);
            btnNavTrainerExpenses.TabIndex = 4;
            btnNavTrainerExpenses.Text = "مصروفات المدربات";
            btnNavTrainerExpenses.TextAlign = ContentAlignment.MiddleRight;
            btnNavTrainerExpenses.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // btnNavDailyClosing
            // 
            btnNavDailyClosing.Dock = DockStyle.Top;
            btnNavDailyClosing.FlatAppearance.BorderSize = 0;
            btnNavDailyClosing.FlatStyle = FlatStyle.Flat;
            btnNavDailyClosing.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnNavDailyClosing.IconChar = FontAwesome.Sharp.IconChar.CalendarDay;
            btnNavDailyClosing.IconColor = Color.Black;
            btnNavDailyClosing.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNavDailyClosing.IconSize = 35;
            btnNavDailyClosing.ImageAlign = ContentAlignment.MiddleRight;
            btnNavDailyClosing.Location = new Point(0, 330);
            btnNavDailyClosing.Name = "btnNavDailyClosing";
            btnNavDailyClosing.Padding = new Padding(0, 0, 15, 0);
            btnNavDailyClosing.Size = new Size(244, 55);
            btnNavDailyClosing.TabIndex = 4;
            btnNavDailyClosing.Text = "التقفيل اليومي";
            btnNavDailyClosing.TextAlign = ContentAlignment.MiddleRight;
            btnNavDailyClosing.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // btnNavSafes
            // 
            btnNavSafes.Dock = DockStyle.Top;
            btnNavSafes.FlatAppearance.BorderSize = 0;
            btnNavSafes.FlatStyle = FlatStyle.Flat;
            btnNavSafes.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnNavSafes.IconChar = FontAwesome.Sharp.IconChar.Vault;
            btnNavSafes.IconColor = Color.Black;
            btnNavSafes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNavSafes.IconSize = 35;
            btnNavSafes.ImageAlign = ContentAlignment.MiddleRight;
            btnNavSafes.Location = new Point(0, 275);
            btnNavSafes.Name = "btnNavSafes";
            btnNavSafes.Padding = new Padding(0, 0, 15, 0);
            btnNavSafes.Size = new Size(244, 55);
            btnNavSafes.TabIndex = 5;
            btnNavSafes.Text = "الخزن";
            btnNavSafes.TextAlign = ContentAlignment.MiddleRight;
            btnNavSafes.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // btnNavPurchases
            // 
            btnNavPurchases.Dock = DockStyle.Top;
            btnNavPurchases.FlatAppearance.BorderSize = 0;
            btnNavPurchases.FlatStyle = FlatStyle.Flat;
            btnNavPurchases.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnNavPurchases.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
            btnNavPurchases.IconColor = Color.Black;
            btnNavPurchases.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNavPurchases.IconSize = 35;
            btnNavPurchases.ImageAlign = ContentAlignment.MiddleRight;
            btnNavPurchases.Location = new Point(0, 220);
            btnNavPurchases.Name = "btnNavPurchases";
            btnNavPurchases.Padding = new Padding(0, 0, 15, 0);
            btnNavPurchases.Size = new Size(244, 55);
            btnNavPurchases.TabIndex = 6;
            btnNavPurchases.Text = "المشتريات";
            btnNavPurchases.TextAlign = ContentAlignment.MiddleRight;
            btnNavPurchases.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // btnNavExpenses
            // 
            btnNavExpenses.Dock = DockStyle.Top;
            btnNavExpenses.FlatAppearance.BorderSize = 0;
            btnNavExpenses.FlatStyle = FlatStyle.Flat;
            btnNavExpenses.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnNavExpenses.IconChar = FontAwesome.Sharp.IconChar.MoneyBillTransfer;
            btnNavExpenses.IconColor = Color.Black;
            btnNavExpenses.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNavExpenses.IconSize = 35;
            btnNavExpenses.ImageAlign = ContentAlignment.MiddleRight;
            btnNavExpenses.Location = new Point(0, 165);
            btnNavExpenses.Name = "btnNavExpenses";
            btnNavExpenses.Padding = new Padding(0, 0, 15, 0);
            btnNavExpenses.Size = new Size(244, 55);
            btnNavExpenses.TabIndex = 7;
            btnNavExpenses.Text = "المصروفات";
            btnNavExpenses.TextAlign = ContentAlignment.MiddleRight;
            btnNavExpenses.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // btnNavSales
            // 
            btnNavSales.Dock = DockStyle.Top;
            btnNavSales.FlatAppearance.BorderSize = 0;
            btnNavSales.FlatStyle = FlatStyle.Flat;
            btnNavSales.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnNavSales.IconChar = FontAwesome.Sharp.IconChar.Tags;
            btnNavSales.IconColor = Color.Black;
            btnNavSales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNavSales.IconSize = 35;
            btnNavSales.ImageAlign = ContentAlignment.MiddleRight;
            btnNavSales.Location = new Point(0, 110);
            btnNavSales.Name = "btnNavSales";
            btnNavSales.Padding = new Padding(0, 0, 15, 0);
            btnNavSales.Size = new Size(244, 55);
            btnNavSales.TabIndex = 8;
            btnNavSales.Text = "المبيعات";
            btnNavSales.TextAlign = ContentAlignment.MiddleRight;
            btnNavSales.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // btnNavRooms
            // 
            btnNavRooms.Dock = DockStyle.Top;
            btnNavRooms.FlatAppearance.BorderSize = 0;
            btnNavRooms.FlatStyle = FlatStyle.Flat;
            btnNavRooms.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnNavRooms.IconChar = FontAwesome.Sharp.IconChar.Bed;
            btnNavRooms.IconColor = Color.Black;
            btnNavRooms.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNavRooms.IconSize = 35;
            btnNavRooms.ImageAlign = ContentAlignment.MiddleRight;
            btnNavRooms.Location = new Point(0, 55);
            btnNavRooms.Name = "btnNavRooms";
            btnNavRooms.Padding = new Padding(0, 0, 15, 0);
            btnNavRooms.Size = new Size(244, 55);
            btnNavRooms.TabIndex = 9;
            btnNavRooms.Text = "أرباح الغرف";
            btnNavRooms.TextAlign = ContentAlignment.MiddleRight;
            btnNavRooms.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // btnNavServices
            // 
            btnNavServices.Dock = DockStyle.Top;
            btnNavServices.FlatAppearance.BorderSize = 0;
            btnNavServices.FlatStyle = FlatStyle.Flat;
            btnNavServices.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnNavServices.IconChar = FontAwesome.Sharp.IconChar.Spa;
            btnNavServices.IconColor = Color.Black;
            btnNavServices.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNavServices.IconSize = 35;
            btnNavServices.ImageAlign = ContentAlignment.MiddleRight;
            btnNavServices.Location = new Point(0, 0);
            btnNavServices.Name = "btnNavServices";
            btnNavServices.Padding = new Padding(0, 0, 15, 0);
            btnNavServices.Size = new Size(244, 55);
            btnNavServices.TabIndex = 10;
            btnNavServices.Text = "الغرف والخدمات";
            btnNavServices.TextAlign = ContentAlignment.MiddleRight;
            btnNavServices.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // pnlMainContainer
            // 
            pnlMainContainer.BackColor = Color.White;
            pnlMainContainer.Controls.Add(pnlContent);
            pnlMainContainer.Controls.Add(tableLayoutPanel1);
            pnlMainContainer.Controls.Add(panel1);
            pnlMainContainer.Dock = DockStyle.Fill;
            pnlMainContainer.Location = new Point(3, 3);
            pnlMainContainer.Name = "pnlMainContainer";
            pnlMainContainer.Size = new Size(928, 743);
            pnlMainContainer.TabIndex = 1;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 280);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(928, 463);
            pnlContent.TabIndex = 2;
            // 
            // FrmFinancialReports
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(242, 242, 242);
            ClientSize = new Size(1184, 749);
            Controls.Add(mainLayout);
            Name = "FrmFinancialReports";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "التقارير المالية المجمعة";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            pnlTotalRevenue.ResumeLayout(false);
            pnlTotalPurchases.ResumeLayout(false);
            pnlTotalExpenses.ResumeLayout(false);
            pnlNetProfit.ResumeLayout(false);
            pnlTotalEmployeeDues.ResumeLayout(false);
            pnlTotalTrainerDues.ResumeLayout(false);
            pnlTotalGym.ResumeLayout(false);
            pnlTotalCafeteria.ResumeLayout(false);
            mainLayout.ResumeLayout(false);
            pnlSidebar.ResumeLayout(false);
            pnlMainContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEnableDateFilter;
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

        // التغييرات البرمجية المطلوبة للـ MaterialSkin والتبويبات القديمة والجديدة
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;


        // تحويل الأزرار إلى MaterialButton مع الإبقاء على نفس الأسماء
        private MaterialSkin.Controls.MaterialButton btnPrint;
        private MaterialSkin.Controls.MaterialButton btnRefresh;

        private System.Windows.Forms.Label label4;
        private TableLayoutPanel mainLayout;
        private Panel pnlSidebar;
        private Panel pnlMainContainer;
        private Panel pnlContent;
        
        private FontAwesome.Sharp.IconButton btnNavServices;
        private FontAwesome.Sharp.IconButton btnNavRooms;
        private FontAwesome.Sharp.IconButton btnNavSales;
        private FontAwesome.Sharp.IconButton btnNavExpenses;
        private FontAwesome.Sharp.IconButton btnNavPurchases;
        private FontAwesome.Sharp.IconButton btnNavSafes;
        private FontAwesome.Sharp.IconButton btnNavDailyClosing;
        private FontAwesome.Sharp.IconButton btnNavEmployeeExpenses;
        private FontAwesome.Sharp.IconButton btnNavTrainerExpenses;
        private FontAwesome.Sharp.IconButton btnNavGym;
        private FontAwesome.Sharp.IconButton btnNavCafeteria;
        private FontAwesome.Sharp.IconButton btnNavEmployeePerf;
        
        // New Dues Cards
        private MaterialSkin.Controls.MaterialCard pnlTotalEmployeeDues;
        private System.Windows.Forms.Label lblTotalEmployeeDues;
        private System.Windows.Forms.Label labelEmployeeDuesTitle;
        private MaterialSkin.Controls.MaterialCard pnlTotalTrainerDues;
        private System.Windows.Forms.Label lblTotalTrainerDues;
        private System.Windows.Forms.Label labelTrainerDuesTitle;
        private MaterialSkin.Controls.MaterialCard pnlTotalGym;
        private System.Windows.Forms.Label lblTotalGym;
        private System.Windows.Forms.Label labelTotalGymTitle;
        private MaterialSkin.Controls.MaterialCard pnlTotalCafeteria;
        private System.Windows.Forms.Label lblTotalCafeteria;
        private System.Windows.Forms.Label labelTotalCafeteriaTitle;
    }
}
