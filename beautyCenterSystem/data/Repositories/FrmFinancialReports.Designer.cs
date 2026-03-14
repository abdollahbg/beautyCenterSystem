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
            btnRefresh = new Button();
            btnPrint = new Button();
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
            pnlTotalRevenue = new MaterialSkin.Controls.MaterialCard();
            lblTotalRevenue = new Label();
            label10 = new Label();
            pnlTotalExpenses = new MaterialSkin.Controls.MaterialCard();
            lblTotalExpenses = new Label();
            label8 = new Label();
            splitMain = new SplitContainer();
            tableLayoutPanel2 = new TableLayoutPanel();
            dgvRoomsSummary = new DataGridView();
            dgvServicesSummary = new DataGridView();
            tabcontrol = new TabControl();
            tpExpenses = new TabPage();
            dgvExpensesDetails = new DataGridView();
            tpPurchases = new TabPage();
            dgvPurchasesDetails = new DataGridView();
            tpSafes = new TabPage();
            dgvSafesBalances = new DataGridView();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlNetProfit.SuspendLayout();
            pnlTotalPurchases.SuspendLayout();
            pnlTotalRevenue.SuspendLayout();
            pnlTotalExpenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoomsSummary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvServicesSummary).BeginInit();
            tabcontrol.SuspendLayout();
            tpExpenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpensesDetails).BeginInit();
            tpPurchases.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPurchasesDetails).BeginInit();
            tpSafes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSafesBalances).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
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
            panel1.Size = new Size(1184, 63);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label4.Location = new Point(1013, 20);
            label4.Name = "label4";
            label4.Size = new Size(120, 25);
            label4.TabIndex = 7;
            label4.Text = "التقارير المالية";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(75, 14);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(127, 38);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "تحديث البيانات";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.Top;
            btnPrint.Location = new Point(339, 14);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(127, 38);
            btnPrint.TabIndex = 5;
            btnPrint.Text = "طباعة التقارير";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(833, 37);
            label2.Name = "label2";
            label2.Size = new Size(24, 15);
            label2.TabIndex = 3;
            label2.Text = "إلى";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(833, 9);
            label1.Name = "label1";
            label1.Size = new Size(22, 15);
            label1.TabIndex = 2;
            label1.Text = "من";
            // 
            // dtpTo
            // 
            dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpTo.Location = new Point(609, 37);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(200, 23);
            dtpTo.TabIndex = 1;
            // 
            // dtpFrom
            // 
            dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFrom.Location = new Point(609, 3);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(200, 23);
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
            tableLayoutPanel1.Controls.Add(pnlTotalRevenue, 3, 0);
            tableLayoutPanel1.Controls.Add(pnlTotalExpenses, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 63);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1184, 100);
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
            pnlNetProfit.Location = new Point(5, 5);
            pnlNetProfit.Margin = new Padding(5);
            pnlNetProfit.MouseState = MaterialSkin.MouseState.HOVER;
            pnlNetProfit.Name = "pnlNetProfit";
            pnlNetProfit.Padding = new Padding(5);
            pnlNetProfit.Size = new Size(286, 90);
            pnlNetProfit.TabIndex = 5;
            // 
            // lblNetProfit
            // 
            lblNetProfit.AutoSize = true;
            lblNetProfit.Font = new Font("Segoe UI", 12F);
            lblNetProfit.ForeColor = Color.Green;
            lblNetProfit.Location = new Point(128, 54);
            lblNetProfit.Name = "lblNetProfit";
            lblNetProfit.Size = new Size(40, 21);
            lblNetProfit.TabIndex = 3;
            lblNetProfit.Text = "0.00";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label6.Location = new Point(89, 15);
            label6.Name = "label6";
            label6.Size = new Size(109, 28);
            label6.TabIndex = 2;
            label6.Text = "صافي الربح";
            // 
            // pnlTotalPurchases
            // 
            pnlTotalPurchases.BackColor = Color.FromArgb(255, 255, 255);
            pnlTotalPurchases.Controls.Add(lblTotalPurchases);
            pnlTotalPurchases.Controls.Add(label3);
            pnlTotalPurchases.Depth = 0;
            pnlTotalPurchases.Dock = DockStyle.Fill;
            pnlTotalPurchases.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlTotalPurchases.Location = new Point(301, 5);
            pnlTotalPurchases.Margin = new Padding(5);
            pnlTotalPurchases.MouseState = MaterialSkin.MouseState.HOVER;
            pnlTotalPurchases.Name = "pnlTotalPurchases";
            pnlTotalPurchases.Padding = new Padding(5);
            pnlTotalPurchases.Size = new Size(286, 90);
            pnlTotalPurchases.TabIndex = 4;
            // 
            // lblTotalPurchases
            // 
            lblTotalPurchases.AutoSize = true;
            lblTotalPurchases.Font = new Font("Segoe UI", 12F);
            lblTotalPurchases.ForeColor = Color.FromArgb(255, 128, 128);
            lblTotalPurchases.Location = new Point(125, 54);
            lblTotalPurchases.Name = "lblTotalPurchases";
            lblTotalPurchases.Size = new Size(40, 21);
            lblTotalPurchases.TabIndex = 4;
            lblTotalPurchases.Text = "0.00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.Location = new Point(61, 15);
            label3.Name = "label3";
            label3.Size = new Size(164, 28);
            label3.TabIndex = 0;
            label3.Text = "إجمالي المشتريات";
            // 
            // pnlTotalRevenue
            // 
            pnlTotalRevenue.BackColor = Color.FromArgb(255, 255, 255);
            pnlTotalRevenue.Controls.Add(lblTotalRevenue);
            pnlTotalRevenue.Controls.Add(label10);
            pnlTotalRevenue.Depth = 0;
            pnlTotalRevenue.Dock = DockStyle.Fill;
            pnlTotalRevenue.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlTotalRevenue.Location = new Point(893, 5);
            pnlTotalRevenue.Margin = new Padding(5);
            pnlTotalRevenue.MouseState = MaterialSkin.MouseState.HOVER;
            pnlTotalRevenue.Name = "pnlTotalRevenue";
            pnlTotalRevenue.Padding = new Padding(5);
            pnlTotalRevenue.Size = new Size(286, 90);
            pnlTotalRevenue.TabIndex = 3;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Segoe UI", 12F);
            lblTotalRevenue.ForeColor = Color.Blue;
            lblTotalRevenue.Location = new Point(134, 54);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(40, 21);
            lblTotalRevenue.TabIndex = 3;
            lblTotalRevenue.Text = "0.00";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label10.Location = new Point(81, 10);
            label10.Name = "label10";
            label10.Size = new Size(144, 28);
            label10.TabIndex = 2;
            label10.Text = "إجمالي الإيرادات";
            // 
            // pnlTotalExpenses
            // 
            pnlTotalExpenses.BackColor = Color.FromArgb(255, 255, 255);
            pnlTotalExpenses.Controls.Add(lblTotalExpenses);
            pnlTotalExpenses.Controls.Add(label8);
            pnlTotalExpenses.Depth = 0;
            pnlTotalExpenses.Dock = DockStyle.Fill;
            pnlTotalExpenses.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlTotalExpenses.Location = new Point(597, 5);
            pnlTotalExpenses.Margin = new Padding(5);
            pnlTotalExpenses.MouseState = MaterialSkin.MouseState.HOVER;
            pnlTotalExpenses.Name = "pnlTotalExpenses";
            pnlTotalExpenses.Padding = new Padding(5);
            pnlTotalExpenses.Size = new Size(286, 90);
            pnlTotalExpenses.TabIndex = 0;
            // 
            // lblTotalExpenses
            // 
            lblTotalExpenses.AutoSize = true;
            lblTotalExpenses.Font = new Font("Segoe UI", 12F);
            lblTotalExpenses.ForeColor = Color.FromArgb(255, 128, 0);
            lblTotalExpenses.Location = new Point(129, 54);
            lblTotalExpenses.Name = "lblTotalExpenses";
            lblTotalExpenses.Size = new Size(40, 21);
            lblTotalExpenses.TabIndex = 4;
            lblTotalExpenses.Text = "0.00";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label8.Location = new Point(60, 10);
            label8.Name = "label8";
            label8.Size = new Size(167, 28);
            label8.TabIndex = 2;
            label8.Text = "إجمالي المصروفات";
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(0, 163);
            splitMain.Name = "splitMain";
            splitMain.Orientation = Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(tableLayoutPanel2);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(tabcontrol);
            splitMain.Size = new Size(1184, 586);
            splitMain.SplitterDistance = 337;
            splitMain.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoScroll = true;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel2.Controls.Add(dgvRoomsSummary, 0, 0);
            tableLayoutPanel2.Controls.Add(dgvServicesSummary, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(10);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(15);
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tableLayoutPanel2.Size = new Size(1184, 337);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // dgvRoomsSummary
            // 
            dgvRoomsSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoomsSummary.Dock = DockStyle.Fill;
            dgvRoomsSummary.Location = new Point(18, 18);
            dgvRoomsSummary.Name = "dgvRoomsSummary";
            dgvRoomsSummary.RightToLeft = RightToLeft.Yes;
            dgvRoomsSummary.Size = new Size(448, 194);
            dgvRoomsSummary.TabIndex = 2;
            // 
            // dgvServicesSummary
            // 
            dgvServicesSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServicesSummary.Dock = DockStyle.Fill;
            dgvServicesSummary.Location = new Point(18, 218);
            dgvServicesSummary.Name = "dgvServicesSummary";
            dgvServicesSummary.RightToLeft = RightToLeft.Yes;
            dgvServicesSummary.Size = new Size(448, 194);
            dgvServicesSummary.TabIndex = 3;
            // 
            // tabcontrol
            // 
            tabcontrol.Controls.Add(tpExpenses);
            tabcontrol.Controls.Add(tpPurchases);
            tabcontrol.Controls.Add(tpSafes);
            tabcontrol.Dock = DockStyle.Fill;
            tabcontrol.Location = new Point(0, 0);
            tabcontrol.Name = "tabcontrol";
            tabcontrol.RightToLeft = RightToLeft.Yes;
            tabcontrol.RightToLeftLayout = true;
            tabcontrol.SelectedIndex = 0;
            tabcontrol.Size = new Size(1184, 245);
            tabcontrol.TabIndex = 0;
            // 
            // tpExpenses
            // 
            tpExpenses.Controls.Add(dgvExpensesDetails);
            tpExpenses.Location = new Point(4, 24);
            tpExpenses.Name = "tpExpenses";
            tpExpenses.Padding = new Padding(3);
            tpExpenses.Size = new Size(1176, 217);
            tpExpenses.TabIndex = 0;
            tpExpenses.Text = "تفاصيل المصروفات";
            tpExpenses.UseVisualStyleBackColor = true;
            // 
            // dgvExpensesDetails
            // 
            dgvExpensesDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpensesDetails.Dock = DockStyle.Fill;
            dgvExpensesDetails.Location = new Point(3, 3);
            dgvExpensesDetails.Name = "dgvExpensesDetails";
            dgvExpensesDetails.Size = new Size(1170, 211);
            dgvExpensesDetails.TabIndex = 0;
            // 
            // tpPurchases
            // 
            tpPurchases.Controls.Add(dgvPurchasesDetails);
            tpPurchases.Location = new Point(4, 24);
            tpPurchases.Name = "tpPurchases";
            tpPurchases.Padding = new Padding(3);
            tpPurchases.Size = new Size(1176, 217);
            tpPurchases.TabIndex = 1;
            tpPurchases.Text = "تفاصيل المشتريات";
            tpPurchases.UseVisualStyleBackColor = true;
            // 
            // dgvPurchasesDetails
            // 
            dgvPurchasesDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPurchasesDetails.Dock = DockStyle.Fill;
            dgvPurchasesDetails.Location = new Point(3, 3);
            dgvPurchasesDetails.Name = "dgvPurchasesDetails";
            dgvPurchasesDetails.Size = new Size(1170, 211);
            dgvPurchasesDetails.TabIndex = 1;
            // 
            // tpSafes
            // 
            tpSafes.Controls.Add(dgvSafesBalances);
            tpSafes.Location = new Point(4, 24);
            tpSafes.Name = "tpSafes";
            tpSafes.Padding = new Padding(3);
            tpSafes.Size = new Size(1176, 217);
            tpSafes.TabIndex = 2;
            tpSafes.Text = "أرصدة الخزائن الحالية";
            tpSafes.UseVisualStyleBackColor = true;
            // 
            // dgvSafesBalances
            // 
            dgvSafesBalances.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSafesBalances.Dock = DockStyle.Fill;
            dgvSafesBalances.Location = new Point(3, 3);
            dgvSafesBalances.Name = "dgvSafesBalances";
            dgvSafesBalances.Size = new Size(1170, 211);
            dgvSafesBalances.TabIndex = 2;
            // 
            // FrmFinancialReports
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            ClientSize = new Size(1184, 749);
            Controls.Add(splitMain);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Name = "FrmFinancialReports";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmFinancialReports";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            pnlNetProfit.ResumeLayout(false);
            pnlNetProfit.PerformLayout();
            pnlTotalPurchases.ResumeLayout(false);
            pnlTotalPurchases.PerformLayout();
            pnlTotalRevenue.ResumeLayout(false);
            pnlTotalRevenue.PerformLayout();
            pnlTotalExpenses.ResumeLayout(false);
            pnlTotalExpenses.PerformLayout();
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRoomsSummary).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvServicesSummary).EndInit();
            tabcontrol.ResumeLayout(false);
            tpExpenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExpensesDetails).EndInit();
            tpPurchases.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPurchasesDetails).EndInit();
            tpSafes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSafesBalances).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpTo;
        private DateTimePicker dtpFrom;
        private TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialCard materialCard4;
        private MaterialSkin.Controls.MaterialCard materialCard3;
        private MaterialSkin.Controls.MaterialCard pnlTotalExpenses;
        private MaterialSkin.Controls.MaterialCard pnlNetProfit;
        private MaterialSkin.Controls.MaterialCard pnlTotalPurchases;
        private MaterialSkin.Controls.MaterialCard pnlTotalRevenue;
        private Label lblNetProfit;
        private Label label6;
        private Label label3;
        private Label lblTotalRevenue;
        private Label label10;
        private Label label8;
        private Label lblTotalPurchases;
        private Label lblTotalExpenses;
        private SplitContainer splitMain;
        private TabControl tabcontrol;
        private TabPage tpExpenses;
        private TabPage tpPurchases;
        private TabPage tpSafes;
        private TableLayoutPanel tableLayoutPanel2;
        private DataGridView dgvRoomsSummary;
        private DataGridView dgvServicesSummary;
        private Button btnPrint;
        private Button btnRefresh;
        private DataGridView dgvExpensesDetails;
        private DataGridView dgvPurchasesDetails;
        private DataGridView dgvSafesBalances;
        private Label label4;
    }
}