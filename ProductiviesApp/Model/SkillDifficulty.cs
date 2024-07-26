namespace ProductiviesApp.Model;

public class SkillDifficulty
{
    public Skill SkillModel { get; set; } = new();
    public Difficulty Difficulty { get; set; }
}