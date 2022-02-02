using Domain.Models.Requests;
using System.Threading.Tasks;

namespace Application.UseCases.LoginUser
{
    public interface ILoginUserUseCase
    {
        Task<string> Execute(LoginUserRequest request);
    }
}