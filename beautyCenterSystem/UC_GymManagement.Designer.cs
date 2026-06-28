using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;
using FontAwesome.Sharp;

namespace beautyCenterSystem
{
    partial class UC_GymManagement
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

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            btnFilter = new Button();
            dtpTo = new DateTimePicker();
            lblTo = new Label();
            dtpFrom = new DateTimePicker();
            lblFrom = new Label();
            txtBoxsearch = new MaterialTextBox2();
            lblTitle = new Label();
            tabControlGym = new TabControl();
            tabActive = new TabPage();
            dgvActive = new DataGridView();
            btnNewSubscription = new Button();
            btnCheckIn = new Button();
            btnPrintReceipt = new Button();
            btnCancelSubscription = new Button();
            tabNearExpiry = new TabPage();
            dgvNearExpiry = new DataGridView();
            btnRenew = new Button();
            tabExpired = new TabPage();
            dgvExpired = new DataGridView();
            tabPackages = new TabPage();
            dgvPackages = new DataGridView();
            btnAddNewPackage = new Button();
            btnEditPackage = new Button();
            btnDeletePackage = new Button();
            flpSearch = new FlowLayoutPanel();
            cmbFilterPackage = new ComboBox();
            pnlHeader.SuspendLayout();
            flpSearch.SuspendLayout();
            tabControlGym.SuspendLayout();
            tabActive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActive).BeginInit();
            tabNearExpiry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNearExpiry).BeginInit();
            tabExpired.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpired).BeginInit();
            tabPackages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPackages).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(btnFilter);
            pnlHeader.Controls.Add(dtpTo);
            pnlHeader.Controls.Add(lblTo);
            pnlHeader.Controls.Add(dtpFrom);
            pnlHeader.Controls.Add(lblFrom);
            pnlHeader.Controls.Add(flpSearch);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(800, 120);
            pnlHeader.TabIndex = 1;
            // 
            // btnFilter
            // 
            btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilter.Location = new Point(70, 65);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(100, 35);
            btnFilter.TabIndex = 7;
            btnFilter.Text = "تحديث";
            // 
            // dtpTo
            // 
            dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(190, 70);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(140, 23);
            dtpTo.TabIndex = 6;
            dtpTo.Value = new DateTime(2026, 6, 21, 2, 39, 38, 808);
            // 
            // lblTo
            // 
            lblTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTo.AutoSize = true;
            lblTo.Location = new Point(340, 75);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(54, 15);
            lblTo.TabIndex = 5;
            lblTo.Text = "إلى تاريخ:";
            // 
            // dtpFrom
            // 
            dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(410, 70);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(140, 23);
            dtpFrom.TabIndex = 4;
            dtpFrom.Value = new DateTime(2026, 3, 21, 2, 39, 38, 812);
            // 
            // lblFrom
            // 
            lblFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(560, 75);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(52, 15);
            lblFrom.TabIndex = 3;
            lblFrom.Text = "من تاريخ:";
            // 
            // txtBoxsearch
            // 
            txtBoxsearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBoxsearch.AnimateReadOnly = false;
            txtBoxsearch.AutoCompleteMode = AutoCompleteMode.None;
            txtBoxsearch.AutoCompleteSource = AutoCompleteSource.None;
            txtBoxsearch.BackgroundImageLayout = ImageLayout.None;
            txtBoxsearch.CharacterCasing = CharacterCasing.Normal;
            txtBoxsearch.Depth = 0;
            txtBoxsearch.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBoxsearch.HideSelection = true;
            txtBoxsearch.Hint = "البحث";
            txtBoxsearch.LeadingIcon = null;
            txtBoxsearch.Location = new Point(3, 3);
            txtBoxsearch.Margin = new Padding(3, 3, 20, 3);
            txtBoxsearch.MaxLength = 32767;
            txtBoxsearch.MouseState = MaterialSkin.MouseState.OUT;
            txtBoxsearch.Name = "txtBoxsearch";
            txtBoxsearch.PasswordChar = '\0';
            txtBoxsearch.PrefixSuffixText = null;
            txtBoxsearch.ReadOnly = false;
            txtBoxsearch.RightToLeft = RightToLeft.No;
            txtBoxsearch.SelectedText = "";
            txtBoxsearch.SelectionLength = 0;
            txtBoxsearch.SelectionStart = 0;
            txtBoxsearch.ShortcutsEnabled = true;
            txtBoxsearch.Size = new Size(397, 48);
            txtBoxsearch.TabIndex = 2;
            txtBoxsearch.TabStop = false;
            txtBoxsearch.TextAlign = HorizontalAlignment.Left;
            txtBoxsearch.TrailingIcon = null;
            txtBoxsearch.UseSystemPasswordChar = false;
            // 
            // flpSearch
            // 
            flpSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flpSearch.Controls.Add(txtBoxsearch);
            flpSearch.Controls.Add(cmbFilterPackage);
            flpSearch.FlowDirection = FlowDirection.RightToLeft;
            flpSearch.Location = new Point(10, 10);
            flpSearch.Name = "flpSearch";
            flpSearch.Size = new Size(640, 55);
            flpSearch.TabIndex = 8;
            // 
            // cmbFilterPackage
            // 
            cmbFilterPackage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterPackage.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            cmbFilterPackage.FormattingEnabled = true;
            cmbFilterPackage.Location = new Point(410, 10);
            cmbFilterPackage.Margin = new Padding(3, 10, 3, 3);
            cmbFilterPackage.Name = "cmbFilterPackage";
            cmbFilterPackage.Size = new Size(200, 32);
            cmbFilterPackage.TabIndex = 9;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(659, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(117, 15);
            lblTitle.TabIndex = 1;
            lblTitle.Tag = "Header";
            lblTitle.Text = "إدارة الجيم والاشتراكات";
            // 
            // tabControlGym
            // 
            tabControlGym.Controls.Add(tabActive);
            tabControlGym.Controls.Add(tabNearExpiry);
            tabControlGym.Controls.Add(tabExpired);
            tabControlGym.Controls.Add(tabPackages);
            tabControlGym.Dock = DockStyle.Fill;
            tabControlGym.Location = new Point(0, 120);
            tabControlGym.Name = "tabControlGym";
            tabControlGym.RightToLeft = RightToLeft.Yes;
            tabControlGym.RightToLeftLayout = true;
            tabControlGym.SelectedIndex = 0;
            tabControlGym.Size = new Size(800, 480);
            tabControlGym.TabIndex = 0;
            // 
            // tabActive
            // 
            tabActive.Controls.Add(dgvActive);
            tabActive.Controls.Add(btnNewSubscription);
            tabActive.Controls.Add(btnCheckIn);
            tabActive.Controls.Add(btnCancelSubscription);
            tabActive.Controls.Add(btnPrintReceipt);
            tabActive.Location = new Point(4, 24);
            tabActive.Name = "tabActive";
            tabActive.Padding = new Padding(10);
            tabActive.Size = new Size(792, 452);
            tabActive.TabIndex = 0;
            tabActive.Text = "الاشتراكات السارية";
            // 
            // dgvActive
            // 
            dgvActive.Dock = DockStyle.Top;
            dgvActive.Location = new Point(10, 10);
            dgvActive.Name = "dgvActive";
            dgvActive.ReadOnly = true;
            dgvActive.Size = new Size(772, 380);
            dgvActive.TabIndex = 0;
            // 
            // btnNewSubscription
            // 
            btnNewSubscription.Location = new Point(10, 400);
            btnNewSubscription.Name = "btnNewSubscription";
            btnNewSubscription.Size = new Size(150, 40);
            btnNewSubscription.TabIndex = 1;
            btnNewSubscription.Text = "اشتراك جديد";
            // 
            // btnCheckIn
            // 
            btnCheckIn.Location = new Point(180, 400);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(150, 40);
            btnCheckIn.TabIndex = 2;
            btnCheckIn.Text = "تسجيل حصة";
            btnCheckIn.UseVisualStyleBackColor = true;
            // 
            // btnPrintReceipt
            // 
            btnPrintReceipt.Location = new Point(350, 400);
            btnPrintReceipt.Name = "btnPrintReceipt";
            btnPrintReceipt.Size = new Size(150, 40);
            btnPrintReceipt.TabIndex = 3;
            btnPrintReceipt.Text = "🖨️ طباعة وصل";
            btnPrintReceipt.UseVisualStyleBackColor = true;
            // 
            // btnCancelSubscription
            // 
            btnCancelSubscription.Location = new Point(520, 400);
            btnCancelSubscription.Name = "btnCancelSubscription";
            btnCancelSubscription.Size = new Size(150, 40);
            btnCancelSubscription.TabIndex = 4;
            btnCancelSubscription.Text = "إلغاء الاشتراك";
            btnCancelSubscription.UseVisualStyleBackColor = true;
            // 
            // tabNearExpiry
            // 
            tabNearExpiry.Controls.Add(dgvNearExpiry);
            tabNearExpiry.Controls.Add(btnRenew);
            tabNearExpiry.Location = new Point(4, 24);
            tabNearExpiry.Name = "tabNearExpiry";
            tabNearExpiry.Padding = new Padding(10);
            tabNearExpiry.Size = new Size(792, 452);
            tabNearExpiry.TabIndex = 1;
            tabNearExpiry.Text = "قرب الانتهاء";
            // 
            // dgvNearExpiry
            // 
            dgvNearExpiry.Dock = DockStyle.Top;
            dgvNearExpiry.Location = new Point(10, 10);
            dgvNearExpiry.Name = "dgvNearExpiry";
            dgvNearExpiry.ReadOnly = true;
            dgvNearExpiry.Size = new Size(772, 380);
            dgvNearExpiry.TabIndex = 0;
            // 
            // btnRenew
            // 
            btnRenew.Location = new Point(10, 400);
            btnRenew.Name = "btnRenew";
            btnRenew.Size = new Size(150, 40);
            btnRenew.TabIndex = 1;
            btnRenew.Text = "تجديد الاشتراك";
            // 
            // tabExpired
            // 
            tabExpired.Controls.Add(dgvExpired);
            tabExpired.Location = new Point(4, 24);
            tabExpired.Name = "tabExpired";
            tabExpired.Padding = new Padding(10);
            tabExpired.Size = new Size(792, 452);
            tabExpired.TabIndex = 2;
            tabExpired.Text = "المنتهية";
            // 
            // dgvExpired
            // 
            dgvExpired.Dock = DockStyle.Fill;
            dgvExpired.Location = new Point(10, 10);
            dgvExpired.Name = "dgvExpired";
            dgvExpired.ReadOnly = true;
            dgvExpired.Size = new Size(772, 432);
            dgvExpired.TabIndex = 0;
            // 
            // tabPackages
            // 
            tabPackages.Controls.Add(dgvPackages);
            tabPackages.Controls.Add(btnAddNewPackage);
            tabPackages.Controls.Add(btnEditPackage);
            tabPackages.Controls.Add(btnDeletePackage);
            tabPackages.Location = new Point(4, 24);
            tabPackages.Name = "tabPackages";
            tabPackages.Padding = new Padding(10);
            tabPackages.Size = new Size(792, 452);
            tabPackages.TabIndex = 3;
            tabPackages.Text = "إعدادات الباقات";
            // 
            // dgvPackages
            // 
            dgvPackages.Dock = DockStyle.Top;
            dgvPackages.Location = new Point(10, 10);
            dgvPackages.Name = "dgvPackages";
            dgvPackages.ReadOnly = true;
            dgvPackages.Size = new Size(772, 300);
            dgvPackages.TabIndex = 0;
            // 
            // btnAddNewPackage
            // 
            btnAddNewPackage.Location = new Point(10, 320);
            btnAddNewPackage.Name = "btnAddNewPackage";
            btnAddNewPackage.Size = new Size(150, 40);
            btnAddNewPackage.TabIndex = 1;
            btnAddNewPackage.Text = "إضافة باقة";
            // 
            // btnEditPackage
            // 
            btnEditPackage.Enabled = false;
            btnEditPackage.Location = new Point(180, 320);
            btnEditPackage.Name = "btnEditPackage";
            btnEditPackage.Size = new Size(150, 40);
            btnEditPackage.TabIndex = 2;
            btnEditPackage.Text = "تعديل الباقة";
            // 
            // btnDeletePackage
            // 
            btnDeletePackage.Location = new Point(350, 320);
            btnDeletePackage.Name = "btnDeletePackage";
            btnDeletePackage.Size = new Size(150, 40);
            btnDeletePackage.TabIndex = 3;
            btnDeletePackage.Text = "حذف الباقة";
            // 
            // UC_GymManagement
            // 
            Controls.Add(tabControlGym);
            Controls.Add(pnlHeader);
            Name = "UC_GymManagement";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(800, 600);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tabControlGym.ResumeLayout(false);
            tabActive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvActive).EndInit();
            tabNearExpiry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNearExpiry).EndInit();
            tabExpired.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExpired).EndInit();
            tabPackages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPackages).EndInit();
            flpSearch.ResumeLayout(false);
            flpSearch.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label lblTitle;

        private Label lblFrom;
        private DateTimePicker dtpFrom;
        private Label lblTo;
        private DateTimePicker dtpTo;
        private Button btnFilter;

        private TabControl tabControlGym;
        private TabPage tabActive;
        private TabPage tabNearExpiry;
        private TabPage tabExpired;
        private TabPage tabPackages;

        private DataGridView dgvActive;
        private Button btnNewSubscription;
        private Button btnCheckIn;
        private Button btnPrintReceipt;
        private Button btnCancelSubscription;

        private DataGridView dgvNearExpiry;
        private Button btnRenew;

        private DataGridView dgvExpired;

        private DataGridView dgvPackages;
        private Button btnAddNewPackage;
        private Button btnEditPackage;
        private Button btnDeletePackage;
        private MaterialTextBox2 txtBoxsearch;
        private FlowLayoutPanel flpSearch;
        private ComboBox cmbFilterPackage;
    }
}