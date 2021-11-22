using Domain.Models.Requests;
using System.Threading.Tasks;

namespace Application.UseCases.PostUser
{
    public class PostUserUseCase : IPostUserUseCase
    {
        public async Task Execute(PostUserRequest requestModel)
        {
            await Task.CompletedTask
                .ConfigureAwait(false);
        }
    }
}