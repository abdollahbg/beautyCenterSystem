namespace beautyCenterSystem.data.Repositories
{
    partial class frmPurchases
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
            panel1 = new Panel();
            btnPrintInvoice = new Button();
            groupBox2 = new GroupBox();
            label9 = new Label();
            dtpFilterDate = new DateTimePicker();
            txtSearchSupplier = new MaterialSkin.Controls.MaterialTextBox2();
            groupBox1 = new GroupBox();
            label5 = new Label();
            cmbSafes = new MaterialSearchableCombo();
            btnNewInvoice = new Button();
            txtSupplierName = new TextBox();
            txtNotes = new TextBox();
            label3 = new Label();
            label2 = new Label();
            splitContainer1 = new SplitContainer();
            dgvPurchases = new DataGridView();
            splitContainer2 = new SplitContainer();
            dgvPurchaseDetails = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            tsmiDeleteDetail = new ToolStripMenuItem();
            lblTotalItem = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            btnAddItem = new Button();
            numPrice = new NumericUpDown();
            numQty = new NumericUpDown();
            cmbMaterials = new MaterialSearchableCombo();
            label1 = new Label();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPurchases).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseDetails).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnPrintInvoice);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(984, 155);
            panel1.TabIndex = 0;
            // 
            // btnPrintInvoice
            // 
            btnPrintInvoice.Location = new Point(3, 11);
            btnPrintInvoice.Name = "btnPrintInvoice";
            btnPrintInvoice.Size = new Size(86, 28);
            btnPrintInvoice.TabIndex = 10;
            btnPrintInvoice.Text = "طباعة";
            btnPrintInvoice.UseVisualStyleBackColor = true;
            btnPrintInvoice.Click += btnPrintInvoice_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(dtpFilterDate);
            groupBox2.Controls.Add(txtSearchSupplier);
            groupBox2.Dock = DockStyle.Right;
            groupBox2.Location = new Point(95, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.RightToLeft = RightToLeft.Yes;
            groupBox2.Size = new Size(405, 155);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "الفلترة";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(361, 100);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 9;
            label9.Text = "التاريخ";
            // 
            // dtpFilterDate
            // 
            dtpFilterDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFilterDate.Location = new Point(139, 94);
            dtpFilterDate.Name = "dtpFilterDate";
            dtpFilterDate.Size = new Size(200, 23);
            dtpFilterDate.TabIndex = 8;
            dtpFilterDate.ValueChanged += dtpFilterDate_ValueChanged;
            // 
            // txtSearchSupplier
            // 
            txtSearchSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearchSupplier.AnimateReadOnly = false;
            txtSearchSupplier.AutoCompleteMode = AutoCompleteMode.None;
            txtSearchSupplier.AutoCompleteSource = AutoCompleteSource.None;
            txtSearchSupplier.BackgroundImageLayout = ImageLayout.None;
            txtSearchSupplier.CharacterCasing = CharacterCasing.Normal;
            txtSearchSupplier.Depth = 0;
            txtSearchSupplier.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSearchSupplier.HideSelection = true;
            txtSearchSupplier.Hint = "البحث بإسم المورد";
            txtSearchSupplier.LeadingIcon = null;
            txtSearchSupplier.Location = new Point(95, 17);
            txtSearchSupplier.MaxLength = 32767;
            txtSearchSupplier.MouseState = MaterialSkin.MouseState.OUT;
            txtSearchSupplier.Name = "txtSearchSupplier";
            txtSearchSupplier.PasswordChar = '\0';
            txtSearchSupplier.PrefixSuffixText = null;
            txtSearchSupplier.ReadOnly = false;
            txtSearchSupplier.RightToLeft = RightToLeft.Yes;
            txtSearchSupplier.SelectedText = "";
            txtSearchSupplier.SelectionLength = 0;
            txtSearchSupplier.SelectionStart = 0;
            txtSearchSupplier.ShortcutsEnabled = true;
            txtSearchSupplier.Size = new Size(306, 48);
            txtSearchSupplier.TabIndex = 7;
            txtSearchSupplier.TabStop = false;
            txtSearchSupplier.TextAlign = HorizontalAlignment.Right;
            txtSearchSupplier.TrailingIcon = null;
            txtSearchSupplier.UseSystemPasswordChar = false;
            txtSearchSupplier.TextChanged += txtSearchSupplier_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cmbSafes);
            groupBox1.Controls.Add(btnNewInvoice);
            groupBox1.Controls.Add(txtSupplierName);
            groupBox1.Controls.Add(txtNotes);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Dock = DockStyle.Right;
            groupBox1.Location = new Point(500, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.RightToLeft = RightToLeft.Yes;
            groupBox1.Size = new Size(484, 155);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "إضافة فاتورة جديدة";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(199, 24);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 16;
            label5.Text = "الخزنة";
            // 
            // cmbSafes
            // 
            cmbSafes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbSafes.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbSafes.BackColor = Color.White;
            cmbSafes.FlatStyle = FlatStyle.Flat;
            cmbSafes.Font = new Font("Segoe UI", 11F);
            cmbSafes.FormattingEnabled = true;
            cmbSafes.Location = new Point(72, 17);
            cmbSafes.Name = "cmbSafes";
            cmbSafes.Size = new Size(121, 28);
            cmbSafes.TabIndex = 15;
            // 
            // btnNewInvoice
            // 
            btnNewInvoice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNewInvoice.Location = new Point(101, 81);
            btnNewInvoice.Name = "btnNewInvoice";
            btnNewInvoice.Size = new Size(101, 36);
            btnNewInvoice.TabIndex = 14;
            btnNewInvoice.Text = "إضافة";
            btnNewInvoice.UseVisualStyleBackColor = true;
            btnNewInvoice.Click += btnNewInvoice_Click;
            // 
            // txtSupplierName
            // 
            txtSupplierName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSupplierName.Location = new Point(269, 21);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.RightToLeft = RightToLeft.Yes;
            txtSupplierName.Size = new Size(137, 23);
            txtSupplierName.TabIndex = 8;
            // 
            // txtNotes
            // 
            txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNotes.Location = new Point(269, 62);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.RightToLeft = RightToLeft.Yes;
            txtNotes.Size = new Size(137, 55);
            txtNotes.TabIndex = 9;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(412, 81);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 11;
            label3.Text = "ملاحظات";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(418, 24);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 10;
            label2.Text = "إسم المورد";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 155);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvPurchases);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Size = new Size(984, 506);
            splitContainer1.SplitterDistance = 185;
            splitContainer1.TabIndex = 2;
            // 
            // dgvPurchases
            // 
            dgvPurchases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPurchases.Dock = DockStyle.Fill;
            dgvPurchases.Location = new Point(0, 0);
            dgvPurchases.Name = "dgvPurchases";
            dgvPurchases.RightToLeft = RightToLeft.Yes;
            dgvPurchases.Size = new Size(984, 185);
            dgvPurchases.TabIndex = 0;
            dgvPurchases.SelectionChanged += dgvPurchases_SelectionChanged;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.IsSplitterFixed = true;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(dgvPurchaseDetails);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(lblTotalItem);
            splitContainer2.Panel2.Controls.Add(label8);
            splitContainer2.Panel2.Controls.Add(label7);
            splitContainer2.Panel2.Controls.Add(label6);
            splitContainer2.Panel2.Controls.Add(label4);
            splitContainer2.Panel2.Controls.Add(btnAddItem);
            splitContainer2.Panel2.Controls.Add(numPrice);
            splitContainer2.Panel2.Controls.Add(numQty);
            splitContainer2.Panel2.Controls.Add(cmbMaterials);
            splitContainer2.Size = new Size(984, 317);
            splitContainer2.SplitterDistance = 702;
            splitContainer2.TabIndex = 3;
            // 
            // dgvPurchaseDetails
            // 
            dgvPurchaseDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPurchaseDetails.ContextMenuStrip = contextMenuStrip1;
            dgvPurchaseDetails.Dock = DockStyle.Fill;
            dgvPurchaseDetails.Location = new Point(0, 0);
            dgvPurchaseDetails.Name = "dgvPurchaseDetails";
            dgvPurchaseDetails.RightToLeft = RightToLeft.Yes;
            dgvPurchaseDetails.Size = new Size(702, 317);
            dgvPurchaseDetails.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { tsmiDeleteDetail });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(135, 26);
            // 
            // tsmiDeleteDetail
            // 
            tsmiDeleteDetail.Name = "tsmiDeleteDetail";
            tsmiDeleteDetail.Size = new Size(134, 22);
            tsmiDeleteDetail.Text = "حذف السطر";
            tsmiDeleteDetail.Click += tsmiDeleteDetail_Click;
            // 
            // lblTotalItem
            // 
            lblTotalItem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotalItem.AutoSize = true;
            lblTotalItem.ForeColor = Color.Blue;
            lblTotalItem.Location = new Point(107, 218);
            lblTotalItem.Name = "lblTotalItem";
            lblTotalItem.Size = new Size(28, 15);
            lblTotalItem.TabIndex = 8;
            lblTotalItem.Text = "1.00";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(184, 218);
            label8.Name = "label8";
            label8.Size = new Size(77, 15);
            label8.TabIndex = 7;
            label8.Text = "اجمالي التكلفة";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(193, 169);
            label7.Name = "label7";
            label7.Size = new Size(68, 15);
            label7.TabIndex = 6;
            label7.Text = "تكلفة الوحدة";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(220, 115);
            label6.Name = "label6";
            label6.Size = new Size(37, 15);
            label6.TabIndex = 5;
            label6.Text = "الكمية";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(220, 64);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 4;
            label4.Text = "العنصر";
            // 
            // btnAddItem
            // 
            btnAddItem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddItem.Location = new Point(107, 253);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(93, 40);
            btnAddItem.TabIndex = 3;
            btnAddItem.Text = "إضافة";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // numPrice
            // 
            numPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numPrice.BorderStyle = BorderStyle.FixedSingle;
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(93, 167);
            numPrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(91, 23);
            numPrice.TabIndex = 2;
            numPrice.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numQty
            // 
            numQty.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numQty.BorderStyle = BorderStyle.FixedSingle;
            numQty.Location = new Point(116, 111);
            numQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQty.Name = "numQty";
            numQty.Size = new Size(68, 23);
            numQty.TabIndex = 1;
            numQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cmbMaterials
            // 
            cmbMaterials.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cmbMaterials.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbMaterials.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbMaterials.BackColor = Color.White;
            cmbMaterials.FlatStyle = FlatStyle.Flat;
            cmbMaterials.Font = new Font("Segoe UI", 11F);
            cmbMaterials.FormattingEnabled = true;
            cmbMaterials.Location = new Point(22, 57);
            cmbMaterials.Name = "cmbMaterials";
            cmbMaterials.Size = new Size(162, 28);
            cmbMaterials.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(2449, 369);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(169, 25);
            label1.TabIndex = 2;
            label1.Text = "اجمالي قيمة الفاتورة:";
            // 
            // frmPurchases
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(984, 661);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Name = "frmPurchases";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "المشتريات";
            WindowState = FormWindowState.Maximized;
            Load += frmPurchases_Load;
            panel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPurchases).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseDetails).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Button btnNewInvoice;
        private TextBox txtSupplierName;
        private TextBox txtNotes;
        private Label label3;
        private Label label2;
        private Label label5;
        private MaterialSearchableCombo cmbSafes;
        private SplitContainer splitContainer1;
        private DataGridView dgvPurchases;
        private Label label1;
        private SplitContainer splitContainer2;
        private DataGridView dgvPurchaseDetails;
        private NumericUpDown numQty;
        private MaterialSearchableCombo cmbMaterials;
        private Label label7;
        private Label label6;
        private Label label4;
        private Button btnAddItem;
        private NumericUpDown numPrice;
        private Label lblTotalItem;
        private Label label8;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmiDeleteDetail;
        private Label label9;
        private DateTimePicker dtpFilterDate;
        private MaterialSkin.Controls.MaterialTextBox2 txtSearchSupplier;
        private Button btnPrintInvoice;
    }
}