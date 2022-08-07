using Dashboard.Models;
using Newtonsoft.Json;

namespace Dashboard.Services;

public static class JsonLoaderService
{
    /// <summary>
    /// Loads the weapons from the json found in the of the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <returns>The converted weapons.</returns>
    public static List<RPG_Weapon> LoadWeapons(string path)
    {
        // build the path.
        var fullPath = $"{path}/Weapons.json";

        // read the file as json.
        var rawJson = File.ReadAllText(fullPath);

        // convert the json into weapons.
        var weapons = JsonConvert.DeserializeObject<List<RPG_Weapon>>(rawJson) ?? new();

        // return what we found.
        return weapons;
    }

    /// <summary>
    /// Saves the current state of weapons to the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <param name="weapons">The current state of weapons.</param>
    public static async Task SaveWeapons(string path, List<RPG_Weapon> weapons)
    {
        // convert the objects to JSON.
        var jsonWeapons = JsonConvert.SerializeObject(weapons);

        // build the path.
        var fullPath = $"{path}/Weapons.json";

        // write all the text back out as json.
        await File.WriteAllTextAsync(fullPath, jsonWeapons);
    }
}