namespace beautyCenterSystem.data.Repositories
{
    partial class RoleCreateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleCreateForm));
            label2 = new Label();
            txtRoleName = new MaterialSkin.Controls.MaterialTextBox2();
            PnlHeader = new Panel();
            label1 = new Label();
            BtnCancel = new Button();
            btnSave = new Button();
            PnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(356, 200);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 23;
            label2.Text = "أسم الدور";
            // 
            // txtRoleName
            // 
            txtRoleName.AnimateReadOnly = false;
            txtRoleName.AutoCompleteMode = AutoCompleteMode.None;
            txtRoleName.AutoCompleteSource = AutoCompleteSource.None;
            txtRoleName.BackgroundImageLayout = ImageLayout.None;
            txtRoleName.CharacterCasing = CharacterCasing.Normal;
            txtRoleName.Depth = 0;
            txtRoleName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtRoleName.HideSelection = true;
            txtRoleName.LeadingIcon = null;
            txtRoleName.Location = new Point(79, 180);
            txtRoleName.MaxLength = 32767;
            txtRoleName.MouseState = MaterialSkin.MouseState.OUT;
            txtRoleName.Name = "txtRoleName";
            txtRoleName.PasswordChar = '\0';
            txtRoleName.PrefixSuffixText = null;
            txtRoleName.ReadOnly = false;
            txtRoleName.RightToLeft = RightToLeft.Yes;
            txtRoleName.SelectedText = "";
            txtRoleName.SelectionLength = 0;
            txtRoleName.SelectionStart = 0;
            txtRoleName.ShortcutsEnabled = true;
            txtRoleName.Size = new Size(250, 48);
            txtRoleName.TabIndex = 22;
            txtRoleName.TabStop = false;
            txtRoleName.TextAlign = HorizontalAlignment.Right;
            txtRoleName.TrailingIcon = null;
            txtRoleName.UseSystemPasswordChar = false;
            // 
            // PnlHeader
            // 
            PnlHeader.Controls.Add(label1);
            PnlHeader.Dock = DockStyle.Top;
            PnlHeader.Location = new Point(0, 0);
            PnlHeader.Name = "PnlHeader";
            PnlHeader.Size = new Size(434, 69);
            PnlHeader.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(160, 23);
            label1.Name = "label1";
            label1.Size = new Size(139, 28);
            label1.TabIndex = 1;
            label1.Text = "إضافة دور جديد";
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(65, 313);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(124, 48);
            BtnCancel.TabIndex = 29;
            BtnCancel.Text = "الغاء";
            BtnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(248, 313);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(124, 48);
            btnSave.TabIndex = 28;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // RoleCreateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 424);
            Controls.Add(BtnCancel);
            Controls.Add(btnSave);
            Controls.Add(label2);
            Controls.Add(txtRoleName);
            Controls.Add(PnlHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "RoleCreateForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "إضافة دور جديد";
            PnlHeader.ResumeLayout(false);
            PnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private MaterialSkin.Controls.MaterialTextBox2 txtRoleName;
        private Panel PnlHeader;
        private Label label1;
        private Button BtnCancel;
        private Button btnSave;
    }
}