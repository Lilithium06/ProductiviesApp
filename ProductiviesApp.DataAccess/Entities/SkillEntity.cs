using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProductiviesApp.DataAccess.Entities;

public class SkillEntity
{
    [PrimaryKey, AutoIncrement]
    public Guid Id { get; set; }

    public string Name { get; set; }
    public int Level { get; set; }
    public int Exp { get; set; }

    [ManyToMany(typeof(QuestSkillEntity))]
    public List<QuestEntity> NeededInQuests { get; set; }
}