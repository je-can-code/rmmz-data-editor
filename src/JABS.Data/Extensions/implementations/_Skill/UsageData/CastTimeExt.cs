using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Extensions.implementations._Skill.UsageData;

public static class CastTimeExt
{
    public static decimal GetJabsCastTime(this RPG_Skill skill)
    {
        return skill.GetFirstNumberByTag(Tags.CastTime.Name) ?? decimal.Zero;
    }

    public static void UpdateJabsCastTime(this RPG_Skill skill, decimal castTime)
    {
        // determine if this skill currently has actionId on it.
        var isMissing = skill.GetJabsCastTime() == decimal.Zero;

        // check if there is no castAnimationId and was passed a no-castAnimationId value.
        if (isMissing && castTime == 0)
        {
            // do nothing.
            return;
        }

        // check if we had an actionId, but are now removing it.
        if (castTime == 0)
        {
            // remove the tag entirely, zero is an invalid castAnimationId.
            skill.RemoveNoteData(Tags.CastTime.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Tags.CastTime.ToValueTag(castTime.ToString());

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
            skill.UpdateNoteData(Tags.CastTime.Regex, updatedNote);
        }
    }
}