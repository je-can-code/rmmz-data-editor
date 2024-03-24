namespace JMZ.Sdp.Data;

/// <summary>
/// A utility class for initializing data related to the SDP plugin.
/// </summary>
public static class SdpInitializer
{
    /// <summary>
    /// The name of the configuration file associated with this system.
    /// </summary>
    public static string ConfigurationFileName => "config.sdp.json";

    /// <summary>
    /// Initialize the bare minimum required in JSON format for loading the configuration.
    /// </summary>
    /// <param name="projectPath">The project data path.</param>
    public static async Task InitializeConfiguration(string projectPath)
    {
        var configPath = $@"{projectPath}\{ConfigurationFileName}";
        await File.WriteAllTextAsync(configPath, ConfigurationTemplate());
    }
    
    /// <summary>
    /// The hard-coded bare minimum configuration template.
    /// </summary>
    private static string ConfigurationTemplate()
    {
        return
        """
        [
        ]
        """;
    }
}