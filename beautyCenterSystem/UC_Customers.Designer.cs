namespace beautyCenterSystem
{
    partial class UC_Customers
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
            components = new System.ComponentModel.Container();
            panel3 = new Panel();
            lblNumberOfCustumer = new Label();
            btnAddCustomer = new FontAwesome.Sharp.IconButton();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtboxSearch = new MaterialSkin.Controls.MaterialTextBox2();
            panel1 = new Panel();
            dgvCustomers = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btnDeleteCustomer = new ToolStripMenuItem();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Controls.Add(lblNumberOfCustumer);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(20, 640);
            panel3.Name = "panel3";
            panel3.Size = new Size(960, 40);
            panel3.TabIndex = 2;
            // 
            // lblNumberOfCustumer
            // 
            lblNumberOfCustumer.AutoSize = true;
            lblNumberOfCustumer.Location = new Point(930, 15);
            lblNumberOfCustumer.Name = "lblNumberOfCustumer";
            lblNumberOfCustumer.Size = new Size(13, 15);
            lblNumberOfCustumer.TabIndex = 1;
            lblNumberOfCustumer.Text = "0";
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 0);
            btnAddCustomer.FlatStyle = FlatStyle.Flat;
            btnAddCustomer.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            btnAddCustomer.IconColor = Color.Black;
            btnAddCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddCustomer.IconSize = 35;
            btnAddCustomer.Location = new Point(3, 3);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(106, 59);
            btnAddCustomer.TabIndex = 0;
            btnAddCustomer.Text = "إضافة عميل";
            btnAddCustomer.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = SystemColors.Control;
            iconPictureBox1.Dock = DockStyle.Right;
            iconPictureBox1.ForeColor = SystemColors.ControlText;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Search;
            iconPictureBox1.IconColor = SystemColors.ControlText;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 39;
            iconPictureBox1.Location = new Point(208, 3);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(39, 59);
            iconPictureBox1.TabIndex = 6;
            iconPictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(826, 0);
            label1.Name = "label1";
            label1.Size = new Size(131, 32);
            label1.TabIndex = 3;
            label1.Text = "إدارة العملاء";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 260F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 450F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(iconPictureBox1, 2, 0);
            tableLayoutPanel1.Controls.Add(btnAddCustomer, 4, 0);
            tableLayoutPanel1.Controls.Add(txtboxSearch, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(20, 20);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RightToLeft = RightToLeft.Yes;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(960, 65);
            tableLayoutPanel1.TabIndex = 3;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint_2;
            // 
            // txtboxSearch
            // 
            txtboxSearch.AnimateReadOnly = false;
            txtboxSearch.AutoCompleteMode = AutoCompleteMode.None;
            txtboxSearch.AutoCompleteSource = AutoCompleteSource.None;
            txtboxSearch.BackgroundImageLayout = ImageLayout.None;
            txtboxSearch.CharacterCasing = CharacterCasing.Normal;
            txtboxSearch.Depth = 0;
            txtboxSearch.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtboxSearch.HideSelection = true;
            txtboxSearch.Hint = "البحث";
            txtboxSearch.LeadingIcon = null;
            txtboxSearch.Location = new Point(253, 3);
            txtboxSearch.MaxLength = 32767;
            txtboxSearch.MouseState = MaterialSkin.MouseState.OUT;
            txtboxSearch.Name = "txtboxSearch";
            txtboxSearch.PasswordChar = '\0';
            txtboxSearch.PrefixSuffixText = null;
            txtboxSearch.ReadOnly = false;
            txtboxSearch.RightToLeft = RightToLeft.Yes;
            txtboxSearch.SelectedText = "";
            txtboxSearch.SelectionLength = 0;
            txtboxSearch.SelectionStart = 0;
            txtboxSearch.ShortcutsEnabled = true;
            txtboxSearch.Size = new Size(444, 48);
            txtboxSearch.TabIndex = 5;
            txtboxSearch.TabStop = false;
            txtboxSearch.TextAlign = HorizontalAlignment.Right;
            txtboxSearch.TrailingIcon = null;
            txtboxSearch.UseSystemPasswordChar = false;
            txtboxSearch.TextChanged += txtboxSearch_TextChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvCustomers);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 85);
            panel1.Name = "panel1";
            panel1.Size = new Size(960, 555);
            panel1.TabIndex = 4;
            // 
            // dgvCustomers
            // 
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.ContextMenuStrip = contextMenuStrip1;
            dgvCustomers.Dock = DockStyle.Fill;
            dgvCustomers.Location = new Point(0, 0);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RightToLeft = RightToLeft.Yes;
            dgvCustomers.Size = new Size(960, 555);
            dgvCustomers.TabIndex = 1;
            dgvCustomers.CellContentClick += dgvCustomers_CellContentClick_1;
            dgvCustomers.CellEndEdit += dgvCustomers_CellEndEdit;
            dgvCustomers.CellMouseDown += dgvCustomers_CellMouseDown;
            dgvCustomers.MouseDown += dgvCustomers_MouseDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { btnDeleteCustomer });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RightToLeft = RightToLeft.Yes;
            contextMenuStrip1.Size = new Size(136, 26);
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(135, 22);
            btnDeleteCustomer.Text = "حذف العميل";
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // UC_Customers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel3);
            Name = "UC_Customers";
            Padding = new Padding(20);
            Size = new Size(1000, 700);
            Load += UC_Customers_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel3;
        private Label lblNumberOfCustumer;
        private FontAwesome.Sharp.IconButton btnAddCustomer;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private MaterialSkin.Controls.MaterialTextBox2 txtboxSearch;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private DataGridView dgvCustomers;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem btnDeleteCustomer;
    }
}
