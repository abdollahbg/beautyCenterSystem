namespace beautyCenterSystem
{
    partial class UC_Appointments
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            dtpFilterDate = new DateTimePicker();
            cmbFilterRoom = new System.Windows.Forms.ComboBox();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            txtSearchCustomer = new MaterialSkin.Controls.MaterialTextBox2();
            btnRefresh = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnAddAppointment = new FontAwesome.Sharp.IconButton();
            btnEditAppointment = new FontAwesome.Sharp.IconButton();
            btnPrintInvoice = new FontAwesome.Sharp.IconButton();
            btnCompleteAndPay = new FontAwesome.Sharp.IconButton();
            btnCancelAppointment = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            splitContainer1 = new SplitContainer();
            dgvDetails = new DataGridView();
            dgvAppointments = new DataGridView();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.WhiteSmoke;
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(dtpFilterDate);
            flowLayoutPanel1.Controls.Add(cmbFilterRoom);
            flowLayoutPanel1.Controls.Add(iconPictureBox1);
            flowLayoutPanel1.Controls.Add(txtSearchCustomer);
            flowLayoutPanel1.Controls.Add(btnRefresh);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(15, 20, 15, 10);
            flowLayoutPanel1.Size = new Size(1000, 96);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(789, 20);
            label1.Margin = new Padding(3, 0, 15, 0);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(151, 32);
            label1.TabIndex = 0;
            label1.Text = "مواعيد اليوم";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dtpFilterDate
            // 
            dtpFilterDate.Font = new Font("Segoe UI", 12F);
            dtpFilterDate.Location = new Point(561, 23);
            dtpFilterDate.Margin = new Padding(15, 3, 15, 3);
            dtpFilterDate.Name = "dtpFilterDate";
            dtpFilterDate.Size = new Size(210, 29);
            dtpFilterDate.TabIndex = 1;
            dtpFilterDate.ValueChanged += dtpFilterDate_ValueChanged;
            // 
            // cmbFilterRoom
            // 
            cmbFilterRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterRoom.FlatStyle = FlatStyle.Flat;
            cmbFilterRoom.Font = new Font("Segoe UI", 12F);
            cmbFilterRoom.FormattingEnabled = true;
            cmbFilterRoom.Location = new Point(316, 23);
            cmbFilterRoom.Margin = new Padding(15, 3, 15, 3);
            cmbFilterRoom.Name = "cmbFilterRoom";
            cmbFilterRoom.Size = new Size(215, 29);
            cmbFilterRoom.TabIndex = 8;
            cmbFilterRoom.SelectedIndexChanged += cmbFilterRoom_SelectedIndexChanged;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.Transparent;
            iconPictureBox1.ForeColor = Color.Gray;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Search;
            iconPictureBox1.IconColor = Color.Gray;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 35;
            iconPictureBox1.Location = new Point(506, 23);
            iconPictureBox1.Margin = new Padding(5, 3, 15, 3);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(35, 35);
            iconPictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            iconPictureBox1.TabIndex = 7;
            iconPictureBox1.TabStop = false;
            // 
            // txtSearchCustomer
            // 
            txtSearchCustomer.AnimateReadOnly = false;
            txtSearchCustomer.AutoCompleteMode = AutoCompleteMode.None;
            txtSearchCustomer.AutoCompleteSource = AutoCompleteSource.None;
            txtSearchCustomer.BackgroundImageLayout = ImageLayout.None;
            txtSearchCustomer.CharacterCasing = CharacterCasing.Normal;
            txtSearchCustomer.Depth = 0;
            txtSearchCustomer.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSearchCustomer.HideSelection = true;
            txtSearchCustomer.Hint = "البحث عن عميلة...";
            txtSearchCustomer.LeadingIcon = null;
            txtSearchCustomer.Location = new Point(147, 23);
            txtSearchCustomer.Margin = new Padding(15, 3, 3, 3);
            txtSearchCustomer.MaxLength = 32767;
            txtSearchCustomer.MouseState = MaterialSkin.MouseState.OUT;
            txtSearchCustomer.Name = "txtSearchCustomer";
            txtSearchCustomer.PasswordChar = '\0';
            txtSearchCustomer.PrefixSuffixText = null;
            txtSearchCustomer.ReadOnly = false;
            txtSearchCustomer.RightToLeft = RightToLeft.Yes;
            txtSearchCustomer.SelectedText = "";
            txtSearchCustomer.SelectionLength = 0;
            txtSearchCustomer.SelectionStart = 0;
            txtSearchCustomer.ShortcutsEnabled = true;
            txtSearchCustomer.Size = new Size(341, 48);
            txtSearchCustomer.TabIndex = 6;
            txtSearchCustomer.TabStop = false;
            txtSearchCustomer.TextAlign = HorizontalAlignment.Right;
            txtSearchCustomer.TrailingIcon = null;
            txtSearchCustomer.UseSystemPasswordChar = false;
            txtSearchCustomer.TextChanged += txtSearchCustomer_TextChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.White;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderColor = Color.Silver;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.FromArgb(64, 64, 64);
            btnRefresh.Location = new Point(40, 23);
            btnRefresh.Margin = new Padding(15, 3, 3, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(89, 48);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "تحديث";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click_1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.WhiteSmoke;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(btnAddAppointment, 0, 0);
            tableLayoutPanel1.Controls.Add(btnEditAppointment, 1, 0);
            tableLayoutPanel1.Controls.Add(btnPrintInvoice, 2, 0);
            tableLayoutPanel1.Controls.Add(btnCompleteAndPay, 3, 0);
            tableLayoutPanel1.Controls.Add(btnCancelAppointment, 4, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 600);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RightToLeft = RightToLeft.Yes;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1000, 100);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btnAddAppointment
            // 
            btnAddAppointment.Cursor = Cursors.Hand;
            btnAddAppointment.Dock = DockStyle.Fill;
            btnAddAppointment.FlatAppearance.BorderSize = 0;
            btnAddAppointment.FlatStyle = FlatStyle.Flat;
            btnAddAppointment.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddAppointment.IconChar = FontAwesome.Sharp.IconChar.CalendarPlus;
            btnAddAppointment.IconColor = Color.Black;
            btnAddAppointment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddAppointment.IconSize = 40;
            btnAddAppointment.Location = new Point(793, 13);
            btnAddAppointment.Name = "btnAddAppointment";
            btnAddAppointment.Size = new Size(184, 74);
            btnAddAppointment.TabIndex = 1;
            btnAddAppointment.Text = "حجز جديد";
            btnAddAppointment.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnAddAppointment.UseVisualStyleBackColor = true;
            btnAddAppointment.Click += btnAddAppointment_Click;
            // 
            // btnEditAppointment
            // 
            btnEditAppointment.Cursor = Cursors.Hand;
            btnEditAppointment.Dock = DockStyle.Fill;
            btnEditAppointment.FlatAppearance.BorderSize = 0;
            btnEditAppointment.FlatStyle = FlatStyle.Flat;
            btnEditAppointment.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnEditAppointment.IconChar = FontAwesome.Sharp.IconChar.Edit;
            btnEditAppointment.IconColor = Color.Black;
            btnEditAppointment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEditAppointment.IconSize = 40;
            btnEditAppointment.Location = new Point(598, 13);
            btnEditAppointment.Name = "btnEditAppointment";
            btnEditAppointment.Size = new Size(189, 74);
            btnEditAppointment.TabIndex = 4;
            btnEditAppointment.Text = "تعديل الحجز";
            btnEditAppointment.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnEditAppointment.UseVisualStyleBackColor = true;
            btnEditAppointment.Click += btnEditAppointment_Click;
            // 
            // btnPrintInvoice
            // 
            btnPrintInvoice.Cursor = Cursors.Hand;
            btnPrintInvoice.Dock = DockStyle.Fill;
            btnPrintInvoice.FlatAppearance.BorderSize = 0;
            btnPrintInvoice.FlatStyle = FlatStyle.Flat;
            btnPrintInvoice.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPrintInvoice.IconChar = FontAwesome.Sharp.IconChar.Print;
            btnPrintInvoice.IconColor = Color.Black;
            btnPrintInvoice.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPrintInvoice.IconSize = 40;
            btnPrintInvoice.Location = new Point(402, 13);
            btnPrintInvoice.Name = "btnPrintInvoice";
            btnPrintInvoice.Size = new Size(190, 74);
            btnPrintInvoice.TabIndex = 6;
            btnPrintInvoice.Text = "طباعة فاتورة";
            btnPrintInvoice.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnPrintInvoice.UseVisualStyleBackColor = true;
            btnPrintInvoice.Click += btnPrintInvoice_Click;
            // 
            // btnCompleteAndPay
            // 
            btnCompleteAndPay.Cursor = Cursors.Hand;
            btnCompleteAndPay.Dock = DockStyle.Fill;
            btnCompleteAndPay.FlatAppearance.BorderSize = 0;
            btnCompleteAndPay.FlatStyle = FlatStyle.Flat;
            btnCompleteAndPay.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCompleteAndPay.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            btnCompleteAndPay.IconColor = Color.Black;
            btnCompleteAndPay.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCompleteAndPay.IconSize = 40;
            btnCompleteAndPay.Location = new Point(207, 13);
            btnCompleteAndPay.Name = "btnCompleteAndPay";
            btnCompleteAndPay.Size = new Size(189, 74);
            btnCompleteAndPay.TabIndex = 3;
            btnCompleteAndPay.Text = "انهاء ودفع";
            btnCompleteAndPay.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnCompleteAndPay.UseVisualStyleBackColor = true;
            btnCompleteAndPay.Click += btnCompleteAndPay_Click;
            // 
            // btnCancelAppointment
            // 
            btnCancelAppointment.Cursor = Cursors.Hand;
            btnCancelAppointment.Dock = DockStyle.Fill;
            btnCancelAppointment.FlatAppearance.BorderSize = 0;
            btnCancelAppointment.FlatStyle = FlatStyle.Flat;
            btnCancelAppointment.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelAppointment.IconChar = FontAwesome.Sharp.IconChar.CalendarMinus;
            btnCancelAppointment.IconColor = Color.Black;
            btnCancelAppointment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelAppointment.IconSize = 40;
            btnCancelAppointment.Location = new Point(13, 13);
            btnCancelAppointment.Name = "btnCancelAppointment";
            btnCancelAppointment.Size = new Size(188, 74);
            btnCancelAppointment.TabIndex = 5;
            btnCancelAppointment.Text = "الغاء حجز";
            btnCancelAppointment.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnCancelAppointment.UseVisualStyleBackColor = true;
            btnCancelAppointment.Click += btnCancelAppointment_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(splitContainer1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 96);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15);
            panel1.Size = new Size(1000, 504);
            panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(15, 15);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvDetails);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvAppointments);
            splitContainer1.Size = new Size(970, 474);
            splitContainer1.SplitterDistance = 580;
            splitContainer1.SplitterWidth = 10;
            splitContainer1.TabIndex = 0;
            // 
            // dgvDetails
            // 
            dgvDetails.BackgroundColor = Color.White;
            dgvDetails.BorderStyle = BorderStyle.None;
            dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetails.Dock = DockStyle.Fill;
            dgvDetails.Location = new Point(0, 0);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.RightToLeft = RightToLeft.Yes;
            dgvDetails.Size = new Size(580, 474);
            dgvDetails.TabIndex = 4;
            // 
            // dgvAppointments
            // 
            dgvAppointments.BackgroundColor = Color.White;
            dgvAppointments.BorderStyle = BorderStyle.None;
            dgvAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAppointments.Dock = DockStyle.Fill;
            dgvAppointments.Location = new Point(0, 0);
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.RightToLeft = RightToLeft.Yes;
            dgvAppointments.Size = new Size(380, 474);
            dgvAppointments.TabIndex = 4;
            dgvAppointments.SelectionChanged += dgvAppointments_SelectionChanged;
            // 
            // UC_Appointments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(flowLayoutPanel1);
            Name = "UC_Appointments";
            Size = new Size(1000, 700);
            Load += UC_Appointments_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private DateTimePicker dtpFilterDate;
        private System.Windows.Forms.ComboBox cmbFilterRoom;
        private MaterialSkin.Controls.MaterialTextBox2 txtSearchCustomer;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnCancelAppointment;
        private FontAwesome.Sharp.IconButton btnEditAppointment;
        private FontAwesome.Sharp.IconButton btnCompleteAndPay;
        private FontAwesome.Sharp.IconButton btnPrintInvoice;
        private FontAwesome.Sharp.IconButton btnAddAppointment;
        private Panel panel1;
        private SplitContainer splitContainer1;
        private DataGridView dgvDetails;
        private DataGridView dgvAppointments;
        private Button btnRefresh;
    }
}