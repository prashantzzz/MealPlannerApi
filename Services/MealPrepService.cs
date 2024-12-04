using MealPlannerApi.Data;
using MealPlannerApi.Models;
using MealPlannerApi.DTOs;

namespace MealPlannerApi.Services
{
    public class MealPrepService
    {
        private readonly ApplicationDbContext _context;

        public MealPrepService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MealPrep> GetAllMealPreps()
        {
            return _context.MealPrep.ToList();
        }

        public MealPrep GetMealPrepById(int id)
        {
            return _context.MealPrep.FirstOrDefault(mp => mp.MealPrepId == id);
        }

        public bool AddMealPrep(MealPrepDto model)
        {
            var mealPrep = new MealPrep
            {
                RecipeId = model.RecipeId,
                PortionSize = model.PortionSize,
                IngredientsRequired = model.IngredientsRequired,
                PrepTime = model.PrepTime
            };

            _context.MealPrep.Add(mealPrep);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateMealPrep(int id, MealPrepDto model)
        {
            var existing = _context.MealPrep.FirstOrDefault(mp => mp.MealPrepId == id);
            if (existing == null) return false;

            existing.RecipeId = model.RecipeId;
            existing.PortionSize = model.PortionSize;
            existing.IngredientsRequired = model.IngredientsRequired;
            existing.PrepTime = model.PrepTime;

            _context.MealPrep.Update(existing);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteMealPrep(int id)
        {
            var mealPrep = _context.MealPrep.FirstOrDefault(mp => mp.MealPrepId == id);
            if (mealPrep == null) return false;

            _context.MealPrep.Remove(mealPrep);
            return _context.SaveChanges() > 0;
        }
    }
}
