using MealPlannerApi.Data; // For accessing ApplicationDbContext
using MealPlannerApi.Models; // For Nutrition model
using Microsoft.EntityFrameworkCore; // For Entity Framework Core operations (ToListAsync, FirstOrDefaultAsync, etc.)
using System.Collections.Generic; // For List<T>
using System.Threading.Tasks; // For async/await


namespace MealPlannerApi.Services
{
    public class NutritionService
    {
        private readonly ApplicationDbContext _context;

        public NutritionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Nutrition>> GetAllNutritionAsync()
        {
            return await _context.Nutrition.ToListAsync();
        }

        public async Task<Nutrition> GetNutritionByIdAsync(int id)
        {
            return await _context.Nutrition.Include(n => n.Recipe).FirstOrDefaultAsync(n => n.NutritionId == id);
        }

        public async Task<Nutrition> AddNutritionAsync(Nutrition nutrition)
        {
            _context.Nutrition.Add(nutrition);
            await _context.SaveChangesAsync();
            return nutrition;
        }

        public async Task<Nutrition> UpdateNutritionAsync(int id, Nutrition updatedNutrition)
        {
            var nutrition = await _context.Nutrition.FirstOrDefaultAsync(n => n.NutritionId == id);
            if (nutrition == null) return null;

            nutrition.Calories = updatedNutrition.Calories;
            nutrition.Protein = updatedNutrition.Protein;
            nutrition.Carbs = updatedNutrition.Carbs;
            nutrition.Fat = updatedNutrition.Fat;
            nutrition.Vitamins = updatedNutrition.Vitamins;

            await _context.SaveChangesAsync();
            return nutrition;
        }

        public async Task<bool> DeleteNutritionAsync(int id)
        {
            var nutrition = await _context.Nutrition.FirstOrDefaultAsync(n => n.NutritionId == id);
            if (nutrition == null) return false;

            _context.Nutrition.Remove(nutrition);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
