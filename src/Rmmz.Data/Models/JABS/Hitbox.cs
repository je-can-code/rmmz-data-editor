namespace JMZ.Rmmz.Data.Models.JABS;

/// <summary>
/// Represents all currently available hitboxes used in JABS.
/// </summary>
public enum Hitbox
{
    /// <summary>
    /// <see cref="Hitbox.None"/> represents that a skill has no hitbox
    /// associated with it in the tags of a skill. If a skill is assigned
    /// this value, the tag will instead be removed from the skill.
    /// </summary>
    None,
    
    Circle,
    Rhombus,
    Square,
    FrontSquare,
    Line,
    Arc,
    Wall,
    Cross,
}