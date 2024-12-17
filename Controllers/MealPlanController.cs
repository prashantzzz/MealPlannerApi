using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MealPlannerApi.Services;
using MealPlannerApi.DTOs;
using MealPlannerApi.Models;

namespace MealPlannerApi.Controllers
{
    [ApiController]
    [Route("api/mealplans")]
    public class MealPlanController : ControllerBase
    {
        private readonly MealPlanService _mealPlanService;

        public MealPlanController(MealPlanService mealPlanService)
        {
            _mealPlanService = mealPlanService;
        }

        [Authorize(Roles = "Admin,Customer,MealPlanner")]
        [HttpGet]
        public IActionResult GetMealPlans()
        {
            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized(new { message = "User is not authenticated" });
            }

            var user = _mealPlanService.GetUserByUsername(username); // Service method to retrieve user by username

            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            var mealPlans = _mealPlanService.GetMealPlansForUser(user.UserId);
            return Ok(new { message = "Meal plans retrieved successfully", data = mealPlans });
        }



        [Authorize(Roles = "Admin,Customer,MealPlanner")]
        [HttpGet("{id}")]
        public IActionResult GetMealPlanById(int id)
        {
            var mealPlan = _mealPlanService.GetMealPlanById(id);
            if (mealPlan != null)
            {
                return Ok(new { message = "Meal plan retrieved successfully", data = mealPlan });
            }

            return NotFound(new { message = "Meal plan not found" });
        }

        [Authorize(Roles = "Admin,MealPlanner")] 
        [HttpGet("all")]
        public IActionResult GetAllMealPlans()
        {
            var mealPlans = _mealPlanService.GetAllMealPlans();
            return Ok(new { message = "All meal plans retrieved successfully", data = mealPlans });
        }

        [Authorize(Roles = "Admin,Customer,MealPlanner")]
        [HttpPost]
        public IActionResult CreateMealPlan(MealPlanDto model)
        {
            var result = _mealPlanService.CreateMealPlan(model);
            if (result)
            {
                return Ok(new { message = "Meal plan created successfully" });
            }

            return BadRequest(new { message = "Meal plan creation failed" });
        }

        [Authorize(Roles = "Admin,Customer,MealPlanner")]
        [HttpPut("{id}")]
        public IActionResult UpdateMealPlan(int id, MealPlanDto model)
        {
            var result = _mealPlanService.UpdateMealPlan(id, model);
            if (result)
            {
                return Ok(new { message = "Meal plan updated successfully" });
            }

            return NotFound(new { message = "Meal plan not found" });
        }

        [Authorize(Roles = "Customer,MealPlanner")]
        [HttpDelete("{id}")]
        public IActionResult DeleteMealPlan(int id)
        {
            var result = _mealPlanService.DeleteMealPlan(id);
            if (result)
            {
                return Ok(new { message = "Meal plan deleted successfully" });
            }

            return NotFound(new { message = "Meal plan not found" });
        }
    }
}
