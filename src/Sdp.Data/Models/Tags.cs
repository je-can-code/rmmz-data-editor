using JMZ.Rmmz.Data.Tags;

namespace JMZ.Sdp.Data.Models;

public static class Tags
{
    public static Tag DropData { get; }

    public static Tag Points { get; }

    static Tags()
    {
        DropData = dropData();
        Points = points();
    }

    private static Tag dropData()
    {
        var tag = "sdpDropData";
        var regex = @"<sdpDropData:[ ]?(\[[-\w]+,[ ]?\d+(:?,[ ]?\d+)?])>";
        var description = "The drop information relating to SDP data.\n"
            + "\n"
            + "If any of it is missing or invalid, it will not be used by the SDP plugin.";
        return new(tag, regex, description);
    }

    private static Tag points()
    {
        var tag = "sdpPoints";
        var regex = @"<sdpPoints:[ ]?(\d+)>";
        var description = "The number of points this enemy will grant the player upon defeat.";
        return new(tag, regex, description);
    }
}