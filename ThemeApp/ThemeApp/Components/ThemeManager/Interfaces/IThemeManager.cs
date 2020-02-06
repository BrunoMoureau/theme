using Xamarin.Forms;

namespace ThemeApp.Components.ThemeManager.Interfaces
{
    public interface IThemeManager
    {
        ThemeColor GetThemeColor();
        void SetThemeColor(ThemeColor color);

        ThemeShape GetThemeShape();
        void SetThemeShape(ThemeShape shape);

        void SetDefault();

        void Load();
    }
}
