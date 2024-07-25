using ProductiviesApp.Commands;
using ProductiviesApp.DataAccess;
using ProductiviesApp.Mappers;
using ProductiviesApp.Models;
using ProductiviesApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProductiviesApp.ViewModels;

public class SkillListViewModel : ViewModelBase
{
    public SkillListViewModel()
    {
        _skillsDatabase = new();
        new Thread(async () => await InitializeAsync()).Start();

        _goToSkillCreationPageCommand = new GoToPageCommand($"{nameof(SkillCreationPage)}?param1={new SkillCreationViewModel()}");
        _allSkills = [];
    }

    private readonly SkillsDatabase _skillsDatabase;

    private ObservableCollection<SkillModel> _allSkills;

    public ObservableCollection<SkillModel> AllSkills
    {
        get => _allSkills;
        set => SetProperty(ref _allSkills, value);
    }

    private ICommand _goToSkillCreationPageCommand;

    public ICommand GoToSkillCreationPageCommand
    {
        get => _goToSkillCreationPageCommand;
        set => SetProperty(ref _goToSkillCreationPageCommand, value);
    }

    public async Task InitializeAsync()
    {
        var skills = await _skillsDatabase.GetSkillsAsync();

        AllSkills = new ObservableCollection<SkillModel>(skills.Select(s => s.ToModel()));
    }
}