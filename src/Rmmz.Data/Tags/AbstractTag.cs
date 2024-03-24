namespace JMZ.Rmmz.Data.Tags;

/// <summary>
/// An abstract class representing the various data points that make up structure for tag data.
/// </summary>
public abstract class AbstractTag
{
    private const string NO_DESCRIPTION = "A description for this tag has yet to be defined.";

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="name">The name of this tag as a string.</param>
    protected AbstractTag(string name)
    {
        // assign the name.
        this.Name = name;
        
        // default to a boolean tag.
        this.Regex = $"<{name}>";

        // default to generic description.
        this.Description = "A description for this tag has yet to be defined.";
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="name">The name of this tag as a string.</param>
    /// <param name="regex">The regex of this tag.</param>
    protected AbstractTag(string name, string regex)
    {
        // assign the name.
        this.Name = name;
        
        // update the regex as given.
        this.Regex = regex;
        
        // default to generic description.
        this.Description = NO_DESCRIPTION;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="name">The name of this tag as a string.</param>
    /// <param name="regex">The regex of this tag.</param>
    /// <param name="description">The description of this tag.</param>
    protected AbstractTag(string name, string regex, string description)
    {
        // assign the name.
        this.Name = name;
        
        // update the regex as given.
        this.Regex = regex;
        
        // define the literal description.
        this.Description = description;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="name">The name of this tag as a string.</param>
    /// <param name="regex">The regex of this tag.</param>
    /// <param name="descriptions">The multi-tag description collection for this tag.</param>
    protected AbstractTag(string name, string regex, params string[] descriptions)
    {
        // assign the name.
        this.Name = name;
        
        // update the regex as given.
        this.Regex = regex;
        
        // define the literal description.
        this.Description = descriptions.FirstOrDefault() ?? NO_DESCRIPTION;

        // define a multi-tag description, such as combo data or pose data.
        this.Descriptions = descriptions;
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
    /// A singular description for the tooltips to define what the function of this tag is.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// A multi-description for when a single regex maps to multiple fields on the UI.
    /// </summary>
    public string[] Descriptions { get; } = [];
}