using Domain.Models.Requests;
using Domain.Repositories;
using Infrastructure.Services;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.Resources;

namespace Application.UseCases.LoginUser
{
    public class LoginUseCase : ILoginUserUseCase
    {
        private readonly IUserRepository _repository;
        private readonly ITokenService _service;

        public LoginUseCase(IUserRepository repository, ITokenService service)
        {
            this._repository = repository;
            this._service = service;
        }

        public async Task<string> Execute(LoginUserRequest request)
        {
            var user = await this._repository.GetUser(request.Login);
            
            if (user == null || !user.ValidatePassword(request.Password))
            {
                throw new InvalidLoginException(Messages.InvalidLoginPassword);
            }

            return _service.GenerateToken(user);
        }
    }
}