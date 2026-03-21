namespace beautyCenterSystem
{
    partial class AddCustomerForm
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
            PnlHeader = new Panel();
            label1 = new Label();
            txtName = new MaterialSkin.Controls.MaterialTextBox2();
            btnSave = new Button();
            BtnCancel = new Button();
            label2 = new Label();
            label3 = new Label();
            txtNotes = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            BtnNotes = new Label();
            txtPhone = new MaterialSkin.Controls.MaterialTextBox2();
            PnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // PnlHeader
            // 
            PnlHeader.Controls.Add(label1);
            PnlHeader.Dock = DockStyle.Top;
            PnlHeader.Location = new Point(0, 0);
            PnlHeader.Name = "PnlHeader";
            PnlHeader.Size = new Size(434, 69);
            PnlHeader.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(140, 20);
            label1.Name = "label1";
            label1.Size = new Size(155, 28);
            label1.TabIndex = 1;
            label1.Text = "إضافة عميل جديد";
            // 
            // txtName
            // 
            txtName.AnimateReadOnly = false;
            txtName.AutoCompleteMode = AutoCompleteMode.None;
            txtName.AutoCompleteSource = AutoCompleteSource.None;
            txtName.BackgroundImageLayout = ImageLayout.None;
            txtName.CharacterCasing = CharacterCasing.Normal;
            txtName.Depth = 0;
            txtName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtName.HideSelection = true;
            txtName.LeadingIcon = null;
            txtName.Location = new Point(92, 136);
            txtName.MaxLength = 32767;
            txtName.MouseState = MaterialSkin.MouseState.OUT;
            txtName.Name = "txtName";
            txtName.PasswordChar = '\0';
            txtName.PrefixSuffixText = null;
            txtName.ReadOnly = false;
            txtName.RightToLeft = RightToLeft.Yes;
            txtName.SelectedText = "";
            txtName.SelectionLength = 0;
            txtName.SelectionStart = 0;
            txtName.ShortcutsEnabled = true;
            txtName.Size = new Size(250, 48);
            txtName.TabIndex = 1;
            txtName.TabStop = false;
            txtName.TextAlign = HorizontalAlignment.Right;
            txtName.TrailingIcon = null;
            txtName.UseSystemPasswordChar = false;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(246, 411);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(124, 48);
            btnSave.TabIndex = 4;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(63, 411);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(124, 48);
            BtnCancel.TabIndex = 5;
            BtnCancel.Text = "الغاء";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(348, 153);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 6;
            label2.Text = "الإسم";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(348, 217);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 7;
            label3.Text = "رقم الهاتف";
            // 
            // txtNotes
            // 
            txtNotes.AnimateReadOnly = false;
            txtNotes.BackgroundImageLayout = ImageLayout.None;
            txtNotes.CharacterCasing = CharacterCasing.Normal;
            txtNotes.Depth = 0;
            txtNotes.HideSelection = true;
            txtNotes.Location = new Point(92, 274);
            txtNotes.MaxLength = 32767;
            txtNotes.MouseState = MaterialSkin.MouseState.OUT;
            txtNotes.Name = "txtNotes";
            txtNotes.PasswordChar = '\0';
            txtNotes.ReadOnly = false;
            txtNotes.ScrollBars = ScrollBars.None;
            txtNotes.SelectedText = "";
            txtNotes.SelectionLength = 0;
            txtNotes.SelectionStart = 0;
            txtNotes.ShortcutsEnabled = true;
            txtNotes.Size = new Size(250, 100);
            txtNotes.TabIndex = 3;
            txtNotes.TabStop = false;
            txtNotes.TextAlign = HorizontalAlignment.Left;
            txtNotes.UseSystemPasswordChar = false;
            // 
            // BtnNotes
            // 
            BtnNotes.AutoSize = true;
            BtnNotes.Location = new Point(348, 313);
            BtnNotes.Name = "BtnNotes";
            BtnNotes.Size = new Size(52, 15);
            BtnNotes.TabIndex = 8;
            BtnNotes.Text = "ملاحظات";
            // 
            // txtPhone
            // 
            txtPhone.AnimateReadOnly = false;
            txtPhone.AutoCompleteMode = AutoCompleteMode.None;
            txtPhone.AutoCompleteSource = AutoCompleteSource.None;
            txtPhone.BackgroundImageLayout = ImageLayout.None;
            txtPhone.CharacterCasing = CharacterCasing.Normal;
            txtPhone.Depth = 0;
            txtPhone.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPhone.HideSelection = true;
            txtPhone.LeadingIcon = null;
            txtPhone.Location = new Point(92, 202);
            txtPhone.MaxLength = 32767;
            txtPhone.MouseState = MaterialSkin.MouseState.OUT;
            txtPhone.Name = "txtPhone";
            txtPhone.PasswordChar = '\0';
            txtPhone.PrefixSuffixText = null;
            txtPhone.ReadOnly = false;
            txtPhone.RightToLeft = RightToLeft.Yes;
            txtPhone.SelectedText = "";
            txtPhone.SelectionLength = 0;
            txtPhone.SelectionStart = 0;
            txtPhone.ShortcutsEnabled = true;
            txtPhone.Size = new Size(250, 48);
            txtPhone.TabIndex = 2;
            txtPhone.TabStop = false;
            txtPhone.TextAlign = HorizontalAlignment.Right;
            txtPhone.TrailingIcon = null;
            txtPhone.UseSystemPasswordChar = false;
            // 
            // AddCustomerForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(434, 511);
            Controls.Add(BtnNotes);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(BtnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtNotes);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(PnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AddCustomerForm";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterParent;
            Text = "اضافة عميل";
            Load += AddCustomerForm_Load;
            PnlHeader.ResumeLayout(false);
            PnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PnlHeader;
        private Label label1;
        private MaterialSkin.Controls.MaterialTextBox2 txtName;
        private Button btnSave;
        private Button BtnCancel;
        private Label label2;
        private Label label3;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtNotes;
        private Label BtnNotes;
        private MaterialSkin.Controls.MaterialTextBox2 txtPhone;
    }
}