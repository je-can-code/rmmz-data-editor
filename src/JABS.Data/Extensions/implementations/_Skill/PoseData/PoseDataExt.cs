using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;
using PoseDataRecord = JMZ.JABS.Data.Models.PoseData;

namespace JMZ.JABS.Data.Extensions.implementations._Skill.PoseData;

internal static class PoseDataExt
{
    internal static PoseDataRecord GetJabsPoseData(this RPG_Skill skill)
    {
        // retrieve the data points.
        var poseData = skill.GetAllStringsByTag(Tags.Pose.Name) ?? new List<string>();

        // if there are no data points, then there are no poses.
        if (!poseData.Any())
        {
            // return an empty set.
            return new(string.Empty);
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
        decimal newPoseIndex = 0,
        decimal newPoseDuration = 0)
    {
        // check if we currently are missing a primary value.
        var isMissing = skill.GetJabsPoseSuffix() == string.Empty;

        // check if there is no value and was passed a non-value.
        if (isMissing && newPoseSuffix == string.Empty)
        {
            // do nothing.
            return;
        }

        // check if the pose suffix became empty but had a suffix previously.
        if (newPoseSuffix == string.Empty)
        {
            skill.RemoveNoteData(Tags.Pose.Regex);

            // do nothing.
            return;
        }
        
        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Tags.Pose.ToArrayTag(
            newPoseSuffix,
            newPoseIndex.ToString(),
            newPoseDuration.ToString());

        // check if the value was missing previously.
        if (isMissing)
        {
            // add the new tag to the note.
            skill.AddNoteData(updatedNote);
        }
        // the value just needs to be updated.
        else
        {
            // update the actual note.
            skill.UpdateNoteData(Tags.Pose.Regex, updatedNote);
        }
    }
}