using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.PiercingData;

public static class PierceCountExt
{
    public static decimal GetJabsPiercingCount(this RPG_Skill skill)
    {
        return  skill.GetJabsPiercingData().PierceCount;
    }
}