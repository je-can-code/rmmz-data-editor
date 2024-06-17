﻿using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Skill.UsageData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Skill.UsageData;

[Trait("Category","UsageData")]
public class CastTimeExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;
    
    public CastTimeExtTests()
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
        var actual = this.modelUnderTest.GetJabsCastTime();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenAdded_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        var fakeTag = this.fdg.CastTimeTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        this.modelUnderTest.note = fakeNote;
        
        // when
        var actual = this.modelUnderTest.GetJabsCastTime();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void whenUpdated_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        this.modelUnderTest.UpdateJabsCastTime(fakeTagValue);
        
        // when
        var actual = this.modelUnderTest.GetJabsCastTime();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        var fakeTagValue = this.fdg.RmmzUNumber();
        this.modelUnderTest.UpdateJabsCastTime(fakeTagValue); // update with valid value.
        this.modelUnderTest.UpdateJabsCastTime(expected);
        
        // when
        var actual = this.modelUnderTest.GetJabsCastTime();
        
        // then
        actual.Should().Be(expected);
    }
}