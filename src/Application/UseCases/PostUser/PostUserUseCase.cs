using Domain.DTOs;
using Domain.Models.Requests;
using Domain.Repositories;
using Domain.UnitOfWork;
using Domain.Utils;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Application.UseCases.PostUser
{
    public class PostUserUseCase : IPostUserUseCase
    {
        private IConfiguration _configuration;
        private IUserRepository _repository;
        private IUnitOfWork _unitOfWork;
        private string _userSaltSize = "UserSaltSize";

        public PostUserUseCase(IConfiguration configuration, IUserRepository repository, IUnitOfWork unitOfWork)
        {
            this._configuration = configuration;
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public async Task Execute(PostUserRequest request)
        {
            var size = this._configuration.GetValue<uint>(_userSaltSize);
            var salt = Cryptography.GenerateSalt(size);
            var password = Cryptography.EncryptPassword(request.Password!, salt);

            UserDto user = new(request, salt, password);

            await _repository.AddUser(user).ConfigureAwait(false);
            await _unitOfWork.Save().ConfigureAwait(false);
        }
    }
}