using Dashboard.Models.Tags;

namespace Dashboard.Models.JABS;

/// <summary>
/// A typed representation of all the various JABS-related tag names.
/// </summary>
internal sealed class RmmzTags : AbstractRmmzTags
{
    public static RmmzTags SkillId { get; }
    public static RmmzTags HideFromJabsMenu { get; }
    public static RmmzTags Combo { get; }
    public static RmmzTags Pose { get; }
    public static RmmzTags Pierce { get; }
    public static RmmzTags Duration { get; }
    public static RmmzTags ActionId { get; }
    public static RmmzTags Radius { get; }
    public static RmmzTags Proximity { get; }
    public static RmmzTags Hitbox { get; }

    /// <summary>
    /// Static constructor for initializing the statically typed tag names.
    /// These could be declared upon creation of the properties, but then
    /// we'd have some really long lines for the complicated/longer regexes like hitbox.
    /// </summary>
    static RmmzTags()
    {
        // weapons.
        SkillId = new("skillId");
        
        // skills.
        Radius = new("radius", @"<radius:[ ]?((0|([1-9][0-9]*))(\.[0-9]+)?)>");
        Proximity = new("proximity", @"<proximity:[ ]?((0|([1-9][0-9]*))(\.[0-9]+)?)>");
        Hitbox = new("hitbox", @"<hitbox:[ ]?(circle|rhombus|square|frontsquare|line|arc|wall|cross)>");
        Combo = new("combo", @"<combo:[ ]?(\[\d+,[ ]?\d+])>");
        Pose = new("poseSuffix");
        Pierce = new("pierce");
        Duration = new("duration", @"<duration:[ ]?(\d+)>");
        ActionId = new("actionId", @"<actionId:[ ]?(\d+)>");
        HideFromJabsMenu = new("hideFromJabsMenu"); // is a boolean tag.
    }

    /// <summary>
    /// Constructor for boolean tags.
    /// </summary>
    /// <param name="name">The name of this tag as a string.</param>
    private RmmzTags(string name) : base(name)
    {
    }
    
    /// <summary>
    /// Constructor for tags that use a regex to capture their value.
    /// </summary>
    /// <param name="name">The name of this tag as a string.</param>
    /// <param name="regex">The regex of this tag.</param>
    private RmmzTags(string name, string regex) : base(name, regex)
    {
    }
}