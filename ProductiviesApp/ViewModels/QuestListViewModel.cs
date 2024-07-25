using ProductiviesApp.Commands;
using ProductiviesApp.Core;
using ProductiviesApp.DataAccess;
using ProductiviesApp.Mappers;
using ProductiviesApp.Models;
using ProductiviesApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProductiviesApp.ViewModels;

public class QuestListViewModel : ViewModelBase
{
    public QuestListViewModel()
    {
        _questDatabase = new();
        _skillsDatabase = new();
        new Thread(async () => await InitializeAsync()).Start();

        _goToQuestCreationPageCommand = new GoToPageCommand($"{nameof(QuestCreationPage)}?param1={new QuestCreationViewModel()}");
        _completeQuestCommand = new Command<QuestModel>(async (questModel) => await CompleteQuest(questModel));
    }

    private readonly QuestDatabase _questDatabase;
    private readonly SkillsDatabase _skillsDatabase;

    private ObservableCollection<QuestModel> _allQuests = [];

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