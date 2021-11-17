using Application.UseCases.PostUser;
using Domain.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1.UseCases.PostUser
{
    /// <summary>
    /// UserController
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Cria usuários.
        /// </summary>
        /// <response code="200">Returns the greeting message</response>
        /// <param name="useCase"></param>
        /// <param name="request"></param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(
            [FromServices] IPostUseCase useCase,
            [FromBody] PostUserRequest request)
        {
            await useCase.Execute(request)
                .ConfigureAwait(false);

            return NoContent();
        }
    }
}