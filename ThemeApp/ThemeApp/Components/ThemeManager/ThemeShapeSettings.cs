using System;
using ThemeApp.Themes.Shapes;
using Xamarin.Forms;

namespace ThemeApp.Components.ThemeManager
{
    public enum ThemeShape
    {
        Squared,
        Rounded
    }

    public class ThemeShapeSettings : ThemeSettings<ThemeShape>
    {
        protected override ThemeShape DefaultValue => ThemeShape.Squared;
        protected override string SettingsKey => "AppShapeSettings";

        public ResourceDictionary GetResourceDictionary()
        {
            var preferredShape = GetPreferences();
            
            switch (preferredShape)
            {
                case ThemeShape.Squared:
                    return new SquaredShape();
                case ThemeShape.Rounded:
                    return new RoundedShape();

                default:
                    throw new ArgumentOutOfRangeException($"Missing case in {nameof(ThemeShapeSettings)} for type {Enum.GetName(typeof(ThemeShape), preferredShape)}");
            }
        }
    }
}