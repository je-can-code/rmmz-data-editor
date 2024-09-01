using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Skill.MapData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Skill.MapData;

[Trait("Category","mapData")]
public class ActionIdExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;
    
    public ActionIdExtTests()
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
        var actual = modelUnderTest.GetJabsActionId();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenAdded_returnsValue()
    {
        // given
        var fakeTagValue = fdg.RmmzUNumber();
        var fakeTag = fdg.ActionIdTag(fakeTagValue);
        var fakeNote = fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.GetJabsActionId();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void whenUpdated_returnsValue()
    {
        // given
        var fakeTagValue = fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsActionId(fakeTagValue);
        
        // when
        var actual = modelUnderTest.GetJabsActionId();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        var fakeTagValue = fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsActionId(fakeTagValue); // update with valid value.
        modelUnderTest.UpdateJabsActionId(expected);
        
        // when
        var actual = modelUnderTest.GetJabsActionId();
        
        // then
        actual.Should().Be(expected);
    }
}