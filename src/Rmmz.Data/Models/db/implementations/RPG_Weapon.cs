using System.Text.Json.Serialization;
using Rmmz.Data.Models.db.core;

namespace Rmmz.Data.Models.db.implementations;

/// <summary>
/// A data model representing a single RMMZ weapon.
/// </summary>
public partial class RPG_Weapon : RPG_EquipItem
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
}