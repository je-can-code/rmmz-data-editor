using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Extensions.implementations._Skill.TargetingData;

public static class DirectTargetingExt
{
    public static bool HasJabsDirectTargeting(this RPG_Skill skill)
    {
        return skill.HasBooleanTag(Tags.Direct.Name);
    }
    
    public static void UpdateJabsDirectTargeting(this RPG_Skill skill, bool directTargeting)
    {
        // check what our current state is.
        var currentlyEnabled = skill.HasJabsDirectTargeting();

        // determine what action to take.
        switch (currentlyEnabled)
        {
            // was before and still is.
            case true when directTargeting:
                return;
            // was previously but is not any longer.
            case true:
                skill.RemoveNoteData(Tags.Direct.Regex);
                break;
            // was not previously, but is now.
            case false when directTargeting:
                skill.AddNoteData(Tags.Direct.ToBooleanTag());
                break;
        }
    }
}