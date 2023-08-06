using System.Text.RegularExpressions;
using JMZ.Rmmz.Data.Models.db.@base;
using JMZ.Rmmz.Data.Services;
using JMZ.Rmmz.Data.Tags;

namespace JMZ.Rmmz.Data.Extensions.db.@base._Base;

/// <summary>
/// Extension methods against <see cref="RPG_Base"/> that are for reading and writing note data
/// from the note field of any database object.
/// </summary>
public static class NoteExtensions
{
    /// <summary>
    /// Updates all tags that match the given regex with the new value.
    /// </summary>
    public static void UpdateNoteData(this RPG_Base @base, string structure, string replacement)
    {
        // We don't start with a match.
        var foundMatch = false;
        
        // grab the notes string.
        var tags = @base.note;
        
        // build the regex for matching.
        var regex = new Regex(structure, RegexOptions.IgnoreCase);
        
        // split the tags into an array based on new lines.
        var tagCollection = tags.Split('\r', '\n').ToList();
        
        // iterate over the array and update it with the new value.
        tagCollection = tagCollection
            .Select(tag =>
            {
                // check to make sure we have a match.
                if (!regex.IsMatch(tag)) return tag;
                
                // replace the value with the new value.
                tag = regex.Replace(tag, replacement);
                
                // raise the flag for finding a match.
                foundMatch = true;

                // return the potentially mutated tag value.
                return tag;
            })
            .ToList();

        // if no matches were found, then no changes were made.
        if (!foundMatch) return;

        // reconnect all the tags as a single long string.
        @base.note = string.Join('\n', tagCollection);
    }
    
    /// <summary>
    /// Adds a new tag as a full string to the note.
    /// </summary>
    public static void AddNoteData(this RPG_Base @base, string addition)
    {
        // add the new data between two new lines.
        @base.note += $"\n{addition}\n";
        
        // cleanup excess newlines.
        @base.CleanupNoteData();
    }

    /// <summary>
    /// Removes all instances of a tag that match the given regex.
    /// </summary>
    public static void RemoveNoteData(this RPG_Base @base, string structure)
    {
        // remove the note by replacing it with an empty string.
        @base.UpdateNoteData(structure, string.Empty);
        
        // cleanup excess newlines.
        @base.CleanupNoteData();
    }

    /// <summary>
    /// Gets all <see cref="NoteTag"/>s from this database object that match the given tag name.
    /// </summary>
    internal static List<NoteTag> NoteDataByTagName(this RPG_Base @base, string tagName)
    {
        // grab the note data to scan.
        var tags = @base.NoteData();

        // filter down to the tags we care about.
        return tags
            .Where(tag => tag.Name == tagName)
            .ToList();
    }

    /// <summary>
    /// Manually cleans up any excess new lines as a result of modifying the note field.
    /// This is a destructive procedure against the note field.
    /// </summary>
    private static void CleanupNoteData(this RPG_Base @base)
    {
        // while we have duplicate newlines...
        while (@base.note.Contains("\n\n"))
        {
            // keep removing the duplicates.
            @base.note = @base.note.Replace("\n\n", "\n");
        }
        
        // while we have duplicate newlines... (non-windows)
        while (@base.note.Contains("\r\r"))
        {
            // keep removing the duplicates.
            @base.note = @base.note.Replace("\r\r", "\r");
        }

        // check if we have any leading newlines.
        while (@base.note.StartsWith("\n") || @base.note.StartsWith("\r"))
        {
            // strip off the starting newline as well.
            @base.note = @base.note[1..];
        }
    }
    
    /// <summary>
    /// Converts the note object on this database data into a <see cref="List{NoteTag}"/>.
    /// </summary>
    private static IEnumerable<NoteTag> NoteData(this RPG_Base @base)
    {
        return TagService.translateTags(@base.note);
    }
}