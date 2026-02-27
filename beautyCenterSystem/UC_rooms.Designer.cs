namespace beautyCenterSystem
{
    partial class UC_rooms
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
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnAddRoom = new FontAwesome.Sharp.IconButton();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btnDeleteRoom = new ToolStripMenuItem();
            panel1 = new Panel();
            dgvRooms = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.Location = new Point(370, 0);
            label1.Name = "label1";
            label1.Size = new Size(177, 46);
            label1.TabIndex = 3;
            label1.Text = "إدارة الغرف";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 450F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(btnAddRoom, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RightToLeft = RightToLeft.Yes;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1000, 65);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // btnAddRoom
            // 
            btnAddRoom.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 0);
            btnAddRoom.FlatStyle = FlatStyle.Flat;
            btnAddRoom.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            btnAddRoom.IconColor = Color.Black;
            btnAddRoom.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddRoom.IconSize = 35;
            btnAddRoom.Location = new Point(3, 3);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(144, 59);
            btnAddRoom.TabIndex = 4;
            btnAddRoom.Text = "إضافة غرفة";
            btnAddRoom.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnAddRoom.UseVisualStyleBackColor = true;
            btnAddRoom.Click += btnAddRoom_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { btnDeleteRoom });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RightToLeft = RightToLeft.Yes;
            contextMenuStrip1.Size = new Size(126, 26);
            // 
            // btnDeleteRoom
            // 
            btnDeleteRoom.Name = "btnDeleteRoom";
            btnDeleteRoom.Size = new Size(125, 22);
            btnDeleteRoom.Text = "حذف غرفة";
            btnDeleteRoom.Click += btnDeleteRoom_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvRooms);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 65);
            panel1.Name = "panel1";
            panel1.Size = new Size(1000, 635);
            panel1.TabIndex = 7;
            // 
            // dgvRooms
            // 
            dgvRooms.BorderStyle = BorderStyle.None;
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRooms.ContextMenuStrip = contextMenuStrip1;
            dgvRooms.Dock = DockStyle.Fill;
            dgvRooms.Location = new Point(0, 0);
            dgvRooms.Name = "dgvRooms";
            dgvRooms.RightToLeft = RightToLeft.Yes;
            dgvRooms.Size = new Size(1000, 635);
            dgvRooms.TabIndex = 2;
            dgvRooms.CellEndEdit += dgvRooms_CellEndEdit;
            dgvRooms.CellMouseDown += dgvRooms_CellMouseDown;
            // 
            // UC_rooms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel1);
            Name = "UC_rooms";
            Size = new Size(1000, 700);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem btnDeleteRoom;
        private Panel panel1;
        private DataGridView dgvRooms;
        private FontAwesome.Sharp.IconButton btnAddRoom;
    }
}
