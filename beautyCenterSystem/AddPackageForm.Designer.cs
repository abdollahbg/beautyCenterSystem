using System.Drawing;
using System.Windows.Forms;

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

            // إضافة Labels لتعويض خاصية الـ Hint
            this.lblPackageName = new System.Windows.Forms.Label();
            this.lblDurationDays = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblTotalSessions = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // 
            // lblPackageName
            // 
            this.lblPackageName.AutoSize = true;
            this.lblPackageName.Location = new System.Drawing.Point(30, 68);
            this.lblPackageName.Name = "lblPackageName";
            this.lblPackageName.Size = new System.Drawing.Size(59, 15);
            this.lblPackageName.TabIndex = 7;
            this.lblPackageName.Text = "اسم الباقة";
            // 
            // txtPackageName
            // 
            this.txtPackageName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPackageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackageName.Location = new System.Drawing.Point(30, 88);
            this.txtPackageName.MaxLength = 50;
            this.txtPackageName.Name = "txtPackageName";
            this.txtPackageName.Size = new System.Drawing.Size(340, 29);
            this.txtPackageName.TabIndex = 0;
            // 
            // lblDurationDays
            // 
            this.lblDurationDays.AutoSize = true;
            this.lblDurationDays.Location = new System.Drawing.Point(30, 138);
            this.lblDurationDays.Name = "lblDurationDays";
            this.lblDurationDays.Size = new System.Drawing.Size(78, 15);
            this.lblDurationDays.TabIndex = 8;
            this.lblDurationDays.Text = "المدة (بالأيام)";
            // 
            // txtDurationDays
            // 
            this.txtDurationDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDurationDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDurationDays.Location = new System.Drawing.Point(30, 158);
            this.txtDurationDays.MaxLength = 50;
            this.txtDurationDays.Name = "txtDurationDays";
            this.txtDurationDays.Size = new System.Drawing.Size(160, 29);
            this.txtDurationDays.TabIndex = 1;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(210, 138);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 15);
            this.lblPrice.TabIndex = 9;
            this.lblPrice.Text = "السعر";
            // 
            // txtPrice
            // 
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(210, 158);
            this.txtPrice.MaxLength = 50;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(160, 29);
            this.txtPrice.TabIndex = 2;
            // 
            // chkIsSessionBased
            // 
            this.chkIsSessionBased.AutoSize = true;
            this.chkIsSessionBased.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsSessionBased.Location = new System.Drawing.Point(30, 230);
            this.chkIsSessionBased.Name = "chkIsSessionBased";
            this.chkIsSessionBased.Size = new System.Drawing.Size(107, 22);
            this.chkIsSessionBased.TabIndex = 3;
            this.chkIsSessionBased.Text = "باقة بالحصص؟";
            this.chkIsSessionBased.UseVisualStyleBackColor = true;
            // 
            // lblTotalSessions
            // 
            this.lblTotalSessions.AutoSize = true;
            this.lblTotalSessions.Location = new System.Drawing.Point(210, 208);
            this.lblTotalSessions.Name = "lblTotalSessions";
            this.lblTotalSessions.Size = new System.Drawing.Size(78, 15);
            this.lblTotalSessions.TabIndex = 10;
            this.lblTotalSessions.Text = "إجمالي الحصص";
            // 
            // txtTotalSessions
            // 
            this.txtTotalSessions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalSessions.Enabled = false;
            this.txtTotalSessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSessions.Location = new System.Drawing.Point(210, 228);
            this.txtTotalSessions.MaxLength = 50;
            this.txtTotalSessions.Name = "txtTotalSessions";
            this.txtTotalSessions.Size = new System.Drawing.Size(160, 29);
            this.txtTotalSessions.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(210, 310);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 45);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(30, 310);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 45);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddPackageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 380);
            this.Controls.Add(this.lblTotalSessions);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblDurationDays);
            this.Controls.Add(this.lblPackageName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtTotalSessions);
            this.Controls.Add(this.chkIsSessionBased);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtDurationDays);
            this.Controls.Add(this.txtPackageName);
            this.Name = "AddPackageForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "إضافة باقة جديدة";
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

        // التسميات الجديدة
        private System.Windows.Forms.Label lblPackageName;
        private System.Windows.Forms.Label lblDurationDays;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblTotalSessions;
    }
}