using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MealPlannerApi.Services;
using MealPlannerApi.DTOs;

namespace MealPlannerApi.Controllers
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeService _recipeService;

        public RecipeController(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllRecipes()
        {
            return Ok(_recipeService.GetAllRecipes());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetRecipeById(int id)
        {
            var recipe = _recipeService.GetRecipeById(id);
            return recipe != null ? Ok(recipe) : NotFound("Recipe not found");
        }

        [Authorize(Roles = "Chef,Nutritionist")]
        [HttpPost]
        public IActionResult CreateRecipe(RecipeDto model)
        {
            var result = _recipeService.CreateRecipe(model);
            return result ? Ok("Recipe created successfully") : BadRequest("Creation failed");
        }

        [Authorize(Roles = "Chef,Nutritionist")]
        [HttpPut("{id}")]
        public IActionResult UpdateRecipe(int id, RecipeDto model)
        {
            var result = _recipeService.UpdateRecipe(id, model);
            return result ? Ok("Recipe updated successfully") : NotFound("Recipe not found");
        }

        [Authorize(Roles = "Chef,Nutritionist")]
        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            var result = _recipeService.DeleteRecipe(id);
            return result ? Ok("Recipe deleted successfully") : NotFound("Recipe not found");
        }
    }
}
