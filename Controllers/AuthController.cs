using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelGreen.Contracts;
using TravelGreen.Models.Users;

namespace TravelGreen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManger;

        public AuthController(IAuthManager authManger)
        {
            _authManger = authManger;
        }

        // POST: api/Auth/register
        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register([FromBody] ApiUserDto userDto)
        {
            var errors = await _authManger.Register(userDto);

            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // POST: api/Auth/login
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] LoginUserDto userDto)
        {
            bool isValidUser = await _authManger.Login(userDto);

            if (!isValidUser)
            {
                return Unauthorized();
            }

            return Ok();
        }
    }
}
