using FluentAssertions;
using JMZ.Base.Tests;
using JMZ.LevelMaster.Data.Extensions.implementations._Enemy;
using JMZ.Rmmz.Data.Models.db.implementations;
using Xunit;

namespace JMZ.LevelMaster.Data.Tests.Extensions.implementations._Enemy;

[Trait("Category", "EnemyData")]
public class LevelsExtTest : BaseTests
{
    private readonly RPG_Enemy modelUnderTest;

    public LevelsExtTest()
    {
        modelUnderTest = new();
    }

    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        var expected = decimal.Zero;
        modelUnderTest.note = string.Empty;

        // when
        var actual = modelUnderTest.GetLevel();

        // then
        actual.Should()
            .Be(expected);
    }

    [Fact]
    public void whenAdded_returnsValue()
    {
        // given
        var expected = fdg.RmmzUNumber();
        modelUnderTest.UpdateLevel(expected);

        // when
        var actual = modelUnderTest.GetLevel();

        // then
        actual.Should()
            .Be(expected);
    }

    [Fact]
    public void whenUpdated_returnsUpdatedValue()
    {
        // given
        var firstNumber = fdg.RmmzUNumber();
        modelUnderTest.UpdateLevel(firstNumber);

        var secondNumber = fdg.RmmzUNumber();
        modelUnderTest.UpdateLevel(secondNumber);

        // when
        var actual = modelUnderTest.GetLevel();

        // then
        actual.Should()
            .Be(secondNumber);
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var fakeNumber = fdg.RmmzUNumber();
        modelUnderTest.UpdateLevel(fakeNumber);

        var numberOfRemoval = decimal.Zero;
        modelUnderTest.UpdateLevel(numberOfRemoval);

        // when
        var actual = modelUnderTest.GetLevel();

        // then
        actual.Should()
            .NotBe(fakeNumber);
        actual.Should()
            .Be(decimal.Zero);
    }
}