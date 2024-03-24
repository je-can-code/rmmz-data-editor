using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Sdp.Data.Extensions.implementations._Enemy;

public static class SdpDropChanceExt
{
    public static decimal GetSdpDropChance(this RPG_Enemy enemy)
    {
        return  enemy.GetSdpData().DropChance;
    }
}