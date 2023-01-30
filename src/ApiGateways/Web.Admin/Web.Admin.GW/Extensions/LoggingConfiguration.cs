

using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Configuration;
using Serilog.Enrichers.Span;
using Serilog.Exceptions;

namespace Web.Admin.GW.Extensions;

public static class LoggingConfiguration
{
    public static IHostBuilder AddLogging(this IHostBuilder hostBuilder,IConfiguration configuration)
    {
        return hostBuilder.UseSerilog((context, services, configurations) => configurations
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .Enrich.FromLogContext()
            .Enrich.WithSpan()
            .Enrich.WithEnvironmentName()
            .Enrich.WithExceptionDetails()
            .WriteTo.Seq(configuration.GetValue<string>("Serilog:SeqHost")));
    }

    public static IServiceCollection AddCustomHttpLogging(this IServiceCollection services)
    {
        services.AddHttpLogging(logging =>
        {
            logging.LoggingFields = HttpLoggingFields.All;
        });
        return services;
    }

    public static void UseRequestLogging(this IApplicationBuilder app)
    {
        app.UseSerilogRequestLogging();
    }
}
