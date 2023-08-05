using JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.UsageData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Rmmz.Data.Tests.Extensions.JABS.implementations._Skill.UsageData;

[Trait("Category","UsageData")]
public class CastAnimationExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;
    
    public CastAnimationExtTests()
    {
        modelUnderTest = new();
    }
    
    [Fact]
    public void jabsCastAnimation_whenUnset_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.GetJabsCastAnimation();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void jabsCastAnimation_whenAdded_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        var fakeTag = this.fdg.CastAnimationTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.GetJabsCastAnimation();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void jabsCastAnimation_whenUpdated_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsCastAnimation(fakeTagValue);
        
        // when
        var actual = modelUnderTest.GetJabsCastAnimation();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void jabsCastAnimation_whenRemoved_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsCastAnimation(fakeTagValue); // update with valid value.
        modelUnderTest.UpdateJabsCastAnimation(expected);
        
        // when
        var actual = modelUnderTest.GetJabsCastAnimation();
        
        // then
        actual.Should().Be(expected);
    }
}