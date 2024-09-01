using JMZ.Rmmz.Data.Tags;

namespace JMZ.JABS.Data.Models;

public static class Tags
{
    public static Tag SkillId { get; }
    
    public static Tag HideFromQuickMenu { get; }
    
    public static Tag Pose { get; }
    
    public static Tag Pierce { get; }
    
    public static Tag Duration { get; }
    public static Tag ActionId { get; }
    
    public static Tag Direct { get; }
    public static Tag Radius { get; }
    public static Tag Proximity { get; }
    public static Tag Hitbox { get; }
    
    public static Tag Sight { get; }
    public static Tag AlertedSightBoost { get; }
    public static Tag Pursuit { get; }
    public static Tag AlertedPursuitBoost { get; }
    
    
    public static Tag Cooldown { get; }
    public static Tag CastAnimation { get; }
    public static Tag CastTime { get; }
    public static Tag GapCloser { get; }

    public static Tag Combo { get; }
    public static Tag FreeCombo { get; }
    public static Tag AiComboStarter { get; }
    public static Tag AiSkillExclusion { get; }
    
    public static Tag SpeedBoost { get; }
    
    public static Tag AiTraitCareful { get; }
    public static Tag AiTraitExecutor { get; }
    public static Tag AiTraitReckless { get; }
    public static Tag AiTraitHealer { get; }
    public static Tag AiTraitLeader { get; }
    public static Tag AiTraitFollower { get; }

    static Tags()
    {
        // weapons.
        SkillId = skillId();
        
        // skills.
        HideFromQuickMenu = new("hideFromJabsMenu");

        Pose = pose();

        Pierce = pierce();

        Direct = new("direct");
        Radius = radius();
        Proximity = proximity();
        Hitbox = hitbox();
        
        Duration = new("duration", @"<duration:[ ]?(\d+)>");
        ActionId = new("actionId", @"<actionId:[ ]?(\d+)>");

        Sight = sight();
        AlertedSightBoost = alertedSightBoost();
        Pursuit = pursuit();
        AlertedPursuitBoost = alertedPursuitBoost();
        
        Cooldown = new("cooldown", @"<cooldown:[ ]?(\d+)>");
        CastAnimation = new("castAnimation", @"<castAnimation:[ ]?(\d+)>");
        CastTime = new("castTime", @"<castTime:[ ]?(\d+)>");
        GapCloser = new("gapClose");
        
        Combo = combo();
        FreeCombo = new("freeCombo");
        AiComboStarter = new("comboStarter");
        AiSkillExclusion = new("aiSkillExclusion");

        SpeedBoost = speedBoost();

        AiTraitCareful = aiTraitCareful();
        AiTraitExecutor = aiTraitExecutor();
        AiTraitReckless = aiTraitReckless();
        AiTraitHealer = aiTraitHealer();
        AiTraitLeader = aiTraitLeader();
        AiTraitFollower = aiTraitFollower();
    }

    private static Tag skillId()
    {
        var tag = "skillId";
        var regex = @"<skillId:[ ]?(\d+)>";
        var description = 
            "The id of the skill triggered when this weapon is used in combat.\n" +
            "\n" +
            "Set this to 0 to remove the tag.";
        return new(tag, regex, description);
    }

