namespace ProductiviesApp.Models;

public class QuestModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;

    public List<Difficulty> Difficulty { get; set; } = [];
    public List<SkillModel> NeededSkills { get; set; } = [];
}