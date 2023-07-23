namespace Dashboard.Tests;

public class BaseTests
{
    /// <summary>
    /// The fake data generator.<br/>
    /// Use this to generate various components of RM objects, or
    /// to generate the RM objects themselves.
    /// </summary>
    internal readonly FDG fdg;

    protected BaseTests()
    {
        this.fdg = new();
    }
}