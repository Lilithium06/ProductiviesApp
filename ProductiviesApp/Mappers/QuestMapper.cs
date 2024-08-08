using ProductiviesApp.DataAccess.Entities;
using ProductiviesApp.Model;

namespace ProductiviesApp.Mappers;

public static class QuestMapper
{
    public static Quest ToModel(this QuestEntity entity)
    {
        return new Quest
        {
            Id = entity.Id,
            Name = entity.Name,
            Details = entity.Details,
            Difficulty = entity.Difficulty.StringToDifficulties(),

            NeededSkills = entity.NeededSkills is null ? ([]) :
            new List<Skill>(entity.NeededSkills.Select(s => s.ToModel()))
        };
    }

    public static QuestEntity ToEntity(this Quest quest)
    {
        return new QuestEntity()
        {
            Id = quest.Id,
            Name = quest.Name,
            Details = quest.Details,
            Difficulty = quest.Difficulty.DifficultiesToString(),
            NeededSkills = quest.NeededSkills.ConvertAll(s => s.ToEntity())
        };
    }

    private static string DifficultiesToString(this List<Difficulty> difficulties)
        => string.Join(' ', difficulties.Select(d => d.ToString()));

    private static List<Difficulty> StringToDifficulties(this string difficultiesString)
        => new(difficultiesString.Split(' ')
            .Select(d => Enum.TryParse(typeof(Difficulty), d, out object? result) ? (Difficulty)result : Difficulty.VeryEasy));
}