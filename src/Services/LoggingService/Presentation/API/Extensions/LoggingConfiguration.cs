using Serilog;

namespace API.Extensions;

public static class LoggingConfiguration
{
    #region Public Methods

    public static IHostBuilder AddLogging(this IHostBuilder hostBuilder)
    {
        return hostBuilder.UseSerilog((context, services, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services)
            .Enrich.FromLogContext()
            .WriteTo.Console());
    }

    public static void ConfigureRequestLogging(this IApplicationBuilder app)
    {
        app.UseSerilogRequestLogging();
    }

    #endregion Public Methods
}