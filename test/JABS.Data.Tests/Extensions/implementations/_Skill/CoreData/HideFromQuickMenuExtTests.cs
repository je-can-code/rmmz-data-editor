using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Skill.CoreData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Skill.CoreData;

public class HideFromQuickMenuExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;
    
    public HideFromQuickMenuExtTests()
    {
        modelUnderTest = new();
    }
    
    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.HasJabsHideFromQuickMenu();
        
        // then
        actual.Should().BeFalse();
    }
    
    [Fact]
    public void whenAdded_returnsValue()
    {
        // given
        var fakeTag = fdg.HideFromQuickMenuTag();
        var fakeNote = fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.HasJabsHideFromQuickMenu();
        
        // then
        actual.Should().BeTrue();
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = false;
        var fakeTagValue = true;
        modelUnderTest.UpdateJabsHideFromQuickMenu(fakeTagValue); // update with valid value.
        modelUnderTest.UpdateJabsHideFromQuickMenu(expected);
        
        // when
        var actual = modelUnderTest.HasJabsHideFromQuickMenu();
        
        // then
        actual.Should().BeFalse();
    }
}