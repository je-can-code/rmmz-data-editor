namespace JMZ.Quest.Data.Models;

/// <summary>
///     A data structure representing the shape of a single quest and its details.
/// </summary>
public record OmniQuest
{
    public static OmniQuest DefaultTemplate()
    {
        return new(
            "neo-9999",
            "The Journey Continues",
            0,
            string.Empty,
            [],
            "The old man at the Raevula Waterfront has a crazy idea for a heroic quest.",
            "A new quest for brave adventurers to undertake the journey of a lifetime.",
            1,
            [OmniObjective.DefaultTemplate()]
        );
    }

    public string Key { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int IconIndex { get; set; }

    public string CategoryKey { get; set; } = string.Empty;

    public List<string> TagKeys { get; set; } = [];

    public string UnknownHint { get; set; } = string.Empty;

    public string Overview { get; set; } = string.Empty;

    public int RecommendedLevel { get; set; }

    public List<OmniObjective> Objectives { get; } = [];

    /// <summary>
    ///     Constructor.
    /// </summary>
    /// <param name="key">The key of the quest.</param>
    /// <param name="name">The name of the quest.</param>
    /// <param name="iconIndex">The index of the icon for the quest.</param>
    /// <param name="categoryKey">The key of the category this quest is associated with.</param>
    /// <param name="tagKeys">The keys of all tags this quest is associated with.</param>
    /// <param name="unknownHint">The hint to display when the quest is inactive.</param>
    /// <param name="overview">The general description of the quest provided to the user.</param>
    /// <param name="recommendedLevel">The level recommended for taking this quest on.</param>
    /// <param name="objectives">The objectives that must be completed to complete the quest.</param>
    public OmniQuest(
        string key,
        string name,
        int iconIndex,
        string categoryKey,
        List<string> tagKeys,
        string unknownHint,
        string overview,
        int recommendedLevel,
        List<OmniObjective> objectives)
    {
        Key = key;
        Name = name;
        IconIndex = iconIndex;
        CategoryKey = categoryKey;
        TagKeys = tagKeys;
        UnknownHint = unknownHint;
        Overview = overview;
        RecommendedLevel = recommendedLevel;
        Objectives = objectives;
    }
}