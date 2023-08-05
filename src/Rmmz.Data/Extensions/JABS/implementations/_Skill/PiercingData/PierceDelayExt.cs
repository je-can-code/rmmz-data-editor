using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.PiercingData;

public static class PierceDelayExt
{
    public static decimal GetJabsPiercingDelay(this RPG_Skill skill)
    {
        return skill.GetJabsPiercingData().PierceDelay;
    }
}