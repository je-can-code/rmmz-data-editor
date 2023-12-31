namespace JMZ.Crafting.Data.Models;

/// <summary>
/// A data model representing a single recipe that can potentially be crafted.
/// </summary>
public class Recipe
{
    /// <summary>
    /// The name of this recipe.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The unique identifying key associated with this recipe.
    /// </summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// The icon index of this recipe.<br/>
    /// A value of 0 represents no icon will be displayed.
    /// </summary>
    public int IconIndex { get; set; } = 0;
    
    /// <summary>
    /// The description of this recipe.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Whether or not this recipe comes unlocked when a category is first acquired.
    /// </summary>
    public bool UnlockedByDefault { get; set; } = false;

    /// <summary>
    /// Whether or not this recipe will have its details masked until it is crafted.
    /// </summary>
    public bool MaskedUntilCrafted { get; set; } = true;

    /// <summary>
    /// The category keys that this recipe belongs to.
    /// </summary>
    public List<string> CategoryKeys { get; set; } = new();

    /// <summary>
    /// The list of required tools not consumed but required to execute the recipe.
    /// </summary>
    public List<Component> Tools { get; set; } = new();
    
    /// <summary>
    /// The list of ingredients that make up this recipe that will be consumed.
    /// </summary>
    public List<Component> Ingredients { get; set; } = new();
    
    /// <summary>
    /// The list of components that will be generated when this recipe is successfully crafted.
    /// </summary>
    public List<Component> Outputs { get; set; } = new();
}