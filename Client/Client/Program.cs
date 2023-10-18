using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Serilog;
using Site.Client.Infrastructure;
using Site.Shared.Logging;

namespace Site.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        Log.Logger = SiteLoggerManager.CreateConfiguration().CreateLogger();

        try
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            /* this is used instead of .UseSerilog to add Serilog to providers */
            builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

            builder.Services.AddScoped(sp => new HttpClient
                { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.Configure<SiteApiOptions>(options =>
            {
                options.BaseUrl = builder.HostEnvironment.BaseAddress;
            });

            builder.Services.AddScoped<SiteApiClient>();

            await builder.Build().RunAsync();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}