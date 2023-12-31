using JMZ.Crafting.Data.Models;
using JMZ.Dashboard.Caches;

namespace JMZ.Dashboard.Mappers;

public static class CraftComponentMapper
{
    public static string GetDisplayName(this Component component)
    {
        switch (component.Type)
        {
            case "i":
                if (Items.Cache.TryGetValue(component.Id, out var item))
                {
                    return item.name;
                }

                throw new($"invalid id for item: {component.Id}");
            case "w":
                if (Weapons.Cache.TryGetValue(component.Id, out var weapon))
                {
                    return weapon.name;
                }

                throw new($"invalid id for weapon: {component.Id}");
            case "a":
                if (Armors.Cache.TryGetValue(component.Id, out var armor))
                {
                    return armor.name;
                }

                throw new($"invalid id for armor: {component.Id}");
            case "g":
                return "GOLD";
            case "s":
                return "SDP";
            default:
                return string.Empty;
        }
    }
}