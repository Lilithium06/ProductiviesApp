using ProductiviesApp.DataAccess.Entities;
using ProductiviesApp.Models;

namespace ProductiviesApp.Mappers;

public static class QuestMapper
{
    public static QuestModel ToModel(this QuestEntity entity)
    {
        var returnModel = new QuestModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Details = entity.Details,
            Difficulty = entity.Difficulty.StringToDifficulties(),

            NeededSkills = entity.NeededSkills is null ? ([]) :
            new List<SkillModel>(entity.NeededSkills.Select(s => s.ToModel()))
        };

        return returnModel;
    }

    public static QuestEntity ToEntity(this QuestModel model)
    {
        return new QuestEntity()
        {
            Id = model.Id,
            Name = model.Name,
            Details = model.Details,
            Difficulty = model.Difficulty.DifficultiesToString(),
            NeededSkills = model.NeededSkills.Select(s => s.ToEntity()).ToList()
        };
    }

    private static string DifficultiesToString(this List<Difficulty> difficulties)
        => string.Join(' ', difficulties.Select(d => d.ToString()));

    private static List<Difficulty> StringToDifficulties(this string difficultiesString)
        => new(difficultiesString.Split(' ')
            .Select(d => Enum.TryParse(typeof(Difficulty), d, out object? result) ? (Difficulty)result : Difficulty.VeryEasy));
}