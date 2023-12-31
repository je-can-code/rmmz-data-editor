using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Sdp.Data.Extensions.implementations._Enemy;

public static class SdpKeyExt
{
    public static string GetSdpKey(this RPG_Enemy enemy)
    {
        return  enemy.GetSdpData().Key;
    }
}