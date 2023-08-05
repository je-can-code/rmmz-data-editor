using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.ComboData;

public static class FreeComboExt
{
    public static bool HasJabsFreeCombo(this RPG_Skill skill)
    {
        return skill.HasBooleanTag(Models.JABS.Tags.Direct.Name);
    }
    
    public static void UpdateJabsFreeCombo(this RPG_Skill skill, bool freeCombo)
    {
        // check what our current state is.
        var currentlyEnabled = skill.HasJabsFreeCombo();

        // determine what action to take.
        switch (currentlyEnabled)
        {
            // was before and still is.
            case true when freeCombo:
                return;
            // was previously but is not any longer.
            case true:
                skill.RemoveNoteData(Models.JABS.Tags.FreeCombo.Regex);
                break;
            // was not previously, but is now.
            case false when freeCombo:
                skill.AddNoteData(Models.JABS.Tags.FreeCombo.ToBooleanTag());
                break;
        }
    }
}