namespace beautyCenterSystem
{
    partial class TrainerPaymentForm
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
            lblTrainer = new Label();
            lblTotalEarned = new Label();
            txtTotalEarned = new TextBox();
            lblTotalPaid = new Label();
            txtTotalPaid = new TextBox();
            lblRemaining = new Label();
            txtRemainingBalance = new TextBox();
            lblTreasury = new Label();
            cmbSafe = new ComboBox();
            lblAmount = new Label();
            txtAmountToPay = new TextBox();
            lblNotes = new Label();
            txtNotes = new TextBox();
            btnSave = new Button();
            BtnCancel = new Button();
            cmbTrainer = new ComboBox();
            PnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // PnlHeader
            // 
            PnlHeader.BackColor = Color.FromArgb(0, 150, 136);
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
            label1.ForeColor = Color.White;
            label1.Location = new Point(160, 20);
            label1.Name = "label1";
            label1.Size = new Size(226, 30);
            label1.TabIndex = 0;
            label1.Text = "صرف مستحقات مدربة";
            // 
            // lblTrainer
            // 
            lblTrainer.AutoSize = true;
            lblTrainer.Font = new Font("Segoe UI", 11F);
            lblTrainer.Location = new Point(400, 95);
            lblTrainer.Name = "lblTrainer";
            lblTrainer.Size = new Size(94, 20);
            lblTrainer.TabIndex = 1;
            lblTrainer.Text = "اسم المدربة";
            // 
            // cmbTrainer
            // 
            cmbTrainer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrainer.Font = new Font("Segoe UI", 11F);
            cmbTrainer.FormattingEnabled = true;
            cmbTrainer.Location = new Point(50, 92);
            cmbTrainer.Name = "cmbTrainer";
            cmbTrainer.RightToLeft = RightToLeft.Yes;
            cmbTrainer.Size = new Size(320, 28);
            cmbTrainer.TabIndex = 17;
            // 
            // lblTotalEarned
            // 
            lblTotalEarned.AutoSize = true;
            lblTotalEarned.Font = new Font("Segoe UI", 10F);
            lblTotalEarned.Location = new Point(400, 145);
            lblTotalEarned.Name = "lblTotalEarned";
            lblTotalEarned.Size = new Size(120, 19);
            lblTotalEarned.TabIndex = 3;
            lblTotalEarned.Text = "إجمالي المستحقات";
            // 
            // txtTotalEarned
            // 
            txtTotalEarned.BackColor = Color.FromArgb(245, 245, 245);
            txtTotalEarned.Font = new Font("Segoe UI", 12F);
            txtTotalEarned.Location = new Point(50, 140);
            txtTotalEarned.Name = "txtTotalEarned";
            txtTotalEarned.ReadOnly = true;
            txtTotalEarned.RightToLeft = RightToLeft.Yes;
            txtTotalEarned.Size = new Size(320, 29);
            txtTotalEarned.TabIndex = 4;
            txtTotalEarned.Text = "0.00";
            txtTotalEarned.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTotalPaid
            // 
            lblTotalPaid.AutoSize = true;
            lblTotalPaid.Font = new Font("Segoe UI", 10F);
            lblTotalPaid.Location = new Point(400, 195);
            lblTotalPaid.Name = "lblTotalPaid";
            lblTotalPaid.Size = new Size(110, 19);
            lblTotalPaid.TabIndex = 5;
            lblTotalPaid.Text = "إجمالي المصروف";
            // 
            // txtTotalPaid
            // 
            txtTotalPaid.BackColor = Color.FromArgb(245, 245, 245);
            txtTotalPaid.Font = new Font("Segoe UI", 12F);
            txtTotalPaid.Location = new Point(50, 190);
            txtTotalPaid.Name = "txtTotalPaid";
            txtTotalPaid.ReadOnly = true;
            txtTotalPaid.RightToLeft = RightToLeft.Yes;
            txtTotalPaid.Size = new Size(320, 29);
            txtTotalPaid.TabIndex = 6;
            txtTotalPaid.Text = "0.00";
            txtTotalPaid.TextAlign = HorizontalAlignment.Center;
            // 
            // lblRemaining
            // 
            lblRemaining.AutoSize = true;
            lblRemaining.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRemaining.ForeColor = Color.DarkGreen;
            lblRemaining.Location = new Point(400, 245);
            lblRemaining.Name = "lblRemaining";
            lblRemaining.Size = new Size(104, 20);
            lblRemaining.TabIndex = 7;
            lblRemaining.Text = "الرصيد المتبقي";
            // 
            // txtRemainingBalance
            // 
            txtRemainingBalance.BackColor = Color.FromArgb(232, 245, 233);
            txtRemainingBalance.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            txtRemainingBalance.ForeColor = Color.DarkGreen;
            txtRemainingBalance.Location = new Point(50, 240);
            txtRemainingBalance.Name = "txtRemainingBalance";
            txtRemainingBalance.ReadOnly = true;
            txtRemainingBalance.RightToLeft = RightToLeft.Yes;
            txtRemainingBalance.Size = new Size(320, 31);
            txtRemainingBalance.TabIndex = 8;
            txtRemainingBalance.Text = "0.00";
            txtRemainingBalance.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTreasury
            // 
            lblTreasury.AutoSize = true;
            lblTreasury.Font = new Font("Segoe UI", 11F);
            lblTreasury.Location = new Point(400, 300);
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
            cmbSafe.Location = new Point(50, 297);
            cmbSafe.Name = "cmbSafe";
            cmbSafe.RightToLeft = RightToLeft.Yes;
            cmbSafe.Size = new Size(320, 28);
            cmbSafe.TabIndex = 10;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAmount.Location = new Point(400, 350);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(124, 20);
            lblAmount.TabIndex = 11;
            lblAmount.Text = "المبلغ المراد صرفه";
            // 
            // txtAmountToPay
            // 
            txtAmountToPay.Font = new Font("Segoe UI", 12F);
            txtAmountToPay.Location = new Point(50, 345);
            txtAmountToPay.Name = "txtAmountToPay";
            txtAmountToPay.RightToLeft = RightToLeft.Yes;
            txtAmountToPay.Size = new Size(320, 29);
            txtAmountToPay.TabIndex = 12;
            txtAmountToPay.TextAlign = HorizontalAlignment.Center;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 10F);
            lblNotes.Location = new Point(400, 400);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(63, 19);
            lblNotes.TabIndex = 13;
            lblNotes.Text = "ملاحظات";
            // 
            // txtNotes
            // 
            txtNotes.Font = new Font("Segoe UI", 11F);
            txtNotes.Location = new Point(50, 395);
            txtNotes.Name = "txtNotes";
            txtNotes.RightToLeft = RightToLeft.Yes;
            txtNotes.Size = new Size(320, 27);
            txtNotes.TabIndex = 14;
            txtNotes.Text = "صرف مستحقات مدربة";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 150, 136);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(270, 450);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 45);
            btnSave.TabIndex = 15;
            btnSave.Text = "إتمام الصرف";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // BtnCancel
            // 
            BtnCancel.BackColor = Color.FromArgb(200, 200, 200);
            BtnCancel.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatStyle = FlatStyle.Flat;
            BtnCancel.Font = new Font("Segoe UI", 11F);
            BtnCancel.Location = new Point(100, 450);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(140, 45);
            BtnCancel.TabIndex = 16;
            BtnCancel.Text = "إلغاء";
            BtnCancel.UseVisualStyleBackColor = false;
            // 
            // TrainerPaymentForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(534, 520);
            Controls.Add(cmbTrainer);
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
            Controls.Add(txtTotalPaid);
            Controls.Add(lblTotalPaid);
            Controls.Add(txtTotalEarned);
            Controls.Add(lblTotalEarned);
            Controls.Add(lblTrainer);
            Controls.Add(PnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TrainerPaymentForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "صرف مستحقات مدربة";
            PnlHeader.ResumeLayout(false);
            PnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PnlHeader;
        private Label label1;
        private Label lblTrainer;
        private Label lblTotalEarned;
        private TextBox txtTotalEarned;
        private Label lblTotalPaid;
        private TextBox txtTotalPaid;
        private Label lblRemaining;
        private TextBox txtRemainingBalance;
        private Label lblTreasury;
        private ComboBox cmbSafe;
        private Label lblAmount;
        private TextBox txtAmountToPay;
        private Label lblNotes;
        private TextBox txtNotes;
        private Button btnSave;
        private Button BtnCancel;
        private ComboBox cmbTrainer;
    }
}
