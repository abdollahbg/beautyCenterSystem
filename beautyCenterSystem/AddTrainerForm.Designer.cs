namespace beautyCenterSystem
{
    partial class AddTrainerForm
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
            txtTrainerName = new MaterialSkin.Controls.MaterialTextBox2();
            label4 = new Label();
            txtPhone = new MaterialSkin.Controls.MaterialTextBox2();
            
            labelType = new Label();
            cmbTrainerType = new System.Windows.Forms.ComboBox();

            labelSalary = new Label();
            txtBaseSalary = new MaterialSkin.Controls.MaterialTextBox2();

            label5 = new Label();
            txtCommissionRate = new MaterialSkin.Controls.MaterialTextBox2();
            label3 = new Label();
            cmbRooms = new System.Windows.Forms.ComboBox();
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
            label1.Text = "بيانات الموظفة";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(326, 102);
            label2.Name = "label2";
            label2.Size = new Size(86, 19);
            label2.TabIndex = 1;
            label2.Text = "اسم الموظفة";
            // 
            // txtTrainerName
            // 
            txtTrainerName.AnimateReadOnly = false;
            txtTrainerName.BackgroundImageLayout = ImageLayout.None;
            txtTrainerName.Depth = 0;
            txtTrainerName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTrainerName.Location = new Point(51, 89);
            txtTrainerName.MaxLength = 100;
            txtTrainerName.MouseState = MaterialSkin.MouseState.OUT;
            txtTrainerName.Name = "txtTrainerName";
            txtTrainerName.RightToLeft = RightToLeft.Yes;
            txtTrainerName.Size = new Size(250, 48);
            txtTrainerName.TabIndex = 1;
            txtTrainerName.TextAlign = HorizontalAlignment.Right;
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
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Font = new Font("Segoe UI", 10F);
            labelType.Location = new Point(326, 233);
            labelType.Name = "labelType";
            labelType.Size = new Size(65, 19);
            labelType.TabIndex = 3;
            labelType.Text = "نظام العمل";
            // 
            // cmbTrainerType
            // 
            cmbTrainerType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrainerType.FlatStyle = FlatStyle.Flat;
            cmbTrainerType.Font = new Font("Segoe UI", 11F);
            cmbTrainerType.FormattingEnabled = true;
            cmbTrainerType.Items.AddRange(new object[] { "نسبة", "راتب ثابت" });
            cmbTrainerType.Location = new Point(51, 230);
            cmbTrainerType.Name = "cmbTrainerType";
            cmbTrainerType.RightToLeft = RightToLeft.Yes;
            cmbTrainerType.Size = new Size(250, 28);
            cmbTrainerType.TabIndex = 3;
            
            // 
            // labelSalary
            // 
            labelSalary.AutoSize = true;
            labelSalary.Font = new Font("Segoe UI", 10F);
            labelSalary.Location = new Point(326, 299);
            labelSalary.Name = "labelSalary";
            labelSalary.Size = new Size(65, 19);
            labelSalary.TabIndex = 4;
            labelSalary.Text = "الراتب الأساسي";
            // 
            // txtBaseSalary
            // 
            txtBaseSalary.AnimateReadOnly = false;
            txtBaseSalary.Depth = 0;
            txtBaseSalary.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBaseSalary.Location = new Point(51, 285);
            txtBaseSalary.MaxLength = 10;
            txtBaseSalary.MouseState = MaterialSkin.MouseState.OUT;
            txtBaseSalary.Name = "txtBaseSalary";
            txtBaseSalary.RightToLeft = RightToLeft.Yes;
            txtBaseSalary.Size = new Size(250, 48);
            txtBaseSalary.TabIndex = 4;
            txtBaseSalary.Text = "0";
            txtBaseSalary.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(326, 365);
            label5.Name = "label5";
            label5.Size = new Size(65, 19);
            label5.TabIndex = 5;
            label5.Text = "النسبة %";
            // 
            // txtCommissionRate
            // 
            txtCommissionRate.AnimateReadOnly = false;
            txtCommissionRate.Depth = 0;
            txtCommissionRate.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCommissionRate.Location = new Point(51, 351);
            txtCommissionRate.MaxLength = 5;
            txtCommissionRate.MouseState = MaterialSkin.MouseState.OUT;
            txtCommissionRate.Name = "txtCommissionRate";
            txtCommissionRate.RightToLeft = RightToLeft.Yes;
            txtCommissionRate.Size = new Size(250, 48);
            txtCommissionRate.TabIndex = 5;
            txtCommissionRate.Text = "0";
            txtCommissionRate.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(326, 431);
            label3.Name = "label3";
            label3.Size = new Size(47, 19);
            label3.TabIndex = 6;
            label3.Text = "القسم";
            // 
            // cmbRooms
            // 
            cmbRooms.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRooms.FlatStyle = FlatStyle.Flat;
            cmbRooms.Font = new Font("Segoe UI", 11F);
            cmbRooms.FormattingEnabled = true;
            cmbRooms.Location = new Point(51, 428);
            cmbRooms.Name = "cmbRooms";
            cmbRooms.RightToLeft = RightToLeft.Yes;
            cmbRooms.Size = new Size(250, 28);
            cmbRooms.TabIndex = 6;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(250, 500);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(124, 48);
            btnSave.TabIndex = 7;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(60, 500);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(124, 48);
            BtnCancel.TabIndex = 8;
            BtnCancel.Text = "إلغاء";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // AddTrainerForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(434, 580);
            Controls.Add(BtnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbRooms);
            Controls.Add(label3);
            Controls.Add(txtCommissionRate);
            Controls.Add(label5);
            Controls.Add(txtBaseSalary);
            Controls.Add(labelSalary);
            Controls.Add(cmbTrainerType);
            Controls.Add(labelType);
            Controls.Add(txtPhone);
            Controls.Add(label4);
            Controls.Add(txtTrainerName);
            Controls.Add(label2);
            Controls.Add(PnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddTrainerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "بيانات الموظفة";
            Load += AddTrainerForm_Load;
            PnlHeader.ResumeLayout(false);
            PnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PnlHeader;
        private Label label1;
        private Label label2;
        private MaterialSkin.Controls.MaterialTextBox2 txtTrainerName;
        private Label label4;
        private MaterialSkin.Controls.MaterialTextBox2 txtPhone;
        private Label labelType;
        private System.Windows.Forms.ComboBox cmbTrainerType;
        private Label labelSalary;
        private MaterialSkin.Controls.MaterialTextBox2 txtBaseSalary;
        private Label label5;
        private MaterialSkin.Controls.MaterialTextBox2 txtCommissionRate;
        private Label label3;
        private System.Windows.Forms.ComboBox cmbRooms;
        private Button btnSave;
        private Button BtnCancel;
    }
}
