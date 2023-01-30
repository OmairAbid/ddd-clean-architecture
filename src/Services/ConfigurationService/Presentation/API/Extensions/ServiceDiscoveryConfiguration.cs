using Consul;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;

namespace API.Extensions;

public static class ServiceDiscoveryConfiguration
{
    public static IServiceCollection AddConsulConfig(this IServiceCollection services, IConfiguration configuration)
    {
        //if (services == null)
        //{
        //    throw new ArgumentNullException(nameof(services));
        //}

        //var serviceConfig = new ServiceConfig
        //{
        //    Id = configuration.GetValue<string>("ConsulConfig:ServiceId"),
        //    Name = configuration.GetValue<string>("ConsulConfig:ServiceName"),
        //    Address = configuration.GetValue<string>("ConsulConfig:ServiceAddress"),
        //    Port = configuration.GetValue<int>("ConsulConfig:Port"),
        //    DiscoveryAddress = configuration.GetValue<Uri>("ConsulConfig:DiscoveryAddress"),
        //    HealthCheckEndPoint = configuration.GetValue<string>("ConsulConfig:HealthCheckEndPoint"),
        //};

        //var consulClient = new ConsulClient(config =>
        //{
        //    config.Address = serviceConfig.DiscoveryAddress;
        //});

        //services.AddSingleton(serviceConfig);
        //services.AddSingleton<IConsulClient, ConsulClient>(_ => consulClient);
        ////services.AddSingleton<ServiceConfig>();
        //services.AddSingleton<IHostedService, ServiceDiscoveryHostedService>();

        services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
        {
            var address = configuration.GetValue<string>("ConsulConfig:DiscoveryAddress");
            consulConfig.Address = new Uri(address);
        }));

        return services;
    }

    public static IApplicationBuilder UseConsul(this IApplicationBuilder app, IConfiguration configuration)
    {
        var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
        var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("AppExtensions");
        var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

        if (!(app.Properties["server.Features"] is FeatureCollection features))
        {
            return app;
        }

        var serviceName = configuration.GetValue<string>("ConsulConfig:ServiceName");
        var serviceId = configuration.GetValue<string>("ConsulConfig:ServiceId");
        var address = configuration.GetValue<string>("ConsulConfig:ServiceAddress");
        var port = configuration.GetValue<string>("ConsulConfig:Port");
        //var uri = new Uri(address);

        var registration = new AgentServiceRegistration()
        {
            ID = serviceId,
            Name = serviceName,
            Address = $"{address}",
            Port = int.Parse(port)
        };

        logger.LogInformation("Registering with Consul");
        consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
        consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

        lifetime.ApplicationStopping.Register(() =>
        {
            logger.LogInformation("Unregistering from Consul");
            consulClient.Agent.ServiceDeregister(registration.ID).Wait();
        });

        return app;
    }
}

public sealed class ServiceConfig
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public int Port { get; set; }

    public Uri DiscoveryAddress { get; set; }

    public string HealthCheckEndPoint { get; set; }
}

public class ServiceDiscoveryHostedService : IHostedService
{
    private readonly IConsulClient _client;
    private readonly ServiceConfig _config;
    private AgentServiceRegistration _registration;

    public ServiceDiscoveryHostedService(IConsulClient client, ServiceConfig config)
    {
        _client = client;
        _config = config;
    }

    // Registers service to Consul registry
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _registration = new AgentServiceRegistration
        {
            ID = _config.Id,
            Name = _config.Name,
            Address = _config.Address,
            Port = _config.Port,
            //Check = new AgentServiceCheck()
            //{
            //    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
            //    Interval = TimeSpan.FromSeconds(15),
            //    HTTP = $"http://{_config.Address}:{_config.Port}/{_config.HealthCheckEndPoint}",
            //    Timeout = TimeSpan.FromSeconds(30)
            //}
        };

        // Deregister already registered service
        await _client.Agent.ServiceDeregister(_registration.ID, cancellationToken).ConfigureAwait(false);

        // Registers service
        await _client.Agent.ServiceRegister(_registration, cancellationToken).ConfigureAwait(false);
    }

    // If the service is shutting down it deregisters service from Consul registry
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Stop");
        await _client.Agent.ServiceDeregister(_registration.ID, cancellationToken).ConfigureAwait(false);
    }
}
