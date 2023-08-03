using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.JABS.implementations;
using JabsHitbox = JMZ.Rmmz.Data.Models.JABS.Hitbox;

namespace JMZ.Rmmz.Data.Extensions.JABS.implementations._Skill.TargetingData;

public static class HitboxExt
{
    public static JabsHitbox GetJabsHitbox(this RPG_Skill skill)
    {
        // parse the hitbox from the notes.
        var hitbox = skill.getAsStringByTag(Models.JABS.Tags.Hitbox.Name);

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
        var currentHitbox = skill.GetJabsHitbox();

        // check if there was no hitbox and is no hitbox.
        if (currentHitbox == JabsHitbox.None && hitbox == JabsHitbox.None)
        {
            // do nothing.
            return;
        }

        // check if there was a value, but is no longer.
        if (currentHitbox != JabsHitbox.None && hitbox == JabsHitbox.None)
        {
            // remove the note, it is no longer needed.
            skill.RemoveNoteData(Models.JABS.Tags.Hitbox.Regex);

            // stop processing.
            return;
        }

        // we need to update the tag, so build the updated note with the new value.
        var updatedNote = Models.JABS.Tags.Hitbox.ToValueTag(hitbox.ToString().ToLower());
        
        // update the actual note.
        skill.UpdateNoteData(Models.JABS.Tags.Hitbox.Regex, updatedNote);
    }
}