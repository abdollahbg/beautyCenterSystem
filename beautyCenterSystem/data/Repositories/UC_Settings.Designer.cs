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
            tbCenterIdentity = new TabPage();
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            label12 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel8 = new Panel();
            txtInvoiceNote = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            label11 = new Label();
            label8 = new Label();
            panel7 = new Panel();
            txtInstagram = new MaterialSkin.Controls.MaterialTextBox2();
            label10 = new Label();
            label7 = new Label();
            panel6 = new Panel();
            txtFacebook = new MaterialSkin.Controls.MaterialTextBox2();
            label9 = new Label();
            label6 = new Label();
            panel4 = new Panel();
            txtPhone = new MaterialSkin.Controls.MaterialTextBox2();
            label1 = new Label();
            label4 = new Label();
            panel5 = new Panel();
            txtWhatsApp = new MaterialSkin.Controls.MaterialTextBox2();
            label2 = new Label();
            label5 = new Label();
            panel3 = new Panel();
            txtCenterName = new MaterialSkin.Controls.MaterialTextBox2();
            label3 = new Label();
            picLogo = new System.Windows.Forms.PictureBox();
            btnSaveSettings = new Button();
            label13 = new Label();
            btnDelete = new Button();
            btnBrowse = new Button();
            tbUsersPermissions = new TabPage();
            splitContainerUsers = new SplitContainer();
            dgvUsers = new DataGridView();
            pnlUsersTop = new Panel();
            btnResetPassword = new Button();
            btnDeleteUser = new Button();
            btnEditUser = new Button();
            btnAddUser = new Button();
            lblUsersTitle = new Label();
            clbPermissions = new CheckedListBox();
            pnlRoleSelection = new Panel();
            btnAddRole = new Button();
            cbRoles = new ComboBox();
            lblSelectRole = new Label();
            pnlRolesBottom = new Panel();
            btnSavePermissions = new Button();
            pnlRolesTop = new Panel();
            lblRolesTitle = new Label();
            tbBackup = new TabPage();
            pnlBackupMain = new Panel();
            gbRestore = new GroupBox();
            lblRestoreWarning = new Label();
            btnRestore = new Button();
            gbAutoBackup = new GroupBox();
            txtAutoBackupPath = new MaterialSkin.Controls.MaterialTextBox2();
            chkEnableAutoBackup = new CheckBox();
            btnBrowseAutoBackup = new Button();
            btnSaveBackupSettings = new Button();
            gbManualBackup = new GroupBox();
            lblManualBackupDesc = new Label();
            btnTakeBackup = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            openFileDialog1 = new OpenFileDialog();
            tabControl1.SuspendLayout();
            tbCenterIdentity.SuspendLayout();
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
            tbUsersPermissions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerUsers).BeginInit();
            splitContainerUsers.Panel1.SuspendLayout();
            splitContainerUsers.Panel2.SuspendLayout();
            splitContainerUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            pnlUsersTop.SuspendLayout();
            pnlRoleSelection.SuspendLayout();
            pnlRolesBottom.SuspendLayout();
            pnlRolesTop.SuspendLayout();
            tbBackup.SuspendLayout();
            pnlBackupMain.SuspendLayout();
            gbRestore.SuspendLayout();
            gbAutoBackup.SuspendLayout();
            gbManualBackup.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbCenterIdentity);
            tabControl1.Controls.Add(tbUsersPermissions);
            tabControl1.Controls.Add(tbBackup);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.Yes;
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1000, 700);
            tabControl1.TabIndex = 0;
            // 
            // tbCenterIdentity
            // 
            tbCenterIdentity.Controls.Add(splitContainer1);
            tbCenterIdentity.Location = new Point(4, 24);
            tbCenterIdentity.Name = "tbCenterIdentity";
            tbCenterIdentity.Padding = new Padding(3);
            tbCenterIdentity.Size = new Size(992, 672);
            tbCenterIdentity.TabIndex = 0;
            tbCenterIdentity.Text = "هوية المركز";
            tbCenterIdentity.UseVisualStyleBackColor = true;
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
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
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
            panel8.Size = new Size(391, 105);
            panel8.TabIndex = 6;
            // 
            // txtInvoiceNote
            // 
            txtInvoiceNote.AnimateReadOnly = false;
            txtInvoiceNote.BackgroundImageLayout = ImageLayout.None;
            txtInvoiceNote.CharacterCasing = CharacterCasing.Normal;
            txtInvoiceNote.Depth = 0;
            txtInvoiceNote.HideSelection = true;
            txtInvoiceNote.Location = new Point(10, 40);
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
            txtInvoiceNote.Size = new Size(370, 60);
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
            panel7.Controls.Add(txtInstagram);
            panel7.Controls.Add(label10);
            panel7.Controls.Add(label7);
            panel7.Location = new Point(3, 250);
            panel7.Name = "panel7";
            panel7.Size = new Size(391, 53);
            panel7.TabIndex = 5;
            // 
            // txtInstagram
            // 
            txtInstagram.AnimateReadOnly = false;
            txtInstagram.AutoCompleteMode = AutoCompleteMode.None;
            txtInstagram.AutoCompleteSource = AutoCompleteSource.None;
            txtInstagram.BackgroundImageLayout = ImageLayout.None;
            txtInstagram.CharacterCasing = CharacterCasing.Normal;
            txtInstagram.Depth = 0;
            txtInstagram.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtInstagram.HideSelection = true;
            txtInstagram.LeadingIcon = null;
            txtInstagram.Location = new Point(10, 3);
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
            txtInstagram.Size = new Size(260, 48);
            txtInstagram.TabIndex = 3;
            txtInstagram.TabStop = false;
            txtInstagram.TextAlign = HorizontalAlignment.Left;
            txtInstagram.TrailingIcon = null;
            txtInstagram.UseSystemPasswordChar = false;
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
            // panel6
            // 
            panel6.Controls.Add(txtFacebook);
            panel6.Controls.Add(label9);
            panel6.Controls.Add(label6);
            panel6.Location = new Point(3, 188);
            panel6.Name = "panel6";
            panel6.Size = new Size(391, 56);
            panel6.TabIndex = 4;
            // 
            // txtFacebook
            // 
            txtFacebook.AnimateReadOnly = false;
            txtFacebook.AutoCompleteMode = AutoCompleteMode.None;
            txtFacebook.AutoCompleteSource = AutoCompleteSource.None;
            txtFacebook.BackgroundImageLayout = ImageLayout.None;
            txtFacebook.CharacterCasing = CharacterCasing.Normal;
            txtFacebook.Depth = 0;
            txtFacebook.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtFacebook.HideSelection = true;
            txtFacebook.LeadingIcon = null;
            txtFacebook.Location = new Point(10, 3);
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
            txtFacebook.Size = new Size(260, 48);
            txtFacebook.TabIndex = 3;
            txtFacebook.TabStop = false;
            txtFacebook.TextAlign = HorizontalAlignment.Left;
            txtFacebook.TrailingIcon = null;
            txtFacebook.UseSystemPasswordChar = false;
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
            // panel4
            // 
            panel4.Controls.Add(txtPhone);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(3, 64);
            panel4.Name = "panel4";
            panel4.Size = new Size(391, 54);
            panel4.TabIndex = 3;
            // 
            // txtPhone
            // 
            txtPhone.AnimateReadOnly = false;
            txtPhone.AutoCompleteMode = AutoCompleteMode.None;
            txtPhone.AutoCompleteSource = AutoCompleteSource.None;
            txtPhone.BackgroundImageLayout = ImageLayout.None;
            txtPhone.CharacterCasing = CharacterCasing.Normal;
            txtPhone.Depth = 0;
            txtPhone.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPhone.HideSelection = true;
            txtPhone.LeadingIcon = null;
            txtPhone.Location = new Point(10, 3);
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
            txtPhone.Size = new Size(260, 48);
            txtPhone.TabIndex = 3;
            txtPhone.TabStop = false;
            txtPhone.TextAlign = HorizontalAlignment.Left;
            txtPhone.TrailingIcon = null;
            txtPhone.UseSystemPasswordChar = false;
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
            // panel5
            // 
            panel5.Controls.Add(txtWhatsApp);
            panel5.Controls.Add(label2);
            panel5.Controls.Add(label5);
            panel5.Location = new Point(3, 124);
            panel5.Name = "panel5";
            panel5.Size = new Size(391, 58);
            panel5.TabIndex = 2;
            // 
            // txtWhatsApp
            // 
            txtWhatsApp.AnimateReadOnly = false;
            txtWhatsApp.AutoCompleteMode = AutoCompleteMode.None;
            txtWhatsApp.AutoCompleteSource = AutoCompleteSource.None;
            txtWhatsApp.BackgroundImageLayout = ImageLayout.None;
            txtWhatsApp.CharacterCasing = CharacterCasing.Normal;
            txtWhatsApp.Depth = 0;
            txtWhatsApp.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtWhatsApp.HideSelection = true;
            txtWhatsApp.LeadingIcon = null;
            txtWhatsApp.Location = new Point(10, 3);
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
            txtWhatsApp.Size = new Size(260, 48);
            txtWhatsApp.TabIndex = 3;
            txtWhatsApp.TabStop = false;
            txtWhatsApp.TextAlign = HorizontalAlignment.Left;
            txtWhatsApp.TrailingIcon = null;
            txtWhatsApp.UseSystemPasswordChar = false;
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
            // panel3
            // 
            panel3.Controls.Add(txtCenterName);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(391, 55);
            panel3.TabIndex = 0;
            // 
            // txtCenterName
            // 
            txtCenterName.AnimateReadOnly = false;
            txtCenterName.AutoCompleteMode = AutoCompleteMode.None;
            txtCenterName.AutoCompleteSource = AutoCompleteSource.None;
            txtCenterName.BackgroundImageLayout = ImageLayout.None;
            txtCenterName.CharacterCasing = CharacterCasing.Normal;
            txtCenterName.Depth = 0;
            txtCenterName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCenterName.HideSelection = true;
            txtCenterName.LeadingIcon = null;
            txtCenterName.Location = new Point(10, 3);
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
            txtCenterName.Size = new Size(260, 48);
            txtCenterName.TabIndex = 2;
            txtCenterName.TabStop = false;
            txtCenterName.TextAlign = HorizontalAlignment.Left;
            txtCenterName.TrailingIcon = null;
            txtCenterName.UseSystemPasswordChar = false;
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
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.ForeColor = SystemColors.ControlText;
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
            btnSaveSettings.Click += btnSaveSettings_Click;
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
            // tbUsersPermissions
            // 
            tbUsersPermissions.Controls.Add(splitContainerUsers);
            tbUsersPermissions.Location = new Point(4, 24);
            tbUsersPermissions.Name = "tbUsersPermissions";
            tbUsersPermissions.Padding = new Padding(3);
            tbUsersPermissions.Size = new Size(992, 672);
            tbUsersPermissions.TabIndex = 1;
            tbUsersPermissions.Text = "المستخدمين والصلاحيات";
            tbUsersPermissions.UseVisualStyleBackColor = true;
            // 
            // splitContainerUsers
            // 
            splitContainerUsers.Dock = DockStyle.Fill;
            splitContainerUsers.Location = new Point(3, 3);
            splitContainerUsers.Name = "splitContainerUsers";
            // 
            // splitContainerUsers.Panel1
            // 
            splitContainerUsers.Panel1.Controls.Add(dgvUsers);
            splitContainerUsers.Panel1.Controls.Add(pnlUsersTop);
            splitContainerUsers.Panel1.RightToLeft = RightToLeft.Yes;
            // 
            // splitContainerUsers.Panel2
            // 
            splitContainerUsers.Panel2.Controls.Add(clbPermissions);
            splitContainerUsers.Panel2.Controls.Add(pnlRoleSelection);
            splitContainerUsers.Panel2.Controls.Add(pnlRolesBottom);
            splitContainerUsers.Panel2.Controls.Add(pnlRolesTop);
            splitContainerUsers.Panel2.RightToLeft = RightToLeft.Yes;
            splitContainerUsers.Size = new Size(986, 666);
            splitContainerUsers.SplitterDistance = 600;
            splitContainerUsers.TabIndex = 0;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(0, 70);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowTemplate.Height = 35;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(600, 596);
            dgvUsers.TabIndex = 1;
            // 
            // pnlUsersTop
            // 
            pnlUsersTop.Controls.Add(btnResetPassword);
            pnlUsersTop.Controls.Add(btnDeleteUser);
            pnlUsersTop.Controls.Add(btnEditUser);
            pnlUsersTop.Controls.Add(btnAddUser);
            pnlUsersTop.Controls.Add(lblUsersTitle);
            pnlUsersTop.Dock = DockStyle.Top;
            pnlUsersTop.Location = new Point(0, 0);
            pnlUsersTop.Name = "pnlUsersTop";
            pnlUsersTop.Size = new Size(600, 70);
            pnlUsersTop.TabIndex = 0;
            // 
            // btnResetPassword
            // 
            btnResetPassword.Font = new Font("Segoe UI", 10F);
            btnResetPassword.Location = new Point(10, 15);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(100, 40);
            btnResetPassword.TabIndex = 4;
            btnResetPassword.Text = "إعادة تعيين المرور";
            btnResetPassword.UseVisualStyleBackColor = true;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Font = new Font("Segoe UI", 10F);
            btnDeleteUser.Location = new Point(120, 15);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(90, 40);
            btnDeleteUser.TabIndex = 3;
            btnDeleteUser.Text = "حذف";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnEditUser
            // 
            btnEditUser.Font = new Font("Segoe UI", 10F);
            btnEditUser.Location = new Point(220, 15);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(90, 40);
            btnEditUser.TabIndex = 2;
            btnEditUser.Text = "تعديل";
            btnEditUser.UseVisualStyleBackColor = true;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // btnAddUser
            // 
            btnAddUser.Font = new Font("Segoe UI", 10F);
            btnAddUser.Location = new Point(320, 15);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(100, 40);
            btnAddUser.TabIndex = 1;
            btnAddUser.Text = "إضافة مستخدم";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // lblUsersTitle
            // 
            lblUsersTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUsersTitle.AutoSize = true;
            lblUsersTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblUsersTitle.Location = new Point(430, 20);
            lblUsersTitle.Name = "lblUsersTitle";
            lblUsersTitle.Size = new Size(156, 28);
            lblUsersTitle.TabIndex = 0;
            lblUsersTitle.Text = "إدارة المستخدمين";
            // 
            // clbPermissions
            // 
            clbPermissions.CheckOnClick = true;
            clbPermissions.Dock = DockStyle.Fill;
            clbPermissions.Font = new Font("Segoe UI", 12F);
            clbPermissions.FormattingEnabled = true;
            clbPermissions.Location = new Point(0, 110);
            clbPermissions.Name = "clbPermissions";
            clbPermissions.Size = new Size(382, 486);
            clbPermissions.TabIndex = 2;
            // 
            // pnlRoleSelection
            // 
            pnlRoleSelection.Controls.Add(btnAddRole);
            pnlRoleSelection.Controls.Add(cbRoles);
            pnlRoleSelection.Controls.Add(lblSelectRole);
            pnlRoleSelection.Dock = DockStyle.Top;
            pnlRoleSelection.Location = new Point(0, 50);
            pnlRoleSelection.Name = "pnlRoleSelection";
            pnlRoleSelection.Size = new Size(382, 60);
            pnlRoleSelection.TabIndex = 1;
            // 
            // btnAddRole
            // 
            btnAddRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddRole.Font = new Font("Segoe UI", 10F);
            btnAddRole.Location = new Point(10, 11);
            btnAddRole.Name = "btnAddRole";
            btnAddRole.Size = new Size(90, 31);
            btnAddRole.TabIndex = 2;
            btnAddRole.Text = "دور جديد";
            btnAddRole.UseVisualStyleBackColor = true;
            btnAddRole.Click += btnAddRole_Click;
            // 
            // cbRoles
            // 
            cbRoles.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRoles.Font = new Font("Segoe UI", 12F);
            cbRoles.FormattingEnabled = true;
            cbRoles.Location = new Point(110, 12);
            cbRoles.Name = "cbRoles";
            cbRoles.Size = new Size(170, 29);
            cbRoles.TabIndex = 1;
            cbRoles.SelectedIndexChanged += cbRoles_SelectedIndexChanged;
            // 
            // lblSelectRole
            // 
            lblSelectRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSelectRole.AutoSize = true;
            lblSelectRole.Font = new Font("Segoe UI", 12F);
            lblSelectRole.Location = new Point(290, 15);
            lblSelectRole.Name = "lblSelectRole";
            lblSelectRole.Size = new Size(74, 21);
            lblSelectRole.TabIndex = 0;
            lblSelectRole.Text = "اختر الدور:";
            // 
            // pnlRolesBottom
            // 
            pnlRolesBottom.Controls.Add(btnSavePermissions);
            pnlRolesBottom.Dock = DockStyle.Bottom;
            pnlRolesBottom.Location = new Point(0, 596);
            pnlRolesBottom.Name = "pnlRolesBottom";
            pnlRolesBottom.Size = new Size(382, 70);
            pnlRolesBottom.TabIndex = 3;
            // 
            // btnSavePermissions
            // 
            btnSavePermissions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSavePermissions.Font = new Font("Segoe UI", 14F);
            btnSavePermissions.Location = new Point(10, 10);
            btnSavePermissions.Name = "btnSavePermissions";
            btnSavePermissions.Size = new Size(362, 50);
            btnSavePermissions.TabIndex = 0;
            btnSavePermissions.Text = "حفظ صلاحيات الدور المختار";
            btnSavePermissions.UseVisualStyleBackColor = true;
            btnSavePermissions.Click += btnSavePermissions_Click;
            // 
            // pnlRolesTop
            // 
            pnlRolesTop.Controls.Add(lblRolesTitle);
            pnlRolesTop.Dock = DockStyle.Top;
            pnlRolesTop.Location = new Point(0, 0);
            pnlRolesTop.Name = "pnlRolesTop";
            pnlRolesTop.Size = new Size(382, 50);
            pnlRolesTop.TabIndex = 0;
            // 
            // lblRolesTitle
            // 
            lblRolesTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRolesTitle.AutoSize = true;
            lblRolesTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblRolesTitle.Location = new Point(150, 10);
            lblRolesTitle.Name = "lblRolesTitle";
            lblRolesTitle.Size = new Size(206, 28);
            lblRolesTitle.TabIndex = 0;
            lblRolesTitle.Text = "إدارة الأدوار والصلاحيات";
            // 
            // tbBackup
            // 
            tbBackup.Controls.Add(pnlBackupMain);
            tbBackup.Location = new Point(4, 24);
            tbBackup.Name = "tbBackup";
            tbBackup.Padding = new Padding(3);
            tbBackup.Size = new Size(992, 672);
            tbBackup.TabIndex = 2;
            tbBackup.Text = "النسخ الاحتياطي والاستعادة";
            tbBackup.UseVisualStyleBackColor = true;
            // 
            // pnlBackupMain
            // 
            pnlBackupMain.Controls.Add(gbRestore);
            pnlBackupMain.Controls.Add(gbAutoBackup);
            pnlBackupMain.Controls.Add(gbManualBackup);
            pnlBackupMain.Dock = DockStyle.Fill;
            pnlBackupMain.Location = new Point(3, 3);
            pnlBackupMain.Name = "pnlBackupMain";
            pnlBackupMain.Padding = new Padding(20);
            pnlBackupMain.Size = new Size(986, 666);
            pnlBackupMain.TabIndex = 0;
            // 
            // gbRestore
            // 
            gbRestore.Controls.Add(lblRestoreWarning);
            gbRestore.Controls.Add(btnRestore);
            gbRestore.Dock = DockStyle.Top;
            gbRestore.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            gbRestore.Location = new Point(20, 320);
            gbRestore.Name = "gbRestore";
            gbRestore.Size = new Size(946, 130);
            gbRestore.TabIndex = 2;
            gbRestore.TabStop = false;
            gbRestore.Text = "استعادة البيانات (خطر)";
            // 
            // lblRestoreWarning
            // 
            lblRestoreWarning.AutoSize = true;
            lblRestoreWarning.Font = new Font("Segoe UI", 11F);
            lblRestoreWarning.ForeColor = Color.DarkRed;
            lblRestoreWarning.Location = new Point(480, 55);
            lblRestoreWarning.Name = "lblRestoreWarning";
            lblRestoreWarning.Size = new Size(484, 20);
            lblRestoreWarning.TabIndex = 1;
            lblRestoreWarning.Text = "تحذير: استعادة قاعدة البيانات ستؤدي إلى مسح جميع البيانات الحالية بالكامل!";
            // 
            // btnRestore
            // 
            btnRestore.Font = new Font("Segoe UI", 12F);
            btnRestore.ForeColor = Color.DarkRed;
            btnRestore.Location = new Point(50, 40);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(220, 50);
            btnRestore.TabIndex = 0;
            btnRestore.Text = "استعادة من ملف احتياطي";
            btnRestore.UseVisualStyleBackColor = true;
            // 
            // gbAutoBackup
            // 
            gbAutoBackup.Controls.Add(txtAutoBackupPath);
            gbAutoBackup.Controls.Add(chkEnableAutoBackup);
            gbAutoBackup.Controls.Add(btnBrowseAutoBackup);
            gbAutoBackup.Controls.Add(btnSaveBackupSettings);
            gbAutoBackup.Dock = DockStyle.Top;
            gbAutoBackup.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            gbAutoBackup.Location = new Point(20, 140);
            gbAutoBackup.Name = "gbAutoBackup";
            gbAutoBackup.Size = new Size(946, 180);
            gbAutoBackup.TabIndex = 1;
            gbAutoBackup.TabStop = false;
            gbAutoBackup.Text = "النسخ الاحتياطي التلقائي";
            // 
            // txtAutoBackupPath
            // 
            txtAutoBackupPath.AnimateReadOnly = false;
            txtAutoBackupPath.AutoCompleteMode = AutoCompleteMode.None;
            txtAutoBackupPath.AutoCompleteSource = AutoCompleteSource.None;
            txtAutoBackupPath.BackgroundImageLayout = ImageLayout.None;
            txtAutoBackupPath.CharacterCasing = CharacterCasing.Normal;
            txtAutoBackupPath.Depth = 0;
            txtAutoBackupPath.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAutoBackupPath.HideSelection = true;
            txtAutoBackupPath.Hint = "مسار النسخ التلقائي";
            txtAutoBackupPath.LeadingIcon = null;
            txtAutoBackupPath.Location = new Point(176, 80);
            txtAutoBackupPath.MaxLength = 32767;
            txtAutoBackupPath.MouseState = MaterialSkin.MouseState.OUT;
            txtAutoBackupPath.Name = "txtAutoBackupPath";
            txtAutoBackupPath.PasswordChar = '\0';
            txtAutoBackupPath.PrefixSuffixText = null;
            txtAutoBackupPath.ReadOnly = true;
            txtAutoBackupPath.RightToLeft = RightToLeft.No;
            txtAutoBackupPath.SelectedText = "";
            txtAutoBackupPath.SelectionLength = 0;
            txtAutoBackupPath.SelectionStart = 0;
            txtAutoBackupPath.ShortcutsEnabled = true;
            txtAutoBackupPath.Size = new Size(728, 48);
            txtAutoBackupPath.TabIndex = 4;
            txtAutoBackupPath.TabStop = false;
            txtAutoBackupPath.TextAlign = HorizontalAlignment.Left;
            txtAutoBackupPath.TrailingIcon = null;
            txtAutoBackupPath.UseSystemPasswordChar = false;
            // 
            // chkEnableAutoBackup
            // 
            chkEnableAutoBackup.AutoSize = true;
            chkEnableAutoBackup.Font = new Font("Segoe UI", 12F);
            chkEnableAutoBackup.Location = new Point(563, 40);
            chkEnableAutoBackup.Name = "chkEnableAutoBackup";
            chkEnableAutoBackup.Size = new Size(341, 25);
            chkEnableAutoBackup.TabIndex = 0;
            chkEnableAutoBackup.Text = "تفعيل النسخ الاحتياطي التلقائي عند إغلاق البرنامج";
            chkEnableAutoBackup.UseVisualStyleBackColor = true;
            // 
            // btnBrowseAutoBackup
            // 
            btnBrowseAutoBackup.Font = new Font("Segoe UI", 11F);
            btnBrowseAutoBackup.Location = new Point(50, 80);
            btnBrowseAutoBackup.Name = "btnBrowseAutoBackup";
            btnBrowseAutoBackup.Size = new Size(120, 48);
            btnBrowseAutoBackup.TabIndex = 2;
            btnBrowseAutoBackup.Text = "استعراض...";
            btnBrowseAutoBackup.UseVisualStyleBackColor = true;
            // 
            // btnSaveBackupSettings
            // 
            btnSaveBackupSettings.Font = new Font("Segoe UI", 11F);
            btnSaveBackupSettings.Location = new Point(50, 135);
            btnSaveBackupSettings.Name = "btnSaveBackupSettings";
            btnSaveBackupSettings.Size = new Size(220, 40);
            btnSaveBackupSettings.TabIndex = 3;
            btnSaveBackupSettings.Text = "حفظ إعدادات النسخ";
            btnSaveBackupSettings.UseVisualStyleBackColor = true;
            // 
            // gbManualBackup
            // 
            gbManualBackup.Controls.Add(lblManualBackupDesc);
            gbManualBackup.Controls.Add(btnTakeBackup);
            gbManualBackup.Dock = DockStyle.Top;
            gbManualBackup.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            gbManualBackup.Location = new Point(20, 20);
            gbManualBackup.Name = "gbManualBackup";
            gbManualBackup.Size = new Size(946, 120);
            gbManualBackup.TabIndex = 0;
            gbManualBackup.TabStop = false;
            gbManualBackup.Text = "النسخ الاحتياطي اليدوي";
            // 
            // lblManualBackupDesc
            // 
            lblManualBackupDesc.AutoSize = true;
            lblManualBackupDesc.Font = new Font("Segoe UI", 11F);
            lblManualBackupDesc.ForeColor = Color.DimGray;
            lblManualBackupDesc.Location = new Point(560, 45);
            lblManualBackupDesc.Name = "lblManualBackupDesc";
            lblManualBackupDesc.Size = new Size(395, 20);
            lblManualBackupDesc.TabIndex = 1;
            lblManualBackupDesc.Text = "قم بإنشاء نسخة احتياطية فورية لبيانات النظام في مسار محدد.";
            // 
            // btnTakeBackup
            // 
            btnTakeBackup.Font = new Font("Segoe UI", 12F);
            btnTakeBackup.Location = new Point(50, 40);
            btnTakeBackup.Name = "btnTakeBackup";
            btnTakeBackup.Size = new Size(220, 50);
            btnTakeBackup.TabIndex = 0;
            btnTakeBackup.Text = "إنشاء نسخة احتياطية الآن";
            btnTakeBackup.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Backup Files (*.bak)|*.bak|All Files (*.*)|*.*";
            openFileDialog1.Title = "اختر ملف النسخة الاحتياطية للاستعادة";
            // 
            // UC_Settings
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(tabControl1);
            Name = "UC_Settings";
            Size = new Size(1000, 700);
            tabControl1.ResumeLayout(false);
            tbCenterIdentity.ResumeLayout(false);
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
            tbUsersPermissions.ResumeLayout(false);
            splitContainerUsers.Panel1.ResumeLayout(false);
            splitContainerUsers.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerUsers).EndInit();
            splitContainerUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            pnlUsersTop.ResumeLayout(false);
            pnlUsersTop.PerformLayout();
            pnlRoleSelection.ResumeLayout(false);
            pnlRoleSelection.PerformLayout();
            pnlRolesBottom.ResumeLayout(false);
            pnlRolesTop.ResumeLayout(false);
            pnlRolesTop.PerformLayout();
            tbBackup.ResumeLayout(false);
            pnlBackupMain.ResumeLayout(false);
            gbRestore.ResumeLayout(false);
            gbRestore.PerformLayout();
            gbAutoBackup.ResumeLayout(false);
            gbAutoBackup.PerformLayout();
            gbManualBackup.ResumeLayout(false);
            gbManualBackup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tbCenterIdentity;
        private TabPage tbUsersPermissions;
        private TabPage tbBackup;

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
        private System.Windows.Forms.PictureBox picLogo;

        private SplitContainer splitContainerUsers;

        private Panel pnlUsersTop;
        private Label lblUsersTitle;
        private Button btnAddUser;
        private Button btnEditUser;
        private Button btnDeleteUser;
        private Button btnResetPassword;
        private DataGridView dgvUsers;

        private Panel pnlRolesTop;
        private Label lblRolesTitle;
        private Panel pnlRoleSelection;
        private Label lblSelectRole;
        private ComboBox cbRoles;
        private Button btnAddRole;
        private CheckedListBox clbPermissions;
        private Panel pnlRolesBottom;
        private Button btnSavePermissions;

        private Panel pnlBackupMain;
        private GroupBox gbManualBackup;
        private Button btnTakeBackup;
        private Label lblManualBackupDesc;

        private GroupBox gbAutoBackup;
        private CheckBox chkEnableAutoBackup;
        private MaterialSkin.Controls.MaterialTextBox2 txtAutoBackupPath;
        private Button btnBrowseAutoBackup;
        private Button btnSaveBackupSettings;

        private GroupBox gbRestore;
        private Button btnRestore;
        private Label lblRestoreWarning;

        private FolderBrowserDialog folderBrowserDialog1;
        private OpenFileDialog openFileDialog1;
    }
}