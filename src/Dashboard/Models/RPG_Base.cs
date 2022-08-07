using System.Text.RegularExpressions;
using Dashboard.Models.Tags;
using Dashboard.Services;

namespace Dashboard.Models;

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
    
    internal void updateNotedata(string structure, string replacement)
    {
        var tags = this.note;
        var regex = new Regex(structure, RegexOptions.IgnoreCase);
        var tagCollection = tags.Split('\n').ToList();
        tagCollection = tagCollection
            .Select(tag =>
            {
                if (regex.IsMatch(tag))
                {
                    tag = regex.Replace(tag, replacement);
                }

                return tag;
            })
            .ToList();

        this.note = string.Join('\n', tagCollection);
    }

    public virtual void parseTags()
    {
    }
}
