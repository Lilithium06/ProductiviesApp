using SQLiteNetExtensions.Attributes;

namespace ProductiviesApp.DataAccess.Entities;

public class QuestSkillEntity
{
    [ForeignKey(typeof(QuestEntity))]
    public Guid QuestId { get; set; }
    
    [ForeignKey(typeof(SkillEntity))]
    public Guid SkillId { get; set; }
}