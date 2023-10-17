using Serilog;

namespace Site.Shared.Logging;

public static class SiteLoggerManager
{
    public static LoggerConfiguration CreateConfiguration()
    {
        var configuration = new LoggerConfiguration()
            .WriteTo.Debug()
            .WriteTo.Console();

        return configuration;
    }

    public static ILogger CreateLoggerByConf(LoggerConfiguration configuration)
    {
        var logger = configuration.CreateLogger();

        return logger;
    }
}