using Newtonsoft.Json;

namespace JMZ.Difficulty.Data.Models;

/// <summary>
/// The definition of a single difficulty layer.
/// </summary>
public class DifficultyMetadata
{
    /// <summary>
    /// The unique identifying key associated with this difficulty.
    /// </summary>
    public string Key { get; set; } = string.Empty;
    
    /// <summary>
    /// The name of this difficulty.
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// The icon index of this difficulty.<br/>
    /// A value of 0 represents no icon will be displayed.
    /// </summary>
    public int IconIndex { get; set; } = 0;

    /// <summary>
    /// The description of this difficulty.
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// The layer point cost of this difficulty.
    /// </summary>
    public int Cost { get; set; } = 0;

    /// <summary>
    /// The various parameter-related effects applied to actors when this layer is applied.
    /// </summary>
    public BattlerEffects ActorEffects { get; set; } = new();
    
    /// <summary>
    /// The various parameter-related effects applied to enemies when this layer is applied.
    /// </summary>
    public BattlerEffects EnemyEffects { get; set; } = new();

    /// <summary>
    /// The various reward-related effects applied when this layer is applied.
    /// </summary>
    public RewardEffects Rewards { get; set; } = new();

    /// <summary>
    /// Whether or not this metadata is enabled by default.
    /// </summary>
    [JsonProperty("enabled")]
    public bool EnabledByDefault { get; set; } = false;
    
    /// <summary>
    /// Whether or not this metadata is unlocked by default.
    /// </summary>
    [JsonProperty("unlocked")]
    public bool UnlockedByDefault { get; set; } = false;
    
    /// <summary>
    /// Whether or not this metadata is hidden by default.
    /// </summary>
    [JsonProperty("hidden")]
    public bool HiddenByDefault { get; set; } = false;
}