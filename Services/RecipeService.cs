using MealPlannerApi.Data;
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

        public List<Recipe> GetAllRecipes()
        {
            return _context.Recipes.ToList();
        }

        public Recipe GetRecipeById(int id)
        {
            return _context.Recipes.FirstOrDefault(r => r.RecipeId == id);
        }

        public void AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
        }

        public void DeleteRecipe(int id)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.RecipeId == id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
                _context.SaveChanges();
            }
        }
    }
}
