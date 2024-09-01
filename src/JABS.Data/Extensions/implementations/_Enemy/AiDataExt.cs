using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.JABS.Data.Extensions.implementations._Enemy;

public static class AiDataExt
{
    public static bool HasJabsAiTraitCareful(this RPG_Enemy enemy)
    {
        return enemy.HasBooleanTag(Tags.AiTraitCareful.Name);
    }
    
    public static bool HasJabsAiTraitExecutor(this RPG_Enemy enemy)
    {
        return enemy.HasBooleanTag(Tags.AiTraitExecutor.Name);
    }
    
    public static bool HasJabsAiTraitReckless(this RPG_Enemy enemy)
    {
        return enemy.HasBooleanTag(Tags.AiTraitReckless.Name);
    }
    
    public static bool HasJabsAiTraitHealer(this RPG_Enemy enemy)
    {
        return enemy.HasBooleanTag(Tags.AiTraitHealer.Name);
    }
    
    public static bool HasJabsAiTraitLeader(this RPG_Enemy enemy)
    {
        return enemy.HasBooleanTag(Tags.AiTraitLeader.Name);
    }
    
    public static bool HasJabsAiTraitFollower(this RPG_Enemy enemy)
    {
        return enemy.HasBooleanTag(Tags.AiTraitFollower.Name);
    }
    
    public static void UpdateJabsAiTraitCareful(this RPG_Enemy enemy, bool aiTraitEnabled)
    {
        // check what our current state is.
        var currentlyEnabled = enemy.HasJabsAiTraitCareful();

        // determine what action to take.
        switch (currentlyEnabled)
        {
            // was before and still is.
            case true when aiTraitEnabled:
                return;
            // was previously but is not any longer.
            case true:
                enemy.RemoveNoteData(Tags.AiTraitCareful.Regex);
                break;
            // was not previously, but is now.
            case false when aiTraitEnabled:
                enemy.AddNoteData(Tags.AiTraitCareful.ToBooleanTag());
                break;
        }
    }
    
    public static void UpdateJabsAiTraitExecutor(this RPG_Enemy enemy, bool aiTraitEnabled)
    {
        // check what our current state is.
        var currentlyEnabled = enemy.HasJabsAiTraitExecutor();

        // determine what action to take.
        switch (currentlyEnabled)
        {
            // was before and still is.
            case true when aiTraitEnabled:
                return;
            // was previously but is not any longer.
            case true:
                enemy.RemoveNoteData(Tags.AiTraitExecutor.Regex);
                break;
            // was not previously, but is now.
            case false when aiTraitEnabled:
                enemy.AddNoteData(Tags.AiTraitExecutor.ToBooleanTag());
                break;
        }
    }
    
    public static void UpdateJabsAiTraitReckless(this RPG_Enemy enemy, bool aiTraitEnabled)
    {
        // check what our current state is.
        var currentlyEnabled = enemy.HasJabsAiTraitReckless();

        // determine what action to take.
        switch (currentlyEnabled)
        {
            // was before and still is.
            case true when aiTraitEnabled:
                return;
            // was previously but is not any longer.
            case true:
                enemy.RemoveNoteData(Tags.AiTraitReckless.Regex);
                break;
            // was not previously, but is now.
            case false when aiTraitEnabled:
                enemy.AddNoteData(Tags.AiTraitReckless.ToBooleanTag());
                break;
        }
    }

    public static void UpdateJabsAiTraitHealer(this RPG_Enemy enemy, bool aiTraitEnabled)
    {
        // check what our current state is.
        var currentlyEnabled = enemy.HasJabsAiTraitHealer();

        // determine what action to take.
        switch (currentlyEnabled)
        {
            // was before and still is.
            case true when aiTraitEnabled:
                return;
            // was previously but is not any longer.
            case true:
                enemy.RemoveNoteData(Tags.AiTraitHealer.Regex);
                break;
            // was not previously, but is now.
            case false when aiTraitEnabled:
                enemy.AddNoteData(Tags.AiTraitHealer.ToBooleanTag());
                break;
        }
    }
    
    public static void UpdateJabsAiTraitLeader(this RPG_Enemy enemy, bool aiTraitEnabled)
    {
        // check what our current state is.
        var currentlyEnabled = enemy.HasJabsAiTraitLeader();

        // determine what action to take.
        switch (currentlyEnabled)
        {
            // was before and still is.
            case true when aiTraitEnabled:
                return;
            // was previously but is not any longer.
            case true:
                enemy.RemoveNoteData(Tags.AiTraitLeader.Regex);
                break;
            // was not previously, but is now.
            case false when aiTraitEnabled:
                enemy.AddNoteData(Tags.AiTraitLeader.ToBooleanTag());
                break;
        }
    }
    
    public static void UpdateJabsAiTraitFollower(this RPG_Enemy enemy, bool aiTraitEnabled)
    {
        // check what our current state is.
        var currentlyEnabled = enemy.HasJabsAiTraitFollower();

        // determine what action to take.
        switch (currentlyEnabled)
        {
            // was before and still is.
            case true when aiTraitEnabled:
                return;
            // was previously but is not any longer.
            case true:
                enemy.RemoveNoteData(Tags.AiTraitFollower.Regex);
                break;
            // was not previously, but is now.
            case false when aiTraitEnabled:
                enemy.AddNoteData(Tags.AiTraitFollower.ToBooleanTag());
                break;
        }
    }
}