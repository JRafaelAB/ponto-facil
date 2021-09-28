using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v2
{    
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        /// <summary>
        /// Hello World
        /// </summary>
        /// <returns>A greeting message</returns>
        /// <response code="200">Returns the greeting message</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public IActionResult GetHelloWorld()
        {
            return Ok("Hello World, I'm Alive!");
        }
    }
}
