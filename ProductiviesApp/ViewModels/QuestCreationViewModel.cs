using ProductiviesApp.Commands;
using ProductiviesApp.DataAccess;
using ProductiviesApp.Mappers;
using ProductiviesApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProductiviesApp.ViewModels;

public class QuestCreationViewModel : ViewModelBase
{
    public QuestCreationViewModel()
    {
        _questDatabase = new();
        _skillsDatabase = new();
        _saveCommand = new Command(async () => await SaveQuest());
        _addSkillCommand = new Command(AddSkill);
        _removeSkillCommand = new Command<SkillDifficultyModel>(RemoveSkill);
        _goToLastPageCommand = new GoToPageCommand("..");

        new Thread(async () => await Initialize()).Start();
    }

    private readonly QuestDatabase _questDatabase;
    private readonly SkillsDatabase _skillsDatabase;

    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    private string _details = string.Empty;

    public string Details
    {
        get => _details;
        set => SetProperty(ref _details, value);
    }

    private ObservableCollection<SkillDifficultyModel> _availableSkillDifficulties = [];

    public ObservableCollection<SkillDifficultyModel> AvailableSkillDifficulties
    {
        get => _availableSkillDifficulties;
        set => SetProperty(ref _availableSkillDifficulties, value);
    }

    private ObservableCollection<SkillModel> _allSkills = [];

    public ObservableCollection<SkillModel> AllSkills
    {
        get => _allSkills;
        set => SetProperty(ref _allSkills, value);
    }

    private ObservableCollection<Difficulty> _allDifficulties = [];

    public ObservableCollection<Difficulty> AllDifficulties
    {
        get => _allDifficulties;
        set => SetProperty(ref _allDifficulties, value);
    }

    private ICommand _saveCommand;

    public ICommand SaveCommand
    {
        get => _saveCommand;
        set => SetProperty(ref _saveCommand, value);
    }

    private ICommand _addSkillCommand;

    public ICommand AddSkillCommand
    {
        get => _addSkillCommand;
        set => SetProperty(ref _addSkillCommand, value);
    }

    private ICommand _removeSkillCommand;

    public ICommand RemoveSkillCommand
    {
        get => _removeSkillCommand;
        set => SetProperty(ref _removeSkillCommand, value);
    }

    private ICommand _goToLastPageCommand;

    public ICommand GoToLastPageCommand
    {
        get => _goToLastPageCommand;
        set => SetProperty(ref _goToLastPageCommand, value);
    }

    private async Task<int> SaveQuest()
    {
        var questToSave = new QuestModel()
        {
            Id = Guid.Empty,
            Name = Name,
            Details = Details,
            NeededSkills = new ObservableCollection<SkillModel>(AvailableSkillDifficulties.Select(sd => sd.SkillModel)),
            Difficulty = new ObservableCollection<Difficulty>(AvailableSkillDifficulties.Select(sd => sd.Difficulty))
        };

        GoToLastPageCommand.Execute(null);

        return await _questDatabase.SaveQuestAsync(questToSave.ToEntity());
    }

    private async Task Initialize()
    {
        var skillEntities = await _skillsDatabase.GetSkillsAsync();
        AllSkills = new ObservableCollection<SkillModel>(skillEntities.Select(s => s.ToModel()));
        AllDifficulties = new ObservableCollection<Difficulty>(Enum.GetValues<Difficulty>());

        var skillDifficulties = _allSkills.Select(s =>
        {
            var skillDifficulty = new SkillDifficultyModel();
            skillDifficulty.SkillModel = s;
            skillDifficulty.Difficulty = AllDifficulties.First();
            return skillDifficulty;
        });

        AvailableSkillDifficulties = new ObservableCollection<SkillDifficultyModel>(skillDifficulties);
    }

    private void AddSkill()
    {
        var newSkillDifficulty = new SkillDifficultyModel
        {
            SkillModel = _allSkills.First(),
            Difficulty = Difficulty.VeryEasy
        };
        AvailableSkillDifficulties.Add(newSkillDifficulty);
    }

    private void RemoveSkill(SkillDifficultyModel skillDifficulty)
    {
        AvailableSkillDifficulties.Remove(skillDifficulty);
    }
}