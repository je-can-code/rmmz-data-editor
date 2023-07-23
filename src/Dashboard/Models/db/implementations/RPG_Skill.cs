using Dashboard.Extensions;
using Dashboard.Models.db.core;
using Dashboard.Models.JABS;
using Dashboard.Services;
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
    internal bool jabsHideFromQuickMenu => this.hideFromQuickMenu();

    internal bool jabsDirectTargeting => this.isJabsDirectTargeting();

    internal decimal jabsRadius => this.getJabsRadius();

    internal decimal jabsProximity => this.getJabsProximity();

    internal Hitbox jabsHitbox => this.getJabsHitbox();

    internal string jabsSkillExtends => this.getSkillExtends();

    internal decimal jabsComboSkillId => this.getJabsComboSkillId();
    
    internal decimal jabsComboDelay => this.getJabsComboDelay();

    internal bool jabsFreeCombo => this.isFreeComboEnabled();

    internal bool jabsAiComboStarter => this.isAiComboStarter();

    internal bool jabsAiSkillExclusion => this.isSkillExcludedFromAi();

    internal bool jabsGapCloser => this.canGapClose();
    
    internal decimal jabsActionId => this.getJabsActionId();

    internal decimal jabsDuration => this.getJabsDuration();

    internal decimal jabsPierceCount => this.getJabsPierceCount();

    internal decimal jabsPierceDelay => this.getJabsPierceDelay();
    
    internal decimal jabsCooldown => this.getJabsCooldown();

    internal decimal jabsCastAnimation => this.getJabsCastAnimation();

    internal decimal jabsCastTime => this.getJabsCastTime();

    internal string jabsPoseSuffix => this.getJabsPoseSuffix();
    
    internal decimal jabsPoseIndex => this.getJabsPoseIndex();

    internal decimal jabsPoseDuration => this.getJabsPoseDuration();
    
    /// <summary>
    /// Extracts the boolean for whether or not there is a tag for hiding this
    /// skill from the JABS quick menu.
    /// </summary>
    /// <returns>True if the tag was present, false otherwise.</returns>
    private bool hideFromQuickMenu()
    {
        // return what we found.
        return this.hasBooleanTag(JABS.Tags.HideFromJabsMenu.Name);
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
                this.removeNotedata(JABS.Tags.HideFromJabsMenu.Regex);
                break;
            // not currently hiding, but should.
            case false when hideFromQuickMenu:
                this.addNotedata(JABS.Tags.HideFromJabsMenu.ToBooleanTag());
                break;
        }
    }
    
    private bool isJabsDirectTargeting()
    {
        // return what we found.
        return this.hasBooleanTag(JABS.Tags.Direct.Name);
    }

    internal void updateJabsDirectTargeting(bool directTargeting)
    {
        // check what our current state is.
        var currentlyEnabled = this.isJabsDirectTargeting();

        // determine what action to take.
        switch (currentlyEnabled)
        {
            // was before and still is.
            case true when directTargeting:
                return;
            // was previously but is not any longer.
            case true:
                this.removeNotedata(JABS.Tags.Direct.Regex);
                break;
            // was not previously, but is now.
            case false when directTargeting:
                this.addNotedata(JABS.Tags.Direct.ToBooleanTag());
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
            this.removeNotedata(JABS.Tags.Radius.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new value.
        var updatedNote = JABS.Tags.Radius.ToValueTag(radius.ToString());
        
        // update the actual note.
        this.updateNotedata(JABS.Tags.Radius.Regex, updatedNote);
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
            this.removeNotedata(JABS.Tags.Proximity.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new value.
        var updatedNote = JABS.Tags.Proximity.ToValueTag(proximity.ToString());
        
        // update the actual note.
        this.updateNotedata(JABS.Tags.Proximity.Regex, updatedNote);
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

    internal void updateJabsHitbox(Hitbox hitbox)
    {
        // grab our current state.
        var currentHitbox = this.getJabsHitbox();

        // check if there was no hitbox and is no hitbox.
        if (currentHitbox == Hitbox.None && hitbox == Hitbox.None)
        {
            // do nothing.
            return;
        }

        // check if there was a value, but is no longer.
        if (currentHitbox != Hitbox.None && hitbox == Hitbox.None)
        {
            // remove the note, it is no longer needed.
            this.removeNotedata(JABS.Tags.Hitbox.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new value.
        var updatedNote = JABS.Tags.Hitbox.ToValueTag(hitbox.ToString().ToLower());
        
        // update the actual note.
        this.updateNotedata(JABS.Tags.Hitbox.Regex, updatedNote);
    }

    /// <summary>
    /// Extracts the boolean for whether or not there is a tag for enabling
    /// free combo in the context of JABS.
    /// </summary>
    /// <returns>True if the tag was present, false otherwise.</returns>
    private bool isFreeComboEnabled()
    {
        // return what we found.
        return this.hasBooleanTag(JABS.Tags.FreeCombo.Name);
    }

    internal void updateFreeComboEnabled(bool freeComboEnabled)
    {
        // check what our current state is.
        var currentlyEnabled = this.isFreeComboEnabled();

        // determine what action to take.
        switch (currentlyEnabled)
        {
            // currently and still hiding.
            case true when freeComboEnabled:
                // do not process anything.
                return;
            // currently hiding, but no more.
            case true:
                this.removeNotedata(JABS.Tags.AiComboStarter.Regex);
                break;
            // not currently hiding, but should.
            case false when freeComboEnabled:
                this.addNotedata(JABS.Tags.AiComboStarter.ToBooleanTag());
                break;
        }
    }

    private bool isAiComboStarter()
    {
        return this.hasBooleanTag(JABS.Tags.AiComboStarter.Name);
    }

    internal void updateAiComboStarter(bool isAiComboStarter)
    {
        // check what our current state is.
        var currentlyEnabled = this.isAiComboStarter();

        // determine what action to take.
        switch (currentlyEnabled)
        {
            // was before and still is.
            case true when isAiComboStarter:
                return;
            // was previously but is not any longer.
            case true:
                this.removeNotedata(JABS.Tags.AiComboStarter.Regex);
                break;
            // was not previously, but is now.
            case false when isAiComboStarter:
                this.addNotedata(JABS.Tags.AiComboStarter.ToBooleanTag());
                break;
        }
    }

    private bool canGapClose()
    {
        return this.hasBooleanTag(JABS.Tags.GapCloser.Name);
    }

    internal void updateCanGapClose(bool canGapClose)
    {
        // check what our current state is.
        var currentlyEnabled = this.canGapClose();

        // determine what action to take.
        switch (currentlyEnabled)
        {
            // was before and still is.
            case true when canGapClose:
                return;
            // was previously but is not any longer.
            case true:
                this.removeNotedata(JABS.Tags.GapCloser.Regex);
                break;
            // was not previously, but is now.
            case false when canGapClose:
                this.addNotedata(JABS.Tags.GapCloser.ToBooleanTag());
                break;
        }
    }
    
    private bool isSkillExcludedFromAi()
    {
        return this.hasBooleanTag(JABS.Tags.AiSkillExclusion.Name);
    }

    internal void updateAiSkillExclusion(bool isSkillExcluded)
    {
        // check what our current state is.
        var currentState = this.isSkillExcludedFromAi();

        // determine what action to take.
        switch (currentState)
        {
            // was before and still is.
            case true when isSkillExcluded:
                return;
            // was previously but is not any longer.
            case true:
                this.removeNotedata(JABS.Tags.AiSkillExclusion.Regex);
                break;
            // was not previously, but is now.
            case false when isSkillExcluded:
                this.addNotedata(JABS.Tags.AiSkillExclusion.ToBooleanTag());
                break;
        }
    }

    /// <summary>
    /// Extracts the numeric value representing the cooldown of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The cooldown of this skill.</returns>
    private decimal getJabsCooldown()
    {
        return this.getAsNumberByTag(JABS.Tags.Cooldown.Name) ?? decimal.Zero;
    }

    internal void updateJabsCooldown(decimal cooldown)
    {
        // determine if this skill currently has a value on it.
        var isMissing = this.getJabsCooldown() == decimal.Zero;

        // check if there is no value, and was passed a non-value value.
        if (isMissing && cooldown == 0)
        {
            // do nothing.
            return;
        }

        // check if we had a value, but are now removing it.
        if (cooldown == 0)
        {
            // remove the tag entirely, zero is an invalid cooldown.
            this.removeNotedata(JABS.Tags.Cooldown.Regex);
            
            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = JABS.Tags.Cooldown.ToValueTag(cooldown.ToString());

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
            this.updateNotedata(JABS.Tags.Cooldown.Regex, updatedNote);
        }
    }

    /// <summary>
    /// Extracts the numeric value representing the cast animation id of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The cast animation of this skill.</returns>
    private decimal getJabsCastAnimation()
    {
        return this.getAsNumberByTag(JABS.Tags.CastAnimation.Name) ?? decimal.Zero;
    }

    internal void updateJabsCastAnimation(decimal castAnimationId)
    {
        // determine if this skill currently has actionId on it.
        var isMissing = this.getJabsCastAnimation() == decimal.Zero;

        // check if there is no castAnimationId and was passed a no-castAnimationId value.
        if (isMissing && castAnimationId == 0)
        {
            // do nothing.
            return;
        }

        // check if we had an actionId, but are now removing it.
        if (castAnimationId == 0)
        {
            // remove the tag entirely, zero is an invalid castAnimationId.
            this.removeNotedata(JABS.Tags.CastAnimation.Regex);
            
            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = JABS.Tags.CastAnimation.ToValueTag(castAnimationId.ToString());

        // check if the actionId was missing previously.
        if (isMissing)
        {
            // add the new tag to the note.
            this.addNotedata(updatedNote);
        }
        // the actionId just needs to be updated.
        else
        {
            // update the actual note.
            this.updateNotedata(JABS.Tags.CastAnimation.Regex, updatedNote);
        }
    }

    private decimal getJabsCastTime()
    {
        return this.getAsNumberByTag(JABS.Tags.CastTime.Name) ?? decimal.Zero;
    }

    internal void updateJabsCastTime(decimal castTime)
    {
        // determine if this skill currently has actionId on it.
        var isMissing = this.getJabsCastTime() == decimal.Zero;

        // check if there is no castAnimationId and was passed a no-castAnimationId value.
        if (isMissing && castTime == 0)
        {
            // do nothing.
            return;
        }

        // check if we had an actionId, but are now removing it.
        if (castTime == 0)
        {
            // remove the tag entirely, zero is an invalid castAnimationId.
            this.removeNotedata(JABS.Tags.CastTime.Regex);
            
            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = JABS.Tags.CastTime.ToValueTag(castTime.ToString());

        // check if the actionId was missing previously.
        if (isMissing)
        {
            // add the new tag to the note.
            this.addNotedata(updatedNote);
        }
        // the actionId just needs to be updated.
        else
        {
            // update the actual note.
            this.updateNotedata(JABS.Tags.CastTime.Regex, updatedNote);
        }
    }
    
    /// <summary>
    /// Extracts the numeric value representing the action id of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The action id of this skill.</returns>
    private decimal getJabsActionId()
    {
        return this.getAsNumberByTag(JABS.Tags.ActionId.Name) ?? decimal.Zero;
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

        // check if we had an actionId, but are now removing it.
        if (actionId == 0)
        {
            // remove the tag entirely, zero is an invalid actionId.
            this.removeNotedata(JABS.Tags.ActionId.Regex);
            
            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = JABS.Tags.ActionId.ToValueTag(actionId.ToString());

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
            this.updateNotedata(JABS.Tags.ActionId.Regex, updatedNote);
        }
    }

    /// <summary>
    /// Extracts the numeric value representing the duration of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The duration of this skill.</returns>
    private decimal getJabsDuration()
    {
        return this.getAsNumberByTag(JABS.Tags.Duration.Name) ?? decimal.Zero;
    }

    internal void updateJabsDuration(decimal duration)
    {
        // determine if this skill currently has a value on it.
        var missingDuration = this.getJabsDuration() == decimal.Zero;

        // check if there is no value, and was passed a non-value value.
        if (missingDuration && duration == 0)
        {
            // do nothing.
            return;
        }

        // check if we had a value, but are now removing it.
        if (duration == 0)
        {
            // remove the tag entirely, zero is an invalid duration.
            this.removeNotedata(JABS.Tags.Duration.Regex);
            
            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = JABS.Tags.Duration.ToValueTag(duration.ToString());

        // check if the value was missing previously.
        if (missingDuration)
        {
            // add the new tag to the note.
            this.addNotedata(updatedNote);
        }
        // the value just needs to be updated.
        else
        {
            // update the actual note.
            this.updateNotedata(JABS.Tags.Duration.Regex, updatedNote);
        }
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

    internal void updateJabsPose(string newPoseSuffix, decimal newPoseIndex, decimal newPoseDuration)
    {
        // grab the current pose suffix for this skill.
        var poseSuffix = this.getJabsPoseSuffix();

        // determine if this skill is missing a pose suffix.
        var missingPoseSuffix = poseSuffix == string.Empty;

        // check if there is no skill and was passed a no-combo-skill value.
        if (missingPoseSuffix && newPoseSuffix == string.Empty)
        {
            // do nothing.
            return;
        }

        // check if the pose suffix became empty but had a suffix previously.
        if (newPoseSuffix == string.Empty)
        {
            this.removeNotedata(JABS.Tags.Pose.Regex);

            // do nothing.
            return;
        }
        
        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = JABS.Tags.Pose.ToArrayTag(
            newPoseSuffix,
            newPoseIndex.ToString(),
            newPoseDuration.ToString());
        
        // update the actual note.
        this.updateNotedata(JABS.Tags.Pose.Regex, updatedNote);
    }

    private (string poseSuffix, decimal poseIndex, decimal poseDuration) getJabsPoseData()
    {
        var poseData = this.getAsStringsByTag(JABS.Tags.Pose.Name) ?? new List<string>();

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
        var combos = this.getAsNumbersByTag(JABS.Tags.Combo.Name) ?? new List<decimal>();

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
            this.removeNotedata(JABS.Tags.Combo.Regex);
            
            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = JABS.Tags.Combo.ToArrayTag(comboSkill.ToString(), comboDelay.ToString());

        if (missingComboSkill)
        {
            this.addNotedata(updatedNote);
        }
        // the note just needs to be updated.
        else
        {
            // update the actual note.
            this.updateNotedata(JABS.Tags.Combo.Regex, updatedNote);
        }
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
        var data = this.getAsNumbersByTag(JABS.Tags.Pierce.Name) ?? new List<decimal>();

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
        var extensions = this.getAsStringByTag(SkillExtend.Tags.Extend.Name) ?? string.Empty;

        // remove the outer brackets.
        return extensions.UnwrapBrackets();
    }

    internal void updateSkillExtends(string extensions)
    {
        var isMissing = this.getSkillExtends() == string.Empty;

        if (isMissing && extensions == string.Empty)
        {
            // do nothing.
            return;
        }

        if (extensions == string.Empty)
        {
            this.removeNotedata(SkillExtend.Tags.Extend.Regex);

            return;
        }
        
        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = SkillExtend.Tags.Extend.ToArrayTag(extensions);

        // check if the actionId was missing previously.
        if (isMissing)
        {
            // add the new tag to the note.
            this.addNotedata(updatedNote);
        }
        // the data just needs to be updated.
        else
        {
            // update the actual note.
            this.updateNotedata(SkillExtend.Tags.Extend.Regex, updatedNote);
        }
    }
}