using Application.Commands.Contracts.Common;
using static Application.Commands.Common.Constants.Constants;

namespace Persistence.Commands;

public static class CommandsServiceRegistration
{
    public static IServiceCollection AddPersistentCommandServices(this IServiceCollection services, string connectionString, string dbSource)
    {
        AddDbContext(services, connectionString, dbSource);

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddTransient<ISystemSettingCommandRepository, SystemSettingCommandRepository>();
        services.AddTransient<IConnectorCommandRepository, ConnectorCommandRepository>();
        services.AddTransient<IConnectorDetailCommandRepository, ConnectorDetailCommandRepository>();
        services.AddTransient<IProfileCommandRepository, ProfileCommandRepository>();

        return services;
    }

    public static void AddDbContext(this IServiceCollection services, string connectionString, string dbSource)
    {
        services.AddDbContext<AppDBContext>(options =>
        {
            if (dbSource.ToUpper() == DbSource.SQL)
            {
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
                });
                //options.UseLazyLoadingProxies(true);
            }
            else if(dbSource.ToUpper() == DbSource.ORACLE)
            {
                options.UseOracle(connectionString);
            }
        });
    }
}