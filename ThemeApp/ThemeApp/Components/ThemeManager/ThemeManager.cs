using System.Linq;
using ThemeApp.Components.ThemeManager;
using ThemeApp.Components.ThemeManager.Interfaces;
using ThemeApp.Themes.Colors;
using ThemeApp.Themes.Shapes;
using Xamarin.Forms;

[assembly:Dependency(typeof(ThemeManager))]
namespace ThemeApp.Components.ThemeManager
{
    /// <summary>
    /// Switch between application themes
    /// </summary>
    public class ThemeManager : IThemeManager
    {
        public ResourceDictionary Colors { get; set; }
        public ResourceDictionary Shapes { get; set; }

        public ThemeManager()
        {
            //todo check if device use light or dark mode
            // Theses dictionaries are the default ones.
            // You could provide the theme selected by the user during the last session.
            Colors = new LightColor();
            Shapes = new SquaredShape();
        }

        /// <summary>
        /// Load the theme using provided dictionaries
        /// </summary>
        public void Load()
        {
            var dictionaries = Application.Current.Resources.MergedDictionaries;

            dictionaries.Clear();
            dictionaries.Add(Colors);
            dictionaries.Add(Shapes);
        }
    }
}