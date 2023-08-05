using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;
using JabsHitbox = JMZ.JABS.Data.Models.Hitbox;

namespace JMZ.JABS.Data.Extensions.implementations._Skill.TargetingData;

public static class HitboxExt
{
    public static JabsHitbox GetJabsHitbox(this RPG_Skill skill)
    {
        // parse the hitbox from the notes.
        var hitbox = skill.GetFirstStringByTag(Tags.Hitbox.Name);

        // check if the hitbox can be parsed from the string provided.
        if (Enum.TryParse<JabsHitbox>(hitbox, true, out var convertedHitbox))
        {
            return convertedHitbox;
        }

        // the default hitbox is that none is associated.
        return JabsHitbox.None;
    }
    
    public static void UpdateJabsHitbox(this RPG_Skill skill, JabsHitbox hitbox)
    {
        // grab our current state.
        var isMissing = skill.GetJabsHitbox() == Hitbox.None;

        // check if there was no value and is no value.
        if (isMissing && hitbox == JabsHitbox.None)
        {
            // do nothing.
            return;
        }

        // check if there was a value, but is no longer.
        if (hitbox == JabsHitbox.None)
        {
            // remove the note, it is no longer needed.
            skill.RemoveNoteData(Tags.Hitbox.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new value.
        var updatedNote = Tags.Hitbox.ToValueTag(hitbox.ToString().ToLower());

        // check if the value was missing previously.
        if (isMissing)
        {
            // add the new tag to the note.
            skill.AddNoteData(updatedNote);
        }
        else
        {
            // update the actual note.
            skill.UpdateNoteData(Tags.Hitbox.Regex, updatedNote);    
        }
    }
}