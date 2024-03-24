using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;
using JMZ.Sdp.Data.Models;

namespace JMZ.Sdp.Data.Extensions.implementations._Enemy;

/// <summary>
/// Extensions related to SDP data management.
/// </summary>
public static class SdpDataExt
{
    /// <summary>
    /// Gets the <see cref="SdpDropData"/> from the enemy.
    /// </summary>
    public static SdpDropData GetSdpData(this RPG_Enemy enemy)
    {
        // retrieve the data points.
        var sdpDropData = enemy.GetAllStringsByTag(Tags.DropData.Name) ?? [];

        // if there are no data points, then there is no data.
        if (!sdpDropData.Any())
        {
            // return an empty set.
            return new(string.Empty, decimal.MinusOne);
        }

        // the string form of the key.
        var key = sdpDropData[0];
        
        // parse the integer percent chance of the panel being dropped.
        var chance = decimal.Parse(sdpDropData[1]);
        
        // parse the id of the database id of the item representing the panel.
        var itemId = decimal.Parse(sdpDropData[2]);

        // return what the collection contained for sdp drop data.
        return new(key, itemId, chance);
    }

    public static void UpdateSdpData(
        this RPG_Enemy enemy,
        string newKey,
        decimal newDropChance,
        decimal newItemId)
    {
        // check if we currently are missing a primary value.
        var isMissing = enemy.GetSdpKey() == string.Empty;

        // check if there is no value and was passed a non-value.
        if (isMissing && newKey == string.Empty)
        {
            // do nothing.
            return;
        }

        // check if it became empty but had data previously.
        if (newKey == string.Empty)
        {
            // remove the tag data..
            enemy.RemoveNoteData(Tags.DropData.Regex);

            // stop processing.
            return;
        }
        
        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Tags.DropData.ToArrayTag(
            newKey,
            newDropChance.ToString(),
            newItemId.ToString());
        
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
            enemy.UpdateNoteData(Tags.DropData.Regex, updatedNote);
        }
    }
}