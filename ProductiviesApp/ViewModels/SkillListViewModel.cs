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
    }

    public SkillListViewModel(SkillsDatabase skillsDatabase)
    {
        _skillsDatabase = skillsDatabase;
        new Thread(async () => await InitializeAsync()).Start();

        GoToSkillCreationPageCommand = new GoToPageCommand($"{nameof(SkillCreationPage)}?param1={new SkillCreationViewModel()}");
        _allSkills = new ObservableCollection<SkillModel>();
    }

    private SkillsDatabase _skillsDatabase;

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