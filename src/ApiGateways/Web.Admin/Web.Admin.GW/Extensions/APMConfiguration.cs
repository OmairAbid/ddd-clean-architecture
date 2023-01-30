using System.Reflection.PortableExecutable;
using System.Reflection;
using OpenTelemetry.Resources;
using OpenTelemetry;
using OpenTelemetry.Trace;
using OpenTelemetry.Instrumentation.AspNetCore;
using OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using Microsoft.Extensions.Options;

namespace Web.Admin.GW.Extensions;

public static class APMConfiguration
{
    public static IServiceCollection AddAPM(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment hostEnvironment)
    {
        var tracingExporter = configuration.GetValue<string>("UseTracingExporter").ToLowerInvariant();
        var serviceVersion = configuration.GetValue<string>("Logging:OpenTelemetry:ApplicationVersion").ToString();

        Action<ResourceBuilder> configureResource = r => r.AddService(
    serviceName: hostEnvironment.ApplicationName,
    serviceVersion: serviceVersion,
    serviceInstanceId: Environment.MachineName);

        services.AddOpenTelemetry()
            .ConfigureResource(configureResource)
                .WithTracing(builder =>
                {
                    builder
                     .AddHttpClientInstrumentation(instrumentationOptions =>
                     {
                         instrumentationOptions.RecordException = true;
                     })
                     .AddAspNetCoreInstrumentation(instrumentationOptions =>
                     {
                         instrumentationOptions.RecordException = true;
                     });



                    switch (tracingExporter)
                    {
                        case "jaeger":
                            builder.AddJaegerExporter();

                            builder.ConfigureServices(services =>
                            {
                                // Use IConfiguration binding for Jaeger exporter options.
                                services.Configure<JaegerExporterOptions>(configuration.GetSection("Jaeger"));

                                // Customize the HttpClient that will be used when JaegerExporter is configured for HTTP transport.
                                services.AddHttpClient("JaegerExporter", configureClient: (client) => client.DefaultRequestHeaders.Add("X-MyCustomHeader", "value"));
                            });
                            break;

                        default:
                            builder.AddConsoleExporter();
                            break;
                    }
                })
    .StartWithHost();


        return services;
    }
}
