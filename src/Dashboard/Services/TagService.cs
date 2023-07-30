using JMZ.Rmmz.Data.Tags;

namespace JMZ.Dashboard.Services;

/// <summary>
/// A service for translating tag blobs into a collection of tags.
/// </summary>
internal static class TagService
{
    /// <summary>
    /// Translates a note tag block into its respective tags.
    /// </summary>
    public static List<NoteTag> translateTags(string tags)
    {
        // divide the collection by line breaks.
        var tagCollection = tags.Split("\n");
            
        // convert the collection of lines into note tags.
        var convertedTags = tagCollection
            .Where(isValidTag)
            .Select(translateTag)
            .ToList();

        return convertedTags;
    }

    /// <summary>
    /// Determines whether or not the line is a valid and parsable tag.
    /// </summary>
    /// <param name="line">A line from the note tag section of a database entry.</param>
    /// <returns>True if this is a valid tag, false otherwise.</returns>
    private static bool isValidTag(string line)
    {
        // ignore tags that don't start and end with our angle brackets.
        if (!line.StartsWith('<') || !line.EndsWith('>')) return false;

        // translate the tag!
        return true;
    }

    /// <summary>
    /// Translates a known tag type into a <see cref="NoteTag"/>.
    /// </summary>
    /// <param name="tag">The string to translate into a tag.</param>
    /// <returns>The newly built tag.</returns>
    private static NoteTag translateTag(string tag)
    {
        // check if there is a delimiter in the tag.
        if (tag.Contains(':'))
        {
            // build the name-value pair type of tag.
            return translateNameValueTag(tag);
        }

        // build the boolean type of tag.
        return translateBooleanTag(tag);
    }

    /// <summary>
    /// Translates a known tag into a name-value pair type of <see cref="NoteTag"/>.
    /// </summary>
    /// <param name="tag">The string to translate into a tag.</param>
    /// <returns>The newly built name-value type tag.</returns>
    private static NoteTag translateNameValueTag(string tag)
    {
        // use the colon as a delimiter between name and value.
        var split = tag.Split(':');
            
        // skip the opening angle bracket for the name.
        var name = split[0].TrimStart('<');
            
        // skip the closing angle bracket for the value.
        var value = split[1].TrimEnd('>');
            
        // build a new note tag object.
        var notetag = new NoteTag { Name = name, Value = value };
            
        // return the name-value tag.
        return notetag;
    }

    /// <summary>
    /// Translates a known tag into a boolean type of <see cref="NoteTag"/>.
    /// </summary>
    /// <param name="tag">The string to translate into a tag.</param>
    /// <returns>The newly built boolean type tag.</returns>
    private static NoteTag translateBooleanTag(string tag)
    {
        // remove the opening and closing brackets.
        var nameAndValue = tag.TrimStart('<').TrimEnd('>');
            
        // build a new note tag 
        var notetag = new NoteTag { Name = nameAndValue, isBoolean = true };
            
        // return the boolean-type tag.
        return notetag;
    }
}