﻿using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Skill.MapData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Skill.MapData;

[Trait("Category","mapData")]
public class ActionIdExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;
    
    public ActionIdExtTests()
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
        var actual = this.modelUnderTest.GetJabsActionId();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenAdded_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        var fakeTag = this.fdg.ActionIdTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        this.modelUnderTest.note = fakeNote;
        
        // when
        var actual = this.modelUnderTest.GetJabsActionId();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void whenUpdated_returnsValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        this.modelUnderTest.UpdateJabsActionId(fakeTagValue);
        
        // when
        var actual = this.modelUnderTest.GetJabsActionId();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        var fakeTagValue = this.fdg.RmmzUNumber();
        this.modelUnderTest.UpdateJabsActionId(fakeTagValue); // update with valid value.
        this.modelUnderTest.UpdateJabsActionId(expected);
        
        // when
        var actual = this.modelUnderTest.GetJabsActionId();
        
        // then
        actual.Should().Be(expected);
    }
}