using JMZ.Quest.Data.Enums;
using Newtonsoft.Json;

namespace JMZ.Quest.Data.Models;

/// <summary>
/// A data structure representing a single objective and its data.
/// </summary>
public record OmniObjective
{
    public int Id { get; set; } = 0;
    public int Type { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public OmniLogs Logs { get; set; } = new();
    public List<object> FulfillmentData { get; set; } = new(5);
    public string[] FulfillmentQuestKeys { get; set; } = [];
    public bool HiddenByDefault { get; set; } = false;
    public bool IsOptional { get; set; } = false;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id">The id of the obejctive- should be 1-based instead of 0-based.</param>
    /// <param name="type">The type of the objective.</param>
    /// <param name="description">The over-arching description detailing what the player knows about it.</param>
    /// <param name="logs">The various logs associated with the state of the objective.</param>
    /// <param name="fulfillmentData">The data points that are dependent on the type of the objective.</param>
    /// <param name="fulfillmentQuestKeys">The quest keys that may be required to complete the objective.</param>
    /// <param name="hiddenByDefault">Whether or not this objective is hidden- this should typically be true.</param>
    /// <param name="isOptional">Whether or not this objective is strictly required to complete the quest.</param>
    public OmniObjective(
        int id,
        int type,
        string description,
        OmniLogs logs,
        List<object> fulfillmentData,
        string[] fulfillmentQuestKeys,
        bool hiddenByDefault,
        bool isOptional)
    {
        Id = id;
        Type = type;
        Description = description;
        Logs = logs;
        FulfillmentData = fulfillmentData;
        FulfillmentQuestKeys = fulfillmentQuestKeys;
        HiddenByDefault = hiddenByDefault;
        IsOptional = isOptional;
    }

    [JsonIgnore]
    public string ObjectiveName => ((OmniObjectiveType)Convert.ToInt32(Type)).ToString();
    
    [JsonIgnore]
    public string IndiscriminateData => FulfillmentData[0].ToString()!;
    
    [JsonIgnore]
    public int DestinationMapId => Convert.ToInt32(FulfillmentData[0]);
    
    [JsonIgnore]
    public int DestinationX1 => Convert.ToInt32(FulfillmentData[1]);
    
    [JsonIgnore]
    public int DestinationY1 => Convert.ToInt32(FulfillmentData[2]);
    
    [JsonIgnore]
    public int DestinationX2 => Convert.ToInt32(FulfillmentData[3]);
    
    [JsonIgnore]
    public int DestinationY2 => Convert.ToInt32(FulfillmentData[4]);
    
    [JsonIgnore]
    public string FetchTypeName => ((OmniObjectiveFetchType)Convert.ToInt32(FulfillmentData[0])).ToString();
    
    [JsonIgnore]
    public OmniObjectiveFetchType FetchType => (OmniObjectiveFetchType)Convert.ToInt32(FulfillmentData[0]);
    
    [JsonIgnore]
    public int FetchTypeId => Convert.ToInt32(FulfillmentData[1]);
    
    [JsonIgnore]
    public int FetchAmount => Convert.ToInt32(FulfillmentData[2]);
    
    [JsonIgnore]
    public int SlayEnemyId => Convert.ToInt32(FulfillmentData[0]);
    
    [JsonIgnore]
    public int SlayAmount => Convert.ToInt32(FulfillmentData[1]);

    public void SetIndiscriminateData(string data)
    {
        FulfillmentData = [data];
    }

    public void SetDestinationData(List<int> destinationData)
    {
        FulfillmentData = destinationData.Cast<object>().ToList();
    }

    public void SetFetchData(List<int> fetchData)
    {
        FulfillmentData = fetchData.Cast<object>().ToList();
    }

    public void SetSlayData(List<int> slayData)
    {
        FulfillmentData = slayData.Cast<object>().ToList();
    }
    
    public void SetQuestKeys(string questKeysString)
    {
        FulfillmentData ??= new(5);
        FulfillmentQuestKeys = questKeysString.Split(',');
    }
}