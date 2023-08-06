using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Skill.TargetingData;
using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Skill.TargetingData;

[Trait("Category","TargetingData")]
public class HitboxExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;

    public HitboxExtTests()
    {
        modelUnderTest = new();
    }
    
    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        var expected = Hitbox.None;
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.GetJabsHitbox();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenAdded_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RandomHitbox();
        var fakeTag = this.fdg.HitboxTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.GetJabsHitbox();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void whenUpdated_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RandomHitbox();
        modelUnderTest.UpdateJabsHitbox(fakeTagValue);
        
        // when
        var actual = modelUnderTest.GetJabsHitbox();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = Hitbox.None;
        var fakeTagValue = this.fdg.RandomHitbox();
        modelUnderTest.UpdateJabsHitbox(fakeTagValue); // update with valid value.
        modelUnderTest.UpdateJabsHitbox(expected);
        
        // when
        var actual = modelUnderTest.GetJabsHitbox();
        
        // then
        actual.Should().Be(expected);
    }
}