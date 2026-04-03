namespace beautyCenterSystem
{
    partial class UC_Employees
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
            btnAddEmployee = new FontAwesome.Sharp.IconButton();
            lblTitle = new MaterialSkin.Controls.MaterialLabel();
            pnlActions = new Panel();
            btnPayCommission = new MaterialSkin.Controls.MaterialButton();
            btnDeactivateEmployee = new MaterialSkin.Controls.MaterialButton();
            pnlMain = new Panel();
            dgvEmployees = new DataGridView();
            pnlSearch = new Panel();
            txtSearch = new MaterialSkin.Controls.MaterialTextBox2();
            pnlHeader.SuspendLayout();
            pnlActions.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            pnlSearch.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(55, 71, 79);
            pnlHeader.Controls.Add(btnAddEmployee);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(827, 66);
            pnlHeader.TabIndex = 0;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.BackColor = Color.White;
            btnAddEmployee.Cursor = Cursors.Hand;
            btnAddEmployee.FlatAppearance.BorderSize = 0;
            btnAddEmployee.FlatStyle = FlatStyle.Flat;
            btnAddEmployee.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddEmployee.ForeColor = Color.Black;
            btnAddEmployee.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            btnAddEmployee.IconColor = Color.Black;
            btnAddEmployee.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddEmployee.IconSize = 32;
            btnAddEmployee.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddEmployee.Location = new Point(18, 11);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(158, 42);
            btnAddEmployee.TabIndex = 1;
            btnAddEmployee.Text = "إضافة موظفة";
            btnAddEmployee.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddEmployee.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTitle.AutoSize = true;
            lblTitle.Depth = 0;
            lblTitle.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
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
            pnlActions.Controls.Add(btnDeactivateEmployee);
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
            // btnDeactivateEmployee
            // 
            btnDeactivateEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeactivateEmployee.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDeactivateEmployee.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDeactivateEmployee.Depth = 0;
            btnDeactivateEmployee.HighEmphasis = true;
            btnDeactivateEmployee.Icon = null;
            btnDeactivateEmployee.Location = new Point(715, 19);
            btnDeactivateEmployee.Margin = new Padding(4, 6, 4, 6);
            btnDeactivateEmployee.MouseState = MaterialSkin.MouseState.HOVER;
            btnDeactivateEmployee.Name = "btnDeactivateEmployee";
            btnDeactivateEmployee.NoAccentTextColor = Color.Empty;
            btnDeactivateEmployee.Size = new Size(94, 36);
            btnDeactivateEmployee.TabIndex = 1;
            btnDeactivateEmployee.Text = "إيقاف الموظفة";
            btnDeactivateEmployee.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnDeactivateEmployee.UseAccentColor = true;
            btnDeactivateEmployee.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(dgvEmployees);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 150);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(18, 19, 18, 19);
            pnlMain.Size = new Size(827, 337);
            pnlMain.TabIndex = 2;
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.BackgroundColor = Color.White;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Dock = DockStyle.Fill;
            dgvEmployees.Location = new Point(18, 19);
            dgvEmployees.MultiSelect = false;
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.RowTemplate.Height = 40;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(791, 299);
            dgvEmployees.TabIndex = 0;
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
            // UC_Employees
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlMain);
            Controls.Add(pnlSearch);
            Controls.Add(pnlActions);
            Controls.Add(pnlHeader);
            Name = "UC_Employees";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(827, 562);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlActions.ResumeLayout(false);
            pnlActions.PerformLayout();
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            pnlSearch.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private MaterialSkin.Controls.MaterialLabel lblTitle;
        private FontAwesome.Sharp.IconButton btnAddEmployee;
        private System.Windows.Forms.Panel pnlActions;
        private MaterialSkin.Controls.MaterialButton btnPayCommission;
        private MaterialSkin.Controls.MaterialButton btnDeactivateEmployee;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Panel pnlSearch;
        private MaterialSkin.Controls.MaterialTextBox2 txtSearch;
    }
}