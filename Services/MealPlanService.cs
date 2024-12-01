using MealPlannerApi.Data;
using MealPlannerApi.DTOs;
using MealPlannerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MealPlannerApi.Services
{
    public class MealPlanService
    {
        private readonly ApplicationDbContext _context;

        public MealPlanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MealPlan> CreateMealPlanAsync(MealPlanDto mealPlanDto)
        {
            var mealPlan = new MealPlan
            {
                UserId = mealPlanDto.UserId,
                StartDate = mealPlanDto.StartDate,
                EndDate = mealPlanDto.EndDate,
                MealType = mealPlanDto.MealType,
                RecipeId = mealPlanDto.RecipeId
            };

            _context.MealPlans.Add(mealPlan);
            await _context.SaveChangesAsync();
            return mealPlan;
        }

        public async Task<MealPlan> GetMealPlanByIdAsync(int id)
        {
            return await _context.MealPlans
                .FirstOrDefaultAsync(mp => mp.MealPlanId == id);
        }

        public async Task<List<MealPlan>> GetAllMealPlansAsync()
        {
            return await _context.MealPlans.ToListAsync();
        }
    }
}
