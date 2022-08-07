namespace Dashboard.Models.@base;

/// <summary>
/// A data model representing a base-level item from the database- but with traits!
/// </summary>
public class RPG_Traited : RPG_BaseItem
{
    /// <summary>
    /// A collection of all traits this item possesses.
    /// </summary>
    public RPG_Trait[] traits { get; set; } = Array.Empty<RPG_Trait>();
}