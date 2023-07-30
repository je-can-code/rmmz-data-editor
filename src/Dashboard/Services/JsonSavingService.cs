using JMZ.Rmmz.Data.Models.JABS.implementations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JMZ.Dashboard.Services;

/// <summary>
/// A utility class for saving JSON data files as their appropriate types.
/// This will overwrite the existing file!
/// </summary>
public static class JsonSavingService
{
    /// <summary>
    /// Saves the current state of weapons to the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <param name="data">The current state of weapons.</param>
    public static async Task SaveWeapons(string path, List<RPG_Weapon> data)
    {
        // convert the objects to JSON.
        var json = JsonConvert.SerializeObject(
            data,
            Formatting.Indented,
            new StringEnumConverter());

        // build the path.
        var fullPath = $"{path}/Weapons.json";

        // write all the text back out as json.
        await File.WriteAllTextAsync(fullPath, json);
    }
    
    /// <summary>
    /// Saves the current state of skills to the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <param name="data">The current state of skills.</param>
    public static async Task SaveSkills(string path, List<RPG_Skill> data)
    {
        // convert the objects to JSON.
        var json = JsonConvert.SerializeObject(
            data,
            Formatting.Indented,
            new StringEnumConverter());

        // build the path.
        var fullPath = $"{path}/Skills.json";

        // write all the text back out as json.
        await File.WriteAllTextAsync(fullPath, json);
    }
}