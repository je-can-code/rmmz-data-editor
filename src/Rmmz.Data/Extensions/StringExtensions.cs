namespace JMZ.Rmmz.Data.Extensions;

/// <summary>
/// Extensions for strings used by this project.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Unwraps the contents of a string that is wrapped in hard brackets.
    /// </summary>
    /// <param name="data">The string potentially wrapped in hard brackets.</param>
    /// <returns>The string no longer wrapped in hard brackets.</returns>
    public static string UnwrapBrackets(this string data)
    {
        // check if there are hard brackets wrapping the inner data.
        if (data.StartsWith("[") && data.EndsWith("]"))
        {
            // peel off the outer brackets and return the innards.
            return data.Substring(1, data.Length - 2);
        }

        // there are no brackets, just return the string.
        return data;
    }

    /// <summary>
    /// Converts a string that is expected to be a delimited list of numbers,
    /// into a list of decimals.
    /// </summary>
    /// <param name="input">The string to be converted.</param>
    /// <param name="delimiter">The delimiter character(s); defaults to a single comma.</param>
    /// <returns>A conversion of the string into a list of decimals.</returns>
    public static IEnumerable<decimal> ToDecimalList(this string input, string delimiter = ",")
    {
        return input
            .ToStringList(delimiter)
            .Select(decimal.Parse);
    }

    /// <summary>
    /// Converts a string that is expected to be a delimited list of strings,
    /// into a list of strings.
    /// </summary>
    /// <param name="input">The string to be converted.</param>
    /// <param name="delimiter">The delimiter character(s); defaults to a single comma.</param>
    /// <returns>A conversion of the string into a list of decimals.</returns>
    public static IEnumerable<string> ToStringList(this string input, string delimiter = ",")
    {
        // check if the input is invalid.
        if (input == null)
        {
            // return an empty list.
            return Enumerable.Empty<string>();
        }

        // unwrap the input from its hard brackets.
        var unwrappedInput = input.UnwrapBrackets();
        
        // check if the input has the delimiter, meaning its a list.
        if (unwrappedInput.Contains(delimiter))
        {
            // split the string into a list of strings.
            return unwrappedInput
                .Split(delimiter)
                .ToList();
        }
        
        // the input was a single string in a container.
        return new List<string> { unwrappedInput };
    }
}