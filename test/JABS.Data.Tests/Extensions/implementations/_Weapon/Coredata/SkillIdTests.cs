using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Weapon.CoreData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Weapon.Coredata;

[Trait("Category","CoreData")]
public class SkillIdTests : BaseTests
{
    private readonly RPG_Weapon modelUnderTest;

    public SkillIdTests()
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
        var actual = modelUnderTest.GetJabsSkillId();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenSetExplicitly_explicitValueIsReturned()
    {
        // given
        var fakeTagValue = fdg.RmmzUNumber();
        var fakeTag = fdg.SkillIdTag(fakeTagValue);
        var fakeNote = fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.GetJabsSkillId();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void whenUpdated_returnsUpdatedValue()
    {
        // given
        var fakeTagValue = fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsSkillId(fakeTagValue);
        
        // when
        var actual = modelUnderTest.GetJabsSkillId();
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        var fakeTagValue = fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsSkillId(fakeTagValue); // update with valid value.
        modelUnderTest.UpdateJabsSkillId(expected);
        
        // when
        var actual = modelUnderTest.GetJabsSkillId();
        
        // then
        actual.Should().Be(expected);
    }
}