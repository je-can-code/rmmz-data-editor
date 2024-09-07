namespace JMZ.Base.Tests.Utilities;

/// <summary>
///     Extensions for the primitive integer data type.
/// </summary>
public static class IntExtensions
{
    /// <summary>
    ///     Executes an action a given number of times.
    /// </summary>
    public static void Times(this int count, Action action)
    {
        for (var i = 0; i < count; i++)
        {
            action();
        }
    }
}