using JMZ.Rmmz.Data.Models.db.core;

namespace JMZ.Rmmz.Data.Models.db.implementations;

/// <summary>
///     A data model representing a single RMMZ armor.
/// </summary>
public class RPG_Armor : RPG_EquipItem
{
    /// <summary>
    ///     The type of armor this is.
    ///     This number is the index that maps to your armor types.
    /// </summary>
    public int atypeId { get; set; } = 1;

    /// <summary>
    ///     The type of item this is.<br />
    ///     Armors are always of type 3.
    /// </summary>
    public int kind => 3;
}