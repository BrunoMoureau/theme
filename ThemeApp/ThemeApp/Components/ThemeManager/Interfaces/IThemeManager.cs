using Xamarin.Forms;

namespace ThemeApp.Components.ThemeManager.Interfaces
{
    public interface IThemeManager
    {
        ResourceDictionary Colors { get; set; }
        ResourceDictionary Shapes { get; set; }

        void Load();
    }
}
