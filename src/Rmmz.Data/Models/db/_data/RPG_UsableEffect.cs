namespace Rmmz.Data.Models.db._data;

/// <summary>
/// A data model representing a single effect on an item or skill.
/// </summary>
public class RPG_UsableEffect
{
    /// <summary>
    /// The type of effect this is.
    /// </summary>
    public int code { get; set; } = 0;

    /// <summary>
    /// The data id further defines what type of effect this is.
    /// </summary>
    public int dataId { get; set; } = 0;

    /// <summary>
    /// The first value parameter of the effect.
    /// </summary>
    public float value1 { get; set; } = 0;

    /// <summary>
    /// The second value parameter of the effect.
    /// </summary>
    public float value2 { get; set; } = 0;
}