using Application.Commands.Common.Helpers;
using Application.Commands.Common.Models;
using Application.Commands.Contracts.Common;
using Microsoft.Extensions.Configuration;

namespace Application.Commands;

public static class ApplicationCommandsServiceRegistration
{
    public static void AddApplicationCommandServices(this IServiceCollection servicesCollection, IConfiguration configuration)
    {
        servicesCollection.AddOptions();
        servicesCollection.Configure<LanguagFilePath>(configuration.GetSection(nameof(LanguagFilePath)));

        servicesCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        servicesCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        servicesCollection.AddMediatR(Assembly.GetExecutingAssembly());

        servicesCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        servicesCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

        servicesCollection.AddTransient<IHtmlHelper, HtmlHelper>();
        servicesCollection.AddSingleton<IAuditLogHelper, AuditLogHelper>();
        servicesCollection.AddTransient(typeof(IJsonSerializeHelper<>), typeof(JsonSerializeHelper<>));
        servicesCollection.AddTransient<IXMLSerializeHelper, XMLSerializeHelper>();
    }
}