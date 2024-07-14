using ProductiviesApp.DataAccess.Entities;
using ProductiviesApp.Models;

namespace ProductiviesApp.Mappers;

public static class SkillMapper
{
    public static SkillModel ToModel(this SkillEntity entity)
    {
        return new SkillModel()
        {
            Id = entity.Id,
            Exp = entity.Exp,
            Level = entity.Level,
            Name = entity.Name
        };
    }

    public static SkillEntity ToEntity(this SkillModel model)
    {
        return new SkillEntity()
        {
            Id = model.Id,
            Exp = model.Exp,
            Level = model.Level,
            Name = model.Name
        };
    }
}