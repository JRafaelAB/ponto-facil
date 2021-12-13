using Domain.Exceptions;
using Domain.Models.Requests;
using Domain.Resources;
using System.Threading.Tasks;

namespace Application.UseCases.PostUser
{
    public class PostUserValidation : IPostUserUseCase
    {
        private IPostUserUseCase _useCase;
        private NotificationError _notificationError = new NotificationError();

        public PostUserValidation(IPostUserUseCase useCase)
        {
            this._useCase = useCase;
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

            if (_notificationError.IsInvalid)
            {
                throw new InvalidRequestException(_notificationError);
            }

            await this._useCase
                .Execute(requestModel)
                .ConfigureAwait(false);
        }
    }
}