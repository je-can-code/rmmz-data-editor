using JMZ.Rmmz.Data.Models.db._data;
using JMZ.Rmmz.Data.Models.db.@base;

namespace JMZ.Rmmz.Data.Models.db.implementations;

public class RPG_Enemy : RPG_BaseBattler
{
    public List<RPG_EnemyAction> actions { get; set; } = new();

    public int battlerHue { get; set; } = 0;

    public List<RPG_DropItem> dropItems { get; set; } = new();

    public int exp { get; set; } = 0;

    public int gold { get; set; } = 0;
    
    public int[] @params { get; set; } = { 1, 0, 0, 0, 0, 0, 0, 0 };
}