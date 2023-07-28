namespace Rmmz.Data.Tests;

/// <summary>
/// A baseclass for extending tests with.
/// Will provide useful testing utilities to accelerate testing.
/// </summary>
public class BaseTests
{
    /// <summary>
    /// The fake data generator.<br/>
    /// Use this to generate various components of RM objects, or
    /// to generate the RM objects themselves.
    /// </summary>
    protected readonly FDG fdg = new();
}