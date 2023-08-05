﻿using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.TargetingData;

public static class RadiusExt
{
    public static decimal GetJabsRadius(this RPG_Skill skill)
    {
        return skill.GetFirstNumberByTag(Models.JABS.Tags.Radius.Name)  ?? -1;
    }
    
    public static void UpdateJabsRadius(this RPG_Skill skill, decimal radius)
    {
        // grab our current state.
        var currentRadius = skill.GetJabsRadius();

        // check if there was no radius and is no radius, do not update.
        if (currentRadius < 0 && radius < 0)
        {
            // do nothing.
            return;
        }

        // check if there was a radius but is no longer.
        if (radius < 0 && currentRadius >= 0)
        {
            // remove the note, it is no longer needed.
            skill.RemoveNoteData(Models.JABS.Tags.Radius.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new value.
        var updatedNote = Models.JABS.Tags.Radius.ToValueTag(radius.ToString());
        
        // update the actual note.
        skill.UpdateNoteData(Models.JABS.Tags.Radius.Regex, updatedNote);
    }
}