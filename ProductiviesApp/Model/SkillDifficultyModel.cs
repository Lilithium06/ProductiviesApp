namespace ProductiviesApp.Model;

public class SkillDifficultyModel
{
    public SkillModel SkillModel { get; set; } = new();
    public Difficulty Difficulty { get; set; }
}