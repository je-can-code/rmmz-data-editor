using Dashboard.Extensions;
using Dashboard.Models.core;
using Dashboard.Models.JABS;

namespace Dashboard.Models.implementations;

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
    public bool jabsHideFromQuickMenu => this.hideFromQuickMenu();

    public decimal jabsRadius => this.getJabsRadius();

    public decimal jabsProximity => this.getJabsProximity();

    public Hitbox jabsHitbox => this.getJabsHitbox();

    public string jabsSkillExtends => this.getJabsSkillExtends();

    public decimal jabsComboSkillId => this.getJabsComboSkillId();
    
    public decimal jabsComboDelay => this.getJabsComboDelay();

    public bool jabsFreeCombo => this.freeComboEnabled();
    
    public decimal jabsActionId => this.getJabsActionId();

    public decimal jabsDuration => this.getJabsDuration();

    public decimal jabsPierceCount => this.getJabsPierceCount();

    public decimal jabsPierceDelay => this.getJabsPierceDelay();
    
    public decimal jabsCooldown => this.getJabsCooldown();

    public decimal jabsCastAnimation => this.getJabsCastAnimation();

    public string jabsPoseSuffix => this.getJabsPoseSuffix();
    
    public decimal jabsPoseIndex => this.getJabsPoseIndex();

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
    /// Extracts the numeric value representing the radius of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The radius of this skill.</returns>
    private decimal getJabsRadius()
    {
        return this.getNumberByTag("radius") ?? decimal.Zero;
    }

    /// <summary>
    /// Extracts the numeric value representing the proximity of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The radius of this skill.</returns>
    private decimal getJabsProximity()
    {
        return this.getNumberByTag("proximity") ?? decimal.Zero;
    }

    /// <summary>
    /// Extracts the enum value representing the hitbox of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The hitbox of this skill.</returns>
    private Hitbox getJabsHitbox()
    {
        // parse the hitbox from the notes.
        var hitbox = this.getStringByTag("hitbox");

        // check if the hitbox can be parsed from the string provided.
        if (Enum.TryParse<Hitbox>(hitbox, true, out var convertedHitbox))
        {
            return convertedHitbox;
        }

        // the default hitbox is that none is associated.
        return Hitbox.None;
    }
    
    /// <summary>
    /// Extracts the string value representing the ids of other skills that are
    /// extended by this skill.
    /// </summary>
    /// <returns>The list of skills that this skill extends.</returns>
    private string getJabsSkillExtends()
    {
        var extensions = this.getStringByTag("skillExtend") ?? string.Empty;

        return extensions.UnwrapBrackets();
    }
    
    /// <summary>
    /// Extracts the numeric value representing the combo follow-up skill id
    /// of this skill in the context of JABS.
    /// </summary>
    /// <returns>The follow-up combo skill of this skill.</returns>
    private decimal getJabsComboSkillId()
    {
        return this.getJabsComboData().comboSkill;
    }
    
    /// <summary>
    /// Extracts the numeric value representing the delay in frames before being able to
    /// execute a combo follow-up skill in the context of JABS.
    /// </summary>
    /// <returns>The delay before able to perform a combo after this skill.</returns>
    private decimal getJabsComboDelay()
    {
        return this.getJabsComboData().comboDelay;
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
        return this.getNumberByTag("cooldown") ?? decimal.Zero;
    }

    /// <summary>
    /// Extracts the numeric value representing the cast animation id of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The cast animation of this skill.</returns>
    private decimal getJabsCastAnimation()
    {
        return this.getNumberByTag("castAnimation") ?? decimal.Zero;
    }

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
    
    /// <summary>
    /// Extracts the numeric value representing the action id of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The radius of this skill.</returns>
    private decimal getJabsActionId()
    {
        return this.getNumberByTag("actionId") ?? decimal.Zero;
    }

    /// <summary>
    /// Extracts the numeric value representing the duration of this skill
    /// in the context of JABS.
    /// </summary>
    /// <returns>The duration of this skill.</returns>
    private decimal getJabsDuration()
    {
        return this.getNumberByTag("duration") ?? decimal.Zero;
    }

    private (decimal comboSkill, decimal comboDelay) getJabsComboData()
    {
        // grab the number data from the combo.
        var combos = this.getNumbersByTag("combo") ?? new List<decimal>();

        // if there are no numbers, then there are no combos.
        if (!combos.Any())
        {
            // return an empty set.
            return (0, 0);
        }

        // return what the collection contained for combo data.
        return (combos[0], combos[1]);
    }
    
    private (decimal pierceCount, decimal pierceDelay) getJabsPierceData()
    {
        // grab the number data from the combo.
        var data = this.getNumbersByTag("pierce") ?? new List<decimal>();

        // if there are no numbers, then there are no combos.
        if (!data.Any())
        {
            // return an empty set.
            return (0, 0);
        }

        // return what the collection contained for combo data.
        return (data[0], data[1]);
    }

    private (string poseSuffix, decimal poseIndex, decimal poseDuration) getJabsPoseData()
    {
        // TODO: extend RPG_Base to have method for retrieving all data split by delimiter.
        return (string.Empty, 0, 0);
    }
}