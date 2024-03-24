using JMZ.Rmmz.Data.Models.db.@base;

namespace JMZ.Rmmz.Data.Extensions.db.@base._Base;

/// <summary>
/// Extension methods against <see cref="RPG_Base"/> that are for extracting data in a particular format
/// from the note field of any database object.
/// </summary>
public static class DataAccessExtensions
{
    /// <summary>
    /// Determines whether or not this database entry has a tag in its
    /// note data matching the given tag name.
    /// </summary>
    public static bool HasBooleanTag(this RPG_Base @base, string tagName)
    {
        // grab the note data to scan.
        var tags = @base.NoteDataByTagName(tagName);

        // check if we have the tag.
        var hasBooleanTag = tags.Any();

        // return what we found.
        return hasBooleanTag;
    }

    /// <summary>
    /// Gets the first numeric value matching the provided tag name on this database object.
    /// If no matching tag is found, <see cref="decimal.Zero"/> will be returned, or null if nullIfEmpty is true.
    /// </summary>
    public static decimal? GetFirstNumberByTag(this RPG_Base @base, string tagName, bool nullIfEmpty = false)
    {
        // grab the note data to scan.
        var tags = @base.NoteDataByTagName(tagName);
        
        // check if we had any tags on this entry.
        if (!tags.Any())
        {
            // return null or empty based on parameters.
            return nullIfEmpty
                ? null
                : decimal.Zero;
        }

        // there should only be the one, but if more then ignore the rest.
        var tag = tags.First();

        // parse the stringy value to its proper form.
        var number = decimal.Parse(tag.Value);

        // return the result.
        return number;
    }

    /// <summary>
    /// Gets all found numbers matching the provided tag name on this database object.
    /// If no matching tag is found, an empty list will be returned, or null if nullIfEmpty is true.
    ///
    /// It is important to note that this method does not sum any of the numbers together, only adds them
    /// to running list of numbers for whatever purposes they may serve in this format.
    /// </summary>
    public static List<decimal>? GetAllNumbersByTag(this RPG_Base @base, string tagName, bool nullIfEmpty = false)
    {
        // grab the note data to scan.
        var tags = @base.NoteDataByTagName(tagName);

        // check if we had any tags on this entry.
        if (!tags.Any())
        {
            // return null or empty based on parameters.
            return nullIfEmpty
                ? null
                : [];
        }
        
        // iterate over each of the tags.
        var numbers = tags.Aggregate(
            new List<decimal>(),
            (runningTotal, tag) =>
            {
                // translate the string array of numbers into a list of decimals.
                var valueNumbers = tag.Value.ToDecimalList();

                // add the values to the list.
                runningTotal.AddRange(valueNumbers);
                
                // return the new total.
                return runningTotal;
            });

        // return what we found.
        return numbers;
    }

    /// <summary>
    /// Gets the sum of all numbers found matching the provided tag name on this database object.
    /// If no matching tag is found, <see cref="decimal.Zero"/> will be returned, or null if nullIfEmpty is true.
    /// </summary>
    public static decimal? GetSumByTag(this RPG_Base @base, string tagName, bool nullIfEmpty = false)
    {
        // grab the note data to scan.
        var tags = @base.NoteDataByTagName(tagName);

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
    /// Gets the first stringy value matching the provided tag name on this database object.
    /// If no matching tag is found, <see cref="string.Empty"/> will be returned, or null if nullIfEmpty is true.
    /// </summary>
    public static string? GetFirstStringByTag(this RPG_Base @base, string tagName, bool nullIfEmpty = false)
    {
        // grab the note data to scan.
        var tags = @base.NoteDataByTagName(tagName);
        
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

    /// <summary>
    /// Gets all found strings matching the provided tag name on this database object.
    /// If no matching tag is found, an empty list will be returned, or null if nullIfEmpty is true.
    ///
    /// It is important to note that this method does not concat any of the strings together, only adds them
    /// to running list of strings for whatever purposes they may serve in this format.
    /// </summary>
    public static List<string>? GetAllStringsByTag(this RPG_Base @base, string tagName, bool nullIfEmpty = false)
    {
        // grab the note data to scan.
        var tags = @base.NoteDataByTagName(tagName);
        
        // check if we had any tags on this entry.
        if (!tags.Any())
        {
            // return null or empty based on parameters.
            return nullIfEmpty
                ? null
                : [];
        }
        
        // iterate over each of the tags.
        var strings = tags.Aggregate(
            new List<string>(),
            (runningList, tag) =>
            {
                // translate the string array of numbers into a list of strings.
                var valueStrings = tag.Value.ToStringList();

                // add the values to the list.
                runningList.AddRange(valueStrings);
                
                // return the running collection.
                return runningList;
            });

        // return what we found.
        return strings;
    }

    /// <summary>
    /// Gets all found strings matching the provided tag name on this database object.
    /// If no matching tag is found, an empty list will be returned, or null if nullIfEmpty is true.
    ///
    /// It is important to note that this method will group each tag's values together, not build them into
    /// one long running list.
    /// </summary>
    public static List<List<string>>? GetAllStringsGroupedByTag(
        this RPG_Base @base,
        string tagName,
        string delimiter = ",",
        bool nullIfEmpty = false)
    {
        // grab the note data to scan.
        var tags = @base.NoteDataByTagName(tagName);
        
        // check if we had any tags on this entry.
        if (!tags.Any())
        {
            // return null or empty based on parameters.
            return nullIfEmpty
                ? null
                : [];
        }

        // iterate over each of the tags.
        var tagValuesGrouped = tags
            // map each one to a list of strings based on the delimiter.
            .Select(tag => tag.Value.ToStringList(delimiter).ToList())
            .ToList();
        
        // return what we found.
        return tagValuesGrouped;
    }
}