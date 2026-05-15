namespace beautyCenterSystem
{
    partial class MainDashBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDashBoard));
            pnlSidebar = new Panel();
            btnSettings = new FontAwesome.Sharp.IconButton();
            btnInvoices = new FontAwesome.Sharp.IconButton();
            btnMaterials = new FontAwesome.Sharp.IconButton();
            btnGym = new FontAwesome.Sharp.IconButton();
            btnEmployees = new FontAwesome.Sharp.IconButton();
            btnRooms = new FontAwesome.Sharp.IconButton();
            btnServices = new FontAwesome.Sharp.IconButton();
            btnCustomers = new FontAwesome.Sharp.IconButton();
            btnAppointments = new FontAwesome.Sharp.IconButton();
            btnHome = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            btnAbout = new FontAwesome.Sharp.IconButton();
            btnLogout = new FontAwesome.Sharp.IconButton();
            pnlContainer = new Panel();
            pnlFooter = new Panel();
            lblRights = new Label();
            lblUserName = new Label();
            pnlSidebar.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.Controls.Add(btnSettings);
            pnlSidebar.Controls.Add(btnInvoices);
            pnlSidebar.Controls.Add(btnMaterials);
            pnlSidebar.Controls.Add(btnGym);
            pnlSidebar.Controls.Add(btnEmployees);
            pnlSidebar.Controls.Add(btnRooms);
            pnlSidebar.Controls.Add(btnServices);
            pnlSidebar.Controls.Add(btnCustomers);
            pnlSidebar.Controls.Add(btnAppointments);
            pnlSidebar.Controls.Add(btnHome);
            pnlSidebar.Controls.Add(panel1);
            pnlSidebar.Controls.Add(btnAbout);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Dock = DockStyle.Right;
            pnlSidebar.Location = new Point(784, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(200, 611);
            pnlSidebar.TabIndex = 0;
            // 
            // btnSettings
            // 
            btnSettings.Dock = DockStyle.Top;
            btnSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            btnSettings.IconColor = Color.Black;
            btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSettings.IconSize = 35;
            btnSettings.ImageAlign = ContentAlignment.MiddleRight;
            btnSettings.Location = new Point(0, 475);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(0, 0, 15, 0);
            btnSettings.Size = new Size(200, 45);
            btnSettings.TabIndex = 8;
            btnSettings.Text = "الإعدادات";
            btnSettings.TextAlign = ContentAlignment.MiddleRight;
            btnSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnInvoices
            // 
            btnInvoices.Dock = DockStyle.Top;
            btnInvoices.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            btnInvoices.IconColor = Color.Black;
            btnInvoices.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnInvoices.IconSize = 35;
            btnInvoices.ImageAlign = ContentAlignment.MiddleRight;
            btnInvoices.Location = new Point(0, 430);
            btnInvoices.Name = "btnInvoices";
            btnInvoices.Padding = new Padding(0, 0, 15, 0);
            btnInvoices.Size = new Size(200, 45);
            btnInvoices.TabIndex = 7;
            btnInvoices.Text = "الفواتير والمالية";
            btnInvoices.TextAlign = ContentAlignment.MiddleRight;
            btnInvoices.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInvoices.UseVisualStyleBackColor = true;
            btnInvoices.Click += btnInvoices_Click;
            // 
            // btnMaterials
            // 
            btnMaterials.Dock = DockStyle.Top;
            btnMaterials.IconChar = FontAwesome.Sharp.IconChar.BoxOpen;
            btnMaterials.IconColor = Color.Black;
            btnMaterials.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMaterials.IconSize = 35;
            btnMaterials.ImageAlign = ContentAlignment.MiddleRight;
            btnMaterials.Location = new Point(0, 385);
            btnMaterials.Name = "btnMaterials";
            btnMaterials.Padding = new Padding(0, 0, 15, 0);
            btnMaterials.Size = new Size(200, 45);
            btnMaterials.TabIndex = 6;
            btnMaterials.Text = "المخزون والمواد";
            btnMaterials.TextAlign = ContentAlignment.MiddleRight;
            btnMaterials.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMaterials.UseVisualStyleBackColor = true;
            btnMaterials.Click += btnMaterials_Click;
            // 
            // btnGym
            // 
            btnGym.Dock = DockStyle.Top;
            btnGym.IconChar = FontAwesome.Sharp.IconChar.Dumbbell;
            btnGym.IconColor = Color.Black;
            btnGym.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGym.IconSize = 35;
            btnGym.ImageAlign = ContentAlignment.MiddleRight;
            btnGym.Location = new Point(0, 340);
            btnGym.Name = "btnGym";
            btnGym.Padding = new Padding(0, 0, 15, 0);
            btnGym.Size = new Size(200, 45);
            btnGym.TabIndex = 12;
            btnGym.Text = "الصالة الرياضية";
            btnGym.TextAlign = ContentAlignment.MiddleRight;
            btnGym.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGym.UseVisualStyleBackColor = true;
            btnGym.Click += btnGym_Click;
            // 
            // btnEmployees
            // 
            btnEmployees.Dock = DockStyle.Top;
            btnEmployees.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            btnEmployees.IconColor = Color.Black;
            btnEmployees.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEmployees.IconSize = 35;
            btnEmployees.ImageAlign = ContentAlignment.MiddleRight;
            btnEmployees.Location = new Point(0, 295);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Padding = new Padding(0, 0, 15, 0);
            btnEmployees.Size = new Size(200, 45);
            btnEmployees.TabIndex = 11;
            btnEmployees.Text = "الموظفات";
            btnEmployees.TextAlign = ContentAlignment.MiddleRight;
            btnEmployees.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEmployees.UseVisualStyleBackColor = true;
            btnEmployees.Click += btnEmployees_Click;
            // 
            // btnRooms
            // 
            btnRooms.Dock = DockStyle.Top;
            btnRooms.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            btnRooms.IconColor = Color.Black;
            btnRooms.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRooms.IconSize = 35;
            btnRooms.ImageAlign = ContentAlignment.MiddleRight;
            btnRooms.Location = new Point(0, 250);
            btnRooms.Name = "btnRooms";
            btnRooms.Padding = new Padding(0, 0, 15, 0);
            btnRooms.Size = new Size(200, 45);
            btnRooms.TabIndex = 5;
            btnRooms.Text = "إدارة الغرف";
            btnRooms.TextAlign = ContentAlignment.MiddleRight;
            btnRooms.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRooms.UseVisualStyleBackColor = true;
            btnRooms.Click += btnRooms_Click;
            // 
            // btnServices
            // 
            btnServices.Dock = DockStyle.Top;
            btnServices.IconChar = FontAwesome.Sharp.IconChar.Spa;
            btnServices.IconColor = Color.Black;
            btnServices.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnServices.IconSize = 35;
            btnServices.ImageAlign = ContentAlignment.MiddleRight;
            btnServices.Location = new Point(0, 205);
            btnServices.Name = "btnServices";
            btnServices.Padding = new Padding(0, 0, 15, 0);
            btnServices.Size = new Size(200, 45);
            btnServices.TabIndex = 4;
            btnServices.Text = "خدمات المركز";
            btnServices.TextAlign = ContentAlignment.MiddleRight;
            btnServices.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnServices.UseVisualStyleBackColor = true;
            btnServices.Click += btnServices_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.Dock = DockStyle.Top;
            btnCustomers.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            btnCustomers.IconColor = Color.Black;
            btnCustomers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCustomers.IconSize = 35;
            btnCustomers.ImageAlign = ContentAlignment.MiddleRight;
            btnCustomers.Location = new Point(0, 160);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Padding = new Padding(0, 0, 15, 0);
            btnCustomers.Size = new Size(200, 45);
            btnCustomers.TabIndex = 3;
            btnCustomers.Text = "العملاء";
            btnCustomers.TextAlign = ContentAlignment.MiddleRight;
            btnCustomers.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // btnAppointments
            // 
            btnAppointments.Dock = DockStyle.Top;
            btnAppointments.IconChar = FontAwesome.Sharp.IconChar.Calendar;
            btnAppointments.IconColor = Color.Black;
            btnAppointments.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAppointments.IconSize = 35;
            btnAppointments.ImageAlign = ContentAlignment.MiddleRight;
            btnAppointments.Location = new Point(0, 115);
            btnAppointments.Name = "btnAppointments";
            btnAppointments.Padding = new Padding(0, 0, 15, 0);
            btnAppointments.Size = new Size(200, 45);
            btnAppointments.TabIndex = 2;
            btnAppointments.Text = "مواعيد اليوم";
            btnAppointments.TextAlign = ContentAlignment.MiddleRight;
            btnAppointments.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAppointments.UseVisualStyleBackColor = true;
            btnAppointments.Click += btnAppointments_Click;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Top;
            btnHome.IconChar = FontAwesome.Sharp.IconChar.House;
            btnHome.IconColor = Color.Black;
            btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnHome.IconSize = 35;
            btnHome.ImageAlign = ContentAlignment.MiddleRight;
            btnHome.Location = new Point(0, 70);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(0, 0, 15, 0);
            btnHome.Size = new Size(200, 45);
            btnHome.TabIndex = 1;
            btnHome.Text = "الرئيسية";
            btnHome.TextAlign = ContentAlignment.MiddleRight;
            btnHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 70);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Gemini_Generated_Image_jzohhjzohhjzohhj_removebg_preview;
            pictureBox1.Location = new Point(68, -6);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(90, 82);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnAbout
            // 
            btnAbout.Dock = DockStyle.Bottom;
            btnAbout.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            btnAbout.IconColor = Color.Black;
            btnAbout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAbout.IconSize = 35;
            btnAbout.ImageAlign = ContentAlignment.MiddleRight;
            btnAbout.Location = new Point(0, 491);
            btnAbout.Name = "btnAbout";
            btnAbout.Padding = new Padding(0, 0, 15, 0);
            btnAbout.Size = new Size(200, 60);
            btnAbout.TabIndex = 10;
            btnAbout.Text = "حول النظام";
            btnAbout.TextAlign = ContentAlignment.MiddleRight;
            btnAbout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAbout.UseVisualStyleBackColor = true;
            btnAbout.Click += btnAbout_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(255, 128, 128);
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            btnLogout.IconColor = Color.White;
            btnLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLogout.IconSize = 35;
            btnLogout.ImageAlign = ContentAlignment.MiddleRight;
            btnLogout.Location = new Point(0, 551);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(0, 0, 15, 0);
            btnLogout.Size = new Size(200, 60);
            btnLogout.TabIndex = 9;
            btnLogout.Text = "تسجيل خروج";
            btnLogout.TextAlign = ContentAlignment.MiddleRight;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // pnlContainer
            // 
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(784, 581);
            pnlContainer.TabIndex = 1;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(245, 245, 245);
            pnlFooter.Controls.Add(lblRights);
            pnlFooter.Controls.Add(lblUserName);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 581);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(784, 30);
            pnlFooter.TabIndex = 2;
            // 
            // lblRights
            // 
            lblRights.Dock = DockStyle.Left;
            lblRights.Font = new Font("Segoe UI", 8F);
            lblRights.ForeColor = Color.DimGray;
            lblRights.Location = new Point(0, 0);
            lblRights.Name = "lblRights";
            lblRights.Padding = new Padding(10, 0, 0, 0);
            lblRights.Size = new Size(350, 30);
            lblRights.TabIndex = 0;
            lblRights.Text = "جميع الحقوق محفوظة © 2024 - شركة الصنوان للحلول التقنية";
            lblRights.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            lblUserName.Dock = DockStyle.Right;
            lblUserName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUserName.ForeColor = Color.DarkSlateGray;
            lblUserName.Location = new Point(484, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Padding = new Padding(0, 0, 10, 0);
            lblUserName.Size = new Size(300, 30);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "المستخدم: جاري التحميل...";
            lblUserName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // MainDashBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 611);
            Controls.Add(pnlContainer);
            Controls.Add(pnlFooter);
            Controls.Add(pnlSidebar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1000, 650);
            Name = "MainDashBoard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "نظام إدارة مركز التجميل - لوحة التحكم";
            WindowState = FormWindowState.Maximized;
            FormClosing += MainDashBoard_FormClosing;
            Load += MainDashBoard_Load;
            pnlSidebar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlContainer;
        private FontAwesome.Sharp.IconButton btnRooms;
        private FontAwesome.Sharp.IconButton btnServices;
        private FontAwesome.Sharp.IconButton btnCustomers;
        private FontAwesome.Sharp.IconButton btnAppointments;
        private FontAwesome.Sharp.IconButton btnHome;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnMaterials;
        private FontAwesome.Sharp.IconButton btnSettings;
        private FontAwesome.Sharp.IconButton btnInvoices;
        private FontAwesome.Sharp.IconButton btnLogout;
        private FontAwesome.Sharp.IconButton btnAbout;
        private FontAwesome.Sharp.IconButton btnEmployees;
        private FontAwesome.Sharp.IconButton btnGym;
        private Panel pnlFooter;
        private Label lblRights;
        public Label lblUserName;
        private PictureBox pictureBox1;
    }
}