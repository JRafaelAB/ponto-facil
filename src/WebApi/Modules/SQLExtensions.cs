using Infrastructure.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Modules
{
    public static class SQLExtensions
    {
        public static IServiceCollection AddSQLServer(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetValue<string>("SQL_CONNECTION_STRING") ?? string.Empty;
            
            services.AddDbContext<ClockContext>(
                options =>
                {
                    options.UseSqlServer(connectionString, option => option.MigrationsAssembly("Infrastructure"));
                    options.EnableSensitiveDataLogging();
                });

            return services;
        }
        
    }
}
