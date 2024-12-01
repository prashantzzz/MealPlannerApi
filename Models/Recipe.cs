using System.ComponentModel.DataAnnotations;

namespace MealPlannerApi.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Category { get; set; } // e.g., Breakfast, Lunch

        [Required]
        public string Ingredients { get; set; } // JSON or delimited string

        [Required]
        public string PreparationSteps { get; set; }

        [Required]
        public int CookingTime { get; set; } // in minutes

        [Required]
        public int Servings { get; set; }

        public string NutritionalInfo { get; set; } // JSON or delimited string
    }
}
