using System;
using System.Windows.Forms;
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

            // 1. تهيئة الماتيريال سكين أولاً قبل بناء أي واجهة لضمان تحميل خط Roboto_Medium في الذاكرة
            var manager = MaterialSkinManager.Instance;
            manager.Theme = MaterialSkinManager.Themes.LIGHT;

            // 2. الآن نقوم بإنشاء وعرض شاشة البداية بأمان تام
            SplashForm splash = new SplashForm();
            splash.Show();
            splash.Refresh();

            // 3. تأخير زمني لتهيئة النظام وعرض الـ Splash
            System.Threading.Thread.Sleep(2000);

            // 4. إخفاء شاشة البداية وتفريغها من الذاكرة، ثم فتح شاشة تسجيل الدخول
            splash.Hide();
            splash.Dispose(); 
            
            Application.Run(new LoginForm());
        }
    }
}