using beautyCenterSystem.data.Repositories;
using BeautyCenterSystem.Data;
using MaterialSkin.Controls; 
using FontAwesome.Sharp;
using beautyCenterSystem.D;
namespace beautyCenterSystem;
    using beautyCenterSystem.data.Repositories;
    using BeautyCenterSystem.Data;

    public partial class LoginForm : Form
    {
    private readonly beautyCenterSystem.data.Repositories.UserRepository _userRepository;
    public LoginForm()
        {
            InitializeComponent();
        var dbFactory = new BeautyCenterSystem.Data.DbConnectionFactory();
        _userRepository = new beautyCenterSystem.data.Repositories.UserRepository(dbFactory);
        AppTheme.Apply(this);
        
        


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private  async void LoginButton_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if(string.IsNullOrEmpty(username)||string.IsNullOrEmpty(password))
            {
                MessageBox.Show("⁄–—«° Ì—ÃÏ ≈œŒ«· «”„ «·„” Œœ„ Êﬂ·„… «·„—Ê— √Ê·«.",
                        " ‰»ÌÂ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
      
            try
              {
            this.Cursor = Cursors.WaitCursor;
            LoginButton.Enabled = false;
            var user = await _userRepository.LoginAsync(username, password);

            if(user != null )
            {
                  CurrentSession.UserID = user.UserID;
                CurrentSession.Username = user.Username;
                  CurrentSession.RoleName = user.RoleName;
                this.Hide();
                new MainDashBoard().Show();

            }
            else
            {
                MessageBox.Show("«”„ «·„” Œœ„ √Ê ﬂ·„… «·„—Ê— €Ì— ’ÕÌÕ…° .",
                                "›‘· «·œŒÊ·", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"ÕœÀ Œÿ√ √À‰«¡ «·« ’«· »ﬁ«⁄œ… «·»Ì«‰« : \n{ex.Message}",
                            "Œÿ√  ﬁ‰Ì", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        finally
        {
            // ≈⁄«œ… «·„«Ê” Ê«·“— ·Õ«· Â„« «·ÿ»Ì⁄Ì…
            this.Cursor = Cursors.Default;
            LoginButton.Enabled = true;
        }

    }
        



        }
    



