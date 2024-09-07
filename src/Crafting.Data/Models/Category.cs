namespace JMZ.Crafting.Data.Models;

/// <summary>
///     The data model representing a single category of crafting recipes.
/// </summary>
public class Category
{
    /// <summary>
    ///     The <see cref="Category" /> used when creating categories anew.
    /// </summary>
    public static Category NEW => new()
    {
        Name = "===NEW CATEGORY===",
        Key = "NEW_0"
    };

    /// <summary>
    ///     The name of this category.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     The unique identifying key associated with this category.
    /// </summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    ///     The icon index of this category.<br />
    ///     A value of 0 represents no icon will be displayed.
    /// </summary>
    public int IconIndex { get; set; } = 0;

    /// <summary>
    ///     The description of this category.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    ///     True if this category is unlocked by default, false otherwise.
    /// </summary>
    public bool UnlockedByDefault { get; set; } = false;
}