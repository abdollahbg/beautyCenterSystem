using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;

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
            this.txtPackageName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDurationDays = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPrice = new MaterialSkin.Controls.MaterialTextBox();
            this.txtTotalSessions = new MaterialSkin.Controls.MaterialTextBox();
            this.chkIsSessionBased = new MaterialSkin.Controls.MaterialCheckbox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPackageName
            // 
            this.txtPackageName.AnimateReadOnly = false;
            this.txtPackageName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPackageName.Depth = 0;
            this.txtPackageName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPackageName.Hint = "اسم الباقة";
            this.txtPackageName.LeadingIcon = null;
            this.txtPackageName.Location = new System.Drawing.Point(30, 90);
            this.txtPackageName.MaxLength = 50;
            this.txtPackageName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPackageName.Multiline = false;
            this.txtPackageName.Name = "txtPackageName";
            this.txtPackageName.Size = new System.Drawing.Size(340, 50);
            this.txtPackageName.TabIndex = 0;
            this.txtPackageName.Text = "";
            this.txtPackageName.TrailingIcon = null;
            // 
            // txtDurationDays
            // 
            this.txtDurationDays.AnimateReadOnly = false;
            this.txtDurationDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDurationDays.Depth = 0;
            this.txtDurationDays.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDurationDays.Hint = "المدة (بالأيام)";
            this.txtDurationDays.LeadingIcon = null;
            this.txtDurationDays.Location = new System.Drawing.Point(30, 160);
            this.txtDurationDays.MaxLength = 50;
            this.txtDurationDays.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDurationDays.Multiline = false;
            this.txtDurationDays.Name = "txtDurationDays";
            this.txtDurationDays.Size = new System.Drawing.Size(160, 50);
            this.txtDurationDays.TabIndex = 1;
            this.txtDurationDays.Text = "";
            this.txtDurationDays.TrailingIcon = null;
            // 
            // txtPrice
            // 
            this.txtPrice.AnimateReadOnly = false;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrice.Depth = 0;
            this.txtPrice.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPrice.Hint = "السعر";
            this.txtPrice.LeadingIcon = null;
            this.txtPrice.Location = new System.Drawing.Point(210, 160);
            this.txtPrice.MaxLength = 50;
            this.txtPrice.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPrice.Multiline = false;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(160, 50);
            this.txtPrice.TabIndex = 2;
            this.txtPrice.Text = "";
            this.txtPrice.TrailingIcon = null;
            // 
            // chkIsSessionBased
            // 
            this.chkIsSessionBased.AutoSize = true;
            this.chkIsSessionBased.Depth = 0;
            this.chkIsSessionBased.Location = new System.Drawing.Point(30, 230);
            this.chkIsSessionBased.Margin = new System.Windows.Forms.Padding(0);
            this.chkIsSessionBased.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkIsSessionBased.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkIsSessionBased.Name = "chkIsSessionBased";
            this.chkIsSessionBased.ReadOnly = false;
            this.chkIsSessionBased.Ripple = true;
            this.chkIsSessionBased.Size = new System.Drawing.Size(117, 37);
            this.chkIsSessionBased.TabIndex = 3;
            this.chkIsSessionBased.Text = "باقة بالحصص؟";
            this.chkIsSessionBased.UseVisualStyleBackColor = true;
            // 
            // txtTotalSessions
            // 
            this.txtTotalSessions.AnimateReadOnly = false;
            this.txtTotalSessions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalSessions.Depth = 0;
            this.txtTotalSessions.Enabled = false;
            this.txtTotalSessions.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTotalSessions.Hint = "إجمالي الحصص";
            this.txtTotalSessions.LeadingIcon = null;
            this.txtTotalSessions.Location = new System.Drawing.Point(210, 230);
            this.txtTotalSessions.MaxLength = 50;
            this.txtTotalSessions.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTotalSessions.Multiline = false;
            this.txtTotalSessions.Name = "txtTotalSessions";
            this.txtTotalSessions.Size = new System.Drawing.Size(160, 50);
            this.txtTotalSessions.TabIndex = 4;
            this.txtTotalSessions.Text = "";
            this.txtTotalSessions.TrailingIcon = null;
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

        private MaterialSkin.Controls.MaterialTextBox txtPackageName;
        private MaterialSkin.Controls.MaterialTextBox txtDurationDays;
        private MaterialSkin.Controls.MaterialTextBox txtPrice;
        private MaterialSkin.Controls.MaterialTextBox txtTotalSessions;
        private MaterialSkin.Controls.MaterialCheckbox chkIsSessionBased;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
