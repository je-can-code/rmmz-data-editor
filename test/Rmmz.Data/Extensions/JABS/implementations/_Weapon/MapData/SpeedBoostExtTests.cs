using JMZ.Rmmz.Data.Extensions.JABS.implementations._Weapon.MapData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Rmmz.Data.Tests.Extensions.JABS.implementations._Weapon.MapData;

public class SpeedBoostExtTests : BaseTests
{
    private readonly RPG_Weapon modelUnderTest;

    public SpeedBoostExtTests()
    {
        modelUnderTest = new();
    }
    
    [Fact]
    [Trait("Category","speedBoost")]
    public void jabsSpeedBoost_whenUnset_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.GetJabsSpeedBoost();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    [Trait("Category","speedBoost")]
    public void jabsSpeedBoost_whenSetExplicitly_explicitValueIsReturned()
    {
        // given
        var fakeTagValue = this.fdg.RmmzNumber();
        var fakeTag = this.fdg.SpeedBoostTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.GetJabsSpeedBoost();
        
        // then
        actual.Should().Be(fakeTagValue);
    }
    
    [Fact]
    [Trait("Category","speedBoost")]
    public void jabsSpeedBoost_whenUpdated_returnsUpdatedValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzNumber();
        modelUnderTest.UpdateJabsSpeedBoost(fakeTagValue);
        
        // when
        var actual = modelUnderTest.GetJabsSpeedBoost();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    [Trait("Category","speedBoost")]
    public void jabsSpeedBoost_whenRemoved_returnsDefault()
    {
        // given
        var fakeTagValue = this.fdg.RmmzNumber();
        modelUnderTest.UpdateJabsSpeedBoost(fakeTagValue); // update with valid value.
        modelUnderTest.UpdateJabsSpeedBoost(decimal.Zero);
        
        // when
        var actual = modelUnderTest.GetJabsSpeedBoost();
        
        // then
        actual.Should().Be(fakeTagValue);
    }
}