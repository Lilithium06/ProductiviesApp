using System.Collections.ObjectModel;
using System.Windows.Input;
using ProductiviesApp.DataAccess;
using ProductiviesApp.DataAccess.Entities;
using ProductiviesApp.Mappers;
using ProductiviesApp.Models;

namespace ProductiviesApp.ViewModels;

public class QuestListViewModel : ViewModelBase
{
    public QuestListViewModel()
    {
    }

    public QuestListViewModel(QuestDatabase questDatabase, SkillsDatabase skillsDatabase)
    {
        _questDatabase = questDatabase;
        InitializeAsync();
        
        GoToQuestCreationPageCommand = new Command(async () =>
        {
            var skills = await skillsDatabase.GetSkillsAsync();
            
            var quest = new QuestModel()
            {
                Id = Guid.Empty,
                Name = "Something",
                Details = "lol",
                Difficulty = [Difficulty.Medium, Difficulty.Easy,],
                NeededSkills = new ObservableCollection<SkillModel>(skills.Select(s => s.ToModel()))
            };
            
            await _questDatabase.SaveQuestAsync(quest.ToEntity());
        });
    }

    private QuestDatabase _questDatabase;

    private ObservableCollection<QuestModel> _allQuests;

    public ObservableCollection<QuestModel> AllQuests
    {
        get => _allQuests;
        set => SetProperty(ref _allQuests, value);
    }

    private ICommand _goToQuestCreationPageCommand;

    public ICommand GoToQuestCreationPageCommand
    {
        get => _goToQuestCreationPageCommand;
        set => SetProperty(ref _goToQuestCreationPageCommand, value);
    }
    
    public async Task InitializeAsync()
    {
        var quests = await _questDatabase.GetQuestAsync();

        AllQuests = new ObservableCollection<QuestModel>(quests.Select(s => s.ToModel()));

        Console.WriteLine();
    }
}