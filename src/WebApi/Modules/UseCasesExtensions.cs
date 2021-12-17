using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.PostUser;

namespace WebApi.Modules
{
    public static class UseCasesExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IPostUserUseCase, PostUserUseCase>();
            services.Decorate<IPostUserUseCase, PostUserValidation>();
            return services;
        }
    }
}