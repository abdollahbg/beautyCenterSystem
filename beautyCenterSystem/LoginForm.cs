using System;
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
            // ÊåíÆÉ ÇáÇÊÕÇá ÈŞÇÚÏÉ ÇáÈíÇäÇÊ æÇáÑíÈæ
            var dbFactory = new DbConnectionFactory();
            _userRepository = new UserRepository(dbFactory);

            // ÊØÈíŞ ÇáËíã ÇáÚÇã ááãÑßÒ
            AppTheme.Apply(this);
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // 1. ÇáÊÍŞŞ ãä ÅÏÎÇá ÇáÈíÇäÇÊ
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("ÚĞÑÇğ¡ íÑÌì ÅÏÎÇá ÇÓã ÇáãÓÊÎÏã æßáãÉ ÇáãÑæÑ ÃæáÇğ.",
                                "ÊäÈíå", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // ÊÛííÑ Ôßá ÇáãÇæÓ áíæÍí ÈÇáÇäÊÙÇÑ
                this.Cursor = Cursors.WaitCursor;
                LoginButton.Enabled = false;

                // 2. ãÍÇæáÉ ÊÓÌíá ÇáÏÎæá ÚÈÑ ÇáÑíÈæ (Dapper + BCrypt)
                var user = await _userRepository.LoginAsync(username, password);

                if (user != null)
                {
                    // --- ÇáÎØæÉ ÇáÍÇÓãÉ áÑÈØ ÇáÕáÇÍíÇÊ ---

                    // Ã: ÊÎÒíä ÈíÇäÇÊ ÇáÌáÓÉ (ááÚÑÖ İí ÇáæÇÌåÇÊ)
                    CurrentSession.UserID = user.UserID;
                    CurrentSession.Username = user.Username;
                    CurrentSession.RoleName = user.RoleName;
                    CurrentSession.UserPermissions = user.Permissions;

                    // È: ÊİÚíá äÙÇã ÇáÕáÇÍíÇÊ (ÇáĞí ÊÚÊãÏ Úáíå ÇáÃÒÑÇÑ İí MainDashBoard)
                    // ÈÏæä åĞÇ ÇáÓØÑ¡ ÓíÚÊÈÑ ÇáÜ PermissionManager Ãäß ãÓÊÎÏã ãÌåæá æÊÎÊİí ÇáÃÒÑÇÑ
                    PermissionManager.Initialize(user);

                    // 3. ÇáÇäÊŞÇá ááÔÇÔÉ ÇáÑÆíÓíÉ
                    this.Hide();
                    MainDashBoard main = new MainDashBoard();
                    main.Show();
                }
                else
                {
                    // İÔá ÇáÏÎæá
                    MessageBox.Show("ÇÓã ÇáãÓÊÎÏã Ãæ ßáãÉ ÇáãÑæÑ ÛíÑ ÕÍíÍÉ.",
                                    "İÔá ÇáÏÎæá", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                // ÇáÊÚÇãá ãÚ ÃÎØÇÁ ÇáÓíÑİÑ Ãæ ŞÇÚÏÉ ÇáÈíÇäÇÊ
                MessageBox.Show($"ÍÏË ÎØÃ ÃËäÇÁ ÇáÇÊÕÇá ÈŞÇÚÏÉ ÇáÈíÇäÇÊ: \n{ex.Message}",
                                "ÎØÃ ÊŞäí", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                // ÅÚÇÏÉ ÇáÒÑ æÇáãÇæÓ áÍÇáÊåãÇ ÇáØÈíÚíÉ
                this.Cursor = Cursors.Default;
                LoginButton.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ãí ÅÚÏÇÏÇÊ ÅÖÇİíÉ ÚäÏ İÊÍ ÇáÔÇÔÉ
        }
    }
}