    private static Tag radius()
    {
        var tag = "radius";
        var regex = @"<radius:[ ]?((0|([1-9][0-9]*))(\.[0-9]+)?)>";
        var description = 
            "The radius or range of this skill.\n" +
            "The radius works in combination with the hitbox to determine the collision vector of this skill.\n" +
            "\n" +
            "When this is set to a negative value, the tag will be removed.";
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
            "meaning if they are within this distance, no additional movement will be required to perform this skill." +
            "\n" +
            "When this is set to a negative value, the tag will be removed.";
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

    private static Tag pierce()
    {
        var tag = "pierce";
        var regex = @"<pierce:[ ]?(\[\d+,[ ]?\d+])>";
        var countDescription =
            "The total number of times this skill can connect with targets before expiring.";
        var delayDescription =
            "The number of frames that must pass before this skill can pierce the same target again.";
        return new(tag, regex, countDescription, delayDescription);
    }

    private static Tag pose()
    {
        var tag = "poseSuffix";
        var regex = @"<poseSuffix:[ ]?(\[[-_]?\w+,[ ]?\d+,[ ]?\d+])>";
        var suffixDescription =
            "The suffix that will be appended to the character's default spritesheet to determine the pose's spritesheet.\n" +
            "For example, if the base sheet is 'hero.png', and the suffix is '-atk', then the sheet that will be used\n" +
            "is 'hero-atk.png'.";
        var indexDescription =
            "The index of the spritesheet to use.\n" +
            "Poses were designed to be a part of larger spritesheet, and is not compatible with single-character sheets.";
        var durationDescription = "The number of frames that will be spent before returning to the original pose";
        return new(tag, regex, suffixDescription, indexDescription, durationDescription);
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

    private static Tag sight()
    {
        var tag = "sight";
        var regex = @"<sight:[ ]?((0|([1-9][0-9]*))(\.[0-9]+)?)>";
        var description = 
            "The sight of this battler.\n" +
            "Sight represents the distance in tiles a particular battler can see.\n" +
            "Obstructions are not considered.\n" +
            "\n" +
            "When this is set to a negative value, the tag will be removed.";
        return new(tag, regex, description);
    }
    
    private static Tag alertedSightBoost()
    {
        var tag = "alertedSightBoost";
        var regex = @"<alertedSightBoost:[ ]?((0|([1-9][0-9]*))(\.[0-9]+)?)>";
        var description = 
            "The sight bonus when this battler is alerted.\n" +
            "Sight Alerted represents the bonus a battler gets when they are not in combat but notice an enemy.\n" +
            "Obstructions are not considered.\n" +
            "\n" +
            "When this is set to a negative value, the tag will be removed.";
        return new(tag, regex, description);
    }
    
    private static Tag pursuit()
    {
        var tag = "pursuit";
        var regex = @"<pursuit:[ ]?((0|([1-9][0-9]*))(\.[0-9]+)?)>";
        var description = 
            "The pursuit of this battler.\n" +
            "Pursuit effectively replaces Sight once a battler is engaged in combat.\n" +
            "Obstructions are not considered.\n" +
            "\n" +
            "When this is set to a negative value, the tag will be removed.";
        return new(tag, regex, description);
    }
    
    private static Tag alertedPursuitBoost()
    {
        var tag = "alertedPursuitBoost";
        var regex = @"<alertedPursuitBoost:[ ]?((0|([1-9][0-9]*))(\.[0-9]+)?)>";
        var description = 
            "The pursuit of this battler.\n" +
            "Pursuit effectively replaces Sight once a battler is engaged in combat.\n" +
            "Obstructions are not considered.\n" +
            "\n" +
            "When this is set to a negative value, the tag will be removed.";
        return new(tag, regex, description);
    }

    private static Tag aiTraitCareful()
    {
        var tag = "aiTrait:careful";
        var regex = @"<aiTrait:[ ]?careful>";
        var description =
            "Whether or not this battler has the AI trait of 'careful'.";
        return new(tag, regex, description);
    }
    
    private static Tag aiTraitExecutor()
    {
        var tag = "aiTrait:executor";
        var regex = @"<aiTrait:[ ]?executor>";
        var description =
            "Whether or not this battler has the AI trait of 'executor'.";
        return new(tag, regex, description);
    }
    
    private static Tag aiTraitReckless()
    {
        var tag = "aiTrait:reckless";
        var regex = @"<aiTrait:[ ]?reckless>";
        var description =
            "Whether or not this battler has the AI trait of 'reckless'.";
        return new(tag, regex, description);
    }
    
    private static Tag aiTraitHealer()
    {
        var tag = "aiTrait:healer";
        var regex = @"<aiTrait:[ ]?healer>";
        var description =
            "Whether or not this battler has the AI trait of 'healer'.";
        return new(tag, regex, description);
    }
    
    private static Tag aiTraitLeader()
    {
        var tag = "aiTrait:leader";
        var regex = @"<aiTrait:[ ]?leader>";
        var description =
            "Whether or not this battler has the AI trait of 'leader'.";
        return new(tag, regex, description);
    }
    
    private static Tag aiTraitFollower()
    {
        var tag = "aiTrait:follower";
        var regex = @"<aiTrait:[ ]?follower>";
        var description =
            "Whether or not this battler has the AI trait of 'follower'.";
        return new(tag, regex, description);
    }
}