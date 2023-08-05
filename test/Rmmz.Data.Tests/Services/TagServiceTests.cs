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
        yield return new object[] { 0 };
        yield return new object[] { 1 };
        yield return new object[] { 7 };
        yield return new object[] { 13 };
        yield return new object[] { 25 };
        yield return new object[] { 128 }; // if we have more than this, its too much.
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
        yield return new object[] { "<foo" };   // needs on end as well.
        yield return new object[] { "bar>" };   // needs on start as well.
        yield return new object[] { "foobar" }; // needs on both start and end.
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