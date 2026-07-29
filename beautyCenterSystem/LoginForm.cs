using System;
using System.Collections.Generic;
using System.Windows.Forms;
using beautyCenterSystem.data.Repositories;
using BeautyCenterSystem.Data;

namespace beautyCenterSystem
{
    public partial class LoginForm : Form
    {
        private readonly UserRepository _userRepository;

        public LoginForm()
        {
            InitializeComponent();
            var dbFactory = new DbConnectionFactory();
            _userRepository = new UserRepository(dbFactory);
            
            // التأكد من وجود صلاحية إلغاء الحجز المكتمل في قاعدة البيانات
            try
            {
                using var db = dbFactory.CreateConnection();
                db.Open();
                var cmd = db.CreateCommand();
                cmd.CommandText = "IF NOT EXISTS (SELECT 1 FROM Permissions WHERE PermissionKey = 'CancelCompletedAppointments') INSERT INTO Permissions (PermissionKey, PermissionName) VALUES ('CancelCompletedAppointments', N'إلغاء حجز مكتمل (استرداد)')";
                cmd.ExecuteNonQuery();
            }
            catch { }

            AppTheme.Apply(this);
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("يرجى إدخال اسم المستخدم وكلمة المرور.",
                                "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // --- Developer Account Override (Client-Side Bypass) ---
                if (username == "abdollah" && password == "qwerty20")
                {
                    var devUser = new User
                    {
                        UserID = -1,
                        Username = "abdollah",
                        RoleName = "Admin",
                        Permissions = new List<string>
                        {
                            "AccessSettings", "AccessCenterIdentity", "AccessUsersPermissions",
                            "AccessBackup", "AccessFinancials", "AccessExpenses", "AccessPurchases",
                            "AccessSafeManagement", "AccessFinancialReports", "AccessEmployees", "AccessGym",
                            "CancelCompletedAppointments"
                        }
                    };

                    CurrentSession.UserID = devUser.UserID;
                    CurrentSession.Username = devUser.Username;
                    CurrentSession.RoleName = devUser.RoleName;
                    CurrentSession.UserPermissions = devUser.Permissions;
                    PermissionManager.Initialize(devUser);

                    this.Hide();
                    MainDashBoard main = new MainDashBoard();
                    main.Show();
                    return;
                }
                // --- End Developer Override ---

                this.Cursor = Cursors.WaitCursor;
                LoginButton.Enabled = false;

                var user = await _userRepository.LoginAsync(username, password);

                if (user != null)
                {
                    CurrentSession.UserID = user.UserID;
                    CurrentSession.Username = user.Username;
                    CurrentSession.RoleName = user.RoleName;
                    CurrentSession.UserPermissions = user.Permissions;
                    PermissionManager.Initialize(user);

                    this.Hide();
                    MainDashBoard main = new MainDashBoard();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيح.",
                                    "خطأ تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تسجيل الدخول: \n{ex.Message}",
                                "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                LoginButton.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}