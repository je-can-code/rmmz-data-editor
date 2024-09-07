using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Extensions.implementations._Skill.ComboData;

public static class AiComboStarterExt
{
    public static bool HasJabsAiComboStarter(this RPG_Skill skill)
    {
        return skill.HasBooleanTag(Tags.AiComboStarter.Name);
    }

    public static void UpdateJabsAiComboStarter(this RPG_Skill skill, bool freeCombo)
    {
        // check what our current state is.
        var currentlyEnabled = skill.HasJabsAiComboStarter();

        // determine what action to take.
        switch (currentlyEnabled)
        {
            // was before and still is.
            case true when freeCombo:
                return;
            // was previously but is not any longer.
            case true:
                skill.RemoveNoteData(Tags.AiComboStarter.Regex);
                break;
            // was not previously, but is now.
            case false when freeCombo:
                skill.AddNoteData(Tags.AiComboStarter.ToBooleanTag());
                break;
        }
    }
}