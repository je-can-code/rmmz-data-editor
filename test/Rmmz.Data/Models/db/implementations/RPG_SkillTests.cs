using Rmmz.Data.Models.db.implementations;

namespace Rmmz.Data.Tests.Models.db.implementations;

[Trait("Category","skill")]
public class RPG_SkillTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;
    
    public RPG_SkillTests()
    {
        modelUnderTest = new();
    }
    
    #region actionId
    [Fact]
    [Trait("Category","mapData")]
    [Trait("Category","actionId")]
    public void jabsActionId_whenUnset_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.jabsActionId;
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    [Trait("Category","mapData")]
    [Trait("Category","actionId")]
    public void jabsActionId_whenAdded_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        var fakeTag = this.fdg.ActionIdTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.jabsActionId;
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    [Trait("Category","mapData")]
    [Trait("Category","actionId")]
    public void jabsActionId_whenUpdated_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.updateJabsActionId(fakeTagValue);
        
        // when
        var actual = modelUnderTest.jabsActionId;
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    [Trait("Category","mapData")]
    [Trait("Category","actionId")]
    public void jabsActionId_whenRemoved_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.updateJabsActionId(fakeTagValue); // update with valid value.
        modelUnderTest.updateJabsActionId(expected);
        
        // when
        var actual = modelUnderTest.jabsActionId;
        
        // then
        actual.Should().Be(expected);
    }
    #endregion actionId
    
    #region castAnimation
    [Fact]
    [Trait("Category","casting")]
    [Trait("Category","castAnimation")]
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
    [Trait("Category","castAnimation")]
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
    [Trait("Category","castAnimation")]
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
    [Trait("Category","castAnimation")]
    public void jabsCastAnimation_whenRemoved_returnsDefault()
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
    [Trait("Category","castTime")]
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
    [Trait("Category","castTime")]
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
    [Trait("Category","castTime")]
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
    [Trait("Category","castTime")]
    public void jabsCastTime_whenRemoved_returnsDefault()
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
    public void jabsCooldown_whenRemoved_returnsDefault()
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
    
    #region duration
    [Fact]
    [Trait("Category","mapData")]
    [Trait("Category","duration")]
    public void jabsDuration_whenUnset_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.jabsDuration;
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    [Trait("Category","mapData")]
    [Trait("Category","duration")]
    public void jabsDuration_whenAdded_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        var fakeTag = this.fdg.DurationTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.jabsDuration;
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    [Trait("Category","mapData")]
    [Trait("Category","duration")]
    public void jabsDuration_whenUpdated_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.updateJabsDuration(fakeTagValue);
        
        // when
        var actual = modelUnderTest.jabsDuration;
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    [Trait("Category","mapData")]
    [Trait("Category","duration")]
    public void jabsDuration_whenRemoved_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.updateJabsDuration(fakeTagValue); // update with valid value.
        modelUnderTest.updateJabsDuration(expected);
        
        // when
        var actual = modelUnderTest.jabsDuration;
        
        // then
        actual.Should().Be(expected);
    }
    #endregion duration
    
    #region hideFromQuickMenu
    [Fact]
    [Trait("Category","mapData")]
    [Trait("Category","hideFromQuickMenu")]
    public void jabsHideFromQuickMenu_whenUnset_returnsDefault()
    {
        // given
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.jabsHideFromQuickMenu;
        
        // then
        actual.Should().BeFalse();
    }
    
    [Fact]
    [Trait("Category","mapData")]
    [Trait("Category","hideFromQuickMenu")]
    public void jabsHideFromQuickMenu_whenAdded_returnsValue()
    {
        // given
        var fakeTag = this.fdg.HideFromQuickMenuTag();
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.jabsHideFromQuickMenu;
        
        // then
        actual.Should().BeTrue();
    }

    [Fact]
    [Trait("Category","mapData")]
    [Trait("Category","hideFromQuickMenu")]
    public void jabsHideFromQuickMenu_whenRemoved_returnsDefault()
    {
        // given
        var expected = false;
        var fakeTagValue = true;
        modelUnderTest.updateHideFromQuickMenu(fakeTagValue); // update with valid value.
        modelUnderTest.updateHideFromQuickMenu(expected);
        
        // when
        var actual = modelUnderTest.jabsHideFromQuickMenu;
        
        // then
        actual.Should().BeFalse();
    }
    #endregion hideFromQuickMenu
}