namespace beautyCenterSystem.data.Repositories
{
    partial class CheckoutForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtTotalSystem = new TextBox();
            label3 = new Label();
            label4 = new Label();
            cmbPaymentMethod = new ComboBox();
            lblCustomerName = new Label();
            txtAmountPaid = new TextBox();
            txtDiscount = new TextBox();
            label5 = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            txtNet = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(319, 66);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(84, 20);
            label1.TabIndex = 0;
            label1.Text = "اسم العميل:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(319, 120);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 1;
            label2.Text = "الإجمالي";
            // 
            // txtTotalSystem
            // 
            txtTotalSystem.BorderStyle = BorderStyle.FixedSingle;
            txtTotalSystem.Font = new Font("Segoe UI", 15F);
            txtTotalSystem.Location = new Point(186, 113);
            txtTotalSystem.Name = "txtTotalSystem";
            txtTotalSystem.Size = new Size(121, 34);
            txtTotalSystem.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(319, 178);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 4;
            label3.Text = "المدفوع";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(319, 352);
            label4.Name = "label4";
            label4.Size = new Size(88, 20);
            label4.TabIndex = 5;
            label4.Text = "طريقة الدفع";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.Font = new Font("Segoe UI", 15F);
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Location = new Point(151, 341);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(156, 36);
            cmbPaymentMethod.TabIndex = 6;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 11F);
            lblCustomerName.Location = new Point(259, 66);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.RightToLeft = RightToLeft.Yes;
            lblCustomerName.Size = new Size(17, 20);
            lblCustomerName.TabIndex = 7;
            lblCustomerName.Text = "0";
            // 
            // txtAmountPaid
            // 
            txtAmountPaid.BorderStyle = BorderStyle.FixedSingle;
            txtAmountPaid.Font = new Font("Segoe UI", 15F);
            txtAmountPaid.Location = new Point(186, 170);
            txtAmountPaid.Name = "txtAmountPaid";
            txtAmountPaid.Size = new Size(121, 34);
            txtAmountPaid.TabIndex = 8;
            // 
            // txtDiscount
            // 
            txtDiscount.Font = new Font("Segoe UI", 15F);
            txtDiscount.Location = new Point(186, 227);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(121, 34);
            txtDiscount.TabIndex = 9;
            txtDiscount.TextChanged += txtDiscount_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F);
            label5.Location = new Point(319, 236);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 10;
            label5.Text = "الخصم";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(259, 425);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(110, 55);
            btnConfirm.TabIndex = 11;
            btnConfirm.Text = "تأكيد";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(76, 425);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(110, 55);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "الغاء";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtNet
            // 
            txtNet.BorderStyle = BorderStyle.FixedSingle;
            txtNet.Font = new Font("Segoe UI", 15F);
            txtNet.Location = new Point(186, 284);
            txtNet.Name = "txtNet";
            txtNet.Size = new Size(121, 34);
            txtNet.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.Location = new Point(319, 294);
            label6.Name = "label6";
            label6.Size = new Size(58, 20);
            label6.TabIndex = 14;
            label6.Text = "الصافي";
            // 
            // CheckoutForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(434, 511);
            Controls.Add(label6);
            Controls.Add(txtNet);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(label5);
            Controls.Add(txtDiscount);
            Controls.Add(txtAmountPaid);
            Controls.Add(lblCustomerName);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtTotalSystem);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "CheckoutForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "إعداد الدفع";
            Load += CheckoutForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtTotalSystem;
        private TextBox textBox2;
        private Label label3;
        private Label label4;
        private ComboBox cmbPaymentMethod;
        private Label lblCustomerName;
        private TextBox txtAmountPaid;
        private TextBox txtDiscount;
        private Label label5;
        private Button btnConfirm;
        private Button btnCancel;
        private TextBox txtNet;
        private Label label6;
    }
}