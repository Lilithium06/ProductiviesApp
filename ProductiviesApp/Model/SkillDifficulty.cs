namespace ProductiviesApp.Model;

public class SkillDifficulty
{
    public Skill Skill { get; set; } = new();
    public Difficulty Difficulty { get; set; }
}