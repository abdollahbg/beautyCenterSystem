namespace beautyCenterSystem
{
    partial class AddPackageForm
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
            this.txtPackageName = new System.Windows.Forms.TextBox();
            this.txtDurationDays = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtTotalSessions = new System.Windows.Forms.TextBox();
            this.chkIsSessionBased = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPackageName = new System.Windows.Forms.Label();
            this.lblDurationDays = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblTotalSessions = new System.Windows.Forms.Label();
            
            // New controls
            this.dgvTrainers = new System.Windows.Forms.DataGridView();
            this.cmbTrainers = new System.Windows.Forms.ComboBox();
            this.txtBaseAmount = new System.Windows.Forms.TextBox();
            this.txtCommissionRate = new System.Windows.Forms.TextBox();
            this.btnAddTrainer = new System.Windows.Forms.Button();
            this.lblTrainer = new System.Windows.Forms.Label();
            this.lblBaseAmount = new System.Windows.Forms.Label();
            this.lblCommissionRate = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainers)).BeginInit();
            this.SuspendLayout();

            // Form
            this.ClientSize = new System.Drawing.Size(650, 480);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "≈÷«›… /  ⁄œÌ· »«ﬁ… ÃÌ„";

            // Existing
            this.lblPackageName.Location = new System.Drawing.Point(30, 20);
            this.lblPackageName.Text = "«”„ «·»«ﬁ…";
            this.txtPackageName.Location = new System.Drawing.Point(30, 40);
            this.txtPackageName.Size = new System.Drawing.Size(340, 29);
            this.txtPackageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);

            this.lblDurationDays.Location = new System.Drawing.Point(30, 80);
            this.lblDurationDays.Text = "«·„œ… (»«·√Ì«„)";
            this.txtDurationDays.Location = new System.Drawing.Point(30, 100);
            this.txtDurationDays.Size = new System.Drawing.Size(160, 29);
            this.txtDurationDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);

            this.lblPrice.Location = new System.Drawing.Point(210, 80);
            this.lblPrice.Text = "«·”⁄—";
            this.txtPrice.Location = new System.Drawing.Point(210, 100);
            this.txtPrice.Size = new System.Drawing.Size(160, 29);
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);

            this.chkIsSessionBased.Location = new System.Drawing.Point(30, 150);
            this.chkIsSessionBased.Text = "»«ﬁ… Õ’’";

            this.lblTotalSessions.Location = new System.Drawing.Point(210, 130);
            this.lblTotalSessions.Text = "≈Ã„«·Ì «·Õ’’";
            this.txtTotalSessions.Location = new System.Drawing.Point(210, 150);
            this.txtTotalSessions.Size = new System.Drawing.Size(160, 29);
            this.txtTotalSessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTotalSessions.Enabled = false;

            // New Trainer Selection
            this.lblTrainer.Location = new System.Drawing.Point(30, 200);
            this.lblTrainer.Text = "«·„œ—»…";
            this.cmbTrainers.Location = new System.Drawing.Point(30, 220);
            this.cmbTrainers.Size = new System.Drawing.Size(200, 29);
            this.cmbTrainers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbTrainers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblBaseAmount.Location = new System.Drawing.Point(240, 200);
            this.lblBaseAmount.Text = "«·√”«”";
            this.txtBaseAmount.Location = new System.Drawing.Point(240, 220);
            this.txtBaseAmount.Size = new System.Drawing.Size(100, 29);
            this.txtBaseAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);

            this.lblCommissionRate.Location = new System.Drawing.Point(350, 200);
            this.lblCommissionRate.Text = "«·‰”»… %";
            this.txtCommissionRate.Location = new System.Drawing.Point(350, 220);
            this.txtCommissionRate.Size = new System.Drawing.Size(100, 29);
            this.txtCommissionRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);

            this.btnAddTrainer.Location = new System.Drawing.Point(460, 219);
            this.btnAddTrainer.Size = new System.Drawing.Size(100, 31);
            this.btnAddTrainer.Text = "≈÷«›… „œ—»…";

            // Grid
            this.dgvTrainers.Location = new System.Drawing.Point(30, 270);
            this.dgvTrainers.Size = new System.Drawing.Size(590, 130);
            this.dgvTrainers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTrainers.AllowUserToAddRows = false;
            this.dgvTrainers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrainers.ReadOnly = true;

            // Buttons
            this.btnSave.Location = new System.Drawing.Point(410, 420);
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.Text = "Õ›Ÿ";

            this.btnCancel.Location = new System.Drawing.Point(520, 420);
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.Text = "≈·€«¡";

            // Add Controls
            this.Controls.Add(this.txtPackageName);
            this.Controls.Add(this.txtDurationDays);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtTotalSessions);
            this.Controls.Add(this.chkIsSessionBased);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblPackageName);
            this.Controls.Add(this.lblDurationDays);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblTotalSessions);
            
            this.Controls.Add(this.dgvTrainers);
            this.Controls.Add(this.cmbTrainers);
            this.Controls.Add(this.txtBaseAmount);
            this.Controls.Add(this.txtCommissionRate);
            this.Controls.Add(this.btnAddTrainer);
            this.Controls.Add(this.lblTrainer);
            this.Controls.Add(this.lblBaseAmount);
            this.Controls.Add(this.lblCommissionRate);

            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtPackageName;
        private System.Windows.Forms.TextBox txtDurationDays;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtTotalSessions;
        private System.Windows.Forms.CheckBox chkIsSessionBased;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPackageName;
        private System.Windows.Forms.Label lblDurationDays;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblTotalSessions;
        
        private System.Windows.Forms.DataGridView dgvTrainers;
        private System.Windows.Forms.ComboBox cmbTrainers;
        private System.Windows.Forms.TextBox txtBaseAmount;
        private System.Windows.Forms.TextBox txtCommissionRate;
        private System.Windows.Forms.Button btnAddTrainer;
        private System.Windows.Forms.Label lblTrainer;
        private System.Windows.Forms.Label lblBaseAmount;
        private System.Windows.Forms.Label lblCommissionRate;
    }
}
