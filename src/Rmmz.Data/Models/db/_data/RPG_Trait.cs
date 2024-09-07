namespace JMZ.Rmmz.Data.Models.db._data;

/// <summary>
///     A data model representing a single trait.
///     These traits are used across multiple items in the database.
/// </summary>
public class RPG_Trait
{
    public int code { get; set; } = 0;
    public int dataId { get; set; } = 0;
    public float value { get; set; } = 0;
}