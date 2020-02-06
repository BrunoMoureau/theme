using System.Collections.Generic;
using System.Windows.Input;
using ThemeApp.Components.ThemeManager;
using ThemeApp.Components.ThemeManager.Interfaces;
using ThemeApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThemeApp.Pages.Themes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemesPage
    {
        public ICommand ColorOptionTappedCommand { get; }
        public ICommand ShapeOptionTappedCommand { get; }

        private void ThemeColorOptionTapped(Option<ThemeColor> option)
        {
            if (ColorCollectionView.ItemsSource is IEnumerable<Option<ThemeColor>> items)
            {
                var options = new OptionCollection<ThemeColor>(items);
                options.Select(option.Value);
            }

            DependencyService.Get<IThemeManager>().SetThemeColor(option.Value);
            DependencyService.Get<IThemeManager>().Load();
        }

        private void ThemeShapeOptionTapped(Option<ThemeShape> option)
        {
            if (ShapeCollectionView.ItemsSource is IEnumerable<Option<ThemeShape>> items)
            {
                var options = new OptionCollection<ThemeShape>(items);
                options.Select(option.Value);
            }

            DependencyService.Get<IThemeManager>().SetThemeShape(option.Value);
            DependencyService.Get<IThemeManager>().Load();
        }

        public ThemesPage()
        {
            InitializeComponent();

            ColorOptionTappedCommand = new Command<Option<ThemeColor>>(ThemeColorOptionTapped, option => option.CanBeSelected());
            ShapeOptionTappedCommand = new Command<Option<ThemeShape>>(ThemeShapeOptionTapped, option => option.CanBeSelected());
            
            FillColorOptions();
            FillShapeOptions();
        }

        private void FillColorOptions()
        {
            var options = GetColorOptions();
            var color = DependencyService.Get<IThemeManager>().GetThemeColor();
            options.Select(color);

            ColorCollectionView.ItemsSource = options.Items;
        }

        private void FillShapeOptions()
        {
            var options = GetShapeOptions();
            var shape = DependencyService.Get<IThemeManager>().GetThemeShape();
            options.Select(shape);

            ShapeCollectionView.ItemsSource = options.Items;
        }

        private static OptionCollection<ThemeColor> GetColorOptions()
        {
            return new OptionCollection<ThemeColor>(new[]
            {
                new Option<ThemeColor>(false, ThemeColor.Auto, "Default Device Color"),
                new Option<ThemeColor>(false, ThemeColor.Light, "Light Color"),
                new Option<ThemeColor>(false, ThemeColor.Dark, "Dark Color")
            });
        }
        
        private static OptionCollection<ThemeShape> GetShapeOptions()
        {
            return new OptionCollection<ThemeShape>(new[]
            {
                new Option<ThemeShape>(false, ThemeShape.Squared, "Squared Shapes"),
                new Option<ThemeShape>(false, ThemeShape.Rounded, "Rounded Shapes")
            });
        }
    }
}