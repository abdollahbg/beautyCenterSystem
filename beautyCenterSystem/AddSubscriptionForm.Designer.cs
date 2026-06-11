using System.Drawing;
using System.Windows.Forms;
// تمت إزالة MaterialSkin.Controls لأننا لم نعد نحتاجها هنا

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
            cmbCustomers = new ComboBox();
            btnNewCustomer = new Button();
            cmbSubscriptionTypes = new ComboBox();
            dtpStartDate = new DateTimePicker();
            cmbPaymentMethod = new ComboBox();
            // تم تغيير النوع إلى TextBox العادي
            txtPaidAmount = new TextBox();
            txtNotes = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblCustomer = new Label();
            lblType = new Label();
            lblStartDate = new Label();
            lblPayment = new Label();
            lblPaidAmount = new Label(); // تمت إضافته لتعويض الـ Hint
            lblNotes = new Label();      // تمت إضافته لتعويض الـ Hint

            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // cmbCustomers
            // 
            cmbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomers.FormattingEnabled = true;
            cmbCustomers.Location = new Point(122, 64);
            cmbCustomers.Margin = new Padding(3, 2, 3, 2);
            cmbCustomers.Name = "cmbCustomers";
            cmbCustomers.Size = new Size(193, 23);
            cmbCustomers.TabIndex = 2;
            // 
            // btnNewCustomer
            // 
            btnNewCustomer.Location = new Point(18, 60);
            btnNewCustomer.Margin = new Padding(3, 2, 3, 2);
            btnNewCustomer.Name = "btnNewCustomer";
            btnNewCustomer.Size = new Size(96, 26);
            btnNewCustomer.TabIndex = 3;
            btnNewCustomer.Text = "عميلة جديدة";
            btnNewCustomer.UseVisualStyleBackColor = true;
            // 
            // cmbSubscriptionTypes
            // 
            cmbSubscriptionTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubscriptionTypes.FormattingEnabled = true;
            cmbSubscriptionTypes.Location = new Point(122, 101);
            cmbSubscriptionTypes.Margin = new Padding(3, 2, 3, 2);
            cmbSubscriptionTypes.Name = "cmbSubscriptionTypes";
            cmbSubscriptionTypes.Size = new Size(193, 23);
            cmbSubscriptionTypes.TabIndex = 5;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(122, 139);
            dtpStartDate.Margin = new Padding(3, 2, 3, 2);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(193, 23);
            dtpStartDate.TabIndex = 7;
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Card" });
            cmbPaymentMethod.Location = new Point(122, 176);
            cmbPaymentMethod.Margin = new Padding(3, 2, 3, 2);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(193, 23);
            cmbPaymentMethod.TabIndex = 9;
            // 
            // lblPaidAmount
            // 
            lblPaidAmount.AutoSize = true;
            lblPaidAmount.Location = new Point(332, 219);
            lblPaidAmount.Name = "lblPaidAmount";
            lblPaidAmount.Size = new Size(81, 15);
            lblPaidAmount.TabIndex = 14;
            lblPaidAmount.Text = "المبلغ المدفوع";
            // 
            // txtPaidAmount
            // 
            txtPaidAmount.BorderStyle = BorderStyle.FixedSingle;
            txtPaidAmount.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPaidAmount.Location = new Point(122, 214);
            txtPaidAmount.Margin = new Padding(3, 2, 3, 2);
            txtPaidAmount.MaxLength = 50;
            txtPaidAmount.Name = "txtPaidAmount";
            txtPaidAmount.Size = new Size(193, 29);
            txtPaidAmount.TabIndex = 10;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(332, 267);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(54, 15);
            lblNotes.TabIndex = 15;
            lblNotes.Text = "ملاحظات";
            // 
            // txtNotes
            // 
            txtNotes.BorderStyle = BorderStyle.FixedSingle;
            txtNotes.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNotes.Location = new Point(122, 262);
            txtNotes.Margin = new Padding(3, 2, 3, 2);
            txtNotes.MaxLength = 50;
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(193, 35);
            txtNotes.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(228, 315);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 30);
            btnSave.TabIndex = 12;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(122, 315);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 30);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "إلغاء";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 2, 3, 2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(438, 45);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(158, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(103, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Tag = "Header";
            lblTitle.Text = "تسجيل اشتراك جديد";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(332, 68);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(42, 15);
            lblCustomer.TabIndex = 1;
            lblCustomer.Text = "العميلة";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(332, 105);
            lblType.Name = "lblType";
            lblType.Size = new Size(53, 15);
            lblType.TabIndex = 4;
            lblType.Text = "نوع الباقة";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(332, 142);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(56, 15);
            lblStartDate.TabIndex = 6;
            lblStartDate.Text = "تاريخ البدء";
            // 
            // lblPayment
            // 
            lblPayment.AutoSize = true;
            lblPayment.Location = new Point(332, 180);
            lblPayment.Name = "lblPayment";
            lblPayment.Size = new Size(68, 15);
            lblPayment.TabIndex = 8;
            lblPayment.Text = "طريقة الدفع";
            // 
            // AddSubscriptionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 368);
            Controls.Add(lblNotes);
            Controls.Add(lblPaidAmount);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtNotes);
            Controls.Add(txtPaidAmount);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(lblPayment);
            Controls.Add(dtpStartDate);
            Controls.Add(lblStartDate);
            Controls.Add(cmbSubscriptionTypes);
            Controls.Add(lblType);
            Controls.Add(btnNewCustomer);
            Controls.Add(cmbCustomers);
            Controls.Add(lblCustomer);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddSubscriptionForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddSubscriptionForm";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ComboBox cmbCustomers;
        private System.Windows.Forms.Button btnNewCustomer;
        private System.Windows.Forms.ComboBox cmbSubscriptionTypes;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        // تم تغيير التعريفات لتصبح TextBox
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblPayment;
        // تمت إضافة تسميات لتوضيح الحقول بدلاً من خاصية Hint المفقودة في TextBox
        private System.Windows.Forms.Label lblPaidAmount;
        private System.Windows.Forms.Label lblNotes;
    }
}