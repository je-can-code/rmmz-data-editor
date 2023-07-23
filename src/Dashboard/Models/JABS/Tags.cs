using Dashboard.Models.Tags;

namespace Dashboard.Models.JABS;

internal static class Tags
{
    public static Tag SkillId { get; }
    
    public static Tag HideFromJabsMenu { get; }
    
    public static Tag Pose { get; }
    
    public static Tag Pierce { get; }
    
    public static Tag Duration { get; }
    public static Tag ActionId { get; }
    
    
    public static Tag Direct { get; }
    public static Tag Radius { get; }
    public static Tag Proximity { get; }
    public static Tag Hitbox { get; }
    
    public static Tag Cooldown { get; }
    public static Tag CastAnimation { get; }
    public static Tag CastTime { get; }
    public static Tag GapCloser { get; }

    public static Tag Combo { get; }
    public static Tag FreeCombo { get; }
    public static Tag AiComboStarter { get; }
    public static Tag AiSkillExclusion { get; }
    
    public static Tag SpeedBoost { get; }

    static Tags()
    {
        // weapons.
        SkillId = new("skillId");
        
        // skills.
        HideFromJabsMenu = new("hideFromJabsMenu");

        Pose = new("poseSuffix", @"<poseSuffix:[ ]?(\[[-_]?\w+,[ ]?\d+,[ ]?\d+])>");

        Pierce = new("pierce");

        Direct = new("direct");
        Radius = radius();
        Proximity = proximity();
        Hitbox = hitbox();
        
        Duration = new("duration", @"<duration:[ ]?(\d+)>");
        ActionId = new("actionId", @"<actionId:[ ]?(\d+)>");
        
        Cooldown = new("cooldown", @"<cooldown:[ ]?(\d+)>");
        CastAnimation = new("castAnimation", @"<castAnimation:[ ]?(\d+)>");
        CastTime = new("castTime", @"<castTime:[ ]?(\d+)>");
        GapCloser = new("gapClose");
        
        Combo = combo();
        FreeCombo = new("freeCombo");
        AiComboStarter = new("comboStarter");
        AiSkillExclusion = new("aiSkillExclusion");

        SpeedBoost = speedBoost();
    }
    
    private static Tag radius()
    {
        var tag = "radius";
        var regex = @"<radius:[ ]?((0|([1-9][0-9]*))(\.[0-9]+)?)>";
        var description = 
            "The radius or range of this skill.\n" +
            "The radius works in combination with the hitbox to determine the collision vector of this skill.\n" +
            "\n" +
            "Set this to -0.1 to remove the tag.";
        return new(tag, regex, description);
    }

    private static Tag proximity()
    {
        var tag = "proximity";
        var regex = @"<proximity:[ ]?((0|([1-9][0-9]*))(\.[0-9]+)?)>";
        var description =
            "The proximity or maximum casting distance of this skill.\n" +
            "If this skill is also 'direct', then this value represents the distance from the caster\n" +
            "from which a target may be considered- priority to the closest targets.\n" +
            "\n" +
            "For AI-controlled characters, the proximity defines the furthest they may execute this skill from-\n" +
            "meaning if they are within this distance, no additional movement will be required to perform this skill.";
        return new(tag, regex, description);
    }
    
    private static Tag hitbox()
    {
        var tag = "hitbox";
        var regex = @"<hitbox:[ ]?(circle|rhombus|square|frontsquare|line|arc|wall|cross)>";
        var description =
            "The hitbox represents the shape of the collision vector for this skill.\n\n" +
            "Circle: A relatively pixel-perfect circle hitbox.\n" +
            "Rhombus: A diamond-shaped hitbox.\n" +
            "Square: A square-shaped hitbox.\n" +
            "Front Square: A square hitbox that does not include any of the square collision behind the caster.\n" +
            "Line: A line-shaped hitbox, where the radius impacts how far the line reaches, not how wide the line is.\n" +
            "Arc: A circle-shaped hitbox that does not include any of the circle collision behind the caster.\n" +
            "Wall: A line-shaped hitbox, where the radius impacts how wide the line is, not how far the line reaches.\n" +
            "Cross: A combination of 'Line' and 'Wall' hitboxes, centered on the caster, where radius impacts how far the lines reach.";
        return new(tag, regex, description);
    }
    
    private static Tag combo()
    {
        var tag = "combo";
        var regex = @"<combo:[ ]?(\[\d+,[ ]?\d+])>";
        var skillDescription =
            "The combo skill defines what skills will become enabled upon execution of this skill.\n" +
            "\n" +
            "If the combo skill is a skill the user does not know, then the skill will not execute.\n" +
            "If the combo skill is NOT flagged with '<comboStarter>', the AI will not be able to start or execute this combo.\n" +
            "\n";
        var delayDescription =
            "The combo delay represents the number of frames the user must wait before executing the combo skill.";
        return new(tag, regex, skillDescription, delayDescription);
    }

    private static Tag speedBoost()
    {
        var tag = "speedBoost";
        var regex = @"<speedBoost:[ ]?((0|([1-9][0-9]*))(\.[0-9]+)?)>";
        var description = 
            "The additive percent-based speedboost provided.\n" +
            "The speedboost provides a literal percent boost to the battler's movespeed on the map.\n" +
            "\n" +
            "Set this to 0.0 to remove the tag.";
        return new(tag, regex, description);
    }
}