using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MealPlannerApi.Services;
using MealPlannerApi.DTOs;

namespace MealPlannerApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllUsers()
        {
            return Ok(new { data = _userService.GetAllUsers() });
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            return user != null
                ? Ok(new { data = user })
                : NotFound(new { message = "User not found" });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateUser(int id, UserDto model)
        {
            var result = _userService.UpdateUser(id, model);
            return result
                ? Ok(new { message = "User updated successfully" })
                : BadRequest(new { message = "Update failed" });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUser(int id)
        {
            var result = _userService.DeleteUser(id);
            return result
                ? Ok(new { message = "User deleted successfully" })
                : NotFound(new { message = "User not found" });
        }
    }
}
