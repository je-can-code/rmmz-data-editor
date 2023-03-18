using Dashboard.Models.Tags;

namespace Dashboard.Models.SkillExtend;

/// <summary>
/// A typed representation of all the various skill extend tag names.
/// </summary>
internal sealed class RmmzTags : AbstractRmmzTags
{
    public static RmmzTags Extend { get; }

    /// <summary>
    /// Static constructor for initializing the statically typed tag names.
    /// </summary>
    static RmmzTags()
    {
        Extend = new("skillExtend");
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="name">The name of this tag as a string.</param>
    private RmmzTags(string name) : base(name)
    {
    }
}