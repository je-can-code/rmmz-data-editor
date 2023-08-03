namespace JMZ.Rmmz.Data.Models.JABS;

public readonly record struct PoseData(
    string PoseSuffix = "",
    decimal PoseIndex = decimal.Zero,
    decimal PoseDuration = decimal.Zero);