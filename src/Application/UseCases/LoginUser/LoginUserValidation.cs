using Domain.Entities;
using Domain.Exceptions;
using Domain.Models.Requests;
using Domain.Repositories;
using Domain.Resources;
using System.Threading.Tasks;

namespace Application.UseCases.LoginUser
{
    public class LoginUserValidation : ILoginUserUseCase
    {
        private ILoginUserUseCase _useCase;
        private NotificationError _notificationError = new NotificationError();
        private IUserRepository _repository;

        public LoginUserValidation(ILoginUserUseCase useCase, IUserRepository repository)
        {
            this._useCase = useCase;
            this._repository = repository;
        }

        public async Task<string> Execute(LoginUserRequest request)
        {
            if (!string.IsNullOrEmpty(request.Login))
            {
                User? user = await this._repository.GetUser(request.Login, request.Password);
                if (user == null)
                {
                    _notificationError.Add(Messages.InvalidLoginPassword);
                }
            }

            if (_notificationError.IsInvalid)
            {
                throw new InvalidRequestException(_notificationError);
            }

            return await this._useCase
                .Execute(request);
        }
    }
}