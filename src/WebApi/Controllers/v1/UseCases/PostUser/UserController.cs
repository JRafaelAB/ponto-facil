using Domain.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        /// Hello World
        /// </summary>
        /// <returns>A greeting message</returns>
        /// <response code="200">Returns the greeting message</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public IActionResult GetHelloWorld()
        {
            string teste = null;
            teste.ValidateStringArgumentNotNullOrEmpty(string.Empty);
            return Ok("Hello World, I'm Alive!");
        }
    }
}
