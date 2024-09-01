namespace JMZ.Quest.Data.Models;

/// <summary>
/// A data structure representing a single category that a quest can belong to.
/// </summary>
/// <param name="Key">The key of the category.</param>
/// <param name="Name">The name of the category.</param>
/// <param name="IconIndex">The index of the icon for the category.</param>
public record OmniCategory(
    string Key,
    string Name,
    int IconIndex = 0)
{
    public string Key { get; } = Key;
    public string Name { get; } = Name;
    public int IconIndex { get; } = IconIndex;

}