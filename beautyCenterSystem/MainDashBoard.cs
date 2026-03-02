using beautyCenterSystem.data.Repositories;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beautyCenterSystem
{
    public partial class MainDashBoard : Form
    {
        public MainDashBoard()
        {
            InitializeComponent();
            AppTheme.Apply(this);
        }
        private void HighlightButton(object btnSender)
        {
            if (btnSender != null)
            {
                // 1. إعادة كل الأزرار داخل السايد بار لشكلها الطبيعي (غير النشط)
                foreach (Control ctrl in pnlSidebar.Controls)
                {
                    if (ctrl is IconButton btn)
                    {
                        btn.BackColor = Color.White; // خلفية شفافة
                        btn.ForeColor = AppTheme.Charcoal; // لون النص العادي
                        btn.IconColor = AppTheme.Charcoal; // لون الأيقونة العادي
                    }
                }

                // 2. تمييز الزر الذي تم الضغط عليه حالياً
                IconButton activeBtn = (IconButton)btnSender;
                activeBtn.BackColor = AppTheme.RoseGold; // خلفية وردية ناعمة (التي عرفناها في الثيم)
                activeBtn.ForeColor = AppTheme.Primary;  // لون النص أحمر ياقوتي
                activeBtn.IconColor = AppTheme.Primary;  // لون الأيقونة أحمر ياقوتي
            }
        }
        private void ShowScreen(UserControl screen)
        {

            if (pnlContainer.Controls.Count > 0)
            {
                pnlContainer.Controls[0].Dispose();
                pnlContainer.Controls.Clear();
            }


            screen.Dock = DockStyle.Fill;


            pnlContainer.Controls.Add(screen);


            AppTheme.Apply(screen);
        }
        private void MainDashBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }



        private void MainDashBoard_Load(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            HighlightButton(sender);

        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            ShowScreen(new UC_Appointments());
            HighlightButton(sender);
           
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            ShowScreen(new UC_Customers());
            HighlightButton(sender);
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            ShowScreen(new UC_Services());
            HighlightButton(sender);
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            ShowScreen(new UC_rooms());

            HighlightButton(sender);
        }

        private void btnMaterials_Click(object sender, EventArgs e)
        {
            HighlightButton(sender);
           
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            HighlightButton(sender);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            HighlightButton(sender);
        }
    }
}
