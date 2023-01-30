using Application.Commands.Common.Exceptions;
using Application.Commands.Common.Models;

using Domain.Common;

using Newtonsoft.Json;

namespace API.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    #region Private Fields

    private readonly IWebHostEnvironment _env;
    private readonly ILogger<ExceptionMiddleware> _logger;

    #endregion Private Fields

    #region Public Constructors

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, IWebHostEnvironment env)
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
            await HandleExceptionAsync(context, e, _logger, _env);
        }
    }

    #endregion Public Methods

    #region Private Methods

    private static Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ExceptionMiddleware> logger, IWebHostEnvironment env)
    {
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
        context.Request.ContentType = "appication/json";
        string result = string.Empty;

        switch (ex)
        {
            case ValidationException validationException:
                httpStatusCode = HttpStatusCode.BadRequest;
                BasicResponse response = new();
                var errors = validationException.ValidationFailures.Select(x => new Error
                {
                    ErrorMessage = x.Value,
                    PropertyName = x.Key
                }).ToList();
                response.Errors = errors;
                response.Success = false;
                response.Message = "Request validation failed.";
                result = JsonConvert.SerializeObject(response);
                break;

            case BuisnessException buisnessException:
                httpStatusCode = HttpStatusCode.BadRequest;
                result = buisnessException.Message;
                break;

            case BadRequestException badRequestException:
                httpStatusCode = HttpStatusCode.BadRequest;
                result = badRequestException.Message;
                break;

            case Exception exception:
                httpStatusCode = HttpStatusCode.InternalServerError;
                break;

            default:
                break;
        }

        context.Response.StatusCode = (int)httpStatusCode;
        if (string.IsNullOrEmpty(result))
        {
            if (env.IsDevelopment())
            {
                result = JsonConvert.SerializeObject(new { error = ex.Message, InnerExcpetion = ex.InnerException });
            }
            else
            {
                result = JsonConvert.SerializeObject(new { error = Messages.SERVER_ERROR });
            }
        }

        return context.Response.WriteAsync(result);
    }

    #endregion Private Methods
}