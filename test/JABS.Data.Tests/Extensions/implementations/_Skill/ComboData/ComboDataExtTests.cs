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
        this.modelUnderTest = new();
    }
    
    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        var expected = new Models.ComboData();
        this.modelUnderTest.note = string.Empty;
        
        // when
        var actual = this.modelUnderTest.GetJabsComboData();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenAdded_returnsData()
    {
        // given
        var testComboSkill = this.fdg.RmmzUNumber();
        var testComboDelay = this.fdg.RmmzUNumber();
        var fakeTag = this.fdg.ComboDataTag(testComboSkill, testComboDelay);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        this.modelUnderTest.note = fakeNote;
        
        // when
        var actual = this.modelUnderTest.GetJabsComboData();
        var (comboSkill, comboDelay) = actual;

        // then
        comboSkill.Should().Be(testComboSkill);
        comboDelay.Should().Be(testComboDelay);
    }
    
    [Fact]
    public void whenUpdated_returnsData()
    {
        // given
        var testComboSkill = this.fdg.RmmzUNumber();
        var testComboDelay = this.fdg.RmmzUNumber();
        this.modelUnderTest.UpdateJabsComboData(testComboSkill, testComboDelay);
        
        // when
        var actual = this.modelUnderTest.GetJabsComboData();

        // then
        actual.ComboSkill.Should().Be(testComboSkill);
        actual.ComboDelay.Should().Be(testComboDelay);
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = new Models.ComboData();
        var testComboSkill = this.fdg.RmmzUNumber();
        var testComboDelay = this.fdg.RmmzUNumber();
        this.modelUnderTest.UpdateJabsComboData(testComboSkill, testComboDelay);
        this.modelUnderTest.UpdateJabsComboData(decimal.Zero, decimal.Zero);
        
        // when
        var actual = this.modelUnderTest.GetJabsComboData();

        // then
        actual.Should().Be(expected);
    }
}