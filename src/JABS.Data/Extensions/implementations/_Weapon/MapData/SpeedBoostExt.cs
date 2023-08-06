using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Extensions.implementations._Weapon.MapData;

public static class SpeedBoostExt
{
    public static decimal GetJabsSpeedBoost(this RPG_Weapon skill)
    {
        return skill.GetFirstNumberByTag(Tags.SpeedBoost.Name) ?? decimal.Zero;
    }

    public static void UpdateJabsSpeedBoost(this RPG_Weapon skill, decimal speedBoost)
    {
        // determine if currently there is a value on it.
        var isMissing = skill.GetJabsSpeedBoost() == decimal.Zero;

        // check if there is no value, and was passed a non-value value.
        if (isMissing && speedBoost == 0)
        {
            // do nothing.
            return;
        }

        // check if we had a value, but are now removing it.
        if (speedBoost == 0)
        {
            // remove the tag entirely, zero is an invalid input.
            skill.RemoveNoteData(Tags.SpeedBoost.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Tags.SpeedBoost.ToValueTag(speedBoost.ToString());

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
            skill.UpdateNoteData(Tags.SpeedBoost.Regex, updatedNote);
        }
    }
}