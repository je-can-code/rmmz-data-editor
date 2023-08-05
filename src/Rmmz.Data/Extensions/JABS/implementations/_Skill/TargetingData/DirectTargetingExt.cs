using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.TargetingData;

public static class DirectTargetingExt
{
    public static bool HasJabsDirectTargeting(this RPG_Skill skill)
    {
        return skill.HasBooleanTag(Models.JABS.Tags.Direct.Name);
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
                skill.RemoveNoteData(Models.JABS.Tags.Direct.Regex);
                break;
            // was not previously, but is now.
            case false when directTargeting:
                skill.AddNoteData(Models.JABS.Tags.Direct.ToBooleanTag());
                break;
        }
    }
}