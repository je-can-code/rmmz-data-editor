﻿using FluentAssertions;
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
        this.modelUnderTest = new();
    }
    
    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        var expected = SdpPointsExt.NON_VALUE;
        this.modelUnderTest.note = string.Empty;

        // when
        var actual = this.modelUnderTest.GetSdpPoints();

        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenAdded_returnsData()
    {
        // given
        var expected = this.fdg.RmmzUNumber();
        this.modelUnderTest.UpdateSdpPoints(expected);

        // when
        var actual = this.modelUnderTest.GetSdpPoints();

        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenUpdated_returnsUpdatedData()
    {
        // given
        var firstPoints = this.fdg.RmmzUNumber();
        this.modelUnderTest.UpdateSdpPoints(firstPoints);

        var secondPoints = this.fdg.RmmzUNumber();
        this.modelUnderTest.UpdateSdpPoints(secondPoints);
      
        // when
        var actual = this.modelUnderTest.GetSdpPoints();

        // then
        actual.Should().NotBe(firstPoints);
        actual.Should().Be(secondPoints);
    }
    
    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = SdpPointsExt.NON_VALUE;
        var firstPoints = this.fdg.RmmzUNumber();
        this.modelUnderTest.UpdateSdpPoints(firstPoints);

        this.modelUnderTest.UpdateSdpPoints();

        // when
        var actual = this.modelUnderTest.GetSdpPoints();

        // then
        actual.Should().NotBe(firstPoints);
        actual.Should().Be(expected);
    }
}