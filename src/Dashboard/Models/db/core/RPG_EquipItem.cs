using Dashboard.Models.db.@base;

namespace Dashboard.Models.db.core;

/// <summary>
/// A data model containing common properties found in both weapons and armor.
/// </summary>
public class RPG_EquipItem : RPG_Traited
{
    /// <summary>
    /// The type of equip this is.
    /// This number is the index that maps to your equip types.
    /// </summary>
    public int etypeId { get; set; } = 1;

    /// <summary>
    /// The core parameters that all battlers have:
    /// MHP, MMP, ATK, DEF, MAT, MDF, SPD, LUK
    /// in that order.
    /// </summary>
    public int[] @params { get; set; } = Array.Empty<int>();

    /// <summary>
    /// The price of this equip.
    /// </summary>
    public int price { get; set; } = 0;
}