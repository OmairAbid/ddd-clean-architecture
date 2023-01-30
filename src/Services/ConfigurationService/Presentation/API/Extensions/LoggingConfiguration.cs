using Microsoft.AspNetCore.HttpLogging;
using Serilog;
using Serilog.Enrichers.Span;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;
using Serilog.Exceptions.Destructurers;
using Serilog.Exceptions.EntityFrameworkCore.Destructurers;

namespace API.Extensions;

public static class LoggingConfiguration
{
    public static IHostBuilder AddLogging(this IHostBuilder hostBuilder,IConfiguration configuration)
    {
        return hostBuilder.UseSerilog((context, services, configurations) => configurations
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithMachineName()
            .Enrich.WithCorrelationId()
            .Enrich.WithSpan()
            .Enrich.WithEnvironmentName()
            .WriteTo.Console()
            .WriteTo.Seq(configuration.GetValue<string>("Serilog:SeqHost"))
            );
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
