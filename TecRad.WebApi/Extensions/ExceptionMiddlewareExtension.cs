using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using TecRad.Models.Exceptions;
using TecRad.Services.Interfaces;

namespace TecRad.WebApi.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error => 
            {
                error.Run(async context => 
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionHandlerFeature.Error;
                    var statusCode = (int) HttpStatusCode.InternalServerError;

                    var logService = app.ApplicationServices.GetService(typeof(ILogService)) as ILogService;
                    logService.LogToFile($"Message: {exception.Message}. Stack trace: {exception.StackTrace}");

                    if (exception is ResourceNotFoundException)
                    {
                        statusCode = (int) HttpStatusCode.NotFound;
                    }
                    else if (exception is ModelFormatException)
                    {
                        statusCode = (int) HttpStatusCode.PreconditionFailed;
                    }

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = statusCode;

                    await context.Response.WriteAsync(new ExceptionModel
                    {
                        StatusCode = statusCode,
                        Message = exception.Message
                    }.ToString());
                });
            });
        }
    }
}