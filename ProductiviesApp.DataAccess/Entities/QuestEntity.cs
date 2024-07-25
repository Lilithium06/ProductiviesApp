using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProductiviesApp.DataAccess.Entities;

public class QuestEntity
{
    [PrimaryKey, AutoIncrement]
    public Guid Id { get; set; }

    [NotNull]
    public string Name { get; set; } = string.Empty;
    [NotNull]
    public string Details { get; set; } = string.Empty;
    [NotNull]
    public string Difficulty { get; set; } = string.Empty;

    [NotNull]
    [ManyToMany(typeof(QuestSkillEntity))]
    public List<SkillEntity> NeededSkills { get; set; } = [];
}