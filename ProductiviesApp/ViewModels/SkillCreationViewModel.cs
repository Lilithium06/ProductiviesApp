using ProductiviesApp.Commands;
using ProductiviesApp.DataAccess;
using ProductiviesApp.Mappers;
using ProductiviesApp.Models;
using System.Windows.Input;

namespace ProductiviesApp.ViewModels;

public class SkillCreationViewModel : ViewModelBase
{
    public SkillCreationViewModel()
    {
        _skillsDatabase = new();
        _saveCommand = new Command(async () => await SaveSkill());
        _goToLastPageCommand = new GoToPageCommand("..");
    }

    private readonly SkillsDatabase _skillsDatabase;

    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    private ICommand _saveCommand;

    public ICommand SaveCommand
    {
        get => _saveCommand;
        set => SetProperty(ref _saveCommand, value);
    }

    private ICommand _goToLastPageCommand;

    public ICommand GoToLastPageCommand
    {
        get => _goToLastPageCommand;
        set => SetProperty(ref _goToLastPageCommand, value);
    }

    private async Task<int> SaveSkill()
    {
        var skillToSave = new SkillModel()
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