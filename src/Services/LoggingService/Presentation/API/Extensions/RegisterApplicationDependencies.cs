//using Application.Commands;
using API.Middlewares;
using API.Model;
using Application.Commands;
using Application.Queries;
using Persistence.Queries;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace API.Extensions;

public static class RegisterApplicationDependencies
{
    #region Public Methods

    public static void AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        AddStartupDependecies(services);
        AddApplicationServices(services, configuration);
        AddInfrastructureServices(services, configuration);
    }

    #endregion Public Methods

    #region Private Methods

    private static void AddApplicationServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationQueryServices();
        services.AddApplicationCommandServices(configuration);
    }

    private static void AddInfrastructureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistentCommandServices(configuration);
        services.AddPersistentQueryServices();
        services.AddInfrastructureServices(configuration);
    }

    private static void AddStartupDependecies(IServiceCollection services)
    {
        services.AddScoped(typeof(LoggedInUser));
        services.AddTransient<ExceptionMiddleware>();
    }

    #endregion Private Methods
}