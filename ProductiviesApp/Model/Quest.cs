namespace ProductiviesApp.Model;

public class Quest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;

    public List<Difficulty> Difficulty { get; set; } = [];
    public List<Skill> NeededSkills { get; set; } = [];
}