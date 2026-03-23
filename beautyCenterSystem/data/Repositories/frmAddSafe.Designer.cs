namespace beautyCenterSystem.data.Repositories
{
    partial class frmAddSafe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddSafe));
            PnlHeader = new Panel();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtInitialBalance = new MaterialSkin.Controls.MaterialTextBox2();
            txtSafeName = new MaterialSkin.Controls.MaterialTextBox2();
            BtnCancel = new Button();
            btnSaveSafe = new Button();
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
            PnlHeader.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(140, 20);
            label1.Name = "label1";
            label1.Size = new Size(156, 28);
            label1.TabIndex = 1;
            label1.Text = "إضافة خزنة جديدة";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(335, 227);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 24;
            label3.Text = "الرصيد الافتتاحي";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(348, 170);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(58, 15);
            label2.TabIndex = 23;
            label2.Text = "اسم الخزنة";
            // 
            // txtInitialBalance
            // 
            txtInitialBalance.AnimateReadOnly = false;
            txtInitialBalance.AutoCompleteMode = AutoCompleteMode.None;
            txtInitialBalance.AutoCompleteSource = AutoCompleteSource.None;
            txtInitialBalance.BackgroundImageLayout = ImageLayout.None;
            txtInitialBalance.CharacterCasing = CharacterCasing.Normal;
            txtInitialBalance.Depth = 0;
            txtInitialBalance.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtInitialBalance.HideSelection = true;
            txtInitialBalance.LeadingIcon = null;
            txtInitialBalance.Location = new Point(242, 208);
            txtInitialBalance.MaxLength = 32767;
            txtInitialBalance.MouseState = MaterialSkin.MouseState.OUT;
            txtInitialBalance.Name = "txtInitialBalance";
            txtInitialBalance.PasswordChar = '\0';
            txtInitialBalance.PrefixSuffixText = "د.ل";
            txtInitialBalance.ReadOnly = false;
            txtInitialBalance.RightToLeft = RightToLeft.Yes;
            txtInitialBalance.SelectedText = "";
            txtInitialBalance.SelectionLength = 0;
            txtInitialBalance.SelectionStart = 0;
            txtInitialBalance.ShortcutsEnabled = true;
            txtInitialBalance.Size = new Size(85, 48);
            txtInitialBalance.TabIndex = 20;
            txtInitialBalance.TabStop = false;
            txtInitialBalance.Text = "0.00";
            txtInitialBalance.TextAlign = HorizontalAlignment.Right;
            txtInitialBalance.TrailingIcon = null;
            txtInitialBalance.UseSystemPasswordChar = false;
            txtInitialBalance.KeyPress += txtInitialBalance_KeyPress;
            // 
            // txtSafeName
            // 
            txtSafeName.AnimateReadOnly = false;
            txtSafeName.AutoCompleteMode = AutoCompleteMode.None;
            txtSafeName.AutoCompleteSource = AutoCompleteSource.None;
            txtSafeName.BackgroundImageLayout = ImageLayout.None;
            txtSafeName.CharacterCasing = CharacterCasing.Normal;
            txtSafeName.Depth = 0;
            txtSafeName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSafeName.HideSelection = true;
            txtSafeName.LeadingIcon = null;
            txtSafeName.Location = new Point(77, 154);
            txtSafeName.MaxLength = 32767;
            txtSafeName.MouseState = MaterialSkin.MouseState.OUT;
            txtSafeName.Name = "txtSafeName";
            txtSafeName.PasswordChar = '\0';
            txtSafeName.PrefixSuffixText = null;
            txtSafeName.ReadOnly = false;
            txtSafeName.RightToLeft = RightToLeft.Yes;
            txtSafeName.SelectedText = "";
            txtSafeName.SelectionLength = 0;
            txtSafeName.SelectionStart = 0;
            txtSafeName.ShortcutsEnabled = true;
            txtSafeName.Size = new Size(250, 48);
            txtSafeName.TabIndex = 19;
            txtSafeName.TabStop = false;
            txtSafeName.TextAlign = HorizontalAlignment.Right;
            txtSafeName.TrailingIcon = null;
            txtSafeName.UseSystemPasswordChar = false;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(77, 347);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(124, 48);
            BtnCancel.TabIndex = 18;
            BtnCancel.Text = "الغاء";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += btnCancel_Click;
            // 
            // btnSaveSafe
            // 
            btnSaveSafe.Location = new Point(260, 347);
            btnSaveSafe.Name = "btnSaveSafe";
            btnSaveSafe.Size = new Size(124, 48);
            btnSaveSafe.TabIndex = 17;
            btnSaveSafe.Text = "حفظ";
            btnSaveSafe.UseVisualStyleBackColor = true;
            btnSaveSafe.Click += btnSaveSafe_Click;
            // 
            // frmAddSafe
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(434, 398);
            Controls.Add(PnlHeader);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtInitialBalance);
            Controls.Add(txtSafeName);
            Controls.Add(BtnCancel);
            Controls.Add(btnSaveSafe);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmAddSafe";
            StartPosition = FormStartPosition.CenterParent;
            Text = "اضافة خزنة";
            Load += frmAddSafe_Load;
            PnlHeader.ResumeLayout(false);
            PnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PnlHeader;
        private Label label1;
        private Label label3;
        private Label label2;
        private MaterialSkin.Controls.MaterialTextBox2 txtInitialBalance;
        private MaterialSkin.Controls.MaterialTextBox2 txtSafeName;
        private Button BtnCancel;
        private Button btnSaveSafe;
    }
}