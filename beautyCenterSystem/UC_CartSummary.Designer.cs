namespace beautyCenterSystem
{
    partial class UC_CartSummary
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            pnlComboBorder = new Panel();
            cmbCustomers = new MaterialSearchableCombo();
            lblTitle = new Label();
            btnAddCustomer = new FontAwesome.Sharp.IconButton();
            pnlFooter = new Panel();
            pnlSummary = new TableLayoutPanel();
            lblSubTotalText = new Label();
            lblSubTotalValue = new Label();
            lblDiscountText = new Label();
            cmbDiscountPercent = new ComboBox();
            lblTotalText = new Label();
            lblTotalPrice = new Label();
            btnSave = new Button();
            dgvCart = new DataGridView();
            IDCol = new DataGridViewTextBoxColumn();
            NameCol = new DataGridViewTextBoxColumn();
            PriceCol = new DataGridViewTextBoxColumn();
            DeleteCol = new DataGridViewButtonColumn();

            pnlHeader.SuspendLayout();
            pnlComboBorder.SuspendLayout();
            pnlFooter.SuspendLayout();
            pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();

            // pnlHeader
            pnlHeader.Controls.Add(pnlComboBorder);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnAddCustomer);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(10, 10);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(330, 110);
            pnlHeader.TabIndex = 0;

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(215, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(106, 21);
            lblTitle.Text = "بيانات العميلة";

            // pnlComboBorder
            pnlComboBorder.BackColor = Color.Gainsboro;
            pnlComboBorder.Controls.Add(cmbCustomers);
            pnlComboBorder.Location = new Point(51, 52);
            pnlComboBorder.Name = "pnlComboBorder";
            pnlComboBorder.Padding = new Padding(1);
            pnlComboBorder.Size = new Size(254, 30);

            // cmbCustomers
            cmbCustomers.Dock = DockStyle.Fill;
            cmbCustomers.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCustomers.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCustomers.BackColor = Color.White;
            cmbCustomers.FlatStyle = FlatStyle.Flat;
            cmbCustomers.Font = new Font("Segoe UI", 11F);
            cmbCustomers.FormattingEnabled = true;
            cmbCustomers.Location = new Point(1, 1);
            cmbCustomers.Name = "cmbCustomers";
            cmbCustomers.Size = new Size(252, 28);
            cmbCustomers.TabIndex = 3;

            // btnAddCustomer
            btnAddCustomer.BackColor = Color.Transparent;
            btnAddCustomer.Cursor = Cursors.Hand;
            btnAddCustomer.FlatAppearance.BorderSize = 0;
            btnAddCustomer.FlatStyle = FlatStyle.Flat;
            btnAddCustomer.IconChar = FontAwesome.Sharp.IconChar.CirclePlus;
            btnAddCustomer.IconColor = Color.FromArgb(230, 25, 70);
            btnAddCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddCustomer.IconSize = 35;
            btnAddCustomer.Location = new Point(5, 48);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(40, 40);
            btnAddCustomer.TabIndex = 2;

            // pnlFooter
            pnlFooter.Controls.Add(pnlSummary);
            pnlFooter.Controls.Add(btnSave);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(10, 490);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(330, 200);
            pnlFooter.TabIndex = 1;

            // pnlSummary
            pnlSummary.ColumnCount = 2;
            pnlSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlSummary.Controls.Add(lblSubTotalText, 0, 0);
            pnlSummary.Controls.Add(lblSubTotalValue, 1, 0);
            pnlSummary.Controls.Add(lblDiscountText, 0, 1);
            pnlSummary.Controls.Add(cmbDiscountPercent, 1, 1);
            pnlSummary.Controls.Add(lblTotalText, 0, 2);
            pnlSummary.Controls.Add(lblTotalPrice, 1, 2);
            pnlSummary.Dock = DockStyle.Top;
            pnlSummary.Location = new Point(0, 0);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.RowCount = 3;
            pnlSummary.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            pnlSummary.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            pnlSummary.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            pnlSummary.Size = new Size(330, 120);

            // lblSubTotalText
            lblSubTotalText.Text = "الإجمالي قبل الخصم:";
            lblSubTotalText.TextAlign = ContentAlignment.MiddleLeft;
            lblSubTotalText.Dock = DockStyle.Fill;

            // lblSubTotalValue
            lblSubTotalValue.Text = "0.00 د.ل";
            lblSubTotalValue.TextAlign = ContentAlignment.MiddleRight;
            lblSubTotalValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSubTotalValue.Dock = DockStyle.Fill;

            // lblDiscountText
            lblDiscountText.Text = "نسبة الخصم:";
            lblDiscountText.TextAlign = ContentAlignment.MiddleLeft;
            lblDiscountText.Dock = DockStyle.Fill;

            // cmbDiscountPercent
            cmbDiscountPercent.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDiscountPercent.Items.AddRange(new object[] { "0%", "5%", "10%", "15%", "20%", "25%", "50%" });
            cmbDiscountPercent.Location = new Point(3, 38);
            cmbDiscountPercent.Name = "cmbDiscountPercent";
            cmbDiscountPercent.Size = new Size(100, 23);
            cmbDiscountPercent.TabIndex = 1;

            // lblTotalText
            lblTotalText.Text = "الصافي النهائي:";
            lblTotalText.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalText.TextAlign = ContentAlignment.MiddleLeft;
            lblTotalText.Dock = DockStyle.Fill;

            // lblTotalPrice
            lblTotalPrice.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalPrice.ForeColor = Color.FromArgb(230, 25, 70);
            lblTotalPrice.Text = "0.00 د.ل";
            lblTotalPrice.TextAlign = ContentAlignment.MiddleRight;
            lblTotalPrice.Dock = DockStyle.Fill;

            // btnSave
            btnSave.BackColor = Color.FromArgb(230, 25, 70);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(0, 140);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(330, 60);
            btnSave.TabIndex = 2;
            btnSave.Text = "تأكيد وحفظ الحجز";

            // dgvCart
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.BorderStyle = BorderStyle.None;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Columns.AddRange(new DataGridViewColumn[] { IDCol, NameCol, PriceCol, DeleteCol });
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.Location = new Point(10, 120);
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowTemplate.Height = 35;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(330, 370);

            // --- إعدادات الأعمدة (هنا يكمن الحل) ---

            // IDCol
            IDCol.Name = "IDCol"; // إعطاء اسم برمجي للعمود
            IDCol.Visible = false;

            // NameCol
            NameCol.Name = "NameCol";
            NameCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NameCol.HeaderText = "الخدمة";

            // PriceCol
            PriceCol.Name = "PriceCol";
            PriceCol.HeaderText = "السعر";
            PriceCol.Width = 80;

            // DeleteCol
            DeleteCol.Name = "DeleteCol"; // إعطاء اسم برمجي لزر الحذف ليتعرف عليه الـ Logic
            DeleteCol.HeaderText = "";
            DeleteCol.Text = "❌";
            DeleteCol.UseColumnTextForButtonValue = true;
            DeleteCol.Width = 40;

            // UC_CartSummary
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvCart);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            Name = "UC_CartSummary";
            Padding = new Padding(10);
            RightToLeft = RightToLeft.Yes;
            Size = new Size(350, 700);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlComboBorder.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlComboBorder;
        private System.Windows.Forms.Label lblTitle;
        private FontAwesome.Sharp.IconButton btnAddCustomer;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.TableLayoutPanel pnlSummary;
        private System.Windows.Forms.Label lblSubTotalText;
        private System.Windows.Forms.Label lblSubTotalValue;
        private System.Windows.Forms.Label lblDiscountText;
        private System.Windows.Forms.ComboBox cmbDiscountPercent;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblTotalText;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceCol;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteCol;
        private MaterialSearchableCombo cmbCustomers;
    }
}