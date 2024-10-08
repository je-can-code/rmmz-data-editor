namespace JMZ.Rmmz.Data.Tags;

/// <summary>
///     An implementation class including constructors for building conventionalized tag data.
/// </summary>
public class Tag : AbstractTag
{
    /// <summary>
    ///     Builds a tag with this tag's name as the boolean value.
    /// </summary>
    /// <returns>The output that will show up in the RMMZ note field.</returns>
    public string ToBooleanTag()
    {
        return $"<{Name}>";
    }

    /// <summary>
    ///     Builds a tag with this tag's name and the given value.
    /// </summary>
    /// <param name="parameter">The parameter to fill the value with.</param>
    /// <returns>The output that will show up in the RMMZ note field.</returns>
    public string ToValueTag(string parameter)
    {
        return $"<{Name}:{parameter}>";
    }

    /// <summary>
    ///     Builds a tag with this tag's name and the given values as an array of values.
    /// </summary>
    /// <param name="parameters">The 1+ parameters to fill the array with.</param>
    /// <returns>The output that will show up in the RMMZ note field.</returns>
    public string ToArrayTag(params string[] parameters)
    {
        return $"<{Name}:[{string.Join(',', parameters)}]>";
    }

    #region constructors
    /// <summary>
    ///     Constructor for boolean tags.
    /// </summary>
    /// <param name="name">The name of this tag as a string.</param>
    public Tag(string name) : base(name)
    {
    }

    /// <summary>
    ///     Constructor for tags that use a regex to capture their value(s).
    /// </summary>
    /// <param name="name">The name of this tag as a string.</param>
    /// <param name="regex">The regex of this tag.</param>
    public Tag(string name, string regex) : base(name, regex)
    {
    }

    /// <summary>
    ///     Constructor for tags that use a regex to capture their value(s), but with a description.
    /// </summary>
    /// <param name="name">The name of this tag as a string.</param>
    /// <param name="regex">The regex of this tag.</param>
    /// <param name="description">The description of this tag.</param>
    public Tag(string name, string regex, string description) : base(name, regex, description)
    {
    }

    /// <summary>
    ///     Constructor for tags that use a regex to capture their value(s), but with multiple descriptions
    /// </summary>
    /// <param name="name">The name of this tag as a string.</param>
    /// <param name="regex">The regex of this tag.</param>
    /// <param name="descriptions">The multi-tag description collection for this tag.</param>
    public Tag(string name, string regex, params string[] descriptions) : base(name, regex, descriptions)
    {
    }
    #endregion constructors
}