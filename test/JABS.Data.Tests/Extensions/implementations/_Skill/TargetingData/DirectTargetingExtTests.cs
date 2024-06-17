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
        this.modelUnderTest = new();
    }
    
    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        this.modelUnderTest.note = string.Empty;
        
        // when
        var actual = this.modelUnderTest.HasJabsDirectTargeting();
        
        // then
        actual.Should().BeFalse();
    }
    
    [Fact]
    public void whenAdded_returnsValue()
    {
        // given
        var fakeTag = this.fdg.DirectTargetingTag();
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        this.modelUnderTest.note = fakeNote;
        
        // when
        var actual = this.modelUnderTest.HasJabsDirectTargeting();
        
        // then
        actual.Should().BeTrue();
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = false;
        var fakeTagValue = true;
        this.modelUnderTest.UpdateJabsDirectTargeting(fakeTagValue); // update with valid value.
        this.modelUnderTest.UpdateJabsDirectTargeting(expected);
        
        // when
        var actual = this.modelUnderTest.HasJabsDirectTargeting();
        
        // then
        actual.Should().BeFalse();
    }
}