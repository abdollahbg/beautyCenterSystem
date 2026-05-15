using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace beautyCenterSystem
{
    partial class AddSubscriptionForm
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
            this.cmbCustomers = new System.Windows.Forms.ComboBox();
            this.btnNewCustomer = new System.Windows.Forms.Button();
            this.cmbSubscriptionTypes = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.txtPaidAmount = new MaterialSkin.Controls.MaterialTextBox();
            this.txtNotes = new MaterialSkin.Controls.MaterialTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(500, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(180, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(120, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Tag = "Header";
            this.lblTitle.Text = "تسجيل اشتراك جديد";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(380, 90);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(50, 20);
            this.lblCustomer.TabIndex = 1;
            this.lblCustomer.Text = "العميلة";
            // 
            // cmbCustomers
            // 
            this.cmbCustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomers.FormattingEnabled = true;
            this.cmbCustomers.Location = new System.Drawing.Point(140, 85);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.Size = new System.Drawing.Size(220, 28);
            this.cmbCustomers.TabIndex = 2;
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Location = new System.Drawing.Point(20, 80);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(110, 35);
            this.btnNewCustomer.TabIndex = 3;
            this.btnNewCustomer.Text = "عميلة جديدة";
            this.btnNewCustomer.UseVisualStyleBackColor = true;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(380, 140);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(70, 20);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "نوع الباقة";
            // 
            // cmbSubscriptionTypes
            // 
            this.cmbSubscriptionTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubscriptionTypes.FormattingEnabled = true;
            this.cmbSubscriptionTypes.Location = new System.Drawing.Point(140, 135);
            this.cmbSubscriptionTypes.Name = "cmbSubscriptionTypes";
            this.cmbSubscriptionTypes.Size = new System.Drawing.Size(220, 28);
            this.cmbSubscriptionTypes.TabIndex = 5;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(380, 190);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(75, 20);
            this.lblStartDate.TabIndex = 6;
            this.lblStartDate.Text = "تاريخ البدء";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(140, 185);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(220, 27);
            this.dtpStartDate.TabIndex = 7;
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.Location = new System.Drawing.Point(380, 240);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(80, 20);
            this.lblPayment.TabIndex = 8;
            this.lblPayment.Text = "طريقة الدفع";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "Card"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(140, 235);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(220, 28);
            this.cmbPaymentMethod.TabIndex = 9;
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.AnimateReadOnly = false;
            this.txtPaidAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaidAmount.Depth = 0;
            this.txtPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPaidAmount.Hint = "المبلغ المدفوع";
            this.txtPaidAmount.Location = new System.Drawing.Point(140, 285);
            this.txtPaidAmount.MaxLength = 50;
            this.txtPaidAmount.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPaidAmount.Multiline = false;
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(220, 50);
            this.txtPaidAmount.TabIndex = 10;
            this.txtPaidAmount.Text = "";
            // 
            // txtNotes
            // 
            this.txtNotes.AnimateReadOnly = false;
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNotes.Depth = 0;
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtNotes.Hint = "ملاحظات";
            this.txtNotes.Location = new System.Drawing.Point(140, 350);
            this.txtNotes.MaxLength = 50;
            this.txtNotes.MouseState = MaterialSkin.MouseState.OUT;
            this.txtNotes.Multiline = false;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(220, 50);
            this.txtNotes.TabIndex = 11;
            this.txtNotes.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(260, 420);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(140, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddSubscriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 490);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtPaidAmount);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.lblPayment);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.cmbSubscriptionTypes);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnNewCustomer);
            this.Controls.Add(this.cmbCustomers);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddSubscriptionForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddSubscriptionForm";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox cmbCustomers;
        private System.Windows.Forms.Button btnNewCustomer;
        private System.Windows.Forms.ComboBox cmbSubscriptionTypes;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private MaterialSkin.Controls.MaterialTextBox txtPaidAmount;
        private MaterialSkin.Controls.MaterialTextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblPayment;
    }
}
