namespace beautyCenterSystem.data.Repositories
{
    partial class UserEditForm
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
            label2 = new Label();
            BtnCancel = new Button();
            btnSave = new Button();
            txtUsername = new MaterialSkin.Controls.MaterialTextBox2();
            PnlHeader = new Panel();
            label1 = new Label();
            label4 = new Label();
            cmbRole = new MaterialSkin.Controls.MaterialComboBox();
            PnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(376, 169);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 24;
            label2.Text = "الإسم";
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(63, 450);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(124, 48);
            BtnCancel.TabIndex = 23;
            BtnCancel.Text = "الغاء";
            BtnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(246, 450);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(124, 48);
            btnSave.TabIndex = 22;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
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
            txtUsername.Location = new Point(108, 152);
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
            txtUsername.TabIndex = 20;
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
            PnlHeader.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(140, 20);
            label1.Name = "label1";
            label1.Size = new Size(202, 28);
            label1.TabIndex = 1;
            label1.Text = "تعديل بيانات المستخدم";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(349, 259);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 27;
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
            cmbRole.IntegralHeight = false;
            cmbRole.ItemHeight = 43;
            cmbRole.Location = new Point(222, 239);
            cmbRole.MaxDropDownItems = 4;
            cmbRole.MouseState = MaterialSkin.MouseState.OUT;
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(121, 49);
            cmbRole.StartIndex = 0;
            cmbRole.TabIndex = 26;
            // 
            // UserEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 511);
            Controls.Add(label2);
            Controls.Add(BtnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtUsername);
            Controls.Add(PnlHeader);
            Controls.Add(label4);
            Controls.Add(cmbRole);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "UserEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "تعديل بيانات مستخدم";
            PnlHeader.ResumeLayout(false);
            PnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button BtnCancel;
        private Button btnSave;
        private MaterialSkin.Controls.MaterialTextBox2 txtUsername;
        private Panel PnlHeader;
        private Label label1;
        private Label label4;
        private MaterialSkin.Controls.MaterialComboBox cmbRole;
    }
}