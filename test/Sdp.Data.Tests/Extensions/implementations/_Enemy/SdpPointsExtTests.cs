using FluentAssertions;
using JMZ.Base.Tests;
using JMZ.Rmmz.Data.Models.db.implementations;
using JMZ.Sdp.Data.Extensions.implementations._Enemy;
using Xunit;

namespace JMZ.Sdp.Data.Tests.Extensions.implementations._Enemy;

[Trait("Category","SdpData")]
public class SdpPointsExtTests : BaseTests
{
    private readonly RPG_Enemy modelUnderTest;

    public SdpPointsExtTests()
    {
        modelUnderTest = new();
    }
    
    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        var expected = SdpPointsExt.NON_VALUE;
        modelUnderTest.note = string.Empty;

        // when
        var actual = modelUnderTest.GetSdpPoints();

        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenAdded_returnsData()
    {
        // given
        var expected = fdg.RmmzUNumber();
        modelUnderTest.UpdateSdpPoints(expected);

        // when
        var actual = modelUnderTest.GetSdpPoints();

        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenUpdated_returnsUpdatedData()
    {
        // given
        var firstPoints = fdg.RmmzUNumber();
        modelUnderTest.UpdateSdpPoints(firstPoints);

        var secondPoints = fdg.RmmzUNumber();
        modelUnderTest.UpdateSdpPoints(secondPoints);
      
        // when
        var actual = modelUnderTest.GetSdpPoints();

        // then
        actual.Should().NotBe(firstPoints);
        actual.Should().Be(secondPoints);
    }
    
    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = SdpPointsExt.NON_VALUE;
        var firstPoints = fdg.RmmzUNumber();
        modelUnderTest.UpdateSdpPoints(firstPoints);

        modelUnderTest.UpdateSdpPoints();

        // when
        var actual = modelUnderTest.GetSdpPoints();

        // then
        actual.Should().NotBe(firstPoints);
        actual.Should().Be(expected);
    }
}