using System.Runtime.CompilerServices;

namespace Dashboard.Extensions;

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
    public static List<decimal> toDecimalList(this string input, string delimiter = ",")
    {
        // check if the input is 
        if (input == null)
        {
            // return an empty list.
            return new();
        }

        // unwrap the input from its hard brackets.
        var unwrappedInput = input.UnwrapBrackets();

        // check if the input has the delimiter, meaning its a list.
        if (unwrappedInput.Contains(delimiter))
        {
            // split the string into a list of numbers.
            return unwrappedInput
                .Split(delimiter)
                .Select(decimal.Parse)
                .ToList();
        }
        
        // the input was a single number in a container.
        return new() { decimal.Parse(unwrappedInput) };
    }
}