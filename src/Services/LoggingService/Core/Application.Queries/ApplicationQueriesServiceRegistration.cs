namespace Application.Queries;

public static class ApplicationQueriesServiceRegistration
{
    public static void AddApplicationQueryServices(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        servicesCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        servicesCollection.AddMediatR(Assembly.GetExecutingAssembly());

        servicesCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        servicesCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
    }
}