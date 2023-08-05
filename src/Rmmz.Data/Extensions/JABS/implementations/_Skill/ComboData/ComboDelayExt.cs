using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.ComboData;

public static class ComboDelayExt
{
    public static decimal GetJabsComboDelay(this RPG_Skill skill)
    {
        return skill.GetJabsComboData().ComboDelay;
    }
}