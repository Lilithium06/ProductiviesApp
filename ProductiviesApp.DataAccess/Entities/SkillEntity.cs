using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProductiviesApp.DataAccess.Entities;

public class SkillEntity
{
    [PrimaryKey, AutoIncrement]
    public Guid Id { get; set; }

    [NotNull]
    public required string Name { get; set; }
    [NotNull]
    public required int Level { get; set; }
    [NotNull]
    public required int Exp { get; set; }

    [NotNull]
    [ManyToMany(typeof(QuestSkillEntity))]
    public required List<QuestEntity> NeededInQuests { get; set; }
}