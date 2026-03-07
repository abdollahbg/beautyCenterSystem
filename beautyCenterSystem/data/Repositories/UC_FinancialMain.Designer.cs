namespace beautyCenterSystem.data.Repositories
{
    partial class UC_FinancialMain
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
            btnFinReports = new FontAwesome.Sharp.IconButton();
            btnPurchases = new FontAwesome.Sharp.IconButton();
            btnExpenses = new FontAwesome.Sharp.IconButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnManageSafes = new FontAwesome.Sharp.IconButton();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnFinReports
            // 
            btnFinReports.Dock = DockStyle.Fill;
            btnFinReports.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnFinReports.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            btnFinReports.IconColor = Color.Black;
            btnFinReports.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFinReports.IconSize = 100;
            btnFinReports.Location = new Point(20, 370);
            btnFinReports.Margin = new Padding(20);
            btnFinReports.Name = "btnFinReports";
            btnFinReports.Size = new Size(460, 310);
            btnFinReports.TabIndex = 1;
            btnFinReports.Text = "التقارير المالية";
            btnFinReports.TextImageRelation = TextImageRelation.TextAboveImage;
            btnFinReports.UseVisualStyleBackColor = true;
            // 
            // btnPurchases
            // 
            btnPurchases.Dock = DockStyle.Fill;
            btnPurchases.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnPurchases.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
            btnPurchases.IconColor = Color.Black;
            btnPurchases.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPurchases.IconSize = 100;
            btnPurchases.Location = new Point(20, 20);
            btnPurchases.Margin = new Padding(20);
            btnPurchases.Name = "btnPurchases";
            btnPurchases.Size = new Size(460, 310);
            btnPurchases.TabIndex = 2;
            btnPurchases.Text = "المشتريات";
            btnPurchases.TextImageRelation = TextImageRelation.TextAboveImage;
            btnPurchases.UseVisualStyleBackColor = true;
            // 
            // btnExpenses
            // 
            btnExpenses.Dock = DockStyle.Fill;
            btnExpenses.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnExpenses.IconChar = FontAwesome.Sharp.IconChar.MoneyBillTransfer;
            btnExpenses.IconColor = Color.Black;
            btnExpenses.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnExpenses.IconSize = 100;
            btnExpenses.Location = new Point(520, 370);
            btnExpenses.Margin = new Padding(20);
            btnExpenses.Name = "btnExpenses";
            btnExpenses.Size = new Size(460, 310);
            btnExpenses.TabIndex = 3;
            btnExpenses.Text = "المصروفات";
            btnExpenses.TextImageRelation = TextImageRelation.TextAboveImage;
            btnExpenses.UseVisualStyleBackColor = true;
            btnExpenses.Click += btnExpenses_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnManageSafes, 1, 0);
            tableLayoutPanel1.Controls.Add(btnPurchases, 0, 0);
            tableLayoutPanel1.Controls.Add(btnFinReports, 0, 1);
            tableLayoutPanel1.Controls.Add(btnExpenses, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1000, 700);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // btnManageSafes
            // 
            btnManageSafes.Dock = DockStyle.Fill;
            btnManageSafes.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageSafes.IconChar = FontAwesome.Sharp.IconChar.Vault;
            btnManageSafes.IconColor = Color.Black;
            btnManageSafes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnManageSafes.IconSize = 100;
            btnManageSafes.Location = new Point(520, 20);
            btnManageSafes.Margin = new Padding(20);
            btnManageSafes.Name = "btnManageSafes";
            btnManageSafes.Size = new Size(460, 310);
            btnManageSafes.TabIndex = 4;
            btnManageSafes.Text = "إدارة الخزينة";
            btnManageSafes.TextImageRelation = TextImageRelation.TextAboveImage;
            btnManageSafes.UseVisualStyleBackColor = true;
            // 
            // UC_FinancialMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UC_FinancialMain";
            Size = new Size(1000, 700);
            Load += UC_FinancialMain_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private FontAwesome.Sharp.IconButton btnFinReports;
        private FontAwesome.Sharp.IconButton btnPurchases;
        private FontAwesome.Sharp.IconButton btnExpenses;
        private TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnManageSafes;
    }
}
