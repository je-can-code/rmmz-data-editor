using JMZ.Quest.Data.Enums;
using Newtonsoft.Json;

namespace JMZ.Quest.Data.Models;

/// <summary>
///     A data structure representing a single objective and its data.
/// </summary>
public record OmniObjective
{
    public static OmniObjective DefaultTemplate()
    {
        return new(
            0,
            OmniObjectiveType.Indiscriminate,
            string.Empty,
            new(),
            OmniFulfillmentData.DefaultTemplate(),
            true,
            false);
    }

    public static OmniObjective From(OmniObjective otherObjective)
    {
        return new(
            otherObjective.Id,
            otherObjective.Type,
            otherObjective.Description,
            OmniLogs.From(otherObjective.Logs),
            OmniFulfillmentData.From(otherObjective.Fulfillment),
            otherObjective.HiddenByDefault,
            otherObjective.IsOptional);
    }

    public int Id { get; set; }
    public OmniObjectiveType Type { get; set; }
    public string Description { get; set; } = string.Empty;
    public OmniLogs Logs { get; set; } = new();
    public OmniFulfillmentData Fulfillment { get; set; }
    public bool HiddenByDefault { get; set; }
    public bool IsOptional { get; set; }

    [JsonIgnore]
    public string ObjectiveName => ((OmniObjectiveType)Convert.ToInt32(Type)).ToString();

    /// <summary>
    ///     Constructor.
    /// </summary>
    /// <param name="id">The id of the obejctive- should be 1-based instead of 0-based.</param>
    /// <param name="type">The type of the objective.</param>
    /// <param name="description">The over-arching description detailing what the player knows about it.</param>
    /// <param name="logs">The various logs associated with the state of the objective.</param>
    /// <param name="fulfillment">The data points that are dependent on the type of the objective.</param>
    /// <param name="hiddenByDefault">Whether or not this objective is hidden- this should typically be true.</param>
    /// <param name="isOptional">Whether or not this objective is strictly required to complete the quest.</param>
    public OmniObjective(
        int id,
        OmniObjectiveType type,
        string description,
        OmniLogs logs,
        OmniFulfillmentData fulfillment,
        bool hiddenByDefault,
        bool isOptional)
    {
        Id = id;
        Type = type;
        Description = description;
        Logs = logs;
        Fulfillment = fulfillment;
        HiddenByDefault = hiddenByDefault;
        IsOptional = isOptional;
    }
}