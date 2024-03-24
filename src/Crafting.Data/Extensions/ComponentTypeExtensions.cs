using JMZ.Crafting.Data.Models;

namespace JMZ.Crafting.Data.Extensions;

public static class ComponentTypeExtensions
{
    public static string ToAbbreviation(this ComponentType componentType)
    {
        return componentType switch
        {
            ComponentType.Item => "i",
            ComponentType.Weapon => "w",
            ComponentType.Armor => "a",
            ComponentType.Gold => "g",
            ComponentType.SDP => "s",
            _ => "_"
        };
    }
}