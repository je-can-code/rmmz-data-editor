using Newtonsoft.Json;

namespace JMZ.Crafting.Data.Models;

/// <summary>
///     A single instance of a particular crafting component.
///     Tools, ingredients, and output are classified as components.
/// </summary>
public class Component
{
    /// <summary>
    ///     The underlying base name data.
    /// </summary>
    [JsonIgnore]
    private string _Name = string.Empty;

    /// <summary>
    ///     True if this component is missing a display name, false otherwise.
    /// </summary>
    [JsonIgnore]
    public bool MissingDisplayName => string.IsNullOrWhiteSpace(_Name);

    /// <summary>
    ///     The name of the component; used for display purposes only.
    /// </summary>
    [JsonIgnore]
    public string Name
    {
        get => $"{Type} : {Id} : {_Name} : x{Count}";
        set => _Name = value;
    }

    /// <summary>
    ///     The name of the component with the Count marked as the drop chance.
    ///     Used for display purposes only.
    /// </summary>
    [JsonIgnore]
    public string DropChanceName
    {
        get => $"{Type} : {Id} : {_Name} : {Count}%";
        set => _Name = value;
    }

    /// <summary>
    ///     The id of the underlying component.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     The type of component this is.
    /// </summary>
    public string Type { get; set; } = "i";

    /// <summary>
    ///     The count of this component.
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    ///     Returns a clone of this component in its current state.
    /// </summary>
    /// <returns></returns>
    public Component Clone()
    {
        return new()
        {
            Count = Count,
            Id = Id,
            Name = _Name,
            Type = Type
        };
    }
}