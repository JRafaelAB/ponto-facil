using Application.UseCases.PostUser;
using Domain.Exceptions;
using Domain.Models.Requests;
using Domain.Resources;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.UseCases.PostUser
{
    public class PostUserValidationTest
    {
        public PostUserUseCase useCase;
        public PostUserValidation validation;
        public NotificationError notificationError;

        public PostUserValidationTest()
        {
            this.useCase = new();
            this.validation = new PostUserValidation(useCase);
            this.notificationError = new();
        }

        [Fact]
        public async Task TestarSucesso()
        {
            await validation.Execute(PostUserDataSetup.usuarioValido);
            Assert.False(notificationError.IsInvalid);
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