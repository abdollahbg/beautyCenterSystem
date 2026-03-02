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
            txtSearchCustomer = new MaterialSkin.Controls.MaterialTextBox2();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            btnRefresh = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnCancelAppointment = new FontAwesome.Sharp.IconButton();
            btnCompleteAndPay = new FontAwesome.Sharp.IconButton();
            btnStartService = new FontAwesome.Sharp.IconButton();
            btnAddAppointment = new FontAwesome.Sharp.IconButton();
            btnEditAppointment = new FontAwesome.Sharp.IconButton();
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
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(dtpFilterDate);
            flowLayoutPanel1.Controls.Add(txtSearchCustomer);
            flowLayoutPanel1.Controls.Add(iconPictureBox1);
            flowLayoutPanel1.Controls.Add(btnRefresh);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(20);
            flowLayoutPanel1.Size = new Size(1000, 96);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(792, 20);
            label1.Name = "label1";
            label1.Padding = new Padding(10, 0, 0, 0);
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(165, 37);
            label1.TabIndex = 0;
            label1.Text = "مواعيد اليوم";
            // 
            // dtpFilterDate
            // 
            dtpFilterDate.Location = new Point(587, 23);
            dtpFilterDate.Name = "dtpFilterDate";
            dtpFilterDate.Size = new Size(199, 23);
            dtpFilterDate.TabIndex = 1;
            dtpFilterDate.ValueChanged += dtpFilterDate_ValueChanged;
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
            txtSearchCustomer.Hint = "البحث";
            txtSearchCustomer.LeadingIcon = null;
            txtSearchCustomer.Location = new Point(137, 23);
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
            txtSearchCustomer.Size = new Size(444, 48);
            txtSearchCustomer.TabIndex = 6;
            txtSearchCustomer.TabStop = false;
            txtSearchCustomer.TextAlign = HorizontalAlignment.Right;
            txtSearchCustomer.TrailingIcon = null;
            txtSearchCustomer.UseSystemPasswordChar = false;
            txtSearchCustomer.Click += txtSearchCustomer_Click;
            txtSearchCustomer.TextChanged += txtSearchCustomer_TextChanged;
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
            iconPictureBox1.Location = new Point(92, 23);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(39, 48);
            iconPictureBox1.TabIndex = 7;
            iconPictureBox1.TabStop = false;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(11, 23);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 48);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "تحديث";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click_1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.18455F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.3346767F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.7598553F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.6277771F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.09314F));
            tableLayoutPanel1.Controls.Add(btnCancelAppointment, 4, 0);
            tableLayoutPanel1.Controls.Add(btnCompleteAndPay, 2, 0);
            tableLayoutPanel1.Controls.Add(btnStartService, 1, 0);
            tableLayoutPanel1.Controls.Add(btnAddAppointment, 0, 0);
            tableLayoutPanel1.Controls.Add(btnEditAppointment, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 600);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RightToLeft = RightToLeft.Yes;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1000, 100);
            tableLayoutPanel1.TabIndex = 1;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // btnCancelAppointment
            // 
            btnCancelAppointment.IconChar = FontAwesome.Sharp.IconChar.CalendarMinus;
            btnCancelAppointment.IconColor = Color.Black;
            btnCancelAppointment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelAppointment.IconSize = 45;
            btnCancelAppointment.Location = new Point(3, 3);
            btnCancelAppointment.Name = "btnCancelAppointment";
            btnCancelAppointment.Padding = new Padding(15, 0, 0, 0);
            btnCancelAppointment.Size = new Size(197, 94);
            btnCancelAppointment.TabIndex = 5;
            btnCancelAppointment.Text = "الغاء حجز";
            btnCancelAppointment.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnCancelAppointment.UseVisualStyleBackColor = true;
            btnCancelAppointment.Click += btnCancelAppointment_Click;
            // 
            // btnCompleteAndPay
            // 
            btnCompleteAndPay.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            btnCompleteAndPay.IconColor = Color.Black;
            btnCompleteAndPay.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCompleteAndPay.IconSize = 45;
            btnCompleteAndPay.Location = new Point(402, 3);
            btnCompleteAndPay.Name = "btnCompleteAndPay";
            btnCompleteAndPay.Padding = new Padding(15, 0, 0, 0);
            btnCompleteAndPay.Size = new Size(191, 94);
            btnCompleteAndPay.TabIndex = 3;
            btnCompleteAndPay.Text = "انهاء ودفع";
            btnCompleteAndPay.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnCompleteAndPay.UseVisualStyleBackColor = true;
            // 
            // btnStartService
            // 
            btnStartService.IconChar = FontAwesome.Sharp.IconChar.Play;
            btnStartService.IconColor = Color.Black;
            btnStartService.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStartService.IconSize = 45;
            btnStartService.Location = new Point(599, 3);
            btnStartService.Name = "btnStartService";
            btnStartService.Padding = new Padding(15, 0, 0, 0);
            btnStartService.Size = new Size(197, 94);
            btnStartService.TabIndex = 2;
            btnStartService.Text = "بدء الخدمة";
            btnStartService.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnStartService.UseVisualStyleBackColor = true;
            btnStartService.Click += btnStartService_Click;
            // 
            // btnAddAppointment
            // 
            btnAddAppointment.IconChar = FontAwesome.Sharp.IconChar.CalendarPlus;
            btnAddAppointment.IconColor = Color.Black;
            btnAddAppointment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddAppointment.IconSize = 45;
            btnAddAppointment.Location = new Point(802, 3);
            btnAddAppointment.Name = "btnAddAppointment";
            btnAddAppointment.Padding = new Padding(20, 0, 0, 0);
            btnAddAppointment.Size = new Size(195, 94);
            btnAddAppointment.TabIndex = 1;
            btnAddAppointment.Text = "حجز جديد";
            btnAddAppointment.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnAddAppointment.UseVisualStyleBackColor = true;
            btnAddAppointment.Click += btnAddAppointment_Click;
            // 
            // btnEditAppointment
            // 
            btnEditAppointment.IconChar = FontAwesome.Sharp.IconChar.Edit;
            btnEditAppointment.IconColor = Color.Black;
            btnEditAppointment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEditAppointment.IconSize = 45;
            btnEditAppointment.Location = new Point(206, 3);
            btnEditAppointment.Name = "btnEditAppointment";
            btnEditAppointment.Padding = new Padding(15, 0, 0, 0);
            btnEditAppointment.Size = new Size(190, 94);
            btnEditAppointment.TabIndex = 4;
            btnEditAppointment.Text = "تعديل الحجز";
            btnEditAppointment.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnEditAppointment.UseVisualStyleBackColor = true;
            btnEditAppointment.Click += btnEditAppointment_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(splitContainer1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 96);
            panel1.Name = "panel1";
            panel1.Size = new Size(1000, 504);
            panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvDetails);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvAppointments);
            splitContainer1.Size = new Size(1000, 504);
            splitContainer1.SplitterDistance = 619;
            splitContainer1.TabIndex = 0;
            // 
            // dgvDetails
            // 
            dgvDetails.BorderStyle = BorderStyle.None;
            dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetails.Dock = DockStyle.Fill;
            dgvDetails.Location = new Point(0, 0);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.RightToLeft = RightToLeft.Yes;
            dgvDetails.Size = new Size(619, 504);
            dgvDetails.TabIndex = 4;
            // 
            // dgvAppointments
            // 
            dgvAppointments.BorderStyle = BorderStyle.None;
            dgvAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAppointments.Dock = DockStyle.Fill;
            dgvAppointments.Location = new Point(0, 0);
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.RightToLeft = RightToLeft.Yes;
            dgvAppointments.Size = new Size(377, 504);
            dgvAppointments.TabIndex = 4;
            dgvAppointments.SelectionChanged += dgvAppointments_SelectionChanged;
            // 
            // UC_Appointments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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
        private MaterialSkin.Controls.MaterialTextBox2 txtSearchCustomer;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnCancelAppointment;
        private FontAwesome.Sharp.IconButton btnEditAppointment;
        private FontAwesome.Sharp.IconButton btnCompleteAndPay;
        private FontAwesome.Sharp.IconButton btnStartService;
        private FontAwesome.Sharp.IconButton btnAddAppointment;
        private Panel panel1;
        private SplitContainer splitContainer1;
        private DataGridView dgvDetails;
        private DataGridView dgvAppointments;
        private Button btnRefresh;
    }
}
