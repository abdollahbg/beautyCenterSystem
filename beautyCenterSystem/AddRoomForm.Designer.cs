namespace beautyCenterSystem
{
    partial class AddRoomForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRoomForm));
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            BtnCancel = new Button();
            btnSave = new Button();
            txtRoomName2 = new MaterialSkin.Controls.MaterialTextBox2();
            txtIconPath = new MaterialSkin.Controls.MaterialTextBox2();
            btnBrowseIcon = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(434, 75);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(165, 23);
            label1.Name = "label1";
            label1.Size = new Size(105, 28);
            label1.TabIndex = 0;
            label1.Text = "إضافة غرفة";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(362, 104);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 1;
            label2.Text = "إسم الغرفة";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(362, 175);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 9;
            label3.Text = "أيقونة الغرفة";
            // 
            // txtRoomName2
            // 
            txtRoomName2.AnimateReadOnly = false;
            txtRoomName2.AutoCompleteMode = AutoCompleteMode.None;
            txtRoomName2.AutoCompleteSource = AutoCompleteSource.None;
            txtRoomName2.BackgroundImageLayout = ImageLayout.None;
            txtRoomName2.CharacterCasing = CharacterCasing.Normal;
            txtRoomName2.Depth = 0;
            txtRoomName2.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtRoomName2.HideSelection = true;
            txtRoomName2.LeadingIcon = null;
            txtRoomName2.Location = new Point(49, 87);
            txtRoomName2.MaxLength = 32767;
            txtRoomName2.MouseState = MaterialSkin.MouseState.OUT;
            txtRoomName2.Name = "txtRoomName2";
            txtRoomName2.PasswordChar = '\0';
            txtRoomName2.PrefixSuffixText = null;
            txtRoomName2.ReadOnly = false;
            txtRoomName2.RightToLeft = RightToLeft.Yes;
            txtRoomName2.SelectedText = "";
            txtRoomName2.SelectionLength = 0;
            txtRoomName2.SelectionStart = 0;
            txtRoomName2.ShortcutsEnabled = true;
            txtRoomName2.Size = new Size(307, 48);
            txtRoomName2.TabIndex = 8;
            txtRoomName2.TabStop = false;
            txtRoomName2.TextAlign = HorizontalAlignment.Right;
            txtRoomName2.TrailingIcon = null;
            txtRoomName2.UseSystemPasswordChar = false;
            // 
            // txtIconPath
            // 
            txtIconPath.AnimateReadOnly = false;
            txtIconPath.AutoCompleteMode = AutoCompleteMode.None;
            txtIconPath.AutoCompleteSource = AutoCompleteSource.None;
            txtIconPath.BackgroundImageLayout = ImageLayout.None;
            txtIconPath.CharacterCasing = CharacterCasing.Normal;
            txtIconPath.Depth = 0;
            txtIconPath.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtIconPath.HideSelection = true;
            txtIconPath.LeadingIcon = null;
            txtIconPath.Location = new Point(100, 158);
            txtIconPath.MaxLength = 32767;
            txtIconPath.MouseState = MaterialSkin.MouseState.OUT;
            txtIconPath.Name = "txtIconPath";
            txtIconPath.PasswordChar = '\0';
            txtIconPath.PrefixSuffixText = null;
            txtIconPath.ReadOnly = true;
            txtIconPath.RightToLeft = RightToLeft.Yes;
            txtIconPath.SelectedText = "";
            txtIconPath.SelectionLength = 0;
            txtIconPath.SelectionStart = 0;
            txtIconPath.ShortcutsEnabled = true;
            txtIconPath.Size = new Size(256, 48);
            txtIconPath.TabIndex = 10;
            txtIconPath.TabStop = false;
            txtIconPath.TextAlign = HorizontalAlignment.Right;
            txtIconPath.TrailingIcon = null;
            txtIconPath.UseSystemPasswordChar = false;
            // 
            // btnBrowseIcon
            // 
            btnBrowseIcon.Location = new Point(49, 158);
            btnBrowseIcon.Name = "btnBrowseIcon";
            btnBrowseIcon.Size = new Size(45, 48);
            btnBrowseIcon.TabIndex = 11;
            btnBrowseIcon.Text = "...";
            btnBrowseIcon.UseVisualStyleBackColor = true;
            btnBrowseIcon.Click += btnBrowseIcon_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(58, 245);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(124, 48);
            BtnCancel.TabIndex = 7;
            BtnCancel.Text = "الغاء";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(241, 245);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(124, 48);
            btnSave.TabIndex = 6;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // AddRoomForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 315);
            Controls.Add(btnBrowseIcon);
            Controls.Add(txtIconPath);
            Controls.Add(label3);
            Controls.Add(txtRoomName2);
            Controls.Add(BtnCancel);
            Controls.Add(btnSave);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AddRoomForm";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterParent;
            Text = "اضافة غرفة";
            Load += AddRoomForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button BtnCancel;
        private Button btnSave;
        private MaterialSkin.Controls.MaterialTextBox2 txtRoomName2;
        private MaterialSkin.Controls.MaterialTextBox2 txtIconPath;
        private Button btnBrowseIcon;
    }
}