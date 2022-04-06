using Application.UseCases.PostUser;
using Domain.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Controllers.Base;

namespace WebApi.Controllers.v1.UseCases.PostUser
{
    /// <summary>
    /// UsersController
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class UsersController : BaseController
    {
        private readonly IPostUserUseCase _useCase;

        public UsersController(IPostUserUseCase useCase)
        {
            _useCase = useCase;
        }
        
        /// <summary>
        /// Cria usuários.
        /// </summary>
        /// <response code="204">Successfull Request.</response>
        /// <response code="400">Invalid Request.</response>
        /// <response code="409">Already Existing Login.</response>
        /// <param name="request"></param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PostUser([FromBody] PostUserRequest request)
        {
            ValidateRequest(request);
            await _useCase.Execute(request);

            return NoContent();
        }
    }
}