using MealPlannerApi.DTOs;
using MealPlannerApi.Models;
using MealPlannerApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MealPlannerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MealPlanController : ControllerBase
    {
        private readonly MealPlanService _mealPlanService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MealPlanController"/> class.
        /// </summary>
        /// <param name="mealPlanService">The service for handling meal plan logic.</param>
        public MealPlanController(MealPlanService mealPlanService)
        {
            _mealPlanService = mealPlanService;
        }

        /// <summary>
        /// Creates a new meal plan for a user.
        /// Only accessible by users with "Admin" or "MealPlanner" roles.
        /// </summary>
        /// <param name="mealPlanDto">The meal plan details.</param>
        /// <returns>The created meal plan.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin, MealPlanner")]
        public async Task<IActionResult> CreateMealPlan([FromBody] MealPlanDto mealPlanDto)
        {
            var mealPlan = await _mealPlanService.CreateMealPlanAsync(mealPlanDto);
            return CreatedAtAction(nameof(GetMealPlanById), new { id = mealPlan.MealPlanId }, mealPlan);
        }

        /// <summary>
        /// Gets a meal plan by its ID.
        /// </summary>
        /// <param name="id">The ID of the meal plan to retrieve.</param>
        /// <returns>The meal plan with the specified ID, or a 404 Not Found if not found.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMealPlanById(int id)
        {
            var mealPlan = await _mealPlanService.GetMealPlanByIdAsync(id);
            if (mealPlan == null)
            {
                return NotFound();
            }
            return Ok(mealPlan);
        }

        /// <summary>
        /// Gets all meal plans.
        /// </summary>
        /// <returns>A list of all meal plans.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllMealPlans()
        {
            var mealPlans = await _mealPlanService.GetAllMealPlansAsync();
            return Ok(mealPlans);
        }
    }
}
