using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MealPlannerApi.Services;
using MealPlannerApi.DTOs;

namespace MealPlannerApi.Controllers
{
    [ApiController]
    [Route("api/assignedusers")]
    public class AssignedUsersController : ControllerBase
    {
        private readonly AssignedUsersService _assignedUsersService;

        public AssignedUsersController(AssignedUsersService assignedUsersService)
        {
            _assignedUsersService = assignedUsersService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllAssignedUsers()
        {
            var assignedUsers = _assignedUsersService.GetAllAssignedUsers();
            return Ok(new { message = "Assigned users retrieved successfully", data = assignedUsers });
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetAssignedUserById(int id)
        {
            var assignedUser = _assignedUsersService.GetAssignedUserById(id);
            if (assignedUser != null)
            {
                return Ok(new { message = "Assigned user retrieved successfully", data = assignedUser });
            }

            return NotFound(new { message = "Assigned user not found" });
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddAssignedUser(AssignedUsersDto model)
        {
            var result = _assignedUsersService.AddAssignedUser(model);
            if (result)
            {
                return Ok(new { message = "Assigned user added successfully" });
            }

            return BadRequest(new { message = "Failed to add assigned user" });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateAssignedUser(int id, AssignedUsersDto model)
        {
            var result = _assignedUsersService.UpdateAssignedUser(id, model);
            if (result)
            {
                return Ok(new { message = "Assigned user updated successfully" });
            }

            return NotFound(new { message = "Assigned user not found" });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteAssignedUser(int id)
        {
            var result = _assignedUsersService.DeleteAssignedUser(id);
            if (result)
            {
                return Ok(new { message = "Assigned user deleted successfully" });
            }

            return NotFound(new { message = "Assigned user not found" });
        }
    }
}
