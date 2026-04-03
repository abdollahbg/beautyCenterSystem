namespace beautyCenterSystem
{
    partial class AddMaterialForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMaterialForm));
            label3 = new Label();
            PnlHeader = new Panel();
            label1 = new Label();
            chkIsAvailable = new MaterialSkin.Controls.MaterialCheckbox();
            label2 = new Label();
            BtnCancel = new Button();
            btnSave = new Button();
            txtMaterialName = new MaterialSkin.Controls.MaterialTextBox2();
            txtSalePrice = new MaterialSkin.Controls.MaterialTextBox2();
            label4 = new Label();
            txtStockQuantity = new MaterialSkin.Controls.MaterialTextBox2();
            label5 = new Label();
            chkIsCaffeteria = new MaterialSkin.Controls.MaterialCheckbox();
            label6 = new Label();
            PnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // label3 (متوفر)
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(364, 305);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 16;
            label3.Text = "متوفر";
            // 
            // PnlHeader
            // 
            PnlHeader.Controls.Add(label1);
            PnlHeader.Dock = DockStyle.Top;
            PnlHeader.Location = new Point(0, 0);
            PnlHeader.Name = "PnlHeader";
            PnlHeader.Size = new Size(434, 69);
            PnlHeader.TabIndex = 11;
            // 
            // label1 (العنوان)
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(140, 20);
            label1.Name = "label1";
            label1.Size = new Size(156, 28);
            label1.TabIndex = 1;
            label1.Text = "إضافة عنصر جديد";
            // 
            // chkIsAvailable
            // 
            chkIsAvailable.AutoSize = true;
            chkIsAvailable.Checked = true;
            chkIsAvailable.CheckState = CheckState.Checked;
            chkIsAvailable.Depth = 0;
            chkIsAvailable.Location = new Point(310, 298);
            chkIsAvailable.Margin = new Padding(0);
            chkIsAvailable.MouseLocation = new Point(-1, -1);
            chkIsAvailable.MouseState = MaterialSkin.MouseState.HOVER;
            chkIsAvailable.Name = "chkIsAvailable";
            chkIsAvailable.ReadOnly = false;
            chkIsAvailable.Ripple = true;
            chkIsAvailable.Size = new Size(35, 37);
            chkIsAvailable.TabIndex = 4;
            chkIsAvailable.UseVisualStyleBackColor = true;
            // 
            // label2 (إسم المادة)
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(345, 102);
            label2.Name = "label2";
            label2.Size = new Size(71, 19);
            label2.TabIndex = 15;
            label2.Text = "إسم المادة";
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(70, 370);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(124, 48);
            BtnCancel.TabIndex = 7;
            BtnCancel.Text = "الغاء";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(253, 370);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(124, 48);
            btnSave.TabIndex = 6;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtMaterialName
            // 
            txtMaterialName.AnimateReadOnly = false;
            txtMaterialName.BackgroundImageLayout = ImageLayout.None;
            txtMaterialName.Depth = 0;
            txtMaterialName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMaterialName.Location = new Point(70, 89);
            txtMaterialName.MaxLength = 100;
            txtMaterialName.MouseState = MaterialSkin.MouseState.OUT;
            txtMaterialName.Name = "txtMaterialName";
            txtMaterialName.RightToLeft = RightToLeft.Yes;
            txtMaterialName.Size = new Size(250, 48);
            txtMaterialName.TabIndex = 1;
            txtMaterialName.TextAlign = HorizontalAlignment.Right;
            // 
            // txtSalePrice (سعر البيع)
            // 
            txtSalePrice.AnimateReadOnly = false;
            txtSalePrice.Depth = 0;
            txtSalePrice.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSalePrice.Location = new Point(70, 153);
            txtSalePrice.MaxLength = 10;
            txtSalePrice.MouseState = MaterialSkin.MouseState.OUT;
            txtSalePrice.Name = "txtSalePrice";
            txtSalePrice.RightToLeft = RightToLeft.Yes;
            txtSalePrice.Size = new Size(250, 48);
            txtSalePrice.TabIndex = 2;
            txtSalePrice.TextAlign = HorizontalAlignment.Right;
            // 
            // label4 (سعر البيع)
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(345, 168);
            label4.Name = "label4";
            label4.Size = new Size(65, 19);
            label4.TabIndex = 19;
            label4.Text = "سعر البيع";
            // 
            // txtStockQuantity (الكمية)
            // 
            txtStockQuantity.AnimateReadOnly = false;
            txtStockQuantity.Depth = 0;
            txtStockQuantity.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtStockQuantity.Location = new Point(70, 219);
            txtStockQuantity.MaxLength = 10;
            txtStockQuantity.MouseState = MaterialSkin.MouseState.OUT;
            txtStockQuantity.Name = "txtStockQuantity";
            txtStockQuantity.RightToLeft = RightToLeft.Yes;
            txtStockQuantity.Size = new Size(250, 48);
            txtStockQuantity.TabIndex = 3;
            txtStockQuantity.TextAlign = HorizontalAlignment.Right;
            // 
            // label5 (الكمية)
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(345, 233);
            label5.Name = "label5";
            label5.Size = new Size(49, 19);
            label5.TabIndex = 21;
            label5.Text = "الكمية";
            // 
            // chkIsCaffeteria
            // 
            chkIsCaffeteria.AutoSize = true;
            chkIsCaffeteria.Depth = 0;
            chkIsCaffeteria.Location = new Point(135, 298);
            chkIsCaffeteria.Margin = new Padding(0);
            chkIsCaffeteria.MouseLocation = new Point(-1, -1);
            chkIsCaffeteria.MouseState = MaterialSkin.MouseState.HOVER;
            chkIsCaffeteria.Name = "chkIsCaffeteria";
            chkIsCaffeteria.ReadOnly = false;
            chkIsCaffeteria.Ripple = true;
            chkIsCaffeteria.Size = new Size(35, 37);
            chkIsCaffeteria.TabIndex = 5;
            chkIsCaffeteria.UseVisualStyleBackColor = true;
            // 
            // label6 (كافيتيريا)
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.Location = new Point(184, 305);
            label6.Name = "label6";
            label6.Size = new Size(65, 20);
            label6.TabIndex = 23;
            label6.Text = "كافيتيريا؟";
            // 
            // AddMaterialForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(434, 450);
            Controls.Add(label6);
            Controls.Add(chkIsCaffeteria);
            Controls.Add(label5);
            Controls.Add(txtStockQuantity);
            Controls.Add(label4);
            Controls.Add(txtSalePrice);
            Controls.Add(label3);
            Controls.Add(PnlHeader);
            Controls.Add(chkIsAvailable);
            Controls.Add(label2);
            Controls.Add(BtnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtMaterialName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AddMaterialForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "اضافة عنصر";
            Load += AddMaterialForm_Load;
            PnlHeader.ResumeLayout(false);
            PnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Panel PnlHeader;
        private Label label1;
        private MaterialSkin.Controls.MaterialCheckbox chkIsAvailable;
        private Label label2;
        private Button BtnCancel;
        private Button btnSave;
        private MaterialSkin.Controls.MaterialTextBox2 txtMaterialName;
        private MaterialSkin.Controls.MaterialTextBox2 txtSalePrice;
        private Label label4;
        private MaterialSkin.Controls.MaterialTextBox2 txtStockQuantity;
        private Label label5;
        private MaterialSkin.Controls.MaterialCheckbox chkIsCaffeteria;
        private Label label6;
    }
}