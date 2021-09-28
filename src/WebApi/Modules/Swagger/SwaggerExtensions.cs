﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Modules.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            return services;
        }

        public static void ConfigureSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                foreach (ApiVersionDescription description in provider.ApiVersionDescriptions)
                {
                    option.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", 
                        description.GroupName.ToUpperInvariant());
                }
            });
        }
        
    }
}
