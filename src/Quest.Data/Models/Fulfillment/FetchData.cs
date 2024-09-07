using JMZ.Quest.Data.Enums;
using Newtonsoft.Json;

namespace JMZ.Quest.Data.Models.Fulfillment;

public record FetchData
{
    public OmniObjectiveFetchType Type { get; set; } = OmniObjectiveFetchType.Unset;

    public int Id { get; set; } = -1;
    public int Amount { get; set; }

    [JsonIgnore]
    public string TypeName => ((OmniObjectiveFetchType)Convert.ToInt32(Type)).ToString();

    public FetchData(OmniObjectiveFetchType type, int id, int amount)
    {
        Type = type;
        Id = id;
        Amount = amount;
    }
}