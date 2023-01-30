using API.Middlewares;
using API.Model;

using Application.Commands;
using Application.Queries;

using Persistence.Queries;

namespace API;

public static class RegisterApplicationDependencies
{
	#region Public Methods

	public static void AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
	{
		AddStartupDependecies(services);
        AddApplicationServices(services);
		AddInfrastructureServices(services, configuration);

		
	}

    #endregion Public Methods

    #region Private Methods

    private static void AddStartupDependecies(IServiceCollection services)
    {
        services.AddScoped(typeof(LoggedInUser));
        services.AddTransient<UnHandleExceptionMiddleware>();
    }

    private static void AddApplicationServices(IServiceCollection services)
	{
		services.AddApplicationQueryServices();
		services.AddApplicationCommandServices();
	}

	private static void AddInfrastructureServices(IServiceCollection services, IConfiguration configuration)
	{
		string connectiongString = configuration.GetConnectionString("DBConnectiongString");
		string DbSource = configuration.GetConnectionString("DBProvider");
		services.AddPersistentCommandServices(connectiongString, DbSource);
		services.AddPersistentQueryServices(connectiongString, DbSource);
	}

	#endregion Private Methods
}