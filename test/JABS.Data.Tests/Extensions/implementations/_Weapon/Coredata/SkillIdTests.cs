﻿using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Weapon.CoreData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Weapon.Coredata;

[Trait("Category","CoreData")]
public class SkillIdTests : BaseTests
{
    private readonly RPG_Weapon modelUnderTest;

    public SkillIdTests()
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
        var actual = this.modelUnderTest.GetJabsSkillId();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenSetExplicitly_explicitValueIsReturned()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        var fakeTag = this.fdg.SkillIdTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        this.modelUnderTest.note = fakeNote;
        
        // when
        var actual = this.modelUnderTest.GetJabsSkillId();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void whenUpdated_returnsUpdatedValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        this.modelUnderTest.UpdateJabsSkillId(fakeTagValue);
        
        // when
        var actual = this.modelUnderTest.GetJabsSkillId();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        var fakeTagValue = this.fdg.RmmzUNumber();
        this.modelUnderTest.UpdateJabsSkillId(fakeTagValue); // update with valid value.
        this.modelUnderTest.UpdateJabsSkillId(expected);
        
        // when
        var actual = this.modelUnderTest.GetJabsSkillId();
        
        // then
        actual.Should().Be(expected);
    }
}