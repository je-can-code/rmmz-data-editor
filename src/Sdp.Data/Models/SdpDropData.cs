namespace JMZ.Sdp.Data.Models;

/// <summary>
///     A data model representing the sdp drop data for an enemy.
/// </summary>
/// <param name="Key">
///     The key of the panel that this enemy owns.
/// </param>
/// <param name="ItemId">
///     The id of the item dropped that represents this sdp.
/// </param>
/// <param name="DropChance">
///     The integer percent chance of this panel dropping from this enemy.
/// </param>
public readonly record struct SdpDropData(string Key, decimal ItemId, decimal DropChance = decimal.One);