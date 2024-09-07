using JMZ.Base.Tests;
using JMZ.JABS.Data.Extensions.implementations._Skill.PoseData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Tests.Extensions.implementations._Skill.PoseData;

[Trait("Category", "PoseData")]
public class PoseDataExtTests : BaseTests
{
    private readonly RPG_Skill modelUnderTest;

    public PoseDataExtTests()
    {
        modelUnderTest = new();
    }

    [Fact]
    public void whenUnset_returnsDefault()
    {
        // given
        var expected = new Models.PoseData(string.Empty);
        modelUnderTest.note = string.Empty;

        // when
        var actual = modelUnderTest.GetJabsPoseData();

        // then
        actual.Should()
            .Be(expected);
    }

    [Fact]
    public void whenAdded_returnsValue()
    {
        // given
        var fakeTag = fdg.PoseDataTag();
        var fakeNote = fdg.BuildNoteTag(fakeTag);
        modelUnderTest.note = fakeNote;

        // when
        var actual = modelUnderTest.GetJabsPoseData();
        var (poseSuffix, poseIndex, poseDuration) = actual;

        // then
        fakeTag.Should()
            .Contain(poseSuffix);
        fakeTag.Should()
            .Contain(poseIndex.ToString());
        fakeTag.Should()
            .Contain(poseDuration.ToString());
    }

    [Fact]
    public void whenUpdated_returnsData()
    {
        // given
        var testPoseSuffix = "-atk";
        var testPoseIndex = fdg.RmmzUNumber();
        var testPoseDuration = fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsPoseData(testPoseSuffix, testPoseIndex, testPoseDuration);

        // when
        var actual = modelUnderTest.GetJabsPoseData();

        // then
        actual.PoseSuffix
            .Should()
            .Be(testPoseSuffix);
        actual.PoseIndex
            .Should()
            .Be(testPoseIndex);
        actual.PoseDuration
            .Should()
            .Be(testPoseDuration);
    }

    [Fact]
    public void whenRemoved_returnsDefault()
    {
        // given
        var expected = new Models.PoseData(string.Empty);
        var testPoseSuffix = "-atk";
        var testPoseIndex = fdg.RmmzUNumber();
        var testPoseDuration = fdg.RmmzUNumber();
        modelUnderTest.UpdateJabsPoseData(testPoseSuffix, testPoseIndex, testPoseDuration);
        modelUnderTest.UpdateJabsPoseData(string.Empty);

        // when
        var actual = modelUnderTest.GetJabsPoseData();

        // then
        actual.Should()
            .Be(expected);
    }
}