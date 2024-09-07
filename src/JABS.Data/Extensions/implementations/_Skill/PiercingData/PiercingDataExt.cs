using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;
using PiercingDataRecord = JMZ.JABS.Data.Models.PiercingData;

namespace JMZ.JABS.Data.Extensions.implementations._Skill.PiercingData;

internal static class PiercingDataExt
{
    internal static PiercingDataRecord GetJabsPiercingData(this RPG_Skill skill)
    {
        // grab the number data from the string array.
        var data = skill.GetAllNumbersByTag(Tags.Pierce.Name) ?? [];

        // if there are no numbers, then there is no piercing data.
        if (!data.Any())
        {
            // return an empty set.
            return new();
        }

        // return what the collection contained for piercing data.
        return new(data[0], data[1]);
    }

    internal static void UpdateJabsPiercingData(
        this RPG_Skill skill,
        decimal newPiercingCount,
        decimal newPiercingDelay)
    {
        // determine if this skill is missing piercing data.
        var isMissing = skill.GetJabsPiercingCount() == decimal.Zero;

        // check if there is no value and was passed a no-data value.
        if (isMissing && newPiercingCount == decimal.Zero)
        {
            // do nothing.
            return;
        }

        // check if the tag became empty but had a value previously.
        if (newPiercingCount == decimal.Zero)
        {
            // remove the tag entirely.
            skill.RemoveNoteData(Tags.Pierce.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Tags.Pierce.ToArrayTag(newPiercingCount.ToString(), newPiercingDelay.ToString());

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
            skill.UpdateNoteData(Tags.Pierce.Regex, updatedNote);
        }
    }
}