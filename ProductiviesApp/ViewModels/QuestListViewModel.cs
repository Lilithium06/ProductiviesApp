using System.Collections.ObjectModel;
using ProductiviesApp.DataAccess;
using ProductiviesApp.DataAccess.Models;
using ProductiviesApp.Mappers;
using ProductiviesApp.Models;

namespace ProductiviesApp.ViewModels;

public class QuestListViewModel : ViewModelBase
{
    public QuestListViewModel()
    {
        
    }
    
    public QuestListViewModel(SkillsDatabase skillsDatabase)
    {
        InitializeAsync(skillsDatabase);
        
        _allSkills = new ObservableCollection<SkillModel>();
    }

    private ObservableCollection<SkillModel> _allSkills;

    public ObservableCollection<SkillModel> AllSkills
    {
        get => _allSkills;
        set => SetProperty(ref _allSkills, value);
    }

    private async Task InitializeAsync(SkillsDatabase skillsDatabase)
    {
        var testSkill = new SkillModel()
        {
            Id = Guid.Empty,
            Exp = 666,
            Level = 6,
            Name = "Test Skill"
        };

        await skillsDatabase.SaveItemAsync(testSkill.ToEntity());

        var skills = await skillsDatabase.GetSkillsAsync();

        AllSkills = new ObservableCollection<SkillModel>(skills.Select(s => s.ToModel()));
    }
}