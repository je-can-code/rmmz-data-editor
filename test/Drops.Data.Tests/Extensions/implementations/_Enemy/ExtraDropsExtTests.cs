using FluentAssertions;
using JMZ.Base.Tests;
using JMZ.Drops.Data.Extensions.implementations._Enemy;
using JMZ.Rmmz.Data.Models.db.implementations;
using Xunit;

namespace JMZ.Drops.Data.Tests.Extensions.implementations._Enemy;

[Trait("Category","EnemyData")]
public class ExtraDropsExtTests : BaseTests
{
    private readonly RPG_Enemy modelUnderTest;

    public ExtraDropsExtTests()
    {
        this.modelUnderTest = new();
    }

    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        this.modelUnderTest.note = string.Empty;

        // when
        var actual = this.modelUnderTest.GetDropsData();

        // then
        actual.Should().BeEmpty();
    }
    
    [Fact]
    public void whenAdded_returnsDrops()
    {
        // given
        var fakeDropItemsCount = this.fdg.RmmzUNumber();
        var fakeDropItems = this.fdg.GenerateDropItems(fakeDropItemsCount);
        this.modelUnderTest.UpdateDropsData(fakeDropItems);

        // when
        var actual = this.modelUnderTest.GetDropsData();

        // then
        actual.Should().BeEquivalentTo(fakeDropItems);
    }
    
    [Fact]
    public void whenUpdated_returnsUpdatedDrops()
    {
        // given
        var firstDropItemsCount = this.fdg.RmmzUNumber();
        var firstDropItems = this.fdg.GenerateDropItems(firstDropItemsCount);
        this.modelUnderTest.UpdateDropsData(firstDropItems);

        var secondDropItemsCount = this.fdg.RmmzUNumber();
        var secondDropItems = this.fdg.GenerateDropItems(secondDropItemsCount);
        this.modelUnderTest.UpdateDropsData(secondDropItems);
        
        // when
        var actual = this.modelUnderTest.GetDropsData();

        // then
        actual.Should().NotBeEquivalentTo(firstDropItems);
        actual.Should().BeEquivalentTo(secondDropItems);
    }
    
    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var firstDropItemsCount = this.fdg.RmmzUNumber();
        var firstDropItems = this.fdg.GenerateDropItems(firstDropItemsCount);
        this.modelUnderTest.UpdateDropsData(firstDropItems);

        this.modelUnderTest.UpdateDropsData([]);
        
        // when
        var actual = this.modelUnderTest.GetDropsData();

        // then
        actual.Should().NotBeEquivalentTo(firstDropItems);
        actual.Should().BeEmpty();
    }
}