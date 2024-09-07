namespace JMZ.Sdp.Data.Models;

/// <summary>
///     The "long" parameter id mapping as an enum.
///     The indexes align with the "long parameter id" format.
/// </summary>
public enum LongParameter
{
    // b-params
    MaxLife = 0,
    MaxMagi = 1,
    Power = 2,
    Endurance = 3,
    Force = 4,
    Resistance = 5,
    Speed = 6,
    Luck = 7,

    // s-params
    Accuracy = 8,
    ParryExtend = 9,
    CritRate = 10,
    CritDodge = 11,
    MagicEvade = 12,
    MagicReflect = 13,
    Autocounter = 14,
    HpRegen = 15,
    MpRegen = 16,
    TpRegen = 17,

    // x-params
    Aggro = 18,
    Parry = 19,
    HealingRate = 20,
    ItemEffects = 21,
    MagiCost = 22,
    TechCost = 23,
    PhysDmgRate = 24,
    MagiDmgRate = 25,
    LightFooted = 26,
    ExperienceUp = 27,

    // custom params
    CritAmp = 28,
    CritBlock = 29,
    MaxTech = 30,
    MoveBoost = 31,
    ProficiencyBoost = 32
}