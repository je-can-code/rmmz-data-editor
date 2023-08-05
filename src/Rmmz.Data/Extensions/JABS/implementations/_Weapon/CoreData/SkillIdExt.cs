using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Rmmz.Data.Extensions.JABS.implementations._Weapon.CoreData;

public static class SkillIdExt
{
    public static decimal GetJabsSkillId(this RPG_Weapon skill)
    {
        return skill.GetFirstNumberByTag(Models.JABS.Tags.SkillId.Name) ?? decimal.Zero;
    }

    public static void UpdateJabsSkillId(this RPG_Weapon skill, decimal skillId)
    {
        // determine if currently there is a value on it.
        var isMissing = skill.GetJabsSkillId() == decimal.Zero;

        // check if there is no value, and was passed a non-value value.
        if (isMissing && skillId == 0)
        {
            // do nothing.
            return;
        }

        // check if we had a value, but are now removing it.
        if (skillId == 0)
        {
            // remove the tag entirely, zero is an invalid input.
            skill.RemoveNoteData(Models.JABS.Tags.SkillId.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Models.JABS.Tags.SkillId.ToValueTag(skillId.ToString());

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
            skill.UpdateNoteData(Models.JABS.Tags.SkillId.Regex, updatedNote);
        }
    }
}