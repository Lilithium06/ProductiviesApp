using ProductiviesApp.ViewModels;

namespace ProductiviesApp.Views;

public partial class QuestListPage : ContentPage
{
    private QuestListViewModel _viewModel;
    
    public QuestListPage(QuestListViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = viewModel;
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.InitializeAsync();
    }
}