using JMZ.Crafting.Data.Models;

namespace JMZ.Crafting.Data;

/// <summary>
/// The shape of the configuration file for crafting.
/// </summary>
public class CraftingConfiguration
{
    public List<Recipe> Recipes { get; set; } = new();

    public List<Category> Categories { get; set; } = new();
}