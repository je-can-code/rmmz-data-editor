using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Skill.TargetingData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Skill.TargetingData;

[Trait("Category","TargetingData")]
public class RadiusExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;
    
    public RadiusExtTests()
    {
        this.modelUnderTest = new();
    }
    
    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        var expected = -1;
        this.modelUnderTest.note = string.Empty;
        
        // when
        var actual = this.modelUnderTest.GetJabsRadius();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenAdded_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        var fakeTag = this.fdg.RadiusTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        this.modelUnderTest.note = fakeNote;
        
        // when
        var actual = this.modelUnderTest.GetJabsRadius();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void whenUpdated_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzDecimal();
        this.modelUnderTest.UpdateJabsRadius(fakeTagValue);
        
        // when
        var actual = this.modelUnderTest.GetJabsRadius();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = -1;
        var fakeTagValue = this.fdg.RmmzUNumber();
        this.modelUnderTest.UpdateJabsRadius(fakeTagValue); // update with valid value.
        this.modelUnderTest.UpdateJabsRadius(-1);
        
        // when
        var actual = this.modelUnderTest.GetJabsRadius();
        
        // then
        actual.Should().Be(expected);
    }
}