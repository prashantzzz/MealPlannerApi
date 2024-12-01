using Microsoft.AspNetCore.Mvc;
using MealPlannerApi.Models;
using MealPlannerApi.Services;
using Microsoft.AspNetCore.Authorization;

namespace MealPlannerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeService _recipeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeController"/> class.
        /// </summary>
        /// <param name="recipeService">The service for handling recipe-related logic.</param>
        public RecipeController(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // Allows any authenticated user to get all recipes
        /// <summary>
        /// Gets all recipes.
        /// </summary>
        /// <returns>A list of all recipes.</returns>
        [HttpGet]
        public IActionResult GetRecipes()
        {
            return Ok(_recipeService.GetAllRecipes());
        }

        // Allows any authenticated user to get recipe by ID
        /// <summary>
        /// Gets a recipe by its ID.
        /// </summary>
        /// <param name="id">The ID of the recipe to retrieve.</param>
        /// <returns>The recipe with the specified ID, or a 404 Not Found if not found.</returns>
        [HttpGet("{id}")]
        public IActionResult GetRecipeById(int id)
        {
            var recipe = _recipeService.GetRecipeById(id);
            if (recipe == null) return NotFound();

            return Ok(recipe);
        }

        // Allows Chefs and Nutritionists to add new recipes
        /// <summary>
        /// Adds a new recipe. Only accessible by users with "Chef" or "Nutritionist" roles.
        /// </summary>
        /// <param name="recipe">The recipe details to add.</param>
        /// <returns>The created recipe.</returns>
        [HttpPost]
        [Authorize(Roles = "Chef, Nutritionist")]
        public IActionResult AddRecipe([FromBody] Recipe recipe)
        {
            _recipeService.AddRecipe(recipe);
            return CreatedAtAction(nameof(GetRecipeById), new { id = recipe.RecipeId }, recipe);
        }

        // Allows Chefs and Nutritionists to update existing recipes
        /// <summary>
        /// Updates an existing recipe. Only accessible by users with "Chef" or "Nutritionist" roles.
        /// </summary>
        /// <param name="id">The ID of the recipe to update.</param>
        /// <param name="recipe">The updated recipe details.</param>
        /// <returns>No content if the update is successful.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Chef, Nutritionist")]
        public IActionResult UpdateRecipe(int id, [FromBody] Recipe recipe)
        {
            if (id != recipe.RecipeId) return BadRequest();

            _recipeService.UpdateRecipe(recipe);
            return NoContent();
        }

        // Allows Chefs and Nutritionists to delete recipes
        /// <summary>
        /// Deletes a recipe. Only accessible by users with "Chef" or "Nutritionist" roles.
        /// </summary>
        /// <param name="id">The ID of the recipe to delete.</param>
        /// <returns>No content if the deletion is successful.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Chef, Nutritionist")]
        public IActionResult DeleteRecipe(int id)
        {
            _recipeService.DeleteRecipe(id);
            return NoContent();
        }
    }
}
