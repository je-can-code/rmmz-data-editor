using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Skill.UsageData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Skill.UsageData;

[Trait("Category", "UsageData")]
public class GapCloserExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;

    public GapCloserExtTests()
    {
        modelUnderTest = new();
    }

    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        modelUnderTest.note = string.Empty;

        // when
        var actual = modelUnderTest.HasJabsGapCloser();

        // then
        actual.Should()
            .BeFalse();
    }

    [Fact]
    public void whenAdded_returnsValue()
    {
        // given
        var fakeTag = fdg.GapCloserTag();
        var fakeNote = fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;

        // when
        var actual = modelUnderTest.HasJabsGapCloser();

        // then
        actual.Should()
            .BeTrue();
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = false;
        var fakeTagValue = true;
        modelUnderTest.UpdateJabsGapCloser(fakeTagValue);
        modelUnderTest.UpdateJabsGapCloser(expected);

        // when
        var actual = modelUnderTest.HasJabsGapCloser();

        // then
        actual.Should()
            .BeFalse();
    }
}