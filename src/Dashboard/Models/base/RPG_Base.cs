using System.Text.RegularExpressions;
using Dashboard.Models.Tags;
using Dashboard.Services;

namespace Dashboard.Models.@base;

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

    /// <summary>
    /// The formatted collection of note data.
    /// </summary>
    /// <returns></returns>
    internal List<NoteTag> notedata()
    {
        return TagService.translateTags(this.note);
    }
    
    /// <summary>
    /// Updates the note data accordingly to the regex structure provided and replaces
    /// the value of that structure with the given value.
    /// </summary>
    /// <param name="structure">The structure of note to find.</param>
    /// <param name="replacement">The value to replace with the original value.</param>
    internal void updateNotedata(string structure, string replacement)
    {
        // grab the notes string.
        var tags = this.note;
        
        // build the regex for matching.
        var regex = new Regex(structure, RegexOptions.IgnoreCase);
        
        // split the tags into an array based on new lines.
        var tagCollection = tags.Split('\n').ToList();
        
        // iterate over the array and update it with the new value.
        tagCollection = tagCollection
            .Select(tag =>
            {
                // check to make sure we have a match.
                if (regex.IsMatch(tag))
                {
                    // replace the value with the new value.
                    tag = regex.Replace(tag, replacement);
                }

                // return the potentially mutated tag value.
                return tag;
            })
            .ToList();

        // reconnect all the tags as a single long string.
        this.note = string.Join('\n', tagCollection);
    }

    /// <summary>
    /// Parses the tags.
    /// </summary>
    public virtual void parseTags()
    {
    }
}
