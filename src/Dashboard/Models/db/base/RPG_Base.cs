using System.Text.RegularExpressions;
using Dashboard.Extensions;
using Dashboard.Models.Tags;
using Dashboard.Services;

namespace Dashboard.Models.db.@base;

/// <summary>
/// A class representing the foundation of all database objects.
/// </summary>
public abstract class RPG_Base
{
    #region properties
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
    #endregion properties
    
    /// <summary>
    /// The formatted collection of note data.
    /// </summary>
    /// <returns></returns>
    internal List<NoteTag> notedata()
    {
        return TagService.translateTags(this.note);
    }

    /// <summary>
    /// Determines whether or not this database entry has a tag in its
    /// note data matching the given tag name.
    /// </summary>
    /// <param name="tagName">The name of the tag to find.</param>
    /// <returns>True if the tag exists on this entry, false otherwise.</returns>
    internal bool hasBooleanTag(string tagName)
    {
        // grab the note data to scan.
        var tags = this.notedata();

        // check if we have the tag.
        var hasBooleanTag = tags.Any(tag => tag.Name == tagName);

        // return what we found.
        return hasBooleanTag;
    }
    
    internal List<NoteTag> notedataByTagName(string tagName)
    {
        // grab the note data to scan.
        var tags = this.notedata();

        // filter down to the tags we care about.
        return tags
            .Where(tag => tag.Name == tagName)
            .ToList();
    }

    internal string? getAsStringByTag(string tagName, bool nullIfEmpty = false)
    {
        // grab the note data to scan.
        var tags = this.notedataByTagName(tagName);
        
        // check if we had any tags on this entry.
        if (!tags.Any())
        {
            // return null or empty based on parameters.
            return nullIfEmpty
                ? null
                : string.Empty;
        }
        
        // there should only be the one, but if more then ignore the rest.
        var tag = tags.First();

        // do nothing with the parsed data.
        var stringyValue = tag.Value;

        // return the result.
        return stringyValue;
    }

    internal List<string>? getAsStringsByTag(string tagName, bool nullIfEmpty = false)
    {
        // grab the note data to scan.
        var tags = this.notedataByTagName(tagName);
        
        // check if we had any tags on this entry.
        if (!tags.Any())
        {
            // return null or empty based on parameters.
            return nullIfEmpty
                ? null
                : new();
        }
        
        // iterate over each of the tags.
        var strings = tags.Aggregate(
            new List<string>(),
            (runningList, tag) =>
            {
                // translate the string array of numbers into a list of strings.
                var valueStrings = tag.Value.toStringList();

                // add the values to the list.
                runningList.AddRange(valueStrings);
                
                // return the running collection.
                return runningList;
            });

        // return what we found.
        return strings;
    }

    internal decimal? getAsNumberByTag(string tagName, bool nullIfEmpty = false)
    {
        // grab the note data to scan.
        var tags = this.notedataByTagName(tagName);

        // check if we had any tags on this entry.
        if (!tags.Any())
        {
            // return null or empty based on parameters.
            return nullIfEmpty
                ? null
                : 0;
        }

        // there should only be the one, but if more then ignore the rest.
        var tag = tags.First();

        // parse the stringy value to its proper form.
        var number = decimal.Parse(tag.Value);

        // return the result.
        return number;
    }

    internal List<decimal>? getAsNumbersByTag(string tagName, bool nullIfEmpty = false)
    {
        // grab the note data to scan.
        var tags = this.notedataByTagName(tagName);

        // check if we had any tags on this entry.
        if (!tags.Any())
        {
            // return null or empty based on parameters.
            return nullIfEmpty
                ? null
                : new List<decimal>(0);
        }
        
        // iterate over each of the tags.
        var numbers = tags.Aggregate(
            new List<decimal>(),
            (runningTotal, tag) =>
            {
                // translate the string array of numbers into a list of decimals.
                var valueNumbers = tag.Value.toDecimalList();

                // add the values to the list.
                runningTotal.AddRange(valueNumbers);
                
                // return the new total.
                return runningTotal;
            });

        // return what we found.
        return numbers;
    }

    internal decimal? getSumByTag(string tagName, bool nullIfEmpty = false)
    {
        // grab the note data to scan.
        var tags = this.notedataByTagName(tagName);

        // check if we had any tags on this entry.
        if (!tags.Any())
        {
            // return null or empty based on parameters.
            return nullIfEmpty
                ? null
                : decimal.Zero;
        }

        // iterate over each of the tags.
        var sum = tags.Aggregate(
            decimal.Zero,
            (runningTotal, tag) =>
            {
                // parse the value from the tag.
                var addableValue = decimal.Parse(tag.Value);

                // add the value on.
                runningTotal += addableValue;
                
                // return the new total.
                return runningTotal;
            });

        return sum;
    }

    /// <summary>
    /// Updates all tags that match the given regex with the new value.
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
        var tagCollection = tags.Split(Environment.NewLine).ToList();
        
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
        this.note = string.Join(Environment.NewLine, tagCollection);
    }

    /// <summary>
    /// Adds a new tag as a full string to the note.
    /// </summary>
    /// <param name="addition"></param>
    internal void addNotedata(string addition)
    {
        // add the new data between two new lines.
        this.note += $"\n{addition}\n";
        
        // cleanup excess newlines.
        this.cleanupNotedata();
    }
    
    /// <summary>
    /// Removes all instances of a tag that match the given regex.
    /// </summary>
    /// <param name="structure"></param>
    internal void removeNotedata(string structure)
    {
        // remove the note by replacing it with an empty string.
        this.updateNotedata(structure, string.Empty);
        
        // cleanup excess newlines.
        this.cleanupNotedata();
    }

    /// <summary>
    /// Manually cleans up any excess new lines as a result of modifying the note field.
    /// This is a destructive procedure against the note field.
    /// </summary>
    private void cleanupNotedata()
    {
        // while we have duplicate newlines...
        while (this.note.Contains("\n\n"))
        {
            // keep removing the duplicates.
            this.note = this.note.Replace("\n\n", "\n");
        }
        
        // while we have duplicate newlines... (non-windows)
        while (this.note.Contains("\r\r"))
        {
            // keep removing the duplicates.
            this.note = this.note.Replace("\r\r", "\r");
        }

        // check if we have any leading newlines.
        while (this.note.StartsWith("\n") || this.note.StartsWith("\r"))
        {
            // strip off the starting newline as well.
            this.note = this.note[2..];
        }
    }
}
