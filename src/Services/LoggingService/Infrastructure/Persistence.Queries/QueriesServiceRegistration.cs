using Application.Queries.Contracts.Repositories.Queries;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Queries.ORM;
using Persistence.Queries.Repositories;

namespace Persistence.Queries;

public static class QueriesServiceRegistration
{
    #region Public Methods

    public static IServiceCollection AddPersistentQueryServices(this IServiceCollection services)
    {
        services.AddTransient<DapperContext>();
        services.AddTransient<IAdministratorLogQueryRepository, AdministratorLogQueryRepository>();
        return services;
    }

    #endregion Public Methods
}