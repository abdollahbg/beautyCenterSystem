namespace beautyCenterSystem.data.Repositories
{
    partial class FrmDailyClosure
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
            cardSystemInfo = new MaterialSkin.Controls.MaterialCard();
            lblExpectedCash = new Label();
            lblTitleExpected = new Label();
            lblOutgoings = new Label();
            lblTitleOutgoings = new Label();
            lblCardSystem = new Label();
            lblTitleCardSystem = new Label();
            lblCashSystem = new Label();
            lblTitleCashSystem = new Label();
            lblSystemSectionTitle = new Label();
            cardActualInfo = new MaterialSkin.Controls.MaterialCard();
            txtNotes = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            lblDifference = new Label();
            txtActualCash = new MaterialSkin.Controls.MaterialTextBox2();
            lblWarning = new Label();
            btnSaveClosure = new FontAwesome.Sharp.IconButton();
            btnCancel = new FontAwesome.Sharp.IconButton();
            cardSystemInfo.SuspendLayout();
            cardActualInfo.SuspendLayout();
            SuspendLayout();
            // 
            // cardSystemInfo
            // 
            cardSystemInfo.BackColor = Color.FromArgb(255, 255, 255);
            cardSystemInfo.Controls.Add(lblExpectedCash);
            cardSystemInfo.Controls.Add(lblTitleExpected);
            cardSystemInfo.Controls.Add(lblOutgoings);
            cardSystemInfo.Controls.Add(lblTitleOutgoings);
            cardSystemInfo.Controls.Add(lblCardSystem);
            cardSystemInfo.Controls.Add(lblTitleCardSystem);
            cardSystemInfo.Controls.Add(lblCashSystem);
            cardSystemInfo.Controls.Add(lblTitleCashSystem);
            cardSystemInfo.Controls.Add(lblSystemSectionTitle);
            cardSystemInfo.Depth = 0;
            cardSystemInfo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cardSystemInfo.Location = new Point(25, 25);
            cardSystemInfo.Margin = new Padding(16);
            cardSystemInfo.MouseState = MaterialSkin.MouseState.HOVER;
            cardSystemInfo.Name = "cardSystemInfo";
            cardSystemInfo.Padding = new Padding(16);
            cardSystemInfo.Size = new Size(642, 254);
            cardSystemInfo.TabIndex = 0;
            // 
            // lblExpectedCash
            // 
            lblExpectedCash.AutoSize = true;
            lblExpectedCash.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblExpectedCash.ForeColor = Color.MediumSeaGreen;
            lblExpectedCash.Location = new Point(20, 202);
            lblExpectedCash.Margin = new Padding(4, 0, 4, 0);
            lblExpectedCash.Name = "lblExpectedCash";
            lblExpectedCash.Size = new Size(37, 20);
            lblExpectedCash.TabIndex = 8;
            lblExpectedCash.Text = "0.00";
            // 
            // lblTitleExpected
            // 
            lblTitleExpected.AutoSize = true;
            lblTitleExpected.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblTitleExpected.Location = new Point(401, 202);
            lblTitleExpected.Margin = new Padding(4, 0, 4, 0);
            lblTitleExpected.Name = "lblTitleExpected";
            lblTitleExpected.Size = new Size(201, 20);
            lblTitleExpected.TabIndex = 7;
            lblTitleExpected.Text = "الرصيد الدفتري المتوقع (كاش):";
            // 
            // lblOutgoings
            // 
            lblOutgoings.AutoSize = true;
            lblOutgoings.Font = new Font("Segoe UI", 10F);
            lblOutgoings.Location = new Point(20, 156);
            lblOutgoings.Margin = new Padding(4, 0, 4, 0);
            lblOutgoings.Name = "lblOutgoings";
            lblOutgoings.Size = new Size(36, 19);
            lblOutgoings.TabIndex = 6;
            lblOutgoings.Text = "0.00";
            // 
            // lblTitleOutgoings
            // 
            lblTitleOutgoings.AutoSize = true;
            lblTitleOutgoings.Font = new Font("Segoe UI", 10F);
            lblTitleOutgoings.Location = new Point(398, 156);
            lblTitleOutgoings.Margin = new Padding(4, 0, 4, 0);
            lblTitleOutgoings.Name = "lblTitleOutgoings";
            lblTitleOutgoings.Size = new Size(197, 19);
            lblTitleOutgoings.TabIndex = 5;
            lblTitleOutgoings.Text = "إجمالي المصروفات والمشتريات:";
            // 
            // lblCardSystem
            // 
            lblCardSystem.AutoSize = true;
            lblCardSystem.Font = new Font("Segoe UI", 10F);
            lblCardSystem.Location = new Point(20, 110);
            lblCardSystem.Margin = new Padding(4, 0, 4, 0);
            lblCardSystem.Name = "lblCardSystem";
            lblCardSystem.Size = new Size(36, 19);
            lblCardSystem.TabIndex = 4;
            lblCardSystem.Text = "0.00";
            // 
            // lblTitleCardSystem
            // 
            lblTitleCardSystem.AutoSize = true;
            lblTitleCardSystem.Font = new Font("Segoe UI", 10F);
            lblTitleCardSystem.Location = new Point(428, 110);
            lblTitleCardSystem.Margin = new Padding(4, 0, 4, 0);
            lblTitleCardSystem.Name = "lblTitleCardSystem";
            lblTitleCardSystem.Size = new Size(174, 19);
            lblTitleCardSystem.TabIndex = 3;
            lblTitleCardSystem.Text = "إجمالي مبيعات (بطاقة/بنك):";
            // 
            // lblCashSystem
            // 
            lblCashSystem.AutoSize = true;
            lblCashSystem.Font = new Font("Segoe UI", 10F);
            lblCashSystem.Location = new Point(20, 63);
            lblCashSystem.Margin = new Padding(4, 0, 4, 0);
            lblCashSystem.Name = "lblCashSystem";
            lblCashSystem.Size = new Size(36, 19);
            lblCashSystem.TabIndex = 2;
            lblCashSystem.Text = "0.00";
            // 
            // lblTitleCashSystem
            // 
            lblTitleCashSystem.AutoSize = true;
            lblTitleCashSystem.Font = new Font("Segoe UI", 10F);
            lblTitleCashSystem.Location = new Point(454, 63);
            lblTitleCashSystem.Margin = new Padding(4, 0, 4, 0);
            lblTitleCashSystem.Name = "lblTitleCashSystem";
            lblTitleCashSystem.Size = new Size(148, 19);
            lblTitleCashSystem.TabIndex = 1;
            lblTitleCashSystem.Text = "إجمالي مبيعات (الكاش):";
            // 
            // lblSystemSectionTitle
            // 
            lblSystemSectionTitle.AutoSize = true;
            lblSystemSectionTitle.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSystemSectionTitle.ForeColor = Color.Gray;
            lblSystemSectionTitle.Location = new Point(411, 16);
            lblSystemSectionTitle.Margin = new Padding(4, 0, 4, 0);
            lblSystemSectionTitle.Name = "lblSystemSectionTitle";
            lblSystemSectionTitle.Size = new Size(178, 25);
            lblSystemSectionTitle.TabIndex = 0;
            lblSystemSectionTitle.Text = "ملخص إيرادات النظام";
            // 
            // cardActualInfo
            // 
            cardActualInfo.BackColor = Color.FromArgb(255, 255, 255);
            cardActualInfo.Controls.Add(txtNotes);
            cardActualInfo.Controls.Add(lblDifference);
            cardActualInfo.Controls.Add(txtActualCash);
            cardActualInfo.Depth = 0;
            cardActualInfo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cardActualInfo.Location = new Point(25, 311);
            cardActualInfo.Margin = new Padding(16);
            cardActualInfo.MouseState = MaterialSkin.MouseState.HOVER;
            cardActualInfo.Name = "cardActualInfo";
            cardActualInfo.Padding = new Padding(16);
            cardActualInfo.Size = new Size(642, 277);
            cardActualInfo.TabIndex = 1;
            // 
            // txtNotes
            // 
            txtNotes.AnimateReadOnly = false;
            txtNotes.BackgroundImageLayout = ImageLayout.None;
            txtNotes.CharacterCasing = CharacterCasing.Normal;
            txtNotes.Cursor = Cursors.IBeam;
            txtNotes.Depth = 0;
            txtNotes.HideSelection = true;
            txtNotes.Hint = "ملاحظات الإغلاق (اختياري)...";
            txtNotes.Location = new Point(20, 153);
            txtNotes.Margin = new Padding(4, 3, 4, 3);
            txtNotes.MaxLength = 32767;
            txtNotes.MouseState = MaterialSkin.MouseState.OUT;
            txtNotes.Name = "txtNotes";
            txtNotes.PasswordChar = '\0';
            txtNotes.ReadOnly = false;
            txtNotes.ScrollBars = ScrollBars.None;
            txtNotes.SelectedText = "";
            txtNotes.SelectionLength = 0;
            txtNotes.SelectionStart = 0;
            txtNotes.ShortcutsEnabled = true;
            txtNotes.Size = new Size(602, 98);
            txtNotes.TabIndex = 2;
            txtNotes.TabStop = false;
            txtNotes.TextAlign = HorizontalAlignment.Left;
            txtNotes.UseSystemPasswordChar = false;
            // 
            // lblDifference
            // 
            lblDifference.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDifference.ForeColor = Color.Gray;
            lblDifference.Location = new Point(20, 104);
            lblDifference.Margin = new Padding(4, 0, 4, 0);
            lblDifference.Name = "lblDifference";
            lblDifference.Size = new Size(602, 35);
            lblDifference.TabIndex = 1;
            lblDifference.Text = "الفارق (عجز / زيادة): 0.00";
            lblDifference.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtActualCash
            // 
            txtActualCash.AnimateReadOnly = false;
            txtActualCash.AutoCompleteMode = AutoCompleteMode.None;
            txtActualCash.AutoCompleteSource = AutoCompleteSource.None;
            txtActualCash.BackgroundImageLayout = ImageLayout.None;
            txtActualCash.CharacterCasing = CharacterCasing.Normal;
            txtActualCash.Depth = 0;
            txtActualCash.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtActualCash.HideSelection = true;
            txtActualCash.Hint = "أدخل المبلغ الفعلي الموجود في الدرج (كاش)";
            txtActualCash.LeadingIcon = null;
            txtActualCash.Location = new Point(20, 29);
            txtActualCash.Margin = new Padding(4, 3, 4, 3);
            txtActualCash.MaxLength = 32767;
            txtActualCash.MouseState = MaterialSkin.MouseState.OUT;
            txtActualCash.Name = "txtActualCash";
            txtActualCash.PasswordChar = '\0';
            txtActualCash.PrefixSuffixText = null;
            txtActualCash.ReadOnly = false;
            txtActualCash.RightToLeft = RightToLeft.No;
            txtActualCash.SelectedText = "";
            txtActualCash.SelectionLength = 0;
            txtActualCash.SelectionStart = 0;
            txtActualCash.ShortcutsEnabled = true;
            txtActualCash.Size = new Size(602, 48);
            txtActualCash.TabIndex = 0;
            txtActualCash.TabStop = false;
            txtActualCash.TextAlign = HorizontalAlignment.Center;
            txtActualCash.TrailingIcon = null;
            txtActualCash.UseSystemPasswordChar = false;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWarning.ForeColor = Color.DarkGoldenrod;
            lblWarning.Location = new Point(25, 611);
            lblWarning.Margin = new Padding(4, 0, 4, 0);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(411, 17);
            lblWarning.TabIndex = 2;
            lblWarning.Text = "تنبيه: لا تنسَ ترحيل المبلغ  إلى الخزنة الرئيسية من شاشة (إدارة الخزينة) لاحقاً.";
            // 
            // btnSaveClosure
            // 
            btnSaveClosure.BackColor = Color.MediumSeaGreen;
            btnSaveClosure.Cursor = Cursors.Hand;
            btnSaveClosure.FlatAppearance.BorderSize = 0;
            btnSaveClosure.FlatStyle = FlatStyle.Flat;
            btnSaveClosure.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveClosure.ForeColor = Color.White;
            btnSaveClosure.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            btnSaveClosure.IconColor = Color.White;
            btnSaveClosure.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSaveClosure.IconSize = 32;
            btnSaveClosure.ImageAlign = ContentAlignment.MiddleRight;
            btnSaveClosure.Location = new Point(399, 636);
            btnSaveClosure.Margin = new Padding(4, 3, 4, 3);
            btnSaveClosure.Name = "btnSaveClosure";
            btnSaveClosure.Padding = new Padding(0, 0, 12, 0);
            btnSaveClosure.Size = new Size(268, 58);
            btnSaveClosure.TabIndex = 3;
            btnSaveClosure.Text = "حفظ وإغلاق الحساب";
            btnSaveClosure.TextAlign = ContentAlignment.MiddleLeft;
            btnSaveClosure.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightCoral;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            btnCancel.IconColor = Color.White;
            btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancel.IconSize = 32;
            btnCancel.ImageAlign = ContentAlignment.MiddleRight;
            btnCancel.Location = new Point(229, 636);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Padding = new Padding(0, 0, 12, 0);
            btnCancel.Size = new Size(152, 58);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "إلغاء";
            btnCancel.TextAlign = ContentAlignment.MiddleLeft;
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // FrmDailyClosure
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(700, 699);
            Controls.Add(btnCancel);
            Controls.Add(btnSaveClosure);
            Controls.Add(lblWarning);
            Controls.Add(cardActualInfo);
            Controls.Add(cardSystemInfo);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmDailyClosure";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إغلاق الحساب اليومي (الدرج)";
            cardSystemInfo.ResumeLayout(false);
            cardSystemInfo.PerformLayout();
            cardActualInfo.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard cardSystemInfo;
        private Label lblTitleCashSystem;
        private Label lblExpectedCash;
        private Label lblTitleExpected;
        private Label lblOutgoings;
        private Label lblTitleOutgoings;
        private Label lblCardSystem;
        private Label lblTitleCardSystem;
        private Label lblCashSystem;
        private Label lblSystemSectionTitle;
        private MaterialSkin.Controls.MaterialCard cardActualInfo;
        private Label lblDifference;
        private MaterialSkin.Controls.MaterialTextBox2 txtActualCash;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtNotes;
        private Label lblWarning;
        private FontAwesome.Sharp.IconButton btnSaveClosure;
        private FontAwesome.Sharp.IconButton btnCancel;
    }
}