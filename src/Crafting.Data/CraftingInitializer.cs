namespace JMZ.Crafting.Data;

public static class CraftingInitializer
{
    /// <summary>
    /// The name of the configuration file associated with this system.
    /// </summary>
    public static string ConfigurationFileName => "config.crafting.json";

    /// <summary>
    /// Initialize the bare minimum required in JSON format for loading the configuration.
    /// </summary>
    /// <param name="projectPath">The project data path.</param>
    public static async Task InitializeConfiguration(string projectPath)
    {
        // determine the path to write to.
        var configPath = $@"{projectPath}\{ConfigurationFileName}";
        
        // create the template at the destination.
        await File.WriteAllTextAsync(configPath, ConfigurationTemplate());
    }

    /// <summary>
    /// The hard-coded bare minimum configuration template.
    /// </summary>
    private static string ConfigurationTemplate()
    {
        return
        """
        {
          "recipes":[],
          "categories":[]
        }
        """;
    }
}