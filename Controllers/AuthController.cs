using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelGreen.Contracts;
using TravelGreen.Models.Users;
using TravelGreen.Repository;

namespace TravelGreen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManger;
        private readonly ILogger<AuthManager> _logger;


        public AuthController(IAuthManager authManger, ILogger<AuthController> logger)
        {
            this._authManger = authManger;
            this._logger = logger;
        }

        // POST: api/Auth/register
        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register([FromBody] ApiUserDto userDto)
        {
            _logger.LogInformation($"Registration attempt for {userDto.Email}");
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Registration failed for {userDto.Email}, something went wrong in {nameof(Register)}");
                return Problem($"Registration failed for {userDto.Email}, something went wrong in {nameof(Register)}", statusCode: 500);
            }
        }

        // POST: api/Auth/login
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] LoginUserDto userDto)
        {
            _logger.LogInformation($"Login attempt for {userDto.Email}");

            try
            {
                AuthResponseDto authResponse = await _authManger.Login(userDto);

                if (authResponse == null)
                {
                    return Unauthorized();
                }

                return Ok(authResponse);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Login failed for {userDto.Email}, something went wrong in {nameof(Login)}");
                return Problem($"Something went wrong during login attempt for {userDto.Email}", statusCode: 500);
            }
        }

        // POST: api/Auth/RefreshToken
        [HttpPost]
        [Route("RefreshToken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDto request)
        {
            AuthResponseDto authResponse = await _authManger.VerifyRefreshToken(request);

            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }
    }
}
