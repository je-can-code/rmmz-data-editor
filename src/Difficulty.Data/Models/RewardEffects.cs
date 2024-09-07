using Newtonsoft.Json;

namespace JMZ.Difficulty.Data.Models;

/// <summary>
///     All the various multipliers that apply against the player's acquisition of rewards.
/// </summary>
public class RewardEffects
{
    /// <summary>
    ///     The 100-based-multiplier against experience while this layer is applied.
    /// </summary>
    [JsonProperty("exp")]
    public int Experience { get; set; } = 100;

    /// <summary>
    ///     The 100-based-multiplier against gold while this layer is applied.
    /// </summary>
    public int Gold { get; set; } = 100;

    /// <summary>
    ///     The 100-based-multiplier against experience while this layer is applied.
    /// </summary>
    public int Drops { get; set; } = 100;

    /// <summary>
    ///     The 100-based-multiplier against experience while this layer is applied.
    /// </summary>
    public int Encounters { get; set; } = 100;

    /// <summary>
    ///     The 100-based-multiplier against experience while this layer is applied.
    /// </summary>
    [JsonProperty("sdp")]
    public int SdpPoints { get; set; } = 100;
}