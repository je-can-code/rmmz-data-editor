using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;
using PoseDataRecord = JMZ.Rmmz.Data.Models.JABS.PoseData;

namespace JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.PoseData;

internal static class PoseDataExt
{
    internal static PoseDataRecord GetJabsPoseData(this RPG_Skill skill)
    {
        // retrieve the data points.
        var poseData = skill.getAsStringsByTag(Models.JABS.Tags.Pose.Name) ?? new List<string>();

        // if there are no data points, then there are no poses.
        if (!poseData.Any())
        {
            // return an empty set.
            return new();
        }
        
        // the actual suffix appended to the base character sheet name.
        var poseSuffix = poseData[0];

        // parse the index.
        var poseIndex = decimal.Parse(poseData[1]);

        // parse the duration.
        var poseDuration = decimal.Parse(poseData[2]);
        
        // return what the collection contained for pose data.
        return new(poseSuffix, poseIndex, poseDuration);
    }

    internal static void UpdateJabsPoseData(
        this RPG_Skill skill,
        string newPoseSuffix,
        decimal newPoseIndex,
        decimal newPoseDuration)
    {
        // grab the current pose suffix for this skill.
        var poseSuffix = skill.GetJabsPoseSuffix();

        // determine if this skill is missing a pose suffix.
        var missingPoseSuffix = poseSuffix == string.Empty;

        // check if there is no skill and was passed a no-combo-skill value.
        if (missingPoseSuffix && newPoseSuffix == string.Empty)
        {
            // do nothing.
            return;
        }

        // check if the pose suffix became empty but had a suffix previously.
        if (newPoseSuffix == string.Empty)
        {
            skill.RemoveNoteData(Models.JABS.Tags.Pose.Regex);

            // do nothing.
            return;
        }
        
        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Models.JABS.Tags.Pose.ToArrayTag(
            newPoseSuffix,
            newPoseIndex.ToString(),
            newPoseDuration.ToString());
        
        // update the actual note.
        skill.UpdateNoteData(Models.JABS.Tags.Pose.Regex, updatedNote);
    }
}