using System.Threading.Tasks;

namespace Application.UseCases.LogoutUser
{
    public sealed class LogoutUseCase : ILogoutUserUseCase
    {
        public Task Execute() =>
            Logout();

        public static async Task Logout()
        {
            await Task.CompletedTask;
        }
    }
}