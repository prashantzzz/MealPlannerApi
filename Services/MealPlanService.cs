using MealPlannerApi.Data;
using MealPlannerApi.DTOs;
using MealPlannerApi.Models;

namespace MealPlannerApi.Services
{
    public class MealPlanService
    {
        private readonly ApplicationDbContext _context;

        public MealPlanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public List<MealPlan> GetMealPlansForUser(int userId)  // Change to int
        {
            return _context.MealPlans.Where(mp => mp.UserId == userId).ToList();
        }

        public MealPlan GetMealPlanById(int id)
        {
            return _context.MealPlans.Find(id);
        }

        public List<MealPlan> GetAllMealPlans()
        {
            return _context.MealPlans.ToList();
        }

        public bool CreateMealPlan(MealPlanDto model)
        {
            var mealPlan = new MealPlan
            {
                UserId = model.UserId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                MealType = model.MealType,
                RecipeId = model.RecipeId
            };
            _context.MealPlans.Add(mealPlan);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateMealPlan(int id, MealPlanDto model)
        {
            Console.WriteLine($"Attempting to update MealPlan with ID: {id}"); // Debugging
            var mealPlan = _context.MealPlans.Find(id);
            if (mealPlan == null)
            {
                Console.WriteLine($"MealPlan with ID {id} not found.");
                return false;
            }

            mealPlan.StartDate = model.StartDate;
            mealPlan.EndDate = model.EndDate;
            mealPlan.MealType = model.MealType;
            mealPlan.RecipeId = model.RecipeId;
            return _context.SaveChanges() > 0;
        }


        public bool DeleteMealPlan(int id)
        {
            var mealPlan = _context.MealPlans.Find(id);
            if (mealPlan == null) return false;

            _context.MealPlans.Remove(mealPlan);
            return _context.SaveChanges() > 0;
        }
    }
}
