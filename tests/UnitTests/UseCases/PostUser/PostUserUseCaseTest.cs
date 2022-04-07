using Application.UseCases.PostUser;
using Domain.DTOs;
using Domain.Repositories;
using Domain.UnitOfWork;
using Moq;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.Utils;
using Xunit;

namespace UnitTests.UseCases.PostUser
{
    public class PostUserUseCaseTest
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly PostUserUseCase _useCase;

        public PostUserUseCaseTest()
        {
            Configuration.SetConfiguration(TestConfigurationBuilder.BuildTestConfiguration());
            this._userRepository = new Mock<IUserRepository>();
            this._unitOfWork = new Mock<IUnitOfWork>();
            this._useCase = new PostUserUseCase(_userRepository.Object, _unitOfWork.Object);
        }

        [Fact]
        public async Task TestingSucess()
        {
            UserDto user = new("usuario", "email", "10", "10");

            await _useCase.Execute(PostUserDataSetup.validUser);
            
            this._userRepository.Verify(repo => repo.AddUser(user), Times.Once);
            this._userRepository.Verify(repo => repo.GetUser("email"), Times.Once);
            this._unitOfWork.Verify(x => x.Save(), Times.Once);
            Assert.Equal(PostUserDataSetup.validUser.Login, user.Login);
        }

        [Fact]
        public async Task TestingExistingLogin()
        {
            ConfigureUserRepositoryForExistingLogin();
            
            UserDto user = new("usuario", "email", "10", "10");
            
            await Assert.ThrowsAsync<LoginConflictException>(() => _useCase.Execute(PostUserDataSetup.validUser));
            
            this._userRepository.Verify(repo => repo.GetUser("email"), Times.Once);
            this._userRepository.Verify(repo => repo.AddUser(user), Times.Never);
            this._unitOfWork.Verify(x => x.Save(), Times.Never);
            Assert.Equal(PostUserDataSetup.validUser.Login, user.Login);
        }

        #region Auxiliary

        private void ConfigureUserRepositoryForExistingLogin()
        {
            this._userRepository.Setup(repo => repo.GetUser("email")).ReturnsAsync(new UserDto("usuario", "email", "10", "10"));
        }

        #endregion
    }
}