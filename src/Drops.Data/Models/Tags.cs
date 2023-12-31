using JMZ.Rmmz.Data.Tags;

namespace JMZ.Drops.Data.Models;

internal static class Tags
{
    public static Tag Drops { get; }
    
    public static Tag DropMultiplier { get; }
    
    public static Tag GoldMultiplier { get; }

    static Tags()
    {
        Drops = drops();
        DropMultiplier = dropMultiplier();
        GoldMultiplier = goldMultiplier();
    }

    private static Tag drops()
    {
        return new(
            "drops",
            @"<drops:[ ]?(\[(i|item|w|weapon|a|armor),[ ]?(\d+),[ ]?(\d+)])>",
            "The comma-delimited list of drops that this enemy can drop.\n" +
            "This extends their existing in-database drops.");
    }
    
    private static Tag dropMultiplier()
    {
        return new(
            "dropMultiplier",
            @"<dropMultiplier:[ ]?(-?\d+)>",
            "The percentage modifier applied against drops dropping.");
    }
    
    private static Tag goldMultiplier()
    {
        return new(
            "goldMultiplier",
            @"<goldMultiplier:[ ]?(-?\d+)>",
            "The percentage modifier applied against gold dropping.");
    }
}