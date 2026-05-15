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
            btnOpenGate = new Button();
            lblTitle = new Label();
            tabControlGym = new TabControl();
            tabActive = new TabPage();
            dgvActive = new DataGridView();
            btnNewSubscription = new Button();
            btnCheckIn = new Button();
            tabNearExpiry = new TabPage();
            dgvNearExpiry = new DataGridView();
            btnRenew = new Button();
            tabExpired = new TabPage();
            dgvExpired = new DataGridView();
            tabPackages = new TabPage();
            dgvPackages = new DataGridView();
            txtPackageName = new MaterialTextBox();
            txtDurationDays = new MaterialTextBox();
            txtPrice = new MaterialTextBox();
            txtTotalSessions = new MaterialTextBox();
            chkIsSessionBased = new CheckBox();
            btnSavePackage = new Button();
            btnDeletePackage = new Button();
            pnlHeader.SuspendLayout();
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
            pnlHeader.Controls.Add(btnOpenGate);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(800, 70);
            pnlHeader.TabIndex = 1;
            // 
            // btnOpenGate
            // 
            btnOpenGate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenGate.Location = new Point(1100, 15);
            btnOpenGate.Name = "btnOpenGate";
            btnOpenGate.Size = new Size(180, 40);
            btnOpenGate.TabIndex = 0;
            btnOpenGate.Text = "نظام بوابة الدخول";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 20);
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
            tabControlGym.Location = new Point(0, 70);
            tabControlGym.Name = "tabControlGym";
            tabControlGym.SelectedIndex = 0;
            tabControlGym.Size = new Size(800, 530);
            tabControlGym.TabIndex = 0;
            // 
            // tabActive
            // 
            tabActive.Controls.Add(dgvActive);
            tabActive.Controls.Add(btnNewSubscription);
            tabActive.Controls.Add(btnCheckIn);
            tabActive.Location = new Point(4, 24);
            tabActive.Name = "tabActive";
            tabActive.Padding = new Padding(10);
            tabActive.Size = new Size(792, 502);
            tabActive.TabIndex = 0;
            tabActive.Text = "الاشتراكات السارية";
            // 
            // dgvActive
            // 
            dgvActive.Dock = DockStyle.Top;
            dgvActive.Location = new Point(10, 10);
            dgvActive.Name = "dgvActive";
            dgvActive.ReadOnly = true;
            dgvActive.Size = new Size(772, 400);
            dgvActive.TabIndex = 0;
            // 
            // btnNewSubscription
            // 
            btnNewSubscription.Location = new Point(10, 420);
            btnNewSubscription.Name = "btnNewSubscription";
            btnNewSubscription.Size = new Size(150, 40);
            btnNewSubscription.TabIndex = 1;
            btnNewSubscription.Text = "اشتراك جديد";
            // 
            // btnCheckIn
            // 
            btnCheckIn.Location = new Point(180, 420);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(150, 40);
            btnCheckIn.TabIndex = 2;
            btnCheckIn.Text = "تسجيل حضور (حصة)";
            // 
            // tabNearExpiry
            // 
            tabNearExpiry.Controls.Add(dgvNearExpiry);
            tabNearExpiry.Controls.Add(btnRenew);
            tabNearExpiry.Location = new Point(4, 24);
            tabNearExpiry.Name = "tabNearExpiry";
            tabNearExpiry.Padding = new Padding(10);
            tabNearExpiry.Size = new Size(792, 502);
            tabNearExpiry.TabIndex = 1;
            tabNearExpiry.Text = "قرب الانتهاء";
            // 
            // dgvNearExpiry
            // 
            dgvNearExpiry.Dock = DockStyle.Top;
            dgvNearExpiry.Location = new Point(10, 10);
            dgvNearExpiry.Name = "dgvNearExpiry";
            dgvNearExpiry.ReadOnly = true;
            dgvNearExpiry.Size = new Size(772, 400);
            dgvNearExpiry.TabIndex = 0;
            // 
            // btnRenew
            // 
            btnRenew.Location = new Point(10, 420);
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
            tabExpired.Size = new Size(792, 502);
            tabExpired.TabIndex = 2;
            tabExpired.Text = "المنتهية";
            // 
            // dgvExpired
            // 
            dgvExpired.Dock = DockStyle.Fill;
            dgvExpired.Location = new Point(10, 10);
            dgvExpired.Name = "dgvExpired";
            dgvExpired.ReadOnly = true;
            dgvExpired.Size = new Size(772, 482);
            dgvExpired.TabIndex = 0;
            // 
            // tabPackages
            // 
            tabPackages.Controls.Add(dgvPackages);
            tabPackages.Controls.Add(txtPackageName);
            tabPackages.Controls.Add(txtDurationDays);
            tabPackages.Controls.Add(txtPrice);
            tabPackages.Controls.Add(txtTotalSessions);
            tabPackages.Controls.Add(chkIsSessionBased);
            tabPackages.Controls.Add(btnSavePackage);
            tabPackages.Controls.Add(btnDeletePackage);
            tabPackages.Location = new Point(4, 24);
            tabPackages.Name = "tabPackages";
            tabPackages.Padding = new Padding(10);
            tabPackages.Size = new Size(792, 502);
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
            // txtPackageName
            // 
            txtPackageName.AnimateReadOnly = false;
            txtPackageName.BorderStyle = BorderStyle.None;
            txtPackageName.Depth = 0;
            txtPackageName.Font = new Font("IRANYekanMobileFN", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPackageName.Hint = "اسم الباقة";
            txtPackageName.LeadingIcon = null;
            txtPackageName.Location = new Point(10, 320);
            txtPackageName.MaxLength = 50;
            txtPackageName.MouseState = MaterialSkin.MouseState.OUT;
            txtPackageName.Multiline = false;
            txtPackageName.Name = "txtPackageName";
            txtPackageName.Size = new Size(200, 50);
            txtPackageName.TabIndex = 1;
            txtPackageName.Text = "";
            txtPackageName.TrailingIcon = null;
            // 
            // txtDurationDays
            // 
            txtDurationDays.AnimateReadOnly = false;
            txtDurationDays.BorderStyle = BorderStyle.None;
            txtDurationDays.Depth = 0;
            txtDurationDays.Font = new Font("IRANYekanMobileFN", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtDurationDays.Hint = "المدة (بالأيام)";
            txtDurationDays.LeadingIcon = null;
            txtDurationDays.Location = new Point(220, 320);
            txtDurationDays.MaxLength = 50;
            txtDurationDays.MouseState = MaterialSkin.MouseState.OUT;
            txtDurationDays.Multiline = false;
            txtDurationDays.Name = "txtDurationDays";
            txtDurationDays.Size = new Size(150, 50);
            txtDurationDays.TabIndex = 2;
            txtDurationDays.Text = "";
            txtDurationDays.TrailingIcon = null;
            // 
            // txtPrice
            // 
            txtPrice.AnimateReadOnly = false;
            txtPrice.BorderStyle = BorderStyle.None;
            txtPrice.Depth = 0;
            txtPrice.Font = new Font("IRANYekanMobileFN", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPrice.Hint = "السعر";
            txtPrice.LeadingIcon = null;
            txtPrice.Location = new Point(380, 320);
            txtPrice.MaxLength = 50;
            txtPrice.MouseState = MaterialSkin.MouseState.OUT;
            txtPrice.Multiline = false;
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(150, 50);
            txtPrice.TabIndex = 3;
            txtPrice.Text = "";
            txtPrice.TrailingIcon = null;
            // 
            // txtTotalSessions
            // 
            txtTotalSessions.AnimateReadOnly = false;
            txtTotalSessions.BorderStyle = BorderStyle.None;
            txtTotalSessions.Depth = 0;
            txtTotalSessions.Enabled = false;
            txtTotalSessions.Font = new Font("IRANYekanMobileFN", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTotalSessions.Hint = "عدد الحصص";
            txtTotalSessions.LeadingIcon = null;
            txtTotalSessions.Location = new Point(220, 380);
            txtTotalSessions.MaxLength = 50;
            txtTotalSessions.MouseState = MaterialSkin.MouseState.OUT;
            txtTotalSessions.Multiline = false;
            txtTotalSessions.Name = "txtTotalSessions";
            txtTotalSessions.Size = new Size(150, 50);
            txtTotalSessions.TabIndex = 4;
            txtTotalSessions.Text = "";
            txtTotalSessions.TrailingIcon = null;
            // 
            // chkIsSessionBased
            // 
            chkIsSessionBased.AutoSize = true;
            chkIsSessionBased.Location = new Point(10, 390);
            chkIsSessionBased.Name = "chkIsSessionBased";
            chkIsSessionBased.Size = new Size(100, 19);
            chkIsSessionBased.TabIndex = 5;
            chkIsSessionBased.Text = "باقة بالحصص؟";
            // 
            // btnSavePackage
            // 
            btnSavePackage.Location = new Point(10, 450);
            btnSavePackage.Name = "btnSavePackage";
            btnSavePackage.Size = new Size(150, 40);
            btnSavePackage.TabIndex = 6;
            btnSavePackage.Text = "حفظ الباقة";
            // 
            // btnDeletePackage
            // 
            btnDeletePackage.Location = new Point(180, 450);
            btnDeletePackage.Name = "btnDeletePackage";
            btnDeletePackage.Size = new Size(150, 40);
            btnDeletePackage.TabIndex = 7;
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
            tabPackages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPackages).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnOpenGate;

        private TabControl tabControlGym;
        private TabPage tabActive;
        private TabPage tabNearExpiry;
        private TabPage tabExpired;
        private TabPage tabPackages;

        private DataGridView dgvActive;
        private Button btnNewSubscription;
        private Button btnCheckIn;

        private DataGridView dgvNearExpiry;
        private Button btnRenew;

        private DataGridView dgvExpired;

        private DataGridView dgvPackages;
        private MaterialTextBox txtPackageName;
        private MaterialTextBox txtDurationDays;
        private MaterialTextBox txtPrice;
        private MaterialTextBox txtTotalSessions;
        private CheckBox chkIsSessionBased;
        private Button btnSavePackage;
        private Button btnDeletePackage;
    }
}
