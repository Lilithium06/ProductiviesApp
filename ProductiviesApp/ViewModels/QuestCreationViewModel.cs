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
        SaveCommand = new Command(async () => await SaveQuest());
        AddSkillCommand = new Command(AddSkill);
        RemoveSkillCommand = new Command<SkillDifficultyModel>(RemoveSkill);
        GoToLastPageCommand = new GoToPageCommand("..");

        new Thread(async () => await Initialize()).Start();
    }

    private readonly QuestDatabase _questDatabase = new();
    private readonly SkillsDatabase _skillsDatabase = new();

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

    public ObservableCollection<SkillDifficultyModel> AvailableSkillDifficulties { get; } = [];
    public ObservableCollection<SkillModel> AllSkills { get; } = [];
    public ObservableCollection<Difficulty> AllDifficulties { get; } = [];

    public ICommand SaveCommand { get; }
    public ICommand AddSkillCommand { get; }
    public ICommand RemoveSkillCommand { get; }
    public ICommand GoToLastPageCommand { get; }

    private async Task<int> SaveQuest()
    {
        var questToSave = new QuestModel()
        {
            Id = Guid.Empty,
            Name = Name,
            Details = Details,
            NeededSkills = new List<SkillModel>(AvailableSkillDifficulties.Select(sd => sd.SkillModel)),
            Difficulty = new List<Difficulty>(AvailableSkillDifficulties.Select(sd => sd.Difficulty))
        };

        GoToLastPageCommand.Execute(null);

        return await _questDatabase.SaveQuestAsync(questToSave.ToEntity());
    }

    private async Task Initialize()
    {
        var skillEntities = await _skillsDatabase.GetSkillsAsync();
        foreach (var item in skillEntities.Select(s => s.ToModel()))
            AllSkills.Add(item);
        foreach (var item in Enum.GetValues<Difficulty>())
            AllDifficulties.Add(item);

        var skillDifficulties = AllSkills.Select(s =>
        {
            return new SkillDifficultyModel
            {
                SkillModel = s,
                Difficulty = AllDifficulties.First()
            };
        });
        foreach (var item in skillDifficulties)
            AvailableSkillDifficulties.Add(item);
    }

    private void AddSkill()
    {
        var newSkillDifficulty = new SkillDifficultyModel
        {
            SkillModel = AllSkills.First(),
            Difficulty = Difficulty.VeryEasy
        };
        AvailableSkillDifficulties.Add(newSkillDifficulty);
    }

    private void RemoveSkill(SkillDifficultyModel skillDifficulty)
    {
        AvailableSkillDifficulties.Remove(skillDifficulty);
    }
}