using JMZ.Rmmz.Data.Models.db.core;

namespace JMZ.Rmmz.Data.Models.db.implementations;

/// <summary>
/// A data model representing a single RMMZ item.
/// </summary>
public class RPG_Item : RPG_UsableItem
{
    /// <summary>
    /// Whether or not this item is removed after using it.
    /// </summary>
    public bool consumable { get; set; } = true;

    /// <summary>
    /// The type of item this is.<br/>
    /// 0 for "regular items".<br/>
    /// 1 for "key items".<br/>
    /// 2 for "hiddenA items".<br/>
    /// 3 for "hiddenB items".
    /// </summary>
    public int itypeId { get; set; } = 0;

    /// <summary>
    /// The price of the item, in an RPG context.
    /// </summary>
    public int price { get; set; } = 0;

    /// <summary>
    /// The type of item this is.<br/>
    /// Items are always of type 1.
    /// </summary>
    public int kind => 1;
}