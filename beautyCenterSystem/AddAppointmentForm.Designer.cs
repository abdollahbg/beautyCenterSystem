namespace beautyCenterSystem
{
    partial class AddAppointmentForm
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
            pnlSidebar = new Panel();
            pnlMainContent = new Panel();
            pnlFormHeader = new Panel();
            dtpAppointmentTime = new DateTimePicker();
            dtpAppointmentDate = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            pnlFormHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.Dock = DockStyle.Right;
            pnlSidebar.Location = new Point(750, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(350, 700);
            pnlSidebar.TabIndex = 0;
            // 
            // pnlMainContent
            // 
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(0, 60);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(750, 640);
            pnlMainContent.TabIndex = 2;
            // 
            // pnlFormHeader
            // 
            pnlFormHeader.BackColor = Color.White;
            pnlFormHeader.Controls.Add(dtpAppointmentTime);
            pnlFormHeader.Controls.Add(dtpAppointmentDate);
            pnlFormHeader.Controls.Add(label3);
            pnlFormHeader.Controls.Add(label4);
            pnlFormHeader.Dock = DockStyle.Top;
            pnlFormHeader.Location = new Point(0, 0);
            pnlFormHeader.Name = "pnlFormHeader";
            pnlFormHeader.Size = new Size(750, 60);
            pnlFormHeader.TabIndex = 1;
            // 
            // dtpAppointmentTime
            // 
            dtpAppointmentTime.CustomFormat = "mm:hh tt";
            dtpAppointmentTime.Format = DateTimePickerFormat.Custom;
            dtpAppointmentTime.Location = new Point(20, 18);
            dtpAppointmentTime.Name = "dtpAppointmentTime";
            dtpAppointmentTime.RightToLeft = RightToLeft.Yes;
            dtpAppointmentTime.ShowUpDown = true;
            dtpAppointmentTime.Size = new Size(120, 23);
            dtpAppointmentTime.TabIndex = 3;
            // 
            // dtpAppointmentDate
            // 
            dtpAppointmentDate.Format = DateTimePickerFormat.Short;
            dtpAppointmentDate.Location = new Point(220, 18);
            dtpAppointmentDate.Name = "dtpAppointmentDate";
            dtpAppointmentDate.Size = new Size(140, 23);
            dtpAppointmentDate.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(370, 22);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(63, 15);
            label3.TabIndex = 4;
            label3.Text = "تاريخ الحجز:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(150, 22);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.Yes;
            label4.Size = new Size(62, 15);
            label4.TabIndex = 5;
            label4.Text = "وقت الحجز:";
            // 
            // AddAppointmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlFormHeader);
            Controls.Add(pnlSidebar);
            Name = "AddAppointmentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "إضافة حجز جديد";
            Load += AddAppointmentForm_Load;
            pnlFormHeader.ResumeLayout(false);
            pnlFormHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlFormHeader;
        private System.Windows.Forms.DateTimePicker dtpAppointmentTime;
        private System.Windows.Forms.DateTimePicker dtpAppointmentDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}