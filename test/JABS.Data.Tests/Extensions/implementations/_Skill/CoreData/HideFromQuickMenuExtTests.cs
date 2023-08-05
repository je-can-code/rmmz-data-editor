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
    public void jabsHideFromQuickMenu_whenUnset_returnsDefault()
    {
        // given
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.HasJabsHideFromQuickMenu();
        
        // then
        actual.Should().BeFalse();
    }
    
    [Fact]
    public void jabsHideFromQuickMenu_whenAdded_returnsValue()
    {
        // given
        var fakeTag = this.fdg.HideFromQuickMenuTag();
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.HasJabsHideFromQuickMenu();
        
        // then
        actual.Should().BeTrue();
    }

    [Fact]
    public void jabsHideFromQuickMenu_whenRemoved_returnsDefault()
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