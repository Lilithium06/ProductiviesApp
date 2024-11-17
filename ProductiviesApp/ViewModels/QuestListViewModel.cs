using ProductiviesApp.Commands;
using ProductiviesApp.Core;
using ProductiviesApp.DataAccess;
using ProductiviesApp.Mappers;
using ProductiviesApp.Model;
using ProductiviesApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProductiviesApp.ViewModels;

public class QuestListViewModel : ViewModelBase
{
    public QuestListViewModel()
    {
        new Thread(async () => await InitializeAsync()).Start();

        GoToQuestCreationPageCommand = new GoToPageCommand($"{nameof(QuestCreationPage)}?param1={new QuestCreationViewModel()}");
        CompleteQuestCommand = new Command<Quest>(async (questModel) => await CompleteQuest(questModel));
    }

    private readonly QuestDatabase _questDatabase = new();
    private readonly SkillsDatabase _skillsDatabase = new();

    public ObservableCollection<Quest> AllQuests { get; } = [];

    public ICommand GoToQuestCreationPageCommand { get; }
    public ICommand CompleteQuestCommand { get; }

    public async Task InitializeAsync()
    {
        var quests = await _questDatabase.GetQuestAsync();

        MainThread.BeginInvokeOnMainThread(() =>
        {
            foreach (var item in quests.Select(s => s.ToModel()))
                AllQuests.Add(item);
        });
    }

    private async Task CompleteQuest(Quest quest)
    {
        for (int i = 0; i < quest.NeededSkills.Count; i++)
        {
            var skillEntityToUpdate = await _skillsDatabase.GetSkillByIdAsync(quest.NeededSkills[i].Id);
            var skillModelToUpdate = skillEntityToUpdate.ToModel();
            skillModelToUpdate.Exp += ExpForDifficulty.DifficultyForExpMap[quest.Difficulty[i]];
            skillModelToUpdate.Level = ExpSystem.GetLevelFromExp(skillModelToUpdate.Exp);
            await _skillsDatabase.SaveSkillAsync(skillModelToUpdate.ToEntity());
        }

        await _questDatabase.DeleteQuestAsync(quest.ToEntity());
    }
}