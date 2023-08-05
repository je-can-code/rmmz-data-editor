using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Extensions.implementations._Skill.PoseData;

public static class PoseSuffixExt
{
    public static string GetJabsPoseSuffix(this RPG_Skill skill)
    {
        return skill.GetJabsPoseData().PoseSuffix;
    }
}