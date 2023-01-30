namespace Application.Commands;

public static class ApplicationCommandsServiceRegistration
{
    #region Public Methods

    public static void AddApplicationCommandServices(this IServiceCollection servicesCollection)
    {

        servicesCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        servicesCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        servicesCollection.AddMediatR(Assembly.GetExecutingAssembly());

        servicesCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        servicesCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        servicesCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

        servicesCollection.AddSingleton<IHtmlHelper, HtmlHelper>();
        servicesCollection.AddSingleton<IEmailHelper, EmailHelper>();
        servicesCollection.AddSingleton<IDateTimeHelper, DateTimeHelper>();

        servicesCollection.AddTransient(typeof(IJsonSerializeHelper<>), typeof(JsonSerializeHelper<>));
        servicesCollection.AddTransient(typeof(IJsonSerializeHelper<>), typeof(JsonSerializeHelper<>));
        servicesCollection.AddTransient<IXMLSerializeHelper, XMLSerializeHelper>();
        servicesCollection.AddSingleton<IAuditLogHelper, AuditLogHelper>();
    }

    #endregion Public Methods
}