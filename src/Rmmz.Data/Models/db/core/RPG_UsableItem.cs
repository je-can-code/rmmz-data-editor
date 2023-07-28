using Rmmz.Data.Models.db._data;
using Rmmz.Data.Models.db.@base;

namespace Rmmz.Data.Models.db.core;

/// <summary>
/// A data model representing the base properties for any usable item or skill.
/// </summary>
public class RPG_UsableItem : RPG_BaseItem
{
    /// <summary>
    /// The animation id to execute.
    /// -1 translates to "use your normal attack".
    /// 0 translates to "no animation".
    /// </summary>
    public int animationId { get; set; } = -1;

    /// <summary>
    /// The damage data for this entry.
    /// </summary>
    public RPG_SkillDamage damage { get; set; } = new();

    /// <summary>
    /// The various effects of this entry.
    /// </summary>
    public RPG_UsableEffect[] effects { get; set; } = Array.Empty<RPG_UsableEffect>();

    /// <summary>
    /// The hit type of this entry.
    /// </summary>
    public int hitType { get; set; } = 0;

    /// <summary>
    /// The occasion type of when this entry can be used.
    /// </summary>
    public int occasion { get; set; } = 0;

    /// <summary>
    /// The number of times this entry will repeat.
    /// </summary>
    public int repeats { get; set; } = 1;

    /// <summary>
    /// The scope of this entry.
    /// </summary>
    public int scope { get; set; } = 1;

    /// <summary>
    /// The speed bonus of this entry.
    /// </summary>
    public int speed { get; set; } = 0;

    /// <summary>
    /// the % chance of success for this entry.
    /// </summary>
    public int successRate { get; set; } = 100;

    /// <summary>
    /// The amount of TP gained from using this entry.
    /// </summary>
    public int tpGain { get; set; } = 0;
}