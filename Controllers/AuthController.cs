using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MealPlannerApi.DTOs;
using MealPlannerApi.Services;

namespace MealPlannerApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(AuthRequestDto model)
        {
            var result = _authService.Login(model);

            if (result != null)
            {
                return Ok(new { message = "Login successful", token = result });
            }

            return Unauthorized(new { message = "Invalid credentials" });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            _authService.Logout();
            return Ok(new { message = "Logged out successfully" });
        }

        [HttpPost("register/customer")]
        public IActionResult RegisterCustomer(RegisterRequestDto model)
        {
            try
            {
                model.Role = "Customer"; // Default role
                var result = _authService.Register(model);

                if (result)
                {
                    return Ok(new { message = "Customer registered successfully" });
                }

                return BadRequest(new { message = "Registration failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Registration failed", error = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("register/role")]
        public IActionResult RegisterRole(RegisterRoleRequestDto model)
        {
            if (!new[] { "Chef", "Nutritionist", "Meal Planner" }.Contains(model.Role))
            {
                return BadRequest(new { message = "Invalid role assignment" });
            }

            var result = _authService.Register(model);

            if (result)
            {
                return Ok(new { message = $"{model.Role} registered successfully" });
            }

            return BadRequest(new { message = "Registration failed" });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("user/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            var result = _authService.DeleteUser(userId);

            if (result)
            {
                return Ok(new { message = $"User with ID {userId} deleted successfully" });
            }

            return NotFound(new { message = $"User with ID {userId} not found" });
        }
    }
}
