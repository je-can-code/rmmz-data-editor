namespace JMZ.JABS.Data.Models;

/// <summary>
/// A data model representing the combo data for a skill.
/// </summary>
/// <param name="ComboSkill">
/// The id of the skill that is next in the combo sequence.
/// </param>
/// <param name="ComboDelay">
/// The number of frames that must pass before the combo skill can be triggered.
/// </param>
public readonly record struct ComboData(
    decimal ComboSkill = decimal.Zero,
    decimal ComboDelay = decimal.Zero);