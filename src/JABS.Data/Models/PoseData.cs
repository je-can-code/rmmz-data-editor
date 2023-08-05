namespace JMZ.JABS.Data.Models;

/// <summary>
/// A data model representing the pose data of a skill.
/// </summary>
/// <param name="PoseSuffix">
/// The string suffix (without quotes) that defines this pose.
/// </param>
/// <param name="PoseIndex">
/// The index on the sprite sheet that represents this pose.
/// </param>
/// <param name="PoseDuration">
/// The duration in frames that will be spent in this pose.
/// </param>
public readonly record struct PoseData(
    string PoseSuffix = "",
    decimal PoseIndex = decimal.Zero,
    decimal PoseDuration = decimal.Zero);