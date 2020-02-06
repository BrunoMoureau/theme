using System;
using ThemeApp.Themes.Colors;
using Xamarin.Forms;

namespace ThemeApp.Components.ThemeManager
{
    public enum ThemeColor
    {
        Light,
        Dark
    }

    public class ThemeColorSettings : ThemeSettings<ThemeColor>
    {
        protected override ThemeColor DefaultValue => ThemeColor.Light;
        protected override string SettingsKey => "AppColorSettings";

        public ResourceDictionary GetResourceDictionary()
        {
            var color = GetPreferences();

            switch (color)
            {
                case ThemeColor.Light:
                    return new LightColor();
                case ThemeColor.Dark:
                    return new DarkColor();

                default:
                    throw new ArgumentOutOfRangeException($"Missing case in {nameof(ThemeColorSettings)} for type {Enum.GetName(typeof(ThemeColor), color)}");
            }
        }
    }
}