﻿using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;
using PiercingDataRecord = JMZ.Rmmz.Data.Models.JABS.PiercingData;

namespace JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.PiercingData;

internal static class PiercingDataExt
{
    internal static PiercingDataRecord GetJabsPiercingData(this RPG_Skill skill)
    {
        // grab the number data from the string array.
        var data = skill.GetAllNumbersByTag(Models.JABS.Tags.Pierce.Name) ?? new();

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
        // grab the current pose suffix for this skill.
        var piercingCount = skill.GetJabsPiercingCount();

        // determine if this skill is missing a pose suffix.
        var missingPiercingCount = piercingCount == decimal.Zero;

        // check if there is no value and was passed a no-data value.
        if (missingPiercingCount && newPiercingCount == decimal.Zero)
        {
            // do nothing.
            return;
        }

        // check if the tag became empty but had a value previously.
        if (newPiercingCount == decimal.Zero)
        {
            // remove the tag entirely.
            skill.RemoveNoteData(Models.JABS.Tags.Pierce.Regex);

            // stop processing.
            return;
        }
        
        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Models.JABS.Tags.Pierce.ToArrayTag(
            newPiercingCount.ToString(),
            newPiercingDelay.ToString());
        
        // update the actual note.
        skill.UpdateNoteData(Models.JABS.Tags.Pierce.Regex, updatedNote);
    }
}