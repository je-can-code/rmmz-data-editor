﻿using Bogus;
using JMZ.Base.Tests.Utilities;
using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Models.db._data;
using JMZ.Rmmz.Data.Models.db.implementations;
using JabsTags = JMZ.JABS.Data.Models.Tags;

namespace JMZ.Base.Tests;

/// <summary>
/// The fake data generator.
/// Used in test for generating various objects.
/// </summary>
public class FDG
{
    private readonly Random RNG = new(1337);

    private readonly Faker FAKER = new();

    public RPG_Weapon GenerateWeapon()
    {
        return new Faker<RPG_Weapon>()
            .RuleFor(weapon => weapon.note, (f, w) =>
            {
                var fakeSkillIdTag = this.SkillIdTag();
                var fakeSpeedBoostTag = this.SpeedBoostTag();
                
                return this.BuildNoteTag(fakeSkillIdTag, fakeSpeedBoostTag);
            })
            .Generate();
    }

    public RPG_Skill GenerateSkill()
    {
        return new Faker<RPG_Skill>().Generate();
    }
    
    public RPG_DropItem GenerateDropItem()
    {
        return new()
        {
            kind = this.RNG.Next(2),
            dataId = this.RmmzUNumber(),
            denominator = this.RNG.Next(1, 101)
        };
    }

    public List<RPG_DropItem> GenerateDropItems(int count)
    {
        var drops = new List<RPG_DropItem>();
        count.Times(() => drops.Add(this.GenerateDropItem()));
        return drops;
    }

    #region tags
    /// <summary>
    /// Generates a skillId tag with a given skill id, or random skill id if none is provided.
    /// </summary>
    public string SkillIdTag(int? input = null)
    {
        var tagValue = input ?? this.RmmzUNumber();
        var builtTag = JabsTags.SkillId.ToValueTag(tagValue.ToString());
        return builtTag;
    }

    /// <summary>
    /// Generates a speedBoost tag with a given value, or random value if none is provided.
    /// </summary>
    public string SpeedBoostTag(int? input = null)
    {
        var tagValue = input ?? this.RmmzNumber();
        var builtTag = JabsTags.SpeedBoost.ToValueTag(tagValue.ToString());
        return builtTag;
    }

    /// <summary>
    /// Generates a cooldown tag with a given value, or random value if none is provided.
    /// </summary>
    public string CooldownTag(int? input = null)
    {
        var tagValue = input ?? this.RmmzUNumber();
        var builtTag = JabsTags.Cooldown.ToValueTag(tagValue.ToString());
        return builtTag;
    }
    
    /// <summary>
    /// Generates a castAnimation tag with a given value, or random value if none is provided.
    /// </summary>
    public string CastAnimationTag(int? input = null)
    {
        var tagValue = input ?? this.RmmzUNumber();
        var builtTag = JabsTags.CastAnimation.ToValueTag(tagValue.ToString());
        return builtTag;
    }
    
    /// <summary>
    /// Generates a castTime tag with a given value, or random value if none is provided.
    /// </summary>
    public string CastTimeTag(int? input = null)
    {
        var tagValue = input ?? this.RmmzUNumber();
        var builtTag = JabsTags.CastTime.ToValueTag(tagValue.ToString());
        return builtTag;
    }
    
    /// <summary>
    /// Generates a actionId tag with a given value, or random value if none is provided.
    /// </summary>
    public string ActionIdTag(int? input = null)
    {
        var tagValue = input ?? this.RmmzUNumber();
        var builtTag = JabsTags.ActionId.ToValueTag(tagValue.ToString());
        return builtTag;
    }
    
    /// <summary>
    /// Generates a duration tag with a given value, or random value if none is provided.
    /// </summary>
    public string DurationTag(int? input = null)
    {
        var tagValue = input ?? this.RmmzUNumber();
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
        var tagValue = input ?? this.RmmzDecimal();
        var builtTag = JabsTags.Radius.ToValueTag(tagValue.ToString());
        return builtTag;
    }
    
    /// <summary>
    /// Generates a proximity tag with a given value, or a random value if none is provided.
    /// </summary>
    public string ProximityTag(decimal? input = null)
    {
        var tagValue = input ?? this.RmmzDecimal();
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
    #endregion tags
    
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
        return this.RNG.Next(1, 501);
    }

    /// <summary>
    /// Generates a random whole number between -500 and 500.
    /// This is a small number deliberately since most values used in RMMZ are pretty small,
    /// and includes negative lower bounds to accommodate possible detriment effects.
    /// </summary>
    public int RmmzNumber()
    {
        return this.RNG.Next(-500, 501);
    }

    /// <summary>
    /// Generates a random decimal number between 1 and 500.
    /// This uses the above <see cref="RmmzUNumber"/> to generate both sides as a string, and parses it
    /// to produce the given decimal.
    /// </summary>
    public decimal RmmzDecimal()
    {
        var left = this.RmmzUNumber();
        var right = this.RmmzUNumber();
        var combined = $"{left}.{right}";
        return decimal.Parse(combined);
    }

    /// <summary>
    /// Generates a random whole number between 1 and 100.
    /// </summary>
    public int RmmzChance()
    {
        return this.RNG.Next(1, 101);
    }

    /// <summary>
    /// Generates a random word or words that has no particular punctuation except maybe a space.
    /// Used for generating keys in tags, among other things.
    /// </summary>
    public string RmmzKey()
    {
        return this.FAKER.Lorem.Random.String2(this.RNG.Next(8,33));
    }

    /// <summary>
    /// Generates a random <see cref="Hitbox"/> from the available values in the enum.
    /// Will not generate ordinal 0 aka <see cref="Hitbox.None"/>.
    /// </summary>
    public Hitbox RandomHitbox()
    {
        var values = Enum.GetValues<Hitbox>();
        return values[this.RNG.Next(1, values.Length)];
    }

    #endregion utility
}