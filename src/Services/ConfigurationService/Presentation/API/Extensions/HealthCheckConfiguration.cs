using API.Filters;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data.Common;

namespace API.Extensions;

public static class HealthCheckConfiguration
{
    public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
    {
        var hcBuilder = services.AddHealthChecks();

        hcBuilder.AddCheck("API-check", () => HealthCheckResult.Healthy(), new string[] { "configurationAPI" });
        
        hcBuilder
            .AddCheck(
            "ConfigurationDB-check",
            new SqlConnectionHealthCheck(configuration["ConnectionStrings:DBConnectiongString"]),
            HealthStatus.Unhealthy,
            new string[] { "configurationdb" });

        if (configuration.GetValue<bool>("forAzureBusConfiguration"))
        {
            
        }
        else
        {
            var connStr = $"amqp://{configuration["RabbitMQ:UserName"]}:" +
                    $"{configuration["RabbitMQ:Password"]}@" +
                    $"{configuration["RabbitMQ:Host"]}" +
                    $"{configuration["RabbitMQ:VirtualHost"]}";
            hcBuilder
                .AddRabbitMQ(connStr,
                    name: "RabbitMQBus-check",
                    tags: new string[] { "rabbitmqbus" });
        }
        hcBuilder.AddSeqPublisher(options =>
        {
            options.Endpoint = "http://localhost:5342";
        });
        return services;
    }

}
