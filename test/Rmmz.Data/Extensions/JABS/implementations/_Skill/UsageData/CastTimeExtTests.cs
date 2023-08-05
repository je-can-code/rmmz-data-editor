using JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.UsageData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Rmmz.Data.Tests.Extensions.JABS.implementations._Skill.UsageData;

[Trait("Category","UsageData")]
public class CastTimeExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;
    
    public CastTimeExtTests()
    {
        modelUnderTest = new();
    }
    
    [Fact]
    public void jabsCastTime_whenUnset_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.GetJabsCastTime();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void jabsCastTime_whenAdded_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        var fakeTag = this.fdg.CastTimeTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.GetJabsCastTime();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void jabsCastTime_whenUpdated_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsCastTime(fakeTagValue);
        
        // when
        var actual = modelUnderTest.GetJabsCastTime();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void jabsCastTime_whenRemoved_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsCastTime(fakeTagValue); // update with valid value.
        modelUnderTest.UpdateJabsCastTime(expected);
        
        // when
        var actual = modelUnderTest.GetJabsCastTime();
        
        // then
        actual.Should().Be(expected);
    }
}