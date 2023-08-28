namespace JMZ.Sdp.Data.Models;

/// <summary>
/// A single reward of a <see cref="StatDistributionPanel"/>.
/// Contains the name, the rank required to achieve the effect, and the effect to execute.
/// </summary>
public class SdpReward
{
    public string RewardName { get; set; } = "===NEW REWARD===";

    /// <summary>
    /// The rank required to be reached by the parent panel in order to execute the effect.<br/>
    /// If the rank is 0, it translates to "when this panel is maxed".<br/>
    /// If the rank is -1, it translates to "every time this panel ranks up".
    /// </summary>
    public int RankRequired { get; set; } = 0;

    /// <summary>
    /// The effect to execute upon meeting the criteria for execution.<br/>
    /// This is typically just raw javascript in string-form.
    /// </summary>
    public string Effect { get; set; } = string.Empty;
}