using Dashboard.Extensions;
using Dashboard.Models.db.core;
using Dashboard.Models.JABS;
using Newtonsoft.Json;

namespace Dashboard.Models.db.implementations;

/// <summary>
/// A data model representing a single skill from the database.
/// </summary>
public class RPG_Skill : RPG_UsableItem
{
    #region properties
    /// <summary>
    /// The first line of the message for this skill.
    /// </summary>
    public string message1 { get; set; } = string.Empty;

    /// <summary>
    /// The second line of the message for this skill.
    /// </summary>
    public string message2 { get; set; } = string.Empty;

    /// <summary>
    /// The type of message this skill has.
    /// </summary>
    public int messageType { get; set; } = 0;

    /// <summary>
    /// The amount of MP required to execute this skill.
    /// </summary>
    public int mpCost { get; set; } = 0;

    /// <summary>
    /// The first of two required weapon types to be equipped to execute this skill.
    /// 0 translates to "no requirement".
    /// </summary>
    public int requiredWtypeId1 { get; set; } = 0;

    /// <summary>
    /// The second of two required weapon types to be equipped to execute this skill.
    /// 0 translates to "no requirement".
    /// </summary>
    public int requiredWtypeId2 { get; set; } = 0;

    /// <summary>
    /// The skill type that this skill belongs to.
    /// </summary>
    public int stypeId { get; set; } = 0;

    /// <summary>
    /// The amount of TP required to execute this skill.
    /// </summary>
    public int tpCost { get; set; } = 0;
    #endregion properties
    
    /// <summary>
    /// Whether or not this skill should be hidden from the JABS quick menu assignment.
    /// </summary>
    [JsonIgnore]
    public bool jabsHideFromQuickMenu => this.hideFromQuickMenu();

    [JsonIgnore]
    public decimal jabsRadius => this.getJabsRadius();

    [JsonIgnore]
    public decimal jabsProximity => this.getJabsProximity();

    [JsonIgnore]
    public Hitbox jabsHitbox => this.getJabsHitbox();

    [JsonIgnore]
    public string jabsSkillExtends => this.getSkillExtends();

    [JsonIgnore]
    public decimal jabsComboSkillId => this.getJabsComboSkillId();
    
    [JsonIgnore]
    public decimal jabsComboDelay => this.getJabsComboDelay();

    [JsonIgnore]
    public bool jabsFreeCombo => this.freeComboEnabled();
    
    [JsonIgnore]
    public decimal jabsActionId => this.getJabsActionId();

    [JsonIgnore]
    public decimal jabsDuration => this.getJabsDuration();

    [JsonIgnore]
    public decimal jabsPierceCount => this.getJabsPierceCount();

    [JsonIgnore]
    public decimal jabsPierceDelay => this.getJabsPierceDelay();
    
    [JsonIgnore]
    public decimal jabsCooldown => this.getJabsCooldown();

    [JsonIgnore]
    public decimal jabsCastAnimation => this.getJabsCastAnimation();

    [JsonIgnore]
    public string jabsPoseSuffix => this.getJabsPoseSuffix();
    
    [JsonIgnore]
    public decimal jabsPoseIndex => this.getJabsPoseIndex();

    [JsonIgnore]
    public decimal jabsPoseDuration => this.getJabsPoseDuration();
    
    /// <summary>
    /// Extracts the boolean for whether or not there is a tag for hiding this
    /// skill from the JABS quick menu.
    /// </summary>
    /// <returns>True if the tag was present, false otherwise.</returns>
    private bool hideFromQuickMenu()
    {
        // return what we found.
        return this.hasBooleanTag("hideFromJabsMenu");
    }

    /// <summary>
    /// Updates the note with the new state of this property.
    /// </summary>
    /// <param name="hideFromQuickMenu">The new state of this property.</param>
    internal void updateHideFromQuickMenu(bool hideFromQuickMenu)
    {
        // check what our current state is.
        var currentlyHidesFromQuickMenu = this.hideFromQuickMenu();

        // determine what action to take.
        switch (currentlyHidesFromQuickMenu)
        {
            // currently and still hiding.
            case true when hideFromQuickMenu:
                // do not process anything.
                return;
            // currently hiding, but no more.
            case true:
                this.removeNotedata(JABS.RmmzTags.HideFromJabsMenu.Regex);
                break;
            // not currently hiding, but should.
            case false when hideFromQuickMenu:
                this.addNotedata(JABS.RmmzTags.HideFromJabsMenu.ToBooleanTag());
                break;
        }
    }

    /// <summary>
    /// Extracts the numeric value representing the radius of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The radius of this skill.</returns>
    private decimal getJabsRadius()
    {
        return this.getAsNumberByTag("radius") ?? -1;
    }

