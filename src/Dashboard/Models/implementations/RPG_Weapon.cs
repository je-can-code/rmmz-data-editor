using Dashboard.Models.@base;
using Dashboard.Models.core;
using Newtonsoft.Json;

namespace Dashboard.Models;

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
    public int jabsSkillId => this.skillId();

    /// <summary>
    /// Gets the jabs skill id from the notes.
    /// </summary>
    /// <returns>The skill id, or 0 if not found.</returns>
    private int skillId()
    {
        // grab the note data to scan.
        var tags = this.notedata();
        
        // if we have no note data, then we have no skill id.
        if (tags.Count == 0) return 0;

        // initialize to 0.
        var skillId = 0;
        
        // iterate over each of the tags.
        tags.ForEach(tag =>
        {
            // check if the tag is the one we're looking for.
            if (tag.Name == "skillId")
            {
                // parse and assign the value.
                skillId = int.Parse(tag.Value);
            }
        });

        // return the result.
        return skillId;
    }

    /// <summary>
    /// Updates the skill id associated with this weapon.
    /// </summary>
    /// <param name="newSkillId"></param>
    internal void updateSkillId(int newSkillId)
    {
        this.updateNotedata(@"<skillId:[ ]?(\d+)>", $"<skillId:{newSkillId}>");
    }
}