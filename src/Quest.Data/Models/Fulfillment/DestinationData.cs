namespace JMZ.Quest.Data.Models.Fulfillment;

public record DestinationData
{
    public int MapId { get; set; } = -1;

    public int X1 { get; set; } = -1;
    public int Y1 { get; set; } = -1;

    public int X2 { get; set; } = -1;
    public int Y2 { get; set; } = -1;

    public DestinationData(int mapId, int x1, int y1, int x2, int y2)
    {
        MapId = mapId;
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
    }
}