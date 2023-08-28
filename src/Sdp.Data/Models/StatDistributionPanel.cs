namespace JMZ.Sdp.Data.Models;

public class StatDistributionPanel
{
    public string Name { get; set; } = string.Empty;

    public string Key { get; set; } = string.Empty;

    public int IconIndex { get; set; } = 0;

    public bool Unlocked { get; set; } = false;

    public string Description { get; set; } = string.Empty;

    public string TopFlavorText { get; set; } = string.Empty;

    public int MaxRank { get; set; } = 1;

    public decimal BaseCost { get; set; } = 50;

    public decimal FlatGrowthCost { get; set; } = 1.0m;
    
    public decimal MultGrowthCost { get; set; } = 1.0m;

    public List<SdpParameter> PanelParameters { get; set; } = new();

    public List<SdpReward> PanelRewards { get; set; } = new();
    
    public int Rarity { get; set; } = 0;
}