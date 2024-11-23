using JMZ.Quest.Data.Enums;
using JMZ.Quest.Data.Models.Fulfillment;

namespace JMZ.Quest.Data.Models;

public record OmniFulfillmentData
{
    public static OmniFulfillmentData DefaultTemplate()
    {
        return new(
            new(),
            new(-1, -1, -1, -1, -1),
            new(OmniObjectiveFetchType.Unset, 0, 0),
            new(0, 0),
            new([]));
    }

    public static OmniFulfillmentData From(OmniFulfillmentData otherFulfillmentData)
    {
        return new(
            otherFulfillmentData.Indiscriminate with {},
            otherFulfillmentData.Destination with {},
            otherFulfillmentData.Fetch with {},
            otherFulfillmentData.Slay with {},
            otherFulfillmentData.Quest with {});
    }

    public IndiscriminateData Indiscriminate { get; set; }

    public DestinationData Destination { get; set; }

    public FetchData Fetch { get; set; }

    public SlayData Slay { get; set; }

    public QuestData Quest { get; set; }

    public OmniFulfillmentData(
        IndiscriminateData? indiscriminate,
        DestinationData? destination,
        FetchData? fetch,
        SlayData? slay,
        QuestData? quest)
    {
        Indiscriminate = indiscriminate ?? new();
        Destination = destination ?? new(-1, -1, -1, -1, -1);
        Fetch = fetch ?? new(OmniObjectiveFetchType.Unset, 0, 0);
        Slay = slay ?? new(0, 0);
        Quest = quest ?? new([]);
    }
}