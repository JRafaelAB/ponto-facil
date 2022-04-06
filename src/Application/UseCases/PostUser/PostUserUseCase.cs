using Domain.DTOs;
using Domain.Models.Requests;
using Domain.Repositories;
using Domain.UnitOfWork;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.Resources;

namespace Application.UseCases.PostUser
{
    public class PostUserUseCase : IPostUserUseCase
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PostUserUseCase(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public async Task Execute(PostUserRequest request)
        {
            if (await this._repository.GetUser(request.Login) != null)
            {
                throw new LoginConflictException(Messages.InvalidLogin);
            }
            
            UserDto user = new(request);
            await _repository.AddUser(user);
            await _unitOfWork.Save();
        }
    }
}