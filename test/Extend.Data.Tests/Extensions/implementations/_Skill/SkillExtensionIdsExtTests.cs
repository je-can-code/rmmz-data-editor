using JMZ.Base.Tests;
using JMZ.Base.Tests.Utilities;
using JMZ.Rmmz.Data.Models.db.implementations;
using JMZ.Extend.Data.Extensions.implementations._Skill;
using JMZ.Rmmz.Data.Extensions;

namespace JMZ.Extend.Data.Tests.Extensions.implementations._Skill;

[Trait("Category","SkillData")]
public class SkillExtensionIdsExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;
    
    public SkillExtensionIdsExtTests()
    {
        this.modelUnderTest = new();
    }
    
    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        var expected = string.Empty;
        this.modelUnderTest.note = string.Empty;

        // when
        var actual = this.modelUnderTest.GetSkillExtendIds();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenAdded_returnsValue()
    {
        // given
        var fakeTagValueList = this.generateRandomRmmzUNumberList().ToArray();
        var fakeTagValueStringList = string.Join(",", fakeTagValueList);
        this.modelUnderTest.UpdateSkillExtendIds(fakeTagValueStringList);
        
        // when
        var actual = this.modelUnderTest.GetSkillExtendIds().ToDecimalList();
        
        // then
        actual.Should().BeEquivalentTo(fakeTagValueList);
    }
    
    [Fact]
    public void whenUpdated_returnsUpdatedValue()
    {
        // given
        var fakeTagValueList = this.generateRandomRmmzUNumberList().ToArray();
        var fakeSecondTagValueList = this.generateRandomRmmzUNumberList().ToArray();
        this.modelUnderTest.UpdateSkillExtendIds(string.Join(",", fakeTagValueList));
        this.modelUnderTest.UpdateSkillExtendIds(string.Join(",", fakeSecondTagValueList));
        
        // when
        var actual = this.modelUnderTest.GetSkillExtendIds().ToDecimalList();
        
        // then
        actual.Should().BeEquivalentTo(fakeSecondTagValueList);
    }
    
    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = string.Empty;
        var fakeTagValueList = this.generateRandomRmmzUNumberList().ToArray();
        this.modelUnderTest.UpdateSkillExtendIds(string.Join(",", fakeTagValueList));
        this.modelUnderTest.UpdateSkillExtendIds(string.Empty);
        
        // when
        var actual = this.modelUnderTest.GetSkillExtendIds();
        
        // then
        actual.Should().BeEquivalentTo(expected);
    }

    private IEnumerable<int> generateRandomRmmzUNumberList()
    {
        var fakeTagValueCount = this.fdg.RmmzUNumber();
        var fakeTagValueList = new List<int>();
        fakeTagValueCount.Times(() => fakeTagValueList.Add(this.fdg.RmmzUNumber()));
        return fakeTagValueList;
    }
}