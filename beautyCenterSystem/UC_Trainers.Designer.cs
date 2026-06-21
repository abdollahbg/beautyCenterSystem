namespace beautyCenterSystem
{
    partial class UC_Trainers
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            btnAddTrainer = new FontAwesome.Sharp.IconButton();
            lblTitle = new MaterialSkin.Controls.MaterialLabel();
            pnlActions = new Panel();
            btnPayCommission = new MaterialSkin.Controls.MaterialButton();
            btnPaymentHistory = new MaterialSkin.Controls.MaterialButton();
            btnDeactivateTrainer = new MaterialSkin.Controls.MaterialButton();
            pnlMain = new Panel();
            dgvTrainers = new DataGridView();
            pnlSearch = new Panel();
            txtSearch = new MaterialSkin.Controls.MaterialTextBox2();
            pnlHeader.SuspendLayout();
            pnlActions.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTrainers).BeginInit();
            pnlSearch.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(55, 71, 79);
            pnlHeader.Controls.Add(btnAddTrainer);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(827, 66);
            pnlHeader.TabIndex = 0;
            // 
            // btnAddTrainer
            // 
            btnAddTrainer.BackColor = Color.White;
            btnAddTrainer.Cursor = Cursors.Hand;
            btnAddTrainer.FlatAppearance.BorderSize = 0;
            btnAddTrainer.FlatStyle = FlatStyle.Flat;
            btnAddTrainer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddTrainer.ForeColor = Color.Black;
            btnAddTrainer.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            btnAddTrainer.IconColor = Color.Black;
            btnAddTrainer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddTrainer.IconSize = 32;
            btnAddTrainer.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddTrainer.Location = new Point(18, 11);
            btnAddTrainer.Name = "btnAddTrainer";
            btnAddTrainer.Size = new Size(158, 42);
            btnAddTrainer.TabIndex = 1;
            btnAddTrainer.Text = "إضافة موظفة";
            btnAddTrainer.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddTrainer.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTitle.AutoSize = true;
            lblTitle.Depth = 0;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(601, 16);
            lblTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(178, 29);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "إدارة الموظفات والنسب";
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(btnPayCommission);
            pnlActions.Controls.Add(btnPaymentHistory);
            pnlActions.Controls.Add(btnDeactivateTrainer);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 487);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(827, 75);
            pnlActions.TabIndex = 1;
            // 
            // btnPayCommission
            // 
            btnPayCommission.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnPayCommission.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnPayCommission.Depth = 0;
            btnPayCommission.HighEmphasis = true;
            btnPayCommission.Icon = null;
            btnPayCommission.Location = new Point(18, 19);
            btnPayCommission.Margin = new Padding(4, 6, 4, 6);
            btnPayCommission.MouseState = MaterialSkin.MouseState.HOVER;
            btnPayCommission.Name = "btnPayCommission";
            btnPayCommission.NoAccentTextColor = Color.Empty;
            btnPayCommission.Size = new Size(107, 36);
            btnPayCommission.TabIndex = 0;
            btnPayCommission.Text = "صرف مستحقات";
            btnPayCommission.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnPayCommission.UseAccentColor = false;
            btnPayCommission.UseVisualStyleBackColor = true;
            // 
            // btnPaymentHistory
            // 
            btnPaymentHistory.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnPaymentHistory.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnPaymentHistory.Depth = 0;
            btnPaymentHistory.HighEmphasis = true;
            btnPaymentHistory.Icon = null;
            btnPaymentHistory.Location = new Point(140, 19);
            btnPaymentHistory.Margin = new Padding(4, 6, 4, 6);
            btnPaymentHistory.MouseState = MaterialSkin.MouseState.HOVER;
            btnPaymentHistory.Name = "btnPaymentHistory";
            btnPaymentHistory.NoAccentTextColor = Color.Empty;
            btnPaymentHistory.Size = new Size(110, 36);
            btnPaymentHistory.TabIndex = 2;
            btnPaymentHistory.Text = "سجل الصرف";
            btnPaymentHistory.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnPaymentHistory.UseAccentColor = false;
            btnPaymentHistory.UseVisualStyleBackColor = true;
            // 
            // btnDeactivateTrainer
            // 
            btnDeactivateTrainer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeactivateTrainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDeactivateTrainer.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDeactivateTrainer.Depth = 0;
            btnDeactivateTrainer.HighEmphasis = true;
            btnDeactivateTrainer.Icon = null;
            btnDeactivateTrainer.Location = new Point(715, 19);
            btnDeactivateTrainer.Margin = new Padding(4, 6, 4, 6);
            btnDeactivateTrainer.MouseState = MaterialSkin.MouseState.HOVER;
            btnDeactivateTrainer.Name = "btnDeactivateTrainer";
            btnDeactivateTrainer.NoAccentTextColor = Color.Empty;
            btnDeactivateTrainer.Size = new Size(94, 36);
            btnDeactivateTrainer.TabIndex = 1;
            btnDeactivateTrainer.Text = "إيقاف الموظفة";
            btnDeactivateTrainer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnDeactivateTrainer.UseAccentColor = true;
            btnDeactivateTrainer.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(dgvTrainers);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 150);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(18, 19, 18, 19);
            pnlMain.Size = new Size(827, 337);
            pnlMain.TabIndex = 2;
            // 
            // dgvTrainers
            // 
            dgvTrainers.AllowUserToAddRows = false;
            dgvTrainers.AllowUserToDeleteRows = false;
            dgvTrainers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTrainers.BackgroundColor = Color.White;
            dgvTrainers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrainers.Dock = DockStyle.Fill;
            dgvTrainers.Location = new Point(18, 19);
            dgvTrainers.MultiSelect = false;
            dgvTrainers.Name = "dgvTrainers";
            dgvTrainers.RowHeadersWidth = 51;
            dgvTrainers.RowTemplate.Height = 40;
            dgvTrainers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrainers.Size = new Size(791, 299);
            dgvTrainers.TabIndex = 0;
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(0, 66);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Padding = new Padding(18, 19, 18, 19);
            pnlSearch.Size = new Size(827, 84);
            pnlSearch.TabIndex = 3;
            // 
            // txtSearch
            // 
            txtSearch.AnimateReadOnly = false;
            txtSearch.AutoCompleteMode = AutoCompleteMode.None;
            txtSearch.AutoCompleteSource = AutoCompleteSource.None;
            txtSearch.BackgroundImageLayout = ImageLayout.None;
            txtSearch.CharacterCasing = CharacterCasing.Normal;
            txtSearch.Depth = 0;
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSearch.HideSelection = true;
            txtSearch.Hint = "ابحث باسم الموظفة أو رقم الهاتف...";
            txtSearch.LeadingIcon = null;
            txtSearch.Location = new Point(18, 19);
            txtSearch.MaxLength = 32767;
            txtSearch.MouseState = MaterialSkin.MouseState.OUT;
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.PrefixSuffixText = null;
            txtSearch.ReadOnly = false;
            txtSearch.RightToLeft = RightToLeft.Yes;
            txtSearch.SelectedText = "";
            txtSearch.SelectionLength = 0;
            txtSearch.SelectionStart = 0;
            txtSearch.ShortcutsEnabled = true;
            txtSearch.Size = new Size(791, 48);
            txtSearch.TabIndex = 0;
            txtSearch.TabStop = false;
            txtSearch.TextAlign = HorizontalAlignment.Left;
            txtSearch.TrailingIcon = null;
            txtSearch.UseSystemPasswordChar = false;
            // 
            // UC_Trainers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlMain);
            Controls.Add(pnlSearch);
            Controls.Add(pnlActions);
            Controls.Add(pnlHeader);
            Name = "UC_Trainers";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(827, 562);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlActions.ResumeLayout(false);
            pnlActions.PerformLayout();
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTrainers).EndInit();
            pnlSearch.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private MaterialSkin.Controls.MaterialLabel lblTitle;
        private FontAwesome.Sharp.IconButton btnAddTrainer;
        private System.Windows.Forms.Panel pnlActions;
        private MaterialSkin.Controls.MaterialButton btnPayCommission;
        private MaterialSkin.Controls.MaterialButton btnDeactivateTrainer;
        private MaterialSkin.Controls.MaterialButton btnPaymentHistory;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvTrainers;
        private System.Windows.Forms.Panel pnlSearch;
        private MaterialSkin.Controls.MaterialTextBox2 txtSearch;
    }
}
