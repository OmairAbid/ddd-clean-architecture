using Application.Commands.Contracts.Common;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IFileHandler, FileHandler>();
        return services;
    }
}