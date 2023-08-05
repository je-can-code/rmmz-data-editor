using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Extensions.implementations._Skill.UsageData;

public static class CooldownExt
{
    public static decimal GetJabsCooldown(this RPG_Skill skill)
    {
        return skill.GetFirstNumberByTag(Tags.Cooldown.Name) ?? decimal.Zero;
    }
    
    public static void UpdateJabsCooldown(this RPG_Skill skill, decimal cooldown)
    {
        // determine if this skill currently has a value on it.
        var isMissing = skill.GetJabsCooldown() == decimal.Zero;

        // check if there is no value, and was passed a non-value value.
        if (isMissing && cooldown == 0)
        {
            // do nothing.
            return;
        }

        // check if we had a value, but are now removing it.
        if (cooldown == 0)
        {
            // remove the tag entirely, zero is an invalid cooldown.
            skill.RemoveNoteData(Tags.Cooldown.Regex);
            
            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Tags.Cooldown.ToValueTag(cooldown.ToString());

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
            skill.UpdateNoteData(Tags.Cooldown.Regex, updatedNote);
        }
    }
}