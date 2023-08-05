using JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.UsageData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Rmmz.Data.Tests.Extensions.JABS.implementations._Skill.UsageData;

[Trait("Category","UsageData")]
public class CooldownExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;
    
    public CooldownExtTests()
    {
        modelUnderTest = new();
    }
    
    [Fact]
    public void jabsCooldown_whenUnset_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.GetJabsCooldown();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void jabsCooldown_whenAdded_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        var fakeTag = this.fdg.CooldownTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.GetJabsCooldown();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void jabsCooldown_whenUpdated_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsCooldown(fakeTagValue);
        
        // when
        var actual = modelUnderTest.GetJabsCooldown();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void jabsCooldown_whenRemoved_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsCooldown(fakeTagValue); // update with valid value.
        modelUnderTest.UpdateJabsCooldown(expected);
        
        // when
        var actual = modelUnderTest.GetJabsCooldown();
        
        // then
        actual.Should().Be(expected);
    }
}