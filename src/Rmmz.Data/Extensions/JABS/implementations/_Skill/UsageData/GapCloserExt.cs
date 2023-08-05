using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.UsageData;

public static class GapCloserExt
{
    public static bool HasJabsGapCloser(this RPG_Skill skill)
    {
        return skill.HasBooleanTag(Models.JABS.Tags.GapCloser.Name);
    }
    
    public static void UpdateJabsGapCloser(this RPG_Skill skill, bool canGapClose)
    {
        // check what our current state is.
        var currentState = skill.HasJabsGapCloser();

        // determine what action to take.
        switch (currentState)
        {
            // was before and still is.
            case true when canGapClose:
                return;
            // was previously but is not any longer.
            case true:
                skill.RemoveNoteData(Models.JABS.Tags.GapCloser.Regex);
                break;
            // was not previously, but is now.
            case false when canGapClose:
                skill.AddNoteData(Models.JABS.Tags.GapCloser.ToBooleanTag());
                break;
        }
    }
}