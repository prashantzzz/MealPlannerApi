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

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="authService">The service responsible for handling authentication logic.</param>
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Logs in a user and generates a JWT token.
        /// </summary>
        /// <param name="request">The login request containing username and password.</param>
        /// <returns>A JWT token if credentials are valid, otherwise an Unauthorized response.</returns>
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
