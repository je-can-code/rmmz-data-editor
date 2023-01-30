namespace Dashboard.Models.Tags;

/// <summary>
/// A data model representing a single tag found in the notes of almost any
/// database item from RMMZ.
/// </summary>
public class NoteTag
{
    /// <summary>
    /// The left side of the : in the tag, aka the identifier.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The right side of the : in the tag, aka the value.
    /// </summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// Whether or not this is a boolean-type tag, as in only a name, no value.
    /// </summary>
    public bool isBoolean { get; set; } = false;
}