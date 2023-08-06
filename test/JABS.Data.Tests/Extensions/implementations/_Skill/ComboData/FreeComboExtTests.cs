using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Skill.ComboData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Skill.ComboData;

public class FreeComboExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;
    
    public FreeComboExtTests()
    {
        modelUnderTest = new();
    }
    
    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.HasJabsFreeCombo();
        
        // then
        actual.Should().BeFalse();
    }
    
    [Fact]
    public void whenAdded_returnsValue()
    {
        // given
        var fakeTag = this.fdg.FreeComboTag();
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.HasJabsFreeCombo();
        
        // then
        actual.Should().BeTrue();
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = false;
        var fakeTagValue = true;
        modelUnderTest.UpdateJabsFreeCombo(fakeTagValue); // update with valid value.
        modelUnderTest.UpdateJabsFreeCombo(expected);
        
        // when
        var actual = modelUnderTest.HasJabsFreeCombo();
        
        // then
        actual.Should().BeFalse();
    }
}