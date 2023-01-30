using API.Model;
using Application.Commands.Common.Exceptions;
using Application.Commands.Common.Models;

using Newtonsoft.Json;
using System.Diagnostics;

namespace API.Middlewares;

public class UnHandleExceptionMiddleware : IMiddleware
{
    #region Private Fields

    private readonly IWebHostEnvironment _env;
    private readonly ILogger<UnHandleExceptionMiddleware> _logger;

    #endregion Private Fields

    #region Public Constructors

    public UnHandleExceptionMiddleware(ILogger<UnHandleExceptionMiddleware> logger, IWebHostEnvironment env)
    {
        _logger = logger;
        _env = env;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await UnHandleExceptionAsync(context, e, _logger, _env);
        }
    }

    #endregion Public Methods

    #region Private Methods

    private static Task UnHandleExceptionAsync(HttpContext context, Exception ex, ILogger<UnHandleExceptionMiddleware> logger, IWebHostEnvironment env)
    {
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
        context.Request.ContentType = "appication/json";
        string result = string.Empty;

        context.Response.StatusCode = (int)httpStatusCode;
        if (string.IsNullOrEmpty(result))
        {
            if (env.IsDevelopment())
            {
                result = JsonConvert.SerializeObject(new { success = false, message = ex.Message, InnerExcpetion = ex.InnerException.Demystify() });
            }
            else
            {
                result = JsonConvert.SerializeObject(new { success = false, message = ResponseMessages.SERVER_UNKNOWN });
            }
        }

        return context.Response.WriteAsync(result);
    }

    #endregion Private Methods
}