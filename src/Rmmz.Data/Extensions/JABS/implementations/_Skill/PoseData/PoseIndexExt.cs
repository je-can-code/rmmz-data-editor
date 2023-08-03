using JMZ.Rmmz.Data.Models.JABS.implementations;

namespace JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.PoseData;

public static class PoseIndexExt
{
    public static decimal GetJabsPoseIndex(this RPG_Skill skill)
    {
        return skill.GetJabsPoseData().PoseIndex;
    }
}