using Dashboard.Models.db.implementations;

namespace Dashboard.Tests.Models.db.implementations;

[Trait("Category","skill")]
public class RPG_SkillTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;
    
    public RPG_SkillTests()
    {
        modelUnderTest = new();
    }
    
    #region cooldown
    [Fact]
    [Trait("Category","cooldown")]
    public void jabsCooldown_whenUnset_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.jabsCooldown;
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    [Trait("Category","cooldown")]
    public void jabsCooldown_whenAdded_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        var fakeTag = this.fdg.CooldownTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.jabsCooldown;
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    [Trait("Category","cooldown")]
    public void jabsCooldown_whenUpdated_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.updateJabsCooldown(fakeTagValue);
        
        // when
        var actual = modelUnderTest.jabsCooldown;
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    [Trait("Category","cooldown")]
    public void jabsCooldown_whenRemoved_returnsDefaultValue()
    {
        // given
        var expected = decimal.Zero;
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.updateJabsCooldown(fakeTagValue); // update with valid value.
        modelUnderTest.updateJabsCooldown(expected);
        
        // when
        var actual = modelUnderTest.jabsCooldown;
        
        // then
        actual.Should().Be(expected);
    }
    #endregion cooldown
    
    #region castAnimation
    [Fact]
    [Trait("Category","casting")]
    public void jabsCastAnimation_whenUnset_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.jabsCastAnimation;
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    [Trait("Category","casting")]
    public void jabsCastAnimation_whenAdded_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        var fakeTag = this.fdg.CastAnimationTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.jabsCastAnimation;
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    [Trait("Category","casting")]
    public void jabsCastAnimation_whenUpdated_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.updateJabsCastAnimation(fakeTagValue);
        
        // when
        var actual = modelUnderTest.jabsCastAnimation;
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    [Trait("Category","casting")]
    public void jabsCastAnimation_whenRemoved_returnsDefaultValue()
    {
        // given
        var expected = decimal.Zero;
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.updateJabsCastAnimation(fakeTagValue); // update with valid value.
        modelUnderTest.updateJabsCastAnimation(expected);
        
        // when
        var actual = modelUnderTest.jabsCastAnimation;
        
        // then
        actual.Should().Be(expected);
    }
    #endregion castAnimation
    
    #region castTime
    [Fact]
    [Trait("Category","casting")]
    public void jabsCastTime_whenUnset_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.jabsCastTime;
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    [Trait("Category","casting")]
    public void jabsCastTime_whenAdded_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        var fakeTag = this.fdg.CastTimeTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.jabsCastTime;
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    [Trait("Category","casting")]
    public void jabsCastTime_whenUpdated_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.updateJabsCastTime(fakeTagValue);
        
        // when
        var actual = modelUnderTest.jabsCastTime;
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    [Trait("Category","casting")]
    public void jabsCastTime_whenRemoved_returnsDefaultValue()
    {
        // given
        var expected = decimal.Zero;
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.updateJabsCastTime(fakeTagValue); // update with valid value.
        modelUnderTest.updateJabsCastTime(expected);
        
        // when
        var actual = modelUnderTest.jabsCastTime;
        
        // then
        actual.Should().Be(expected);
    }
    #endregion castTime
}