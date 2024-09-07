using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Skill.ComboData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Skill.ComboData;

public class AiComboStarterExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;

    public AiComboStarterExtTests()
    {
        modelUnderTest = new();
    }

    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        modelUnderTest.note = string.Empty;

        // when
        var actual = modelUnderTest.HasJabsAiComboStarter();

        // then
        actual.Should()
            .BeFalse();
    }

    [Fact]
    public void whenAdded_returnsValue()
    {
        // given
        var fakeTag = fdg.AiComboStarterTag();
        var fakeNote = fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;

        // when
        var actual = modelUnderTest.HasJabsAiComboStarter();

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
        modelUnderTest.UpdateJabsAiComboStarter(fakeTagValue); // update with valid value.
        modelUnderTest.UpdateJabsAiComboStarter(expected);

        // when
        var actual = modelUnderTest.HasJabsAiComboStarter();

        // then
        actual.Should()
            .BeFalse();
    }
}