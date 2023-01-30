
using Application.Queries.Common.Enumerations;
using Application.Queries.Contracts.Common;

namespace Application.Queries;
public static class ApplicationQueriesServiceRegistration
{
    public static void AddApplicationQueryServices(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        servicesCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        servicesCollection.AddMediatR(Assembly.GetExecutingAssembly());

        //servicesCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        //servicesCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

        servicesCollection.AddSingleton<IEnumerationHelper, StringEnumerationHelper>();
    }
}
