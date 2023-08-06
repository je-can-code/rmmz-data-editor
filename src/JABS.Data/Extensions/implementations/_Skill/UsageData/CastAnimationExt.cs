using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Extensions.implementations._Skill.UsageData;

public static class CastAnimationExt
{
    public static decimal GetJabsCastAnimation(this RPG_Skill skill)
    {
        return skill.GetFirstNumberByTag(Tags.CastAnimation.Name) ?? decimal.Zero;
    }
    
    public static void UpdateJabsCastAnimation(this RPG_Skill skill, decimal castAnimationId)
    {
        // determine if this skill currently has actionId on it.
        var isMissing = skill.GetJabsCastAnimation() == decimal.Zero;

        // check if there is no castAnimationId and was passed a no-castAnimationId value.
        if (isMissing && castAnimationId == 0)
        {
            // do nothing.
            return;
        }

        // check if we had an actionId, but are now removing it.
        if (castAnimationId == 0)
        {
            // remove the tag entirely, zero is an invalid castAnimationId.
            skill.RemoveNoteData(Tags.CastAnimation.Regex);
            
            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Tags.CastAnimation.ToValueTag(castAnimationId.ToString());

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
            skill.UpdateNoteData(Tags.CastAnimation.Regex, updatedNote);
        }
    }
}