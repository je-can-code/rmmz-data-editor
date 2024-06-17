using JMZ.Dashboard.Boards;
using JMZ.Dashboard.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JMZ.Dashboard;

// ReSharper disable once UnusedType.Global
// ReSharper disable once ArrangeTypeModifiers
internal static class Program
{
    private static IHost? CurrentHost { get; set; }

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    internal static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();

        CurrentHost = Host
            .CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddOptions<JmzOptions>()
                    .Bind(context.Configuration)
                    .ValidateOnStart();

                services.AddScoped<BaseBoard>();
            })
            .Build();
        
        using var serviceScope = CurrentHost.Services.CreateScope();
        var mainForm = serviceScope.ServiceProvider.GetRequiredService<BaseBoard>();
        Application.Run(mainForm);
    }
}