using MaterialSkin;

namespace beautyCenterSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            SplashForm splash = new SplashForm();
            splash.Show();
            splash.Refresh();

            System.Threading.Thread.Sleep(2000);

            var manager = MaterialSkinManager.Instance;
            manager.Theme = MaterialSkinManager.Themes.LIGHT;

            splash.Hide();
            Application.Run(new LoginForm());
        }
    }
}