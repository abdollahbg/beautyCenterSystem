namespace beautyCenterSystem
{
    partial class AddMaterialForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMaterialForm));
            label3 = new Label();
            PnlHeader = new Panel();
            label1 = new Label();
            chkIsAvailable = new MaterialSkin.Controls.MaterialCheckbox();
            label2 = new Label();
            BtnCancel = new Button();
            btnSave = new Button();
            txtMaterialName = new MaterialSkin.Controls.MaterialTextBox2();
            PnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(364, 204);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 16;
            label3.Text = "متوفر";
            // 
            // PnlHeader
            // 
            PnlHeader.Controls.Add(label1);
            PnlHeader.Dock = DockStyle.Top;
            PnlHeader.Location = new Point(0, 0);
            PnlHeader.Name = "PnlHeader";
            PnlHeader.Size = new Size(434, 69);
            PnlHeader.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(140, 20);
            label1.Name = "label1";
            label1.Size = new Size(156, 28);
            label1.TabIndex = 1;
            label1.Text = "إضافة عنصر جديد";
            // 
            // chkIsAvailable
            // 
            chkIsAvailable.AutoSize = true;
            chkIsAvailable.Checked = true;
            chkIsAvailable.CheckState = CheckState.Checked;
            chkIsAvailable.Depth = 0;
            chkIsAvailable.Location = new Point(307, 198);
            chkIsAvailable.Margin = new Padding(0);
            chkIsAvailable.MouseLocation = new Point(-1, -1);
            chkIsAvailable.MouseState = MaterialSkin.MouseState.HOVER;
            chkIsAvailable.Name = "chkIsAvailable";
            chkIsAvailable.ReadOnly = false;
            chkIsAvailable.Ripple = true;
            chkIsAvailable.Size = new Size(35, 37);
            chkIsAvailable.TabIndex = 17;
            chkIsAvailable.TextAlign = ContentAlignment.MiddleCenter;
            chkIsAvailable.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(345, 133);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 15;
            label2.Text = "إسم المادة";
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(70, 343);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(124, 48);
            BtnCancel.TabIndex = 14;
            BtnCancel.Text = "الغاء";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(253, 343);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(124, 48);
            btnSave.TabIndex = 13;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtMaterialName
            // 
            txtMaterialName.AnimateReadOnly = false;
            txtMaterialName.AutoCompleteMode = AutoCompleteMode.None;
            txtMaterialName.AutoCompleteSource = AutoCompleteSource.None;
            txtMaterialName.BackgroundImageLayout = ImageLayout.None;
            txtMaterialName.CharacterCasing = CharacterCasing.Normal;
            txtMaterialName.Depth = 0;
            txtMaterialName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMaterialName.HideSelection = true;
            txtMaterialName.LeadingIcon = null;
            txtMaterialName.Location = new Point(70, 116);
            txtMaterialName.MaxLength = 32767;
            txtMaterialName.MouseState = MaterialSkin.MouseState.OUT;
            txtMaterialName.Name = "txtMaterialName";
            txtMaterialName.PasswordChar = '\0';
            txtMaterialName.PrefixSuffixText = null;
            txtMaterialName.ReadOnly = false;
            txtMaterialName.RightToLeft = RightToLeft.Yes;
            txtMaterialName.SelectedText = "";
            txtMaterialName.SelectionLength = 0;
            txtMaterialName.SelectionStart = 0;
            txtMaterialName.ShortcutsEnabled = true;
            txtMaterialName.Size = new Size(250, 48);
            txtMaterialName.TabIndex = 12;
            txtMaterialName.TabStop = false;
            txtMaterialName.TextAlign = HorizontalAlignment.Right;
            txtMaterialName.TrailingIcon = null;
            txtMaterialName.UseSystemPasswordChar = false;
            // 
            // AddMaterialForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(434, 407);
            Controls.Add(label3);
            Controls.Add(PnlHeader);
            Controls.Add(chkIsAvailable);
            Controls.Add(label2);
            Controls.Add(BtnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtMaterialName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AddMaterialForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "اضافة عنصر";
            Load += AddMaterialForm_Load;
            PnlHeader.ResumeLayout(false);
            PnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Panel PnlHeader;
        private Label label1;
        private MaterialSkin.Controls.MaterialCheckbox chkIsAvailable;
        private Label label2;
        private Button BtnCancel;
        private Button btnSave;
        private MaterialSkin.Controls.MaterialTextBox2 txtMaterialName;
    }
}