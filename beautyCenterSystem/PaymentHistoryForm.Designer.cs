namespace beautyCenterSystem
{
    partial class PaymentHistoryForm
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
            pnlHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            pnlFilter = new System.Windows.Forms.Panel();
            lblFilter = new System.Windows.Forms.Label();
            cmbEntities = new System.Windows.Forms.ComboBox();
            btnSearch = new System.Windows.Forms.Button();
            btnReset = new System.Windows.Forms.Button();
            dgvHistory = new System.Windows.Forms.DataGridView();
            pnlHeader.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 150, 136);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(800, 70);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(800, 70);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "سجل عمليات الصرف";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFilter
            // 
            pnlFilter.Controls.Add(btnReset);
            pnlFilter.Controls.Add(btnSearch);
            pnlFilter.Controls.Add(cmbEntities);
            pnlFilter.Controls.Add(lblFilter);
            pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            pnlFilter.Location = new System.Drawing.Point(0, 70);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new System.Drawing.Size(800, 70);
            pnlFilter.TabIndex = 1;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblFilter.Location = new System.Drawing.Point(710, 25);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new System.Drawing.Size(43, 20);
            lblFilter.TabIndex = 0;
            lblFilter.Text = "الاسم";
            // 
            // cmbEntities
            // 
            cmbEntities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbEntities.Font = new System.Drawing.Font("Segoe UI", 11F);
            cmbEntities.FormattingEnabled = true;
            cmbEntities.Location = new System.Drawing.Point(450, 21);
            cmbEntities.Name = "cmbEntities";
            cmbEntities.Size = new System.Drawing.Size(250, 28);
            cmbEntities.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = System.Drawing.Color.Teal;
            btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnSearch.ForeColor = System.Drawing.Color.White;
            btnSearch.Location = new System.Drawing.Point(320, 18);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(100, 35);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "بحث";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            btnReset.BackColor = System.Drawing.Color.Silver;
            btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnReset.Font = new System.Drawing.Font("Segoe UI", 11F);
            btnReset.Location = new System.Drawing.Point(210, 18);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(100, 35);
            btnReset.TabIndex = 3;
            btnReset.Text = "عرض الكل";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.BackgroundColor = System.Drawing.Color.White;
            dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvHistory.Location = new System.Drawing.Point(0, 140);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowTemplate.Height = 35;
            dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new System.Drawing.Size(800, 310);
            dgvHistory.TabIndex = 2;
            // 
            // PaymentHistoryForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(dgvHistory);
            Controls.Add(pnlFilter);
            Controls.Add(pnlHeader);
            Name = "PaymentHistoryForm";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "سجل عمليات الصرف";
            pnlHeader.ResumeLayout(false);
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbEntities;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvHistory;
    }
}
