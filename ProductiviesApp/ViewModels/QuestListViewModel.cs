using System.Collections.ObjectModel;
using System.Windows.Input;
using ProductiviesApp.Commands;
using ProductiviesApp.Core;
using ProductiviesApp.DataAccess;
using ProductiviesApp.DataAccess.Entities;
using ProductiviesApp.Mappers;
using ProductiviesApp.Models;
using ProductiviesApp.Views;

namespace ProductiviesApp.ViewModels;

public class QuestListViewModel : ViewModelBase
{
    public QuestListViewModel()
    {
    }

    public QuestListViewModel(QuestDatabase questDatabase, SkillsDatabase skillsDatabase)
    {
        _questDatabase = questDatabase;
        _skillsDatabase = skillsDatabase;
        InitializeAsync();

        GoToQuestCreationPageCommand = new GoToPageCommand($"{nameof(QuestCreationPage)}?param1={new QuestCreationViewModel()}");
        CompleteQuestCommand = new Command<QuestModel>(async (questModel) => await CompleteQuest(questModel));
    }

    private QuestDatabase _questDatabase;
    private SkillsDatabase _skillsDatabase;

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

    private ICommand _completeQuestCommand;
    public ICommand CompleteQuestCommand
    {
        get => _completeQuestCommand;
        set => SetProperty(ref _completeQuestCommand, value);
    }
    
    public async Task InitializeAsync()
    {
        var quests = await _questDatabase.GetQuestAsync();

        AllQuests = new ObservableCollection<QuestModel>(quests.Select(s => s.ToModel()));

        Console.WriteLine();
    }

    private async Task CompleteQuest(QuestModel questModel)
    {
        for (int i = 0; i < questModel.NeededSkills.Count; i++)
        {
            var skillEntityToUpdate = await _skillsDatabase.GetSkillByIdAsync(questModel.NeededSkills[i].Id);
            var skillModelToUpdate = skillEntityToUpdate.ToModel();
            skillModelToUpdate.Exp += ExpForDifficulty.DifficultyForExpMap[questModel.Difficulty[i]];
            skillModelToUpdate.Level = ExpSystem.GetLevelFromExp(skillModelToUpdate.Exp);
            await _skillsDatabase.SaveSkillAsync(skillModelToUpdate.ToEntity());
        }
        
        await _questDatabase.DeleteQuestAsync(questModel.ToEntity());
    }
}