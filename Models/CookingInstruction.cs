using System.ComponentModel.DataAnnotations;

namespace MealPlannerApi.Models
{
    public class CookingInstruction
    {
        [Key]
        public int InstructionId { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [Required]
        public int StepNumber { get; set; } // Order of the step

        [Required, MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string EquipmentNeeded { get; set; } // Optional
    }
}
