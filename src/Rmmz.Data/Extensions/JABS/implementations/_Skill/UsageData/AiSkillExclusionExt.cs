using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.UsageData;

public static class AiSkillExclusionExt
{
    public static bool HasJabsAiSkillExclusion(this RPG_Skill skill)
    {
        return skill.HasBooleanTag(Models.JABS.Tags.AiSkillExclusion.Name);
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
                skill.RemoveNoteData(Models.JABS.Tags.AiSkillExclusion.Regex);
                break;
            // was not previously, but is now.
            case false when isSkillExcluded:
                skill.AddNoteData(Models.JABS.Tags.AiSkillExclusion.ToBooleanTag());
                break;
        }
    }
}