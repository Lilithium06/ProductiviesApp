using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProductiviesApp.DataAccess.Entities;

public class QuestEntity
{
    [PrimaryKey, AutoIncrement]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Details { get; set; }
    public string Difficulty { get; set; }
    
    [ManyToMany(typeof(QuestSkillEntity))]
    public List<SkillEntity> NeededSkills { get; set; }
}