using Dashboard.Models.db.core;
using Newtonsoft.Json;

namespace Dashboard.Models.db.implementations;

/// <summary>
/// A data model representing a single RMMZ weapon.
/// </summary>
public class RPG_Weapon : RPG_EquipItem
{
    #region regular properties
    /// <summary>
    /// The id of the animation that plays for this weapon.
    /// </summary>
    public int animationId { get; set; } = -1;
    
    /// <summary>
    /// The weapon type id defining the category of weapon this belongs to.
    /// </summary>
    public int wtypeId { get; set; } = 1;
    #endregion regular properties
    
    /// <summary>
    /// A custom JABS-related property.
    /// The skill id associated with a given weapon.
    /// </summary>
    [JsonIgnore]
    internal decimal jabsSkillId => this.getJabsSkillId();

    [JsonIgnore]
    internal decimal jabsSpeedBoost => this.getJabsSpeedBoost();

    /// <summary>
    /// Gets the jabs skill id from the notes.
    /// </summary>
    /// <returns>The skill id, or 0 if not found.</returns>
    private decimal getJabsSkillId()
    {
        return this.getAsNumberByTag(JABS.Tags.SkillId.Name) ?? decimal.Zero;
    }

    /// <summary>
    /// Updates the skill id associated with this weapon.
    /// </summary>
    /// <param name="newSkillId">The updated skill id.</param>
    internal void updateSkillId(decimal newSkillId)
    {
        // determine if currently there is a value on it.
        var isMissing = this.getJabsSkillId() == decimal.Zero;

        // check if there is no value, and was passed a non-value value.
        if (isMissing && newSkillId == 0)
        {
            // do nothing.
            return;
        }

        // check if we had a value, but are now removing it.
        if (newSkillId == 0)
        {
            // remove the tag entirely, zero is an invalid input.
            this.removeNotedata(JABS.Tags.SkillId.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = JABS.Tags.SkillId.ToValueTag(newSkillId.ToString());

        // check if the value was missing previously.
        if (isMissing)
        {
            // add the new tag to the note.
            this.addNotedata(updatedNote);
        }
        // the value just needs to be updated.
        else
        {
            // update the actual note.
            this.updateNotedata(JABS.Tags.SkillId.Regex, updatedNote);
        }
    }

    private decimal getJabsSpeedBoost()
    {
        return this.getAsNumberByTag("speedBoost", true) ?? decimal.Zero;
    }

    internal void updateJabsSpeedBoost(decimal newSpeedBoost)
    {
        // determine if currently there is a value on it.
        var isMissing = this.getJabsSpeedBoost() == decimal.Zero;

        // check if there is no value, and was passed a non-value value.
        if (isMissing && newSpeedBoost == 0)
        {
            // do nothing.
            return;
        }

        // check if we had a value, but are now removing it.
        if (newSpeedBoost == 0)
        {
            // remove the tag entirely, zero is an invalid input.
            this.removeNotedata(JABS.Tags.SpeedBoost.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = JABS.Tags.SpeedBoost.ToValueTag(newSpeedBoost.ToString());

        // check if the value was missing previously.
        if (isMissing)
        {
            // add the new tag to the note.
            this.addNotedata(updatedNote);
        }
        // the value just needs to be updated.
        else
        {
            // update the actual note.
            this.updateNotedata(JABS.Tags.SpeedBoost.Regex, updatedNote);
        }
    }
}