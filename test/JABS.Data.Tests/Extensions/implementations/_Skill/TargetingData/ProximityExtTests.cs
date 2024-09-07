using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Skill.TargetingData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Skill.TargetingData;

[Trait("Category", "TargetingData")]
public class ProximityExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;

    public ProximityExtTests()
    {
        modelUnderTest = new();
    }

    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        var expected = -1;
        modelUnderTest.note = string.Empty;

        // when
        var actual = modelUnderTest.GetJabsProximity();

        // then
        actual.Should()
            .Be(expected);
    }

    [Fact]
    public void whenAdded_returnsValue()
    {
        // given
        var fakeTagValue = fdg.RmmzUNumber();
        var fakeTag = fdg.ProximityTag(fakeTagValue);
        var fakeNote = fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;

        // when
        var actual = modelUnderTest.GetJabsProximity();

        // then
        actual.Should()
            .Be(fakeTagValue);
    }

    [Fact]
    public void whenUpdated_returnsValue()
    {
        // given
        var fakeTagValue = fdg.RmmzDecimal();
        modelUnderTest.UpdateJabsProximity(fakeTagValue);

        // when
        var actual = modelUnderTest.GetJabsProximity();

        // then
        actual.Should()
            .Be(fakeTagValue);
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = -1;
        var fakeTagValue = fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsProximity(fakeTagValue); // update with valid value.
        modelUnderTest.UpdateJabsProximity(-1);

        // when
        var actual = modelUnderTest.GetJabsProximity();

        // then
        actual.Should()
            .Be(expected);
    }
}