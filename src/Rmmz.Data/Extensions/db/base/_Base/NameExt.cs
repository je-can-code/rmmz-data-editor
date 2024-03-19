using JMZ.Rmmz.Data.Models.db.@base;

namespace JMZ.Rmmz.Data.Extensions.db.@base._Base;

public static class NameExt
{
    /// <summary>
    /// Gets the name of the database object.
    /// </summary>
    public static string GetName(this RPG_Base databaseEntry)
    {
        return databaseEntry.name;
    }

    /// <summary>
    /// Updates the name of the database object with a new value..
    /// </summary>
    /// <param name="databaseEntry">The database entry to update the name of.</param>
    /// <param name="newName">The new name to update the database entry with.</param>
    public static void UpdateName(this RPG_Base databaseEntry, string newName)
    {
        databaseEntry.name = newName;
    }
}