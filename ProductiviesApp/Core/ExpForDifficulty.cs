using ProductiviesApp.Models;

namespace ProductiviesApp.Core;

public static class ExpForDifficulty
{
    public static readonly Dictionary<Difficulty, int> DifficultyForExpMap = new()
    {
        { Difficulty.VeryEasy, 50},
        { Difficulty.Easy, 100 },
        { Difficulty.Medium, 200 },
        { Difficulty.Hard, 300 },
        { Difficulty.VeryHard, 400 }
    };
}