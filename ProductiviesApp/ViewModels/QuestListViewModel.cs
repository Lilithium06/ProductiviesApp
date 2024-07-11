using System.Collections.ObjectModel;
using ProductiviesApp.Models;

namespace ProductiviesApp.ViewModels;

public class QuestListViewModel : ViewModelBase
{
    public QuestListViewModel()
    {
        _allSkills = new ObservableCollection<Skill>();
        AllSkills =
        [
            new Skill("Fitness", 5000),
            new Skill("Programming", 230)
        ];
    }

    private ObservableCollection<Skill> _allSkills;

    public ObservableCollection<Skill> AllSkills
    {
        get => _allSkills;
        set => SetProperty(ref _allSkills, value);
    }
}