namespace beautyCenterSystem
{
    partial class AddEmployeeForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            PnlHeader = new Panel();
            label1 = new Label();
            label2 = new Label();
            txtEmployeeName = new MaterialSkin.Controls.MaterialTextBox2();
            label4 = new Label();
            txtPhone = new MaterialSkin.Controls.MaterialTextBox2();
            label5 = new Label();
            txtCommissionRate = new MaterialSkin.Controls.MaterialTextBox2();
            label3 = new Label();
            cmbRooms = new MaterialSkin.Controls.MaterialComboBox();
            btnSave = new Button();
            BtnCancel = new Button();
            PnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // PnlHeader
            // 
            PnlHeader.Controls.Add(label1);
            PnlHeader.Dock = DockStyle.Top;
            PnlHeader.Location = new Point(0, 0);
            PnlHeader.Name = "PnlHeader";
            PnlHeader.Size = new Size(434, 69);
            PnlHeader.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(135, 20);
            label1.Name = "label1";
            label1.Size = new Size(164, 28);
            label1.TabIndex = 0;
            label1.Text = "إضافة موظفة جديدة";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(326, 102);
            label2.Name = "label2";
            label2.Size = new Size(86, 19);
            label2.TabIndex = 1;
            label2.Text = "إسم الموظفة";
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.AnimateReadOnly = false;
            txtEmployeeName.BackgroundImageLayout = ImageLayout.None;
            txtEmployeeName.Depth = 0;
            txtEmployeeName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtEmployeeName.Location = new Point(51, 89);
            txtEmployeeName.MaxLength = 100;
            txtEmployeeName.MouseState = MaterialSkin.MouseState.OUT;
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.RightToLeft = RightToLeft.Yes;
            txtEmployeeName.Size = new Size(250, 48);
            txtEmployeeName.TabIndex = 1;
            txtEmployeeName.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(326, 168);
            label4.Name = "label4";
            label4.Size = new Size(74, 19);
            label4.TabIndex = 2;
            label4.Text = "رقم الهاتف";
            // 
            // txtPhone
            // 
            txtPhone.AnimateReadOnly = false;
            txtPhone.Depth = 0;
            txtPhone.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPhone.Location = new Point(51, 153);
            txtPhone.MaxLength = 15;
            txtPhone.MouseState = MaterialSkin.MouseState.OUT;
            txtPhone.Name = "txtPhone";
            txtPhone.RightToLeft = RightToLeft.Yes;
            txtPhone.Size = new Size(250, 48);
            txtPhone.TabIndex = 2;
            txtPhone.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(326, 233);
            label5.Name = "label5";
            label5.Size = new Size(65, 19);
            label5.TabIndex = 3;
            label5.Text = "النسبة %";
            // 
            // txtCommissionRate
            // 
            txtCommissionRate.AnimateReadOnly = false;
            txtCommissionRate.Depth = 0;
            txtCommissionRate.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCommissionRate.Location = new Point(51, 219);
            txtCommissionRate.MaxLength = 5;
            txtCommissionRate.MouseState = MaterialSkin.MouseState.OUT;
            txtCommissionRate.Name = "txtCommissionRate";
            txtCommissionRate.RightToLeft = RightToLeft.Yes;
            txtCommissionRate.Size = new Size(250, 48);
            txtCommissionRate.TabIndex = 3;
            txtCommissionRate.Text = "0";
            txtCommissionRate.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(326, 305);
            label3.Name = "label3";
            label3.Size = new Size(47, 19);
            label3.TabIndex = 4;
            label3.Text = "الغرفة";
            // 
            // cmbRooms
            // 
            cmbRooms.AutoResize = false;
            cmbRooms.BackColor = Color.FromArgb(255, 255, 255);
            cmbRooms.Depth = 0;
            cmbRooms.DrawMode = DrawMode.OwnerDrawVariable;
            cmbRooms.DropDownHeight = 174;
            cmbRooms.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRooms.DropDownWidth = 121;
            cmbRooms.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbRooms.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbRooms.FormattingEnabled = true;
            cmbRooms.IntegralHeight = false;
            cmbRooms.ItemHeight = 43;
            cmbRooms.Location = new Point(51, 290);
            cmbRooms.MaxDropDownItems = 4;
            cmbRooms.MouseState = MaterialSkin.MouseState.OUT;
            cmbRooms.Name = "cmbRooms";
            cmbRooms.RightToLeft = RightToLeft.Yes;
            cmbRooms.Size = new Size(250, 49);
            cmbRooms.StartIndex = 0;
            cmbRooms.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(250, 410);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(124, 48);
            btnSave.TabIndex = 5;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(60, 410);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(124, 48);
            BtnCancel.TabIndex = 6;
            BtnCancel.Text = "إلغاء";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // AddEmployeeForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(434, 511); // الارتفاع الفعلي للـ Client ليناسب 550 كإجمالي
            Controls.Add(BtnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbRooms);
            Controls.Add(label3);
            Controls.Add(txtCommissionRate);
            Controls.Add(label5);
            Controls.Add(txtPhone);
            // 
            // AddEmployeeForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(434, 511);
            Controls.Add(BtnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbRooms);
            Controls.Add(label3);
            Controls.Add(txtCommissionRate);
            Controls.Add(label5);
            Controls.Add(txtPhone);
            Controls.Add(label4);
            Controls.Add(txtEmployeeName);
            Controls.Add(label2);
            Controls.Add(PnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddEmployeeForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "إضافة موظفة";
            Load += AddEmployeeForm_Load;
            PnlHeader.ResumeLayout(false);
            PnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PnlHeader;
        private Label label1;
        private Label label2;
        private MaterialSkin.Controls.MaterialTextBox2 txtEmployeeName;
        private Label label4;
        private MaterialSkin.Controls.MaterialTextBox2 txtPhone;
        private Label label5;
        private MaterialSkin.Controls.MaterialTextBox2 txtCommissionRate;
        private Label label3;
        private MaterialSkin.Controls.MaterialComboBox cmbRooms;
        private Button btnSave;
        private Button BtnCancel;
    }
}