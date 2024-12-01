using Microsoft.AspNetCore.Mvc;
using MealPlannerApi.Services;
using MealPlannerApi.DTOs; //for username and password

namespace MealPlannerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthRequestDto request)
        {
            var token = _authService.Authenticate(request.Username, request.Password);
            if (string.IsNullOrEmpty(token))
                return Unauthorized("Invalid credentials");

            return Ok(new { Token = token });
        }
    }
}
