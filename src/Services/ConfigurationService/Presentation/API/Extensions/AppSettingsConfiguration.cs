using API.Model;

namespace API.Extensions;

public static class AppSettingsConfiguration
{
    public static IServiceCollection AddAppSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions();
        services.Configure<DbSettings>(configuration.GetSection(nameof(DbSettings)));

        return services;
    }
}
