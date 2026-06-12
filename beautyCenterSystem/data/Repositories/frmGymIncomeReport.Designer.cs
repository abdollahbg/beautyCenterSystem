using System.Drawing;
using System.Windows.Forms;

namespace beautyCenterSystem.data.Repositories
{
    partial class frmGymIncomeReport
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
            pnlHeader = new Panel();
            lblFormTitle = new Label();
            pnlDateFilter = new Panel();
            btnFilter = new Button();
            lblFrom = new Label();
            dtpFrom = new DateTimePicker();
            lblTo = new Label();
            dtpTo = new DateTimePicker();
            pnlTotalCard = new Panel();
            lblTotalIncomeTitle = new Label();
            lblTotalIncomeValue = new Label();
            pnlHeader.SuspendLayout();
            pnlDateFilter.SuspendLayout();
            pnlTotalCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblFormTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 2, 3, 2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(744, 49);
            pnlHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            lblFormTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Location = new Point(306, 9);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(170, 32);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Tag = "Header";
            lblFormTitle.Text = " ﬁ—Ì— œŒ· «·ÃÌ„";
            // 
            // pnlDateFilter
            // 
            pnlDateFilter.Controls.Add(btnFilter);
            pnlDateFilter.Controls.Add(lblFrom);
            pnlDateFilter.Controls.Add(dtpFrom);
            pnlDateFilter.Controls.Add(lblTo);
            pnlDateFilter.Controls.Add(dtpTo);
            pnlDateFilter.Dock = DockStyle.Top;
            pnlDateFilter.Location = new Point(0, 49);
            pnlDateFilter.Margin = new Padding(3, 2, 3, 2);
            pnlDateFilter.Name = "pnlDateFilter";
            pnlDateFilter.Padding = new Padding(9, 8, 9, 8);
            pnlDateFilter.Size = new Size(744, 45);
            pnlDateFilter.TabIndex = 1;
            // 
            // btnFilter
            // 
            btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilter.Location = new Point(201, 9);
            btnFilter.Margin = new Padding(3, 2, 3, 2);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(88, 27);
            btnFilter.TabIndex = 4;
            btnFilter.Text = "⁄—÷ «· ﬁ—Ì—";
            btnFilter.UseVisualStyleBackColor = true;
            // 
            // lblFrom
            // 
            lblFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(665, 15);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(22, 15);
            lblFrom.TabIndex = 0;
            lblFrom.Text = "„‰";
            // 
            // dtpFrom
            // 
            dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(508, 13);
            dtpFrom.Margin = new Padding(3, 2, 3, 2);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(149, 23);
            dtpFrom.TabIndex = 1;
            // 
            // lblTo
            // 
            lblTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTo.AutoSize = true;
            lblTo.Location = new Point(464, 15);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(24, 15);
            lblTo.TabIndex = 2;
            lblTo.Text = "≈·Ï";
            // 
            // dtpTo
            // 
            dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(306, 13);
            dtpTo.Margin = new Padding(3, 2, 3, 2);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(149, 23);
            dtpTo.TabIndex = 3;
            // 
            // pnlTotalCard
            // 
            pnlTotalCard.BackColor = Color.White;
            pnlTotalCard.Controls.Add(lblTotalIncomeTitle);
            pnlTotalCard.Controls.Add(lblTotalIncomeValue);
            pnlTotalCard.Dock = DockStyle.Fill;
            pnlTotalCard.Location = new Point(0, 94);
            pnlTotalCard.Margin = new Padding(3, 2, 3, 2);
            pnlTotalCard.Name = "pnlTotalCard";
            pnlTotalCard.Padding = new Padding(18, 8, 18, 8);
            pnlTotalCard.Size = new Size(744, 185);
            pnlTotalCard.TabIndex = 2;
            // 
            // lblTotalIncomeTitle
            // 
            lblTotalIncomeTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalIncomeTitle.AutoSize = true;
            lblTotalIncomeTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalIncomeTitle.Location = new Point(344, 78);
            lblTotalIncomeTitle.Name = "lblTotalIncomeTitle";
            lblTotalIncomeTitle.Size = new Size(122, 21);
            lblTotalIncomeTitle.TabIndex = 0;
            lblTotalIncomeTitle.Tag = "Header";
            lblTotalIncomeTitle.Text = "≈Ã„«·Ì œŒ· «·ÃÌ„";
            // 
            // lblTotalIncomeValue
            // 
            lblTotalIncomeValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalIncomeValue.AutoSize = true;
            lblTotalIncomeValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalIncomeValue.ForeColor = Color.FromArgb(39, 174, 96);
            lblTotalIncomeValue.Location = new Point(390, 99);
            lblTotalIncomeValue.Name = "lblTotalIncomeValue";
            lblTotalIncomeValue.Size = new Size(35, 41);
            lblTotalIncomeValue.TabIndex = 1;
            lblTotalIncomeValue.Text = "0";
            // 
            // frmGymIncomeReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 279);
            Controls.Add(pnlTotalCard);
            Controls.Add(pnlDateFilter);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "frmGymIncomeReport";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = " ﬁ—Ì— œŒ· «·ÃÌ„";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlDateFilter.ResumeLayout(false);
            pnlDateFilter.PerformLayout();
            pnlTotalCard.ResumeLayout(false);
            pnlTotalCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlDateFilter;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Panel pnlTotalCard;
        private System.Windows.Forms.Label lblTotalIncomeTitle;
        private System.Windows.Forms.Label lblTotalIncomeValue;
    }
}
