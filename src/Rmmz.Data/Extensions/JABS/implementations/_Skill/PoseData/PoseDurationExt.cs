using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.PoseData;

public static class PoseDurationExt
{
    public static decimal GetJabsPoseDuration(this RPG_Skill skill)
    {
        return  skill.GetJabsPoseData().PoseDuration;
    }
}