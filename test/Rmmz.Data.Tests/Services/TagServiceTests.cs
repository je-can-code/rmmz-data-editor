using JMZ.Base.Tests;
using JMZ.Base.Tests.Utilities;
using JMZ.Rmmz.Data.Services;

namespace JMZ.Rmmz.Data.Tests.Services;

public class TagServiceTests : BaseTests
{
    [Fact]
    public void translateTags_withSingleTag_translates()
    {
        // given
        var testSingleTag = this.fdg.SkillIdTag();
        
        // when
        var actual = TagService.translateTags(testSingleTag);
        
        // then
        actual.Should().HaveCount(1);
    }

    [Theory]
    [MemberData(nameof(GenerateSkillId))]
    private void translateTags_withMultipleTags_translates(int tagCount)
    {
        // given
        var tag = new List<string>();
        tagCount.Times(() => tag.Add(this.fdg.SkillIdTag()));
        var testMultipleTags = this.fdg.BuildNoteTag(tag.ToArray());

        // when
        var actual = TagService.translateTags(testMultipleTags);
        
        // then
        actual.Should().HaveCount(tagCount);
    }
    
    /// <summary>
    /// Generates some fixed numbers for the tag translation test.
    /// </summary>
    private static IEnumerable<object[]> GenerateSkillId()
    {
        yield return [0];
        yield return [1];
        yield return [7];
        yield return [13];
        yield return [25];
        yield return [128]; // if we have more than this, its too much.
    }
    
    [Theory]
    [MemberData(nameof(GenerateInvalidTag))]
    public void translateTags_skipsInvalidTags(string testTag)
    {
        // given
        // when
        var actual = TagService.translateTags(testTag);
        
        // then
        actual.Should().BeEmpty();
    }
    
    /// <summary>
    /// Generates some invalid tag formats for the tag translation test.
    /// </summary>
    private static IEnumerable<object[]> GenerateInvalidTag()
    {
        yield return ["<foo"];   // needs on end as well.
        yield return ["bar>"];   // needs on start as well.
        yield return ["foobar"]; // needs on both start and end.
    }
    
    [Fact]
    public void translateTags_withSingleTag_translatesBoolean()
    {
        // given
        var testSingleTag = this.fdg.DirectTargetingTag();
        
        // when
        var actual = TagService.translateTags(testSingleTag);
        
        // then
        actual.Should().HaveCount(1);

        var actualTag = actual.First();
        actualTag.isBoolean.Should().BeTrue();
    }
}