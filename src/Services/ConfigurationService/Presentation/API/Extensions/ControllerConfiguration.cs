using API.Filters;

namespace API.Extensions;

public static class ControllerConfiguration
{
    public static IServiceCollection AddCustomController(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add(typeof(GlobalExceptionFilter));
        });

        return services;
    }
}
