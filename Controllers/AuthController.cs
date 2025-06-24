using be_movies.DTOs;
using be_movies.Services;
using Microsoft.AspNetCore.Mvc;

namespace be_movies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterUserDto dto)
        {
            try
            {
                var response = _authService.Register(dto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUserDto dto)
        {
            try
            {
                var response = _authService.Login(dto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

    }
}