using System.ComponentModel.DataAnnotations;

namespace MealPlannerApi.Models
{
    public class DietaryPreference
    {
        [Key]
        public int PreferenceId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required, MaxLength(50)]
        public string PreferenceType { get; set; } // Vegetarian, Vegan, etc.

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
