using System;
using ThemeApp.Pages.Themes;
using Xamarin.Forms.Xaml;

namespace ThemeApp.Pages.Welcome
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void OnGoToSettingsButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ThemesPage());
        }
    }
}