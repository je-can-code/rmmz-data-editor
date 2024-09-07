using JMZ.Rmmz.Data.Models.db._data;

namespace JMZ.Rmmz.Data.Models.db.@base;

/// <summary>
///     A data model representing a base-level item from the database- but with traits!
/// </summary>
public abstract class RPG_Traited : RPG_BaseItem
{
    /// <summary>
    ///     A collection of all traits this item possesses.
    /// </summary>
    public RPG_Trait[] traits { get; set; } = Array.Empty<RPG_Trait>();
}