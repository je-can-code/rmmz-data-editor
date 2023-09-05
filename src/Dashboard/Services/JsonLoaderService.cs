using JMZ.Rmmz.Data.Models.db.implementations;
using JMZ.Sdp.Data.Models;
using Newtonsoft.Json;

namespace JMZ.Dashboard.Services;

/// <summary>
/// A utility class for loading JSON data files from a given location
/// and parsing them as their type.
/// </summary>
public static class JsonLoaderService
{
    /// <summary>
    /// A template string for creating the path to the SDP configuration data.
    /// </summary>
    /// <param name="basePath">The path that contains the target config file.</param>
    /// <returns>The full path to the SDP configuration data.</returns>
    internal static string sdpDataPath(string basePath) => @$"{basePath}\config.sdp.json";
        
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
    /// Loads the skills from the json found in the of the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <returns>The converted skills.</returns>
    public static List<RPG_Skill> LoadSkills(string path)
    {
        // build the path.
        var fullPath = $"{path}/Skills.json";

        // read the file as json.
        var rawJson = File.ReadAllText(fullPath);

        // parse the json.
        var parsed = JsonConvert.DeserializeObject<List<RPG_Skill>>(rawJson) ?? new();

        // return what we found.
        return parsed;
    }

    /// <summary>
    /// Loads the SDPs from the json found in the of the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <returns>The converted Sdps.</returns>
    public static List<StatDistributionPanel> LoadSdps(string path)
    {
        // build the path.
        var fullPath = sdpDataPath(path);

        // read the file as json.
        var rawJson = File.ReadAllText(fullPath);

        // parse the json.
        var parsed = JsonConvert.DeserializeObject<List<StatDistributionPanel>>(rawJson) ?? new();

        // return what we found.
        return parsed;
    }

    /// <summary>
    /// Determines whether or not there is a file at the target location.
    /// This is used for validating config files exist ahead of loading.
    /// </summary>
    /// <param name="path">The path and file to validate exists.</param>
    /// <returns>True if the file exists, false otherwise.</returns>
    public static bool IsConfigPresent(string path)
    {
        return File.Exists(path);
    }
}