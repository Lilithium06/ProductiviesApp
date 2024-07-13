using ProductiviesApp.ViewModels;

namespace ProductiviesApp.Views;

public partial class SkillCreationPage : ContentPage
{
    public SkillCreationPage(SkillCreationViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}