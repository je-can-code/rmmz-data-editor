﻿using System.Runtime.Serialization;
using JMZ.Crafting.Data;
using JMZ.Difficulty.Data;
using JMZ.Difficulty.Data.Models;
using JMZ.Quest.Data;
using JMZ.Rmmz.Data.Models.db.implementations;
using JMZ.Sdp.Data;
using JMZ.Sdp.Data.Models;
using Newtonsoft.Json;

namespace JMZ.Json.Data.Services;

/// <summary>
///     A utility class for loading JSON data files from a given location
///     and parsing them as their type.
/// </summary>
public static class JsonLoaderService
{
    /// <summary>
    ///     A template string for creating the path to the SDP configuration data.
    /// </summary>
    /// <param name="basePath">The path that contains the target config file.</param>
    /// <returns>The full path to the configuration data.</returns>
    public static string SdpDataPath(string basePath)
    {
        return @$"{basePath}\{SdpInitializer.ConfigurationFileName}";
    }

    /// <summary>
    ///     A template string for creating the path to the Crafting configuration data.
    /// </summary>
    /// <param name="basePath">The path that contains the target config file.</param>
    /// <returns>The full path to the configuration data.</returns>
    public static string CraftingDataPath(string basePath)
    {
        return $@"{basePath}\{CraftingInitializer.ConfigurationFileName}";
    }

    /// <summary>
    ///     A template string for creating the path to the Difficulty configuration data.
    /// </summary>
    /// <param name="basePath">The path that contains the target config file.</param>
    /// <returns>The full path to the configuration data.</returns>
    public static string DifficultyDataPath(string basePath)
    {
        return $@"{basePath}\{DifficultyInitializer.ConfigurationFileName}";
    }

    public static string QuestDataPath(string basePath)
    {
        return $@"{basePath}\{QuestInitializer.ConfigurationFileName}";
    }

    /// <summary>
    ///     Loads the items from the json found in the of the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <returns>The converted items.</returns>
    public static List<RPG_Item> LoadItems(string path)
    {
        // build the path.
        var fullPath = $"{path}/Items.json";

        // load the list of weapons.
        return Load<List<RPG_Item>>(fullPath);
    }

    /// <summary>
    ///     Loads the weapons from the json found in the of the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <returns>The converted weapons.</returns>
    public static async Task<List<RPG_Weapon>> LoadWeapons(string path)
    {
        // build the path.
        var fullPath = $"{path}/Weapons.json";

        // load the list of weapons.
        return await LoadAsync<List<RPG_Weapon>>(fullPath);
    }

    /// <summary>
    ///     Loads the armors from the json found in the of the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <returns>The converted armors.</returns>
    public static List<RPG_Armor> LoadArmors(string path)
    {
        // build the path.
        var fullPath = $"{path}/Armors.json";

        // load the list of weapons.
        return Load<List<RPG_Armor>>(fullPath);
    }

    /// <summary>
    ///     Loads the enemies from the json found in the of the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <returns>The converted enemies.</returns>
    public static List<RPG_Enemy> LoadEnemies(string path)
    {
        // build the path.
        var fullPath = $"{path}/Enemies.json";

        // load the list of weapons.
        // return Load<List<RPG_Enemy>>(fullPath);
        return Load<List<RPG_Enemy>>(fullPath);
    }

    /// <summary>
    ///     Loads the skills from the json found in the of the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <returns>The converted skills.</returns>
    public static List<RPG_Skill> LoadSkills(string path)
    {
        // build the path.
        var fullPath = $"{path}/Skills.json";

        // load it up as a list of skills.
        return Load<List<RPG_Skill>>(fullPath);
    }

    /// <summary>
    ///     Loads the SDPs from the json found in the of the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <returns>The converted Sdps.</returns>
    public static List<StatDistributionPanel> LoadSdps(string path)
    {
        // build the path.
        var fullPath = SdpDataPath(path);

        // load it up as the list of panels.
        return Load<List<StatDistributionPanel>>(fullPath);
    }

    /// <summary>
    ///     Loads the crafting configuration from the json found in the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <returns>The converted crafting configuration.</returns>
    public static CraftingConfiguration LoadCrafting(string path)
    {
        // determine the path to the crafting config.
        var fullPath = CraftingDataPath(path);

        // load it up as the configuration object.
        return Load<CraftingConfiguration>(fullPath);
    }

    public static List<DifficultyMetadata> LoadDifficulties(string path)
    {
        // determine the path to the crafting config.
        var fullPath = DifficultyDataPath(path);

        // load it up as the configuration object.
        return Load<List<DifficultyMetadata>>(fullPath);
    }

    public static async Task<QuestConfiguration> LoadQuests(string path)
    {
        var fullPath = QuestDataPath(path);
        return await LoadAsync<QuestConfiguration>(fullPath);
    }

    /// <summary>
    ///     Determines whether or not there is a file at the target location.
    ///     This is used for validating config files exist ahead of loading.
    /// </summary>
    /// <param name="path">The path and file to validate exists.</param>
    /// <returns>True if the file exists, false otherwise.</returns>
    public static bool IsConfigPresent(string path)
    {
        return File.Exists(path);
    }

    /// <summary>
    ///     Loads a json file from the provided path, and deserializes it into T.
    /// </summary>
    /// <param name="path">The path including the filename and extension.</param>
    /// <typeparam name="T">The type to deserialize the json into.</typeparam>
    private static T Load<T>(string path)
    {
        // validate the file requested is present.
        if (!File.Exists(path))
        {
            // throw up violently if the file is missing.
            throw new FileNotFoundException(path);
        }

        // read the file as json.
        var rawJson = File.ReadAllText(path);

        // deserialize the json into the designated type.
        return JsonConvert.DeserializeObject<T>(rawJson)
            ?? throw new SerializationException("could not deserialize into target class.");
    }

    private static async Task<T> LoadAsync<T>(string path)
    {
        // validate the file requested is present.
        if (!File.Exists(path))
        {
            // throw up violently if the file is missing.
            throw new FileNotFoundException(path);
        }

        // read the file as json.
        var rawJson = await File.ReadAllTextAsync(path);

        // deserialize the json into the designated type.
        return JsonConvert.DeserializeObject<T>(
                rawJson,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                })
            ?? throw new SerializationException("could not deserialize into target class.");
    }
}