using JMZ.Extend.Data.Models;
using JMZ.Rmmz.Data.Extensions;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Extend.Data.Extensions.implementations._Skill;

// TODO: should this be managed as a collection of numbers?
public static class SkillExtensionIdsExt
{
    public static string GetSkillExtendIds(this RPG_Skill skill)
    {
        // grab the contents of the list- we don't question what is within!
        var extensions = skill.GetFirstStringByTag(Tags.Extend.Name) ?? string.Empty;

        // remove the outer brackets.
        return extensions.UnwrapBrackets();
    }

    public static void UpdateSkillExtendIds(this RPG_Skill skill, string extensions)
    {
        // determine if this skill currently has no value assigned.
        var isMissing = skill.GetSkillExtendIds() == string.Empty;

        // check if we have no value and were provided no value to update with.
        if (isMissing && extensions == string.Empty)
        {
            // do nothing.
            return;
        }

        // check if we had a value, but are now removing it.
        if (extensions == string.Empty)
        {
            // remove the tag entirely, no value is invalid.
            skill.RemoveNoteData(Tags.Extend.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Tags.Extend.ToArrayTag(extensions);

        // check if the value was missing previously.
        if (isMissing)
        {
            // add the new tag to the note.
            skill.AddNoteData(updatedNote);
        }
        // the data just needs to be updated.
        else
        {
            // update the actual note.
            skill.UpdateNoteData(Tags.Extend.Regex, updatedNote);
        }
    }
}