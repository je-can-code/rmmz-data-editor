namespace JMZ.Rmmz.Data.Models.db.@base;

/// <summary>
/// The data model representing a base-level item from the database.
/// </summary>
public abstract class RPG_BaseItem : RPG_Base
{
    /// <summary>
    /// The description of this entry.
    /// </summary>
    public string description { get; set; } = string.Empty;

    /// <summary>
    /// The icon index of this entry.
    /// </summary>
    public int iconIndex { get; set; } = 0;
}