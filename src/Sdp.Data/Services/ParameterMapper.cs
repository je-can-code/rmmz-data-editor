using JMZ.Sdp.Data.Models;

namespace JMZ.Sdp.Data.Services;

public static class ParameterMapper
{
    public static string namegetter(LongParameter longParameter)
    {
        return longParameter.ToString();
    }

    public static string NameFromLongParameterId(int longParameterId)
    {
        return longParameterId switch
        {
            // bparam IDs 0-7.
            >= 0 and <= 7 => ToBparamName(longParameterId),

            // xparam IDs 0-9 (8-17).
            > 7 and <= 17 => ToXparamName(longParameterId - 8),

            // sparam IDs 0-9 (18-27).
            > 17 and <= 27 => ToSparamName(longParameterId - 18),

            // custom parameter IDs start at 28, and go up indefinitely.
            > 27 => ToCustomName(longParameterId - 28),

            // anything else, such as negative numbers, is invalid.
            _ => throw new($"unexpected long parameter ID provided: {longParameterId}.")
        };
    }

    private static string ToBparamName(int bparamId)
    {
        return bparamId switch
        {
            0 => "MaxLife",
            1 => "MaxMagi",
            2 => "Power",
            3 => "Endurance",
            4 => "Force",
            5 => "Resistance",
            6 => "Speed",
            7 => "Luck",
            _ => throw new($"unexpected b-param ID provided: {bparamId}.")
        };
    }

    private static string ToXparamName(int xparamId)
    {
        return xparamId switch
        {
            0 => "Accuracy",
            1 => "Parry Extend",
            2 => "Crit Rate",
            3 => "Crit Dodge",
            4 => "Magic Evade",
            5 => "Magic Reflect",
            6 => "Autocounter",
            7 => "HP Regen",
            8 => "MP Regen",
            9 => "TP Regen",
            _ => throw new($"unexpected x-param ID provided: {xparamId}.")
        };
    }

    private static string ToSparamName(int sparamId)
    {
        return sparamId switch
        {
            0 => "Aggro",
            1 => "Parry",
            2 => "Healing Rate",
            3 => "Item Effects",
            4 => "Magi Cost",
            5 => "Tech Cost",
            6 => "Phys Dmg Rate",
            7 => "Magi Dmg Rate",
            8 => "Light-footed",
            9 => "Experience UP",
            _ => throw new($"unexpected s-param ID provided: {sparamId}.")
        };
    }

    private static string ToCustomName(int cparamId)
    {
        return cparamId switch
        {
            0 => "Crit Amp",
            1 => "Crit Block",
            2 => "Max Tech",
            3 => "Move Boost",
            4 => "Proficiency+",
            _ => throw new($"unexpected  custom-param ID provided: {cparamId}.")
        };
    }
}