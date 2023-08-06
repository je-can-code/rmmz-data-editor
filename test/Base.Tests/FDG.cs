using Bogus;
using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Models.db.implementations;
using JabsTags = JMZ.JABS.Data.Models.Tags;
using ExtendTags = JMZ.Extend.Data.Models.Tags;

namespace JMZ.Base.Tests;

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
        var builtTag = JabsTags.SkillId.ToValueTag(tagValue.ToString());
        return builtTag;
    }

    /// <summary>
    /// Generates a speedBoost tag with a given value, or random value if none is provided.
    /// </summary>
    public string SpeedBoostTag(int? input = null)
    {
        var tagValue = input ?? RmmzNumber();
        var builtTag = JabsTags.SpeedBoost.ToValueTag(tagValue.ToString());
        return builtTag;
    }

    /// <summary>
    /// Generates a cooldown tag with a given value, or random value if none is provided.
    /// </summary>
    public string CooldownTag(int? input = null)
    {
        var tagValue = input ?? RmmzUNumber();
        var builtTag = JabsTags.Cooldown.ToValueTag(tagValue.ToString());
        return builtTag;
    }
    
    /// <summary>
    /// Generates a castAnimation tag with a given value, or random value if none is provided.
    /// </summary>
    public string CastAnimationTag(int? input = null)
    {
        var tagValue = input ?? RmmzUNumber();
        var builtTag = JabsTags.CastAnimation.ToValueTag(tagValue.ToString());
        return builtTag;
    }
    
    /// <summary>
    /// Generates a castTime tag with a given value, or random value if none is provided.
    /// </summary>
    public string CastTimeTag(int? input = null)
    {
        var tagValue = input ?? RmmzUNumber();
        var builtTag = JabsTags.CastTime.ToValueTag(tagValue.ToString());
        return builtTag;
    }
    
    /// <summary>
    /// Generates a actionId tag with a given value, or random value if none is provided.
    /// </summary>
    public string ActionIdTag(int? input = null)
    {
        var tagValue = input ?? RmmzUNumber();
        var builtTag = JabsTags.ActionId.ToValueTag(tagValue.ToString());
        return builtTag;
    }
    
    /// <summary>
    /// Generates a duration tag with a given value, or random value if none is provided.
    /// </summary>
    public string DurationTag(int? input = null)
    {
        var tagValue = input ?? RmmzUNumber();
        var builtTag = JabsTags.Duration.ToValueTag(tagValue.ToString());
        return builtTag;
    }
    
    /// <summary>
    /// Generates a duration tag with a given value, or random value if none is provided.
    /// </summary>
    public string HideFromQuickMenuTag()
    {
        return JabsTags.HideFromQuickMenu.ToBooleanTag();
    }
    
    /// <summary>
    /// Generates a direct targeting tag.
    /// </summary>
    public string DirectTargetingTag()
    {
        return JabsTags.Direct.ToBooleanTag();
    }

    /// <summary>
    /// Generates a hitbox tag with a given value, or a random value if none is provided.
    /// Will not generate <see cref="Hitbox.None"/>.
    /// </summary>
    public string HitboxTag(Hitbox? input = null)
    {
        var tagValue = (input ?? this.RandomHitbox()).ToString();
        return JabsTags.Hitbox.ToValueTag(tagValue);
    }

    /// <summary>
    /// Generates a radius tag with a given value, or a random value if none is provided.
    /// </summary>
    public string RadiusTag(decimal? input = null)
    {
        var tagValue = input ?? RmmzDecimal();
        var builtTag = JabsTags.Radius.ToValueTag(tagValue.ToString());
        return builtTag;
    }
    
    /// <summary>
    /// Generates a proximity tag with a given value, or a random value if none is provided.
    /// </summary>
    public string ProximityTag(decimal? input = null)
    {
        var tagValue = input ?? RmmzDecimal();
        var builtTag = JabsTags.Proximity.ToValueTag(tagValue.ToString());
        return builtTag;
    }

    /// <summary>
    /// Generates an AI skill exclusion tag.
    /// </summary>
    public string AiSkillExclusionTag()
    {
        return JabsTags.AiSkillExclusion.ToBooleanTag();
    }

    /// <summary>
    /// Generates a gap closer tag.
    /// </summary>
    public string GapCloserTag()
    {
        return JabsTags.GapCloser.ToBooleanTag();
    }

    public string PoseDataTag()
    {
        var poseSuffix = "-atk";
        var poseIndex = this.RmmzUNumber();
        var poseDuration = this.RmmzUNumber();
        var tag = JabsTags.Pose.ToArrayTag(poseSuffix, poseIndex.ToString(), poseDuration.ToString());
        return tag;
    }

    public string PiercingDataTag(int? inputPierceCount = null, int? inputPierceDelay = null)
    {
        var pierceCount = inputPierceCount ?? this.RmmzUNumber();
        var pierceDelay = inputPierceDelay ?? this.RmmzUNumber();
        var tag = JabsTags.Pierce.ToArrayTag(pierceCount.ToString(), pierceDelay.ToString());
        return tag;
    }
    
    public string ComboDataTag(int? inputComboSkill = null, int? inputComboDelay = null)
    {
        var comboSkill = inputComboSkill ?? this.RmmzUNumber();
        var ComboDelay = inputComboDelay ?? this.RmmzUNumber();
        var tag = JabsTags.Combo.ToArrayTag(comboSkill.ToString(), ComboDelay.ToString());
        return tag;
    }

    public string AiComboStarterTag()
    {
        return JabsTags.AiComboStarter.ToBooleanTag();
    }

    public string FreeComboTag()
    {
        return JabsTags.FreeCombo.ToBooleanTag();
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

    /// <summary>
    /// Generates a random <see cref="Hitbox"/> from the available values in the enum.
    /// Will not generate ordinal 0 aka <see cref="Hitbox.None"/>.
    /// </summary>
    public Hitbox RandomHitbox()
    {
        var values = Enum.GetValues<Hitbox>();
        return values[RNG.Next(1, values.Length)];
    }

    #endregion utility
}