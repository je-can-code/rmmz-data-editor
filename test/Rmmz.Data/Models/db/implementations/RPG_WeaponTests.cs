using Rmmz.Data.Models.db.implementations;

namespace Rmmz.Data.Tests.Models.db.implementations;

[Trait("Category","weapon")]
public class RPG_WeaponTests : BaseTests
{
    private readonly RPG_Weapon modelUnderTest;

    public RPG_WeaponTests()
    {
        modelUnderTest = new();
    }

    #region skillId
    [Fact]
    [Trait("Category","skillId")]
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
    [Trait("Category","skillId")]
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
    [Trait("Category","skillId")]
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
    [Trait("Category","skillId")]
    public void jabsSkillId_whenRemoved_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        var fakeTagValue = this.fdg.RmmzUNumber();
        modelUnderTest.updateSkillId(fakeTagValue); // update with valid value.
        modelUnderTest.updateSkillId(expected);
        
        // when
        var actual = modelUnderTest.jabsSkillId;
        
        // then
        actual.Should().Be(expected);
    }
    #endregion skillId
    
    #region speedBoost
    [Fact]
    [Trait("Category","speedBoost")]
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
    [Trait("Category","speedBoost")]
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
    [Trait("Category","speedBoost")]
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
    [Trait("Category","speedBoost")]
    public void jabsSpeedBoost_whenRemoved_returnsDefault()
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