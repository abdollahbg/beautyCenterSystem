namespace beautyCenterSystem.data.Repositories
{
    partial class EmployeePaymentForm
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
            lblEmployee = new Label();

            lblRemaining = new Label();
            txtRemainingBalance = new MaterialSkin.Controls.MaterialTextBox2();
            lblTreasury = new Label();
            cmbSafe = new System.Windows.Forms.ComboBox();
            lblAmount = new Label();
            txtAmountToPay = new MaterialSkin.Controls.MaterialTextBox2();
            lblNotes = new Label();
            txtNotes = new MaterialSkin.Controls.MaterialTextBox2();
            btnSave = new Button();
            BtnCancel = new Button();
            cmbEmployee = new ComboBox();
            PnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // PnlHeader
            // 
            PnlHeader.Controls.Add(label1);
            PnlHeader.Dock = DockStyle.Top;
            PnlHeader.Location = new Point(0, 0);
            PnlHeader.Name = "PnlHeader";
            PnlHeader.Size = new Size(534, 70);
            PnlHeader.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(170, 20);
            label1.Name = "label1";
            label1.Size = new Size(226, 30);
            label1.TabIndex = 0;
            label1.Text = "صرف مستحقات موظفة";
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.Font = new Font("Segoe UI", 11F);
            lblEmployee.Location = new Point(400, 105);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(94, 20);
            lblEmployee.TabIndex = 1;
            lblEmployee.Text = "اسم الموظفة";
            // 
            // 
            // 
            // lblRemaining
            // 
            lblRemaining.AutoSize = true;
            lblRemaining.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRemaining.ForeColor = Color.DarkGreen;
            lblRemaining.Location = new Point(400, 175);
            lblRemaining.Name = "lblRemaining";
            lblRemaining.Size = new Size(130, 20);
            lblRemaining.TabIndex = 7;
            lblRemaining.Text = "مستحقات الموظفة";
            // 
            // txtRemainingBalance
            // 
            txtRemainingBalance.AnimateReadOnly = false;
            txtRemainingBalance.AutoCompleteMode = AutoCompleteMode.None;
            txtRemainingBalance.AutoCompleteSource = AutoCompleteSource.None;
            txtRemainingBalance.BackgroundImageLayout = ImageLayout.None;
            txtRemainingBalance.CharacterCasing = CharacterCasing.Normal;
            txtRemainingBalance.Depth = 0;
            txtRemainingBalance.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtRemainingBalance.HideSelection = true;
            txtRemainingBalance.LeadingIcon = null;
            txtRemainingBalance.Location = new Point(50, 160);
            txtRemainingBalance.MaxLength = 50;
            txtRemainingBalance.MouseState = MaterialSkin.MouseState.OUT;
            txtRemainingBalance.Name = "txtRemainingBalance";
            txtRemainingBalance.PasswordChar = '\0';
            txtRemainingBalance.PrefixSuffixText = null;
            txtRemainingBalance.ReadOnly = true;
            txtRemainingBalance.RightToLeft = RightToLeft.Yes;
            txtRemainingBalance.SelectedText = "";
            txtRemainingBalance.SelectionLength = 0;
            txtRemainingBalance.SelectionStart = 0;
            txtRemainingBalance.ShortcutsEnabled = true;
            txtRemainingBalance.Size = new Size(320, 48);
            txtRemainingBalance.TabIndex = 8;
            txtRemainingBalance.TabStop = false;
            txtRemainingBalance.Text = "0.00";
            txtRemainingBalance.TextAlign = HorizontalAlignment.Center;
            txtRemainingBalance.TrailingIcon = null;
            txtRemainingBalance.UseSystemPasswordChar = false;
            // 
            // lblTreasury
            // 
            lblTreasury.AutoSize = true;
            lblTreasury.Font = new Font("Segoe UI", 11F);
            lblTreasury.Location = new Point(400, 245);
            lblTreasury.Name = "lblTreasury";
            lblTreasury.Size = new Size(52, 20);
            lblTreasury.TabIndex = 9;
            lblTreasury.Text = "الخزينة";
            // 
            // cmbSafe
            // 
            cmbSafe.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSafe.FlatStyle = FlatStyle.Flat;
            cmbSafe.Font = new Font("Segoe UI", 11F);
            cmbSafe.FormattingEnabled = true;
            cmbSafe.Location = new Point(50, 230);
            cmbSafe.MaxDropDownItems = 4;
            cmbSafe.Name = "cmbSafe";
            cmbSafe.RightToLeft = RightToLeft.Yes;
            cmbSafe.Size = new Size(320, 28);
            cmbSafe.TabIndex = 10;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAmount.Location = new Point(400, 315);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(124, 20);
            lblAmount.TabIndex = 11;
            lblAmount.Text = "المبلغ المراد صرفه";
            // 
            // txtAmountToPay
            // 
            txtAmountToPay.AnimateReadOnly = false;
            txtAmountToPay.AutoCompleteMode = AutoCompleteMode.None;
            txtAmountToPay.AutoCompleteSource = AutoCompleteSource.None;
            txtAmountToPay.BackgroundImageLayout = ImageLayout.None;
            txtAmountToPay.CharacterCasing = CharacterCasing.Normal;
            txtAmountToPay.Depth = 0;
            txtAmountToPay.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAmountToPay.HideSelection = true;
            txtAmountToPay.LeadingIcon = null;
            txtAmountToPay.Location = new Point(50, 300);
            txtAmountToPay.MaxLength = 10;
            txtAmountToPay.MouseState = MaterialSkin.MouseState.OUT;
            txtAmountToPay.Name = "txtAmountToPay";
            txtAmountToPay.PasswordChar = '\0';
            txtAmountToPay.PrefixSuffixText = null;
            txtAmountToPay.ReadOnly = false;
            txtAmountToPay.RightToLeft = RightToLeft.Yes;
            txtAmountToPay.SelectedText = "";
            txtAmountToPay.SelectionLength = 0;
            txtAmountToPay.SelectionStart = 0;
            txtAmountToPay.ShortcutsEnabled = true;
            txtAmountToPay.Size = new Size(320, 48);
            txtAmountToPay.TabIndex = 12;
            txtAmountToPay.TabStop = false;
            txtAmountToPay.TextAlign = HorizontalAlignment.Center;
            txtAmountToPay.TrailingIcon = null;
            txtAmountToPay.UseSystemPasswordChar = false;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 10F);
            lblNotes.Location = new Point(400, 385);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(63, 19);
            lblNotes.TabIndex = 13;
            lblNotes.Text = "ملاحظات";
            // 
            // txtNotes
            // 
            txtNotes.AnimateReadOnly = false;
            txtNotes.AutoCompleteMode = AutoCompleteMode.None;
            txtNotes.AutoCompleteSource = AutoCompleteSource.None;
            txtNotes.BackgroundImageLayout = ImageLayout.None;
            txtNotes.CharacterCasing = CharacterCasing.Normal;
            txtNotes.Depth = 0;
            txtNotes.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNotes.HideSelection = true;
            txtNotes.LeadingIcon = null;
            txtNotes.Location = new Point(50, 370);
            txtNotes.MaxLength = 200;
            txtNotes.MouseState = MaterialSkin.MouseState.OUT;
            txtNotes.Name = "txtNotes";
            txtNotes.PasswordChar = '\0';
            txtNotes.PrefixSuffixText = null;
            txtNotes.ReadOnly = false;
            txtNotes.RightToLeft = RightToLeft.Yes;
            txtNotes.SelectedText = "";
            txtNotes.SelectionLength = 0;
            txtNotes.SelectionStart = 0;
            txtNotes.ShortcutsEnabled = true;
            txtNotes.Size = new Size(320, 48);
            txtNotes.TabIndex = 14;
            txtNotes.TabStop = false;
            txtNotes.Text = "صرف مستحقات";
            txtNotes.TextAlign = HorizontalAlignment.Right;
            txtNotes.TrailingIcon = null;
            txtNotes.UseSystemPasswordChar = false;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.Location = new Point(320, 450);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 50);
            btnSave.TabIndex = 15;
            btnSave.Text = "إتمام الصرف";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            BtnCancel.Font = new Font("Segoe UI", 11F);
            BtnCancel.Location = new Point(80, 450);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(140, 50);
            BtnCancel.TabIndex = 16;
            BtnCancel.Text = "إلغاء";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // cmbEmployee
            // 
            cmbEmployee.Font = new Font("Segoe UI", 11F);
            cmbEmployee.FormattingEnabled = true;
            cmbEmployee.Location = new Point(50, 102);
            cmbEmployee.Name = "cmbEmployee";
            cmbEmployee.Size = new Size(320, 28);
            cmbEmployee.TabIndex = 17;
            // 
            // EmployeePaymentForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(534, 540);
            Controls.Add(cmbEmployee);
            Controls.Add(BtnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtNotes);
            Controls.Add(lblNotes);
            Controls.Add(txtAmountToPay);
            Controls.Add(lblAmount);
            Controls.Add(cmbSafe);
            Controls.Add(lblTreasury);
            Controls.Add(txtRemainingBalance);
            Controls.Add(lblRemaining);
            Controls.Add(lblEmployee);
            Controls.Add(PnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmployeePaymentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "صرف مستحقات موظفة";
            PnlHeader.ResumeLayout(false);
            PnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel PnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblRemaining;
        private MaterialSkin.Controls.MaterialTextBox2 txtRemainingBalance;
        private System.Windows.Forms.Label lblTreasury;
        private System.Windows.Forms.ComboBox cmbSafe;
        private System.Windows.Forms.Label lblAmount;
        private MaterialSkin.Controls.MaterialTextBox2 txtAmountToPay;
        private System.Windows.Forms.Label lblNotes;
        private MaterialSkin.Controls.MaterialTextBox2 txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button BtnCancel;
        private ComboBox cmbEmployee;
    }
}