using FluentAssertions;
using JMZ.Base.Tests;
using JMZ.LevelMaster.Data.Extensions.implementations._Enemy;
using JMZ.Rmmz.Data.Models.db.implementations;
using Xunit;

namespace JMZ.LevelMaster.Data.Tests.Extensions.implementations._Enemy;

[Trait("Category","EnemyData")]
public class LevelsExtTest : BaseTests
{
    private readonly RPG_Enemy modelUnderTest;

    public LevelsExtTest()
    {
        this.modelUnderTest = new();
    }

    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        this.modelUnderTest.note = string.Empty;

        // when
        var actual = this.modelUnderTest.GetLevel();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenAdded_returnsValue()
    {
        // given
        var expected = this.fdg.RmmzUNumber();
        this.modelUnderTest.UpdateLevel(expected);

        // when
        var actual = this.modelUnderTest.GetLevel();
        
        // then
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void whenUpdated_returnsUpdatedValue()
    {
        // given
        var firstNumber = this.fdg.RmmzUNumber();
        this.modelUnderTest.UpdateLevel(firstNumber);

        var secondNumber = this.fdg.RmmzUNumber();
        this.modelUnderTest.UpdateLevel(secondNumber);

        // when
        var actual = this.modelUnderTest.GetLevel();
        
        // then
        actual.Should().Be(secondNumber);
    }
    
    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var fakeNumber = this.fdg.RmmzUNumber();
        this.modelUnderTest.UpdateLevel(fakeNumber);
        
        var numberOfRemoval = decimal.Zero;
        this.modelUnderTest.UpdateLevel(numberOfRemoval);

        // when
        var actual = this.modelUnderTest.GetLevel();
        
        // then
        actual.Should().NotBe(fakeNumber);
        actual.Should().Be(decimal.Zero);
    }
}