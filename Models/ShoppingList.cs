using System.ComponentModel.DataAnnotations;

namespace MealPlannerApi.Models
{
    public class ShoppingList
    {
        [Key]
        public int ShoppingListId { get; set; }

        [Required]
        public int MealPlanId { get; set; }

        [Required, MaxLength(100)]
        public string IngredientName { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required, MaxLength(20)]
        public string Status { get; set; } // Pending, Purchased
    }
}
