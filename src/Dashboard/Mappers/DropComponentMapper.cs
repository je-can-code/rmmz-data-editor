using JMZ.Crafting.Data.Models;
using JMZ.Rmmz.Data.Models.db._data;

namespace JMZ.Dashboard.Mappers;

public static class DropComponentMapper
{
    public static Component ToComponent(this RPG_DropItem dropItem)
    {
        return new()
        {
            Count = dropItem.denominator,
            Id = dropItem.dataId,
            Type = ToKindString(dropItem.kind)
        };
    }

    public static RPG_DropItem ToDropItem(this Component component)
    {
        return new()
        {
            denominator = component.Count,
            dataId = component.Id,
            kind = ToKindInteger(component.Type),
        };
    }

    private static string ToKindString(int kindInteger) => kindInteger switch
    {
        0 => "i",
        1 => "w",
        2 => "a",
        _ => throw new($"bad kind integer provided: {kindInteger}")
    };
    
    private static int ToKindInteger(string kindString) => kindString.ToLowerInvariant() switch
    {
        "i" or "item" => 0,
        "w" or "weapon" => 1,
        "a" or "armor" => 2,
        _ => throw new($"bad kind string provided: {kindString}")
    };
}