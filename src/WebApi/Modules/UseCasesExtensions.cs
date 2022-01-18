using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.PostUser;
using Application.UseCases.LoginUser;

namespace WebApi.Modules
{
    public static class UseCasesExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IPostUserUseCase, PostUserUseCase>();
            services.Decorate<IPostUserUseCase, PostUserValidation>();

            services.AddScoped<ILoginUserUseCase, LoginUserUseCase>();
            services.Decorate<ILoginUserUseCase, LoginUserValidation>();

            return services;
        }
    }
}