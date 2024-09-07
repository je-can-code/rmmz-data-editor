namespace JMZ.JABS.Data.Models;

/// <summary>
///     A data model representing the piercing data on a skill.
/// </summary>
/// <param name="PierceCount">
///     The number of times this skill can pierce a target.
/// </param>
/// <param name="PierceDelay">
///     The number of frames of delay between each triggered pierce hit.
/// </param>
public readonly record struct PiercingData(decimal PierceCount = decimal.Zero, decimal PierceDelay = decimal.Zero);