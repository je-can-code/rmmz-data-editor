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
        modelUnderTest = new();
    }
    
    [Fact]
    public void whenUnset_returnsDefault()
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
    public void whenSetExplicitly_explicitValueIsReturned()
    {
        // given
        var fakeTagValue = fdg.RmmzNumber();
        var fakeTag = fdg.SpeedBoostTag(fakeTagValue);
        var fakeNote = fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.GetJabsSpeedBoost();
        
        // then
        actual.Should().Be(fakeTagValue);
    }
    
    [Fact]
    public void whenUpdated_returnsUpdatedValue()
    {
        // given
        var fakeTagValue = fdg.RmmzNumber();
        modelUnderTest.UpdateJabsSpeedBoost(fakeTagValue);
        
        // when
        var actual = modelUnderTest.GetJabsSpeedBoost();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var fakeTagValue = fdg.RmmzNumber();
        modelUnderTest.UpdateJabsSpeedBoost(fakeTagValue); // update with valid value.
        modelUnderTest.UpdateJabsSpeedBoost(decimal.Zero);
        
        // when
        var actual = modelUnderTest.GetJabsSpeedBoost();
        
        // then
        actual.Should().Be(fakeTagValue);
    }
}