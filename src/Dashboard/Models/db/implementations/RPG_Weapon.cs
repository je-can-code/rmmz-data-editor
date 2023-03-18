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
    public decimal jabsSkillId => this.skillId();

    /// <summary>
    /// Gets the jabs skill id from the notes.
    /// </summary>
    /// <returns>The skill id, or 0 if not found.</returns>
    private decimal skillId()
    {
        return this.getAsNumberByTag(JABS.RmmzTags.SkillId.Name) ?? decimal.Zero;
    }

    /// <summary>
    /// Updates the skill id associated with this weapon.
    /// </summary>
    /// <param name="newSkillId">The updated skill id.</param>
    internal void updateSkillId(decimal newSkillId)
    {
        this.updateNotedata(@"<skillId:[ ]?(\d+)>", $"<skillId:{newSkillId}>");
    }
}