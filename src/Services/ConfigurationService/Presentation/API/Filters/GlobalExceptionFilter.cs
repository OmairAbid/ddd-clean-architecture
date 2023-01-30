using API.Model;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Xml;
using IExceptionFilter = Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter;

namespace API.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    private readonly IWebHostEnvironment env;
    private readonly ILogger<GlobalExceptionFilter> logger;

    public GlobalExceptionFilter(IWebHostEnvironment env, ILogger<GlobalExceptionFilter> logger)
    {
        this.env = env;
        this.logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        logger.LogError(new EventId(context.Exception.HResult),
            context.Exception,
            context.Exception.Message);

        if (context.Exception.GetType().Name == nameof(Application.Commands.Common.Exceptions.BuisnessException))
        {
            FailureResponse response = new();
            var exception = (Application.Commands.Common.Exceptions.BuisnessException)context.Exception;
            response.Success = false;
            response.Message = exception.Message;
            context.Result = new BadRequestObjectResult(response);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            if (env.IsDevelopment())
            {
                response.Exception = exception?.Demystify().ToString();

            }
            context.Result = new BadRequestObjectResult(response);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else if (context.Exception.GetType().Name == nameof(Application.Commands.Common.Exceptions.ValidationException))
        {
            FailureResponse response = new();
            Application.Commands.Common.Exceptions.ValidationException exception = (Application.Commands.Common.Exceptions.ValidationException)context.Exception;
            var errors = exception.ValidationFailures.Select(x => new Error
            {
                ErrorMessage = x.Value,
                PropertyName = x.Key
            }).ToList();
            response.Errors = errors;
            response.Success = false;
            response.Message = "Request validation failed.";

            if (env.IsDevelopment())
            {
                response.Exception = exception?.Demystify().ToString();

            }
            context.Result = new BadRequestObjectResult(response);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else if (context.Exception.GetType().Name == nameof(Application.Commands.Common.Exceptions.BadRequestException))
        {
            FailureResponse response = new();
            var exception = (Application.Commands.Common.Exceptions.BadRequestException)context.Exception;
            response.Success = false;
            response.Message = exception.Message;
            context.Result = new BadRequestObjectResult(response);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            if (env.IsDevelopment())
            {
                response.Exception = exception?.Demystify().ToString();

            }
            context.Result = new BadRequestObjectResult(response);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else
        {
            FailureResponse response = new();
            var exception = context.Exception;
            response.Success = false;
            response.Message = ResponseMessages.SERVER_ERROR;

            if (env.IsDevelopment())
            {
                response.Exception = exception?.Demystify().ToString();

            }
            context.Result = new InternalServerErrorObjectResult(response);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
        context.ExceptionHandled = true;
    }

}





