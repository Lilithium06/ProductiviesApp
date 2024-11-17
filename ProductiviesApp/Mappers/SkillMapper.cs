using ProductiviesApp.DataAccess.Entities;
using ProductiviesApp.Model;

namespace ProductiviesApp.Mappers;

public static class SkillMapper
{
    public static Skill ToModel(this SkillEntity entity)
    {
        return new Skill()
        {
            Id = entity.Id,
            Exp = entity.Exp,
            Level = entity.Level,
            Name = entity.Name
        };
    }

    public static SkillEntity ToEntity(this Skill skill)
    {
        return new SkillEntity()
        {
            Id = skill.Id,
            Exp = skill.Exp,
            Level = skill.Level,
            Name = skill.Name
        };
    }
}