using Application.UseCases.PostUser;
using Domain.Exceptions;
using Domain.Models.Requests;
using Domain.Repositories;
using Domain.Resources;
using Domain.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.UseCases.PostUser
{
    public class PostUserValidationTest
    {
        public Mock<PostUserUseCase> useCase;
        public PostUserValidation validation;
        public NotificationError notificationError;
        private Mock<IConfiguration> _configuration;
        private Mock<IUserRepository> _repository;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IConfigurationSection> _mockSection;

        private string _userSaltSize = "UserSaltSize";

        public PostUserValidationTest()
        {
            this._mockSection = new();
            this._configuration = new();
            this._repository = new();
            this._unitOfWork = new();
            this.useCase = new(_configuration.Object, _repository.Object, _unitOfWork.Object);
            this.validation = new PostUserValidation(useCase.Object, _repository.Object);
            this.notificationError = new();
        }

        [Fact]
        public async Task TestingSuccess()
        {
            _mockSection.Setup(section => section.Value).Returns("100");
            _configuration.Setup(x => x.GetSection(_userSaltSize)).Returns(_mockSection.Object);
            await validation.Execute(PostUserDataSetup.validUser);
        }

        [Theory]
        [ClassData(typeof(PostUserNameTheoryData))]
        public async Task TestingInvalidRequestName(PostUserRequest userRequest)
        {
            try
            {
                await validation.Execute(userRequest);
            }
            catch (Exception exception)
            {
                Assert.Equal(typeof(InvalidRequestException), exception.GetType());
                Assert.Equal(Messages.RequiredName, ((InvalidRequestException)exception).notificationError.ErrorMessages.FirstOrDefault());
            }
        }

        [Theory]
        [ClassData(typeof(PostUserLoginTheoryData))]
        public async Task TestingInvalidRequestLogin(PostUserRequest userRequest)
        {
            try
            {
                await validation.Execute(userRequest);
            }
            catch (Exception exception)
            {
                Assert.Equal(typeof(InvalidRequestException), exception.GetType());
                Assert.Equal(Messages.RequiredLogin, ((InvalidRequestException)exception).notificationError.ErrorMessages.FirstOrDefault());
            }
        }

        [Theory]
        [ClassData(typeof(PostUserPasswordTheoryData))]
        public async Task TestingInvalidRequestPassword(PostUserRequest userRequest)
        {
            try
            {
                await validation.Execute(userRequest);
            }
            catch (Exception exception)
            {
                Assert.Equal(typeof(InvalidRequestException), exception.GetType());
                Assert.Equal(Messages.RequiredPassword, ((InvalidRequestException)exception).notificationError.ErrorMessages.FirstOrDefault());
            }
        }
    }
}