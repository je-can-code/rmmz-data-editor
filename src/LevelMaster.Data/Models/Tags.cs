using JMZ.Rmmz.Data.Tags;

namespace JMZ.LevelMaster.Data.Models;

public static class Tags
{
    public static Tag Level { get; }

    static Tags()
    {
        Level = level();
    }

    private static Tag level()
    {
        var tag = "level";
        var regex = @"<(?:lv|lvl|level):[ ]?(-?\+?\d+)>";
        var description = "The level of the enemy.";
        return new(tag, regex, description);
    }
}