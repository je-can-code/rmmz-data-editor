using Bogus;
using Dashboard.Models.db.implementations;
using Dashboard.Models.JABS;

namespace Dashboard.Tests;

/// <summary>
/// The fake data generator.
/// Used in test for generating various objects.
/// </summary>
public class FDG
{
    private readonly Random RNG = new(1337);

    public RPG_Weapon GenerateWeapon()
    {
        return new Faker<RPG_Weapon>()
            .RuleFor(weapon => weapon.note, (f, w) =>
            {
                var fakeSkillIdTag = SkillIdTag();
                var fakeSpeedBoostTag = SpeedBoostTag();
                
                return BuildNoteTag(fakeSkillIdTag, fakeSpeedBoostTag);
            })
            .Generate();
    }

    public RPG_Skill GenerateSkill()
    {
        return new Faker<RPG_Skill>().Generate();
    }

    /// <summary>
    /// Generates a skillId tag with a given skill id, or random skill id if none is provided.
    /// </summary>
    public string SkillIdTag(int? input = null)
    {
        var tagValue = input ?? RmmzUNumber();
        var builtTag = Tags.SkillId.ToValueTag(tagValue.ToString());
        return builtTag;
    }

    /// <summary>
    /// Generates a speedBoost tag with a given value, or random value if none is provided.
    /// </summary>
    public string SpeedBoostTag(int? input = null)
    {
        var tagValue = input ?? RmmzNumber();
        var builtTag = Tags.SpeedBoost.ToValueTag(tagValue.ToString());
        return builtTag;
    }

    /// <summary>
    /// Generates a cooldown tag with a given value, or random value if none is provided.
    /// </summary>
    public string CooldownTag(int? input = null)
    {
        var tagValue = input ?? RmmzUNumber();
        var builtTag = Tags.Cooldown.ToValueTag(tagValue.ToString());
        return builtTag;
    }
    
    /// <summary>
    /// Generates a castAnimation tag with a given value, or random value if none is provided.
    /// </summary>
    public string CastAnimationTag(int? input = null)
    {
        var tagValue = input ?? RmmzUNumber();
        var builtTag = Tags.CastAnimation.ToValueTag(tagValue.ToString());
        return builtTag;
    }
    
    /// <summary>
    /// Generates a castTime tag with a given value, or random value if none is provided.
    /// </summary>
    public string CastTimeTag(int? input = null)
    {
        var tagValue = input ?? RmmzUNumber();
        var builtTag = Tags.CastTime.ToValueTag(tagValue.ToString());
        return builtTag;
    }
    
    /// <summary>
    /// Generates a actionId tag with a given value, or random value if none is provided.
    /// </summary>
    public string ActionIdTag(int? input = null)
    {
        var tagValue = input ?? RmmzUNumber();
        var builtTag = Tags.ActionId.ToValueTag(tagValue.ToString());
        return builtTag;
    }
    
    /// <summary>
    /// Generates a duration tag with a given value, or random value if none is provided.
    /// </summary>
    public string DurationTag(int? input = null)
    {
        var tagValue = input ?? RmmzUNumber();
        var builtTag = Tags.Duration.ToValueTag(tagValue.ToString());
        return builtTag;
    }
    
    /// <summary>
    /// Generates a duration tag with a given value, or random value if none is provided.
    /// </summary>
    public string HideFromQuickMenuTag()
    {
        return Tags.HideFromJabsMenu.ToBooleanTag();
    }
    
    #region utility
    /// <summary>
    /// Connects all lines together with a "\n" between each.
    /// </summary>
    /// <param name="lines">The various tags intended to in a single note.</param>
    public string BuildNoteTag(params string[] lines)
    {
        return string.Join("\n", lines);
    }

    /// <summary>
    /// Generates a random whole number between 1 and 500.
    /// This is a small number deliberately since most values used in RMMZ are pretty small.
    /// </summary>
    public int RmmzUNumber()
    {
        return RNG.Next(1, 501);
    }

    /// <summary>
    /// Generates a random whole number between -500 and 500.
    /// This is a small number deliberately since most values used in RMMZ are pretty small,
    /// and includes negative lower bounds to accommodate possible detriment effects.
    /// </summary>
    public int RmmzNumber()
    {
        return RNG.Next(-500, 501);
    }

    /// <summary>
    /// Generates a random decimal number between 1 and 500.
    /// This uses the above <see cref="RmmzUNumber"/> to generate both sides as a string, and parses it
    /// to produce the given decimal.
    /// </summary>
    public decimal RmmzDecimal()
    {
        var left = RmmzUNumber();
        var right = RmmzUNumber();
        var combined = $"{left}.{right}";
        return decimal.Parse(combined);
    }
    #endregion utility
}