using Domain.DTOs;
using Domain.Models.Requests;
using Domain.Repositories;
using Domain.UnitOfWork;
using Domain.Utils;
using Infrastructure.Services;
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
        private ITokenService _service;

        public PostUserUseCase(IConfiguration configuration, IUserRepository repository, IUnitOfWork unitOfWork, ITokenService service)
        {
            this._configuration = configuration;
            this._repository = repository;
            this._unitOfWork = unitOfWork;
            this._service = service;
        }

        public async Task Execute(PostUserRequest request)
        {
            var size = this._configuration.GetValue<uint>(_userSaltSize);
            var salt = Cryptography.GenerateSalt(size);
            var password = Cryptography.EncryptPassword(request.Password!, salt);

            UserDto user = new(request, salt, password);

            await _repository.AddUser(user);
            await _unitOfWork.Save();
        }
    }
}