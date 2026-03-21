namespace beautyCenterSystem.data.Repositories
{
    partial class frmSafes
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
            components = new System.ComponentModel.Container();
            TapControl1 = new TabControl();
            tpSafes = new TabPage();
            dgvSafes = new DataGridView();
            panel1 = new Panel();
            btnAddSafe = new Button();
            tpTransfers = new TabPage();
            dgvTransfers = new DataGridView();
            panel2 = new Panel();
            txtAmount = new TextBox();
            btnTransfer = new FontAwesome.Sharp.IconButton();
            label5 = new Label();
            cmbToSafe = new MaterialSearchableCombo();
            label6 = new Label();
            lblFromBalance = new Label();
            cmbFromSafe = new MaterialSearchableCombo();
            label4 = new Label();
            tpFinancialMapping = new TabPage();
            label3 = new Label();
            iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            btnSaveMapping = new Button();
            cmbCardSafe = new MaterialSearchableCombo();
            cmbCashSafe = new MaterialSearchableCombo();
            label2 = new Label();
            label1 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            TapControl1.SuspendLayout();
            tpSafes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSafes).BeginInit();
            panel1.SuspendLayout();
            tpTransfers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransfers).BeginInit();
            panel2.SuspendLayout();
            tpFinancialMapping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // TapControl1
            // 
            TapControl1.Controls.Add(tpSafes);
            TapControl1.Controls.Add(tpTransfers);
            TapControl1.Controls.Add(tpFinancialMapping);
            TapControl1.Dock = DockStyle.Fill;
            TapControl1.Location = new Point(0, 0);
            TapControl1.Name = "TapControl1";
            TapControl1.RightToLeft = RightToLeft.Yes;
            TapControl1.RightToLeftLayout = true;
            TapControl1.SelectedIndex = 0;
            TapControl1.Size = new Size(984, 661);
            TapControl1.TabIndex = 0;
            // 
            // tpSafes
            // 
            tpSafes.Controls.Add(dgvSafes);
            tpSafes.Controls.Add(panel1);
            tpSafes.Location = new Point(4, 24);
            tpSafes.Name = "tpSafes";
            tpSafes.Padding = new Padding(10);
            tpSafes.Size = new Size(976, 633);
            tpSafes.TabIndex = 0;
            tpSafes.Text = "أرصدة الخزنات";
            tpSafes.UseVisualStyleBackColor = true;
            // 
            // dgvSafes
            // 
            dgvSafes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSafes.Dock = DockStyle.Fill;
            dgvSafes.Location = new Point(10, 80);
            dgvSafes.Name = "dgvSafes";
            dgvSafes.RightToLeft = RightToLeft.Yes;
            dgvSafes.Size = new Size(956, 543);
            dgvSafes.TabIndex = 3;
            dgvSafes.CellFormatting += dgvSafes_CellFormatting;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAddSafe);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(956, 70);
            panel1.TabIndex = 2;
            // 
            // btnAddSafe
            // 
            btnAddSafe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddSafe.ForeColor = Color.Black;
            btnAddSafe.Location = new Point(819, 11);
            btnAddSafe.Name = "btnAddSafe";
            btnAddSafe.Size = new Size(134, 47);
            btnAddSafe.TabIndex = 1;
            btnAddSafe.Text = "اضافة خزنة جديدة";
            btnAddSafe.UseVisualStyleBackColor = true;
            btnAddSafe.Click += btnAddSafe_Click;
            // 
            // tpTransfers
            // 
            tpTransfers.Controls.Add(dgvTransfers);
            tpTransfers.Controls.Add(panel2);
            tpTransfers.Location = new Point(4, 24);
            tpTransfers.Name = "tpTransfers";
            tpTransfers.Padding = new Padding(3);
            tpTransfers.Size = new Size(976, 633);
            tpTransfers.TabIndex = 1;
            tpTransfers.Text = "التحويل بين الخزنات";
            tpTransfers.UseVisualStyleBackColor = true;
            // 
            // dgvTransfers
            // 
            dgvTransfers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransfers.Dock = DockStyle.Fill;
            dgvTransfers.Location = new Point(3, 209);
            dgvTransfers.Name = "dgvTransfers";
            dgvTransfers.RightToLeft = RightToLeft.No;
            dgvTransfers.Size = new Size(970, 421);
            dgvTransfers.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtAmount);
            panel2.Controls.Add(btnTransfer);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(cmbToSafe);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(lblFromBalance);
            panel2.Controls.Add(cmbFromSafe);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(970, 206);
            panel2.TabIndex = 0;
            // 
            // txtAmount
            // 
            txtAmount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAmount.Font = new Font("Segoe UI", 16F);
            txtAmount.Location = new Point(617, 148);
            txtAmount.Multiline = true;
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(210, 45);
            txtAmount.TabIndex = 8;
            txtAmount.TextChanged += txtAmount_TextChanged;
            txtAmount.KeyPress += txtAmount_KeyPress;
            // 
            // btnTransfer
            // 
            btnTransfer.Font = new Font("Segoe UI", 12F);
            btnTransfer.IconChar = FontAwesome.Sharp.IconChar.ExchangeAlt;
            btnTransfer.IconColor = Color.Black;
            btnTransfer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTransfer.IconSize = 35;
            btnTransfer.Location = new Point(34, 77);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.RightToLeft = RightToLeft.No;
            btnTransfer.Size = new Size(186, 58);
            btnTransfer.TabIndex = 7;
            btnTransfer.Text = "تحويل";
            btnTransfer.TextAlign = ContentAlignment.MiddleRight;
            btnTransfer.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTransfer.UseVisualStyleBackColor = true;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(897, 159);
            label5.Name = "label5";
            label5.Size = new Size(57, 25);
            label5.TabIndex = 5;
            label5.Text = "المبلغ";
            // 
            // cmbToSafe
            // 
            cmbToSafe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbToSafe.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbToSafe.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbToSafe.BackColor = Color.White;
            cmbToSafe.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbToSafe.FlatStyle = FlatStyle.Flat;
            cmbToSafe.Font = new Font("Segoe UI", 14F);
            cmbToSafe.FormattingEnabled = true;
            cmbToSafe.Location = new Point(644, 90);
            cmbToSafe.Name = "cmbToSafe";
            cmbToSafe.Size = new Size(183, 33);
            cmbToSafe.TabIndex = 4;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F);
            label6.Location = new Point(869, 90);
            label6.Name = "label6";
            label6.Size = new Size(88, 25);
            label6.TabIndex = 3;
            label6.Text = "إلى الخزنة";
            // 
            // lblFromBalance
            // 
            lblFromBalance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFromBalance.AutoSize = true;
            lblFromBalance.Font = new Font("Segoe UI", 14F);
            lblFromBalance.ForeColor = Color.Blue;
            lblFromBalance.Location = new Point(474, 22);
            lblFromBalance.Name = "lblFromBalance";
            lblFromBalance.Size = new Size(46, 25);
            lblFromBalance.TabIndex = 2;
            lblFromBalance.Text = "0.00";
            // 
            // cmbFromSafe
            // 
            cmbFromSafe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbFromSafe.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbFromSafe.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbFromSafe.BackColor = Color.White;
            cmbFromSafe.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFromSafe.FlatStyle = FlatStyle.Flat;
            cmbFromSafe.Font = new Font("Segoe UI", 14F);
            cmbFromSafe.FormattingEnabled = true;
            cmbFromSafe.Location = new Point(644, 19);
            cmbFromSafe.Name = "cmbFromSafe";
            cmbFromSafe.Size = new Size(183, 33);
            cmbFromSafe.TabIndex = 1;
            cmbFromSafe.SelectedIndexChanged += cmbFromSafe_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(869, 19);
            label4.Name = "label4";
            label4.Size = new Size(85, 25);
            label4.TabIndex = 0;
            label4.Text = "من الخزنة";
            // 
            // tpFinancialMapping
            // 
            tpFinancialMapping.Controls.Add(label3);
            tpFinancialMapping.Controls.Add(iconPictureBox2);
            tpFinancialMapping.Controls.Add(iconPictureBox1);
            tpFinancialMapping.Controls.Add(btnSaveMapping);
            tpFinancialMapping.Controls.Add(cmbCardSafe);
            tpFinancialMapping.Controls.Add(cmbCashSafe);
            tpFinancialMapping.Controls.Add(label2);
            tpFinancialMapping.Controls.Add(label1);
            tpFinancialMapping.Location = new Point(4, 24);
            tpFinancialMapping.Name = "tpFinancialMapping";
            tpFinancialMapping.Padding = new Padding(3);
            tpFinancialMapping.Size = new Size(976, 633);
            tpFinancialMapping.TabIndex = 2;
            tpFinancialMapping.Text = "إعدادات توجيه الأموال";
            tpFinancialMapping.UseVisualStyleBackColor = true;
            tpFinancialMapping.Click += tpFinancialMapping_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Location = new Point(244, 428);
            label3.Name = "label3";
            label3.Size = new Size(724, 30);
            label3.TabIndex = 7;
            label3.Text = "سيقوم النظام تلقائياً بتحويل الأموال للخزنة المختارة بناءً على نوع الدفع في الحجز";
            // 
            // iconPictureBox2
            // 
            iconPictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconPictureBox2.BackColor = Color.Transparent;
            iconPictureBox2.ForeColor = SystemColors.ControlText;
            iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            iconPictureBox2.IconColor = SystemColors.ControlText;
            iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox2.IconSize = 52;
            iconPictureBox2.Location = new Point(651, 183);
            iconPictureBox2.Name = "iconPictureBox2";
            iconPictureBox2.Size = new Size(52, 52);
            iconPictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            iconPictureBox2.TabIndex = 6;
            iconPictureBox2.TabStop = false;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconPictureBox1.BackColor = Color.Transparent;
            iconPictureBox1.ForeColor = SystemColors.ControlText;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            iconPictureBox1.IconColor = SystemColors.ControlText;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 52;
            iconPictureBox1.Location = new Point(657, 59);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(52, 52);
            iconPictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            iconPictureBox1.TabIndex = 5;
            iconPictureBox1.TabStop = false;
            // 
            // btnSaveMapping
            // 
            btnSaveMapping.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveMapping.Location = new Point(656, 333);
            btnSaveMapping.Name = "btnSaveMapping";
            btnSaveMapping.Size = new Size(317, 48);
            btnSaveMapping.TabIndex = 4;
            btnSaveMapping.Text = "حفظ الإعدادات";
            btnSaveMapping.UseVisualStyleBackColor = true;
            btnSaveMapping.Click += btnSaveMapping_Click;
            // 
            // cmbCardSafe
            // 
            cmbCardSafe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbCardSafe.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCardSafe.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCardSafe.BackColor = Color.White;
            cmbCardSafe.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCardSafe.FlatStyle = FlatStyle.Flat;
            cmbCardSafe.Font = new Font("Segoe UI", 18F);
            cmbCardSafe.FormattingEnabled = true;
            cmbCardSafe.Location = new Point(348, 183);
            cmbCardSafe.Name = "cmbCardSafe";
            cmbCardSafe.RightToLeft = RightToLeft.No;
            cmbCardSafe.Size = new Size(254, 40);
            cmbCardSafe.TabIndex = 3;
            // 
            // cmbCashSafe
            // 
            cmbCashSafe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbCashSafe.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCashSafe.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCashSafe.BackColor = Color.White;
            cmbCashSafe.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCashSafe.FlatStyle = FlatStyle.Flat;
            cmbCashSafe.Font = new Font("Segoe UI", 18F);
            cmbCashSafe.FormattingEnabled = true;
            cmbCashSafe.Location = new Point(348, 59);
            cmbCashSafe.Name = "cmbCashSafe";
            cmbCashSafe.RightToLeft = RightToLeft.No;
            cmbCashSafe.Size = new Size(254, 40);
            cmbCashSafe.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label2.Location = new Point(709, 183);
            label2.Name = "label2";
            label2.Size = new Size(259, 37);
            label2.TabIndex = 1;
            label2.Text = "توجيه الدفع بالبطاقة  ";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(742, 56);
            label1.Name = "label1";
            label1.Size = new Size(226, 37);
            label1.TabIndex = 0;
            label1.Text = "توجيه الدفع النقدي";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // frmSafes
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(984, 661);
            Controls.Add(TapControl1);
            Name = "frmSafes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إدارة الخزنات";
            WindowState = FormWindowState.Maximized;
            Load += frmSafes_Load;
            TapControl1.ResumeLayout(false);
            tpSafes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSafes).EndInit();
            panel1.ResumeLayout(false);
            tpTransfers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTransfers).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tpFinancialMapping.ResumeLayout(false);
            tpFinancialMapping.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl TapControl1;
        private TabPage tpSafes;
        private TabPage tpTransfers;
        private Panel panel1;
        private Button btnAddSafe;
        private DataGridView dgvSafes;
        private TabPage tpFinancialMapping;
        private MaterialSearchableCombo cmbCardSafe;
        private MaterialSearchableCombo cmbCashSafe;
        private Label label2;
        private Label label1;
        private Label label3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Button btnSaveMapping;
        private Panel panel2;
        private Label lblFromBalance;
        private MaterialSearchableCombo cmbFromSafe;
        private Label label4;
        private Label label5;
        private MaterialSearchableCombo cmbToSafe;
        private Label label6;
        private FontAwesome.Sharp.IconButton btnTransfer;
        private DataGridView dgvTransfers;
        private TextBox txtAmount;
        private ContextMenuStrip contextMenuStrip1;
    }
}