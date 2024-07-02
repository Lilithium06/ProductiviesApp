using ProductiviesApp.ViewModels;

namespace ProductiviesApp;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}
