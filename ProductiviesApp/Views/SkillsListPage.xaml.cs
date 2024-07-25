using ProductiviesApp.ViewModels;

namespace ProductiviesApp.Views;

public partial class SkillsListPage : ContentPage
{
    private SkillListViewModel _viewModel;

    public SkillsListPage(SkillListViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    //Can't bind OnAppearing in ViewModel so it's here soz haha <3
    protected override void OnAppearing()
    {
        base.OnAppearing();

        new Thread(async () => await _viewModel.InitializeAsync()).Start();
    }
}