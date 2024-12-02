using System.ComponentModel.DataAnnotations;

namespace MealPlannerApi.Models
{
    public class MealPlan
    {
        [Key]
        public int MealPlanId { get; set; }

        [Required]
        public int UserId { get; set; }  // Change to int

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required, MaxLength(20)]
        public string MealType { get; set; }

        [Required]
        public int RecipeId { get; set; }
    }
}
