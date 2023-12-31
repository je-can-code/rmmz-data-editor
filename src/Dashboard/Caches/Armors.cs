using JMZ.Dashboard.Services;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Dashboard.Caches;

public static class Armors
{
    public static readonly Dictionary<int, RPG_Armor> Cache = new();
    
    public static void Refresh(string projectPath)
    {
        Cache.Clear();

        var armors = JsonLoaderService.LoadArmors(projectPath);
        
        armors.ForEach(armor =>
        {
            if (armor is null) return;
            
            Cache.Add(armor.id, armor);
        });
    }
}