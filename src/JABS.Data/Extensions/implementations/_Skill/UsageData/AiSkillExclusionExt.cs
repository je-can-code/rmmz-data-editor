using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Extensions.implementations._Skill.UsageData;

public static class AiSkillExclusionExt
{
    public static bool HasJabsAiSkillExclusion(this RPG_Skill skill)
    {
        return skill.HasBooleanTag(Tags.AiSkillExclusion.Name);
    }
    
    public static void UpdateJabsAiSkillExclusion(this RPG_Skill skill, bool isSkillExcluded)
    {
        // check what our current state is.
        var currentState = skill.HasJabsAiSkillExclusion();

        // determine what action to take.
        switch (currentState)
        {
            // was before and still is.
            case true when isSkillExcluded:
                return;
            // was previously but is not any longer.
            case true:
                skill.RemoveNoteData(Tags.AiSkillExclusion.Regex);
                break;
            // was not previously, but is now.
            case false when isSkillExcluded:
                skill.AddNoteData(Tags.AiSkillExclusion.ToBooleanTag());
                break;
        }
    }
}