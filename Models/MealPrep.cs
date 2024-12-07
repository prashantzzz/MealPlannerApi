using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlannerApi.Models
{
    public class MealPrep
    {
        [Key]
        public int MealPrepId { get; set; }

        [ForeignKey("Recipe")]
        [Required]
        public int RecipeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PortionSize { get; set; }

        [Required]
        public string IngredientsRequired { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Prep time must be greater than 0.")]
        public int PrepTime { get; set; }

        public Recipe Recipe { get; set; }
    }
}
