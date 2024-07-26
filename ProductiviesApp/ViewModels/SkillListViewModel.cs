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
        new Thread(async () => await InitializeAsync()).Start();

        GoToSkillCreationPageCommand = new GoToPageCommand($"{nameof(SkillCreationPage)}?param1={new SkillCreationViewModel()}");
    }

    private readonly SkillsDatabase _skillsDatabase = new();

    public ObservableCollection<SkillModel> AllSkills { get; } = [];

    public ICommand GoToSkillCreationPageCommand { get; }

    public async Task InitializeAsync()
    {
        var skills = await _skillsDatabase.GetSkillsAsync();

        foreach (var item in skills.Select(s => s.ToModel()))
            AllSkills.Add(item);
    }
}