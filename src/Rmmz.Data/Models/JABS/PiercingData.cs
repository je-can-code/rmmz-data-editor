namespace JMZ.Rmmz.Data.Models.JABS;

public readonly record struct PiercingData(
    decimal PierceCount = decimal.Zero,
    decimal PierceDelay = decimal.Zero);