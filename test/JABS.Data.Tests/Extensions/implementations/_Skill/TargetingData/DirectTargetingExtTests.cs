using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Skill.TargetingData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Skill.TargetingData;

[Trait("Category","TargetingData")]
public class DirectTargetingExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;
    
    public DirectTargetingExtTests()
    {
        modelUnderTest = new();
    }
    
    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.HasJabsDirectTargeting();
        
        // then
        actual.Should().BeFalse();
    }
    
    [Fact]
    public void whenAdded_returnsValue()
    {
        // given
        var fakeTag = fdg.DirectTargetingTag();
        var fakeNote = fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.HasJabsDirectTargeting();
        
        // then
        actual.Should().BeTrue();
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = false;
        var fakeTagValue = true;
        modelUnderTest.UpdateJabsDirectTargeting(fakeTagValue); // update with valid value.
        modelUnderTest.UpdateJabsDirectTargeting(expected);
        
        // when
        var actual = modelUnderTest.HasJabsDirectTargeting();
        
        // then
        actual.Should().BeFalse();
    }
}