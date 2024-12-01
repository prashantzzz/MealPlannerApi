using Microsoft.AspNetCore.Mvc;
using MealPlannerApi.Models;
using MealPlannerApi.Services;

namespace MealPlannerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeService _recipeService;

        public RecipeController(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public IActionResult GetRecipes()
        {
            return Ok(_recipeService.GetAllRecipes());
        }

        [HttpGet("{id}")]
        public IActionResult GetRecipeById(int id)
        {
            var recipe = _recipeService.GetRecipeById(id);
            if (recipe == null) return NotFound();

            return Ok(recipe);
        }

        [HttpPost]
        public IActionResult AddRecipe([FromBody] Recipe recipe)
        {
            _recipeService.AddRecipe(recipe);
            return CreatedAtAction(nameof(GetRecipeById), new { id = recipe.RecipeId }, recipe);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRecipe(int id, [FromBody] Recipe recipe)
        {
            if (id != recipe.RecipeId) return BadRequest();

            _recipeService.UpdateRecipe(recipe);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            _recipeService.DeleteRecipe(id);
            return NoContent();
        }
    }
}
