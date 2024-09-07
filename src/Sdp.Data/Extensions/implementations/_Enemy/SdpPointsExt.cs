using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;
using JMZ.Sdp.Data.Models;

namespace JMZ.Sdp.Data.Extensions.implementations._Enemy;

public static class SdpPointsExt
{
    /// <summary>
    ///     The value that is used to represent "no value" for this tag.
    /// </summary>
    public const decimal NON_VALUE = decimal.Zero;

    public static decimal GetSdpPoints(this RPG_Enemy enemy)
    {
        return enemy.GetFirstNumberByTag(Tags.Points.Name) ?? NON_VALUE;
    }

    public static void UpdateSdpPoints(this RPG_Enemy enemy, decimal newSdpPoints = NON_VALUE)
    {
        // check if we currently are missing a primary value.
        var isMissing = enemy.GetFirstNumberByTag(Tags.Points.Name, true) == null;

        // check if there is no value and was passed a non-value.
        if (isMissing && newSdpPoints == NON_VALUE)
        {
            // do nothing.
            return;
        }

        // check if it became empty but had data previously.
        if (newSdpPoints == NON_VALUE)
        {
            // remove the tag data.
            enemy.RemoveNoteData(Tags.Points.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Tags.Points.ToValueTag(newSdpPoints.ToString());

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
            enemy.UpdateNoteData(Tags.Points.Regex, updatedNote);
        }
    }
}