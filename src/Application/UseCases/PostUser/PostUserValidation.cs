using Domain.Exceptions;
using Domain.Models.Requests;
using Domain.Resources;
using System;
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
            if (string.IsNullOrEmpty(requestModel.Name))
            {
                _notificationError.Add(Messages.RequiredName);
            }

            if (string.IsNullOrEmpty(requestModel.Login))
            {
                _notificationError.Add(Messages.RequiredLogin);
            }

            if (string.IsNullOrEmpty(requestModel.Password))
            {
                _notificationError.Add(Messages.RequiredPassword);
            }

            if (_notificationError.IsInvalid)
            {
                throw new InvalidRequestException(_notificationError);
            }

            await Task.CompletedTask
                .ConfigureAwait(false);
        }
    }
}