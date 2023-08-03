using JMZ.Rmmz.Data.Extensions;
using JMZ.Rmmz.Data.Models.db.core;

namespace JMZ.Rmmz.Data.Models.JABS.implementations;

/// <summary>
/// JABS-related API extension for skills.
/// </summary>
public partial class RPG_Skill : RPG_UsableItem
{
    #region hideFromQuickMenu
    /// <summary>
    /// Whether or not this skill should be hidden from the JABS quick menu assignment.
    /// </summary>
    internal bool jabsHideFromQuickMenu => this.hideFromQuickMenu();
    
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
    #endregion hideFromQuickMenu
    
    #region skillExtends
    internal string jabsSkillExtends => this.getSkillExtends();
    
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
    #endregion skillExtends
    
    internal decimal jabsComboSkillId => this.getJabsComboSkillId();
    
    internal decimal jabsComboDelay => this.getJabsComboDelay();

    internal bool jabsFreeCombo => this.isFreeComboEnabled();

    internal bool jabsAiComboStarter => this.isAiComboStarter();
    
    internal decimal jabsActionId => this.getJabsActionId();

    internal decimal jabsDuration => this.getJabsDuration();

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


}