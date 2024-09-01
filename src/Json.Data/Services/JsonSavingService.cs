using JMZ.Crafting.Data;
using JMZ.Difficulty.Data;
using JMZ.Difficulty.Data.Models;
using JMZ.Quest.Data;
using JMZ.Rmmz.Data.Models.db.implementations;
using JMZ.Sdp.Data;
using JMZ.Sdp.Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace JMZ.Json.Data.Services;

/// <summary>
/// A utility class for saving JSON data files as their appropriate types.
/// This will overwrite the existing file!
/// </summary>
public static class JsonSavingService
{
    /// <summary>
    /// The default serialization settings.
    /// </summary>
    private static readonly JsonSerializerSettings settings = new()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        Formatting = Formatting.Indented,
        Converters = new List<JsonConverter> { new StringEnumConverter() },
    };
    
    /// <summary>
    /// Saves the current state of skills to the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <param name="data">The current state of skills.</param>
    public static async Task SaveSkills(string path, List<RPG_Skill> data)
    {
        // build the path.
        var fullPath = $"{path}/Skills.json";

        // save the data to the designated path.
        await Save(fullPath, data);
    }
    
    /// <summary>
    /// Saves the current state of items to the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <param name="data">The current state of items.</param>
    public static async Task SaveItems(string path, List<RPG_Item> data)
    {
        // build the path.
        var fullPath = $"{path}/Items.json";

        // save the data to the designated path.
        await Save(fullPath, data);
    }
    
    /// <summary>
    /// Saves the current state of weapons to the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <param name="data">The current state of weapons.</param>
    public static async Task SaveWeapons(string path, List<RPG_Weapon> data)
    {
        // build the path.
        var fullPath = $"{path}/Weapons.json";

        // save the data to the designated path.
        await Save(fullPath, data);
    }
    
    /// <summary>
    /// Saves the current state of armors to the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <param name="data">The current state of armors.</param>
    public static async Task SaveArmors(string path, List<RPG_Armor> data)
    {
        // build the path.
        var fullPath = $"{path}/Armors.json";

        // save the data to the designated path.
        await Save(fullPath, data);
    }
    
    /// <summary>
    /// Saves the current state of enemies to the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <param name="data">The current state of enemies.</param>
    public static async Task SaveEnemies(string path, List<RPG_Enemy> data)
    {
        // build the path.
        var fullPath = $"{path}/Enemies.json";

        // save the data to the designated path.
        await Save(fullPath, data);
    }
    
    /// <summary>
    /// Saves the current state of states to the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <param name="data">The current state of states.</param>
    public static async Task SaveStates(string path, List<RPG_State> data)
    {
        // build the path.
        var fullPath = $"{path}/States.json";

        // save the data to the designated path.
        await Save(fullPath, data);
    }

    /// <summary>
    /// Saves the current state of SDPs to the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <param name="data">The current state of SDPs.</param>
    public static async Task SaveSdps(string path, List<StatDistributionPanel> data)
    {
        // build the path.
        var fullPath = $"{path}/{SdpInitializer.ConfigurationFileName}";

        // save the data to the designated path.
        await Save(fullPath, data);
    }
    
    /// <summary>
    /// Saves the current state of Crafting to the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <param name="data">The current state of crafting.</param>
    public static async Task SaveCrafting(string path, CraftingConfiguration data)
    {
        // build the path.
        var fullPath = $"{path}/{CraftingInitializer.ConfigurationFileName}";

        // save the data to the designated path.
        await Save(fullPath, data);
    }

    /// <summary>
    /// Saves the current state of Difficulties to the current project path directory.
    /// </summary>
    /// <param name="path">The current project path directory.</param>
    /// <param name="data">The current state of the data.</param>
    public static async Task SaveDifficulties(string path, List<DifficultyMetadata> data)
    {
        // build the path.
        var fullPath = $"{path}/{DifficultyInitializer.ConfigurationFileName}";

        // save the data to the designated path.
        await Save(fullPath, data);
    }

    public static async Task SaveQuests(string path, QuestConfiguration data)
    {
        var fullPath = $"{path}/{QuestInitializer.ConfigurationFileName}";
        await Save(fullPath, data);
    }

    private static async Task Save<T>(string fullPath, T data)
    {
        // convert the objects to JSON.
        var json = JsonConvert.SerializeObject(data, settings);
        
        // write all the text back out as json.
        await File.WriteAllTextAsync(fullPath, json);
    }
}