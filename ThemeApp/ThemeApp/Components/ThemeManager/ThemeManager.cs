using ThemeApp.Components.ThemeManager;
using ThemeApp.Components.ThemeManager.Interfaces;
using Xamarin.Forms;

[assembly:Dependency(typeof(ThemeManager))]
namespace ThemeApp.Components.ThemeManager
{
    public class ThemeManager : IThemeManager
    {
        private readonly ThemeColorSettings _colors;
        private readonly ThemeShapeSettings _shapes;

        public ThemeManager()
        {
            _colors = new ThemeColorSettings();
            _shapes = new ThemeShapeSettings();
        }
        
        public ThemeColor GetThemeColor() => _colors.GetPreferences();
        public void SetThemeColor(ThemeColor color) => _colors.SetPreferences(color);

        public ThemeShape GetThemeShape() => _shapes.GetPreferences();
        public void SetThemeShape(ThemeShape shape) => _shapes.SetPreferences(shape);

        public void SetDefault()
        {
            _colors.ResetPreferences();
            _shapes.ResetPreferences();
        }

        public void Load()
        {
            var dictionaries = Application.Current.Resources.MergedDictionaries;
            
            dictionaries.Clear();
            dictionaries.Add(_colors.GetResourceDictionary());
            dictionaries.Add(_shapes.GetResourceDictionary());
        }
    }
}