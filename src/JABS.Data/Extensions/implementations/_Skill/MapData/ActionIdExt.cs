using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Extensions.implementations._Skill.MapData;

public static class ActionIdExt
{
    public static decimal GetJabsActionId(this RPG_Skill skill)
    {
        return skill.GetFirstNumberByTag(Tags.ActionId.Name) ?? decimal.Zero;
    }

    public static void UpdateJabsActionId(this RPG_Skill skill, decimal actionId)
    {
        // determine if this skill currently has actionId on it.
        var missingActionId = skill.GetJabsActionId() == decimal.Zero;

        // check if there is no actionId and was passed a no-actionId value.
        if (missingActionId && actionId == 0)
        {
            // do nothing.
            return;
        }

        // check if we had an actionId, but are now removing it.
        if (actionId == 0)
        {
            // remove the tag entirely, zero is an invalid actionId.
            skill.RemoveNoteData(Tags.ActionId.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Tags.ActionId.ToValueTag(actionId.ToString());

        // check if the value was missing previously.
        if (missingActionId)
        {
            // add the new tag to the note.
            skill.AddNoteData(updatedNote);
        }
        // the value just needs to be updated.
        else
        {
            // update the actual note.
            skill.UpdateNoteData(Tags.ActionId.Regex, updatedNote);
        }
    }
}