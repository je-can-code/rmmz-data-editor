using JMZ.Rmmz.Data.Models.db.@base;

namespace JMZ.Rmmz.Data.Models.db.implementations;

/// <summary>
///     A data model representing a single RMMZ state.
/// </summary>
public class RPG_State : RPG_Traited
{
    /// <summary>
    ///     The automatic removal timing type.<br />
    ///     0 is "None" aka can only be removed by user interaction.<br />
    ///     1 is "Action End" aka will consider removal chances after an action is performed.<br />
    ///     2 is "Turn End" aka will consider removal chances after the inflicted's turn ends.<br />
    /// </summary>
    public int autoRemovalTiming { get; set; } = 0;

    /// <summary>
    ///     The percent chance that receiving damage will remove this state.<br />
    ///     Requires <see cref="removeByDamage" /> to be set to true for this to work.
    /// </summary>
    public int chanceByDamage { get; set; } = 100;

    /// <summary>
    ///     The maximum number of turns this state can persist.<br />
    ///     Requires <see cref="restriction" /> to not be set to 0 for this to work.
    /// </summary>
    public int maxTurns { get; set; } = 1;

    /// <summary>
    ///     "If an actor is inflicted with this state..."
    /// </summary>
    public string message1 { get; set; } = string.Empty;

    /// <summary>
    ///     "If an enemy is inflicted with this state..."
    /// </summary>
    public string message2 { get; set; } = string.Empty;

    /// <summary>
    ///     "If the state persists..."
    /// </summary>
    public string message3 { get; set; } = string.Empty;

    /// <summary>
    ///     "If the state is removed..."
    /// </summary>
    public string message4 { get; set; } = string.Empty;

    /// <summary>
    ///     The type of message this is.
    ///     (unsure what this actually means or does in the context of RMMZ)
    /// </summary>
    public int messageType { get; set; } = 1;

    /// <summary>
    ///     The minimum number of turns this state will persist.<br />
    ///     Requires <see cref="restriction" /> to not be set to 0 for this to work.
    /// </summary>
    public int minTurns { get; set; } = 1;

    /// <summary>
    ///     The motion the sideview battler will show while afflicted with this skill.
    /// </summary>
    public int motion { get; set; } = 0;

    /// <summary>
    ///     The state overlay id that shows up over the battler while this state is afflicted.
    /// </summary>
    public int overlay { get; set; } = 0;

    /// <summary>
    ///     The priority of the state in regards to other states and their restrictions.
    /// </summary>
    public int priority { get; set; } = 50;

    /// <summary>
    ///     Whether or not this state will be removed automatically when a battle ends.
    /// </summary>
    public bool removeAtBattleEnd { get; set; } = false;

    /// <summary>
    ///     Whether or not this state can be removed when receiving damage from a skill.
    /// </summary>
    public bool removeByDamage { get; set; } = false;

    /// <summary>
    ///     Whether or not this state can be removed by applying a different state that
    ///     has a higher <see cref="restriction" /> type/value.
    /// </summary>
    public bool removeByRestriction { get; set; } = false;

    /// <summary>
    ///     Whether or not this state can be removed by taking the <see cref="stepsToRemove" /> number
    ///     of steps while afflicted with this state.
    /// </summary>
    public bool removeByWalking { get; set; } = false;

    /// <summary>
    ///     The type of restriction this state has.<br />
    ///     0 is "None" aka the state does not "restrict" at all.<br />
    ///     1 is "Attack an enemy" aka the state forces the user to only attack, targeting enemies, during battle.<br />
    ///     2 is "Attack anyone" aka the state forces the user to only attack, targeting allies or enemies, during battle.
    ///     <br />
    ///     3 is "Attack an ally" aka the state forces the user to only attack, targeting allies, during battle.
    /// </summary>
    public int restriction { get; set; } = 0;

    /// <summary>
    ///     The number of steps required to take to remove this state.<br />
    ///     Requires <see cref="removeByWalking" /> to be set to true for this to work.
    /// </summary>
    public int stepsToRemove { get; set; } = 60;
}