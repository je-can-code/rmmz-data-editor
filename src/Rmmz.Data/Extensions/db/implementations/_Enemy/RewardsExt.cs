using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Rmmz.Data.Extensions.db.implementations._Enemy;

public static class RewardsExt
{
    public static int GetExperience(this RPG_Enemy enemy)
    {
        return enemy.exp;
    }

    public static void UpdateExperience(this RPG_Enemy enemy, decimal newExperience)
    {
        enemy.exp = (int)newExperience;
    }

    public static int GetGold(this RPG_Enemy enemy)
    {
        return enemy.gold;
    }

    public static void UpdateGold(this RPG_Enemy enemy, decimal newGold)
    {
        enemy.gold = (int)newGold;
    }
}