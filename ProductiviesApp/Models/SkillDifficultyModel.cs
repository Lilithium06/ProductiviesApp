using ProductiviesApp.ViewModels;

namespace ProductiviesApp.Models;

public class SkillDifficultyModel : ViewModelBase
{
    private SkillModel? _skillModel;

    public SkillModel? SkillModel
    {
        get => _skillModel;
        set => SetProperty(ref _skillModel, value);
    }

    private Difficulty _difficulty;

    public Difficulty Difficulty
    {
        get => _difficulty;
        set => SetProperty(ref _difficulty, value);
    }
}