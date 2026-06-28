using System;
using System.Drawing;
using System.Windows.Forms;

namespace beautyCenterSystem
{
    public partial class UC_GymManagement
    {
        private void FixLayout()
        {
            // Create a panel for the bottom buttons in tabActive
            Panel pnlActiveBottom = new Panel();
            pnlActiveBottom.Dock = DockStyle.Bottom;
            pnlActiveBottom.Height = 60;
            pnlActiveBottom.Padding = new Padding(10);
            
            // Move buttons to the panel
            this.tabActive.Controls.Add(pnlActiveBottom);
            
            this.btnNewSubscription.Dock = DockStyle.Right;
            this.btnNewSubscription.Width = 150;
            
            this.btnCheckIn.Dock = DockStyle.Right;
            this.btnCheckIn.Width = 150;

            this.btnCancelSubscription.Dock = DockStyle.Right;
            this.btnCancelSubscription.Width = 150;
            
            this.btnPrintReceipt.Dock = DockStyle.Left;
            this.btnPrintReceipt.Width = 150;

            pnlActiveBottom.Controls.Add(this.btnNewSubscription);
            pnlActiveBottom.Controls.Add(this.btnCheckIn);
            pnlActiveBottom.Controls.Add(this.btnCancelSubscription);
            pnlActiveBottom.Controls.Add(this.btnPrintReceipt);
            
            // Ensure DataGridView fills the rest
            this.dgvActive.Dock = DockStyle.Fill;
            this.dgvActive.BringToFront();
        }
    }
}
