using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data.Common;

namespace Web.Admin.GW.Extensions;

public static class HealthCheckConfiguration
{
    public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
    {
        var hcBuilder = services.AddHealthChecks();

        hcBuilder.AddCheck("Web-Admin-Gateway-Check", () => HealthCheckResult.Healthy(), new string[] { "web.admin.gateway" });
        
        return services;
    }

}
