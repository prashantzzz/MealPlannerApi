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
            return Ok(_mealPrepService.GetAllMealPreps());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetMealPrepById(int id)
        {
            var mealPrep = _mealPrepService.GetMealPrepById(id);
            return mealPrep != null ? Ok(mealPrep) : NotFound("Meal Prep not found");
        }

        [Authorize(Roles = "Admin,Chef")]
        [HttpPost]
        public IActionResult AddMealPrep(MealPrepDto model)
        {
            var result = _mealPrepService.AddMealPrep(model);
            return result ? Ok("Meal Prep added successfully") : BadRequest("Failed to add Meal Prep");
        }

        [Authorize(Roles = "Admin,Chef")]
        [HttpPut("{id}")]
        public IActionResult UpdateMealPrep(int id, MealPrepDto model)
        {
            var result = _mealPrepService.UpdateMealPrep(id, model);
            return result ? Ok("Meal Prep updated successfully") : NotFound("Meal Prep not found");
        }

        [Authorize(Roles = "Admin,Chef")]
        [HttpDelete("{id}")]
        public IActionResult DeleteMealPrep(int id)
        {
            var result = _mealPrepService.DeleteMealPrep(id);
            return result ? Ok("Meal Prep deleted successfully") : NotFound("Meal Prep not found");
        }
    }
}
