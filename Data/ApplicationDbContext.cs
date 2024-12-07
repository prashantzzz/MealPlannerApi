using Microsoft.EntityFrameworkCore;
using MealPlannerApi.Models;

namespace MealPlannerApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Nutrition> Nutrition { get; set; }
        public DbSet<DietaryPreference> DietaryPreferences { get; set; }
        public DbSet<CookingInstruction> CookingInstructions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<MealPrep> MealPreps { get; set; }
        public DbSet<AssignedUsers> AssignedUsers { get; set; }
        public DbSet<MealPrep> MealPrep { get; set; }
    }
}
