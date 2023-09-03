namespace JMZ.Sdp.Data.Models;

/// <summary>
/// The various data points that together represent a single "stat distribution panel" in the context
/// of the SDP system.
/// </summary>
public class StatDistributionPanel
{
    /// <summary>
    /// The name of this panel.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The unique identifying key associated with this panel.
    /// </summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// The icon index of this panel.<br/>
    /// A value of 0 represents no icon will be displayed.
    /// </summary>
    public int IconIndex { get; set; } = 0;

    /// <summary>
    /// Whether or not this panel comes unlocked when first acquired.
    /// </summary>
    public bool UnlockedByDefault { get; set; } = false;

    /// <summary>
    /// The description of this panel that will show up in the help window in the SDP scene.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The flavor text that is within the panel details screen itself.
    /// </summary>
    public string TopFlavorText { get; set; } = string.Empty;

    /// <summary>
    /// The maximum rank this panel can reach.
    /// </summary>
    public int MaxRank { get; set; } = 1;

    /// <summary>
    /// The base cost that is added to the rank-based growth.
    /// </summary>
    public decimal BaseCost { get; set; } = 50;

    /// <summary>
    /// The flat amount that is part of the cost multiplied by the level and multiplicative growth amount.
    /// </summary>
    public decimal FlatGrowthCost { get; set; } = 1.0m;
    
    /// <summary>
    /// The multiplicative factor that is multiplied against the sum of base cost plus flat growth amount.
    /// </summary>
    public decimal MultGrowthCost { get; set; } = 1.0m;

    /// <summary>
    /// The parameters that grow in some way as a result of this panel ranking up.
    /// </summary>
    public List<SdpParameter> PanelParameters { get; set; } = new();

    /// <summary>
    /// The rewards that are earned based on the rank.
    /// </summary>
    public List<SdpReward> PanelRewards { get; set; } = new();
    
    /// <summary>
    /// The rarity of the panel.
    /// </summary>
    public int Rarity { get; set; } = 0;
}