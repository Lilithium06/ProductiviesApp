using ProductiviesApp.Commands;
using ProductiviesApp.DataAccess;
using ProductiviesApp.Mappers;
using ProductiviesApp.Model;
using System.Windows.Input;

namespace ProductiviesApp.ViewModels;

public class SkillCreationViewModel : ViewModelBase
{
    public SkillCreationViewModel()
    {
        SaveCommand = new Command(async () => await SaveSkill());
        GoToLastPageCommand = new GoToPageCommand("..");
    }

    private readonly SkillsDatabase _skillsDatabase = new();

    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public ICommand SaveCommand { get; }

    public ICommand GoToLastPageCommand { get; }

    private async Task<int> SaveSkill()
    {
        var skillToSave = new Skill()
        {
            Id = Guid.Empty,
            Name = Name,
            Exp = 0,
            Level = 1
        };

        GoToLastPageCommand.Execute(null);

        return await _skillsDatabase.SaveSkillAsync(skillToSave.ToEntity());
    }
}