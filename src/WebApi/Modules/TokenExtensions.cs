using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi.Modules
{
    public static class TokenExtensions
    {
        public static IServiceCollection AddTokenConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddSingleton<ITokenService, TokenService>();
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("JWT:Secret").Value);

            service.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = configuration.GetSection("JWT:Issuer").Value,
                    ValidateAudience = true,
                    ValidAudience = configuration.GetSection("JWT.Audience").Value,
                    ValidateLifetime = true
                };
            });
            return service;
        }

        public static void UseTokenConfiguration(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}