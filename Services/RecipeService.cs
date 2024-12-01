using MealPlannerApi.Data;
using MealPlannerApi.DTOs;
using MealPlannerApi.Models;

namespace MealPlannerApi.Services
{
    public class RecipeService
    {
        private readonly ApplicationDbContext _context;

        public RecipeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<RecipeDto> GetAllRecipes()
        {
            return _context.Recipes.Select(recipe => new RecipeDto
            {
                Name = recipe.Name,
                Category = recipe.Category,
                Ingredients = recipe.Ingredients,
                PreparationSteps = recipe.PreparationSteps,
                CookingTime = recipe.CookingTime,
                Servings = recipe.Servings,
                NutritionalInfo = recipe.NutritionalInfo
            }).ToList();
        }

        public RecipeDto GetRecipeById(int id)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.Id == id);
            if (recipe == null) return null;

            return new RecipeDto
            {
                Name = recipe.Name,
                Category = recipe.Category,
                Ingredients = recipe.Ingredients,
                PreparationSteps = recipe.PreparationSteps,
                CookingTime = recipe.CookingTime,
                Servings = recipe.Servings,
                NutritionalInfo = recipe.NutritionalInfo
            };
        }

        public bool CreateRecipe(RecipeDto model)
        {
            var newRecipe = new Recipe
            {
                Name = model.Name,
                Category = model.Category,
                Ingredients = model.Ingredients,
                PreparationSteps = model.PreparationSteps,
                CookingTime = model.CookingTime,
                Servings = model.Servings,
                NutritionalInfo = model.NutritionalInfo
            };

            _context.Recipes.Add(newRecipe);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateRecipe(int id, RecipeDto model)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.Id == id);
            if (recipe == null) return false;

            recipe.Name = model.Name;
            recipe.Category = model.Category;
            recipe.Ingredients = model.Ingredients;
            recipe.PreparationSteps = model.PreparationSteps;
            recipe.CookingTime = model.CookingTime;
            recipe.Servings = model.Servings;
            recipe.NutritionalInfo = model.NutritionalInfo;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteRecipe(int id)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.Id == id);
            if (recipe == null) return false;

            _context.Recipes.Remove(recipe);
            _context.SaveChanges();
            return true;
        }
    }
}
