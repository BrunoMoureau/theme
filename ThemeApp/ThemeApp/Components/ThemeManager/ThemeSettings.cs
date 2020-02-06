using System;
using ThemeApp.Components.ThemeManager.Interfaces;
using Xamarin.Essentials;

namespace ThemeApp.Components.ThemeManager
{
    public abstract class ThemeSettings<T> : IThemeSettings<T>
    {
        protected abstract T DefaultValue { get; }
        protected abstract string SettingsKey { get; }

        public T GetPreferences()
        {
            var defaultValue = GetEnumName(DefaultValue);
            var settingsValue = Preferences.Get(SettingsKey, defaultValue); 
            return (T)Enum.Parse(typeof(T), settingsValue); //todo what happens if enum values has been refactored?
        }

        public void SetPreferences(T type)
        {
            Preferences.Set(SettingsKey, GetEnumName(type));
        }

        public void ResetPreferences()
        {
            SetPreferences(DefaultValue);
        }

        private string GetEnumName(T type)
        {
            return Enum.GetName(typeof(T), type);
        }
    }
}
