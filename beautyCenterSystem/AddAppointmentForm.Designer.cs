namespace beautyCenterSystem
{
    partial class AddAppointmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAppointmentForm));
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            dtpAppointmentTime = new DateTimePicker();
            dtpAppointmentDate = new DateTimePicker();
            btnAddCustomer = new Button();
            cmbCustomerSearch = new MaterialSearchableCombo();
            panel2 = new Panel();
            BtnCancel = new Button();
            btnSave = new Button();
            lblTotalDuration = new Label();
            lblTotalPrice = new Label();
            panel3 = new Panel();
            lvServices = new ListView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dtpAppointmentTime);
            panel1.Controls.Add(dtpAppointmentDate);
            panel1.Controls.Add(btnAddCustomer);
            panel1.Controls.Add(cmbCustomerSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(434, 174);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(368, 140);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 6;
            label4.Text = "وقت الحجز";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(367, 97);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 5;
            label3.Text = "تاريخ الحجز";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(368, 45);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 4;
            label2.Text = "اسم العميل";
            // 
            // dtpAppointmentTime
            // 
            dtpAppointmentTime.CustomFormat = "hh:mm tt";
            dtpAppointmentTime.Format = DateTimePickerFormat.Custom;
            dtpAppointmentTime.Location = new Point(158, 134);
            dtpAppointmentTime.Name = "dtpAppointmentTime";
            dtpAppointmentTime.RightToLeft = RightToLeft.Yes;
            dtpAppointmentTime.ShowUpDown = true;
            dtpAppointmentTime.Size = new Size(200, 23);
            dtpAppointmentTime.TabIndex = 3;
            // 
            // dtpAppointmentDate
            // 
            dtpAppointmentDate.Location = new Point(158, 89);
            dtpAppointmentDate.Name = "dtpAppointmentDate";
            dtpAppointmentDate.Size = new Size(200, 23);
            dtpAppointmentDate.TabIndex = 2;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Location = new Point(3, 16);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(73, 54);
            btnAddCustomer.TabIndex = 1;
            btnAddCustomer.Text = "اضافة عميل جديد";
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // cmbCustomerSearch
            // 
            cmbCustomerSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCustomerSearch.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCustomerSearch.BackColor = Color.White;
            cmbCustomerSearch.FlatStyle = FlatStyle.Flat;
            cmbCustomerSearch.Font = new Font("Segoe UI", 15F);
            cmbCustomerSearch.FormattingEnabled = true;
            cmbCustomerSearch.Location = new Point(106, 34);
            cmbCustomerSearch.Name = "cmbCustomerSearch";
            cmbCustomerSearch.Size = new Size(252, 36);
            cmbCustomerSearch.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(BtnCancel);
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(lblTotalDuration);
            panel2.Controls.Add(lblTotalPrice);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 368);
            panel2.Name = "panel2";
            panel2.Size = new Size(434, 143);
            panel2.TabIndex = 1;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(74, 83);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(124, 48);
            BtnCancel.TabIndex = 9;
            BtnCancel.Text = "الغاء";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(257, 83);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(124, 48);
            btnSave.TabIndex = 8;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblTotalDuration
            // 
            lblTotalDuration.AutoSize = true;
            lblTotalDuration.Font = new Font("Segoe UI", 11F);
            lblTotalDuration.Location = new Point(49, 22);
            lblTotalDuration.Name = "lblTotalDuration";
            lblTotalDuration.Size = new Size(94, 20);
            lblTotalDuration.TabIndex = 1;
            lblTotalDuration.Text = "الزمن المتوقع";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Font = new Font("Segoe UI", 11F);
            lblTotalPrice.Location = new Point(272, 22);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(62, 20);
            lblTotalPrice.TabIndex = 0;
            lblTotalPrice.Text = "الاجمالي";
            // 
            // panel3
            // 
            panel3.Controls.Add(lvServices);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 174);
            panel3.Name = "panel3";
            panel3.Size = new Size(434, 194);
            panel3.TabIndex = 2;
            // 
            // lvServices
            // 
            lvServices.Dock = DockStyle.Fill;
            lvServices.Location = new Point(0, 0);
            lvServices.Name = "lvServices";
            lvServices.RightToLeft = RightToLeft.Yes;
            lvServices.Size = new Size(434, 194);
            lvServices.TabIndex = 0;
            lvServices.UseCompatibleStateImageBehavior = false;
            // 
            // AddAppointmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 511);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddAppointmentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "اضافة حجز";
            Load += AddAppointmentForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private MaterialSearchableCombo cmbCustomerSearch;
        private DateTimePicker dtpAppointmentTime;
        private DateTimePicker dtpAppointmentDate;
        private Button btnAddCustomer;
        private Label lblTotalDuration;
        private Label lblTotalPrice;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button BtnCancel;
        private Button btnSave;
        private ListView lvServices;
    }
}