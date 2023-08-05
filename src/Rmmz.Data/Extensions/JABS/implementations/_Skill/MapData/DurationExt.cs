using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.MapData;

public static class DurationExt
{
    public static decimal GetJabsDuration(this RPG_Skill skill)
    {
        return skill.GetFirstNumberByTag(Models.JABS.Tags.Duration.Name) ?? decimal.Zero;
    }
    
    public static void UpdateJabsDuration(this RPG_Skill skill, decimal duration)
    {
        // determine if this skill currently has value on it.
        var isMissing = skill.GetJabsDuration() == decimal.Zero;

        // check if there is no actionId and was passed a no-actionId value.
        if (isMissing && duration == 0)
        {
            // do nothing.
            return;
        }

        // check if we had an actionId, but are now removing it.
        if (duration == 0)
        {
            // remove the tag entirely, zero is an invalid actionId.
            skill.RemoveNoteData(Models.JABS.Tags.Duration.Regex);
            
            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Models.JABS.Tags.Duration.ToValueTag(duration.ToString());

        // check if the actionId was missing previously.
        if (isMissing)
        {
            // add the new tag to the note.
            skill.AddNoteData(updatedNote);
        }
        // the actionId just needs to be updated.
        else
        {
            // update the actual note.
            skill.UpdateNoteData(Models.JABS.Tags.Duration.Regex, updatedNote);
        }
    }
}