﻿using JMZ.Json.Data.Services;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Json.Data.Caches;

public static class Weapons
{
    public static readonly Dictionary<int, RPG_Weapon> Cache = new();

    public static async Task Refresh(string projectPath)
    {
        Cache.Clear();

        var weapons = await JsonLoaderService.LoadWeapons(projectPath);

        weapons.ForEach(
            weapon =>
            {
                if (weapon is null) return;

                Cache.Add(weapon.id, weapon);
            });
    }
}