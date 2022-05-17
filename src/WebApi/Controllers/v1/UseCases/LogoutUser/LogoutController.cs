using Application.UseCases.LogoutUser;
using Domain.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Controllers.Base;

namespace WebApi.Controllers.v1.UseCases.LogoutUser
{
    /// <summary>
    /// UserController
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class LogoutController : BaseController
    {
        /// <summary>
        /// Faz Logout.
        /// </summary>
        /// <response code="204">Successfull Request.</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Logout([FromServices] ILogoutUserUseCase useCase)
        {
            await useCase.Execute();

            this.Response.Cookies.DeleteToken();
            return NoContent();
        }
    }
}