using FluentAssertions;
using JMZ.Base.Tests;
using JMZ.Rmmz.Data.Models.db.implementations;
using JMZ.Sdp.Data.Extensions.implementations._Enemy;
using JMZ.Sdp.Data.Models;
using Xunit;

namespace JMZ.Sdp.Data.Tests.Extensions.implementations._Enemy;

[Trait("Category","SdpData")]
public class SdpDataExtTests : BaseTests
{
    private readonly RPG_Enemy modelUnderTest;

    public SdpDataExtTests()
    {
        this.modelUnderTest = new();
    }
    
    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        var expected = new SdpDropData(string.Empty, decimal.MinusOne);
        this.modelUnderTest.note = string.Empty;

        // when
        var actual = this.modelUnderTest.GetSdpData();

        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenAdded_returnsData()
    {
        // given
        var expected = this.generateSdpDropData();
        this.modelUnderTest.UpdateSdpData(expected.Key, expected.DropChance, expected.ItemId);

        // when
        var actual = this.modelUnderTest.GetSdpData();

        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenUpdated_returnsUpdatedData()
    {
        // given
        var firstSdp = this.generateSdpDropData();
        this.modelUnderTest.UpdateSdpData(firstSdp.Key, firstSdp.DropChance, firstSdp.ItemId);

        var secondSdp = this.generateSdpDropData();
        this.modelUnderTest.UpdateSdpData(secondSdp.Key, secondSdp.DropChance, secondSdp.ItemId);
      
        // when
        var actual = this.modelUnderTest.GetSdpData();

        // then
        actual.Should().NotBe(firstSdp);
        actual.Should().Be(secondSdp);
    }
    
    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = new SdpDropData(string.Empty, decimal.MinusOne);
        var firstSdp = this.generateSdpDropData();
        this.modelUnderTest.UpdateSdpData(firstSdp.Key, firstSdp.DropChance, firstSdp.ItemId);

        this.modelUnderTest.UpdateSdpData(string.Empty, decimal.MinusOne, decimal.Zero);

        // when
        var actual = this.modelUnderTest.GetSdpData();

        // then
        actual.Should().NotBe(firstSdp);
        actual.Should().Be(expected);
    }

    private SdpDropData generateSdpDropData()
    {
        return new(
            this.fdg.RmmzKey(),
            this.fdg.RmmzUNumber(),
            this.fdg.RmmzChance());
    }
}