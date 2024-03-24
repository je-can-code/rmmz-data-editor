using JMZ.LevelMaster.Data.Models;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.LevelMaster.Data.Extensions.implementations._Enemy;

public static class LevelsExt
{
    public static decimal GetLevel(this RPG_Enemy enemy)
    {
        return enemy.GetFirstNumberByTag(Tags.Level.Name) ?? decimal.Zero;
    }

    public static void UpdateLevel(this RPG_Enemy enemy, decimal newLevel)
    {
        // determine if there is already a value.
        var missingLevel = enemy.GetLevel() == decimal.Zero;

        // check if there is no value and was passed a non-value.
        if (missingLevel && newLevel == 0)
        {
            // do nothing.
            return;
        }

        // check if we had a value, but are now removing it.
        if (newLevel == 0)
        {
            // remove the tag entirely..
            enemy.RemoveNoteData(Tags.Level.Regex);
            
            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Tags.Level.ToValueTag(newLevel.ToString());

        // check if the value was missing previously.
        if (missingLevel)
        {
            // add the new tag to the note.
            enemy.AddNoteData(updatedNote);
        }
        // the value just needs to be updated.
        else
        {
            // update the actual note.
            enemy.UpdateNoteData(Tags.Level.Regex, updatedNote);
        }
    }
}