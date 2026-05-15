using beautyCenterSystem.data.Repositories;
using BeautyCenterSystem.Data;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beautyCenterSystem
{
    public partial class MainDashBoard : Form
    {
        private readonly BackupRepository _backupRepo;

        public MainDashBoard()
        {
            InitializeComponent();
            // تطبيق المظهر العام (Colors & Fonts)
            AppTheme.Apply(this);
            // تهيئة مستودع النسخ الاحتياطي
            _backupRepo = new BackupRepository(new DbConnectionFactory());
        }

        private void MainDashBoard_Load(object sender, EventArgs e)
        {
            // القفل والمفتاح: تطبيق الصلاحيات فور تحميل الواجهة
            ApplyPermissions();

            // افتراضياً: يمكن فتح شاشة المواعيد كشاشة رئيسية
            btnAppointments.PerformClick();
            lblUserName.Text = $"المستخدم: {CurrentSession.Username}";
        }

        /// <summary>
        /// فحص صلاحيات المستخدم وإخفاء/إظهار العناصر بناءً على السكربت المعتمد
        /// </summary>
        private void ApplyPermissions()
        {
            // 1. زر الإعدادات (يظهر إذا كان للمستخدم أي صلاحية تقنية أو إدارية)
            btnSettings.Visible = PermissionManager.Can("AccessSettings") ||
                                 PermissionManager.Can("AccessCenterIdentity") ||
                                 PermissionManager.Can("AccessUsersPermissions") ||
                                 PermissionManager.Can("AccessBackup");

            // 2. زر المالية (Invoices)
            // يظهر إذا كان يملك صلاحية الوصول المالي أو التقارير المالية
            btnInvoices.Visible = PermissionManager.Can("AccessFinancials") ||
                                  PermissionManager.Can("AccessFinancialReports");


            // 4. زر المواد والمخزون
            btnMaterials.Visible = PermissionManager.Can("AccessPurchases");

            btnEmployees.Visible = PermissionManager.Can("AccessEmployees");


            // ملحوظة: أزرار العميلات والمواعيد والخدمات تترك مرئية للموظفين (Staff) عادةً
            btnCustomers.Visible = true;
            btnAppointments.Visible = true;
            btnServices.Visible = true;
            btnRooms.Visible = true;
        }

        #region Navigation Logic (التنقل بين الشاشات)

        private async Task<bool> ShowScreen(UserControl screen)
        {
            // التحقق من وجود تعديلات غير محفوظة في صفحة الإعدادات قبل الانتقال
            if (pnlContainer.Controls.Count > 0 && pnlContainer.Controls[0] is UC_Settings oldSettings)
            {
                bool canNavigate = await oldSettings.PromptUnsavedChanges();
                if (!canNavigate) return false;
            }

            // تنظيف الحاوية وعرض الشاشة الجديدة
            if (pnlContainer.Controls.Count > 0)
            {
                pnlContainer.Controls[0].Dispose();
                pnlContainer.Controls.Clear();
            }

            screen.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(screen);
            AppTheme.Apply(screen);

            return true;
        }

        private void HighlightButton(object btnSender)
        {
            if (btnSender != null && btnSender is IconButton activeBtn)
            {
                // إعادة الألوان الافتراضية لكافة الأزرار في القائمة الجانبية
                foreach (Control ctrl in pnlSidebar.Controls)
                {
                    if (ctrl is IconButton btn)
                    {
                        btn.BackColor = Color.White;
                        btn.ForeColor = AppTheme.Charcoal;
                        btn.IconColor = AppTheme.Charcoal;
                    }
                }

                // تمييز الزر النشط باللون المخصص في الثيم (RoseGold)
                activeBtn.BackColor = AppTheme.RoseGold;
                activeBtn.ForeColor = AppTheme.Primary;
                activeBtn.IconColor = AppTheme.Primary;
            }
        }

        #endregion

        #region Button Click Events

        private async void btnHome_Click(object sender, EventArgs e)
        {
            if (await ShowScreen(new UC_Home()))
                HighlightButton(sender);
        }

        private async void btnAppointments_Click(object sender, EventArgs e)
        {
            if (await ShowScreen(new UC_Appointments()))
                HighlightButton(sender);
        }

        private async void btnCustomers_Click(object sender, EventArgs e)
        {
            if (await ShowScreen(new UC_Customers()))
                HighlightButton(sender);
        }

        private async void btnServices_Click(object sender, EventArgs e)
        {
            if (await ShowScreen(new UC_Services()))
                HighlightButton(sender);
        }

        private async void btnRooms_Click(object sender, EventArgs e)
        {
            if (await ShowScreen(new UC_rooms()))
                HighlightButton(sender);
        }

        private async void btnMaterials_Click(object sender, EventArgs e)
        {
            if (PermissionManager.Can("AccessPurchases"))
            {
                if (await ShowScreen(new UC_Materials()))
                    HighlightButton(sender);
            }
        }

        private async void btnInvoices_Click(object sender, EventArgs e)
        {
            if (PermissionManager.Can("AccessFinancials") || PermissionManager.Can("AccessFinancialReports"))
            {
                if (await ShowScreen(new UC_FinancialMain()))
                    HighlightButton(sender);
            }
            else
            {
                MessageBox.Show("عذراً، لا تملك صلاحية الوصول للقسم المالي.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private async void btnSettings_Click(object sender, EventArgs e)
        {
            if (await ShowScreen(new UC_Settings()))
                HighlightButton(sender);
        }

        #endregion

        #region Form Closing & Backup Logic

        private async void MainDashBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            var settings = Properties.Settings.Default;

            // حالة 1: النسخ التلقائي مفعّل
            if (settings.EnableAutoBackup && !string.IsNullOrEmpty(settings.AutoBackupPath))
            {
                e.Cancel = true; // إيقاف الإغلاق مؤقتاً لتنفيذ النسخ

                using (Form loading = CreateLoadingForm())
                {
                    AppTheme.Apply(loading);
                    loading.Show();
                    loading.Refresh();

                    try
                    {
                        await Task.Run(async () =>
                        {
                            await _backupRepo.CreateBackupAsync(settings.AutoBackupPath);
                            await Task.Delay(1000);
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"فشل النسخ الاحتياطي التلقائي: {ex.Message}", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    finally
                    {
                        loading.Close();
                    }
                }

                // فك الحدث وإغلاق التطبيق نهائياً بعد انتهاء النسخ
                this.FormClosing -= MainDashBoard_FormClosing;
                Application.Exit();
            }
            else
            {
                // حالة 2: النسخ التلقائي غير مفعّل - أغلق البرنامج فوراً
                Application.Exit();
            }
        }

        private Form CreateLoadingForm()
        {
            Form loadingForm = new Form
            {
                Width = 400,
                Height = 120,
                Text = "تأمين البيانات",
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ControlBox = false,
                RightToLeft = RightToLeft.Yes,
                RightToLeftLayout = true
            };

            Label lblMessage = new Label
            {
                Text = "جاري إنشاء نسخة احتياطية من البيانات، يرجى الانتظار...",
                AutoSize = true,
                Location = new Point(20, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            ProgressBar pb = new ProgressBar
            {
                Location = new Point(20, 55),
                Width = 345,
                Height = 20,
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 30
            };

            loadingForm.Controls.Add(lblMessage);
            loadingForm.Controls.Add(pb);
            return loadingForm;
        }

        private void MainDashBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #endregion

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // 1. تأكيد رغبة المستخدم في تسجيل الخروج
            var result = MessageBox.Show("هل أنت متأكد من رغبتك في تسجيل الخروج؟", "تأكيد",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 2. تصفير بيانات الجلسة الحالية باستخدام الدالة التي برمجتها أنت
                CurrentSession.Logout();

                // 3. فتح شاشة تسجيل الدخول من جديد
                LoginForm login = new LoginForm();
                login.Show();

                // 4. إغلاق الشاشة الرئيسية الحالية (MainForm)
                // ملاحظة: إذا كانت هذه هي الشاشة الرئيسية، استخدم this.Hide() 
                // لضمان عدم إغلاق التطبيق بالكامل إذا كان الـ Main هو الـ Entry point
                this.Hide();

                // أو إذا أردت إغلاقها تماماً وكان لديك Logic آخر في Program.cs استخدم:
                // this.Close();
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            // معلومات الهوية والإصدار
            string systemName = "نظام الصنوان لإدارة مراكز التجميل";
            string version = "الإصدار: 1.0.0 (نسخة مستقرة)";
            string company = "الجهة: شركة الصنوان للحلول التقنية";
            string developer = "المطور: عبدالله بن غربية";

            // معلومات التواصل والدعم الفني
            string supportHeader = "--- قسم الدعم الفني وتطوير النظام ---";
            string contact1 = "واتساب (عبدالله بن غربية): 0915725507";
            string contact2 = "واتساب (مجدي شكاب): 0911860781";

            // تجميع الرسالة بالكامل وتنسيقها
            string fullMessage = $"{systemName}\n" +
                                 $"{version}\n" +
                                 $"{new string('-', 45)}\n" +
                                 $"{company}\n" +
                                 $"{developer}\n\n" +
                                 $"{supportHeader}\n" +
                                 $"{contact1}\n" +
                                 $"{contact2}\n" +
                                 $"{new string('-', 45)}\n" +
                                 $"جميع الحقوق محفوظة © 2024 - 2026";

            // عرض الرسالة في MessageBox مع أيقونة المعلومات
            MessageBox.Show(fullMessage, "حول نظام الصنوان", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnEmployees_Click(object sender, EventArgs e)
        {
            if (await ShowScreen(new UC_Employees()))
                HighlightButton(sender);
        }

        private async void btnGym_Click(object sender, EventArgs e)
        {
            if (await ShowScreen(new UC_GymManagement()))
                HighlightButton(sender);
        }
    }
}