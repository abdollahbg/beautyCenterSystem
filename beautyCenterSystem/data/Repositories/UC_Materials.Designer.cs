namespace beautyCenterSystem.data.Repositories
{
    partial class UC_Materials
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            btnAddMaterials = new FontAwesome.Sharp.IconButton();
            txtboxSearch = new MaterialSkin.Controls.MaterialTextBox2();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btnDeleteMaterial = new ToolStripMenuItem();
            panel1 = new Panel();
            dgvMaterials = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaterials).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 260F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 450F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(iconPictureBox1, 2, 0);
            tableLayoutPanel1.Controls.Add(btnAddMaterials, 4, 0);
            tableLayoutPanel1.Controls.Add(txtboxSearch, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RightToLeft = RightToLeft.Yes;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1000, 65);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(828, 0);
            label1.Name = "label1";
            label1.Size = new Size(169, 32);
            label1.TabIndex = 3;
            label1.Text = "المخزون والمواد";
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = SystemColors.Control;
            iconPictureBox1.Dock = DockStyle.Right;
            iconPictureBox1.ForeColor = SystemColors.ControlText;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Search;
            iconPictureBox1.IconColor = SystemColors.ControlText;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 39;
            iconPictureBox1.Location = new Point(248, 3);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(39, 59);
            iconPictureBox1.TabIndex = 6;
            iconPictureBox1.TabStop = false;
            // 
            // btnAddMaterials
            // 
            btnAddMaterials.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 0);
            btnAddMaterials.FlatStyle = FlatStyle.Flat;
            btnAddMaterials.IconChar = FontAwesome.Sharp.IconChar.TabletAndroid;
            btnAddMaterials.IconColor = Color.Black;
            btnAddMaterials.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddMaterials.IconSize = 35;
            btnAddMaterials.Location = new Point(3, 3);
            btnAddMaterials.Name = "btnAddMaterials";
            btnAddMaterials.Size = new Size(106, 59);
            btnAddMaterials.TabIndex = 0;
            btnAddMaterials.Text = "إضافة عنصر";
            btnAddMaterials.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnAddMaterials.UseVisualStyleBackColor = true;
            btnAddMaterials.Click += btnAddMaterials_Click;
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
            txtboxSearch.Location = new Point(293, 3);
            txtboxSearch.MaxLength = 32767;
            txtboxSearch.MouseState = MaterialSkin.MouseState.OUT;
            txtboxSearch.Name = "txtboxSearch";
            txtboxSearch.PasswordChar = '\0';
            txtboxSearch.PrefixSuffixText = null;
            txtboxSearch.ReadOnly = false;
            txtboxSearch.RightToLeft = RightToLeft.Yes;
            txtboxSearch.SelectedText = "";
            txtboxSearch.SelectionLength = 0;
            txtboxSearch.SelectionStart = 0;
            txtboxSearch.ShortcutsEnabled = true;
            txtboxSearch.Size = new Size(444, 48);
            txtboxSearch.TabIndex = 5;
            txtboxSearch.TabStop = false;
            txtboxSearch.TextAlign = HorizontalAlignment.Right;
            txtboxSearch.TrailingIcon = null;
            txtboxSearch.UseSystemPasswordChar = false;
            txtboxSearch.TextChanged += txtboxSearch_TextChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { btnDeleteMaterial });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RightToLeft = RightToLeft.Yes;
            contextMenuStrip1.Size = new Size(137, 26);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // btnDeleteMaterial
            // 
            btnDeleteMaterial.Name = "btnDeleteMaterial";
            btnDeleteMaterial.Size = new Size(136, 22);
            btnDeleteMaterial.Text = "حذف العنصر";
            btnDeleteMaterial.Click += btnDeleteMaterial_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvMaterials);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 65);
            panel1.Name = "panel1";
            panel1.Size = new Size(1000, 635);
            panel1.TabIndex = 7;
            // 
            // dgvMaterials
            // 
            dgvMaterials.BorderStyle = BorderStyle.None;
            dgvMaterials.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterials.ContextMenuStrip = contextMenuStrip1;
            dgvMaterials.Dock = DockStyle.Fill;
            dgvMaterials.Location = new Point(0, 0);
            dgvMaterials.Name = "dgvMaterials";
            dgvMaterials.RightToLeft = RightToLeft.Yes;
            dgvMaterials.Size = new Size(1000, 635);
            dgvMaterials.TabIndex = 2;
            dgvMaterials.CellClick += dgvMaterials_CellClick;
            dgvMaterials.CellValueChanged += dgvMaterials_CellValueChanged;
            dgvMaterials.CurrentCellDirtyStateChanged += dgvMaterials_CurrentCellDirtyStateChanged;
            dgvMaterials.MouseDown += dgvMaterials_MouseDown;
            // 
            // UC_Materials
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel1);
            Name = "UC_Materials";
            Size = new Size(1000, 700);
            Load += UC_Materials_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMaterials).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconButton btnAddMaterials;
        private MaterialSkin.Controls.MaterialTextBox2 txtboxSearch;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem btnDeleteMaterial;
        private Panel panel1;
        private DataGridView dgvMaterials;
    }
}
