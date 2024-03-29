namespace JMZ.Difficulty.Data.Models;

/// <summary>
/// The various types of battler effects that can be applied.
/// </summary>
public enum BattlerEffectType
{
    /// <summary>
    /// The "base" set of parameters, including the core status of MHP and DEF.
    /// </summary>
    BASE,
    
    /// <summary>
    /// The "extra" set of parameters, including CRIT and the regens.
    /// </summary>
    EX,
    
    /// <summary>
    /// The "special" set of parameters, including AGGRO and the cost modifiers.
    /// </summary>
    SP,
    
    /// <summary>
    /// The custom parameters, including all those that are beyond the "standard" RMMZ parameters.
    /// </summary>
    CUSTOM
}