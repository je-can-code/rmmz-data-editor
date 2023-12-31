using JMZ.Dashboard.Services;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Dashboard.Caches;

public static class Weapons
{
    public static readonly Dictionary<int, RPG_Weapon> Cache = new();
    
    public static void Refresh(string projectPath)
    {
        Cache.Clear();

        var weapons = JsonLoaderService.LoadWeapons(projectPath);
        
        weapons.ForEach(weapon =>
        {
            if (weapon is null) return;
            
            Cache.Add(weapon.id, weapon);
        });
    }
}