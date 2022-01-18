using Domain.Entities;
using Domain.Exceptions;
using Domain.Models.Requests;
using Domain.Repositories;
using Domain.Resources;
using System.Threading.Tasks;

namespace Application.UseCases.PostUser
{
    public class PostUserValidation : IPostUserUseCase
    {
        private IPostUserUseCase _useCase;
        private NotificationError _notificationError = new NotificationError();
        private IUserRepository _repository;

        public PostUserValidation(IPostUserUseCase useCase, IUserRepository repository)
        {
            this._useCase = useCase;
            this._repository = repository;
        }

        public async Task Execute(PostUserRequest requestModel)
        {
            if (string.IsNullOrEmpty(requestModel.Name) || string.IsNullOrWhiteSpace(requestModel.Name))
            {
                _notificationError.Add(Messages.RequiredName);
            }

            if (string.IsNullOrEmpty(requestModel.Login) || string.IsNullOrWhiteSpace(requestModel.Login))
            {
                _notificationError.Add(Messages.RequiredLogin);
            }

            if (string.IsNullOrEmpty(requestModel.Password) || string.IsNullOrWhiteSpace(requestModel.Password))
            {
                _notificationError.Add(Messages.RequiredPassword);
            }

            if (!string.IsNullOrEmpty(requestModel.Login))
            {
                User? user = await _repository.GetLogin(requestModel.Login);
                if (user != null)
                {
                    _notificationError.Add(Messages.InvalidLogin);
                }
            }

            if (_notificationError.IsInvalid)
            {
                throw new InvalidRequestException(_notificationError);
            }

            await this._useCase
                .Execute(requestModel);
        }
    }
}