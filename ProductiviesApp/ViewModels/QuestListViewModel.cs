using System.Collections.ObjectModel;
using System.Windows.Input;
using ProductiviesApp.Commands;
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
        InitializeAsync();

        GoToQuestCreationPageCommand = new GoToPageCommand($"{nameof(QuestCreationPage)}?param1={new QuestCreationViewModel()}");
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