using ProductiviesApp.ViewModels;

namespace ProductiviesApp.Views;

public partial class QuestCreationPage : ContentPage
{
    public QuestCreationPage(QuestCreationViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}