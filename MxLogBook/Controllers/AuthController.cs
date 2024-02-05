using Backend.DTOs.Auth;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //Private Fields
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        //POST: api/Auth/register
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> RegisterUser(RegisterUserDto registerUserDto)
        {
            var errors = await _authService.RegisterUser(registerUserDto);

            //If there are any errors
            if (errors.Any())
            {
                //Iterate through the errors
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                //Return the ModelState
                return BadRequest(ModelState);
            }

            //Else return ok
            return Ok("User Registered");
        }

        //POST: api/Auth/login
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> LoginUser(LoginUserDto loginUserDto)
        {
            var isValidated = await _authService.LoginUser(loginUserDto);

            if (!isValidated)
                return Unauthorized();

            return Ok("Logged in");
        }
    }
}
