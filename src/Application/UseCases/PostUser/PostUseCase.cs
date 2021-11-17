using Domain.Models.Requests;
using System.Threading.Tasks;

namespace Application.UseCases.PostUser
{
    public class PostUseCase : IPostUseCase
    {
        public async Task Execute(PostUserRequest requestModel)
        {
            await Task.CompletedTask
                .ConfigureAwait(false);
        }
    }
}