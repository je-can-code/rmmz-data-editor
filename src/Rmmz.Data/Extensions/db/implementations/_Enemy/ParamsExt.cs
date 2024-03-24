using JMZ.Rmmz.Data.Models;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Rmmz.Data.Extensions.db.implementations._Enemy;

public static class ParamsExt
{
    public static int GetBaseParamMaxHp(this RPG_Enemy enemy)
    {
        return enemy.GetBaseParamByIndex(ParameterId.MAX_HP);
    }

    public static void UpdateBaseParamMaxHp(this RPG_Enemy enemy, decimal newParam)
    {
        enemy.UpdateBaseParamByIndex(ParameterId.MAX_HP, newParam);
    }

    public static int GetBaseParamMaxMp(this RPG_Enemy enemy)
    {
        return enemy.GetBaseParamByIndex(ParameterId.MAX_MP);
    }
    
    public static void UpdateBaseParamMaxMp(this RPG_Enemy enemy, decimal newParam)
    {
        enemy.UpdateBaseParamByIndex(ParameterId.MAX_MP, newParam);
    }
    
    public static int GetBaseParamPower(this RPG_Enemy enemy)
    {
        return enemy.GetBaseParamByIndex(ParameterId.POWER);
    }
    
    public static void UpdateBaseParamPower(this RPG_Enemy enemy, decimal newParam)
    {
        enemy.UpdateBaseParamByIndex(ParameterId.POWER, newParam);
    }
    
    public static int GetBaseParamEndurance(this RPG_Enemy enemy)
    {
        return enemy.GetBaseParamByIndex(ParameterId.ENDURANCE);
    }
    
    public static void UpdateBaseParamEndurance(this RPG_Enemy enemy, decimal newParam)
    {
        enemy.UpdateBaseParamByIndex(ParameterId.ENDURANCE, newParam);
    }
    
    public static int GetBaseParamForce(this RPG_Enemy enemy)
    {
        return enemy.GetBaseParamByIndex(ParameterId.FORCE);
    }
    
    public static void UpdateBaseParamForce(this RPG_Enemy enemy, decimal newParam)
    {
        enemy.UpdateBaseParamByIndex(ParameterId.FORCE, newParam);
    }
    
    public static int GetBaseParamResistance(this RPG_Enemy enemy)
    {
        return enemy.GetBaseParamByIndex(ParameterId.RESISTANCE);
    }
    
    public static void UpdateBaseParamResistance(this RPG_Enemy enemy, decimal newParam)
    {
        enemy.UpdateBaseParamByIndex(ParameterId.RESISTANCE, newParam);
    }
    
    public static int GetBaseParamSpeed(this RPG_Enemy enemy)
    {
        return enemy.GetBaseParamByIndex(ParameterId.SPEED);
    }
    
    public static void UpdateBaseParamSpeed(this RPG_Enemy enemy, decimal newParam)
    {
        enemy.UpdateBaseParamByIndex(ParameterId.SPEED, newParam);
    }
    
    public static int GetBaseParamLuck(this RPG_Enemy enemy)
    {
        return enemy.GetBaseParamByIndex(ParameterId.LUCK);
    }
    
    public static void UpdateBaseParamLuck(this RPG_Enemy enemy, decimal newParam)
    {
        enemy.UpdateBaseParamByIndex(ParameterId.LUCK, newParam);
    }
    
    private static int[] GetBaseParams(this RPG_Enemy enemy)
    {
        return enemy.@params;
    }

    private static int GetBaseParamByIndex(this RPG_Enemy enemy, int paramIndex)
    {
        return enemy.GetBaseParams()[paramIndex];
    }

    private static void UpdateBaseParamByIndex(
        this RPG_Enemy enemy,
        int paramIndex,
        decimal newParamaValue)
    {
        enemy.GetBaseParams()[paramIndex] = (int) newParamaValue;
    }
}