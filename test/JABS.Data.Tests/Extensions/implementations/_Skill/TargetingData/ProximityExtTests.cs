using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Skill.TargetingData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Skill.TargetingData;

[Trait("Category","TargetingData")]
public class ProximityExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;
    
    public ProximityExtTests()
    {
        modelUnderTest = new();
    }
    
    [Fact]
    public void jabsProximity_whenUnset_returnsDefault()
    {
        // given
        var expected = -1;
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.GetJabsProximity();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void jabsProximity_whenAdded_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        var fakeTag = this.fdg.ProximityTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.GetJabsProximity();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void jabsProximity_whenUpdated_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzDecimal();
        modelUnderTest.UpdateJabsProximity(fakeTagValue);
        
        // when
        var actual = modelUnderTest.GetJabsProximity();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void jabsProximity_whenRemoved_returnsDefault()
    {
        // given
        var expected = -1;
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsProximity(fakeTagValue); // update with valid value.
        modelUnderTest.UpdateJabsProximity(-1);
        
        // when
        var actual = modelUnderTest.GetJabsProximity();
        
        // then
        actual.Should().Be(expected);
    }
}