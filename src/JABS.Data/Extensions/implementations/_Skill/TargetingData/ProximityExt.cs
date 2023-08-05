using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Extensions.implementations._Skill.TargetingData;

public static class ProximityExt
{
    public static decimal GetJabsProximity(this RPG_Skill skill)
    {
        return skill.GetFirstNumberByTag(Tags.Proximity.Name, true) ?? -1;
    }

    public static void UpdateJabsProximity(this RPG_Skill skill, decimal proximity)
    {
        // grab our current state.
        var isMissing = skill.GetJabsProximity() < 0;

        // check if there was no value and is no value, do not update.
        if (isMissing && proximity < 0)
        {
            // do nothing.
            return;
        }

        // check if there was a value but is no longer.
        if (proximity < 0)
        {
            // remove the note, it is no longer needed.
            skill.RemoveNoteData(Tags.Proximity.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new value.
        var updatedNote = Tags.Proximity.ToValueTag(proximity.ToString());

        // check if the value was missing previously.
        if (isMissing)
        {
            // add the new tag to the note.
            skill.AddNoteData(updatedNote);
        }
        // the value just needs to be updated.
        else
        {
            // update the actual note.
            skill.UpdateNoteData(Tags.Proximity.Regex, updatedNote);   
        }
    }
}