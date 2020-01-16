using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using ThemeApp.Components.ThemeManager.Interfaces;
using ThemeApp.Models;
using ThemeApp.Themes.Colors;
using ThemeApp.Themes.Shapes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThemeApp.Pages.Themes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemesPage
    {
        private ICommand _colorOptionTappedCommand;
        private ICommand _radiusOptionTappedCommand;

        public ICommand ColorOptionTappedCommand => 
            _colorOptionTappedCommand ?? (_colorOptionTappedCommand = new Command<Option<ResourceDictionary>>(option =>
        {
            if (option.IsSelected)
            {
                Trace.WriteLine("The color option is already selected");
                return;
            }

            if (ColorCollectionView.ItemsSource is IEnumerable<Option<ResourceDictionary>> options)
            {
                SelectOption(options, option);
            }

            DependencyService.Get<IThemeManager>().Colors = option.Value;
            DependencyService.Get<IThemeManager>().Load();
        }));

        public ICommand RadiusOptionTappedCommand => 
            _radiusOptionTappedCommand ?? (_radiusOptionTappedCommand = new Command<Option<ResourceDictionary>>(option =>
        {
            if (option.IsSelected)
            {
                Trace.WriteLine("The radius option is already selected");
                return;
            }

            if (RadiusCollectionView.ItemsSource is IEnumerable<Option<ResourceDictionary>> options)
            {
                SelectOption(options, option);
            }
            
            DependencyService.Get<IThemeManager>().Shapes = option.Value;
            DependencyService.Get<IThemeManager>().Load();
        }));

        public ThemesPage()
        {
            InitializeComponent();

            FillColorOptions();
            FillRadiusOptions();
        }

        private void FillColorOptions()
        {
            var options = GetColorOptions();
            var currentType = DependencyService.Get<IThemeManager>().Colors;
            var selectedOption = GetCurrentOption(options, currentType);
            SelectOption(options, selectedOption);

            Trace.WriteLine("Assign color options to the CollectionView");
            ColorCollectionView.ItemsSource = options;
        }

        private void FillRadiusOptions()
        {
            var options = GetRadiusOptions();
            var currentType = DependencyService.Get<IThemeManager>().Shapes;
            var selectedOption = GetCurrentOption(options, currentType);            
            SelectOption(options, selectedOption);

            Trace.WriteLine("Assign radius options to the CollectionView");
            RadiusCollectionView.ItemsSource = options;
        }

        private static Option<ResourceDictionary>[] GetColorOptions()
        {
            return new[]
            {
                new Option<ResourceDictionary>(false, new LightColor(), "Light Color"),
                new Option<ResourceDictionary>(false, new DarkColor(), "Dark Color")
            };
        }

        private static Option<ResourceDictionary>[] GetRadiusOptions()
        {
            return new[]
            {
                new Option<ResourceDictionary>(false, new SquaredShape(), "Squared Shapes"),
                new Option<ResourceDictionary>(false, new RoundedShape(), "Rounded Shapes")
            };
        }

        private Option<ResourceDictionary> GetCurrentOption(IEnumerable<Option<ResourceDictionary>> options, ResourceDictionary resourceDictionary)
        {
            var resourceDictionaryName = resourceDictionary.GetType().Name;
            return options.First(o => o.Value.GetType().Name.Equals(resourceDictionaryName));
        }

        private void SelectOption(IEnumerable<Option<ResourceDictionary>> options, Option<ResourceDictionary> selectedOption)
        {
            Trace.WriteLine("Select option");

            foreach (var option in options)
            {
                option.IsSelected = false;
            }

            selectedOption.IsSelected = true;
        }
    }
}