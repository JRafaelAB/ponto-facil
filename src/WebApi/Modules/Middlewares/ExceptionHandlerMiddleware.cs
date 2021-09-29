using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using Domain.Resources;

namespace WebApi.Modules.Middlewares
{
    public static class ExceptionHandlerMiddleware
    {
        public static async Task ExceptionHandler(HttpContext context, ILogger logger)
        {
            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

            if (contextFeature != null)
            {
                switch (contextFeature.Error)
                {
                    default:
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        context.Response.ContentType = MediaTypeNames.Application.Json;
                        logger.Error($"Unexpected Error: {contextFeature.Error}");
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(Messages.GenericError + $" | traceId: {context.TraceIdentifier}"));
                        break;
                }
            }
        }
    }
}
