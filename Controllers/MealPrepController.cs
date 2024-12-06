using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MealPlannerApi.Services;
using MealPlannerApi.DTOs;

namespace MealPlannerApi.Controllers
{
    [ApiController]
    [Route("api/mealprep")]
    public class MealPrepController : ControllerBase
    {
        private readonly MealPrepService _mealPrepService;

        public MealPrepController(MealPrepService mealPrepService)
        {
            _mealPrepService = mealPrepService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllMealPreps()
        {
            return Ok(new { data = _mealPrepService.GetAllMealPreps() });
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetMealPrepById(int id)
        {
            var mealPrep = _mealPrepService.GetMealPrepById(id);
            return mealPrep != null
                ? Ok(new { data = mealPrep })
                : NotFound(new { message = "Meal Prep not found" });
        }

        [Authorize(Roles = "Admin,Chef")]
        [HttpPost]
        public IActionResult AddMealPrep(MealPrepDto model)
        {
            var result = _mealPrepService.AddMealPrep(model);
            return result
                ? Ok(new { message = "Meal Prep added successfully" })
                : BadRequest(new { message = "Failed to add Meal Prep" });
        }

        [Authorize(Roles = "Admin,Chef")]
        [HttpPut("{id}")]
        public IActionResult UpdateMealPrep(int id, MealPrepDto model)
        {
            var result = _mealPrepService.UpdateMealPrep(id, model);
            return result
                ? Ok(new { message = "Meal Prep updated successfully" })
                : NotFound(new { message = "Meal Prep not found" });
        }

        [Authorize(Roles = "Admin,Chef")]
        [HttpDelete("{id}")]
        public IActionResult DeleteMealPrep(int id)
        {
            var result = _mealPrepService.DeleteMealPrep(id);
            return result
                ? Ok(new { message = "Meal Prep deleted successfully" })
                : NotFound(new { message = "Meal Prep not found" });
        }
    }
}
