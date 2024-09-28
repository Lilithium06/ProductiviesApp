namespace ProductiviesApp.Core;

public static class ExpSystem
{
    private const int _baseExp = 50;
    private const double _growthRate = 1.06;

    public static int GetLevelFromExp(int exp)
    {
        var expLeft = exp;

        for (int i = 1; i < 101; i++)
        {
            var expForLevelDouble = _baseExp * Math.Pow(_growthRate, i - 1);
            int expForLevel = (int)expForLevelDouble;

            if (expLeft > expForLevel)
            {
                expLeft -= expForLevel;
            }
            else
            {
                return i;
            }
        }

        return 0;
    }

    public static int GetExpFromLevel(int level)
    {
        var returnExp = 0;
        
        for (int i = 1; i <= level; i++)
        {
            returnExp += (int)(_baseExp * Math.Pow(_growthRate, i - 1));
        }

        return returnExp;
    }
} 