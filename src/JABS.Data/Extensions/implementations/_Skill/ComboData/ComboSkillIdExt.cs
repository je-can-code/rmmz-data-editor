﻿using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Extensions.implementations._Skill.ComboData;

public static class ComboSkillIdExt
{
    public static decimal GetJabsComboSkillId(this RPG_Skill skill)
    {
        return skill.GetJabsComboData()
            .ComboSkill;
    }
}