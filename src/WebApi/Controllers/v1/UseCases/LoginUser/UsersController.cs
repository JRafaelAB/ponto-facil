using Application.UseCases.LoginUser;
using Domain.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domain.Extensions;
using WebApi.Controllers.Base;

namespace WebApi.Controllers.v1.UseCases.LoginUser
{
    /// <summary>
    /// UserController
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class UsersController : BaseController
    {
        private readonly ILoginUserUseCase _useCase;

        public UsersController(ILoginUserUseCase useCase)
        {
            _useCase = useCase;
        }
        
        /// <summary>
        /// Faz login.
        /// </summary>
        /// <response code="204">Successfull Request.</response>
        /// <response code="400">Invalid Request or Login/Password are Invalid.</response>
        /// <param name="request"></param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            ValidateRequest(request);
            this.Response.Cookies.AppendAccessToken(await _useCase.Execute(request));
            return NoContent();
        }
    }
}