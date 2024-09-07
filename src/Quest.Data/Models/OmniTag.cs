namespace JMZ.Quest.Data.Models;

/// <summary>
///     A data structure representing a single tag that a quest can be associated with.
/// </summary>
/// <param name="Key">The key of the tag.</param>
/// <param name="Name">The name of the tag.</param>
/// <param name="IconIndex">The index of the icon for the tag.</param>
public record OmniTag(string Key, string Name, int IconIndex = 0)
{
    public string Key { get; } = Key;
    public string Name { get; } = Name;
    public int IconIndex { get; } = IconIndex;
}