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
            pnlHeader = new System.Windows.Forms.Panel();
            pnlComboBorder = new System.Windows.Forms.Panel();
            cmbCustomers = new beautyCenterSystem.MaterialSearchableCombo();
            lblTitle = new System.Windows.Forms.Label();
            btnAddCustomer = new FontAwesome.Sharp.IconButton();
            pnlFooter = new System.Windows.Forms.Panel();
            pnlSummary = new System.Windows.Forms.TableLayoutPanel();
            lblTotalText = new System.Windows.Forms.Label();
            lblTotalPrice = new System.Windows.Forms.Label();
            btnSave = new System.Windows.Forms.Button();
            dgvCart = new System.Windows.Forms.DataGridView();

            // تعريف الأعمدة المختصرة (بدون IncreaseCol و DecreaseCol)
            IDCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            PriceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            QuantityCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            LineTotalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DeleteCol = new System.Windows.Forms.DataGridViewButtonColumn();

            pnlHeader.SuspendLayout();
            pnlComboBorder.SuspendLayout();
            pnlFooter.SuspendLayout();
            pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();

            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(pnlComboBorder);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnAddCustomer);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(10, 10);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(430, 110);
            pnlHeader.TabIndex = 0;

            // 
            // pnlComboBorder
            // 
            pnlComboBorder.BackColor = System.Drawing.Color.Gainsboro;
            pnlComboBorder.Controls.Add(cmbCustomers);
            pnlComboBorder.Location = new System.Drawing.Point(51, 52);
            pnlComboBorder.Name = "pnlComboBorder";
            pnlComboBorder.Padding = new System.Windows.Forms.Padding(1);
            pnlComboBorder.Size = new System.Drawing.Size(254, 30);
            pnlComboBorder.TabIndex = 0;

            // 
            // cmbCustomers
            // 
            cmbCustomers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmbCustomers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cmbCustomers.BackColor = System.Drawing.Color.White;
            cmbCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            cmbCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbCustomers.Font = new System.Drawing.Font("Segoe UI", 11F);
            cmbCustomers.FormattingEnabled = true;
            cmbCustomers.Location = new System.Drawing.Point(1, 1);
            cmbCustomers.Name = "cmbCustomers";
            cmbCustomers.Size = new System.Drawing.Size(252, 28);
            cmbCustomers.TabIndex = 3;

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(215, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(97, 21);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "بيانات العميلة";

            // 
            // btnAddCustomer
            // 
            btnAddCustomer.BackColor = System.Drawing.Color.Transparent;
            btnAddCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddCustomer.FlatAppearance.BorderSize = 0;
            btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddCustomer.IconChar = FontAwesome.Sharp.IconChar.CirclePlus;
            btnAddCustomer.IconColor = System.Drawing.Color.FromArgb(230, 25, 70);
            btnAddCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddCustomer.IconSize = 35;
            btnAddCustomer.Location = new System.Drawing.Point(5, 48);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new System.Drawing.Size(40, 40);
            btnAddCustomer.TabIndex = 2;
            btnAddCustomer.UseVisualStyleBackColor = false;

            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(pnlSummary);
            pnlFooter.Controls.Add(btnSave);
            pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlFooter.Location = new System.Drawing.Point(10, 490);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new System.Drawing.Size(430, 200);
            pnlFooter.TabIndex = 1;

            // 
            // pnlSummary
            // 
            pnlSummary.ColumnCount = 2;
            pnlSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            pnlSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            pnlSummary.Controls.Add(lblTotalText, 0, 2);
            pnlSummary.Controls.Add(lblTotalPrice, 1, 2);
            pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            pnlSummary.Location = new System.Drawing.Point(0, 0);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.RowCount = 3;
            pnlSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            pnlSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            pnlSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            pnlSummary.Size = new System.Drawing.Size(430, 120);
            pnlSummary.TabIndex = 0;

            // 
            // lblTotalText
            // 
            lblTotalText.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTotalText.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblTotalText.Location = new System.Drawing.Point(218, 70);
            lblTotalText.Name = "lblTotalText";
            lblTotalText.Size = new System.Drawing.Size(209, 50);
            lblTotalText.TabIndex = 3;
            lblTotalText.Text = "الاجمالي";
            lblTotalText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // lblTotalPrice
            // 
            lblTotalPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTotalPrice.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblTotalPrice.ForeColor = System.Drawing.Color.FromArgb(230, 25, 70);
            lblTotalPrice.Location = new System.Drawing.Point(3, 70);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new System.Drawing.Size(209, 50);
            lblTotalPrice.TabIndex = 4;
            lblTotalPrice.Text = "0.00 د.ل";
            lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.Color.FromArgb(230, 25, 70);
            btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.Location = new System.Drawing.Point(0, 140);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(430, 60);
            btnSave.TabIndex = 2;
            btnSave.Text = "تأكيد وحفظ الحجز";
            btnSave.UseVisualStyleBackColor = false;

            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.BackgroundColor = System.Drawing.Color.White;
            dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            // إضافة الأعمدة النظيفة فقط هنا
            dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                IDCol, NameCol, PriceCol, QuantityCol, LineTotalCol, TypeCol, DeleteCol
            });
            dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvCart.Location = new System.Drawing.Point(10, 120);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowTemplate.Height = 40;
            dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            dgvCart.Size = new System.Drawing.Size(430, 370);
            dgvCart.TabIndex = 0;

            // 
            // IDCol
            // 
            IDCol.Name = "IDCol";
            IDCol.Visible = false;

            // 
            // NameCol
            // 
            NameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            NameCol.HeaderText = "الصنف/الخدمة";
            NameCol.Name = "NameCol";
            NameCol.ReadOnly = true;

            // 
            // PriceCol
            // 
            PriceCol.HeaderText = "السعر";
            PriceCol.Name = "PriceCol";
            PriceCol.ReadOnly = true;
            PriceCol.Width = 70;

            // 
            // QuantityCol (العمود الذكي الوحيد)
            // 
            QuantityCol.HeaderText = "الكمية";
            QuantityCol.Name = "QuantityCol";
            QuantityCol.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            QuantityCol.Width = 60;

            // 
            // LineTotalCol
            // 
            LineTotalCol.HeaderText = "الإجمالي";
            LineTotalCol.Name = "LineTotalCol";
            LineTotalCol.ReadOnly = true;
            LineTotalCol.Width = 85;

            // 
            // TypeCol
            // 
            TypeCol.Name = "TypeCol";
            TypeCol.Visible = false;

            // 
            // DeleteCol
            // 
            DeleteCol.HeaderText = "";
            DeleteCol.Name = "DeleteCol";
            DeleteCol.Text = "❌";
            DeleteCol.UseColumnTextForButtonValue = true;
            DeleteCol.Width = 40;

            // 
            // UC_CartSummary
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(dgvCart);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            Name = "UC_CartSummary";
            Padding = new System.Windows.Forms.Padding(10);
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            Size = new System.Drawing.Size(450, 700);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlComboBorder.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            pnlSummary.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblTotalText;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.DataGridView dgvCart;

        // قائمة المتغيرات النهائية النظيفة
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineTotalCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeCol;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteCol;
        private beautyCenterSystem.MaterialSearchableCombo cmbCustomers;
    }
}