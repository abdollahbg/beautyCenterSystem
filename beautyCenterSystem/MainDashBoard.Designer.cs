namespace beautyCenterSystem
{
    partial class MainDashBoard
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
            pnlSidebar = new Panel();
            btnLogout = new FontAwesome.Sharp.IconButton();
            btnSettings = new FontAwesome.Sharp.IconButton();
            btnInvoices = new FontAwesome.Sharp.IconButton();
            btnMaterials = new FontAwesome.Sharp.IconButton();
            btnRooms = new FontAwesome.Sharp.IconButton();
            btnServices = new FontAwesome.Sharp.IconButton();
            btnCustomers = new FontAwesome.Sharp.IconButton();
            btnAppointments = new FontAwesome.Sharp.IconButton();
            btnHome = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            pnlContainer = new Panel();
            pnlSidebar.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnSettings);
            pnlSidebar.Controls.Add(btnInvoices);
            pnlSidebar.Controls.Add(btnMaterials);
            pnlSidebar.Controls.Add(btnRooms);
            pnlSidebar.Controls.Add(btnServices);
            pnlSidebar.Controls.Add(btnCustomers);
            pnlSidebar.Controls.Add(btnAppointments);
            pnlSidebar.Controls.Add(btnHome);
            pnlSidebar.Controls.Add(panel1);
            pnlSidebar.Dock = DockStyle.Right;
            pnlSidebar.Location = new Point(771, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(200, 609);
            pnlSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(255, 128, 128);
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            btnLogout.IconColor = Color.White;
            btnLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLogout.IconSize = 35;
            btnLogout.ImageAlign = ContentAlignment.MiddleRight;
            btnLogout.Location = new Point(0, 549);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(0, 0, 15, 0);
            btnLogout.RightToLeft = RightToLeft.No;
            btnLogout.Size = new Size(200, 60);
            btnLogout.TabIndex = 9;
            btnLogout.Text = "تسجيل خروج";
            btnLogout.TextAlign = ContentAlignment.MiddleRight;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnSettings
            // 
            btnSettings.Dock = DockStyle.Top;
            btnSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            btnSettings.IconColor = Color.Black;
            btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSettings.IconSize = 35;
            btnSettings.ImageAlign = ContentAlignment.MiddleRight;
            btnSettings.Location = new Point(0, 490);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(0, 0, 15, 0);
            btnSettings.RightToLeft = RightToLeft.No;
            btnSettings.Size = new Size(200, 60);
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
            btnInvoices.RightToLeft = RightToLeft.No;
            btnInvoices.Size = new Size(200, 60);
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
            btnMaterials.Location = new Point(0, 370);
            btnMaterials.Name = "btnMaterials";
            btnMaterials.Padding = new Padding(0, 0, 15, 0);
            btnMaterials.RightToLeft = RightToLeft.No;
            btnMaterials.Size = new Size(200, 60);
            btnMaterials.TabIndex = 6;
            btnMaterials.Text = "المخزون والمواد";
            btnMaterials.TextAlign = ContentAlignment.MiddleRight;
            btnMaterials.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMaterials.UseVisualStyleBackColor = true;
            btnMaterials.Click += btnMaterials_Click;
            // 
            // btnRooms
            // 
            btnRooms.Dock = DockStyle.Top;
            btnRooms.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            btnRooms.IconColor = Color.Black;
            btnRooms.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRooms.IconSize = 35;
            btnRooms.ImageAlign = ContentAlignment.MiddleRight;
            btnRooms.Location = new Point(0, 310);
            btnRooms.Name = "btnRooms";
            btnRooms.Padding = new Padding(0, 0, 15, 0);
            btnRooms.RightToLeft = RightToLeft.No;
            btnRooms.Size = new Size(200, 60);
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
            btnServices.Location = new Point(0, 250);
            btnServices.Name = "btnServices";
            btnServices.Padding = new Padding(0, 0, 15, 0);
            btnServices.RightToLeft = RightToLeft.No;
            btnServices.Size = new Size(200, 60);
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
            btnCustomers.Location = new Point(0, 190);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Padding = new Padding(0, 0, 15, 0);
            btnCustomers.RightToLeft = RightToLeft.No;
            btnCustomers.Size = new Size(200, 60);
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
            btnAppointments.Location = new Point(0, 130);
            btnAppointments.Name = "btnAppointments";
            btnAppointments.Padding = new Padding(0, 0, 15, 0);
            btnAppointments.RightToLeft = RightToLeft.No;
            btnAppointments.Size = new Size(200, 60);
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
            btnHome.RightToLeft = RightToLeft.No;
            btnHome.Size = new Size(200, 60);
            btnHome.TabIndex = 1;
            btnHome.Text = "الرئيسية";
            btnHome.TextAlign = ContentAlignment.MiddleRight;
            btnHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(iconPictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 70);
            panel1.TabIndex = 0;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = SystemColors.Control;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Spa;
            iconPictureBox1.IconColor = Color.White;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 63;
            iconPictureBox1.Location = new Point(71, 4);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(66, 63);
            iconPictureBox1.TabIndex = 0;
            iconPictureBox1.TabStop = false;
            // 
            // pnlContainer
            // 
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(771, 609);
            pnlContainer.TabIndex = 1;
            // 
            // MainDashBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(971, 609);
            Controls.Add(pnlContainer);
            Controls.Add(pnlSidebar);
            Name = "MainDashBoard";
            Text = "MainDashBoard";
            FormClosing += MainDashBoard_FormClosing;
            FormClosed += MainDashBoard_FormClosed;
            Load += MainDashBoard_Load;
            pnlSidebar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
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
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconButton btnMaterials;
        private FontAwesome.Sharp.IconButton btnSettings;
        private FontAwesome.Sharp.IconButton btnInvoices;
        private FontAwesome.Sharp.IconButton btnLogout;
    }
}