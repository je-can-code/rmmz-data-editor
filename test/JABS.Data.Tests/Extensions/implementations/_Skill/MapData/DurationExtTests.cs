using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Skill.MapData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Skill.MapData;

[Trait("Category","MapData")]
public class DurationExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;
    
    public DurationExtTests()
    {
        modelUnderTest = new();
    }
    
    [Fact]
    public void jabsDuration_whenUnset_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.GetJabsDuration();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void jabsDuration_whenAdded_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        var fakeTag = this.fdg.DurationTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.GetJabsDuration();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void jabsDuration_whenUpdated_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsDuration(fakeTagValue);
        
        // when
        var actual = modelUnderTest.GetJabsDuration();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void jabsDuration_whenRemoved_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsDuration(fakeTagValue); // update with valid value.
        modelUnderTest.UpdateJabsDuration(expected);
        
        // when
        var actual = modelUnderTest.GetJabsDuration();
        
        // then
        actual.Should().Be(expected);
    }
}