namespace Dashboard.Models.Tags;

/// <summary>
/// The common class for the enumeration of various tag names across the system.
/// </summary>
internal abstract class AbstractRmmzTags
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="name">The name of this tag as a string.</param>
    protected AbstractRmmzTags(string name)
    {
        // assign the name.
        this.Name = name;
        
        // default to a boolean tag.
        this.Regex = $"<{name}>";
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="name">The name of this tag as a string.</param>
    /// <param name="regex">The regex of this tag.</param>
    protected AbstractRmmzTags(string name, string regex)
    {
        // assign the name.
        this.Name = name;
        
        // update the regex as given.
        this.Regex = regex;
    }

    /// <summary>
    /// The tag name itself as a string.
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// The regex that matches this tag.
    /// </summary>
    public string Regex { get; }

    /// <summary>
    /// Builds a tag with this tag's name as the boolean value.
    /// </summary>
    /// <returns>The output that will show up in the RMMZ note field.</returns>
    internal string ToBooleanTag()
    {
        return $"<{this.Name}>";
    }

    /// <summary>
    /// Builds a tag with this tag's name and the given value.
    /// </summary>
    /// <param name="parameter">The parameter to fill the value with.</param>
    /// <returns>The output that will show up in the RMMZ note field.</returns>
    internal string ToValueTag(string parameter)
    {
        return $"<{this.Name}:{parameter}>";
    }

    /// <summary>
    /// Builds a tag with this tag's name and the given values as an array of values.
    /// </summary>
    /// <param name="parameters">The 1+ parameters to fill the array with.</param>
    /// <returns>The output that will show up in the RMMZ note field.</returns>
    internal string ToArrayTag(params string[] parameters)
    {
        return $"<{this.Name}:[{string.Join(',', parameters)}]>";
    }
}