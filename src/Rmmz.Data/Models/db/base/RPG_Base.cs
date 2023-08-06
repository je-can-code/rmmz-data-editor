namespace JMZ.Rmmz.Data.Models.db.@base;

/// <summary>
/// A class representing the foundation of all database objects.
/// </summary>
public abstract class RPG_Base
{
    /// <summary>
    /// The id of this database entry.
    /// </summary>
    public int id { get; set; } = 0;

    /// <summary>
    /// The name of this database entry.
    /// </summary>
    public string name { get; set; } = string.Empty;
    
    /// <summary>
    /// The note field of this database entry.
    /// </summary>
    public string note { get; set; } = string.Empty;
}
