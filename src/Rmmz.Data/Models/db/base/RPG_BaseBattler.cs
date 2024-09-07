using JMZ.Rmmz.Data.Models.db._data;

namespace JMZ.Rmmz.Data.Models.db.@base;

/// <summary>
///     A class representing the foundation of all database battler objects.
/// </summary>
public abstract class RPG_BaseBattler : RPG_Base
{
    /// <summary>
    ///     The name of the battler while in battle.
    /// </summary>
    public string battlerName { get; set; } = string.Empty;

    /// <summary>
    ///     The name of this database entry.
    /// </summary>
    public List<RPG_Trait> traits { get; set; } = [];
}