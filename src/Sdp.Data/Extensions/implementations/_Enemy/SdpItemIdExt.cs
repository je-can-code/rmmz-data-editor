using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Sdp.Data.Extensions.implementations._Enemy;

public static class SdpItemIdExt
{
    public static decimal GetSdpItemId(this RPG_Enemy enemy)
    {
        return  enemy.GetSdpData().ItemId;
    }
}