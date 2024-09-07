namespace JMZ.Quest.Data.Models;

/// <summary>
///     A data structure representing a single tag that a quest can be associated with.
/// </summary>
/// <param name="Key">The key of the tag.</param>
/// <param name="Name">The name of the tag.</param>
/// <param name="IconIndex">The index of the icon for the tag.</param>
public record OmniTag(string Key, string Name, int IconIndex = 0)
{
    public static OmniTag DefaultTemplate()
    {
        return new("ch-1", "Chapter 1");
    }

    public string Key { get; set; } = Key;
    public string Name { get; set; } = Name;
    public int IconIndex { get; set; } = IconIndex;
}