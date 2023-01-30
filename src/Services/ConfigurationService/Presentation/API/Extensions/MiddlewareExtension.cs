using API.Middlewares;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using static Application.Commands.Common.Constants.Constants;

namespace API.Extensions;

public static class MiddlewareExtension
{
    public static IApplicationBuilder UseClaimsAuthorizationMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ClaimsAuthorizationMiddleware>();
    }

    public static void UseExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<UnHandleExceptionMiddleware>();
    }

    public static void UseSwaggerUIMiddleware(this IApplicationBuilder app, IConfiguration configuration)
    {
        var apiVersionDescriptionProvider = app.ApplicationServices.GetService<IApiVersionDescriptionProvider>();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.RoutePrefix = configuration.GetValue<string>("ApiSettings:SwaggerUrl");
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    $"API - {description.GroupName.ToUpper()}");
            }
        });
    }

    public static void UseEndpointsMiddleware(this IApplicationBuilder app)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            endpoints.MapHealthChecks("/liveness", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self")
            });
        });
    }
}