using Application.UseCases.PostUser;
using Domain.DTOs;
using Domain.Repositories;
using Domain.UnitOfWork;
using Domain.Utils;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.UseCases.PostUser
{
    public class PostUserUseCaseTest
    {
        private Mock<IConfiguration> _configuration;
        private Mock<IConfigurationSection> _mockSection;
        private Mock<IUserRepository> _repository;
        private Mock<IUnitOfWork> _unitOfWork;
        public PostUserUseCase useCase;

        public PostUserUseCaseTest()
        {
            this._mockSection = new();
            this._configuration = new();
            this._repository = new();
            this._unitOfWork = new();
            this.useCase = new PostUserUseCase(_configuration.Object, _repository.Object, _unitOfWork.Object);
        }

        [Fact]
        public async Task TestingSucess()
        {
            _mockSection.Setup(section => section.Value).Returns("100");
            _configuration.Setup(x => x.GetSection("UserSaltSize")).Returns(_mockSection.Object);
            var salt = Cryptography.GenerateSalt(100);
            var password = Cryptography.EncryptPassword(PostUserDataSetup.validUser.Password!, salt);

            UserDto user = new(PostUserDataSetup.validUser, salt, password);

            await useCase.Execute(PostUserDataSetup.validUser);

            this._unitOfWork.Verify(x => x.Save(), Times.Exactly(1));
            Assert.Equal(PostUserDataSetup.validUser.Login, user.Login);
        }
    }
}