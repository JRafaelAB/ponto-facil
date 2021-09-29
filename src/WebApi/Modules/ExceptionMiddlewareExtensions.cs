using Microsoft.AspNetCore.Builder;
using Serilog;

namespace WebApi.Modules
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {

            });
        }
    }
}
