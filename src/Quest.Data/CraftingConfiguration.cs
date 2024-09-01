using JMZ.Quest.Data.Models;

namespace JMZ.Quest.Data;

/// <summary>
/// The shape of the configuration file for crafting.
/// </summary>
public class QuestConfiguration
{
    public List<OmniQuest> Quests { get; set; } = [];

    public List<OmniCategory> Categories { get; set; } = [];

    public List<OmniTag> Tags { get; set; } = [];
}