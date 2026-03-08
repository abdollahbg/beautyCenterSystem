using BeautyCenterSystem.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beautyCenterSystem.data.Repositories
{
    public partial class UC_FinancialMain : UserControl
    {
        public UC_FinancialMain()
        {
            InitializeComponent();

        }

        private void btnManageSafes_Click(object sender, EventArgs e)
        {

        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            using (frmExpenses frm = new frmExpenses())
            {

                frm.ShowDialog();
            }
        }

        private void UC_FinancialMain_Load(object sender, EventArgs e)
        {
            AppTheme.Apply(this);
            this.BeginInvoke((MethodInvoker)delegate
            {
                btnExpenses.ForeColor = AppTheme.Charcoal;
                btnExpenses.FlatStyle = FlatStyle.Flat;
                btnExpenses.FlatAppearance.BorderSize = 1;
                btnExpenses.FlatAppearance.BorderColor = AppTheme.Charcoal;
                btnExpenses.BackColor = Color.White;
                btnExpenses.TextAlign = ContentAlignment.MiddleCenter;
            });
            this.BeginInvoke((MethodInvoker)delegate
            {
                btnFinReports.ForeColor = AppTheme.Charcoal;
                btnFinReports.FlatStyle = FlatStyle.Flat;
                btnFinReports.FlatAppearance.BorderSize = 1;
                btnFinReports.FlatAppearance.BorderColor = AppTheme.Charcoal;
                btnFinReports.BackColor = Color.White;
                btnFinReports.TextAlign = ContentAlignment.MiddleCenter;
            });
            this.BeginInvoke((MethodInvoker)delegate
            {
                btnManageSafes.ForeColor = AppTheme.Charcoal;
                btnManageSafes.FlatStyle = FlatStyle.Flat;
                btnManageSafes.FlatAppearance.BorderSize = 1;
                btnManageSafes.FlatAppearance.BorderColor = AppTheme.Charcoal;
                btnManageSafes.BackColor = Color.White;
                btnManageSafes.TextAlign = ContentAlignment.MiddleCenter;
            });
            this.BeginInvoke((MethodInvoker)delegate
            {
                btnPurchases.ForeColor = AppTheme.Charcoal;
                btnPurchases.FlatStyle = FlatStyle.Flat;
                btnPurchases.FlatAppearance.BorderSize = 1;
                btnPurchases.FlatAppearance.BorderColor = AppTheme.Charcoal;
                btnPurchases.BackColor = Color.White;
                btnPurchases.TextAlign = ContentAlignment.MiddleCenter;
            });

        }

        private void btnManageSafes_Click_1(object sender, EventArgs e)
        {
            using (frmSafes frm = new frmSafes())
            {
                
                frm.ShowDialog();
            }


        }
    }
}
