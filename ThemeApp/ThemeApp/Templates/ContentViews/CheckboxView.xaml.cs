using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThemeApp.Templates.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckboxView
    {
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(
            nameof(IsSelected),
            typeof(bool),
            typeof(CheckboxView));

        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(CheckboxView));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(
            nameof(Description),
            typeof(string),
            typeof(CheckboxView));

        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }
        
        public static readonly BindableProperty TappedCommandProperty = BindableProperty.Create(
            nameof(TappedCommand),
            typeof(ICommand),
            typeof(CheckboxView));
        
        public ICommand TappedCommand
        {
            get => (ICommand)GetValue(TappedCommandProperty);
            set => SetValue(TappedCommandProperty, value);
        }

        public static readonly BindableProperty TappedCommandParameterProperty = BindableProperty.Create(
            nameof(TappedCommandParameter),
            typeof(object),
            typeof(CheckboxView));
        
        public object TappedCommandParameter
        {
            get => GetValue(TappedCommandParameterProperty);
            set => SetValue(TappedCommandParameterProperty, value);
        }

        public CheckboxView()
        {
            InitializeComponent();
        }

        private void OnViewTapped(object sender, EventArgs e)
        {
            if (TappedCommand == null) return;

            if (TappedCommand.CanExecute(TappedCommandParameter))
            {
                TappedCommand.Execute(TappedCommandParameter);
            }
        }
    }
}