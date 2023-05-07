using Microsoft.Extensions.Logging;

namespace Dashboard.Services;

public static class LogService
{
    private static ILogger? _logger;

    static LogService()
    {
        setupLogging();
    }
    
    public static void log(string message)
    {
        _logger?.LogInformation(message);
    }

    private static void setupLogging()
    {
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddDebug());
        _logger = loggerFactory.CreateLogger(string.Empty);
        
        log("logging setup complete.");
    }
}