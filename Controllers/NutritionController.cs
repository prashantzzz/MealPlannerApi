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
    public class NutritionController : ControllerBase
    {
        private readonly NutritionService _nutritionService;

        public NutritionController(NutritionService nutritionService)
        {
            _nutritionService = nutritionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNutrition()
        {
            var nutritionList = await _nutritionService.GetAllNutritionAsync();
            return Ok(nutritionList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNutritionById(int id)
        {
            var nutrition = await _nutritionService.GetNutritionByIdAsync(id);
            if (nutrition == null)
                return NotFound("Nutrition data not found.");

            return Ok(nutrition);
        }

        [HttpPost]
        public async Task<IActionResult> AddNutrition([FromBody] NutritionDto nutritionDto)
        {
            // Check if the nutritionDto is null or invalid
            if (nutritionDto == null)
                return BadRequest("Invalid data.");

            // Create the Nutrition model object from the NutritionDto
            var nutrition = new Nutrition
            {
                RecipeId = nutritionDto.RecipeId,
                Calories = nutritionDto.Calories,
                Protein = nutritionDto.Protein,
                Carbs = nutritionDto.Carbs,
                Fat = nutritionDto.Fat,
                Vitamins = nutritionDto.Vitamins
            };

            var createdNutrition = await _nutritionService.AddNutritionAsync(nutrition);

            return CreatedAtAction(nameof(GetNutritionById), new { id = createdNutrition.NutritionId }, createdNutrition);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNutrition(int id, [FromBody] NutritionDto nutritionDto)
        {
            if (nutritionDto == null)
                return BadRequest("Invalid data.");

            // Fetch the existing nutrition record from the database
            var nutrition = await _nutritionService.GetNutritionByIdAsync(id);

            // If the nutrition record is not found, return a 404 Not Found response
            if (nutrition == null)
                return NotFound("Nutrition data not found.");

            // Update the nutrition record with the new values from the DTO
            nutrition.Calories = nutritionDto.Calories;
            nutrition.Protein = nutritionDto.Protein;
            nutrition.Carbs = nutritionDto.Carbs;
            nutrition.Fat = nutritionDto.Fat;
            nutrition.Vitamins = nutritionDto.Vitamins;

            // Save the updated nutrition record to the database
            var updatedNutrition = await _nutritionService.UpdateNutritionAsync(id, nutrition);

            // Return the updated nutrition record in the response
            return Ok(updatedNutrition);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNutrition(int id)
        {
            var result = await _nutritionService.DeleteNutritionAsync(id);
            if (!result)
                return NotFound("Nutrition data not found.");

            return NoContent();
        }
    }
}
    