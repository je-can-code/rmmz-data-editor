using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Weapon.MapData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Weapon.MapData;

[Trait("Category","MapData")]
public class SpeedBoostExtTests : BaseTests
{
    private readonly RPG_Weapon modelUnderTest;

    public SpeedBoostExtTests()
    {
        this.modelUnderTest = new();
    }
    
    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        this.modelUnderTest.note = string.Empty;
        
        // when
        var actual = this.modelUnderTest.GetJabsSpeedBoost();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenSetExplicitly_explicitValueIsReturned()
    {
        // given
        var fakeTagValue = this.fdg.RmmzNumber();
        var fakeTag = this.fdg.SpeedBoostTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        this.modelUnderTest.note = fakeNote;
        
        // when
        var actual = this.modelUnderTest.GetJabsSpeedBoost();
        
        // then
        actual.Should().Be(fakeTagValue);
    }
    
    [Fact]
    public void whenUpdated_returnsUpdatedValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzNumber();
        this.modelUnderTest.UpdateJabsSpeedBoost(fakeTagValue);
        
        // when
        var actual = this.modelUnderTest.GetJabsSpeedBoost();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var fakeTagValue = this.fdg.RmmzNumber();
        this.modelUnderTest.UpdateJabsSpeedBoost(fakeTagValue); // update with valid value.
        this.modelUnderTest.UpdateJabsSpeedBoost(decimal.Zero);
        
        // when
        var actual = this.modelUnderTest.GetJabsSpeedBoost();
        
        // then
        actual.Should().Be(fakeTagValue);
    }
}