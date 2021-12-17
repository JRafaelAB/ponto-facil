using System.Net.Mime;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.Resources;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;

namespace WebApi.Modules.Middlewares
{
    internal static class ExceptionHandlerMiddleware
    {
        public static async Task ExceptionHandler(HttpContext context, ILogger logger)
        {
            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

            switch (contextFeature.Error)
            {
                case InvalidRequestException invalidRequest:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    logger.Error($"Invalid Request: {JsonConvert.SerializeObject(invalidRequest.notificationError)}");
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(invalidRequest.notificationError));
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    logger.Error($"Unexpected Error: {contextFeature.Error}");
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(Messages.InternalServerError + $" | traceId: {context.TraceIdentifier}"));
                    break;
            }
        }
    }
}