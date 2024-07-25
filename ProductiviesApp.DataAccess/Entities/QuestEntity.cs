using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProductiviesApp.DataAccess.Entities;

public class QuestEntity
{
    [PrimaryKey, AutoIncrement]
    public required Guid Id { get; set; }

    [NotNull]
    public required string Name { get; set; }
    [NotNull]
    public required string Details { get; set; }
    [NotNull]
    public required string Difficulty { get; set; }

    [ManyToMany(typeof(QuestSkillEntity))]
    public required List<SkillEntity> NeededSkills { get; set; }
}