using Microsoft.AspNetCore.Mvc.Versioning;

namespace API.Extensions;

public static class ApiVersionConfiguration
{
    public static void AddVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(o =>
        {
            o.AssumeDefaultVersionWhenUnspecified = true;
            o.DefaultApiVersion = new ApiVersion(1, 0);
            o.ReportApiVersions = true;
            o.ApiVersionReader = new HeaderApiVersionReader("X-Version");
        });

        services.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
        });

    }
}