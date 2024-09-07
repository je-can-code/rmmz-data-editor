using JMZ.Json.Data.Services;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Json.Data.Caches;

public static class Items
{
    public static readonly Dictionary<int, RPG_Item> Cache = new();

    public static void Refresh(string projectPath)
    {
        Cache.Clear();

        var items = JsonLoaderService.LoadItems(projectPath);

        items.ForEach(
            item =>
            {
                if (item is null) return;

                Cache.Add(item.id, item);
            });
    }
}