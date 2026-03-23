namespace beautyCenterSystem
{
    partial class AddServiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddServiceForm));
            PnlHeader = new Panel();
            label1 = new Label();
            BtnCancel = new Button();
            btnSave = new Button();
            txtServiceName = new MaterialSkin.Controls.MaterialTextBox2();
            txtPrice = new MaterialSkin.Controls.MaterialTextBox2();
            txtDuration = new MaterialSkin.Controls.MaterialTextBox2();
            cmbRooms = new MaterialSkin.Controls.MaterialComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
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
            PnlHeader.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(140, 20);
            label1.Name = "label1";
            label1.Size = new Size(165, 28);
            label1.TabIndex = 1;
            label1.Text = "إضافة خدمة جديدة";
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(59, 437);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(124, 48);
            BtnCancel.TabIndex = 7;
            BtnCancel.Text = "الغاء";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(242, 437);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(124, 48);
            btnSave.TabIndex = 6;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtServiceName
            // 
            txtServiceName.AnimateReadOnly = false;
            txtServiceName.AutoCompleteMode = AutoCompleteMode.None;
            txtServiceName.AutoCompleteSource = AutoCompleteSource.None;
            txtServiceName.BackgroundImageLayout = ImageLayout.None;
            txtServiceName.CharacterCasing = CharacterCasing.Normal;
            txtServiceName.Depth = 0;
            txtServiceName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtServiceName.HideSelection = true;
            txtServiceName.LeadingIcon = null;
            txtServiceName.Location = new Point(92, 141);
            txtServiceName.MaxLength = 32767;
            txtServiceName.MouseState = MaterialSkin.MouseState.OUT;
            txtServiceName.Name = "txtServiceName";
            txtServiceName.PasswordChar = '\0';
            txtServiceName.PrefixSuffixText = null;
            txtServiceName.ReadOnly = false;
            txtServiceName.RightToLeft = RightToLeft.Yes;
            txtServiceName.SelectedText = "";
            txtServiceName.SelectionLength = 0;
            txtServiceName.SelectionStart = 0;
            txtServiceName.ShortcutsEnabled = true;
            txtServiceName.Size = new Size(250, 48);
            txtServiceName.TabIndex = 8;
            txtServiceName.TabStop = false;
            txtServiceName.TextAlign = HorizontalAlignment.Right;
            txtServiceName.TrailingIcon = null;
            txtServiceName.UseSystemPasswordChar = false;
            // 
            // txtPrice
            // 
            txtPrice.AnimateReadOnly = false;
            txtPrice.AutoCompleteMode = AutoCompleteMode.None;
            txtPrice.AutoCompleteSource = AutoCompleteSource.None;
            txtPrice.BackgroundImageLayout = ImageLayout.None;
            txtPrice.CharacterCasing = CharacterCasing.Normal;
            txtPrice.Depth = 0;
            txtPrice.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPrice.HideSelection = true;
            txtPrice.LeadingIcon = null;
            txtPrice.Location = new Point(257, 200);
            txtPrice.MaxLength = 32767;
            txtPrice.MouseState = MaterialSkin.MouseState.OUT;
            txtPrice.Name = "txtPrice";
            txtPrice.PasswordChar = '\0';
            txtPrice.PrefixSuffixText = null;
            txtPrice.ReadOnly = false;
            txtPrice.RightToLeft = RightToLeft.Yes;
            txtPrice.SelectedText = "";
            txtPrice.SelectionLength = 0;
            txtPrice.SelectionStart = 0;
            txtPrice.ShortcutsEnabled = true;
            txtPrice.Size = new Size(85, 48);
            txtPrice.TabIndex = 9;
            txtPrice.TabStop = false;
            txtPrice.TextAlign = HorizontalAlignment.Right;
            txtPrice.TrailingIcon = null;
            txtPrice.UseSystemPasswordChar = false;
            txtPrice.KeyPress += txtPrice_KeyPress;
            // 
            // txtDuration
            // 
            txtDuration.AnimateReadOnly = false;
            txtDuration.AutoCompleteMode = AutoCompleteMode.None;
            txtDuration.AutoCompleteSource = AutoCompleteSource.None;
            txtDuration.BackgroundImageLayout = ImageLayout.None;
            txtDuration.CharacterCasing = CharacterCasing.Normal;
            txtDuration.Depth = 0;
            txtDuration.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtDuration.HideSelection = true;
            txtDuration.LeadingIcon = null;
            txtDuration.Location = new Point(257, 259);
            txtDuration.MaxLength = 32767;
            txtDuration.MouseState = MaterialSkin.MouseState.OUT;
            txtDuration.Name = "txtDuration";
            txtDuration.PasswordChar = '\0';
            txtDuration.PrefixSuffixText = null;
            txtDuration.ReadOnly = false;
            txtDuration.RightToLeft = RightToLeft.Yes;
            txtDuration.SelectedText = "";
            txtDuration.SelectionLength = 0;
            txtDuration.SelectionStart = 0;
            txtDuration.ShortcutsEnabled = true;
            txtDuration.Size = new Size(85, 48);
            txtDuration.TabIndex = 10;
            txtDuration.TabStop = false;
            txtDuration.TextAlign = HorizontalAlignment.Right;
            txtDuration.TrailingIcon = null;
            txtDuration.UseSystemPasswordChar = false;
            txtDuration.KeyPress += txtDuration_KeyPress;
            // 
            // cmbRooms
            // 
            cmbRooms.AutoResize = false;
            cmbRooms.BackColor = Color.FromArgb(255, 255, 255);
            cmbRooms.Depth = 0;
            cmbRooms.DrawMode = DrawMode.OwnerDrawVariable;
            cmbRooms.DropDownHeight = 174;
            cmbRooms.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRooms.DropDownWidth = 121;
            cmbRooms.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbRooms.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbRooms.FormattingEnabled = true;
            cmbRooms.IntegralHeight = false;
            cmbRooms.ItemHeight = 43;
            cmbRooms.Location = new Point(92, 313);
            cmbRooms.MaxDropDownItems = 4;
            cmbRooms.MouseState = MaterialSkin.MouseState.OUT;
            cmbRooms.Name = "cmbRooms";
            cmbRooms.Size = new Size(250, 49);
            cmbRooms.StartIndex = 0;
            cmbRooms.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(348, 157);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(63, 15);
            label2.TabIndex = 12;
            label2.Text = "اسم الخدمة";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(348, 215);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 13;
            label3.Text = "السعر";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(348, 273);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.Yes;
            label4.Size = new Size(83, 15);
            label4.TabIndex = 14;
            label4.Text = "المدة (بالدقائق)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(348, 332);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.Yes;
            label5.Size = new Size(40, 15);
            label5.TabIndex = 15;
            label5.Text = "الغرفة ";
            // 
            // AddServiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 511);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmbRooms);
            Controls.Add(txtDuration);
            Controls.Add(txtPrice);
            Controls.Add(txtServiceName);
            Controls.Add(BtnCancel);
            Controls.Add(btnSave);
            Controls.Add(PnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddServiceForm";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterParent;
            Text = "اضافة خدمة";
            PnlHeader.ResumeLayout(false);
            PnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PnlHeader;
        private Label label1;
        private Button BtnCancel;
        private Button btnSave;
        private MaterialSkin.Controls.MaterialTextBox2 txtServiceName;
        private MaterialSkin.Controls.MaterialTextBox2 txtPrice;
        private MaterialSkin.Controls.MaterialTextBox2 txtDuration;
        private MaterialSkin.Controls.MaterialComboBox cmbRooms;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}