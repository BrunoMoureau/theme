using System;
using ThemeApp.Themes.Colors;
using Xamarin.Essentials;
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
        protected override ThemeColor DefaultValue { get; }
        protected override string SettingsKey => "AppColorSettings";

        public ThemeColorSettings()
        {
            DefaultValue = GetDeviceThemeColorOrDefault();
        }

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

        private ThemeColor GetDeviceThemeColorOrDefault()
        {
            switch (AppInfo.RequestedTheme)
            {
                case AppTheme.Light:
                    return ThemeColor.Light;
                case AppTheme.Dark:
                    return ThemeColor.Dark;

                default: 
                    return ThemeColor.Light;
            }
        }
    }
}