using API.Middlewares;

namespace API.Extensions;

public static class MiddlewareExtension
{
    #region Public Methods

    public static IApplicationBuilder UseClaimsAuthorizationMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ClaimsAuthorizationMiddleware>();
    }

    #endregion Public Methods
}