using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Extensions.implementations._Enemy;

public static class CoreDataExt
{
    internal static readonly decimal NonValue = -1;
    
    public static decimal GetJabsSight(this RPG_Enemy enemy)
    {
        return enemy.GetFirstNumberByTag(Tags.Sight.Name, true) ?? NonValue;
    }
    
    public static decimal GetJabsAlertedSightBoost(this RPG_Enemy enemy)
    {
        return enemy.GetFirstNumberByTag(Tags.AlertedSightBoost.Name, true) ?? NonValue;
    }
    
    public static decimal GetJabsPursuit(this RPG_Enemy enemy)
    {
        return enemy.GetFirstNumberByTag(Tags.Pursuit.Name, true) ?? NonValue;
    }
    
    public static decimal GetJabsAlertedPursuitBoost(this RPG_Enemy enemy)
    {
        return enemy.GetFirstNumberByTag(Tags.AlertedPursuitBoost.Name, true) ?? NonValue;
    }
    
    public static void UpdateJabsSight(this RPG_Enemy enemy, decimal newValue)
    {
        // determine if currently there is a value on it.
        var isMissing = enemy.GetJabsSight() == NonValue;

        // determine if the updated value is a non-value.
        var isNonValue = newValue == NonValue;

        // check if there is no value, and was passed a non-value value.
        if (isMissing && isNonValue)
        {
            // do nothing.
            return;
        }

        // check if we had a value, but are now removing it.
        if (isNonValue)
        {
            // remove the tag entirely, zero is an invalid input.
            enemy.RemoveNoteData(Tags.Sight.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Tags.Sight.ToValueTag(newValue.ToString());

        // check if the value was missing previously.
        if (isMissing)
        {
            // add the new tag to the note.
            enemy.AddNoteData(updatedNote);
        }
        // the value just needs to be updated.
        else
        {
            // update the actual note.
            enemy.UpdateNoteData(Tags.Sight.Regex, updatedNote);
        }
    }

    public static void UpdateJabsAlertedSightBoost(this RPG_Enemy enemy, decimal newBoostValue)
    {
        // determine if currently there is a value on it.
        var isMissing = enemy.GetJabsAlertedSightBoost() == NonValue;

        // determine if the updated value is a non-value.
        var isNonValue = newBoostValue == NonValue;

        // check if there is no value, and was passed a non-value value.
        if (isMissing && isNonValue)
        {
            // do nothing.
            return;
        }

        // check if we had a value, but are now removing it.
        if (isNonValue)
        {
            // remove the tag entirely, zero is an invalid input.
            enemy.RemoveNoteData(Tags.AlertedSightBoost.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Tags.AlertedSightBoost.ToValueTag(newBoostValue.ToString());

        // check if the value was missing previously.
        if (isMissing)
        {
            // add the new tag to the note.
            enemy.AddNoteData(updatedNote);
        }
        // the value just needs to be updated.
        else
        {
            // update the actual note.
            enemy.UpdateNoteData(Tags.AlertedSightBoost.Regex, updatedNote);
        }
    }
    
    public static void UpdateJabsPursuit(this RPG_Enemy enemy, decimal newValue)
    {
        // determine if currently there is a value on it.
        var isMissing = enemy.GetJabsPursuit() == NonValue;

        // determine if the updated value is a non-value.
        var isNonValue = newValue == NonValue;

        // check if there is no value, and was passed a non-value value.
        if (isMissing && isNonValue)
        {
            // do nothing.
            return;
        }

        // check if we had a value, but are now removing it.
        if (isNonValue)
        {
            // remove the tag entirely, zero is an invalid input.
            enemy.RemoveNoteData(Tags.Pursuit.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Tags.Pursuit.ToValueTag(newValue.ToString());

        // check if the value was missing previously.
        if (isMissing)
        {
            // add the new tag to the note.
            enemy.AddNoteData(updatedNote);
        }
        // the value just needs to be updated.
        else
        {
            // update the actual note.
            enemy.UpdateNoteData(Tags.Pursuit.Regex, updatedNote);
        }
    }

    public static void UpdateJabsAlertedPursuitBoost(this RPG_Enemy enemy, decimal newValue)
    {
        // determine if currently there is a value on it.
        var isMissing = enemy.GetJabsAlertedPursuitBoost() == NonValue;

        // determine if the updated value is a non-value.
        var isNonValue = newValue == NonValue;

        // check if there is no value, and was passed a non-value value.
        if (isMissing && isNonValue)
        {
            // do nothing.
            return;
        }

        // check if we had a value, but are now removing it.
        if (isNonValue)
        {
            // remove the tag entirely, zero is an invalid input.
            enemy.RemoveNoteData(Tags.AlertedPursuitBoost.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Tags.AlertedPursuitBoost.ToValueTag(newValue.ToString());

        // check if the value was missing previously.
        if (isMissing)
        {
            // add the new tag to the note.
            enemy.AddNoteData(updatedNote);
        }
        // the value just needs to be updated.
        else
        {
            // update the actual note.
            enemy.UpdateNoteData(Tags.AlertedPursuitBoost.Regex, updatedNote);
        }
    }
}