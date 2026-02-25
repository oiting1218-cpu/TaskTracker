using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Api.DTOs;
using TaskTracker.Api.Exceptions;
using TaskTracker.Api.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserDto dto)
        {
            //Note: WITH Global Exception Middleware, no need use try and catch the exception, it automatically handled by middleware
            //If EmailAlreadyExistsException is thrown → middleware returns 409
            //If any unknown exception happens → middleware returns 500
            //Best practice: No null check, No exception handling, middleware handles errors.
            await _authService.RegisterUser(dto);
            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _authService.Login(dto);
            return Ok(result);
        }
    }
}
