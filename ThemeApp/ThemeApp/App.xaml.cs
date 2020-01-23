using ThemeApp.Components.ThemeManager.Interfaces;
using ThemeApp.Pages.Welcome;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ThemeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var test = AppInfo.RequestedTheme;
            DependencyService.Get<IThemeManager>().Load();
            
            MainPage = new NavigationPage(new WelcomePage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
