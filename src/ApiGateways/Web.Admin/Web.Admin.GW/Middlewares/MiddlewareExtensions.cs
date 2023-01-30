using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Web.Admin.GW.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UnhandledExceptionMiddleware>();
        }

        public static IApplicationBuilder UseReponseHeadersMiddleware(this IApplicationBuilder builder, List<KeyValuePair<string, string>> headersToAdd)
        {
            return builder.UseMiddleware<ResponseHeadersMiddleware>(headersToAdd);
        }

        public static IApplicationBuilder UseRemoveHeadersMiddleware(this IApplicationBuilder builder, params string[] headersToRemove)
        {
            return builder.UseMiddleware<RemoveHeadersMiddleware>(headersToRemove.ToList());
        }

        public static void UseEndpointsMiddleware(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/",
                    async context => { await context.Response.WriteAsync("Admin Gateway is running"); });
                
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
}