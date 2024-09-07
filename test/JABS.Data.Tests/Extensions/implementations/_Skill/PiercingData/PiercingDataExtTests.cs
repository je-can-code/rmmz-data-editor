using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Skill.PiercingData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Skill.PiercingData;

[Trait("Category", "PiercingData")]
public class PiercingDataExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;

    public PiercingDataExtTests()
    {
        modelUnderTest = new();
    }

    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        var expected = new Models.PiercingData();
        modelUnderTest.note = string.Empty;

        // when
        var actual = modelUnderTest.GetJabsPiercingData();

        // then
        actual.Should()
            .Be(expected);
    }

    [Fact]
    public void whenAdded_returnsValue()
    {
        // given
        var fakeTag = fdg.PiercingDataTag();
        var fakeNote = fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;

        // when
        var actual = modelUnderTest.GetJabsPiercingData();
        var (pierceCount, pierceDelay) = actual;

        // then
        pierceCount.Should()
            .BePositive();
        pierceDelay.Should()
            .BePositive();
    }

    [Fact]
    public void whenUpdated_returnsData()
    {
        // given
        var testPierceCount = fdg.RmmzUNumber();
        var testPierceDelay = fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsPiercingData(testPierceCount, testPierceDelay);

        // when
        var actual = modelUnderTest.GetJabsPiercingData();

        // then
        actual.PierceCount
            .Should()
            .Be(testPierceCount);
        actual.PierceDelay
            .Should()
            .Be(testPierceDelay);
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = new Models.PiercingData();
        var testPierceCount = fdg.RmmzUNumber();
        var testPierceDelay = fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsPiercingData(testPierceCount, testPierceDelay);
        modelUnderTest.UpdateJabsPiercingData(decimal.Zero, decimal.Zero);

        // when
        var actual = modelUnderTest.GetJabsPiercingData();

        // then
        actual.Should()
            .Be(expected);
    }
}