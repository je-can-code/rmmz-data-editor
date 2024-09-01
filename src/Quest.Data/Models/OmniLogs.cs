namespace JMZ.Quest.Data.Models;

/// <summary>
/// A capture of the various logs associated with an objective throughout its state lifetime.
/// </summary>
public record OmniLogs
{
    public string Inactive { get; set; } = string.Empty;
    
    public string Active { get; set; } = string.Empty;
    public string Completed { get; set; } = string.Empty;
    public string Failed { get; set; } = string.Empty;
    public string Missed { get; set; } = string.Empty;

    public OmniLogs()
    {
        Inactive = string.Empty;
        Active = string.Empty;
        Completed = string.Empty;
        Failed = string.Empty;
        Missed = string.Empty;
    }

    public OmniLogs(string inactive, string active, string completed, string failed, string missed)
    {
        Inactive = inactive;
        Active = active;
        Completed = completed;
        Failed = failed;
        Missed = missed;
    }
}