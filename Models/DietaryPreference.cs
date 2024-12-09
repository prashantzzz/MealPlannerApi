using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlannerApi.Models
{
    public class DietaryPreference
    {
        [Key]
        public int PreferenceId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(30)]
        public string PreferenceType { get; set; }
        public string Description { get; set; }
    }
}
