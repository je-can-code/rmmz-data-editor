using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Skill.UsageData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Skill.UsageData;

[Trait("Category","UsageData")]
public class AiSkillExclusionExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;
    
    public AiSkillExclusionExtTests()
    {
        this.modelUnderTest = new();
    }
    
    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        this.modelUnderTest.note = string.Empty;
        
        // when
        var actual = this.modelUnderTest.HasJabsAiSkillExclusion();
        
        // then
        actual.Should().BeFalse();
    }
    
    [Fact]
    public void whenAdded_returnsValue()
    {
        // given
        var fakeTag = this.fdg.AiSkillExclusionTag();
        var fakeNote = this.fdg.BuildNoteTag(fakeTag);
        this.modelUnderTest.note = fakeNote;
        
        // when
        var actual = this.modelUnderTest.HasJabsAiSkillExclusion();
        
        // then
        actual.Should().BeTrue();
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = false;
        var fakeTagValue = true;
        this.modelUnderTest.UpdateJabsAiSkillExclusion(fakeTagValue); // update with valid value.
        this.modelUnderTest.UpdateJabsAiSkillExclusion(expected);
        
        // when
        var actual = this.modelUnderTest.HasJabsAiSkillExclusion();
        
        // then
        actual.Should().BeFalse();
    }
}