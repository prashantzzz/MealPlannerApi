using System.ComponentModel.DataAnnotations;

namespace MealPlannerApi.Models
{
    public class Nutrition
    {
        [Key]
        public int NutritionId { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]
        public double Protein { get; set; }

        [Required]
        public double Carbs { get; set; }

        [Required]
        public double Fat { get; set; }

        public string Vitamins { get; set; } // JSON or delimited string
    }
}
