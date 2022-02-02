using Application.UseCases.LoginUser;
using Domain.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1.UseCases.LoginUser
{
    /// <summary>
    /// UserController
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Fazer login.
        /// </summary>
        /// <response code="200">Returns the greeting message</response>
        /// <param name="useCase"></param>
        /// <param name="request"></param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(
            [FromServices] ILoginUserUseCase useCase,
            [FromBody] LoginUserRequest request)
        {
            string token = await useCase.Execute(request);

            this.Response.Cookies.Append("X-Access-Token", token, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict, Secure = true });

            return Ok(request);
        }
    }
}