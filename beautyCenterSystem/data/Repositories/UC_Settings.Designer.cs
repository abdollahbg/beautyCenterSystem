namespace beautyCenterSystem.data.Repositories
{
    partial class UC_Settings
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            label12 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel8 = new Panel();
            txtInvoiceNote = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            label11 = new Label();
            label8 = new Label();
            panel7 = new Panel();
            label10 = new Label();
            label7 = new Label();
            txtInstagram = new MaterialSkin.Controls.MaterialTextBox2();
            panel6 = new Panel();
            label9 = new Label();
            label6 = new Label();
            txtFacebook = new MaterialSkin.Controls.MaterialTextBox2();
            panel4 = new Panel();
            label1 = new Label();
            label4 = new Label();
            txtPhone = new MaterialSkin.Controls.MaterialTextBox2();
            panel5 = new Panel();
            label2 = new Label();
            label5 = new Label();
            txtWhatsApp = new MaterialSkin.Controls.MaterialTextBox2();
            panel3 = new Panel();
            label3 = new Label();
            txtCenterName = new MaterialSkin.Controls.MaterialTextBox2();
            picLogo = new FontAwesome.Sharp.IconPictureBox();
            btnSaveSettings = new Button();
            label13 = new Label();
            btnDelete = new Button();
            btnBrowse = new Button();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.Yes;
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1000, 700);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(splitContainer1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(992, 672);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "هوية المركز";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel2);
            splitContainer1.Panel1.RightToLeft = RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(picLogo);
            splitContainer1.Panel2.Controls.Add(btnSaveSettings);
            splitContainer1.Panel2.Controls.Add(label13);
            splitContainer1.Panel2.Controls.Add(btnDelete);
            splitContainer1.Panel2.Controls.Add(btnBrowse);
            splitContainer1.Panel2.RightToLeft = RightToLeft.Yes;
            splitContainer1.Size = new Size(986, 666);
            splitContainer1.SplitterDistance = 397;
            splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label12);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(397, 51);
            panel1.TabIndex = 1;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 15F);
            label12.Location = new Point(107, 0);
            label12.Name = "label12";
            label12.Size = new Size(284, 28);
            label12.TabIndex = 0;
            label12.Text = "البيانات التي ستظهر على الفاتورة";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(panel8, 0, 5);
            tableLayoutPanel2.Controls.Add(panel7, 0, 4);
            tableLayoutPanel2.Controls.Add(panel6, 0, 3);
            tableLayoutPanel2.Controls.Add(panel4, 0, 1);
            tableLayoutPanel2.Controls.Add(panel5, 0, 2);
            tableLayoutPanel2.Controls.Add(panel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(0, 84);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(397, 582);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel8
            // 
            panel8.Controls.Add(txtInvoiceNote);
            panel8.Controls.Add(label11);
            panel8.Controls.Add(label8);
            panel8.Location = new Point(3, 309);
            panel8.Name = "panel8";
            panel8.Size = new Size(391, 98);
            panel8.TabIndex = 6;
            // 
            // txtInvoiceNote
            // 
            txtInvoiceNote.AnimateReadOnly = false;
            txtInvoiceNote.BackgroundImageLayout = ImageLayout.None;
            txtInvoiceNote.CharacterCasing = CharacterCasing.Normal;
            txtInvoiceNote.Depth = 0;
            txtInvoiceNote.HideSelection = true;
            txtInvoiceNote.Location = new Point(0, 0);
            txtInvoiceNote.MaxLength = 32767;
            txtInvoiceNote.MouseState = MaterialSkin.MouseState.OUT;
            txtInvoiceNote.Name = "txtInvoiceNote";
            txtInvoiceNote.PasswordChar = '\0';
            txtInvoiceNote.ReadOnly = false;
            txtInvoiceNote.ScrollBars = ScrollBars.None;
            txtInvoiceNote.SelectedText = "";
            txtInvoiceNote.SelectionLength = 0;
            txtInvoiceNote.SelectionStart = 0;
            txtInvoiceNote.ShortcutsEnabled = true;
            txtInvoiceNote.Size = new Size(250, 100);
            txtInvoiceNote.TabIndex = 3;
            txtInvoiceNote.TabStop = false;
            txtInvoiceNote.TextAlign = HorizontalAlignment.Left;
            txtInvoiceNote.UseSystemPasswordChar = false;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Location = new Point(293, 16);
            label11.Name = "label11";
            label11.Size = new Size(83, 15);
            label11.TabIndex = 2;
            label11.Text = "ملاحظة الفاتورة";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(457, 16);
            label8.Name = "label8";
            label8.Size = new Size(38, 15);
            label8.TabIndex = 1;
            label8.Text = "label8";
            // 
            // panel7
            // 
            panel7.Controls.Add(label10);
            panel7.Controls.Add(label7);
            panel7.Controls.Add(txtInstagram);
            panel7.Location = new Point(3, 250);
            panel7.Name = "panel7";
            panel7.Size = new Size(391, 53);
            panel7.TabIndex = 5;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(293, 16);
            label10.Name = "label10";
            label10.Size = new Size(48, 15);
            label10.TabIndex = 2;
            label10.Text = "إنستقرام";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(457, 16);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 1;
            label7.Text = "label7";
            // 
            // txtInstagram
            // 
            txtInstagram.AnimateReadOnly = false;
            txtInstagram.AutoCompleteMode = AutoCompleteMode.None;
            txtInstagram.AutoCompleteSource = AutoCompleteSource.None;
            txtInstagram.BackgroundImageLayout = ImageLayout.None;
            txtInstagram.CharacterCasing = CharacterCasing.Normal;
            txtInstagram.Depth = 0;
            txtInstagram.Dock = DockStyle.Left;
            txtInstagram.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtInstagram.HideSelection = true;
            txtInstagram.LeadingIcon = null;
            txtInstagram.Location = new Point(0, 0);
            txtInstagram.MaxLength = 32767;
            txtInstagram.MouseState = MaterialSkin.MouseState.OUT;
            txtInstagram.Name = "txtInstagram";
            txtInstagram.PasswordChar = '\0';
            txtInstagram.PrefixSuffixText = null;
            txtInstagram.ReadOnly = false;
            txtInstagram.RightToLeft = RightToLeft.No;
            txtInstagram.SelectedText = "";
            txtInstagram.SelectionLength = 0;
            txtInstagram.SelectionStart = 0;
            txtInstagram.ShortcutsEnabled = true;
            txtInstagram.Size = new Size(250, 48);
            txtInstagram.TabIndex = 0;
            txtInstagram.TabStop = false;
            txtInstagram.TextAlign = HorizontalAlignment.Left;
            txtInstagram.TrailingIcon = null;
            txtInstagram.UseSystemPasswordChar = false;
            // 
            // panel6
            // 
            panel6.Controls.Add(label9);
            panel6.Controls.Add(label6);
            panel6.Controls.Add(txtFacebook);
            panel6.Location = new Point(3, 188);
            panel6.Name = "panel6";
            panel6.Size = new Size(391, 56);
            panel6.TabIndex = 4;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(293, 16);
            label9.Name = "label9";
            label9.Size = new Size(47, 15);
            label9.TabIndex = 2;
            label9.Text = "فيسبوك";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(457, 16);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 1;
            label6.Text = "label6";
            // 
            // txtFacebook
            // 
            txtFacebook.AnimateReadOnly = false;
            txtFacebook.AutoCompleteMode = AutoCompleteMode.None;
            txtFacebook.AutoCompleteSource = AutoCompleteSource.None;
            txtFacebook.BackgroundImageLayout = ImageLayout.None;
            txtFacebook.CharacterCasing = CharacterCasing.Normal;
            txtFacebook.Depth = 0;
            txtFacebook.Dock = DockStyle.Left;
            txtFacebook.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtFacebook.HideSelection = true;
            txtFacebook.LeadingIcon = null;
            txtFacebook.Location = new Point(0, 0);
            txtFacebook.MaxLength = 32767;
            txtFacebook.MouseState = MaterialSkin.MouseState.OUT;
            txtFacebook.Name = "txtFacebook";
            txtFacebook.PasswordChar = '\0';
            txtFacebook.PrefixSuffixText = null;
            txtFacebook.ReadOnly = false;
            txtFacebook.RightToLeft = RightToLeft.No;
            txtFacebook.SelectedText = "";
            txtFacebook.SelectionLength = 0;
            txtFacebook.SelectionStart = 0;
            txtFacebook.ShortcutsEnabled = true;
            txtFacebook.Size = new Size(250, 48);
            txtFacebook.TabIndex = 0;
            txtFacebook.TabStop = false;
            txtFacebook.TextAlign = HorizontalAlignment.Left;
            txtFacebook.TrailingIcon = null;
            txtFacebook.UseSystemPasswordChar = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(txtPhone);
            panel4.Location = new Point(3, 64);
            panel4.Name = "panel4";
            panel4.Size = new Size(391, 54);
            panel4.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(287, 16);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 2;
            label1.Text = "رقم الهاتف";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(457, 16);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 1;
            label4.Text = "label4";
            // 
            // txtPhone
            // 
            txtPhone.AnimateReadOnly = false;
            txtPhone.AutoCompleteMode = AutoCompleteMode.None;
            txtPhone.AutoCompleteSource = AutoCompleteSource.None;
            txtPhone.BackgroundImageLayout = ImageLayout.None;
            txtPhone.CharacterCasing = CharacterCasing.Normal;
            txtPhone.Depth = 0;
            txtPhone.Dock = DockStyle.Left;
            txtPhone.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPhone.HideSelection = true;
            txtPhone.LeadingIcon = null;
            txtPhone.Location = new Point(0, 0);
            txtPhone.MaxLength = 32767;
            txtPhone.MouseState = MaterialSkin.MouseState.OUT;
            txtPhone.Name = "txtPhone";
            txtPhone.PasswordChar = '\0';
            txtPhone.PrefixSuffixText = null;
            txtPhone.ReadOnly = false;
            txtPhone.RightToLeft = RightToLeft.No;
            txtPhone.SelectedText = "";
            txtPhone.SelectionLength = 0;
            txtPhone.SelectionStart = 0;
            txtPhone.ShortcutsEnabled = true;
            txtPhone.Size = new Size(250, 48);
            txtPhone.TabIndex = 0;
            txtPhone.TabStop = false;
            txtPhone.TextAlign = HorizontalAlignment.Left;
            txtPhone.TrailingIcon = null;
            txtPhone.UseSystemPasswordChar = false;
            // 
            // panel5
            // 
            panel5.Controls.Add(label2);
            panel5.Controls.Add(label5);
            panel5.Controls.Add(txtWhatsApp);
            panel5.Location = new Point(3, 124);
            panel5.Name = "panel5";
            panel5.Size = new Size(391, 58);
            panel5.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(275, 16);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 2;
            label2.Text = "رقم الواتساب";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(457, 16);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 1;
            label5.Text = "label5";
            // 
            // txtWhatsApp
            // 
            txtWhatsApp.AnimateReadOnly = false;
            txtWhatsApp.AutoCompleteMode = AutoCompleteMode.None;
            txtWhatsApp.AutoCompleteSource = AutoCompleteSource.None;
            txtWhatsApp.BackgroundImageLayout = ImageLayout.None;
            txtWhatsApp.CharacterCasing = CharacterCasing.Normal;
            txtWhatsApp.Depth = 0;
            txtWhatsApp.Dock = DockStyle.Left;
            txtWhatsApp.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtWhatsApp.HideSelection = true;
            txtWhatsApp.LeadingIcon = null;
            txtWhatsApp.Location = new Point(0, 0);
            txtWhatsApp.MaxLength = 32767;
            txtWhatsApp.MouseState = MaterialSkin.MouseState.OUT;
            txtWhatsApp.Name = "txtWhatsApp";
            txtWhatsApp.PasswordChar = '\0';
            txtWhatsApp.PrefixSuffixText = null;
            txtWhatsApp.ReadOnly = false;
            txtWhatsApp.RightToLeft = RightToLeft.No;
            txtWhatsApp.SelectedText = "";
            txtWhatsApp.SelectionLength = 0;
            txtWhatsApp.SelectionStart = 0;
            txtWhatsApp.ShortcutsEnabled = true;
            txtWhatsApp.Size = new Size(250, 48);
            txtWhatsApp.TabIndex = 0;
            txtWhatsApp.TabStop = false;
            txtWhatsApp.TextAlign = HorizontalAlignment.Left;
            txtWhatsApp.TrailingIcon = null;
            txtWhatsApp.UseSystemPasswordChar = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Controls.Add(txtCenterName);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(391, 55);
            panel3.TabIndex = 0;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(287, 19);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 1;
            label3.Text = "اسم المركز";
            // 
            // txtCenterName
            // 
            txtCenterName.AnimateReadOnly = false;
            txtCenterName.AutoCompleteMode = AutoCompleteMode.None;
            txtCenterName.AutoCompleteSource = AutoCompleteSource.None;
            txtCenterName.BackgroundImageLayout = ImageLayout.None;
            txtCenterName.CharacterCasing = CharacterCasing.Normal;
            txtCenterName.Depth = 0;
            txtCenterName.Dock = DockStyle.Left;
            txtCenterName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCenterName.HideSelection = true;
            txtCenterName.LeadingIcon = null;
            txtCenterName.Location = new Point(0, 0);
            txtCenterName.MaxLength = 32767;
            txtCenterName.MouseState = MaterialSkin.MouseState.OUT;
            txtCenterName.Name = "txtCenterName";
            txtCenterName.PasswordChar = '\0';
            txtCenterName.PrefixSuffixText = null;
            txtCenterName.ReadOnly = false;
            txtCenterName.RightToLeft = RightToLeft.No;
            txtCenterName.SelectedText = "";
            txtCenterName.SelectionLength = 0;
            txtCenterName.SelectionStart = 0;
            txtCenterName.ShortcutsEnabled = true;
            txtCenterName.Size = new Size(250, 48);
            txtCenterName.TabIndex = 0;
            txtCenterName.TabStop = false;
            txtCenterName.TextAlign = HorizontalAlignment.Right;
            txtCenterName.TrailingIcon = null;
            txtCenterName.UseSystemPasswordChar = false;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.ForeColor = SystemColors.ControlText;
            picLogo.IconChar = FontAwesome.Sharp.IconChar.None;
            picLogo.IconColor = SystemColors.ControlText;
            picLogo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            picLogo.IconSize = 240;
            picLogo.Location = new Point(174, 84);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(240, 240);
            picLogo.TabIndex = 5;
            picLogo.TabStop = false;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Font = new Font("Segoe UI", 14F);
            btnSaveSettings.Location = new Point(146, 532);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(290, 55);
            btnSaveSettings.TabIndex = 4;
            btnSaveSettings.Text = "حفظ الاعدادات";
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.Click += btnSave_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 15F);
            label13.Location = new Point(245, 16);
            label13.Name = "label13";
            label13.Size = new Size(107, 28);
            label13.TabIndex = 3;
            label13.Text = "شعار المركز";
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 9F);
            btnDelete.Location = new Point(157, 350);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(115, 59);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "حذف الصورة الحالية";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Font = new Font("Segoe UI", 9F);
            btnBrowse.Location = new Point(312, 350);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(115, 59);
            btnBrowse.TabIndex = 1;
            btnBrowse.Text = "إضافة صورة";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(992, 672);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "إدارة المستخدمين";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // UC_Settings
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(tabControl1);
            Name = "UC_Settings";
            Size = new Size(1000, 700);
            Load += UC_Settings_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel3;
        private Label label3;
        private MaterialSkin.Controls.MaterialTextBox2 txtCenterName;
        private Panel panel8;
        private Label label8;
        private Panel panel7;
        private Label label7;
        private MaterialSkin.Controls.MaterialTextBox2 txtInstagram;
        private Panel panel6;
        private Label label6;
        private MaterialSkin.Controls.MaterialTextBox2 txtFacebook;
        private Panel panel4;
        private Label label4;
        private MaterialSkin.Controls.MaterialTextBox2 txtPhone;
        private Panel panel5;
        private Label label5;
        private MaterialSkin.Controls.MaterialTextBox2 txtWhatsApp;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label1;
        private Label label2;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtInvoiceNote;
        private Panel panel1;
        private Label label12;
        private Label label13;
        private Button btnDelete;
        private Button btnBrowse;
        private Button btnSaveSettings;
        private FontAwesome.Sharp.IconPictureBox picLogo;
    }
}
