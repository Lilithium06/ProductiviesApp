using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProductiviesApp.DataAccess.Entities;

public class SkillEntity
{
    [PrimaryKey, AutoIncrement]
    public Guid Id { get; set; }

    [NotNull]
    public string Name { get; set; } = string.Empty;
    [NotNull]
    public int Level { get; set; }
    [NotNull]
    public int Exp { get; set; }

    [NotNull]
    [ManyToMany(typeof(QuestSkillEntity))]
    public List<QuestEntity> NeededInQuests { get; set; } = [];
}