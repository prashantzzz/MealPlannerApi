using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MealPlannerApi.Services;
using MealPlannerApi.Models;

namespace MealPlannerApi.Controllers
{
    [ApiController]
    [Route("api/dietary-preferences")]
    public class DietaryPreferenceController : ControllerBase
    {
        private readonly DietaryPreferenceService _dietaryPreferenceService;

        public DietaryPreferenceController(DietaryPreferenceService dietaryPreferenceService)
        {
            _dietaryPreferenceService = dietaryPreferenceService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetPreference()
        {
            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized(new { message = "User is not authenticated" });
            }

            var user = _dietaryPreferenceService.GetUserByUsername(username);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            var preferences = _dietaryPreferenceService.GetPreferencesForUser(user.UserId); // Fetch all preferences
            return preferences.Any()
                ? Ok(new { message = "Dietary preferences retrieved successfully", data = preferences })
                : NotFound(new { message = "No dietary preferences found" });
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetPreferenceById(int id)
        {
            var preference = _dietaryPreferenceService.GetPreferenceById(id);
            return preference != null
                ? Ok(new { message = "Dietary preference retrieved successfully", data = preference })
                : NotFound(new { message = "Dietary preference not found" });
        }

        [Authorize(Roles = "Admin,MealPlanner,Nutritionist")] 
        [HttpGet("all")]
        public IActionResult GetAllPreferences()
        {
            var preferences = _dietaryPreferenceService.GetAllPreferences();
            return preferences.Any()
                ? Ok(new { message = "All dietary preferences retrieved successfully", data = preferences })
                : NotFound(new { message = "No dietary preferences found" });
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreatePreference(DietaryPreference model)
        {
            var result = _dietaryPreferenceService.CreatePreference(model);
            return result
                ? Ok(new { message = "Dietary preference created successfully" })
                : BadRequest(new { message = "Failed to create dietary preference" });
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdatePreference(int id, DietaryPreference updatedModel)
        {
            var result = _dietaryPreferenceService.UpdatePreference(id, updatedModel);
            return result
                ? Ok(new { message = "Dietary preference updated successfully" })
                : NotFound(new { message = "Dietary preference not found" });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeletePreference(int id)
        {
            var result = _dietaryPreferenceService.DeletePreference(id);
            return result
                ? Ok(new { message = "Dietary preference deleted successfully" })
                : NotFound(new { message = "Dietary preference not found" });
        }
    }
}
