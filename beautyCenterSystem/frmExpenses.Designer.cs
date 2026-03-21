namespace beautyCenterSystem
{
    partial class frmExpenses
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
            dgvExpenses = new DataGridView();
            dtp_To = new DateTimePicker();
            dtp_From = new DateTimePicker();
            panel1 = new Panel();
            txtboxSearch = new MaterialSkin.Controls.MaterialTextBox2();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            splitContainer1 = new SplitContainer();
            btnSave = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtDescription = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            txtAmount = new MaterialSkin.Controls.MaterialTextBox2();
            txtCategory = new MaterialSkin.Controls.MaterialTextBox2();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            dtpExpenseDate = new DateTimePicker();
            label2 = new Label();
            cmbSafes = new MaterialSearchableCombo();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvExpenses
            // 
            dgvExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpenses.Dock = DockStyle.Fill;
            dgvExpenses.Location = new Point(0, 0);
            dgvExpenses.Name = "dgvExpenses";
            dgvExpenses.Size = new Size(662, 585);
            dgvExpenses.TabIndex = 26;
            dgvExpenses.CellValueChanged += dgvExpenses_CellValueChanged;
            // 
            // dtp_To
            // 
            dtp_To.Location = new Point(21, 47);
            dtp_To.Name = "dtp_To";
            dtp_To.Size = new Size(200, 23);
            dtp_To.TabIndex = 27;
            dtp_To.ValueChanged += OnDateFilterChanged;
            // 
            // dtp_From
            // 
            dtp_From.Location = new Point(21, 12);
            dtp_From.Name = "dtp_From";
            dtp_From.Size = new Size(200, 23);
            dtp_From.TabIndex = 28;
            dtp_From.ValueChanged += OnDateFilterChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtboxSearch);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(iconPictureBox1);
            panel1.Controls.Add(dtp_From);
            panel1.Controls.Add(dtp_To);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(984, 76);
            panel1.TabIndex = 30;
            // 
            // txtboxSearch
            // 
            txtboxSearch.AnimateReadOnly = false;
            txtboxSearch.AutoCompleteMode = AutoCompleteMode.None;
            txtboxSearch.AutoCompleteSource = AutoCompleteSource.None;
            txtboxSearch.BackgroundImageLayout = ImageLayout.None;
            txtboxSearch.CharacterCasing = CharacterCasing.Normal;
            txtboxSearch.Depth = 0;
            txtboxSearch.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtboxSearch.HideSelection = true;
            txtboxSearch.Hint = "البحث";
            txtboxSearch.LeadingIcon = null;
            txtboxSearch.Location = new Point(352, 12);
            txtboxSearch.MaxLength = 32767;
            txtboxSearch.MouseState = MaterialSkin.MouseState.OUT;
            txtboxSearch.Name = "txtboxSearch";
            txtboxSearch.PasswordChar = '\0';
            txtboxSearch.PrefixSuffixText = null;
            txtboxSearch.ReadOnly = false;
            txtboxSearch.RightToLeft = RightToLeft.No;
            txtboxSearch.SelectedText = "";
            txtboxSearch.SelectionLength = 0;
            txtboxSearch.SelectionStart = 0;
            txtboxSearch.ShortcutsEnabled = true;
            txtboxSearch.Size = new Size(399, 48);
            txtboxSearch.TabIndex = 35;
            txtboxSearch.TabStop = false;
            txtboxSearch.TextAlign = HorizontalAlignment.Left;
            txtboxSearch.TrailingIcon = null;
            txtboxSearch.UseSystemPasswordChar = false;
            txtboxSearch.TextChanged += txtboxSearch_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(227, 53);
            label8.Name = "label8";
            label8.Size = new Size(24, 15);
            label8.TabIndex = 34;
            label8.Text = "إلى";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(227, 18);
            label7.Name = "label7";
            label7.Size = new Size(22, 15);
            label7.TabIndex = 33;
            label7.Text = "من";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13F);
            label6.Location = new Point(816, 18);
            label6.Name = "label6";
            label6.Size = new Size(136, 25);
            label6.TabIndex = 31;
            label6.Text = "إدارة المصروفات";
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = SystemColors.Control;
            iconPictureBox1.ForeColor = SystemColors.ControlText;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Search;
            iconPictureBox1.IconColor = SystemColors.ControlText;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 39;
            iconPictureBox1.Location = new Point(307, 12);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(39, 48);
            iconPictureBox1.TabIndex = 30;
            iconPictureBox1.TabStop = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 76);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvExpenses);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnSave);
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer1.Size = new Size(984, 585);
            splitContainer1.SplitterDistance = 662;
            splitContainer1.TabIndex = 31;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Location = new Point(0, 544);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(318, 41);
            btnSave.TabIndex = 1;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSaveExpense_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(txtDescription, 0, 2);
            tableLayoutPanel1.Controls.Add(txtAmount, 0, 1);
            tableLayoutPanel1.Controls.Add(txtCategory, 0, 0);
            tableLayoutPanel1.Controls.Add(label5, 1, 4);
            tableLayoutPanel1.Controls.Add(label4, 1, 3);
            tableLayoutPanel1.Controls.Add(label3, 1, 2);
            tableLayoutPanel1.Controls.Add(dtpExpenseDate, 0, 4);
            tableLayoutPanel1.Controls.Add(label2, 1, 1);
            tableLayoutPanel1.Controls.Add(cmbSafes, 0, 3);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.Size = new Size(318, 585);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // txtDescription
            // 
            txtDescription.AnimateReadOnly = false;
            txtDescription.BackgroundImageLayout = ImageLayout.None;
            txtDescription.CharacterCasing = CharacterCasing.Normal;
            txtDescription.Depth = 0;
            txtDescription.HideSelection = true;
            txtDescription.Location = new Point(3, 103);
            txtDescription.MaxLength = 32767;
            txtDescription.MouseState = MaterialSkin.MouseState.OUT;
            txtDescription.Name = "txtDescription";
            txtDescription.PasswordChar = '\0';
            txtDescription.ReadOnly = false;
            txtDescription.ScrollBars = ScrollBars.None;
            txtDescription.SelectedText = "";
            txtDescription.SelectionLength = 0;
            txtDescription.SelectionStart = 0;
            txtDescription.ShortcutsEnabled = true;
            txtDescription.Size = new Size(250, 64);
            txtDescription.TabIndex = 12;
            txtDescription.TabStop = false;
            txtDescription.TextAlign = HorizontalAlignment.Left;
            txtDescription.UseSystemPasswordChar = false;
            // 
            // txtAmount
            // 
            txtAmount.AnimateReadOnly = false;
            txtAmount.AutoCompleteMode = AutoCompleteMode.None;
            txtAmount.AutoCompleteSource = AutoCompleteSource.None;
            txtAmount.BackgroundImageLayout = ImageLayout.None;
            txtAmount.CharacterCasing = CharacterCasing.Normal;
            txtAmount.Depth = 0;
            txtAmount.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAmount.HideSelection = true;
            txtAmount.LeadingIcon = null;
            txtAmount.Location = new Point(3, 53);
            txtAmount.MaxLength = 32767;
            txtAmount.MouseState = MaterialSkin.MouseState.OUT;
            txtAmount.Name = "txtAmount";
            txtAmount.PasswordChar = '\0';
            txtAmount.PrefixSuffixText = null;
            txtAmount.ReadOnly = false;
            txtAmount.RightToLeft = RightToLeft.No;
            txtAmount.SelectedText = "";
            txtAmount.SelectionLength = 0;
            txtAmount.SelectionStart = 0;
            txtAmount.ShortcutsEnabled = true;
            txtAmount.Size = new Size(250, 48);
            txtAmount.TabIndex = 11;
            txtAmount.TabStop = false;
            txtAmount.TextAlign = HorizontalAlignment.Left;
            txtAmount.TrailingIcon = null;
            txtAmount.UseSystemPasswordChar = false;
            txtAmount.KeyPress += txtAmount_KeyPress;
            // 
            // txtCategory
            // 
            txtCategory.AnimateReadOnly = false;
            txtCategory.AutoCompleteMode = AutoCompleteMode.None;
            txtCategory.AutoCompleteSource = AutoCompleteSource.None;
            txtCategory.BackgroundImageLayout = ImageLayout.None;
            txtCategory.CharacterCasing = CharacterCasing.Normal;
            txtCategory.Depth = 0;
            txtCategory.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCategory.HideSelection = true;
            txtCategory.LeadingIcon = null;
            txtCategory.Location = new Point(3, 3);
            txtCategory.MaxLength = 32767;
            txtCategory.MouseState = MaterialSkin.MouseState.OUT;
            txtCategory.Name = "txtCategory";
            txtCategory.PasswordChar = '\0';
            txtCategory.PrefixSuffixText = null;
            txtCategory.ReadOnly = false;
            txtCategory.RightToLeft = RightToLeft.No;
            txtCategory.SelectedText = "";
            txtCategory.SelectionLength = 0;
            txtCategory.SelectionStart = 0;
            txtCategory.ShortcutsEnabled = true;
            txtCategory.Size = new Size(250, 48);
            txtCategory.TabIndex = 10;
            txtCategory.TabStop = false;
            txtCategory.TextAlign = HorizontalAlignment.Left;
            txtCategory.TrailingIcon = null;
            txtCategory.UseSystemPasswordChar = false;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(267, 225);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 9;
            label5.Text = "التاريخ";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(267, 187);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 8;
            label4.Text = "الخزنة";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(267, 127);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 7;
            label3.Text = "وصف";
            // 
            // dtpExpenseDate
            // 
            dtpExpenseDate.Location = new Point(3, 223);
            dtpExpenseDate.Name = "dtpExpenseDate";
            dtpExpenseDate.Size = new Size(250, 23);
            dtpExpenseDate.TabIndex = 4;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(267, 67);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 6;
            label2.Text = "المبلغ";
            // 
            // cmbSafes
            // 
            cmbSafes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbSafes.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbSafes.BackColor = Color.White;
            cmbSafes.FlatStyle = FlatStyle.Flat;
            cmbSafes.Font = new Font("Segoe UI", 15F);
            cmbSafes.FormattingEnabled = true;
            cmbSafes.Location = new Point(3, 173);
            cmbSafes.Name = "cmbSafes";
            cmbSafes.Size = new Size(250, 36);
            cmbSafes.TabIndex = 13;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F);
            label1.Location = new Point(267, 18);
            label1.Name = "label1";
            label1.Size = new Size(48, 13);
            label1.TabIndex = 5;
            label1.Text = "التصنيف";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // frmExpenses
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Name = "frmExpenses";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إدارة المصروفات";
            Load += frmExpenses_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvExpenses;
        private DateTimePicker dtp_To;
        private DateTimePicker dtp_From;
        private Panel panel1;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSave;
        private DateTimePicker dtpExpenseDate;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label6;
        private Label label7;
        private Label label8;
        private MaterialSearchableCombo cmbSafes;
        private MaterialSkin.Controls.MaterialTextBox2 txtAmount;
        private MaterialSkin.Controls.MaterialTextBox2 txtCategory;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtDescription;
        private MaterialSkin.Controls.MaterialTextBox2 txtboxSearch;
    }
}