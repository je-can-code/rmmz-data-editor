using System.Text.RegularExpressions;
using Dashboard.Extensions;
using Dashboard.Models.Tags;
using Dashboard.Services;

namespace Dashboard.Models.@base;

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

    internal string? getStringByTag(string tagName, bool nullIfEmpty = false)
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

    internal decimal? getNumberByTag(string tagName, bool nullIfEmpty = false)
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

    internal List<decimal>? getNumbersByTag(string tagName, bool nullIfEmpty = false)
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
