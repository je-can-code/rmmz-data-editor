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
                var fakeSkillIdTag = RandomSkillIdTaR();
                var fakeSpeedBoostTag = RandomSpeedBoostTag();
                return BuildNoteTag(fakeSkillIdTag, fakeSpeedBoostTag);
            })
            .Generate();
    }

    /// <summary>
    /// Generates a skillId tag with a random skill id value inside.
    /// </summary>
    public string RandomSkillIdTaR()
    {
        return this.SkillIdTag(RmmzUNumber());
    }

    public string SkillIdTag(int? input)
    {
        var tagValue = input ?? RmmzUNumber();
        var builtTag = Tags.SkillId.ToValueTag(tagValue.ToString());
        return builtTag;
    }

    /// <summary>
    /// Generates a speedBoost tag with a random speed boost value inside.
    /// </summary>
    public string RandomSpeedBoostTag()
    {
        return this.SpeedBoostTag(this.RmmzUNumber());
    }
    
    public string SpeedBoostTag(decimal? input)
    {
        var tagValue = input ?? RmmzNumber();
        var builtTag = Tags.SpeedBoost.ToValueTag(tagValue.ToString());
        return builtTag;
    }

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
    /// Generates a random whole number between -255 and 500.
    /// This is a small number deliberately since most values used in RMMZ are pretty small,
    /// and includes negative lower bounds to accommodate possible detriment effects.
    /// </summary>
    public int RmmzNumber()
    {
        return RNG.Next(-255, 501);
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
}