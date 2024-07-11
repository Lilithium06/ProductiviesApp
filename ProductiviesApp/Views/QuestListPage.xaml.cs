using ProductiviesApp.ViewModels;

namespace ProductiviesApp.Views;

public partial class QuestListPage : ContentPage
{
    public QuestListPage(QuestListViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}