using Application.Queries.Contracts.Common;
using Persistence.Queries.Repositories.ORACLE;
using Persistence.Queries.Repositories.SQL;

namespace Persistence.Queries;

public static class QueriesServiceRegistration
{
    public static void AddPersistentQueryServices(this IServiceCollection services, string connectiongString, string DbSource)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        if (DbSource.ToUpper() == "SQL")
        {
            services.AddTransient<IDbConnection>(x => new Sql(connectiongString));

            services.AddTransient<ISystemSettingQueryRepository, SystemSettingQueryRepository>();
            services.AddTransient<IConnectorQueryRepository, ConnectorQueryRepository>();
            services.AddTransient<IRoleQueryRepository, AdministratorRoleQueryRepository>();
            services.AddTransient<IProfileQueryRepository, ProfileQueryRepository>();
            services.AddTransient<IServicePlanQueryRepository, ServicePlanQueryRepository>();
            services.AddTransient<ICurrencyQueryRepository, CurrencyQueryRepository>();
        }
        else
        {
            services.AddTransient<IDbConnection>(x => new ORACLE(connectiongString));

            services.AddTransient<ISystemSettingQueryRepository, OraSystemSettingQueryRepository>();
            services.AddTransient<IConnectorQueryRepository, OraConnectorQueryRepository>();
            services.AddTransient<IRoleQueryRepository, OraAdministratorRoleQueryRepository>();
            services.AddTransient<IProfileQueryRepository, OraProfileQueryRepository>();
            services.AddTransient<IServicePlanQueryRepository, OraServicePlanQueryRepository>();
            services.AddTransient<ICurrencyQueryRepository, OraCurrencyQueryRepository>();
        }
    }
}