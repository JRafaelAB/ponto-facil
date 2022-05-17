using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.v1.UseCases.LogoutUser;
using Xunit;

namespace UnitTests.Controllers.LogoutUser
{
    public class LogoutControllerTest
    {
        private readonly LogoutController _controller;

        public LogoutControllerTest()
        {
            this._controller = new LogoutController();
        }

        [Fact]
        public void TestingSucessPostUser()
        {
            ConfigureObjectValidator();

            Assert.IsType<NoContentResult>(_controller.NoContent());
        }

        #region Auxiliary

        private void ConfigureObjectValidator()
        {
            this._controller.ObjectValidator = new ObjectValidator();
        }

        #endregion Auxiliary
    }
}