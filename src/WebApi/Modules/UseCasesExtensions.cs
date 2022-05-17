using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.PostUser;
using Application.UseCases.LoginUser;
using Application.UseCases.LogoutUser;

namespace WebApi.Modules
{
    public static class UseCasesExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IPostUserUseCase, PostUserUseCase>();

            services.AddScoped<ILoginUserUseCase, LoginUseCase>();

            services.AddScoped<ILogoutUserUseCase, LogoutUseCase>();

            return services;
        }
    }
}