using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.TargetingData;

public static class ProximityExt
{
    public static decimal GetJabsProximity(this RPG_Skill skill)
    {
        return skill.getAsNumberByTag(Models.JABS.Tags.Proximity.Name) ?? decimal.Zero;
    }

    public static void UpdateJabsProximity(this RPG_Skill skill, decimal proximity)
    {
        // grab our current state.
        var currentProximity = skill.GetJabsProximity();

        // check if there was no proximity and is no proximity, do not update.
        if (currentProximity < 0 && proximity < 0)
        {
            // do nothing.
            return;
        }

        // check if there was a proximity but is no longer.
        if (proximity < 0 && currentProximity >= 0)
        {
            // remove the note, it is no longer needed.
            skill.RemoveNoteData(Models.JABS.Tags.Proximity.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new value.
        var updatedNote = Models.JABS.Tags.Proximity.ToValueTag(proximity.ToString());
        
        // update the actual note.
        skill.UpdateNoteData(Models.JABS.Tags.Proximity.Regex, updatedNote);
    }
}