    /// <summary>
    /// Updates the note with the new state of this property.
    /// </summary>
    /// <param name="radius">The new state of this property.</param>
    internal void updateJabsRadius(decimal radius)
    {
        // grab our current state.
        var currentRadius = this.getJabsRadius();

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
            this.removeNotedata(JABS.RmmzTags.Radius.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new value.
        var updatedNote = JABS.RmmzTags.Radius.ToValueTag(radius.ToString());
        
        // update the actual note.
        this.updateNotedata(JABS.RmmzTags.Radius.Regex, updatedNote);
    }

    /// <summary>
    /// Extracts the numeric value representing the proximity of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The radius of this skill.</returns>
    private decimal getJabsProximity()
    {
        return this.getAsNumberByTag("proximity") ?? decimal.Zero;
    }

    /// <summary>
    /// Updates the note with the new state of this property.
    /// </summary>
    /// <param name="proximity">The new state of this property.</param>
    internal void updateJabsProximity(decimal proximity)
    {
        // grab our current state.
        var currentProximity = this.getJabsProximity();

        // check if there was no proximity and is no proximity, do not update.
        if (currentProximity < 0 && proximity < 0)
        {
            // do nothing.
            return;
        }

        // check if there was a proximity but is no longer.
        if (proximity < 0 && currentProximity >= 0)
        {
            // remove the note, it is no longer needed.
            this.removeNotedata(JABS.RmmzTags.Proximity.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new value.
        var updatedNote = JABS.RmmzTags.Proximity.ToValueTag(proximity.ToString());
        
        // update the actual note.
        this.updateNotedata(JABS.RmmzTags.Proximity.Regex, updatedNote);
    }
    
    /// <summary>
    /// Extracts the enum value representing the hitbox of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The hitbox of this skill.</returns>
    private Hitbox getJabsHitbox()
    {
        // parse the hitbox from the notes.
        var hitbox = this.getAsStringByTag("hitbox");

        // check if the hitbox can be parsed from the string provided.
        if (Enum.TryParse<Hitbox>(hitbox, true, out var convertedHitbox))
        {
            return convertedHitbox;
        }

        // the default hitbox is that none is associated.
        return Hitbox.None;
    }
    
    /// <summary>
    /// Extracts the boolean for whether or not there is a tag for enabling
    /// free combo in the context of JABS.
    /// </summary>
    /// <returns>True if the tag was present, false otherwise.</returns>
    private bool freeComboEnabled()
    {
        // return what we found.
        return this.hasBooleanTag("freeCombo");
    }
    
    /// <summary>
    /// Extracts the numeric value representing the cooldown of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The cooldown of this skill.</returns>
    private decimal getJabsCooldown()
    {
        return this.getAsNumberByTag("cooldown") ?? decimal.Zero;
    }

    /// <summary>
    /// Extracts the numeric value representing the cast animation id of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The cast animation of this skill.</returns>
    private decimal getJabsCastAnimation()
    {
        return this.getAsNumberByTag("castAnimation") ?? decimal.Zero;
    }

    /// <summary>
    /// Extracts the numeric value representing the action id of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The action id of this skill.</returns>
    private decimal getJabsActionId()
    {
        return this.getAsNumberByTag(JABS.RmmzTags.ActionId.Name) ?? decimal.Zero;
    }

    internal void updateJabsActionId(decimal actionId)
    {
        // determine if this skill currently has actionId on it.
        var missingActionId = this.getJabsActionId() == decimal.Zero;

        // check if there is no actionId and was passed a no-actionId value.
        if (missingActionId && actionId == 0)
        {
            // do nothing.
            return;
        }

        if (actionId == 0)
        {
            // remove the tag entirely, zero is an invalid actionId.
            this.removeNotedata(JABS.RmmzTags.ActionId.Regex);
            
            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = JABS.RmmzTags.ActionId.ToValueTag(actionId.ToString());

        // check if the actionId was missing previously.
        if (missingActionId)
        {
            // add the new tag to the note.
            this.addNotedata(updatedNote);
        }
        // the actionId just needs to be updated.
        else
        {
            // update the actual note.
            this.updateNotedata(JABS.RmmzTags.ActionId.Regex, updatedNote);
        }
    }

    /// <summary>
    /// Extracts the numeric value representing the duration of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The duration of this skill.</returns>
    private decimal getJabsDuration()
    {
        return this.getAsNumberByTag(JABS.RmmzTags.Duration.Name) ?? decimal.Zero;
    }

    #region pose
    /// <summary>
    /// Extracts the text value representing the pose suffix of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The pose suffix of this skill.</returns>
    private string getJabsPoseSuffix()
    {
        return this.getJabsPoseData().poseSuffix;
    }

    /// <summary>
    /// Extracts the numeric value representing the pose index of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The pose index of this skill.</returns>
    private decimal getJabsPoseIndex()
    {
        return this.getJabsPoseData().poseIndex;
    }

    /// <summary>
    /// Extracts the numeric value representing the pose duration of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The pose duration of this skill.</returns>
    private decimal getJabsPoseDuration()
    {
        return this.getJabsPoseData().poseDuration;
    }

    private (string poseSuffix, decimal poseIndex, decimal poseDuration) getJabsPoseData()
    {
        var poseData = this.getAsStringsByTag(JABS.RmmzTags.Pose.Name) ?? new List<string>();

        // if there are no data points, then there are no poses.
        if (!poseData.Any())
        {
            // return an empty set.
            return (string.Empty, decimal.Zero, decimal.Zero);
        }
        
        // the actual suffix appended to the base character sheet name.
        var poseSuffix = poseData[0];

        // parse the index.
        var poseIndex = decimal.Parse(poseData[1]);

        // parse the duration.
        var poseDuration = decimal.Parse(poseData[2]);

        // return what the collection contained for pose data.
        return (poseSuffix, poseIndex, poseDuration);
    }
    #endregion pose

    #region combo
    /// <summary>
    /// Extracts the numeric value representing the combo follow-up skill id
    /// of this skill in the context of JABS.
    /// </summary>
    /// <returns>The follow-up combo skill of this skill.</returns>
    private decimal getJabsComboSkillId() => this.getJabsComboData().comboSkill;

    /// <summary>
    /// Extracts the numeric value representing the delay in frames before being able to
    /// execute a combo follow-up skill in the context of JABS.
    /// </summary>
    /// <returns>The delay before able to perform a combo after this skill.</returns>
    private decimal getJabsComboDelay() => this.getJabsComboData().comboDelay;
    
    private (decimal comboSkill, decimal comboDelay) getJabsComboData()
    {
        // grab the number data from the combo.
        var combos = this.getAsNumbersByTag(JABS.RmmzTags.Combo.Name) ?? new List<decimal>();

        // if there are no numbers, then there are no combos.
        if (!combos.Any())
        {
            // return an empty set.
            return (decimal.Zero, decimal.Zero);
        }

        // return what the collection contained for combo data.
        return (combos[0], combos[1]);
    }

    internal void updateJabsCombo(decimal comboSkill, decimal comboDelay)
    {
        // determine if this skill is missing a combo skill on it.
        var missingComboSkill = this.getJabsComboSkillId() == decimal.Zero;

        // check if there is no skill and was passed a no-combo-skill value.
        if (missingComboSkill && comboSkill == 0)
        {
            // do nothing.
            return;
        }

        // check if the combo skill becomes zero but had it previously.
        if (comboSkill == 0)
        {
            // remove the tag entirely, zero is an invalid combo skill.
            this.removeNotedata(JABS.RmmzTags.Combo.Regex);
            
            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = JABS.RmmzTags.Combo.ToArrayTag(comboSkill.ToString(), comboDelay.ToString());
        
        // update the actual note.
        this.updateNotedata(JABS.RmmzTags.Combo.Regex, updatedNote);
    }

    #endregion combo
    
    #region pierce
    /// <summary>
    /// Extracts the numeric value representing the number of times this skill
    /// can pierce a target in the context of JABS.
    /// </summary>
    /// <returns>The pierce count of this skill.</returns>
    private decimal getJabsPierceCount()
    {
        return this.getJabsPierceData().pierceCount;
    }
    
    /// <summary>
    /// Extracts the numeric value representing the delay in frames this skill
    /// requires between piercing a target in the context of JABS.
    /// </summary>
    /// <returns>The pierce delay of this skill.</returns>
    private decimal getJabsPierceDelay()
    {
        return this.getJabsPierceData().pierceDelay;
    }

    private (decimal pierceCount, decimal pierceDelay) getJabsPierceData()
    {
        // grab the number data from the combo.
        var data = this.getAsNumbersByTag(JABS.RmmzTags.Pierce.Name) ?? new List<decimal>();

        // if there are no numbers, then there are no combos.
        if (!data.Any())
        {
            // return an empty set.
            return (0, 0);
        }

        // return what the collection contained for combo data.
        return (data[0], data[1]);
    }
    #endregion pierce
    
    /// <summary>
    /// Extracts the string value representing the ids of other skills that are
    /// extended by this skill.
    /// </summary>
    /// <returns>The list of skills that this skill extends.</returns>
    private string getSkillExtends()
    {
        // grab the contents of the list- we don't question what is within!
        var extensions = this.getAsStringByTag(SkillExtend.RmmzTags.Extend.Name) ?? string.Empty;

        // remove the outer brackets.
        return extensions.UnwrapBrackets();
    }
}