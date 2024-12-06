//AuthController.cs
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
            return result != null ? Ok(result) : Unauthorized("Invalid credentials");
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            _authService.Logout();
            return Ok("Logged out successfully");
        }

        [HttpPost("register/customer")]
        public IActionResult RegisterCustomer(RegisterRequestDto model)
        {
            model.Role = "Customer"; // Default role
            var result = _authService.Register(model);
            return result ? Ok("Customer registered successfully") : BadRequest("Registration failed");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("register/role")]
        public IActionResult RegisterRole(RegisterRoleRequestDto model)
        {
            if (!new[] { "Chef", "Nutritionist", "Meal Planner" }.Contains(model.Role))
                return BadRequest("Invalid role assignment");

            var result = _authService.Register(model);
            return result ? Ok($"{model.Role} registered successfully") : BadRequest("Registration failed");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("user/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            // Call the service method to delete the user
            var result = _authService.DeleteUser(userId);

            return result
                ? Ok($"User with ID {userId} deleted successfully")
                : NotFound($"User with ID {userId} not found");
        }
    }
}
