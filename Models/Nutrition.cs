using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlannerApi.Models
{
    public class Nutrition
    {
        [Key]
        public int NutritionId { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [Required]
        public int Calories { get; set; }  // Keep as int

        public int Protein { get; set; }   // Change to int
        public int Carbs { get; set; }     // Change to int
        public int Fat { get; set; }       // Change to int
        public string Vitamins { get; set; }

        [ForeignKey("RecipeId")]
        public Recipe Recipe { get; set; }
    }
}
