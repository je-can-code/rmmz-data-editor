using JMZ.Rmmz.Data.Models.JABS.implementations;

namespace JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.PoseData;

public static class PoseSuffixExt
{
    public static string GetJabsPoseSuffix(this RPG_Skill skill)
    {
        return skill.GetJabsPoseData().PoseSuffix;
    }
}