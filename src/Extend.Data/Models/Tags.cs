using JMZ.Rmmz.Data.Tags;

namespace JMZ.Extend.Data.Models;

internal static class Tags
{
    public static Tag Extend { get; }

    static Tags()
    {
        // weapons.
        Extend = extend();
    }

    private static Tag extend()
    {
        return new(
            "skillExtend",
            @"<skillExtend:\[[\d,]+]>",
            "The comma-delimited list of skill ids that this skill extends.\n"
            + "\n"
            + "Extended skill data is not represented in this GUI.");
    }
}