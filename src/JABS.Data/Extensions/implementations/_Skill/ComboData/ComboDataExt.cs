using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;
using ComboDataRecord = JMZ.JABS.Data.Models.ComboData;

namespace JMZ.JABS.Data.Extensions.implementations._Skill.ComboData;

internal static class ComboDataExt
{
    internal static ComboDataRecord GetJabsComboData(this RPG_Skill skill)
    {
        // grab the number data from the combo.
        var comboData = skill.GetAllNumbersByTag(Tags.Combo.Name) ?? [];

        // if there are no numbers, then there are no combos.
        if (!comboData.Any())
        {
            // return an empty set.
            return new();
        }
        
        // naming the first value.
        var comboSkillId = comboData[0];

        // naming the second value.
        var comboDelay = comboData[1];

        // return what the collection contained for combo data.
        return new(comboSkillId, comboDelay);
    }

    internal static void UpdateJabsComboData(this RPG_Skill skill, decimal comboSkill, decimal comboDelay)
    {
        // determine if this skill is missing a combo skill on it.
        var missingComboSkill = skill.GetJabsComboSkillId() == decimal.Zero;

        // check if there is no skill and was passed a no-combo-skill value.
        if (missingComboSkill && comboSkill == 0)
        {
            // do nothing.
            return;
        }

        // check if the combo skill becomes zero but had it previously.
        if (comboSkill == 0)
        {
            // remove the tag entirely, zero is an invalid combo skill.
            skill.RemoveNoteData(Tags.Combo.Regex);
            
            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new values.
        var updatedNote = Tags.Combo.ToArrayTag(comboSkill.ToString(), comboDelay.ToString());

        if (missingComboSkill)
        {
            skill.AddNoteData(updatedNote);
        }
        // the note just needs to be updated.
        else
        {
            // update the actual note.
            skill.UpdateNoteData(Tags.Combo.Regex, updatedNote);
        }
    }
}