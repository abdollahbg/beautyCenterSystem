namespace beautyCenterSystem.data.Repositories
{
    partial class UC_Services
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
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btnDeleteService = new ToolStripMenuItem();
            panel1 = new Panel();
            dgvServices = new DataGridView();
            btnAddService = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { btnDeleteService });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RightToLeft = RightToLeft.Yes;
            contextMenuStrip1.Size = new Size(129, 26);
            // 
            // btnDeleteService
            // 
            btnDeleteService.Name = "btnDeleteService";
            btnDeleteService.Size = new Size(128, 22);
            btnDeleteService.Text = "حذف خدمة";
            btnDeleteService.Click += btnDeleteService_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvServices);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 65);
            panel1.Name = "panel1";
            panel1.Size = new Size(1000, 635);
            panel1.TabIndex = 9;
            // 
            // dgvServices
            // 
            dgvServices.BorderStyle = BorderStyle.None;
            dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServices.ContextMenuStrip = contextMenuStrip1;
            dgvServices.Dock = DockStyle.Fill;
            dgvServices.Location = new Point(0, 0);
            dgvServices.Name = "dgvServices";
            dgvServices.RightToLeft = RightToLeft.Yes;
            dgvServices.Size = new Size(1000, 635);
            dgvServices.TabIndex = 3;
            dgvServices.CellEndEdit += dgvServices_CellEndEdit;
            dgvServices.CellMouseDown += dgvServices_CellMouseDown;
            dgvServices.CellValidating += dgvServices_CellValidating;
            // 
            // btnAddService
            // 
            btnAddService.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 0);
            btnAddService.FlatStyle = FlatStyle.Flat;
            btnAddService.IconChar = FontAwesome.Sharp.IconChar.Couch;
            btnAddService.IconColor = Color.Black;
            btnAddService.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddService.IconSize = 35;
            btnAddService.Location = new Point(3, 3);
            btnAddService.Name = "btnAddService";
            btnAddService.Size = new Size(144, 59);
            btnAddService.TabIndex = 4;
            btnAddService.Text = "إضافة خدمة";
            btnAddService.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnAddService.UseVisualStyleBackColor = true;
            btnAddService.Click += btnAddService_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.Location = new Point(338, 0);
            label1.Name = "label1";
            label1.Size = new Size(209, 46);
            label1.TabIndex = 3;
            label1.Text = "إدارة الخدمات";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 450F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(btnAddService, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RightToLeft = RightToLeft.Yes;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1000, 65);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // UC_Services
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel1);
            Name = "UC_Services";
            Size = new Size(1000, 700);
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem btnDeleteService;
        private Panel panel1;
        private DataGridView dgvServices;
        private FontAwesome.Sharp.IconButton btnAddService;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
