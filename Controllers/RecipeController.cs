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
            return Ok(new { data = _recipeService.GetAllRecipes() });
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetRecipeById(int id)
        {
            var recipe = _recipeService.GetRecipeById(id);
            return recipe != null
                ? Ok(new { data = recipe })
                : NotFound(new { message = "Recipe not found" });
        }

        [Authorize(Roles = "Admin,Chef,Nutritionist")]
        [HttpPost]
        public IActionResult CreateRecipe(RecipeDto model)
        {
            var result = _recipeService.CreateRecipe(model);
            return result
                ? Ok(new { message = "Recipe created successfully" })
                : BadRequest(new { message = "Creation failed" });
        }

        [Authorize(Roles = "Admin,Chef,Nutritionist")]
        [HttpPut("{id}")]
        public IActionResult UpdateRecipe(int id, RecipeDto model)
        {
            var result = _recipeService.UpdateRecipe(id, model);
            return result
                ? Ok(new { message = "Recipe updated successfully" })
                : NotFound(new { message = "Recipe not found" });
        }

        [Authorize(Roles = "Admin,Chef,Nutritionist")]
        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            var result = _recipeService.DeleteRecipe(id);
            return result
                ? Ok(new { message = "Recipe deleted successfully" })
                : NotFound(new { message = "Recipe not found" });
        }
    }
}
