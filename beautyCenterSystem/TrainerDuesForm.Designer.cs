namespace beautyCenterSystem
{
    partial class TrainerDuesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvTrainerDues;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbSafes;
        private System.Windows.Forms.Label lblSafe;

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
            this.dgvTrainerDues = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbSafes = new System.Windows.Forms.ComboBox();
            this.lblSafe = new System.Windows.Forms.Label();
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainerDues)).BeginInit();
            this.SuspendLayout();
            
            // 
            // dgvTrainerDues
            // 
            this.dgvTrainerDues.AllowUserToAddRows = false;
            this.dgvTrainerDues.AllowUserToDeleteRows = false;
            this.dgvTrainerDues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTrainerDues.BackgroundColor = System.Drawing.Color.White;
            this.dgvTrainerDues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrainerDues.Location = new System.Drawing.Point(30, 110);
            this.dgvTrainerDues.Name = "dgvTrainerDues";
            this.dgvTrainerDues.ReadOnly = true;
            this.dgvTrainerDues.RowHeadersVisible = false;
            this.dgvTrainerDues.Size = new System.Drawing.Size(740, 320);
            this.dgvTrainerDues.TabIndex = 0;
            this.dgvTrainerDues.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrainerDues_CellContentClick);
            
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(290, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 26);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "صرف مستحقات المدربات";
            
            // 
            // lblSafe
            // 
            this.lblSafe.AutoSize = true;
            this.lblSafe.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblSafe.Location = new System.Drawing.Point(620, 70);
            this.lblSafe.Name = "lblSafe";
            this.lblSafe.Size = new System.Drawing.Size(150, 19);
            this.lblSafe.TabIndex = 2;
            this.lblSafe.Text = "الخزنة (لخصم المبالغ منها):";
            this.lblSafe.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            
            // 
            // cmbSafes
            // 
            this.cmbSafes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSafes.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbSafes.FormattingEnabled = true;
            this.cmbSafes.Location = new System.Drawing.Point(390, 67);
            this.cmbSafes.Name = "cmbSafes";
            this.cmbSafes.Size = new System.Drawing.Size(220, 26);
            this.cmbSafes.TabIndex = 3;
            this.cmbSafes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            
            // 
            // TrainerDuesForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.cmbSafes);
            this.Controls.Add(this.lblSafe);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvTrainerDues);
            this.Name = "TrainerDuesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مستحقات المدربات";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainerDues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
