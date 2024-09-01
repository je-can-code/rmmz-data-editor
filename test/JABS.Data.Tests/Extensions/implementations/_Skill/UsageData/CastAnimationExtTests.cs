using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Skill.UsageData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Skill.UsageData;

[Trait("Category","UsageData")]
public class CastAnimationExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;
    
    public CastAnimationExtTests()
    {
        modelUnderTest = new();
    }
    
    [Fact]
    public void whenUnset_returnsDefault()
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
    public void whenAdded_returnsValue()
    {
        // given
        var fakeTagValue = fdg.RmmzUNumber();
        var fakeTag = fdg.CastAnimationTag(fakeTagValue);
        var fakeNote = fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.GetJabsCastAnimation();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void whenUpdated_returnsValue()
    {
        // given
        var fakeTagValue = fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsCastAnimation(fakeTagValue);
        
        // when
        var actual = modelUnderTest.GetJabsCastAnimation();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        var fakeTagValue = fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsCastAnimation(fakeTagValue); // update with valid value.
        modelUnderTest.UpdateJabsCastAnimation(expected);
        
        // when
        var actual = modelUnderTest.GetJabsCastAnimation();
        
        // then
        actual.Should().Be(expected);
    }
}