namespace JMZ.Rmmz.Data.Tags;

/// <summary>
/// A data model representing a single tag found in the notes of almost any
/// database item from RMMZ.
/// </summary>
/// <param name="Name">
/// The name of the tag, aka the value on the left side of the separator.
/// </param>
/// <param name="Value">
/// The value of the tag, aka the value on the right side of the separator.
/// </param>
/// <param name="isBoolean">
/// A shorthand of whether or not the tag is boolean.
/// </param>
public readonly record struct NoteTag(
    string Name = "",
    string Value = "",
    bool isBoolean = false);