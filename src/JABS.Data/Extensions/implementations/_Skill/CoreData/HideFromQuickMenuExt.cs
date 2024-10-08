﻿using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Extensions.implementations._Skill.CoreData;

public static class HideFromQuickMenuExt
{
    public static bool HasJabsHideFromQuickMenu(this RPG_Skill skill)
    {
        return skill.HasBooleanTag(Tags.HideFromQuickMenu.Name);
    }

    public static void UpdateJabsHideFromQuickMenu(this RPG_Skill skill, bool hideFromQuickMenu)
    {
        // check what our current state is.
        var currentlyEnabled = skill.HasJabsHideFromQuickMenu();

        // determine what action to take.
        switch (currentlyEnabled)
        {
            // was before and still is.
            case true when hideFromQuickMenu:
                return;
            // was previously but is not any longer.
            case true:
                skill.RemoveNoteData(Tags.HideFromQuickMenu.Regex);
                break;
            // was not previously, but is now.
            case false when hideFromQuickMenu:
                skill.AddNoteData(Tags.HideFromQuickMenu.ToBooleanTag());
                break;
        }
    }
}