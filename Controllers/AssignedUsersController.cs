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
            return Ok(_assignedUsersService.GetAllAssignedUsers());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetAssignedUserById(int id)
        {
            var assignedUser = _assignedUsersService.GetAssignedUserById(id);
            return assignedUser != null ? Ok(assignedUser) : NotFound("Assigned user not found");
        }

        [Authorize] //will be updated automatically after succesfull payment by customer
        [HttpPost]
        public IActionResult AddAssignedUser(AssignedUsersDto model)
        {
            var result = _assignedUsersService.AddAssignedUser(model);
            return result ? Ok("Assigned user added successfully") : BadRequest("Failed to add assigned user");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateAssignedUser(int id, AssignedUsersDto model)
        {
            var result = _assignedUsersService.UpdateAssignedUser(id, model);
            return result ? Ok("Assigned user updated successfully") : NotFound("Assigned user not found");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteAssignedUser(int id)
        {
            var result = _assignedUsersService.DeleteAssignedUser(id);
            return result ? Ok("Assigned user deleted successfully") : NotFound("Assigned user not found");
        }
    }
}
