using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Skill.ComboData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Skill.ComboData;

[Trait("Category","PiercingData")]
public class ComboDataExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;
    
    public ComboDataExtTests()
    {
        modelUnderTest = new();
    }
    
    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        var expected = new Models.ComboData();
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.GetJabsComboData();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenAdded_returnsData()
    {
        // given
        var testComboSkill = fdg.RmmzUNumber();
        var testComboDelay = fdg.RmmzUNumber();
        var fakeTag = fdg.ComboDataTag(testComboSkill, testComboDelay);
        var fakeNote = fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.GetJabsComboData();
        var (comboSkill, comboDelay) = actual;

        // then
        comboSkill.Should().Be(testComboSkill);
        comboDelay.Should().Be(testComboDelay);
    }
    
    [Fact]
    public void whenUpdated_returnsData()
    {
        // given
        var testComboSkill = fdg.RmmzUNumber();
        var testComboDelay = fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsComboData(testComboSkill, testComboDelay);
        
        // when
        var actual = modelUnderTest.GetJabsComboData();

        // then
        actual.ComboSkill.Should().Be(testComboSkill);
        actual.ComboDelay.Should().Be(testComboDelay);
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = new Models.ComboData();
        var testComboSkill = fdg.RmmzUNumber();
        var testComboDelay = fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsComboData(testComboSkill, testComboDelay);
        modelUnderTest.UpdateJabsComboData(decimal.Zero, decimal.Zero);
        
        // when
        var actual = modelUnderTest.GetJabsComboData();

        // then
        actual.Should().Be(expected);
    }
}