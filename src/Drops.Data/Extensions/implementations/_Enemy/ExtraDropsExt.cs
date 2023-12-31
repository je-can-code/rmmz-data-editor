using JMZ.Drops.Data.Models;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db._data;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Drops.Data.Extensions.implementations._Enemy;

public static class ExtraDropsExt
{
    public static List<RPG_DropItem> GetDropsData(this RPG_Enemy enemy)
    {
        var dropDatas = enemy.GetAllStringsGroupedByTag(Tags.Drops.Name) ?? new List<List<string>>();
        if (!dropDatas.Any())
        {
            return new();
        }

        var drops = dropDatas
            .Select(dropData =>
            {
                var kind = ToKindInteger(dropData[0]);
                var dataId = int.Parse(dropData[1]);
                var chance = int.Parse(dropData[2]);

                return new RPG_DropItem
                {
                    dataId = dataId,
                    denominator = chance,
                    kind = kind
                };
            })
            .ToList();

        return drops;
    }

    public static void UpdateDropsData(this RPG_Enemy enemy, List<RPG_DropItem> drops)
    {
        // always start by removing everything.
        enemy.RemoveNoteData(Tags.Drops.Regex);

        // check if we were provided any drops to add in.
        if (!drops.Any())
        {
            // do nothing.
            return;
        }
        
        // iterate over each of the drops.
        drops.ForEach(drop =>
        {
            // build the tag for the drop.
            var newTag = Tags.Drops.ToArrayTag(
                ToKindString(drop.kind),
                drop.dataId.ToString(),
                drop.denominator.ToString());
            
            // add the drop to the enemy.
            enemy.AddNoteData(newTag);
        });
    }

    private static int ToKindInteger(string kindString) => kindString.ToLowerInvariant() switch
    {
        "i" or "item" => 0,
        "w" or "weapon" => 1,
        "a" or "armor" => 2,
        _ => throw new($"bad kind string provided {kindString}")
    };

    private static string ToKindString(int kindInteger) => kindInteger switch
    {
        0 => "i",
        1 => "w",
        2 => "a",
        _ => throw new($"bad kind integer provided {kindInteger}")
    };
}