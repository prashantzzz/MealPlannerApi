using System.ComponentModel.DataAnnotations;

namespace MealPlannerApi.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required, Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(500)]
        public string ReviewText { get; set; }

        [Required]
        public DateTime ReviewDate { get; set; }
    }
}
