using Dashboard.Models.db.implementations;

namespace Dashboard.Tests.Models.db.implementations;

public class RPG_WeaponTests : BaseTests
{
    private readonly RPG_Weapon modelUnderTest;

    public RPG_WeaponTests()
    {
        modelUnderTest = new();
    }

    #region skillId
    [Fact]
    public void jabsSkillId_whenUnset_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.jabsSkillId;
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void jabsSkillId_whenSetExplicitly_explicitValueIsReturned()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        var fakeTag = this.fdg.SkillIdTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.jabsSkillId;
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void jabsSkillId_whenUpdated_returnsUpdatedValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.updateSkillId(fakeTagValue);
        
        // when
        var actual = modelUnderTest.jabsSkillId;
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void jabsSkillId_whenRemoved_returnsDefaultValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.updateSkillId(fakeTagValue); // update with valid value.
        modelUnderTest.updateSkillId(decimal.Zero);
        
        // when
        var actual = modelUnderTest.jabsSkillId;
        
        // then
        actual.Should().Be(fakeTagValue);
    }
    #endregion skillId
    
    #region speedBoost
    [Fact]
    public void jabsSpeedBoost_whenUnset_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        modelUnderTest.note = string.Empty;
        
        // when
        var actual = modelUnderTest.jabsSpeedBoost;
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void jabsSpeedBoost_whenSetExplicitly_explicitValueIsReturned()
    {
        // given
        var fakeTagValue = this.fdg.RmmzNumber();
        var fakeTag = this.fdg.SpeedBoostTag(fakeTagValue);
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;
        
        // when
        var actual = modelUnderTest.jabsSpeedBoost;
        
        // then
        actual.Should().Be(fakeTagValue);
    }
    
    [Fact]
    public void jabsSpeedBoost_whenUpdated_returnsUpdatedValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzNumber();
        modelUnderTest.updateJabsSpeedBoost(fakeTagValue);
        
        // when
        var actual = modelUnderTest.jabsSpeedBoost;
        
        // then
        actual.Should().Be(fakeTagValue);
    }

    [Fact]
    public void jabsSpeedBoost_whenRemoved_returnsDefaultValue()
    {
        // given
        var fakeTagValue = this.fdg.RmmzNumber();
        modelUnderTest.updateJabsSpeedBoost(fakeTagValue); // update with valid value.
        modelUnderTest.updateJabsSpeedBoost(decimal.Zero);
        
        // when
        var actual = modelUnderTest.jabsSpeedBoost;
        
        // then
        actual.Should().Be(fakeTagValue);
    }
    #endregion speedBoost
    
}