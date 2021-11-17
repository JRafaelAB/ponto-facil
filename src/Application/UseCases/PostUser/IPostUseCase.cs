namespace Application.UseCases.PostUser
{
    using Domain.Models.Requests;
    using System.Threading.Tasks;

    public interface IPostUseCase
    {
        Task Execute(PostUserRequest requestModel);
    }
}