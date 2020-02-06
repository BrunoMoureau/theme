namespace ThemeApp.Components.ThemeManager.Interfaces
{
    public interface IThemeSettings<T>
    {
        T GetPreferences();
        void SetPreferences(T type);
        void ResetPreferences();
    }
}
