using JMZ.Rmmz.Data.Models.db.core;

namespace JMZ.Rmmz.Data.Models.db.implementations;

/// <summary>
/// A data model representing a single skill from the database.
/// </summary>
public partial class RPG_Skill : RPG_UsableItem
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
}