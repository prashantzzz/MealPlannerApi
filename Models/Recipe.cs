using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlannerApi.Models
{
    public class Recipe
    {
        [Key]
        [Column("RecipeId")] // Maps RecipeId column to Id property
        public int Id { get; set; } // Primary Key

        public string Name { get; set; }
        public string Category { get; set; } // e.g., Breakfast, Lunch, Dinner
        public string Ingredients { get; set; }
        public int PreparationSteps { get; set; }
        public int CookingTime { get; set; } // in minutes
        public int Servings { get; set; }
        public string NutritionalInfo { get; set; }
    }
}
