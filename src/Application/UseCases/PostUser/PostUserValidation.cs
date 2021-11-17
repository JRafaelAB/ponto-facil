using Domain.Models.Requests;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.PostUser
{
    public class PostUserValidation : IPostUseCase
    {
        private IPostUseCase _useCase;

        public PostUserValidation(IPostUseCase useCase)
        {
            this._useCase = useCase;
        }

        public async Task Execute(PostUserRequest requestModel)
        {
            if (string.IsNullOrEmpty(requestModel.Name))
            {
                Console.WriteLine("Required name");
            }

            await Task.CompletedTask
                .ConfigureAwait(false);
        }
    }
}