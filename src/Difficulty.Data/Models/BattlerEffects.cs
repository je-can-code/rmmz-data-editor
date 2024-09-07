namespace JMZ.Difficulty.Data.Models;

/// <summary>
///     All the various multipliers that apply to a battler's parameters.
/// </summary>
public class BattlerEffects
{
    /// <summary>
    ///     The various multipliers against all the base parameters.
    /// </summary>
    public int[] bparams { get; set; } = [1, 0, 0, 0, 0, 0, 0, 0];

    /// <summary>
    ///     The various multipliers against all the ex-parameters.
    /// </summary>
    public int[] xparams { get; set; } = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

    /// <summary>
    ///     The various multipliers against all the sp-parameters.
    /// </summary>
    public int[] sparams { get; set; } = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

    /// <summary>
    ///     The various multipliers against all the custom parameters.
    /// </summary>
    public int[] cparams { get; set; } = Array.Empty<int>();
}