namespace beautyCenterSystem.data.Repositories
{
    partial class UserCreateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserCreateForm));
            label3 = new Label();
            label2 = new Label();
            BtnCancel = new Button();
            btnSave = new Button();
            txtPassword = new MaterialSkin.Controls.MaterialTextBox2();
            txtUsername = new MaterialSkin.Controls.MaterialTextBox2();
            PnlHeader = new Panel();
            label1 = new Label();
            label4 = new Label();
            cmbRole = new MaterialSkin.Controls.MaterialComboBox();
            PnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(364, 232);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 16;
            label3.Text = "كلمة المرور";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(376, 156);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 15;
            label2.Text = "الإسم";
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(63, 437);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(124, 48);
            BtnCancel.TabIndex = 14;
            BtnCancel.Text = "الغاء";
            BtnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(246, 437);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(124, 48);
            btnSave.TabIndex = 13;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            txtPassword.AnimateReadOnly = false;
            txtPassword.AutoCompleteMode = AutoCompleteMode.None;
            txtPassword.AutoCompleteSource = AutoCompleteSource.None;
            txtPassword.BackgroundImageLayout = ImageLayout.None;
            txtPassword.CharacterCasing = CharacterCasing.Normal;
            txtPassword.Depth = 0;
            txtPassword.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPassword.HideSelection = true;
            txtPassword.LeadingIcon = null;
            txtPassword.Location = new Point(108, 216);
            txtPassword.MaxLength = 32767;
            txtPassword.MouseState = MaterialSkin.MouseState.OUT;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PrefixSuffixText = null;
            txtPassword.ReadOnly = false;
            txtPassword.RightToLeft = RightToLeft.Yes;
            txtPassword.SelectedText = "";
            txtPassword.SelectionLength = 0;
            txtPassword.SelectionStart = 0;
            txtPassword.ShortcutsEnabled = true;
            txtPassword.Size = new Size(250, 48);
            txtPassword.TabIndex = 11;
            txtPassword.TabStop = false;
            txtPassword.TextAlign = HorizontalAlignment.Right;
            txtPassword.TrailingIcon = null;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            txtUsername.AnimateReadOnly = false;
            txtUsername.AutoCompleteMode = AutoCompleteMode.None;
            txtUsername.AutoCompleteSource = AutoCompleteSource.None;
            txtUsername.BackgroundImageLayout = ImageLayout.None;
            txtUsername.CharacterCasing = CharacterCasing.Normal;
            txtUsername.Depth = 0;
            txtUsername.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtUsername.HideSelection = true;
            txtUsername.LeadingIcon = null;
            txtUsername.Location = new Point(108, 139);
            txtUsername.MaxLength = 32767;
            txtUsername.MouseState = MaterialSkin.MouseState.OUT;
            txtUsername.Name = "txtUsername";
            txtUsername.PasswordChar = '\0';
            txtUsername.PrefixSuffixText = null;
            txtUsername.ReadOnly = false;
            txtUsername.RightToLeft = RightToLeft.Yes;
            txtUsername.SelectedText = "";
            txtUsername.SelectionLength = 0;
            txtUsername.SelectionStart = 0;
            txtUsername.ShortcutsEnabled = true;
            txtUsername.Size = new Size(250, 48);
            txtUsername.TabIndex = 10;
            txtUsername.TabStop = false;
            txtUsername.TextAlign = HorizontalAlignment.Right;
            txtUsername.TrailingIcon = null;
            txtUsername.UseSystemPasswordChar = false;
            // 
            // PnlHeader
            // 
            PnlHeader.Controls.Add(label1);
            PnlHeader.Dock = DockStyle.Top;
            PnlHeader.Location = new Point(0, 0);
            PnlHeader.Name = "PnlHeader";
            PnlHeader.Size = new Size(434, 69);
            PnlHeader.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(140, 20);
            label1.Name = "label1";
            label1.Size = new Size(181, 28);
            label1.TabIndex = 1;
            label1.Text = "إضافة مستخدم جديد";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(349, 309);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 18;
            label4.Text = "الدور الوظيفي";
            // 
            // cmbRole
            // 
            cmbRole.AutoResize = false;
            cmbRole.BackColor = Color.FromArgb(255, 255, 255);
            cmbRole.Depth = 0;
            cmbRole.DrawMode = DrawMode.OwnerDrawVariable;
            cmbRole.DropDownHeight = 174;
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.DropDownWidth = 121;
            cmbRole.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbRole.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbRole.FormattingEnabled = true;
            cmbRole.Hint = "اختر الدور";
            cmbRole.IntegralHeight = false;
            cmbRole.ItemHeight = 43;
            cmbRole.Location = new Point(93, 291);
            cmbRole.MaxDropDownItems = 4;
            cmbRole.MouseState = MaterialSkin.MouseState.OUT;
            cmbRole.Name = "cmbRole";
            cmbRole.RightToLeft = RightToLeft.Yes;
            cmbRole.Size = new Size(250, 49);
            cmbRole.StartIndex = 0;
            cmbRole.TabIndex = 19;
            // 
            // UserCreateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 511);
            Controls.Add(cmbRole);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(BtnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(PnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "UserCreateForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "اضافة مستخدم";
            PnlHeader.ResumeLayout(false);
            PnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private Button BtnCancel;
        private Button btnSave;
        private MaterialSkin.Controls.MaterialTextBox2 txtPassword;
        private MaterialSkin.Controls.MaterialTextBox2 txtUsername;
        private Panel PnlHeader;
        private Label label1;
        private MaterialSkin.Controls.MaterialComboBox cmbRole;
        private Label label4;
    }
}